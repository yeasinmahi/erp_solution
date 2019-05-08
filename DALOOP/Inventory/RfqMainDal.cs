using System;
using System.Data;
using DAL.Inventory.RfqMainTdsTableAdapters;

namespace DALOOP.Inventory
{
    public class RfqMainDal
    {
        private DataTable _dt;
        public DataTable GetRfq(int rfqId)
        {
            try
            {
                tblRFQMainTableAdapter adp = new tblRFQMainTableAdapter();
                return adp.GetData(rfqId);

            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public int GetUnitIdByRfqId(int rfqId)
        {
            try
            {
                _dt = GetRfq(rfqId);
                if (_dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intUnitId"].ToString());
                }
                return 0;

            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public bool WinRfq(int supplierId, string winCause, int rfqId)
        {
            try
            {
                tblRFQMain1TableAdapter adp = new tblRFQMain1TableAdapter();
                adp.GetData(supplierId, winCause, rfqId);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
