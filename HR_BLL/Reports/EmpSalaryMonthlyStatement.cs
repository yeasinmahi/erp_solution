using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using System.Data;

namespace HR_BLL.Reports
{
    public class EmpSalaryMonthlyStatement
    {
        public DataTable EmpSalaryMonthly(int intEmployeeID)
        {
            SprEmpSalaryMonthlyStatementTableAdapter tbl = new SprEmpSalaryMonthlyStatementTableAdapter();
            return tbl.GetData(intEmployeeID);
        }

        public DataTable EmpSalaryMonthly()
        {
            throw new NotImplementedException();
        }
    }
}
