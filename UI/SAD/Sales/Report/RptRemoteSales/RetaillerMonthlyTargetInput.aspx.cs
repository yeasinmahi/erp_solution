using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RetaillerMonthlyTargetInput : BasePage
    {
        #region =========== Global Variable Declareation ==========
        int enrol,reporttype,coaid, intCOAid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll=new StatementC(); 
        bool ysnChecked;
        string xmlpath, email,  strSearchKey, code, strCustname;
        #endregion

      

        protected void btnCreateJv_Click(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteRetailTargetMonthly.xml");
            if (!IsPostBack)
            {
                try
                {
                    txtcus.Attributes.Add("onkeyUp", "SearchText();");
                }
                catch { }
            }
        }

        [WebMethod]
        public static List<string> GetAutoCompletecustomer(string strSearchKey)
        {

          SalesView   bll = new SalesView();
            List<string> result = new List<string>();
            result = bll.AutoSearchcustomer(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), strSearchKey);
            return result;
        }

        #region =============== Insert Event Here =====================     
        protected void btnShopTargetInput_Click(object sender, EventArgs e)
        {
            //email,  dtfromdate,  dttodate,  reportoption,  customerCOAId
            try
            {
                reporttype = 1;
                strSearchKey = txtcus.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                code = arrayKey[1].ToString();
                strCustname = strSearchKey;
                intCOAid = int.Parse(code);
                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString(); 
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                dt = bll.getdataRetaillshopMonthlySalesAndTarget(email, dtFromDate, dtToDate, reporttype, intCOAid, "");
                if (dt.Rows.Count > 0)
                {
                    grdvShopTargetinput.DataSource = dt;
                    grdvShopTargetinput.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                    if (grdvShopTargetinput.Rows.Count > 0)
                    {
                        for (int index = 0; index < grdvShopTargetinput.Rows.Count; index++)
                        {
                            if (((CheckBox)grdvShopTargetinput.Rows[index].FindControl("chkbx")).Checked == true)
                            {
                                //shopid,  customerid,  custterritoryid,  salesofficeid,  targetqnt
                                string shopid = ((HiddenField)grdvShopTargetinput.Rows[index].FindControl("hdnshopid")).Value.ToString();
                                string custid = ((HiddenField)grdvShopTargetinput.Rows[index].FindControl("hdnCustomerID")).Value.ToString();
                                string terrid = ((HiddenField)grdvShopTargetinput.Rows[index].FindControl("hdnTerritoryid")).Value.ToString();
                                string salesof = ((HiddenField)grdvShopTargetinput.Rows[index].FindControl("hdnSalesoffid")).Value.ToString();
                                string unitid = ((HiddenField)grdvShopTargetinput.Rows[index].FindControl("hdnunitid")).Value.ToString();
                                TextBox txttarget = (TextBox)grdvShopTargetinput.Rows[index].Cells[4].FindControl("txtdecTarget");
                                string targetqnt = txttarget.Text;
                                Createxml(shopid, custid, terrid, salesof,targetqnt);
                            }
                        }

                    #region ------------ Insert into dataBase -----------
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    strSearchKey = txtcus.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        code = arrayKey[1].ToString();
                        strCustname = strSearchKey;
                        intCOAid = int.Parse(code);
                        DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                        XmlDocument doc = new XmlDocument();
                        doc.Load(xmlpath);
                        XmlNode dSftTm = doc.SelectSingleNode("RemoteRetailTargetMonthly");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<RemoteRetailTargetMonthly>" + xmlString + "</RemoteRetailTargetMonthly>";
                        dt = bll.getdataRetaillshopMonthlySalesAndTarget(email, dtFromDate, dtToDate, 2, intCOAid, xmlString);
                        try { File.Delete(xmlpath); } catch { }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);

                        
                        #endregion ------------ Insertion End ----------------
                        grdvShopTargetinput.DataSource = "";
                        grdvShopTargetinput.DataBind();
                }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                    }
                //}
                //catch { File.Delete(xmlpath); }


            }
        }
        #endregion

        #region ================ Generate XML and Others ==========        
        private void Createxml(string shopid, string customerid, string custterritoryid, string salesofficeid, string targetqnt)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteRetailTargetMonthly");
                XmlNode addItem = CreateNode(doc,  shopid,  customerid,  custterritoryid,  salesofficeid,  targetqnt);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteRetailTargetMonthly");
                XmlNode addItem = CreateNode(doc, shopid, customerid, custterritoryid, salesofficeid, targetqnt);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string shopid, string customerid, string custterritoryid, string salesofficeid, string targetqnt)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Shopid = doc.CreateAttribute("shopid");Shopid.Value = shopid;
            XmlAttribute Customerid = doc.CreateAttribute("customerid"); Customerid.Value = customerid;
            XmlAttribute Custterritoryid = doc.CreateAttribute("custterritoryid"); Custterritoryid.Value = custterritoryid;
            XmlAttribute Salesofficeid = doc.CreateAttribute("salesofficeid"); Salesofficeid.Value = salesofficeid;
            XmlAttribute Targetqnt = doc.CreateAttribute("targetqnt"); Targetqnt.Value = targetqnt;
            node.Attributes.Append(Shopid);
            node.Attributes.Append(Customerid);
            node.Attributes.Append(Custterritoryid);
            node.Attributes.Append(Salesofficeid);
            node.Attributes.Append(Targetqnt);
            return node;
        }
        #endregion
        protected void grdvShopTargetinput_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       
    }
}