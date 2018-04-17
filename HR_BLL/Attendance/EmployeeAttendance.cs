using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Attendance.EmployeeAttendanceTDSTableAdapters;
using System.Data;
using HR_DAL.Attendance;
using HR_DAL.Attendance.AttandenceManualTDSTableAdapters;
using HR_DAL.Attendance.RealtimePunchTDSTableAdapters;

namespace HR_BLL.Attendance
{
    public class EmployeeAttendance
    {
        SprGetUnProcessAttendenceByDateAndJobstationIDTableAdapter objSprGetUnProcessAttendenceByDateAndJobstationIDTableAdapter = new SprGetUnProcessAttendenceByDateAndJobstationIDTableAdapter();
        SprGetUnprocessDataDetailsByEmployeeIDAndDateTableAdapter objSprGetUnprocessDataDetailsByEmployeeIDAndDateTableAdapter = new SprGetUnprocessDataDetailsByEmployeeIDAndDateTableAdapter();
        public string InsertEmpAttendance(string brcd, int empId, int empJobStationId, DateTime empAttdnctime, int loginUserId, string loginUserIP)
        {
            string rtnString="";
            SprInsertAttendanceTableAdapter adp = new SprInsertAttendanceTableAdapter();
            try
            {
                adp.InsertEmpAttendanceData(brcd, empId, empJobStationId, empAttdnctime, loginUserId, loginUserIP);
                //rtnString = "Employee Add Successfully";
            }
            catch
            {
                rtnString = "Some Problem is Occured.";
            }
            return rtnString;
        }
        
        public string InsertEmployeeOfficeHour(string empCode, TimeSpan startTime, TimeSpan endTime, string reason, int softwareLoginUserID)
        {
            string rtnString = "";
            //SprEmployeeOfficeHourTableAdapter adp = new SprEmployeeOfficeHourTableAdapter();
            //try
            //{
            //    adp.InsertOfficeHourData(empCode, startTime, endTime, reason, softwareLoginUserID, ref rtnString);
            //}
            //catch
            //{
            //    rtnString = "Some Problem is Occured.";
            //}
            return rtnString;
        }
        
        public string InsertOfficeHourChange(string reason, DateTime fromDate, DateTime toDate, TimeSpan startTime, TimeSpan endTime, int stationid, int shiftId, int loginUserID)
        {
            SprEmployeeOfficeHourChangeTableAdapter adp = new SprEmployeeOfficeHourChangeTableAdapter();
            string rtnMessage = "";
            try
            {
                adp.InsertOfficeHourChangeData(reason, fromDate, toDate, startTime, endTime, stationid, shiftId, loginUserID, ref rtnMessage);
            }
            catch (Exception ex) { rtnMessage = ex.ToString(); }
            return rtnMessage;
        }


        public DataTable GetUnProcessAttendenceByDateAndJobstationID(int? intJobStationID, string dteDateToBeSearch)
        {
            //Summary    :   This function will use to GetUnProcessAttendence By Date And JobstationID for grid load
            //Created    :   Md. Yeasir Arafat / FEB-18-2012
            //Modified   :   
            //Parameters :   return LeaveSummary AS DataTable
            try
            {
                return objSprGetUnProcessAttendenceByDateAndJobstationIDTableAdapter.SprGetUnProcessAttendenceByDateAndJobstationID(intJobStationID, DateTime.Parse(dteDateToBeSearch));
            }
            catch
            {
                DataTable oDt = new DataTable();
                return oDt;
            }
        }

        public DataTable GetUnprocessDataDetailsByEmployeeIDAndDate(int? intEmployeeID, string dteDateToBeSearch)
        {
            //Summary    :   This function will use to GetUnProcessAttendence By Date And EmployeeID for unprocessData Details
            //Created    :   Md. Yeasir Arafat / FEB-18-2012
            //Modified   :   
            //Parameters :   return LeaveSummary AS DataTable
            try
            {
                EmployeeAttendanceTDS.SprGetUnprocessDataDetailsByEmployeeIDAndDateDataTable tbl= objSprGetUnprocessDataDetailsByEmployeeIDAndDateTableAdapter.GetData(intEmployeeID, DateTime.Parse(dteDateToBeSearch));
                return tbl;
            }
            catch
            {
                DataTable oDt = new DataTable();
                return oDt;
            }
        }

        //add by himadri for manual attendance

        public string InsertAttendanceManual(int empIDForPresent, DateTime? dteForPresent, string reason, int loginUserID)
        {
            try
            {
                SprAttendenceManualInsertTableAdapter adp = new SprAttendenceManualInsertTableAdapter();
                adp.InsertManualAttendance(empIDForPresent, dteForPresent, reason, loginUserID);
                return "success";

            }
            catch
            {
                return "error";
            }
        }

        //Add by Konock for realtime attendance
        public DataTable GetRealtimeAttendance(int unit, int station, int shift, DateTime showdate, string showtype)
        {
            SprEmployeeRealtimePunchTableAdapter ta = new SprEmployeeRealtimePunchTableAdapter();
            try
            {
                return ta.GetRealtimePunchData(unit, station, shift, showtype, showdate);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetCalenderAttendance(string empcode, int? enroll)
        {
            SprCalenderViewAttendanceByEmployeeTableAdapter ta = new SprCalenderViewAttendanceByEmployeeTableAdapter();
            try
            {
                return ta.GetCalenderViewData(empcode, enroll);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetAttendanceDetails(string empcode, int? enroll, int month, int year)
        {
            SprEmployeeAttendanceDetailsTableAdapter ta = new SprEmployeeAttendanceDetailsTableAdapter();
            try
            {
                return ta.EmployeeAttendanceDetails(empcode, enroll, month, year);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetDailyPunchDetails(int enroll, string _date)
        {
            TblEmployeeAttendanceTableAdapter ta = new TblEmployeeAttendanceTableAdapter();
            try
            {
                return ta.DailyPunchDetails(_date, enroll);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetMonthlyPunchDetails(int enroll, string _date)
        {
            TblEmployeeAttendanceTableAdapter ta = new TblEmployeeAttendanceTableAdapter();
            try
            {
                DateTime __date = DateTime.Parse(_date);
                return ta.MonthlyPunchDetails(__date, enroll);
            }
            catch { return new DataTable(); }
        }
        public DataTable EmployeeInformation(int enroll)
        {
            TblEmployeeAttendanceTableAdapter ta = new TblEmployeeAttendanceTableAdapter();
            try
            {
                return ta.GetEmployeeInformation(enroll);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetMonthList()
        {
            TblMonthTableAdapter ta = new TblMonthTableAdapter();
            try
            {
                return ta.GetMonthListData();
            }
            catch { return new DataTable(); }
        }

        public string InsertACLManualAttendance(DateTime date, int actionby, string code)
        {
            string rtnString = "";
            TblEmployeeTableAdapter adp = new TblEmployeeTableAdapter();
            try
            {
                adp.ACLManualAttendanceData(date.ToString("yyyy-MM-dd"), actionby.ToString(), code);
                rtnString = "Attendance has been given successfully.";
            }
            catch
            {
                rtnString = "Some Problem is Occured.";
            }
            return rtnString;
        }
        





    }
}
