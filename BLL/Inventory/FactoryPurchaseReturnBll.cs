using BLL.Accounts;
using BLL.HR;
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

        public int PurchaseReturn(int intWhId, int intMrrId, int itemId, string itemName, decimal poQty, decimal numRcvQty, decimal returnQty, decimal returnValue, int locationId, string remarks, int supplierId, string supplierName, int intEnroll)
        {
            int unitId = _unitBll.GetUnitIdByWhId(intWhId);
            int purchaseReturnId = _dal.Insert(intMrrId, itemId, poQty, numRcvQty, returnQty, returnValue, intEnroll, unitId, remarks);
            if (purchaseReturnId > 0)
            {
                int inventoryId = _inventoryBll.InsertBySpInventoryTransection(unitId, intWhId, locationId, itemId,
                    returnQty*-1, returnValue*-1, purchaseReturnId, 2);
                if (inventoryId > 0)
                {
                    int coaId = _itemListBll.GetItemCoaId(itemId);
                    int coaId2 = _supplierBll.GetCoaId(supplierId);
                    if (coaId > 0 && coaId2>0)
                    {
                        string accName = _accountsChartOfAccBll.GetAccountName(coaId);
                        string accName2 = _accountsChartOfAccBll.GetAccountName(coaId2);
                        if (!string.IsNullOrWhiteSpace(accName) && !string.IsNullOrWhiteSpace(accName2))
                        {
                            int jvId = _accountsVoucherJournalBll.InsertJournalVoucher(intWhId, returnValue, "Purchase Return", intEnroll);
                            if (jvId > 0)
                            {
                                int jvId1 = _accountsVoucherJournalDetailsBll.Insert(jvId, coaId, itemName, returnValue, accName);
                                int jvId2 = _accountsVoucherJournalDetailsBll.Insert(jvId, coaId2, supplierName, returnValue * -1, accName2);
                                if(jvId1>0 && jvId2 > 0)
                                {
                                    return purchaseReturnId;
                                }
                            }
                            else
                            {
                                //TODO: Jv insert Failed
                            }
                            
                        }
                        else
                        {
                            //TODO: RollBack
                        }

                    }
                    else
                    {
                        //TODO: RollBack
                    }
                    
                }
                else
                {
                    //TODO: Inventory insert Failed
                }
            }
            else
            {
                //TODO: Purchase Return insert Failed
            }
            return purchaseReturnId;
        }
    }
}
