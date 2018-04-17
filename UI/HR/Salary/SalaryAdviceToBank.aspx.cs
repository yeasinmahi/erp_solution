using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Microsoft.Reporting.WebForms;
using System.Data;
using HR_BLL.Salary;
using UI.ClassFiles;


namespace UI.HR.Salary
{
    public partial class SalaryAdviceToBank : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string intUnitID = Request.QueryString["intUnitID"];
                ShowReportDetails(intUnitID);
            }
        }

        private void ShowReportDetails(string intUnitID)
        {
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/SalaryAdviceToBank.rdlc");

                SalaryInfo objSalaryInfo = new SalaryInfo();
                DataTable oDTReportData = new DataTable();
                oDTReportData = objSalaryInfo.GetUnitwiseSalaryDetailsByUnitID(int.Parse(intUnitID));

                if (oDTReportData.Rows.Count > 0)
                {
                    ReportViewer1.Reset(); //important
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.EnableHyperlinks = true;

                    LocalReport objReport = ReportViewer1.LocalReport;
                    objReport.DataSources.Clear();
                    objReport.ReportPath = path;

                    DateTime salaryDate = DateTime.Parse(oDTReportData.Rows[0]["PayrollGenerationDate"].ToString());
                    string monthName = new DateTime(salaryDate.Year, salaryDate.Month, salaryDate.Day).ToString("MMMMM", CultureInfo.InvariantCulture);
                    string monthYear = monthName + ", " + salaryDate.Year.ToString() + "  ";
                    // Add Parameter 
                    List<ReportParameter> parameters = new List<ReportParameter>();
                    parameters.Add(new ReportParameter("MonthYear", monthYear));
                    ReportViewer1.LocalReport.SetParameters(parameters);
                    ReportViewer1.ShowParameterPrompts = false;
                    ReportViewer1.ShowPromptAreaButton = false;
                    ReportViewer1.LocalReport.Refresh();

                    //Add Datasourdce
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "odsReportData";
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

            }

        }
    }
}