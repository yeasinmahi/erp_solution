using HR_DAL.Internal.IntrnalTransferTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HR_BLL.Internal
{
    public class internaltranfer
    {
        public void ApprovalSubmitedInsert(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit, decimal totalbill)
        {
            SprInternalApprovalBillTableAdapter approvalsubmit = new SprInternalApprovalBillTableAdapter();
            approvalsubmit.InternalApprovalBillGetData(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit, totalbill);
            
        }



        public System.Data.DataTable Requestview(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter requestview = new SprInternalApprovalTableAdapter();
            return requestview.InsertApprovalSubmitGetData(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        }



        public System.Data.DataTable RequestDetalisView(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter detalisview = new SprInternalApprovalTableAdapter();
            return detalisview.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
        }

        public void ApproveRequest(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter approve= new SprInternalApprovalTableAdapter();
           approve.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void ApprovedRequestwithDocUpload(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter approvewithdocupload = new SprInternalApprovalTableAdapter();
            approvewithdocupload.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void ForwardRequest(int intPart, int empto, string  subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter Forward = new SprInternalApprovalTableAdapter();
            Forward.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void ForwardRequestwithDocUpload(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter Forwardwithdocupload = new SprInternalApprovalTableAdapter();
            Forwardwithdocupload.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void RejectRequest(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter RejectRequest= new SprInternalApprovalTableAdapter();
            RejectRequest.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void RejectRequestwithDocUpload(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter RejectRequestwithdocupload = new SprInternalApprovalTableAdapter();
            RejectRequestwithdocupload.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public void CloseRequest(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter CloseRequest = new SprInternalApprovalTableAdapter();
            CloseRequest.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }



        public DataTable MainrequestDgv(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter MainRequest = new SprInternalApprovalTableAdapter();
           return MainRequest.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public DataTable Statusview(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter statusview = new SprInternalApprovalTableAdapter();
            return statusview.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

        public DataTable UserrRequestview(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter dt = new SprInternalApprovalTableAdapter();
            return dt.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }

       

       



        public DataTable renamedocfile(int intPart, int empto, int subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter renames = new SprInternalApprovalTableAdapter();
            return renames.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
        }

        public DataTable StatusCCview(int intPart, int empto, string subject, string path, string description, int intenroll, int intjobid, int intdept, int intUnit)
        {
            SprInternalApprovalTableAdapter statusCCview = new SprInternalApprovalTableAdapter();
            return statusCCview.InsertApprovalSubmitGetData(intPart, empto, Convert.ToString(subject), path, description, intenroll, intjobid, intdept, intUnit);
    
        }
    }
}
