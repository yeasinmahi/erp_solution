using HR_DAL.Settlement.PersonalTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HR_BLL.Settlement
{
    public class SelfClass
    {        
        public DataTable GetEmpInfoForSeltResign(int intEnroll)
        {
            QryEmployeeProfileAllForSelfResignTableAdapter adp = new QryEmployeeProfileAllForSelfResignTableAdapter();
            try
            { return adp.GetEmpInfoForResign(intEnroll); }
            catch { return new DataTable(); }
        }

        public void InsertResign(int intPart, int intEnroll, DateTime dteSeparateDateTime, DateTime dteLastOfficeDate, DateTime dteLastOfficeDateByUser, DateTime dteLastOfficeDateByAuthority, string strSeparateReason, int intSeparateInsertBy, int intSeparateType, int intApproveBy, decimal monAmount, string strRemarks, string strEmailAdd, string strCurrentAddress) 
        {
            SprSeparateInsertAllTableAdapter adp = new SprSeparateInsertAllTableAdapter();
            adp.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
        }
        
        public DataTable CheckSelfResign(int intEnroll)
        {
            CheckSelfResignTableAdapter adp = new CheckSelfResignTableAdapter();
            try
            { return adp.CheckSelfResign(intEnroll); }
            catch { return new DataTable(); }
        }

        public DataTable GetSelfResignCancelData(int intEnroll)
        {
            QryEmployeeProfileAllSelfResignCancelDataTableAdapter adp = new QryEmployeeProfileAllSelfResignCancelDataTableAdapter();
            try
            { return adp.GetSelfResignCancelData(intEnroll); }
            catch { return new DataTable(); }
        }
             
        public DataTable CheckSelfResignWithdraw(int intEnroll)
        {
            CheckSelfResignWithdrawTableAdapter adp = new CheckSelfResignWithdrawTableAdapter();
            try
            { return adp.CheckSelfResignWithdraw(intEnroll); }
            catch { return new DataTable(); }
        }
     

       

    }
}