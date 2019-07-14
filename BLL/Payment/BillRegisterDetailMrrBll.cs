using System;
using System.Data;
using DALOOP.Payment;
using DAL.Inventory.InventoryTableAdapters;

namespace BLL.Payment
{
    public class BillRegisterDetailMrrBll
    {
        private readonly BillRegisterDetailMrrDal _dal = new BillRegisterDetailMrrDal();

        public DataTable GetBillRegisterDetailsMrrByBillId(int billId)
        {
            return _dal.GetBillRegisterDetailsMrrByBillId(billId);
        }
        public DataTable GetBillRegisterDetailsMrrByMrrId(int mrrId)
        {
            return _dal.GetBillRegisterDetailsMrrByMrrId(mrrId);
        }

        internal void InsertPurchaseReturn(int intMrrId, int intWhId, int itemId, decimal returnQty, int intEnroll, string remarks)
        {
            try
            {
                sprPurchaseReturnTableAdapter adp = new sprPurchaseReturnTableAdapter();
                adp.InsertPurchaseReturn(intMrrId, intWhId, itemId, returnQty, intEnroll, remarks);
            }
            catch { }
        }
    }
}
