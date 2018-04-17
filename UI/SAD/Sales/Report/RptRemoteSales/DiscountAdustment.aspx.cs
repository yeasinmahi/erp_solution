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
    public partial class DiscountAdustment : BasePage
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        StatementC bll = new StatementC();
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike;
        decimal totalcom, selectedtotalcom = 0;
        #endregion
        protected void grdvDiscountAdjustment_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvDiscountAdjustment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + "_" + "discountadjustment.xml");
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

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                int soid = Convert.ToInt32(ddlSo.SelectedValue.ToString());
                rptname = drdlSalesview.SelectedItem.Text.ToString();
                int unitid= Convert.ToInt32(drdlUnitName.SelectedValue.ToString());
                dt = bll.getdataDiscountAdjustment(dtFromDate, dtToDate, soid, rptname, unitid);
                if (dt.Rows.Count > 0)
                {
                    grdvDiscountAdjustment.DataSource = dt;
                    grdvDiscountAdjustment.DataBind();
                    decimal txtTotalCommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCashCommission1"));
                    decimal adjustableamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("monCashCommission1"));
                    
                    lblTotalcom.Visible = true;
                    lbltotalcomamount.Text = Convert.ToString(txtTotalCommission);
                    lblTotalcashdoqnt.Visible = true;
                    lblcashdoqnt.Text = Convert.ToString(adjustableamount);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }





        }
        #region ================ Generate XML and Others ==========        
        private void Createxml(string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("RemoteCommission");
                XmlNode addItem = CreateNode(doc, customercoaid, eachcustnarration, eachcustamount, customername);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("RemoteCommission");
                XmlNode addItem = CreateNode(doc, customercoaid, eachcustnarration, eachcustamount, customername);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string customercoaid, string eachcustnarration, string eachcustamount, string customername)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Customercoaid = doc.CreateAttribute("customercoaid"); Customercoaid.Value = customercoaid;
            XmlAttribute Eachcustnarration = doc.CreateAttribute("eachcustnarration"); Eachcustnarration.Value = eachcustnarration;
            XmlAttribute Eachcustamount = doc.CreateAttribute("eachcustamount"); Eachcustamount.Value = eachcustamount;
            XmlAttribute Customername = doc.CreateAttribute("customername"); Customername.Value = customername;

            node.Attributes.Append(Customercoaid);
            node.Attributes.Append(Eachcustnarration);
            node.Attributes.Append(Eachcustamount);
            node.Attributes.Append(Customername);

            return node;
        }
        #endregion
        protected void btnJVCreation_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                //try
                //{
                if (grdvDiscountAdjustment.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvDiscountAdjustment.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvDiscountAdjustment.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            //shopid,  customerid,  custterritoryid,  salesofficeid,  targetqnt
                            string customercoaid = ((HiddenField)grdvDiscountAdjustment.Rows[index].FindControl("hdncustcoaid")).Value.ToString();
                            string eachcustnarration = ((HiddenField)grdvDiscountAdjustment.Rows[index].FindControl("hdncustnarrationindividual")).Value.ToString();
                            string eachcustamount = ((HiddenField)grdvDiscountAdjustment.Rows[index].FindControl("hdncustomercommissionndividual")).Value.ToString();
                            string customername = ((HiddenField)grdvDiscountAdjustment.Rows[index].FindControl("hdncustname")).Value.ToString();
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
                    string unitname = drdlUnitName.SelectedItem.ToString();
                    rptname = drdlSalesview.SelectedItem.Text.ToString();
                    strVcode = "voucherJV";
                    strPrefix = "JV";
                    glblnarration = unitname+" "+ " "+ rptname + " Commission from :" + txtFromDate.Text + "to " + txtToDate.Text;
                    totalcom = selectedtotalcom;
                  

                    enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intmainheadcoaid = int.Parse(ddlcoa.SelectedValue.ToString());
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteCommission");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteCommission>" + xmlString + "</RemoteCommission>";
                    dt = bll.insertdataforsalescommissionjv(xmlString, unitid, strVcode, strPrefix, glblnarration, totalcom, enrol, intmainheadcoaid);
                    lblCreatedjvnumber.Text = dt.Rows[0]["creatjv"].ToString();
                    try { File.Delete(xmlpath); } catch { }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvDiscountAdjustment.DataSource = "";
                    grdvDiscountAdjustment.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                //}
                //catch { File.Delete(xmlpath); }


            }

        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}