using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global.JobTypeTDSTableAdapters;
using HR_DAL.Global;
using System.Web.UI.WebControls;

namespace HR_BLL.Global
{
    public class JobType
    {
        public JobTypeTDS.TblUserJobTypeDataTable GetAllJobType()
        {
            TblUserJobTypeTableAdapter ta = new TblUserJobTypeTableAdapter();
            return ta.GetAllJobTypeData();
        }

        public JobTypeTDS.SprJobTypeByUnitDataTable GetJobTypeByUnit(int unitId)
        {
            SprJobTypeByUnitTableAdapter ta = new SprJobTypeByUnitTableAdapter();
            return ta.GetAllJobTypeData(unitId);
        }

        public ListItemCollection GetAllJobtypeForDropdown()
        {
            //Summary    :   This function will use to get all leave type
            //Created    :   Md. Yeasir Arafat / Oct-23-2012
            //Modified   :   
            //Parameters :   

            ListItemCollection col = new ListItemCollection();

            SprGetAllJobtypeForDropdownTableAdapter ad = new SprGetAllJobtypeForDropdownTableAdapter();
            JobTypeTDS.SprGetAllJobtypeForDropdownDataTable tbl = ad.GetAllJobtypeForDropdown();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strJobType.ToString(), tbl[i].intJobTypeID.ToString()));

            }

            return col;
        }
    }
}
