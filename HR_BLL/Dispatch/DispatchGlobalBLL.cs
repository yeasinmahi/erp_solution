using HR_DAL.Dispatch.DispatchGlobalTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_BLL.Dispatch
{
    public class DispatchGlobalBLL
    {        
        public DataTable GetEmpInfo(int intEnroll)
        {
            QRYEMPLOYEEPROFILEALLTableAdapter adp = new QRYEMPLOYEEPROFILEALLTableAdapter();
            try
            { return adp.GetEmpInfo(intEnroll); }
            catch { return new DataTable(); }
        }
        public DataTable GetJobStationStatus(int intJobStationID)
        {
            QRYEMPLOYEEPROFILEALLTableAdapter adp = new QRYEMPLOYEEPROFILEALLTableAdapter();
            try
            { return adp.GetJobStationStatus(intJobStationID); }
            catch { return new DataTable(); }
        }

        public string DispatchInsertUpdate(int intPart, int intDispatchID, int intWHID, int intDispatchType, string strDispatchType, int intReceiverEnroll, string strReceiver, string strAddress, string strRemarks, int intCreateBy, int intApproveBy, int intVehicleNo, string strVehicleNo, string strBearer, string strBearerContact, decimal monAmount, int intDispatchBy, int intReceiveBy, string xml)
        {
            string msg = "";
            SprDispatchTableAdapter adp = new SprDispatchTableAdapter();
            adp.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml, ref msg);
            return msg;
        }
        public DataTable GetDispatchReport(int intPart, int intEnroll)
        {
            SprDispatchAllReportTableAdapter adp = new SprDispatchAllReportTableAdapter();
            try
            { return adp.GetDispatchReport(intPart, intEnroll); }
            catch { return new DataTable(); }
        }

        













    }
}
