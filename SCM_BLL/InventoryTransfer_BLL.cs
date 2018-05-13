
using SCM_DAL.InventoryTransferTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class InventoryTransfer_BLL
    {
        public DataTable GetTtransferDatas(int Type, string xmlString, int intWh, int id, DateTime dteDate, int enroll)
        {
            try
            {
                string msg = "";
                SprInventoryTransferWebTableAdapter adp = new SprInventoryTransferWebTableAdapter();
                return adp.GetTransferData(Type, xmlString, intWh, id, dteDate, enroll, ref msg);
            }
            catch { return new DataTable(); }
           
        }

        public string PostTransfer(int Type, string xmlString, int intWh, int id, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                
                SprInventoryTransferWebTableAdapter adp = new SprInventoryTransferWebTableAdapter();
                 adp.GetTransferData(Type, xmlString, intWh, id, dteDate, enroll, ref strMsg);
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }
    }
}
