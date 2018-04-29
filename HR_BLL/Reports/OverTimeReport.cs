using HR_DAL.Employee.EmpRegistrationTDSTableAdapters;
using HR_DAL.Reports.OverTimeTableAdapters;
using System;
using System.Data;

namespace HR_BLL.Reports
{
    public class OverTimeReport
    {
        public DataTable EmployeeByEndroll(int enroll)
        {
            SprEmployeeSearchByEnrolTableAdapter ta = new SprEmployeeSearchByEnrolTableAdapter();
            return ta.tasprEmployeeSearchByEnrol(enroll);
        }

        public DataTable EmployeeOverTimeByEndroll(int enroll, DateTime date)
        {
            sprEmpOTEntryReportTableAdapter ta = new sprEmpOTEntryReportTableAdapter();
            return ta.GetData(enroll, date, null, null, null, null, null, null, "PersonalReport", null);
        }

    }
}
