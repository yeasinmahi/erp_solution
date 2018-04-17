using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_BLL.Reports;
using UI.ClassFiles;
using System.Net;

namespace UI.HR.Reports
{
    public partial class EmpSalaryMonthlyStatement : BasePage
    {
        HR_BLL.Reports.EmpSalaryMonthlyStatement objEmpSalaryMonthlyStatement;/*= new HR_BLL.Reports.EmpSalaryMonthlyStatement();*/
        int intUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                 ShowReportDetails(intUserID);
               
            }
        }



        private void ShowReportDetails(int intEmployeeID)
        {
            objEmpSalaryMonthlyStatement = new HR_BLL.Reports.EmpSalaryMonthlyStatement();
            DataTable oDTReportData = new DataTable();
            oDTReportData = objEmpSalaryMonthlyStatement.EmpSalaryMonthly(intEmployeeID);

            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/EmpSalaryMonthlyStatement.rdlc");

            ReportViewer1.Reset(); //important
            if (oDTReportData.Rows.Count > 0)
            {
                ReportViewer1.Reset(); //important
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.EnableHyperlinks = true;

                LocalReport objReport = ReportViewer1.LocalReport;
                objReport.DataSources.Clear();
                objReport.ReportPath = path;

                //Add Datasourdce
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "odsEmpSalaryMonthlyStatement";
                reportDataSource.Value = oDTReportData;
                objReport.DataSources.Add(reportDataSource);
                objReport.Refresh();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }
        }











    }
}