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
using BLL.Accounts.Banking;

using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Banking.Report
{
    public partial class AccountReconcile : BasePage
    {
        // ReportDocument rd = new ReportDocument();
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Banking\\Report\\AccountReconcile";
        string stop = "stopping Accounts\\Banking\\Report\\AccountReconcile";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {

            }
        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            //ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetReport();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            //ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        private void GetReport()
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Banking\\Report\\AccountReconcile   Account Reconcile Report ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {


                string path = HttpContext.Current.Server.MapPath("~/Accounts/Banking/Report/ReportTemplates/AccountReconcile.rdlc");
            DataTable oDTReportData = new DataTable();

            string unitName = "", unitAddress = "", bankName = "", branchName = "";
            decimal bankBookBalance = 0;
            decimal bankStatementBalance = 0;
            decimal bankActualStatementBalance = 0;
            DateTime lastDay = Convert.ToDateTime(txtFrom.Text);
            string Date ="As On " + CommonClass.GetShortDateAtLocalDateFormat(lastDay);
            Reconcile rc = new Reconcile();

            oDTReportData = rc.GetAccountStatementData(ddlAccount.SelectedValue, txtFrom.Text, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref bankName, ref branchName, ref unitName, ref unitAddress, ref bankBookBalance, ref bankStatementBalance, ref bankActualStatementBalance, ref lastDay);
                DateTime? frm = null, to = null, ld = null; int? bnkid;
                
                try
                {
                    bnkid = int.Parse(ddlAccount.SelectedValue);
                }
                catch { bnkid = 0; }
                try
                {
                    to = DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value.Date;
                }
                catch { to = DateTime.Now.Date; }
                unitName = "";
                string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Accounts/AccountReconcile" + "&dteLastDate=" + "" + "&monBankStatementClosing=" + "" + "&monBankTotal=" + "" + "&monBankBookBalance=" + "" + "&unitName=" + unitName + "&bankAccountId=" + bnkid + "&fromDate=" + frm + "&toDate=" + to + "&userID=" + Session[SessionParams.USER_ID].ToString() + "&unitID=" + ddlUnit.SelectedValue + "&unitAddress=" + unitAddress + "&bankBookBal=" + bankBookBalance + "&bankName=" + bankName + "&branchName=" + branchName + "&Date=" + Date + "&bankStatementBal=" + bankStatementBalance + "&actualBankStBal=" + bankActualStatementBalance + "&AccountNo=" + ddlAccount.SelectedItem.Text + "&rc:LinkTarget=_self";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
                //ReportViewer1.Reset(); //important/
                //if (oDTReportData.Rows.Count > 0)
                //{
                //    ReportViewer1.Reset(); //important
                //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //    ReportViewer1.LocalReport.EnableHyperlinks = true;

                //    LocalReport objReport = ReportViewer1.LocalReport;
                //    objReport.DataSources.Clear();
                //    objReport.ReportPath = path;


                //    // Add Parameter 
                //    List<ReportParameter> parameters = new List<ReportParameter>();
                //    //parameters.Add(new ReportParameter("bankBookBal", bankBookBalance.ToString()));
                //    parameters.Add(new ReportParameter("Date", "As On " + CommonClass.GetShortDateAtLocalDateFormat(lastDay)));
                //    parameters.Add(new ReportParameter("Title", "Account Reconcile"));
                //    parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                //    parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                //    parameters.Add(new ReportParameter("Bank", "Bank: " + bankName));
                //    parameters.Add(new ReportParameter("Branch", "Branch: " + branchName));
                //    parameters.Add(new ReportParameter("AccountNo", "Acc. No: " + ddlAccount.SelectedItem.Text));
                //    parameters.Add(new ReportParameter("bankStatementBal", bankStatementBalance.ToString()));
                //    parameters.Add(new ReportParameter("actualBankStBal", bankActualStatementBalance.ToString()));
                //    ReportViewer1.LocalReport.SetParameters(parameters);
                //    ReportViewer1.ShowParameterPrompts = false;
                //    ReportViewer1.ShowPromptAreaButton = false;
                //    ReportViewer1.LocalReport.Refresh();

                //    //Add Datasourdce
                //    ReportDataSource reportDataSource = new ReportDataSource();
                //    reportDataSource.Name = "odsAccountReconcile";
                //    reportDataSource.Value = oDTReportData;
                //    objReport.DataSources.Add(reportDataSource);
                //    objReport.Refresh();

                //}
                //else
                //{
                //    ReportViewer1.Reset(); // CrystalReportViewer1.ReportSource = null;
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                //}
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

    }
}
