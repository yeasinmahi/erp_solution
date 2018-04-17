using HR_DAL.Dispatch.DispatchTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Dispatch
{
    public class DispatchBLL
    {
        public string InsertDispatch(DateTime dteDate, int intUnit, int intJobStation, string strNameAndAddress, string strSubject, string strRemarks, string fileName, int intInsertBy) 
        {
            string msg = "";
            SprDispatchEntryTableAdapter adp = new SprDispatchEntryTableAdapter();
            adp.InsertDispatch(dteDate, intUnit, intJobStation, strNameAndAddress, strSubject, strRemarks, fileName, intInsertBy, ref msg);
            return msg;
        }
        public DataTable GetDispatchR(string fdate, string tdate) 
        {
            TblDispatchTableAdapter adp = new TblDispatchTableAdapter();
            try
            { return adp.GetDispatchR(fdate, tdate); }
            catch { return new DataTable(); } 
        }
        public DataTable GetDocName(int intID)
        {
            TblDispatchDocNTableAdapter adp = new TblDispatchDocNTableAdapter();
            try
            { return adp.GetDocName(intID); } 
            catch { return new DataTable(); }
        }        
        public DataTable GetJobStation(int intUnitID)  
        {
            SprGetJobStationTableAdapter adp = new SprGetJobStationTableAdapter();
            try
            { return adp.GetJobStation(intUnitID); }
            catch { return new DataTable(); }
        }

        public DataTable GetDocDispatch(int intPart, int intDeliveryType, string strDocType, int intDocNameID, string strDeliveryType, int intDeliveryThruID, string strFName, string strFCompany, string strFCompanyAdd, string strFCompanyPhone, string strFMobile, string strFEmail, string strTName, string strTCompany, string strTCompanyAdd, string strTCompanyPhone, string strTMobile, string strTEmail, int intActionBy, DateTime dteDate, string strRemarks, bool ysnReceive)
        {
            SprDocDispatchTableAdapter adp = new SprDocDispatchTableAdapter();
            try
            { return adp.GetDocDispatch(intPart, intDeliveryType, strDocType, intDocNameID, strDeliveryType, intDeliveryThruID, strFName, strFCompany, strFCompanyAdd, strFCompanyPhone, strFMobile, strFEmail, strTName, strTCompany, strTCompanyAdd, strTCompanyPhone, strTMobile, strTEmail, intActionBy, dteDate, strRemarks, ysnReceive); }
            catch { return new DataTable(); }
        }

        public DataTable GetEmpName(int intEmpID)
        {
            TblEmployeeTableAdapter adp = new TblEmployeeTableAdapter();
            try
            { return adp.GetEmpName(intEmpID); }
            catch { return new DataTable(); }
        }









    }
}
