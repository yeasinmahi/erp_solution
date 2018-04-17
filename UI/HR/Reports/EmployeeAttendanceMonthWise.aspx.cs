using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Reports;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_DAL.Reports;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeAttendanceMonthWise : BasePage//System.Web.UI.Page
    {
        ReportDataTDS.SprEmployeeMonthWiseAttendanceDataTable objDataTbl = null;
        EmployeeAttendanceReports objMonthwiseAttendanceReport = new EmployeeAttendanceReports();
        DataTable oDTReportData = new DataTable();
        int? intLoginUerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            objDataTbl = objMonthwiseAttendanceReport.GetEmployeeMonthWiseAttendance(intLoginUerId);
            txtEmployee.Text = objDataTbl[0].strEmployeeName.ToString().ToUpper();
            txtJobStation.Text = objDataTbl[0].strJobStationName.ToString().ToUpper();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Server.MapPath("~/HR/Reports/ReportsTemplate/DatewiseAttendanceInfo.rdlc");
            oDTReportData = objMonthwiseAttendanceReport.GetEmployeeMonthWiseAttendance(intLoginUerId);
            if (oDTReportData.Rows.Count > 0)
            {
                MonthWiseAttendanceReportViewer.Reset(); //important
                MonthWiseAttendanceReportViewer.ProcessingMode = ProcessingMode.Local;
                LocalReport objReport = MonthWiseAttendanceReportViewer.LocalReport;
                objReport.ReportPath = path;
                string dateVal = DateTime.Now.Date.ToString("dd-MMMM-yyyy");
                // Add Parameter 
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("UnitName", objDataTbl[0].strJobStationName.ToString().ToUpper()));
                parameters.Add(new ReportParameter("UnitAddress", objDataTbl[0].strStationAddress.ToString().ToUpper()));
                parameters.Add(new ReportParameter("Title", "Single Employee Attendance Summary"));
                parameters.Add(new ReportParameter("Date", dateVal));

                MonthWiseAttendanceReportViewer.LocalReport.SetParameters(parameters);
                MonthWiseAttendanceReportViewer.ShowParameterPrompts = false;
                MonthWiseAttendanceReportViewer.ShowPromptAreaButton = false;
                MonthWiseAttendanceReportViewer.LocalReport.Refresh();

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "dsDailyEmployyAttendance";
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