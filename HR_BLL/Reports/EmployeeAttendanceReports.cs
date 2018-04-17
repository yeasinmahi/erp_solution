using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using HR_DAL.Reports.AttendanceReport_TDSTableAdapters;
using HR_DAL.Reports;

namespace HR_BLL.Reports
{
    public class EmployeeAttendanceReports
    {

        
        public ReportDataTDS.SprEmployeeDateWiseAttendanceDataTable GetEmployeeDateWiseAttendance(string empCode, string detFrmDate, string detToDate, int rdoStatus)
        {
            //Summary    :   This function will use to get Employee Date Wise Attendance Information
            //Created    :   Konock / April-02-2012
            //Modified   :   Konock / April-26-2012
            //Parameters :   employeeCode, FromDate, ToDate, RadioStatus

            SprEmployeeDateWiseAttendanceTableAdapter datewiseAttendanceTableAdapter = new SprEmployeeDateWiseAttendanceTableAdapter();
            return datewiseAttendanceTableAdapter.GetEmployeeDateWiseAttendanceData(empCode, detFrmDate, detToDate, rdoStatus);
        }

        public ReportDataTDS.SprEmployeeMonthWiseAttendanceDataTable GetEmployeeMonthWiseAttendance(int? loginId)
        {
            //Summary    :   This function will use to get Employee Date Wise Attendance Information
            //Created    :   Konock / May-06-2012
            //Modified   :   
            //Parameters :   Software Login Id

            SprEmployeeMonthWiseAttendanceTableAdapter monthwiseAttendanceTableAdapter = new SprEmployeeMonthWiseAttendanceTableAdapter();
            return monthwiseAttendanceTableAdapter.GetEmployeeMonthWiseAttendanceData(loginId);
        }

        public DataTable AttenanceDailySummaryReportCalanderView(int? intEmployeeId, int? MonthNum, int? Year)
        {
            //Summary    :   This function will use to generate employee's attendance summary Report calenderviw
            //Created    :   Yeasir / Apr-10-2012
            //Modified   :   
            //Parameters :   intEmployeeId, Month number,year

            AttenanceDailySummaryReportCalanderViewTableAdapter tbl = new AttenanceDailySummaryReportCalanderViewTableAdapter();
            return tbl.GetData(intEmployeeId, MonthNum, Year);
        }

        public DataTable DailyAttendanceSummaryTimeview(string strEmployeeCode, DateTime dteFrmDate, DateTime dteToDate)
        {
            //Summary    :   This function will use to generate employee's attendance summary Report Timeview
            //Created    :   Yeasir / June-28-2012
            //Modified   :   
            //Parameters :   strEmployeeCode, dteFrmDate,dteToDate

            SprReport_DailyAttendanceSummaryTimeviewTableAdapter tbl = new SprReport_DailyAttendanceSummaryTimeviewTableAdapter();
            return tbl.GetData(strEmployeeCode, dteFrmDate, dteToDate);
        }
        public DataTable DailyAttendanceSummaryTimeviewSubreport(string strEmployeeCode, DateTime dteAttendanceDate)
        {
            //Summary    :   This function will use to generate employee's attendance summary Report TimeviewSubreport
            //Created    :   Yeasir / June-28-2012
            //Modified   :   
            //Parameters :   strEmployeeCode, dteAttendanceDate

            SprReport_DailyAttendanceSummaryTimeviewSubreportTableAdapter tbl = new SprReport_DailyAttendanceSummaryTimeviewSubreportTableAdapter();
            return tbl.GetData(strEmployeeCode, dteAttendanceDate);
        }
    }
}
