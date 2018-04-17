using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.EmployeeGroupTDSTableAdapters;

namespace HR_BLL.Global
{
    public class EmployeeGroup
    {
        public EmployeeGroupTDS.TblEmployeeGroupDataTable GetAllEmployeeGroup()
        {
            TblEmployeeGroupTableAdapter ta = new TblEmployeeGroupTableAdapter();
            return ta.GetEmployeeGroupData();
        }
    }
}
