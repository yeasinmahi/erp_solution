using SAD_BLL.Customer.Report;
using SAD_BLL.Sales;
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
    public partial class ProductTransferJV : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int enrol, reporttype,reportnameid, coaid, unitid, intmainheadcoaid; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        SalesView bll = new SalesView();
        StatementC objbll = new StatementC();
        bool ysnChecked;
        string xmlpath, email, strVcode, strPrefix, glblnarration, rptname, salesofficelike,factrate,ghatrate;

        

        decimal totalcom, selectedtotalcom = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "remoteCommission.xml");

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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            reporttype =int.Parse (ddldettopsheet.SelectedValue.ToString());
            email = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int soid = Convert.ToInt32(ddlSo.SelectedValue.ToString());
            int unitid = Convert.ToInt32(drdlUnitName.SelectedValue.ToString());
            factrate = txtfactrate.Text.ToString();
            ghatrate = txtghatRate.Text.ToString();
            salesofficelike = ddlSo.SelectedItem.Text.ToString();
            rptname = drdlSalesview.SelectedItem.Text.ToString();
            reportnameid= int.Parse(drdlSalesview.SelectedValue.ToString());
            //dtfromdate, dttodate, Convert.ToDecimal(factoryrate), Convert.ToDecimal(ghatrate), salesofname, salesofice, reptname, unitid
            //try
            //{
            if (reporttype == 1 && reportnameid == 4)
                {
                    dt = bll.getdataSalesCommissionCommon(dtFromDate, dtToDate,factrate,ghatrate,salesofficelike, soid, rptname, unitid);
                    if (dt.Rows.Count > 0)
                    {
                    grdvcommoncommission.DataSource = null;
                    grdvcommoncommission.DataBind();
                    grdvDetDistIHB.DataSource = null;
                    grdvDetDistIHB.DataBind();
                    grdvDetaillsReport.DataSource = dt;
                    grdvDetaillsReport.DataBind();
                    decimal txtfacttotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("factory1"));
                    decimal txtghattotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("ghat1"));
                    decimal txttotaldelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("total1"));
                    decimal txttoalcommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("commissonamount"));
                    grdvDetaillsReport.FooterRow.Cells[4].Text = "zxTotal";
                    grdvDetaillsReport.FooterRow.Cells[5].Text = txttotaldelv.ToString("N2");
                    grdvDetaillsReport.FooterRow.Cells[6].Text = txtfacttotal.ToString("N2");
                    grdvDetaillsReport.FooterRow.Cells[7].Text = txtghattotal.ToString("N2");
                    grdvDetaillsReport.FooterRow.Cells[8].Text = txttoalcommission.ToString("N2");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                }
            else if (reporttype == 1 && reportnameid == 5)
            {
                dt = bll.getdataIHBandDistributor(dtFromDate, dtToDate);
                if (dt.Rows.Count > 0)
                {
                    grdvcommoncommission.DataSource = null;
                    grdvcommoncommission.DataBind();
                    grdvDetaillsReport.DataSource = null;
                    grdvDetaillsReport.DataBind();
                    grdvDetDistIHB.DataSource = dt;
                    grdvDetDistIHB.DataBind();
                    decimal txtdistsales = dt.AsEnumerable().Sum(row => row.Field<decimal>("EntpDelv"));
                    decimal txtihbsales = dt.AsEnumerable().Sum(row => row.Field<decimal>("IHBDelv"));
                    decimal txttotaltarg = dt.AsEnumerable().Sum(row => row.Field<decimal>("decTarget1"));
                    decimal txttotaldelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalsales"));
                    decimal txttoalcommission = dt.AsEnumerable().Sum(row => row.Field<decimal>("Commission Total"));
                    grdvDetDistIHB.FooterRow.Cells[4].Text = "zxTotal";
                    grdvDetDistIHB.FooterRow.Cells[5].Text = txtdistsales.ToString("N2");
                    grdvDetDistIHB.FooterRow.Cells[6].Text = txtihbsales.ToString("N2");
                    grdvDetDistIHB.FooterRow.Cells[7].Text = txttotaltarg.ToString("N2");
                    grdvDetDistIHB.FooterRow.Cells[8].Text = txttotaldelv.ToString("N2");
                    grdvDetDistIHB.FooterRow.Cells[11].Text = txttoalcommission.ToString("N2");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
            else if(reporttype == 2 && reportnameid==4 )
            {
                dt = bll.getdataSalesCommissionCommon(dtFromDate, dtToDate, factrate, ghatrate, salesofficelike, soid, rptname, unitid);
                if (dt.Rows.Count > 0)
                {
                    grdvDetaillsReport.DataSource = null;
                    grdvDetaillsReport.DataBind();
                    grdvDetDistIHB.DataSource = null;
                    grdvDetDistIHB.DataBind();
                    grdvcommoncommission.DataSource = dt;
                    grdvcommoncommission.DataBind();
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (reporttype == 2 && reportnameid == 5)
            {
                dt = bll.getdataSalesCommissionCommon(dtFromDate, dtToDate, factrate, ghatrate, salesofficelike, soid, rptname, unitid);
                if (dt.Rows.Count > 0)
                {
                    grdvDetaillsReport.DataSource = null;
                    grdvDetaillsReport.DataBind();
                    grdvDetDistIHB.DataSource = null;
                    grdvDetDistIHB.DataBind();
                    grdvcommoncommission.DataSource = dt;
                    grdvcommoncommission.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

            //}
            //catch { }
        }

        protected void btnJVCreation_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (grdvcommoncommission.Rows.Count > 0)
                {
                    for (int index = 0; index < grdvcommoncommission.Rows.Count; index++)
                    {
                        if (((CheckBox)grdvcommoncommission.Rows[index].FindControl("chkbx")).Checked == true)
                        {
                            
                            string customercoaid = ((HiddenField)grdvcommoncommission.Rows[index].FindControl("hdncustcoaid")).Value.ToString();
                            string eachcustnarration = ((HiddenField)grdvcommoncommission.Rows[index].FindControl("hdncustnarrationindividual")).Value.ToString();
                            string eachcustamount = ((HiddenField)grdvcommoncommission.Rows[index].FindControl("hdncustomercommissionndividual")).Value.ToString();
                            string customername = ((HiddenField)grdvcommoncommission.Rows[index].FindControl("hdncustname")).Value.ToString();
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
                    strVcode = "voucherJV";
                    strPrefix = "JV";
                    string unitname = drdlUnitName.SelectedItem.Text.ToString();
                    string prgname = drdlSalesview.SelectedItem.Text.ToString();
                    glblnarration = unitname +" " +prgname+ " Commission from :" + txtFromDate.Text + "to " + txtToDate.Text;
                    totalcom = selectedtotalcom;
                   

                    enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    
                    intmainheadcoaid = int.Parse(ddlcoa.SelectedValue.ToString());
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dSftTm = doc.SelectSingleNode("RemoteCommission");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<RemoteCommission>" + xmlString + "</RemoteCommission>";
                    dt = objbll.insertdataforsalescommissionjv(xmlString, unitid, strVcode, strPrefix, glblnarration, totalcom, enrol, intmainheadcoaid);
                    lblCreatedjvnumber.Text = dt.Rows[0]["creatjv"].ToString();
                    try { File.Delete(xmlpath); } catch { }

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                    #endregion ------------ Insertion End ----------------
                    grdvcommoncommission.DataSource = "";
                    grdvcommoncommission.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                }
                }
                catch { File.Delete(xmlpath); }


            }
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
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvDetaillsReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvDetaillsReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grdvcommoncommission_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvcommoncommission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            reporttype = int.Parse(ddldettopsheet.SelectedValue.ToString());
            reportnameid = int.Parse(drdlSalesview.SelectedValue.ToString());
            if (reporttype == 1 && reportnameid==4)
            {
                try
                {
                    grdvDetaillsReport.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("Detghattransfer.xls", grdvDetaillsReport);
                }
                catch { }
            }

            else if (reporttype == 1 && reportnameid == 5)
            {
                try
                {
                    grdvDetDistIHB.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("DetDistIHB.xls", grdvDetDistIHB);
                }
                catch { }
            }
        }
        //protected void grdvDiscountAdjustment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void grdvDiscountAdjustment_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}
    }
}