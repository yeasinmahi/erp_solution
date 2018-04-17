using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Leave;
using HR_DAL.Leave.LeaveApplicationProcessTDSTableAdapters;
using HR_DAL.Leave.LeaveApplicationApprovedTDSTableAdapters;
using System.Data;
using System.Web.UI.WebControls;

namespace HR_BLL.Leave
{
    public class LeaveApplicationProcess
    {
        #region /* Application for Leave */

        public LeaveApplicationProcessTDS.SprLeave_GetLeaveTypeByEmployeeDataTable GetLeaveType(string strEmployeeCode)
        {  
            //Parameters : strEmployeeCode
            SprLeave_GetLeaveTypeByEmployeeTableAdapter ad = new SprLeave_GetLeaveTypeByEmployeeTableAdapter();
            return ad.GetLeaveTypeData(strEmployeeCode);
        }

        public LeaveApplicationProcessTDS.SprLeave_GetLeaveSummaryByEmployeeDataTable GetLeaveSummary(string employeecode, int? employeeid)
        {
            //Parameters :  EmployeeCode and Return LeaveSummary AS DataTable
            SprLeave_GetLeaveSummaryByEmployeeTableAdapter ta = new SprLeave_GetLeaveSummaryByEmployeeTableAdapter();
            return ta.GetLeaveSummaryData(employeecode, employeeid);
        }

        public string SubmitLeaveApplication(string employeecode, int leavetype, DateTime appdate, DateTime fromdate, DateTime todate, string reason, string address, string phone, int actionBy)
        {
            string rtnMessage = "";
            try
            {
                SprLeave_ApplicationSubmitTableAdapter ta = new SprLeave_ApplicationSubmitTableAdapter();
                //ta.SubmitLeaveApplicationData(employeecode, leavetype, appdate, fromdate, todate, reason, address, phone, actionBy, ref rtnMessage);
            }
            catch { rtnMessage = "0"; }
            return rtnMessage;
        }
        public string SubmitLeaveApplication(string empcode, int ltp, TimeSpan tmstart, TimeSpan tmend, DateTime fromdate, DateTime todate, string reason, string address, string phone, int actionBy)
        {
            string rtnMessage = "0";
            try
            {
                SprLeave_ApplicationSubmitTableAdapter ta = new SprLeave_ApplicationSubmitTableAdapter();
                ta.SubmitLeaveApplicationData(empcode, ltp, fromdate, todate, tmstart, tmend, reason, address, phone, actionBy, ref rtnMessage);
            }
            catch { return rtnMessage; }
            return rtnMessage; 
        }
        public string UpdateLeaveApplication(string employeecode, int appid, int leavetype, DateTime appdate, DateTime fromdate, DateTime todate, string reason, string address, int actionBy)
        {
            string rtnMessage = "";
            try
            {
                SprLeave_ApplicationUpdateTableAdapter ta = new SprLeave_ApplicationUpdateTableAdapter();
                ta.UpdateLeaveApplicationData(employeecode, appid, leavetype, appdate, fromdate, todate, reason, address, actionBy, ref rtnMessage);
            }
            catch { rtnMessage = "0"; }
            return rtnMessage;
        }

        public string DeleteLeaveApplication(string employeecode, int appid, int actionBy)
        {
            string rtnMessage = "";
            try
            {
                SprLeave_ApplicationDeleteTableAdapter ta = new SprLeave_ApplicationDeleteTableAdapter();
                ta.DeleteLeaveApplicationData(employeecode, appid, actionBy, ref rtnMessage);
            }
            catch (Exception ex) { rtnMessage = "0"; }
            return rtnMessage;
        }

        public LeaveApplicationProcessTDS.SprLeave_ApplicationSummaryByEmployeeDataTable GetApplicationSummary(string strEmployeeCode, int? employeeid)
        {
            //Parameters : strEmployeeCode, employeeid
            SprLeave_ApplicationSummaryByEmployeeTableAdapter ad = new SprLeave_ApplicationSummaryByEmployeeTableAdapter();
            return ad.GetLeaveApplicationSummaryData(strEmployeeCode, employeeid);
        }


        #endregion

        #region/* Employee Leave Application Approved */

        public LeaveApplicationProcessTDS.SprLeave_GetAllUnApprovedLeaveApplicationByHrAdminDataTable GetUnapprovedLeaveApplication(int appstatus, int userid)
        {
            SprLeave_GetAllUnApprovedLeaveApplicationByHrAdminTableAdapter ta = new SprLeave_GetAllUnApprovedLeaveApplicationByHrAdminTableAdapter();
            return ta.GetUnapprovedLeaveApplicationData(appstatus, userid);
        }

        public LeaveApplicationProcessTDS.SprLeave_GetLeaveSummaryByUserIDOrEmpCodeDataTable GetEmployeeLeaveSummary(string empCode)
        {
            SprLeave_GetLeaveSummaryByUserIDOrEmpCodeTableAdapter ta = new SprLeave_GetLeaveSummaryByUserIDOrEmpCodeTableAdapter();
            return ta.GetLeaveSummaryByEmpCodeData(null, empCode);
        }

        public string LeaveApplicationApproved(string empCode, string lvTpyeID, string lvAppID, string takendays, int approvedBy, DateTime approvedDate, DateTime fromdate, DateTime todate, string approvedStatus, int payStatus)
        {
            string rtnMessage = "";
            SprLeaveApplicationApprovedTableAdapter ta = new SprLeaveApplicationApprovedTableAdapter();
            ta.LeaveApplicationApprovedData(empCode, lvTpyeID, decimal.Parse(takendays), lvAppID, approvedDate, fromdate, todate, payStatus, approvedStatus, approvedBy, ref rtnMessage);
            return rtnMessage;
        }

        public string LeaveApplicationProcessed(int applicationId, DateTime fromdate, DateTime todate, int payStatus, string applicationStatus, int actionBy)
        {            
            string rtnMessage = "";
            try
            {
                SprLeave_ApplicationApprovedTableAdapter ta = new SprLeave_ApplicationApprovedTableAdapter();
                ta.LeaveApplicationProcessData(applicationId, fromdate, todate, payStatus, applicationStatus, actionBy, ref rtnMessage);             
            }
            catch { rtnMessage = "0"; }
            return rtnMessage;
        }

        #endregion

        
    }
}
