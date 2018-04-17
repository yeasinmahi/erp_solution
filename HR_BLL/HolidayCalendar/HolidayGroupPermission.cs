using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.HolidayCalendar.HolidayGroupPermissionTableAdapters;
using System.Data;

namespace HR_BLL.HolidayCalendar
{
   public class HolidayGroupPermission
    {
       

       public string InsertHolidayGroupPermission(int? intUserID, string strXmlData)
       {
           //Summary    :   This function will use to Insert data into tblEmployeeGroupPermissionHolidays by Checking Existing holiday name
           //Created    :   Md. Yeasir Arafat / May-14-2012
           //Modified   :   
           //Parameters :   return insertStatus

           string insertStatus = "";
           InsertHolidaysGroupPermissionTableAdapter objInsertHolidaysGroupPermissionTableAdapter = new InsertHolidaysGroupPermissionTableAdapter();
           objInsertHolidaysGroupPermissionTableAdapter.GetData(intUserID, strXmlData, ref insertStatus);
           return insertStatus;
       }
       
       public string UpdateHolidayGroupPermission(int? intUserID, int? original_intGroupID, int? original_intJobStationID, int? original_intHolidayID, int? original_intReligionId,DateTime original_dteFromDate, DateTime original_dteToDate,string strHolidayName,int? intHolidayID,string strGroupName,int? intGroupID,string strJobStationName,int intJobStationID,string strReligionName,int intReligionId,DateTime dteFromDate,DateTime dteToDate)
       {
           //Summary    :   This function will use to Update data into tblEmployeeGroupPermissionHolidays by Checking Existing holiday name
           //Created    :   Md. Yeasir Arafat / May-15-2012
           //Modified   :   
           //Parameters :   return updateStatus

           string updateStatus = "";
           UpdateHolidaysGroupPermissionTableAdapter objUpdateHolidaysGroupPermissionTableAdapter = new UpdateHolidaysGroupPermissionTableAdapter();
           objUpdateHolidaysGroupPermissionTableAdapter.GetData(intUserID, original_intGroupID, original_intJobStationID, original_intHolidayID, original_intReligionId, dteFromDate, dteToDate, ref updateStatus);
           return updateStatus;
       }

       public string DeleteHolidayGroupPermission(int? intUserID, int? original_intGroupID, int? original_intJobStationID, int? original_intHolidayID, int? original_intReligionId, DateTime original_dteFromDate, DateTime original_dteToDate)
       {
           //Summary    :   This function will use to delete data into tblEmployeeGroupPermissionHolidays by Checking Existing holiday name
           //Created    :   Md. Yeasir Arafat / May-15-2012
           //Modified   :   
           //Parameters :   return deleteStatus

           string deleteStatus = "";
           DeleteHolidaysGroupPermissionTableAdapter objDeleteHolidaysGroupPermissionTableAdapter = new DeleteHolidaysGroupPermissionTableAdapter();
           objDeleteHolidaysGroupPermissionTableAdapter.GetData(intUserID, original_intGroupID, original_intJobStationID, original_intHolidayID, original_intReligionId, original_dteFromDate, original_dteToDate, ref deleteStatus);
           return deleteStatus;
       }
       public DataTable GetAllHolidayGroupPermission()
       {
           //Summary    :   This function will use to get all holiday Group permission
           //Created    :   Md. Yeasir Arafat / May-14-2012
           //Modified   :   
           //Parameters :   return DataTable

           GetAllHolidayGroupPermissionTableAdapter tbl = new GetAllHolidayGroupPermissionTableAdapter();
           return tbl.GetData();
       }
       public DataTable GetAllHolidayGroupPermissionForUpdateAndDelete(int? intHolidayID, int? intGroupID, int? intJobStationID, int? intReligionId)
       {
           //Summary    :   This function will use to get all holiday Group permission
           //Created    :   Md. Yeasir Arafat / May-14-2012
           //Modified   :   
           //Parameters :   return DataTable

           GetAllHolidayGroupPermissionForUpdateAndDeleteTableAdapter tbl = new GetAllHolidayGroupPermissionForUpdateAndDeleteTableAdapter();
           return tbl.GetData(intHolidayID, intGroupID, intJobStationID, intReligionId);
       }
    }
}
