using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Loan.LoanTDSTableAdapters;
using System.Data;

namespace HR_BLL.Loan
{
    public class Loan
    {
        #region Object Declare
        SprInsertLoanApplicationTableAdapter objSprInsertLoanApplicationTableAdapter = new SprInsertLoanApplicationTableAdapter();
        SprUpdateLoanApplicationTableAdapter objSprUpdateLoanApplicationTableAdapter = new SprUpdateLoanApplicationTableAdapter();
        SprDeleteLoanApplicationTableAdapter objSprDeleteLoanApplicationTableAdapter = new SprDeleteLoanApplicationTableAdapter();
        SprGetAllLoanApplicationByUserIDTableAdapter objSprGetAllLoanApplicationByUserIDTableAdapter = new SprGetAllLoanApplicationByUserIDTableAdapter();
        SprGetAllUnapproveLoanApplicationForApproveTableAdapter objSprGetAllUnapproveLoanApplicationForApproveTableAdapter = new SprGetAllUnapproveLoanApplicationForApproveTableAdapter();
        SprApproveLoanApplicationTableAdapter objSprApproveLoanApplicationTableAdapter = new SprApproveLoanApplicationTableAdapter();
        SprLoanGetLoanScheduleDetailsByLoanApplicationIDTableAdapter objSprLoanGetLoanScheduleDetailsByLoanApplicationIDTableAdapter = new SprLoanGetLoanScheduleDetailsByLoanApplicationIDTableAdapter();
        #endregion
        #region Method
        public string SprInsertLoanApplication(int? intUserID, string empCode, int? intLoanAmount, int? intNumberOfInstallment)
        {
            //Summary    :   This function will use to Insert data into Loan Application by Checking Existing active loan have or not
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   BY YEASIR;DATE:03/06/2012;ADD EMPCODE FOR PUBLIC LOAN APPLICATION
            //Parameters :   return insertStatus
            try
            {
                string insertStatus = "";
                objSprInsertLoanApplicationTableAdapter.SprInsertLoanApplication(intUserID, empCode, intLoanAmount, intNumberOfInstallment, ref insertStatus);
                return insertStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public string SprUpdateLoanApplication(int? intLoanApplicationId, int? intUserID, string empCode, int? intLoanAmount, int? intNumberOfInstallment)
        {
            //Summary    :   This function will use to Update loan Application by Application
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   BY YEASIR;DATE:03/06/2012;ADD EMPCODE FOR PUBLIC LOAN APPLICATION
            //Parameters :   return updateStatus
            try
            {
                string updateStatus = "";
                objSprUpdateLoanApplicationTableAdapter.SprUpdateLoanApplication(intLoanApplicationId, intUserID, empCode, intLoanAmount, intNumberOfInstallment, ref updateStatus);
                return updateStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public string SprDeleteLoanApplication(int? intLoanApplicationId, int? intUserID, string empCode)
        {
            //Summary    :   This function will use to delete Application by Application And EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   BY YEASIR;DATE:03/06/2012;ADD EMPCODE FOR PUBLIC LOAN APPLICATION
            //Parameters :   return deleteStatus 
            try
            {
                string deleteStatus = "";
                objSprDeleteLoanApplicationTableAdapter.SprDeleteLoanApplication(intLoanApplicationId, intUserID, empCode, ref deleteStatus);
                return deleteStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public DataTable GetAllLoanApplicationByUserID(int? intUserID, string empCode)
        {
            //Summary    :   This function will use to Get All Loan Application  By  EmployeeID
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   BY YEASIR;DATE:03/06/2012;ADD EMPCODE FOR PUBLIC LOAN APPLICATION
            //Parameters :   return Unapprove Official movement Application As DataTable 

            return objSprGetAllLoanApplicationByUserIDTableAdapter.SprGetAllLoanApplicationByUserID(intUserID, empCode);
        }
        // public DataTable SprGetAllUnapproveLoanApplicationForApprove()
        //{
        //    //Summary    :   This function will use to Get All UnApproved loan Application  for approve
        //    //Created    :   Md. Yeasir Arafat / FEB-23-2012
        //    //Modified   :   
        //    //Parameters :   return Unapprove Official movement Application As DataTable 

        //    return objSprGetAllUnapproveLoanApplicationForApproveTableAdapter.SprGetAllUnapproveLoanApplicationForApprove();
        //}
        public DataTable GetAllUnApprovedLoanApplicationByUserID(int? intUserID)
        {
            //Summary    :   This function will use to Get All UnApproved loan Application  for approve By UserID
            //Created    :   Md. Yeasir Arafat / Appril-01-2012
            //Modified   :   
            //Parameters :   Get intUserID  return Unapprove Official movement Application As DataTable 

            SprLoanGetAllUnapproveLoanApplicationForApproveByUserIDTableAdapter objSprLoanGetAllUnapproveLoanApplicationForApproveByUserIDTableAdapter = new SprLoanGetAllUnapproveLoanApplicationForApproveByUserIDTableAdapter();
            return objSprLoanGetAllUnapproveLoanApplicationForApproveByUserIDTableAdapter.SprLoanGetAllUnapproveLoanApplicationForApproveByUserID(intUserID);
        }
        public string ApproveLoanApplicationData(string strEmployeeName, int intEmployeeID, int intLoanApplicationId, int intLoanAmount, int intNumberOfInstallment, DateTime dteEffectiveDate, int userID)
        {
            //Summary    :   This function will use to Approve loan Application by ApplicationID
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   
            //Parameters :   return appproveStatus
            try
            {
                string appproveStatus = "";
                objSprApproveLoanApplicationTableAdapter.SprApproveLoanApplication(intLoanApplicationId, 1, true, intLoanAmount, intNumberOfInstallment, dteEffectiveDate, ref appproveStatus);
                return appproveStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        public DataTable GetLoanScheduleDetailsByLoanApplicationID(int? intLoanApplicationId)
        {
            //Summary    :   This function will use to Get Loan Schedule Details By Loan ApplicationID
            //Created    :   Md. Yeasir Arafat / FEB-26-2012
            //Modified   :   
            //Parameters :   return Loan schedule details by loan application ID

            return objSprLoanGetLoanScheduleDetailsByLoanApplicationIDTableAdapter.SprLoanGetLoanScheduleDetailsByLoanApplicationID(intLoanApplicationId);
        }
        public DataTable GetLoanScheduleDetailsByEmployeeCode(string strEmployeeCode, ref int? intLoanApplicationID, ref decimal? monTotalLoanScheduleAmount)
        {
            //Summary    :   This function will use to Get Loan Schedule Details By employeeCode
            //Created    :   Md. Yeasir Arafat / October-13-2012
            //Modified   :   
            //Parameters :   return Loan schedule details by loan employee code

            try
            {
                SprLoan_GetLoanScheduleDetailsByEmployeeCodeTableAdapter tbl = new SprLoan_GetLoanScheduleDetailsByEmployeeCodeTableAdapter();
                return tbl.GetLoanScheduleDetailsByEmployeeCode(strEmployeeCode, ref intLoanApplicationID, ref monTotalLoanScheduleAmount);
            }
            catch
            {
                DataTable odt = new DataTable();
                return odt;
            }
        }


        public string UpdateLoanScheduleDetails(int? intLoanApplicationId, string xmlLoanScheduleDetails, int? intSoftwareLoginUserId)
        {
            //Summary    :   This function will use to Update loan schedule details
            //Created    :   Md. Yeasir Arafat / Oct-14-2012
            //Modified   :   
            //Parameters :   return updateStatus
            try
            {
                SprLoan_UpdateLoanScheduleDetailsTableAdapter tbl = new SprLoan_UpdateLoanScheduleDetailsTableAdapter();
                string strUpdateStatus = "";
                tbl.UpdateLoanScheduleDetails(intSoftwareLoginUserId, xmlLoanScheduleDetails, intLoanApplicationId, ref strUpdateStatus);
                return strUpdateStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }

        public string RepayLoanAmount(int? intLoanApplicationId, int? intLoanRepayAmount)
        {
            //Summary    :   This function will use to repay loan amount
            //Created    :   Md. Yeasir Arafat / Oct-24-2012
            //Modified   :   
            //Parameters :   return updateStatus
            try
            {
                SprLoan_RepayLoanAmountTableAdapter tbl = new SprLoan_RepayLoanAmountTableAdapter();
                string strRepayStatus = "";
                tbl.RepayLoanAmount(intLoanApplicationId, intLoanRepayAmount, ref strRepayStatus);
                return strRepayStatus;
            }
            catch (Exception ex)
            { return ex.Message.ToString(); }
        }
        #endregion

        #region ------------  Employee allowance and Attendance Benifit -------------
        public DataTable GetAllowanceTypeList()
        {
            TblAllowanceTypeTableAdapter adp = new TblAllowanceTypeTableAdapter();
            return adp.GetAllowanceTypeData();
        }
        public string InsertAllowance(string code, int allowancetype, DateTime effectivedate, decimal amount, int userID)
        {
            SprEmployeeAllowanceInsertTableAdapter adp = new SprEmployeeAllowanceInsertTableAdapter();
            string msgStatus = "";
            try { adp.EmployeeAllowanceInsertData(code, allowancetype, effectivedate, amount, userID, ref msgStatus); }
            catch (Exception ex) { msgStatus = ex.ToString(); }
            return msgStatus;
        }
        public void DeleteAllowance(int allowanceid)
        {
            QueriesTableAdapter adp = new QueriesTableAdapter();
            adp.DeleteAllowance(allowanceid);
            adp.DeleteAllowanceDetails(allowanceid);
        }
        public DataTable GetAllowanceDetails(string empcode)
        {
            AllowanceDetailsTableAdapter adp = new AllowanceDetailsTableAdapter();
            try { return adp.GetAllowanceData(empcode); }
            catch { return new DataTable(); }
        }

        #endregion

        #region===== Md. Al-Amin Loan Code ===============================================
        public DataTable GetLoanReportByEnroll(int intPart, int intEnroll)
        {
            SprLoanReportByEnrollTableAdapter adp = new SprLoanReportByEnrollTableAdapter();
            try
            { return adp.GetLoanReportByEnroll(intPart, intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetLoanType()
        {
            TblLoanTypeTableAdapter adp = new TblLoanTypeTableAdapter();
            try
            { return adp.GetLoanType(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetRewardType()
        {
            TblLoanTypeTableAdapter adp = new TblLoanTypeTableAdapter();
            try
            { return adp.GetRewardType(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public string InsertUpdateLoan(int intPart, int intApplicationId, int intLType, int intUserID, int intLoanAmount, int intNumberOfInstallment, int intApproveLoanAmount, int intApproveNumberOfInstallment, DateTime dteEffectiveDate, string xml, string strRemarks)
        {
            try
            {
                string msg = "";
                SprLoanApproveLoanApplicationMTableAdapter adp = new SprLoanApproveLoanApplicationMTableAdapter();
                adp.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable InsertReward(int intPart, int intRType, int intEnroll, DateTime dteDate, decimal monAmount, string strRemarks, int intInsertBy)
        {
            try
            {
                //string msg = "";
                sprRewardTableAdapter adp = new sprRewardTableAdapter();
                return adp.GetData(intPart, intRType, intEnroll, dteDate, monAmount, strRemarks, intInsertBy);
                //return msg;
            }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        

         public DataTable GetAllReward(int intPart, int intRType, int intEnroll, DateTime dteDate, decimal monAmount, string strRemarks, int intInsertBy)
        {
            try
            {
                //string msg = "";
                sprRewardDeleteUpdateTableAdapter adp = new sprRewardDeleteUpdateTableAdapter();
                return adp.GetRewardData(intPart, intRType, intEnroll, dteDate, monAmount, strRemarks, intInsertBy);
                //return msg;
            }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }



        #endregion========================================================================



    }
}
