using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Attendance.UnprocessAttedanceTDSTableAdapters;

namespace HR_BLL.Attendance
{
   public class UnprocessAttendance
    {
       public string InsertManualAttendenceForUnprocessData(int? intEmployeeID,int? intJobStationID,DateTime? dteAttendanceDate,TimeSpan? dteAttendanceTime,int? intUserID,string strUserIP,string strReason)
       {
           //Summary    :   This function will use to Insert data into manual attendance table
            //Created    :   Md. Yeasir Arafat / Apr-04-2012
            //Modified   :   
           //Parameters :   return strInsertStatus
            try
            {
                SprAttendence_InsertManualAttendenceForUnprocessAttendenceDataTableAdapter tbl = new SprAttendence_InsertManualAttendenceForUnprocessAttendenceDataTableAdapter();
                string strInsertStatus = "";
                tbl.InsertManualAttendenceData(intEmployeeID, intJobStationID, dteAttendanceDate, dteAttendanceTime, intUserID, strUserIP, strReason, ref strInsertStatus);
                return strInsertStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
           
       }
      
       public string Process_UnprocessAttendanceData(int? intEmployeeID,DateTime? dteAttendanceDate)
       {
           //Summary    :   This function will use to process unprocessed attendance data
           //Created    :   Md. Yeasir Arafat / Apr-04-2012
           //Modified   :   
           //Parameters :   return strInsertStatus
           try
           {
               SprAttendence_Process_UnprocessAttendenceDataTableAdapter tbl = new SprAttendence_Process_UnprocessAttendenceDataTableAdapter();
               string strProcessStatus = "";
               tbl.UpdateData(intEmployeeID, dteAttendanceDate,ref strProcessStatus);
               return strProcessStatus;
           }
           catch (Exception ex)
           { return ex.Message.ToString(); }

       }

    }
}
