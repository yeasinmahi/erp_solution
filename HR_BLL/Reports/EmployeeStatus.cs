using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using System.Data;

namespace HR_BLL.Reports
{
    public class EmployeeStatus
    {
        public DataTable EmpMonthlyStatusMonthly(int intJobStationID, DateTime dteDate)
        {
            SprEmpMonthlyAttandanceReportTableAdapter tbl = new SprEmpMonthlyAttandanceReportTableAdapter();
            return tbl.GetEmpMonthlyAttandanceReportData(intJobStationID, dteDate);
        }
    }
}
