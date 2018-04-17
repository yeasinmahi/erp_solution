using HR_DAL.DocumentTracking.DocumentTrackingTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.DocumentTracking
{
    public class DocumentTrackingBLL
    {
        public DataTable GetDivisionData()
        {
            TblDTSDivisionTableAdapter adp = new TblDTSDivisionTableAdapter();
            try
            { return adp.GetDivisionData(); }
            catch { return new DataTable(); }
        }
        public DataTable GetDeptData(int intDivision)
        {
            TblDTSDepartmentTableAdapter adp = new TblDTSDepartmentTableAdapter();
            try
            { return adp.GetDeptData(intDivision); }
            catch { return new DataTable(); }
        }
        public DataTable GetSectionData(int intDeptID)
        {
            TblDTSSectionTableAdapter adp = new TblDTSSectionTableAdapter();
            try
            { return adp.GetSectionData(intDeptID); }
            catch { return new DataTable(); }
        }
        public DataTable GetLocationData()
        {
            TblDTSLocationTableAdapter adp = new TblDTSLocationTableAdapter();
            try
            { return adp.GetLocationData(); }
            catch { return new DataTable(); }
        }
        public DataTable GetFolderData(int intLocationID)
        {
            TblDTSFolderTableAdapter adp = new TblDTSFolderTableAdapter();
            try
            { return adp.GetFolderData(intLocationID); }
            catch { return new DataTable(); }
        }
        public string InsertDTS(int intPart, int intDivisionID, string strDivision, int intDeptID, string strDepartment, string strSection, int intLocation, string strLocation, string strFolder, int intInsertBy)
        {
            string msg = "";
            try
            {
                SprDocumentTrackingInsertUpdateTableAdapter adp = new SprDocumentTrackingInsertUpdateTableAdapter();
                adp.InsertDTS(intPart, intDivisionID, strDivision, intDeptID, strDepartment, strSection, intLocation, strLocation, strFolder, intInsertBy, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public string InsertDTSDocReg(int intPart, int intDocumentTypeID, DateTime? dteFrom, DateTime? dteTo, int intUnitID, int intJobStationID, int intDivisionID, int intDeptID, int intSectionID, int intLocationID, int intFolderID, string strDocumentCode, string strDocumentInfo, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprDocumentRegistrationTableAdapter adp = new SprDocumentRegistrationTableAdapter();
                adp.InsertDocReg(intPart, intDocumentTypeID, dteFrom, dteTo, intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, strDocumentCode, strDocumentInfo, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public DataTable GetDocumentTypeData()
        {
            TblDocumentTypeTableAdapter adp = new TblDocumentTypeTableAdapter();
            try
            { return adp.GetDocumentTypeData(); }
            catch { return new DataTable(); }
        }
        public DataTable GetDTSReport(int intPart,string strSearch,DateTime dteFromDate,DateTime dteToDate)
        {
            SprDTSSearchResultTableAdapter adp = new SprDTSSearchResultTableAdapter();
            try
            { return adp.GetReport(intPart, strSearch, dteFromDate, dteToDate); }
            catch { return new DataTable(); }
        }

        public string InsertUpdateRequisition(int intPart, int intDocRegID, int intID, int? intRequiredBy, bool? ysnReturnable, string strRequiredType, DateTime? dteRequiredDate, bool? ysnApproved, int? intApprovedBy, bool? ysnIssued, int? intIssuedBy, DateTime? dteReturnDate)
        {
            string msg = "";
            try
            {
                TblDTSRequisitionTableAdapter adp = new TblDTSRequisitionTableAdapter();
                adp.InsertUpdateRequisition(intPart, intDocRegID, intID, intRequiredBy, ysnReturnable, strRequiredType, dteRequiredDate, ysnApproved, intApprovedBy, ysnIssued, intIssuedBy, dteReturnDate, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }

        public DataTable GetDTSReport(int intPart, int intSupervisor)
        {
            SprDTSReportTableAdapter adp = new SprDTSReportTableAdapter();
            try
            { return adp.GetDTSReportData(intPart, intSupervisor); }
            catch { return new DataTable(); }
        }
        
        public DataTable GetPendingList(int intJobStationID)
        {
            PendingListTableAdapter adp = new PendingListTableAdapter();
            try
            { return adp.GetPendingList(intJobStationID); }
            catch { return new DataTable(); }
        }
        public DataTable GetAllReport(int intJobStationID)
        {
            AllReportTableAdapter adp = new AllReportTableAdapter();
            try
            { return adp.GetAllReport(intJobStationID); }
            catch { return new DataTable(); }
        }
        public DataTable GetDocInfo(int intQRCodeID)
        {
            QryDocumentTrackingDetailsTableAdapter adp = new QryDocumentTrackingDetailsTableAdapter();
            try
            { return adp.GetDocInfo(intQRCodeID); }
            catch { return new DataTable(); }
        }

        public void UpdateTransfer(int intUnitID, int intJobStationID, int intDivisionID, int intDeptID, int intSectionID, int intLocationID, int intFolderID, string strDocumentInfo, int intDocRegID)
        {
            TblDTSDocumentRegTableAdapter adp = new TblDTSDocumentRegTableAdapter();
            try
            {
                adp.UpdateTransferInfo(intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, strDocumentInfo, intDocRegID);
            }
            catch { }
        }
        public DataTable GetFileName(int intReffID)
        {
            TblDTSDocListTableAdapter adp = new TblDTSDocListTableAdapter();
            try
            { return adp.GetFileName(intReffID); }
            catch { return new DataTable(); }
        }












    }
}
