using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using System.Data;

namespace HR_BLL.Reports
{
    public class EmpSalaryStatement
    {
        public DataTable EmpSalary(int intJobStationID, DateTime dteDate)
        {
            SprEmpSalaryStatementTableAdapter tbl = new SprEmpSalaryStatementTableAdapter();
            return tbl.GetEmpSalaryStatementData(intJobStationID, dteDate);
        }
    }
}
