using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Reports;
using System.Data;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class MonthwiseSalaryInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToShortDateString();
                pnlUpperControl.DataBind();
            }
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Show Salary report
            //Created    :   Md. Yeasir Arafat / Mar-18-2012
            //Modified   :   
            //Parameters :


            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/MonthwiseSalaryInfo.rdlc");
            BankSalaryReportInfo objBankSalaryReportInfo = new BankSalaryReportInfo();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objBankSalaryReportInfo.GetSalaryReportData(DateTime.Parse(txtDate.Text), int.Parse(ddlUnit.SelectedValue.ToString()), int.Parse(ddlJobStation.SelectedValue.ToString()));
            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.ReportPath = path;
                ReportDataSource reportDataSource = new ReportDataSource();

                reportDataSource.Name = "odsMonthwiseSalaryInfo";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }
    }
}