using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class ProductBaseCommission : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int prouductid,unitid, intmainheadcoaid, enrol; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll = new StatementC();
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, unitname, productname;
        decimal totalcom, comrate,selectedtotalcom=0;

   

        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteProductBaseCommission.xml");
            try
            {
                try { File.Delete(xmlpath); } catch { }
                //txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                //txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnemail.Value = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            }
            catch { }
        }
        #region =============== Click Event Here =====================     
        protected void btnShow_Click(object sender, EventArgs e)
        {
            //try
            //{
             
                comrate = decimal.Parse(txtcomrate.Text.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                prouductid = int.Parse(drdlproductname.SelectedValue);
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                dt = bll.GetProductBaseCommission(dtFromDate, dtToDate, comrate, unitid, prouductid);
                if (dt.Rows.Count > 0)
                {
                    grdvProductbaseCommission.DataSource = dt;
                    grdvProductbaseCommission.DataBind();
                    decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalCom1"));
                    decimal totaldelvqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decDelvQntf1"));
                    decimal totalsoldshop = dt.AsEnumerable().Sum(row => row.Field<decimal>("intSoldShopf1"));
                    lblTotalcom.Visible = true;
                    lbltotalcomamount.Text = Convert.ToString(txtTotalCommission);
                    lblTotalcashdoqnt.Visible = true;
                    lblcashdoqnt.Text = Convert.ToString(totalsoldshop);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            //}
            //catch { }
        }

        protected void btnJVCreation_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                if (grdvProductbaseCommission.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvProductbaseCommission.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvProductbaseCommission.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            //string strtotalcost = ((TextBox)grdvForAuditBillChecking.Rows[RowIndex].FindControl("txtCMHR")).Text;
                            //shopid,  customerid,  custterritoryid,  salesofficeid,  targetqnt
                            string customercoaid = ((HiddenField)grdvProductbaseCommission.Rows[index].FindControl("hdncustcoaid")).Value.ToString();
                            string eachcustnarration = ((HiddenField)grdvProductbaseCommission.Rows[index].FindControl("hdncustnarrationindividual")).Value.ToString();
                            string eachcustamount = ((HiddenField)grdvProductbaseCommission.Rows[index].FindControl("hdneachcustcommission")).Value.ToString();
                            string customername = ((HiddenField)grdvProductbaseCommission.Rows[index].FindControl("hdnCustname")).Value.ToString();
                            
                            selectedtotalcom = selectedtotalcom + decimal.Parse(eachcustamount);
                            string selectedgrand = Convert.ToString(selectedtotalcom);
                            Createxml(customercoaid, eachcustnarration, eachcustamount, customername);
                        }
                    }

                    #region ------------ Insert into dataBase -----------
                    DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                    unitname = drdlUnitName.SelectedItem.Text.ToString();
                    productname = drdlproductname.SelectedItem.Text.ToString();
                    strVcode = "voucherJV";
                    strPrefix = "JV";
                    glblnarration = unitname + productname+" Commission From : " + txtFromDate.Text + "to " + txtToDate.Text;
                   
                    totalcom = selectedtotalcom;
                    enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    
                     intmainheadcoaid = int.Parse(drdlmaincoaheadid.SelectedItem.Value.ToString());
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteProductBaseCommission");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteProductBaseCommission>" + xmlString + "</RemoteProductBaseCommission>";
                    dt = bll.insertdataforindividualproductcommissionjv(xmlString, unitid, strVcode, strPrefix, glblnarration, totalcom, enrol, intmainheadcoaid);
                    lblCreatedjvnumber.Text = dt.Rows[0]["creatjv"].ToString();
                    try { File.Delete(xmlpath); } catch { }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvProductbaseCommission.DataSource = "";
                    grdvProductbaseCommission.DataBind();
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
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            dt = bll.GetItembaseofUnit(unitid);
            drdlproductname.DataSource = dt;
            drdlproductname.DataTextField = "strProductName";
            drdlproductname.DataValueField = "intID";
            drdlproductname.DataBind();

        }
        #region ================ Generate XML and Others ==========        
        private void Createxml(string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteProductBaseCommission");
                XmlNode addItem = CreateNode(doc, customercoaid, eachcustnarration, eachcustamount, customername);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteProductBaseCommission");
                XmlNode addItem = CreateNode(doc, customercoaid, eachcustnarration, eachcustamount, customername);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            XmlNode node = doc.CreateElement("comm");
            XmlAttribute Customercoaid = doc.CreateAttribute("customercoaid"); Customercoaid.Value = customercoaid;
            XmlAttribute Eachcustnarration = doc.CreateAttribute("eachcustnarration"); Eachcustnarration.Value = eachcustnarration;
            XmlAttribute Eachcustamount = doc.CreateAttribute("eachcustamount"); Eachcustamount.Value = eachcustamount;
            XmlAttribute Customername = doc.CreateAttribute("customername"); Customername.Value = customername;
            //XmlAttribute Selectedtotalcommission = doc.CreateAttribute("selectedtotalcommission");Selectedtotalcommission.Value = selectedtotalcommission;
            node.Attributes.Append(Customercoaid);
            node.Attributes.Append(Eachcustnarration);
            node.Attributes.Append(Eachcustamount);
            node.Attributes.Append(Customername);
            //node.Attributes.Append(Selectedtotalcommission);
            return node;
        }
        #endregion


        protected void grdvProductbaseCommission_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvProductbaseCommission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                grdvProductbaseCommission.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("ProductBaseCommission.xls", grdvProductbaseCommission);
            }
            catch { }
        }
    }
}