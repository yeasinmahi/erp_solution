using Dairy_DAL.Global_DALTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Dairy_DAL;
//using Dairy_DAL.Task_DALTableAdapters;
using Dairy_DAL.TaskDALTableAdapters;
using Dairy_DAL.Dairy_DALTableAdapters;

namespace Dairy_BLL
{
    public class Task_BLL
    {
        //New Variable
        public string InsertTask(int intWork, string strTaskTitle, string strPriority, int intStatusID, string strStatus, int intCompletePer, int intAssignBy, int intAssignTo, DateTime dteStart, DateTime dteDeadline, DateTime dteComplete, string strRemarks, int intInsertBy, int intReffID, DateTime dteDate, string strDescription, string xml, string strTaskReffNo, DateTime dteDeadlineTime)
        {
            string msg = "";
            SprTaskTableAdapter adp = new SprTaskTableAdapter();
            adp.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo, dteDeadlineTime, ref msg);
            return msg;
        }
        public string UpdateTaskCancel(int intReffID) 
        {
            string msg = "";
            SprTaskCancelTableAdapter adp = new SprTaskCancelTableAdapter();
            adp.UpdateTaskCancel(intReffID, ref msg);
            return msg;
        }

        public DataTable GetTaskReport2(int intWork, int intEnroll, int intSearchEnroll)
        {
            SprTaskReportTableAdapter adp = new SprTaskReportTableAdapter();
            try
            { return adp.GetReportNew(intWork, intEnroll, intSearchEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetNewR(int intWork, int intEnroll, int intSearchEnroll)
        {
            SprTaskAllNewRTableAdapter adp = new SprTaskAllNewRTableAdapter();
            try
            { return adp.GetNewR(intWork, intEnroll, intSearchEnroll); }
            catch { return new DataTable(); } 
        }
        
        public DataTable GetDetailsReport(int intReffid)  
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetDetailsReport(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetPropostMarks(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetPropostMarks(intReffid); }
            catch { return new DataTable(); }
        }

        public DataTable GetViewDoc(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetViewDoc(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetDocCountByDetailsID(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetDocCountByDetailsID(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetUpdateRowCountDataByDetails(int intReffid)  
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetUpdateRowCountDataByDetails(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetCompletePerCheck(int intReffid)  
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter(); 
            try
            { return adp.GetCompletePerCheck(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetDReqCount(int intReffid)
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetDReqCount(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetCountWorkPlan(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetCountWorkPlan(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetWorkPlanReport(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetWorkPlanReport(intReffid); }
            catch { return new DataTable(); }
        }
        public string UpdateTaskComplete(int intMarks, int intReffID) 
        {            
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            adp.UpdateTaskComplete(intMarks, intReffID);
            string msg = "Complete Successfully";
            return msg;
        }

        public string InsertDchangeReq(int intReffid, DateTime dteReqDate, DateTime dteReqTime, int intInsertBy, string strNotes) 
        {
            string msg = "";
            SprDeadlineChangeReqTableAdapter adp = new SprDeadlineChangeReqTableAdapter();
            adp.InsertDChangeReq(intReffid, dteReqDate, dteReqTime, intInsertBy, strNotes, ref msg);            
            return msg;
        }

        //public string InsertDChangeReqest(int intReffID, DateTime dteReqDate, DateTime dteReqTime, int intInsertBy) 
        //{
        //    TblTaskDeadlineChangeReqTableAdapter adp = new TblTaskDeadlineChangeReqTableAdapter();
        //    adp.InsertDeadlineReq(intReffID, dteReqDate, dteReqTime, intInsertBy);
        //    string msg = "Complete Successfully";
        //    return msg;
        //}
 
        public DataTable GetTaskInfoForUpdateR(int intReffid)  
        {
            TblTaskMainTableAdapter adp = new TblTaskMainTableAdapter();
            try
            { return adp.GetTaskInfoForUpdateR(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetDeadlineChangeReport(int intReffid)  
        {
            TblTaskDeadlineChangeReqTableAdapter adp = new TblTaskDeadlineChangeReqTableAdapter();
            try
            { return adp.GetDeadlineChangeReport(intReffid); }
            catch { return new DataTable(); }
        }        
        public DataTable GetCountDetailsByTask(int intReffid) 
        {
            TblTaskMainTableAdapter adp = new TblTaskMainTableAdapter();
            try
            { return adp.GetCountDetailsByTask(intReffid); }
            catch { return new DataTable(); }
        }
        public DataTable GetDocCountByReffID(int intReffid) 
        {
            TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
            try
            { return adp.GetDocCountByReffID(intReffid); }
            catch { return new DataTable(); }
        }


        // DISCIPLINE ***********************************************************************************************************

        public DataTable GetActionList()  
        {
            TblDisciplineActionListTableAdapter adp = new TblDisciplineActionListTableAdapter();
            try
            { return adp.GetActionList(); }
            catch { return new DataTable(); }
        }

        public string InsertTask(int intWork, int intEmpID, string strCase,string strDescription, int intCreatedBy, DateTime dteCreatedOn, DateTime dteDeadline, int intStatusID, string strStatus, int intActionID, int intInsertBy, string xml)
        {
            string msg = "";
            SprDisciplineInsertUpdateTableAdapter adp = new SprDisciplineInsertUpdateTableAdapter();
            adp.InsertDiscipline(intWork, intEmpID, strCase, strDescription, intCreatedBy, dteCreatedOn, dteDeadline, intStatusID, strStatus, intActionID, intInsertBy, xml, ref msg);
            return msg;
        }

        public string InsertWorkPlan(int intReffid, int intInsertBy, string xml) 
        {
            string msg = "";
            SprTaskWorkPlanTableAdapter adp = new SprTaskWorkPlanTableAdapter();
            adp.InsertWorkPlan(intReffid, intInsertBy, xml, ref msg);
            return msg;
        }

        

         public DataTable GetDisciplineReport(int intWork, int intUnitid)  
        {
            SprDisciplineReportTableAdapter adp = new SprDisciplineReportTableAdapter();
            try
            { return adp.GetDisciplineReport(intWork, intUnitid); }
            catch { return new DataTable(); }
        }
         public DataTable GetDocCount(int intReffid)
         {
             TblDisciplineActionListTableAdapter adp = new TblDisciplineActionListTableAdapter();
             try
             { return adp.GetDocCount(intReffid); }
             catch { return new DataTable(); }
         }
         public DataTable GetDisciplineDocView(int intReffid)
         {
             TblDisciplineActionListTableAdapter adp = new TblDisciplineActionListTableAdapter();
             try
             { return adp.GetDisciplineDocView(intReffid); }
             catch { return new DataTable(); }
         }

         public DataTable GetPicturePath(int intEnroll)  
         {
             TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
             try
             { return adp.GetPicturePath(intEnroll); } 
             catch { return new DataTable(); }
         }
         public DataTable GetMyDocCheckCount(int intReffid) 
         {
             TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
             try
             { return adp.GetMyDocCheckCount(intReffid); }
             catch { return new DataTable(); }
         }
         public DataTable GetMyTaskDocView(int intReffid) 
         {
             TblTaskDetailsTableAdapter adp = new TblTaskDetailsTableAdapter();
             try
             { return adp.GetMyTaskDocView(intReffid); }
             catch { return new DataTable(); }
         }
         public DataTable GetEmpListBySupervisor(int intSvEnroll)
         {
             TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
             try
             { return adp.GetEmpListBySupervisor(intSvEnroll); }
             catch { return new DataTable(); }
         }
         public DataTable GetTeamMemberList(int intSvEnroll) 
         {
             TblHRDocUploadTableAdapter adp = new TblHRDocUploadTableAdapter();
             try
             { return adp.GetTeamMemberList(intSvEnroll); }
             catch { return new DataTable(); }
         }
         public DataTable GetEmpList(int intPart, int intJobStationID, DateTime dteDate) 
         {
             SprEmpSalaryStopRTableAdapter adp = new SprEmpSalaryStopRTableAdapter();
             try
             { return adp.GetEmpList(intPart, intJobStationID, dteDate); }
             catch { return new DataTable(); }
         }
         public DataTable GetJobStationList(int intUnitID)   
         {
             TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
             try
             { return adp.GetJobStationList(intUnitID); }
             catch { return new DataTable(); }
         } 
         public string InsertEmpSalaryStop(int intPart, int intEnroll, int intInsertBy, int intUnitID, int intJobStationID, DateTime dteDate, string xml)
         {
             string msg = "";
             SprEmpSalaryStopInsertTableAdapter adp = new SprEmpSalaryStopInsertTableAdapter();
             adp.InsertEmpSalaryStop(intPart, intEnroll, intInsertBy, intUnitID, intJobStationID, dteDate, xml, ref msg);
             return msg;
         }

        public DataTable GetMilkSupplierInfoForUpdate(int intCCID, string strCode)
        {
            SuppUpdateTableAdapter adp = new SuppUpdateTableAdapter();
            try
            { return adp.GetMilkSupplierInfoForUpdate(intCCID, strCode); }
            catch { return new DataTable(); }
        }
        public string UpdateSuppInfo(string strBankName, string strBankBranchName, string strBankAccountNo, string strOrgAddress, string strReprContactNo, string strNationalIDNo, int intBankID, int intDistrictID, int intBranchID, int intLastActionBy, int intCCID, int intSupplierID)
        {
            string msg = "";
            SprSupplierInfoUpdateForMilkTableAdapter adp = new SprSupplierInfoUpdateForMilkTableAdapter();
            adp.UpdateSuppInfo(strBankName, strBankBranchName, strBankAccountNo, strOrgAddress, strReprContactNo, strNationalIDNo, intBankID, intDistrictID, intBranchID, intLastActionBy, intCCID, intSupplierID, ref msg);
            return msg;
        }








        //GetPicturePath





























    }

}