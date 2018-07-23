using SCM_DAL.MrrReceiveTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class MrrReceive_BLL
    {
        public DataTable DataView(int Part, string xmlString, int intWh, int intPO, DateTime dteDate, int enroll)
        { 
                try
                {
                    string msg = "";
                    SprMrrReceiveTableAdapter adp = new SprMrrReceiveTableAdapter();
                    return adp.GetMrrReceiveData(Part, xmlString, intWh, intPO, dteDate, enroll, ref msg);
                }
                catch { return new DataTable(); } 
        }

        public string MrrReceive(int part, string xmlString, int intWh, int intPOID, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
               
                 SprMrrReceiveTableAdapter adp = new SprMrrReceiveTableAdapter();
                  adp.GetMrrReceiveData(part, xmlString, intWh, intPOID, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }
        public DataTable GetWHByPO(int intPO,int intWh)
        {
            TblPurchaseOrderMainTableAdapter adp = new TblPurchaseOrderMainTableAdapter();
            try
            { return adp.GetWHByPO(intPO, intWh); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPO(int intPO)
        {
            TblPurchaseOrderMainTableAdapter adp = new TblPurchaseOrderMainTableAdapter();
            try
            { return adp.GetPO(intPO); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }




    }
}
