using SAD_DAL.Transport.InternalTransportTDSTableAdapters;
using SAD_DAL.Transport.UtilityTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.Transport
{
    public class Utility_BLL
    {
        //SprUtilityReportTableAdapter

        public DataTable GetUtilityProfile(int intWork, int intUnitID, DateTime dteFromDate, DateTime dteToDate, int intUtilityID, string strServiceName, int intReg)  
        {
            SprUtilityReportTableAdapter adp = new SprUtilityReportTableAdapter();
            try
            { return adp.GetAllReportForUtility(intWork, intUnitID, dteFromDate, dteToDate, intUtilityID, strServiceName, intReg); }
            catch { return new DataTable(); }
        }

        public string InsertPayment(int intUtilityID, string strLicenseAppNo, DateTime dteValidFrom, DateTime dteValidTo, DateTime dteExpireDate, DateTime dteNextSubmiteDate, decimal monGovFee, decimal monIncidentalCost, decimal monTotalCost, string strRemarks, int intInsertBy, DateTime dteSubmitDate, string xmlDocUpload)
        {
            string msg = "";
            SprUtilityPaymentInsertTableAdapter adp = new SprUtilityPaymentInsertTableAdapter();            
            adp.InsertPayment(intUtilityID, strLicenseAppNo, dteValidFrom, dteValidTo, dteExpireDate, dteNextSubmiteDate, monGovFee, monIncidentalCost, monTotalCost, strRemarks, intInsertBy, dteSubmitDate, xmlDocUpload, ref msg);
            return msg;
        }
        public DataTable GetDocList()
        {
            TblUtilityDocTypeTableAdapter adp = new TblUtilityDocTypeTableAdapter();
            try
            { return adp.GetDocList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetServiceList() 
        {
            TblUtilityListMainTableAdapter adp = new TblUtilityListMainTableAdapter();
            try
            { return adp.GetServiceList(); }
            catch { return new DataTable(); }
        }
        public DataTable GetDocListForView(int intReffID)
        {
            TblUtilityDocListTableAdapter adp = new TblUtilityDocListTableAdapter(); 
            try
            { return adp.GetDocTypeListForView(intReffID); }
            catch { return new DataTable(); }
        }

        public DataTable GetJobStationList(int intUnitID)
        { 
            TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
            try
            { return adp.GetJobStationList(intUnitID); }
            catch { return new DataTable(); }
        }
        public DataTable GetJobStationAddress(int intJobStationID)
        {
            TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
            try
            { return adp.GetJobStationAddress(intJobStationID); }
            catch { return new DataTable(); }
        }
        public string InsertRegistration(int intUnitID, int intJobStationID, string strServiceName, string strCategory, string strLicenseAuthAdd, string strLicenseAppNo, DateTime dteValidFrom, DateTime dteValidTo, DateTime dteExpireDate, DateTime dteNextSubmiteDate, decimal monGovFee, decimal monIncidentalCost, decimal monTotalCost, string strRemarks, int intInsertBy, DateTime dteSubmitDate, string xmlDocUpload)
        {
            string msg = "";
            SprUtilityRegistrationTableAdapter adp = new SprUtilityRegistrationTableAdapter();
            adp.InsertRegistration(intUnitID, intJobStationID, strServiceName, strCategory, strLicenseAuthAdd, strLicenseAppNo, dteValidFrom, dteValidTo, dteExpireDate, dteNextSubmiteDate, monGovFee, monIncidentalCost, monTotalCost, strRemarks, intInsertBy, dteSubmitDate, xmlDocUpload, ref msg);
            return msg;
        }

        








    }
}
