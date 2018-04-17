using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HR_DAL.Leave.LeaveTypeTDSTableAdapters;
using HR_DAL.Leave;

namespace HR_BLL.Leave
{
    public class LeaveType
    {
        public ListItemCollection GetLeaveType()
        {
            //Summary    :   This function will use to get all leave type
            //Created    :   Md. Yeasir Arafat / Apr-7-2012
            //Modified   :   
            //Parameters :   

            ListItemCollection col = new ListItemCollection();

            TblLeaveTypeSetupTableAdapter ad = new TblLeaveTypeSetupTableAdapter();
            LeaveTypeTDS.TblLeaveTypeSetupDataTable tbl = ad.GetLeaveTypeData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
            
                col.Add(new ListItem(tbl[i].strLeaveType, tbl[i].intLeaveTypeID + "#" + tbl[i].intMaximumAllowedAt_A_Time.ToString()));

            }


            return col;
        }


        public ListItemCollection GetLeaveType(int? intUserID, string strEmployeeCode)
        {
            //Summary    :   This function will use to get leave type by userId or empcode
            //Created    :   Md. Yeasir Arafat / Apr-7-2012
            //Modified   :   
            //Parameters :   intUserId,strEmployeeCode

            ListItemCollection col = new ListItemCollection();

            GetLeaveTypeByUserIdOrEmployeeCodeDueToGroupPermissionLeaveTableAdapter ad = new GetLeaveTypeByUserIdOrEmployeeCodeDueToGroupPermissionLeaveTableAdapter();
            LeaveTypeTDS.GetLeaveTypeByUserIdOrEmployeeCodeDueToGroupPermissionLeaveDataTable tbl = ad.GetData(intUserID, strEmployeeCode);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strLeaveType, tbl[i].intLeaveTypeID + "#" + tbl[i].intMaximumAllowedAt_A_Time.ToString() + "#" + tbl[i].ysnBalanceCheck.ToString()));

            }


            return col;
        }
    }
}
