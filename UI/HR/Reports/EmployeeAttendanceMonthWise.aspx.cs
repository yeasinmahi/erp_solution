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
using GLOBAL_BLL;
using Flogging.Core;
using System.Globalization;

namespace UI.HR.Reports
{
    public partial class EmployeeAttendanceMonthWise : BasePage//System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Reports/EmployeeAttendanceMonthWise.aspx";
        string stop = "stopping HR/Reports/EmployeeAttendanceMonthWise.aspx";
        string empcode;
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
            empcode=objDataTbl[0].strEmployeeCode.ToString().ToUpper();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Reports/EmployeeAttendanceMonthWise.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            

            DateTime PresentDate =  DateTime.Today;
            string pdate = PresentDate.ToString("yyyy-MM-dd");
            DateTime firstDayOfMonth = new DateTime(PresentDate.Year, PresentDate.Month, 1);
            string fdate = firstDayOfMonth.ToString("yyyy-MM-dd");
           

            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Attendance_Report&type=0" + "&empCode=" + empcode + "&fdate=" + fdate + "&tdate=" + pdate + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}