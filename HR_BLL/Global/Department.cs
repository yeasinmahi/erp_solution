using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.DepartmentTDSTableAdapters;

namespace HR_BLL.Global
{
    public class Department
    {
        public DepartmentTDS.TblDepartmentDataTable GetAllDepartment()
        {
            TblDepartmentTableAdapter ta = new TblDepartmentTableAdapter();
            return ta.GetAllDepartmentData();
        }
    }
}
