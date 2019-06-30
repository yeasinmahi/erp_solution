using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.HolidayCalendar.HolidayCalendarTableAdapters;
using System.Data;

namespace HR_BLL.HolidayCalendar
{
   public class HolidaySetup
    {
       public string InsertHoliday(int? intUserID, string strHolidayName,string  strDescription)
       {
           //Summary    :   This function will use to Insert data into tblEmployeeHoliday by Checking Existing holiday name
           //Created    :   Md. Yeasir Arafat / May-10-2012
           //Modified   :   
           //Parameters :   return insertStatus

           string insertStatus = "";
           InsertHolidayTableAdapter objInsertHolidayTableAdapter = new InsertHolidayTableAdapter();
           objInsertHolidayTableAdapter.GetData(intUserID, strHolidayName, strDescription, ref insertStatus);
           return insertStatus;
       }
       public string UpdateHoliday(int? intUserID, int? intHolidayID, string strHolidayName, string strDescription)
       {
           //Summary    :   This function will use to update data into tblEmployeeHoliday by Checking Existing holiday name
           //Created    :   Md. Yeasir Arafat / May-10-2012
           //Modified   :   
           //Parameters :   return updateStatus

           string updateStatus = "";
           UpdateHolidayTableAdapter objUpdateHolidayTableAdapter = new UpdateHolidayTableAdapter();
           objUpdateHolidayTableAdapter.GetData(intUserID, intHolidayID, strHolidayName, strDescription, ref updateStatus);
           return updateStatus;
       }
       public string DeleteHoliday(int? intUserID, int? intHolidayID)
       {
           //Summary    :   This function will use to delete data from tblEmployeeHoliday 
           //Created    :   Md. Yeasir Arafat / May-10-2012
           //Modified   :   
           //Parameters :   return deleteStatus

           string deleteStatus = "";
           DeleteHolidayTableAdapter objDeleteHolidayTableAdapter = new DeleteHolidayTableAdapter();
           objDeleteHolidayTableAdapter.GetData(intUserID, intHolidayID, ref deleteStatus);
           return deleteStatus;
       }
       public DataTable  GetAllHoliday()
       {
           //Summary    :   This function will use to all data from tblEmployeeHoliday 
           //Created    :   Md. Yeasir Arafat / May-10-2012
           //Modified   :   
           //Parameters :   return dataTable

           GetAllHolidayTableAdapter objGetAllHolidayTableAdapter = new GetAllHolidayTableAdapter();
           return objGetAllHolidayTableAdapter.GetData();
       }
           
       public string InsertHolidayInformation(string xmlString, int holidayid, int userID)
       {
           SprEmployeeHolidayInsertionTableAdapter adp = new SprEmployeeHolidayInsertionTableAdapter();
           string msgStatus = "";
           try { adp.HolidayInsertionData(xmlString, holidayid, userID, ref msgStatus); }
           catch (Exception ex) { msgStatus = ex.ToString(); }
           return msgStatus;
       }

        public DataTable getHolyDayAllJobs(int unitid)
        {
            try
            {
                SprAllJobstationHolyDayTableAdapter ta = new SprAllJobstationHolyDayTableAdapter();
                return ta.GetDataAllJobstationHolyDay(unitid);
            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }


        public string InsertAllJobInfo(string xmlstring, int holydayid, int actionby, DateTime from, DateTime to)
        {
            //string msg = "";

            //try
            //{
            //    SprAllJobstationEmployeeHolidayInsertionTableAdapter ta = new SprAllJobstationEmployeeHolidayInsertionTableAdapter();
            //    return ta.GetDataAllJobstationEmployeeHolidayInsertion(xmlstring,  holydayid,  actionby,  from,  to,ref msg );
            //}
            //catch (Exception ex)
            //{
            //    return new DataTable();
            //}

            SprAllJobstationEmployeeHolidayInsertionTableAdapter adp = new SprAllJobstationEmployeeHolidayInsertionTableAdapter();
            string msgStatus = "";
            try { adp.GetDataAllJobstationEmployeeHolidayInsertion(xmlstring, holydayid, actionby, from, to, ref msgStatus); }
            catch (Exception ex) { msgStatus = ex.ToString(); }
            return msgStatus;


        }




    }
}
