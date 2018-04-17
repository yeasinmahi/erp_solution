using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Attendance.EmployeeOvertimeTDSTableAdapters;
using HR_DAL.Attendance.EmployeeSwapingTDSTableAdapters;

namespace HR_BLL.Attendance
{
    public class EmployeeOvertime
    {
        public string InsertEmpOvertime(string empCode, int assignShiftId, DateTime assignDate, int softwareLoginUserID)
        {
            SprEmployeeOvertimeTableAdapter adp = new SprEmployeeOvertimeTableAdapter();
            string msgStatus = "";
            try
            {
                adp.InsertEmployeeOvertimeData(empCode, assignShiftId, assignDate,softwareLoginUserID, ref msgStatus);
            }
            catch
            {
            }
            return msgStatus;
        }

        public string InsertSwapEmployee(string empOffCode, DateTime dayOffForOffEmp, string empDutyCode, DateTime dayOffForDutyEmp, string reason, int softwareLoginUserID)
        {
            SprEmployeeSwapingTableAdapter adp = new SprEmployeeSwapingTableAdapter();
            string msgStatus = "";
            try
            {
                adp.InsertEmployeeSwapData(empOffCode, dayOffForOffEmp, empDutyCode, dayOffForDutyEmp,reason,softwareLoginUserID, ref msgStatus);
            }
            catch
            {                
            }
            return msgStatus;
        }

        public string InsertEmployeeShift(string strEmpCode, int intDepId, int intshiftId, DateTime frmDate, DateTime toDate, int softwareLoginUserID)
        {
            SprEmployeeShiftAssignTableAdapter adp = new SprEmployeeShiftAssignTableAdapter();
            string msgStatus = "";
            try
            {
               adp.InsertShiftAssignData(strEmpCode,intDepId,intshiftId,frmDate,toDate, softwareLoginUserID, ref msgStatus);
            }
            catch
            {
                msgStatus = "Error Occurs";
            }
            return msgStatus;
        }
    }
}
