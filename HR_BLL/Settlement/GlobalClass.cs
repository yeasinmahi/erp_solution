using HR_DAL.Settlement.GlobalTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace HR_BLL.Settlement
{
    public class GlobalClass
    {       
       public DataTable GetReportForAllUpdate(int intPart, int intSVID, int intUnitID) 
        {
            SprSeparateReportAllTableAdapter adp = new SprSeparateReportAllTableAdapter();
            try
            { return adp.GetReportForAllUpdate(intPart, intSVID, intUnitID); }
            catch { return new DataTable(); }
        }

      public DataTable GetDetailsReportAll(int intEnroll)
       {
           SprSeparateDetailsReportAllTableAdapter adp = new SprSeparateDetailsReportAllTableAdapter();
           try
           { return adp.GetDetailsReportAll(intEnroll); }
           catch { return new DataTable(); }
       }

      public DataTable GetUnitListForSeparation(int intEnroll)
      {
          SprUnitListForSeparationTableAdapter adp = new SprUnitListForSeparationTableAdapter();
          try
          { return adp.GetUnitListForSeparation(intEnroll); }
          catch { return new DataTable(); }
      }

      public void InsertDocPath(int intEnroll, string strFilePath, int intSeparationID)
      {

          TblSeparationDocPathTableAdapter adp = new TblSeparationDocPathTableAdapter();

          adp.InsertDocPath(intEnroll, strFilePath, intSeparationID);

      }

      public DataTable GetDocPath(int intSeparationID)
      {

          GetSeparationDocPathTableAdapter adp = new GetSeparationDocPathTableAdapter();

          try

          { return adp.GetDocPath(intSeparationID); }

          catch { return new DataTable(); }

      }
        public DataTable GetJobStationByUnit(int intUnitid) 
        {
            TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
            try
            { return adp.GetJobStationByUnit(intUnitid); }
            catch { return new DataTable(); }
        }

        public string InsertInsuranceInfoEntry(int intEnroll, int intInsertBy, int intUnitid, int intJobStationid, bool ysnGroup, bool ysnMedical, string xmlDtFareCash, DateTime dteDBirth,string medicaltype)
        {
            string msg = "";
            SprInsuranceInforEntryTableAdapter adp = new SprInsuranceInforEntryTableAdapter();
            adp.InsertInsuranceInfoEntry(intEnroll, intInsertBy, intUnitid, intJobStationid, ysnGroup, ysnMedical, xmlDtFareCash, dteDBirth, medicaltype, ref msg);
            return msg;
        }

        public DataTable GetDependantListByEnroll(int intEnroll)
        {
            TblEmpInsuranceInfoTableAdapter adp = new TblEmpInsuranceInfoTableAdapter();
            try
            { return adp.GetDependantListByEnroll(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetMedicalType(int intEnroll)
        {
            TblEmpInsuranceInfoTableAdapter adp = new TblEmpInsuranceInfoTableAdapter();
            try
            { return adp.GetMedicalType(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable CancelInsurance(int intUpdateBy,int intEnroll)
        {
            TblEmpInsuranceInfoTableAdapter adp = new TblEmpInsuranceInfoTableAdapter();
            try
            { return adp.CancelInsurance(intUpdateBy, intEnroll); }
            catch { return new DataTable(); }
        }
        //
        public DataTable GetInsuranceRData(int intUnit, int intJobS, bool ysnAll)
        {
            SprInsuranceInforReportTableAdapter adp = new SprInsuranceInforReportTableAdapter();
            try
            { return adp.GetInsuranceRData(intUnit, intJobS, ysnAll); }
            catch { return new DataTable(); }
        }

        public void Getmedicaltype(int enrolid,  ref string medicaltypentry)
        {
            string medictyp = null;


            SprInsuranceMedicalTypeTableAdapter ta = new SprInsuranceMedicalTypeTableAdapter();
            ta.GetData(enrolid,  ref medictyp);

            medicaltypentry = medictyp.ToString();
           
        }

        public void GetInsurancePermissionstatus(int enrolid, ref string permission)
        {
            string permis = null;
            SprEmployeeInsurancePermissionTableAdapter ta = new SprEmployeeInsurancePermissionTableAdapter();
            ta.GetDataPermission(enrolid, ref permis);
            permission = permis.ToString();
        }
        public DataTable GetDateRangeReport(int intPart, int intUnitID, int intJobStationID, int intAll, DateTime dteFrom, DateTime dteTo)
        {
            SprInsurancePerodicalReportTableAdapter adp = new SprInsurancePerodicalReportTableAdapter();
            try
            { return adp.GetDateRangeReport(intPart, intUnitID, intJobStationID, intAll, dteFrom, dteTo); }
            catch { return new DataTable(); }
        }


        public DataTable GetInsuranceInfoUpdate(int pkid, string medicaltype, int rptytpe,int unitid, int jobstationid ,int modifyby)
        {
            SprInsuranceInforUpdateTableAdapter adp = new SprInsuranceInforUpdateTableAdapter();
            try
            { return adp.GetDataInsuranceInforUpdate(pkid,  medicaltype,  rptytpe, unitid,  jobstationid,  modifyby); }
            catch { return new DataTable(); }
        }


        public DataTable GetInsuranceInTYPE()
        {
            TblInsuranceTypeTableAdapter adp = new TblInsuranceTypeTableAdapter();
            try
            { return adp.GetData(); }
            catch { return new DataTable(); }
        }






    }
}