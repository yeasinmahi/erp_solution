using System.Data;
using BLL.Accounts;
using BLL.HR;
using BLL.Payment;
using DALOOP.Inventory;

namespace BLL.Inventory
{
    
    public class FactoryPurchaseReturnBll
    {
        private readonly FactoryPurchaseReturnDal _dal = new FactoryPurchaseReturnDal();
        private readonly InventoryBll _inventoryBll = new InventoryBll();
        private readonly UnitBll _unitBll = new UnitBll();
        private readonly AccountsVoucherJournalBll _accountsVoucherJournalBll = new AccountsVoucherJournalBll();
        private readonly AccountsVoucherJournalDetailsBll _accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
        private readonly ItemListBll _itemListBll = new ItemListBll();
        private readonly AccountsChartOfAccBll _accountsChartOfAccBll = new AccountsChartOfAccBll();
        private readonly SupplierBll _supplierBll = new SupplierBll();
        private readonly BillRegisterDetailMrrBll _billRegisterDetail = new BillRegisterDetailMrrBll();
        private DataTable _dt = new DataTable();

        public string PurchaseReturn(int intWhId, int intMrrId, int itemId, string itemName, decimal poQty, decimal numRcvQty, decimal returnQty, decimal returnValue, int locationId, string remarks, int supplierId, string supplierName, int intEnroll)
        {
            int unitId = _unitBll.GetUnitIdByWhId(intWhId);
            _dt = _billRegisterDetail.GetBillRegisterDetailsMrrByMrrId(intMrrId);
            if (_dt.Rows.Count > 0)
            {
                return "This MRR already complete payment. It can not be returned.";
            }


            _billRegisterDetail.InsertPurchaseReturn(intMrrId, intWhId, itemId, returnQty, intEnroll, remarks);

            

            //int purchaseReturnId = _dal.Insert(intMrrId, itemId, poQty, numRcvQty, returnQty, returnValue, intEnroll, unitId, remarks);

            //if (purchaseReturnId > 0)
            //{
            //    int inventoryId = _inventoryBll.InsertBySpInventoryTransection(unitId, intWhId, locationId, itemId,
            //        returnQty*-1, returnValue*-1, purchaseReturnId, 2);
            //    if (inventoryId > 0)
            //    {
            //        int coaId = _itemListBll.GetItemCoaId(itemId);
            //        int coaId2 = _supplierBll.GetCoaId(supplierId);
            //        if (coaId > 0 && coaId2>0)
            //        {
            //            string accName = _accountsChartOfAccBll.GetAccountName(coaId);
            //            string accName2 = _accountsChartOfAccBll.GetAccountName(coaId2);
            //            if (!string.IsNullOrWhiteSpace(accName) && !string.IsNullOrWhiteSpace(accName2))
            //            {
            //                int jvId = _accountsVoucherJournalBll.InsertJournalVoucher(intWhId, returnValue, "Purchase Return", intEnroll);
            //                if (jvId > 0)
            //                {
            //                    int jvId1 = _accountsVoucherJournalDetailsBll.Insert(jvId, coaId, itemName, returnValue, accName);
            //                    int jvId2 = _accountsVoucherJournalDetailsBll.Insert(jvId, coaId2, supplierName, returnValue * -1, accName2);
            //                    if(jvId1>0 && jvId2 > 0)
            //                    {
            //                        return "Purchase Return Successful. Returned ID: "+ purchaseReturnId;
            //                    }
            //                }
            //                else
            //                {
            //                    return "Jv Insert failed";
            //                    //TODO: Jv insert Failed
            //                }

            //            }
            //            else
            //            {
            //                return "failed to get acc";
            //                //TODO: RollBack
            //            }

            //        }
            //        else
            //        {
            //            return "failed to get COA";
            //            //TODO: RollBack
            //        }

            //    }
            //    else
            //    {
            //        return "Failed to inset data into inventory";
            //        //TODO: Inventory insert Failed
            //    }
            //}
            //else
            //{
            //    return "Failed to inset data into purchase return";
            //    //TODO: Purchase Return insert Failed
            //
            return "Purchase Return Successfull";
        }
    }
}
