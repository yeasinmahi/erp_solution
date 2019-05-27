using System;
using System.Data;
using DAL.Inventory.FactoryPurchaseReturnTdsTableAdapters;
using Utility;

namespace DALOOP.Inventory
{
    public class FactoryPurchaseReturnDal
    {
        private DataTable _dt = new DataTable();
        public int Insert(int intMrrId, int itemId,decimal poQty,decimal numRcvQty,decimal returnQty,decimal returnValue, int intEnroll, int intUnit, string remarks)
        {
            try
            {
                tblFactoryPurchaseReturnTableAdapter adp = new tblFactoryPurchaseReturnTableAdapter();
                _dt = adp.Insert1(intMrrId, itemId, poQty, numRcvQty, returnQty, returnValue, intEnroll, intUnit, remarks);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.GetAutoId("intReturnID");
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
