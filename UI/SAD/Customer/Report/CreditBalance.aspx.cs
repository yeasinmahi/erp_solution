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
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Customer.Report
{
    public partial class CreditBalance : BasePage
    {
        //ReportDocument rd = new ReportDocument();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Customer\\Report\\CreditBalance";
        string stop = "stopping SAD\\Customer\\Report\\CreditBalance";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlMarque.DataBind();

                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);

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
            //Created    : Konock/ Apr-24-2012
            //Modified   :   
            //Parameters :   intEmployeeID,intMonthID,intYearId
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Customer\\Report\\CreditBalance  Credit Balance", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

            string path = HttpContext.Current.Server.MapPath("~/SAD/Customer/Report/ReportTemplete/CreditBalance.rdlc");
            DataTable oDTReportData = new DataTable();
            string unitName = "", unitAddress = "";
            string cus = "";

            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                cus = temp[temp.Length - 1];
            }
            catch { }

            StatementC st = new StatementC();
            oDTReportData = st.GetStatementByCustomerCreditBalance(txtTo.Text + " " + ddlTHour.SelectedValue, cus
                , Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, "", ddlSo.SelectedValue, ddlCusType.SelectedValue
                , ref unitName, ref unitAddress);

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;
                string dateVal = "Date: " + txtTo.Text;
                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("Title", "Coustomer Credit Balance"));
                parameters.Add(new ReportParameter("Date", dateVal));


                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsCustomerCrBalance";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        /*
        private void SetReport()
        {        
            DataTable table = null;
            string unitName = "", unitAddress = "";        
            string cus = "";
        
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                cus=temp[temp.Length - 1];
            }
            catch { }

            StatementC st = new StatementC();
            table = st.GetStatementByCustomerCreditBalance(txtTo.Text+" "+ ddlTHour.SelectedValue, cus
                , Session["sesUserID"].ToString(), ddlUnit.SelectedValue
                , "", ddlSo.SelectedValue, ddlCusType.SelectedValue, ref unitName, ref unitAddress);

            if (table.Rows.Count > 0)
            {
            

                rd.Load(Server.MapPath("CreditBalance.rpt"));
                rd.SetDataSource(table);

                ParameterDiscreteValue pv = new ParameterDiscreteValue();

                //pv.Value = accountName;
                //rd.SetParameterValue("AccountName", pv);

                //pv.Value = accountCode;
                //rd.SetParameterValue("AccountCode", pv);

                pv.Value = unitName.ToUpper();
                rd.SetParameterValue("UnitName", pv);

                pv.Value = unitAddress;
                rd.SetParameterValue("UnitAddress", pv);

                pv.Value = "Customer Credit Balance";
                rd.SetParameterValue("Title", pv);

            
                pv.Value = "Date: "+txtTo.Text;            
                rd.SetParameterValue("Date", pv);

                pv.Value = "Total";
                rd.SetParameterValue("Total", pv);

                CrystalReportViewer1.ReportSource = rd;
                        
            }
            else
            {
                CrystalReportViewer1.ReportSource = null;
            }

        }
        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rd.Dispose();
            rd.Clone();
            rd.Close();
            CrystalReportViewer1.Dispose();  
        }
         */
    }
}


