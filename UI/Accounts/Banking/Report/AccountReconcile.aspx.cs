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

namespace UI.Accounts.Banking.Report
{
    public partial class AccountReconcile : BasePage
    {
        // ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {

            }
        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetReport();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
            ReportViewer1.Reset(); //CrystalReportViewer1.ReportSource = null;
        }
        private void GetReport()
        {

            string path = HttpContext.Current.Server.MapPath("~/Accounts/Banking/Report/ReportTemplates/AccountReconcile.rdlc");
            DataTable oDTReportData = new DataTable();

            string unitName = "", unitAddress = "", bankName = "", branchName = "";
            decimal bankBookBalance = 0;
            decimal bankStatementBalance = 0;
            decimal bankActualStatementBalance = 0;
            DateTime lastDay = DateTime.Now;

            Reconcile rc = new Reconcile();

            oDTReportData = rc.GetAccountStatementData(ddlAccount.SelectedValue, txtFrom.Text, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, ref bankName, ref branchName, ref unitName, ref unitAddress, ref bankBookBalance, ref bankStatementBalance, ref bankActualStatementBalance, ref lastDay);

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;


                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                //parameters.Add(new ReportParameter("bankBookBal", bankBookBalance.ToString()));
                parameters.Add(new ReportParameter("Date", "As On " + CommonClass.GetShortDateAtLocalDateFormat(lastDay)));
                parameters.Add(new ReportParameter("Title", "Account Reconcile"));
                parameters.Add(new ReportParameter("UnitAddress", unitAddress.ToUpper()));
                parameters.Add(new ReportParameter("UnitName", unitName.ToUpper()));
                parameters.Add(new ReportParameter("Bank", "Bank: " + bankName));
                parameters.Add(new ReportParameter("Branch", "Branch: " + branchName));
                parameters.Add(new ReportParameter("AccountNo", "Acc. No: " + ddlAccount.SelectedItem.Text));
                parameters.Add(new ReportParameter("bankStatementBal", bankStatementBalance.ToString()));
                parameters.Add(new ReportParameter("actualBankStBal", bankActualStatementBalance.ToString()));
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.ShowParameterPrompts = false;
                ReportViewer1.ShowPromptAreaButton = false;
                ReportViewer1.LocalReport.Refresh();

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsAccountReconcile";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ReportViewer1.Reset(); // CrystalReportViewer1.ReportSource = null;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }

        }

    }
}
