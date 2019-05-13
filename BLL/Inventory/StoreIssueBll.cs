using System;
using System.Data;
using BLL.Accounts;

namespace BLL.Inventory
{
    public class StoreIssueBll
    {
        private DataTable _dt;
        public void  StoreIssue(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId,int enroll)
        {
            InventoryBll inventoryBll = new InventoryBll();
            int jvId = inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            if (jvId > 0)
            {
                ItemListBll itemList = new ItemListBll();
                int coaId = itemList.GetItemCoaId(itemId);
                if (coaId > 0)
                {
                    AccountsVoucherJournalBll accountsVoucherJournalBll = new AccountsVoucherJournalBll();
                    _dt = accountsVoucherJournalBll.GetJurnalVoucher(jvId,DateTime.Now);
                    if (_dt.Rows.Count > 0)
                    {
                        AccountsVoucherJournalDetailsBll accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
                        _dt = accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId);
                        if (_dt.Rows.Count > 0)
                        {
                            if (UpdateJournalVoucherDetails())
                            {
                                
                                if (UpdateJournalVoucher())
                                {
                                    // TODO: success
                                }
                                else
                                {
                                    // TODO: RollBack
                                }
                            }
                            else
                            {
                                // TODO: RollBack
                            }
                        }
                        else
                        {
                            if (InsertJournalVoucherDetails())
                            {
                                if (UpdateJournalVoucher())
                                {
                                    // TODO: success
                                }
                                else
                                {
                                    // TODO: RollBack
                                }
                            }
                            else
                            {
                                // TODO: RollBack
                            }
                        }
                    }
                    else
                    {
                        if (InsertJournalVoucher())
                        {
                            if (InsertJournalVoucherDetails())
                            {
                                //TODO: success insert
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

                }
                else
                {
                    InconsistanceItemBll inconsistanceItemBll = new InconsistanceItemBll();
                    if (inconsistanceItemBll.Insert(whId, itemId, itemQuantity, itemValue, locationId, enroll) > 0)
                    {
                        //TODO: success insert
                    }
                    else
                    {
                        //TODO: fails insert
                    }
                }
                
            }
            else
            {
                // TODO: Insert Journal Voucher
                WareHouseBll wareHouseBll = new WareHouseBll();
                int unitId = wareHouseBll.GetUnitIdByWhId(whId);
                if (unitId > 0)
                {
                    CodeInfoBll codeInfoBll = new CodeInfoBll();
                    string voucherCode = codeInfoBll.GetJurnalVoucherCode(unitId);

                }
                else
                {
                    // TODO: Reverse
                }
            }


        }

        private bool InsertJournalVoucher()
        {
            return true;
        }
        private bool InsertJournalVoucherDetails()
        {
            return true;
        }
        private bool UpdateJournalVoucher()
        {
            return true;
        }
        private bool UpdateJournalVoucherDetails()
        {
            return true;
        }
    }
}
