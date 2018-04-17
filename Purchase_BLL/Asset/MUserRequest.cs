using Purchase_DAL.Asset.MRequestbyUserTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Purchase_BLL.Asset
{
    public class MUserRequest
    {
        public DataTable DepartmentbyJobstation(int intjobid)
        {
            DeptNameDataTableTableAdapter deptname = new DeptNameDataTableTableAdapter();
            return deptname.DepartmentNameGetData(intjobid);
        }

        public DataTable DepartmentbyCorporate()
        {
            DeptNameDataTableTableAdapter corporateDept = new DeptNameDataTableTableAdapter();
            return corporateDept.CorporateDeptGetDataBy();
        }

        public void MaintenanceRequest(string name, int dept, string priority, string Location, string problem, int intenroll, int intjobid)
        {
            TblMSupportReqestTableAdapter Mreqiest = new TblMSupportReqestTableAdapter();
            Mreqiest.InsertMRequestGetData(name, dept, priority, Location, problem, intenroll, intjobid);
        }
    }
}
