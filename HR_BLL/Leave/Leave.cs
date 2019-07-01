using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HR_DAL.Leave.LeaveTableAdapters;

namespace HR_BLL.Leave
{
    public class Leave
    {
        #region Variable Decaration
        SprGetLeaveSummaryByUserIDOrEmpCodeTableAdapter objSprGetLeaveSummaryByUserIDOrEmpCodeTableAdapter = new SprGetLeaveSummaryByUserIDOrEmpCodeTableAdapter();
        SprInsertLeaveApplicationTableAdapter objSprInsertLeaveApplicationTableAdapter = new SprInsertLeaveApplicationTableAdapter();
        SprGetAllUnApprovedLeaveApplicationByUserIDOrEmpCodeTableAdapter objSprGetAllUnApprovedLeaveApplicationByUserIDOrEmpCodeTableAdapter = new SprGetAllUnApprovedLeaveApplicationByUserIDOrEmpCodeTableAdapter();
        SprUdateLeaveApplicationTableAdapter objSprUdateLeaveApplicationTableAdapter = new SprUdateLeaveApplicationTableAdapter();
        SprDeleteLeaveApplicationTableAdapter objSprDeleteLeaveApplicationTableAdapter = new SprDeleteLeaveApplicationTableAdapter();

        #endregion

        #region Method
        public DataTable GetLeaveSummaryByEmployeeCodeOrUserID(int? userID,string empCode)
        {
            //Summary    :   This function will use to GetLeaveSummaryByEmployeeIDn by EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-7-2012
            //Modified   :   
            //Parameters :   return LeaveSummary AS DataTable

            return objSprGetLeaveSummaryByUserIDOrEmpCodeTableAdapter.SprGetLeaveSummaryByUserIDOrEmpCode(userID, empCode);
        }

        public string SprInsertLeaveApplication(int leaveTypeID, int? userID, string empCode, DateTime applicationDate, DateTime fromDate, DateTime toDate, string leaveReason, string addressDueToLeave, string phoneDueToLeave)
        {
            //Summary    :   This function will use to Insert data into Leave Application by Checking Leave Application Exsistency between FromDate AND ToDate 
            //Created    :   Md. Yeasir Arafat / FEB-7-2012
            //Modified   :   
            //Parameters :   return insertStatus
            try
            {
                string insertStatus = "";
                objSprInsertLeaveApplicationTableAdapter.SprInsertLeaveApplication(userID, empCode, leaveTypeID, applicationDate, fromDate, toDate, leaveReason, addressDueToLeave, phoneDueToLeave, ref insertStatus);
                return insertStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }

        public string SprUdateLeaveApplication(int intApplicationId, int intLeaveTypeID, int? userID, string empCode, DateTime dateAppliedFromDate, DateTime dateAppliedToDate, string strLeaveReason, string strAddressDuetoLeave, string strphoneDuetoLeave)
        {
            //Summary    :   This function will use to Update Leave Application by Application And EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-7-2012
            //Modified   :   
            //Parameters :   return updateStatus
            try
            {
            string updateStatus = "";
            objSprUdateLeaveApplicationTableAdapter.SprUdateLeaveApplication(intApplicationId, userID, empCode, intLeaveTypeID, dateAppliedFromDate, dateAppliedToDate, strLeaveReason, strAddressDuetoLeave, strphoneDuetoLeave, ref updateStatus);
            return updateStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }

        public string SprDeleteLeaveApplication(int intApplicationId,int? userID, string empCode)
        {
            //Summary    :   This function will use to Update Leave Application by Application And EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-7-2012
            //Modified   :   
            //Parameters :   return deleteStatus 
            try
            {
            string deleteStatus = "";
            objSprDeleteLeaveApplicationTableAdapter.SprDeleteLeaveApplication(intApplicationId, userID, empCode, ref deleteStatus);
            return deleteStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }

        public DataTable GetAllUnApprovedLeaveApplicationByEmployeeCodeOrUserID(int? userID, string empCode)
        {
            //Summary    :   This function will use to Get All UnApproved Leave Application  By  EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-7-2012
            //Modified   :   
            //Parameters :   return Unapprove Leave Application As DataTable 

            return objSprGetAllUnApprovedLeaveApplicationByUserIDOrEmpCodeTableAdapter.SprGetAllUnApprovedLeaveApplicationByUserIDOrEmpCode(userID, empCode);
        }
        #endregion

        
    }
}
