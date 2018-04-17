using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HR_DAL.Facilities.MobileTypeTDSTableAdapters;
using HR_DAL.Facilities;
using System.Data;
using System.Text.RegularExpressions;

namespace HR_BLL.Facilities
{
    public class MobileFacilities
    {
        public ListItemCollection GetMobileType()
        {
            ListItemCollection col = new ListItemCollection();
            TblFacilitiesMobileTypeTableAdapter adp = new TblFacilitiesMobileTypeTableAdapter();
            MobileTypeTDS.TblFacilitiesMobileTypeDataTable tbl = adp.GetData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                ListItem li = new ListItem(tbl[i].strTypeName,tbl[i].intTypeID.ToString());
                col.Add(li);

            }
            return col;
        }
        public DataTable GetEmployeeDeduction(DateTime frmdate, DateTime todate, string EmployeeCode, int loginid)
        {
            try
            {
                if (EmployeeCode == null) { EmployeeCode = ","; }
                string[] searchKey = Regex.Split(EmployeeCode, ",");
                SprReportEmployeeDeductionTableAdapter adp = new SprReportEmployeeDeductionTableAdapter();
                return adp.GetEmployeeDeductionData(frmdate, todate, searchKey[1], loginid);
            }
            catch { return new DataTable(); }
        }
    }
}
