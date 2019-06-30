using HR_DAL.Leave.LeaveTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Leave
{
    public class PLLeave
    {
        /*
         * Author   : Muktadir
         * Date     : 27-June-2019
         * For      : PL Leave
         */
        public DataTable GetPLLeaveEnableEmployee(int JSId)
        {
            DataTable dt = new DataTable();
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                dt = adapter.GetPLLeaveEnableEmployeeData(JSId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }
        public DateTime GetPlToDate(DateTime JoiningDate, DateTime PLFromDate)
        {
            DateTime PLToDate = DateTime.MinValue;
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                object _obj = adapter.GetPLToDate(JoiningDate, PLFromDate);
                if (_obj != null)
                    PLToDate = Convert.ToDateTime(_obj);
            }
            catch (Exception ex)
            {

            }

            return PLToDate;
        }
        public string PLLeaveApplicationSubmit(int EmployeeId, string EmployeeCode, int LeaveTypeId, DateTime AppliedFrom, DateTime AppliedTo, TimeSpan StartTime, TimeSpan Endtime,
            string LeaveReason, string AddressDuoToLeave, string PhoneDuoToLeave,int AppliedBy)
        {
            string strMessage = string.Empty;
            int decission = 0;
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                adapter.PLLeaveApplicationSubmit(EmployeeCode, LeaveTypeId, AppliedFrom, AppliedTo, StartTime, Endtime, LeaveReason, AddressDuoToLeave, PhoneDuoToLeave, AppliedBy, ref strMessage);
                if(strMessage.Equals("Sorry! This application is back-dated! "))
                {
                    decission = adapter.InsertPLLeaveApplication(LeaveTypeId, EmployeeId, AppliedFrom, AppliedTo, AppliedBy);
                    if (decission > 0)
                    {
                        strMessage = "Application has been submitted successfully.";
                    }
                    else
                    {
                        strMessage = "Sorry to submit this application.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return strMessage;
        }
        public bool ChangePLLeaveDate(DateTime ApprovedFrom,string EmpCode)
        {
            int iii = 0;
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                object _obj = adapter.PlLeaveDateChange(null, null, ApprovedFrom, EmpCode, 1);
                if (_obj != null)
                    iii = Convert.ToInt32(_obj);

                if (iii > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable GetPLLeaveDataForDateChange(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                dt = adapter.GetPLLeaveDataForDateChange(Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return dt;
        }

        public bool PLLeaveDateUpdate(DateTime oldPLFromDate, DateTime oldPLToDate, DateTime newPLFromDate, DateTime newPLToDate,int PLEmpEnroll, int PlAppID, int actionBy, int LeaveTypeId,
            int oldPLDays, int newPLDays, int workId)
        {
            bool result = false;
            try
            {
                PLEnableEmployeeTableAdapter adapter = new PLEnableEmployeeTableAdapter();
                adapter.PLLeaveDateUpdate(oldPLFromDate, oldPLToDate, newPLFromDate, newPLToDate, PLEmpEnroll, PlAppID, actionBy, LeaveTypeId, oldPLDays, newPLDays, workId);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
