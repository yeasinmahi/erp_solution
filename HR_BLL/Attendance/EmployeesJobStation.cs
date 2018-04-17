using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HR_DAL.Attendance.EmployeeJobStation_TDSTableAdapters;
using HR_DAL.Attendance;

namespace HR_BLL.Attendance
{
    public class EmployeesJobStation
    {
        #region Object Declare
        TblEmployeeJobStationTableAdapter objTblEmployeeJobStationTableAdapter = new TblEmployeeJobStationTableAdapter();
        #endregion

        #region Method
        public ListItemCollection GetEmployeeJobStation()
                {
                    //Summary    :   This function will use to Load Get Job station for jobStationDropdown load
                    //Created    :   Md. Yeasir Arafat / FEB-16-2012
                    //Modified   :   
                    //Parameters :

                    ListItemCollection col = new ListItemCollection();
                    EmployeeJobStation_TDS.TblEmployeeJobStationDataTable tbl = objTblEmployeeJobStationTableAdapter.GetEmployeeJobStation();

                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                       col.Add(new ListItem(tbl[i].strJobStationName.ToString(), tbl[i].intEmployeeJobStationId.ToString()));
                    }


                    return col;
                }

        public string InsertShiftStatus(int unitId, int jobStationID, int shiftID, DateTime frmDate, DateTime toDate, int onOff, int userID)
        {
            SprRosterAlgorithmTableAdapter adp = new SprRosterAlgorithmTableAdapter();
            string msgStatus = "";
            try
            {
                adp.ShiftStatusChangeData(unitId, jobStationID, shiftID, onOff, frmDate, toDate,  userID);
                msgStatus = "Successfully shift status has been changed";
            }
            catch
            {
                msgStatus = "Error occurs";
            }
            return msgStatus;
        }

        #endregion
    }
}
