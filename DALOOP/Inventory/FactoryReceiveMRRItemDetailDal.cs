using System;
using System.Data;
using DAL.Inventory.FactoryReceiveMRRItemDetailTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class FactoryReceiveMRRItemDetailDal
    {
        private DataTable _dt = new DataTable();
        public int Insert(int intMRRID, int intItemID, decimal numPOQty, decimal numReceiveQty, decimal monFCRate,decimal monFCTotal,decimal monBDTTotal,
            int intLocationID, int intPOID, string strReceiveRemarks, decimal monVATAmount, decimal monAITAmount, string dteExpireDate, string dteMFGdate,
            string strBatchNo)
        {
            try
            {
                tblFactoryReceiveMRRItemDetailTableAdapter adp = new tblFactoryReceiveMRRItemDetailTableAdapter();
                _dt = adp.Insert1(intMRRID, intItemID, numPOQty, numReceiveQty, monFCRate, monFCTotal, monBDTTotal,
                    intLocationID, intPOID, strReceiveRemarks, monVATAmount, monAITAmount, dteExpireDate, dteMFGdate,
                    strBatchNo);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.GetAutoId("intAutoID");
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
