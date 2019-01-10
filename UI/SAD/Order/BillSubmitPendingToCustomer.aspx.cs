using Flogging.Core;
using SAD_BLL.Customer;
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

namespace UI.SAD.Order
{
    public partial class BillSubmitPendingToCustomer : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid, areaid, regionid, shippoint, salesoffice, rpttypes, intsertby,customerid;
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount, gpendingqnt, gpendingamount;
        DateTime fromdate, todate;
        SalesView bll = new SalesView();
        DataTable dt = new DataTable();
        string xmlpath, email, strSearchKey, code, strCustname;
        #endregion

       

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "customerreturnqnt.xml");
            if (!IsPostBack)
            {
                try
                {
                    try { File.Delete(xmlpath); } catch { }
                    txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                    txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                    //pnlUpperControl.DataBind();
                    hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    hdnemail.Value = HttpContext.Current.Session[SessionParams.EMAIL].ToString();

                }
                catch { }
            }
        }

        //[WebMethod]
        //[ScriptMethod]
        //public static List<string> GetAutoserachingAssetName(string strSearchKey)
        //{
        //    RegistrationRenewals_BLL bll = new RegistrationRenewals_BLL();

        //    List<string> result = new List<string>();
        //    result = bll.AutoSearchAssetName(strSearchKey);
        //    return result;
        //}

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerListunitbase(string prefixText, int count)
        {
            return CustomerInfoSt.GetUnitBaseCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        #region click event
        protected void btncustomertarget_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }
        private void Loadgrid()
        {
            try
            {
                fromdate = DateTime.Parse(txtFromDate.Text);
                todate = DateTime.Parse(txtToDate.Text);

                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttypes = int.Parse(drdlrpttype.SelectedValue.ToString());
                intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (txtCus.Text == "") { customerid = 0; }
                else {
                    char[] ch = { '[', ']' };
                    string[] tmp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdncustomerid.Value = tmp[tmp.Length - 1];
                    customerid = int.Parse(hdncustomerid.Value);
                }
                
                
                if (rpttypes == 1)
                {
                    
                    dt = bll.GetdataforBillSubmission(rpttypes, unitid, fromdate, todate, salesoffice, customerid, "", 0);
                    if (dt.Rows.Count > 0)
                    {
                        grdvBillpendingtopsheet.DataSource = null;
                        grdvBillpendingtopsheet.DataBind();
                        grdvCustomerlistforbill.DataSource = null;
                        grdvCustomerlistforbill.DataBind();
                        dgvCustomervsReturnqnt.DataSource = dt;
                        dgvCustomervsReturnqnt.DataBind();

                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }
                if (rpttypes == 3)
                {
                    
                    dt = bll.GetdataforBillSubmission(3, unitid, fromdate, todate, salesoffice, 0, "", 0);
                    if (dt.Rows.Count > 0)
                    {

                        dgvCustomervsReturnqnt.DataSource = null;
                        dgvCustomervsReturnqnt.DataBind();
                        grdvCustomerlistforbill.DataSource = null;
                        grdvCustomerlistforbill.DataBind();
                        grdvBillpendingtopsheet.DataSource = dt;
                        grdvBillpendingtopsheet.DataBind();

                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }
                if (rpttypes == 4)
                {
                   
                    dt = bll.GetdataforBillSubmission(4, unitid, fromdate, todate, salesoffice, 0, "", 0);
                    if (dt.Rows.Count > 0)
                    {

                        dgvCustomervsReturnqnt.DataSource = null;
                        dgvCustomervsReturnqnt.DataBind();
                        grdvBillpendingtopsheet.DataSource = null;
                        grdvBillpendingtopsheet.DataBind();
                        grdvCustomerlistforbill.DataSource = dt;
                        grdvCustomerlistforbill.DataBind();

                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }

            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void Complete_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ',' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string custid = searchKey[0].ToString();
            Session["intcustid"] = custid;
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int salesoffid = int.Parse(ddlSo.SelectedValue.ToString());
            string dtfromdate = dteFromDate.ToString();

            Session["dtfromdate"] = dtfromdate;
            string dtetodate = dtTodate.ToString();
            Session["dtetodate"] = dtetodate;
            string intsalesoffice = salesoffid.ToString();
            Session["intsalesoffice"] = intsalesoffice;

            
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('BillSubmitPendingToCustomerDet.aspx');", true);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                fromdate = DateTime.Parse(txtFromDate.Text);
                todate = DateTime.Parse(txtToDate.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttypes = int.Parse(drdlrpttype.SelectedValue.ToString());
                intsertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                //try
                //{
                if (dgvCustomervsReturnqnt.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvCustomervsReturnqnt.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvCustomervsReturnqnt.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            //territoryid, custname, custid, targetqnt, areaid, salesofficeid
                           
                            string custid = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnCustomerID")).Value.ToString();
                            string donum = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdndonum")).Value.ToString();
                            string chnum = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnchallan")).Value.ToString();
                            string prmchqnt = ((HiddenField)dgvCustomervsReturnqnt.Rows[index].FindControl("hdnprimarychallanq")).Value.ToString();
                            TextBox txtreturnqnt = (TextBox)dgvCustomervsReturnqnt.Rows[index].Cells[4].FindControl("txtretqnt");
                            string txtretq = txtreturnqnt.Text;
                            string sofid = salesoffice.ToString();
                            Createxml(custid, donum, chnum, prmchqnt, txtretq, sofid);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("Customerreturnqnt");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Customerreturnqnt>" + xmlString + "</Customerreturnqnt>";
                    dt = bll.GetdataforBillSubmission(2, unitid, fromdate, todate, salesoffice, 0, xmlString, intsertby);
                    try { File.Delete(xmlpath); } catch { }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    dgvCustomervsReturnqnt.DataSource = "";
                    dgvCustomervsReturnqnt.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }
        
}
        //intSOID,strName,intCustomerID,intTarget,dteFormdate,dteTodate,dteActiondate,intParent

        #region ================ Generate XML and Others ==========        
        private void Createxml(string CustID, string DONumber, string Challan, string PrimaryChallanQnt, string decNetqntentry, string salesoffice)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Customerreturnqnt");
                XmlNode addItem = CreateNode(doc, CustID, DONumber, Challan, PrimaryChallanQnt, decNetqntentry, salesoffice);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Customerreturnqnt");
                XmlNode addItem = CreateNode(doc,CustID, DONumber, Challan, PrimaryChallanQnt, decNetqntentry, salesoffice);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string CustID, string DONumber, string Challan, string PrimaryChallanQnt, string decNetqntentry, string salesoffice)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute CCustID = doc.CreateAttribute("CustID"); CCustID.Value = CustID;
            XmlAttribute DDONumber = doc.CreateAttribute("DONumber"); DDONumber.Value = DONumber;
            XmlAttribute CChallan = doc.CreateAttribute("Challan"); CChallan.Value = Challan;
            XmlAttribute PPrimaryChallanQnt = doc.CreateAttribute("PrimaryChallanQnt"); PPrimaryChallanQnt.Value = PrimaryChallanQnt;
            XmlAttribute netqntentry = doc.CreateAttribute("decNetqntentry");
            netqntentry.Value = decNetqntentry;
            XmlAttribute Salesofficeid = doc.CreateAttribute("salesoffice"); Salesofficeid.Value = salesoffice;
            node.Attributes.Append(CCustID);
            node.Attributes.Append(DDONumber);
            node.Attributes.Append(CChallan);
            node.Attributes.Append(PPrimaryChallanQnt);
            node.Attributes.Append(netqntentry);
            node.Attributes.Append(Salesofficeid);
            return node;
        }
        #endregion


        #endregion
        #region change event
    
     
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
      

        protected void dgvCustomervsReturnqnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void grdvBillpendingtopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
        protected void drdlrpttype_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void grdvBillpendingtopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }
        protected void grdvCustomerlistforbill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

    

      
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = drdlUnitName.SelectedValue;
        }

        protected void drdlUnitName_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = drdlUnitName.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        #endregion

    }
}