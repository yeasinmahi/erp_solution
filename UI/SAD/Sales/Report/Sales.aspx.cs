using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class Sales : BasePage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlMarque.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));

            }
            else
            {
                //SetReport();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            //Summary    :   This function will use to load report due to page load
            //Created    : Konock/ Apr-25-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId

            DataTable oDTReportData = new DataTable();
            string path = "", unitName = "", unitAddress = "", cus = "", pro = "", frm = "", to = "", dateVal = "", dataSource = "";
            if (rdoType.SelectedIndex == 0)
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/Sales.rdlc");
            }
            else if (rdoType.SelectedIndex == 1)
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesP.rdlc");
            }
            else if (rdoType.SelectedIndex == 2)
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesS.rdlc");
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~/SAD/Sales/Report/ReportTemplete/SalesG.rdlc");
            }

            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                cus = temp[temp.Length - 1];
            }
            catch { }

            temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                pro = temp[temp.Length - 1];
            }
            catch { }

            frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
            to = txtTo.Text + " " + ddlTHour.SelectedValue;

            SalesByCusPro st = new SalesByCusPro();
            if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 1 || rdoType.SelectedIndex == 2)
            {
                oDTReportData = st.GetStatementByCustomerProduct(frm, to, cus, pro
                    , Session[SessionParams.UNIT_ID].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                    , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
                dataSource = "odsCustomerProduct";
            }
            else
            {
                oDTReportData = st.GetStatementByCustomerProductGross(frm, to, cus, pro
                    , Session[SessionParams.UNIT_ID].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                    , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
                dataSource = "odsCustomerProductGross";
            }

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;
                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                if (txtFrom.Text.Trim() == "")
                {
                    dateVal = "As on: " + txtTo.Text;
                }
                else
                {
                    dateVal = "From: " + txtFrom.Text + "      To: " + txtTo.Text;
                }

                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("Title", "Coustomer Statement"));
                parameters.Add(new ReportParameter("Date", dateVal));


                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = dataSource;
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }

        /*
        private void SetReport()
        {
            DataTable table = null;
            string unitName = "", unitAddress = "", cus = "", pro = "";

            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                cus = temp[temp.Length - 1];
            }
            catch { }

            temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                pro = temp[temp.Length - 1];
            }
            catch { }

            string frm, to;
            frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
            to = txtTo.Text + " " + ddlTHour.SelectedValue;

            SalesByCusPro st = new SalesByCusPro();
            if (rdoType.SelectedIndex == 0 || rdoType.SelectedIndex == 1 || rdoType.SelectedIndex == 2)
            {
                table = st.GetStatementByCustomerProduct(frm, to, cus, pro
                    , Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                    , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
            }
            else
            {
                table = st.GetStatementByCustomerProductGross(frm, to, cus, pro
                    , Session["sesUserID"].ToString(), ddlUnit.SelectedValue, ddlCusType.SelectedValue
                    , ddlSo.SelectedValue, bool.Parse(rdoPromo.SelectedValue), ref unitName, ref unitAddress);
            }

            if (table.Rows.Count > 0)
            {          

                if (rdoType.SelectedIndex == 0)
                {
                    rd.Load(Server.MapPath("Sales.rpt"));
                }
                else if (rdoType.SelectedIndex == 1)
                {
                    rd.Load(Server.MapPath("SalesP.rpt"));
                }
                else if (rdoType.SelectedIndex == 2)
                {
                    rd.Load(Server.MapPath("SalesS.rpt"));
                }
                else if (rdoType.SelectedIndex == 3)
                {
                    rd.Load(Server.MapPath("SalesG.rpt"));
                }

                rd.SetDataSource(table);

                ParameterDiscreteValue pv = new ParameterDiscreteValue();

           
                pv.Value = unitName.ToUpper();
                rd.SetParameterValue("UnitName", pv);

                pv.Value = unitAddress;
                rd.SetParameterValue("UnitAddress", pv);

                pv.Value = "Product Delivery";
                rd.SetParameterValue("Title", pv);


                pv.Value = "Date From : " + frm + " To: " + to;
                rd.SetParameterValue("Date", pv);

                CrystalReportViewer1.ReportSource = rd;
            }
            else
            {
                CrystalReportViewer1.ReportSource = null;
            }

        }
        */

        //protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        //{
        //    rd.Dispose();
        //    rd.Clone();
        //    rd.Close();
        //    CrystalReportViewer1.Dispose();
        //}



    }
}

