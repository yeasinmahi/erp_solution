using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Reports.ReportDataTDSTableAdapters;

namespace HR_BLL.Reports
{
    public class EmployeeShiftReport
    {
        public DataTable JobStationwiseCurrentShiftReport(int? intJobStationID,DateTime? dteRosterDutyDate)
        {
            Report_EmpoyeesCurrentShiftReportTableAdapter tbl = new Report_EmpoyeesCurrentShiftReportTableAdapter();
            return tbl.GetData(intJobStationID,dteRosterDutyDate);
        }
    }
}
