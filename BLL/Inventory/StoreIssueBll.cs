using System;
using System.Data;
using BLL.Accounts;

namespace BLL.Inventory
{
    public class StoreIssueBll
    {
        private DataTable _dt;
        private readonly AccountsVoucherJournalBll _accountsVoucherJournalBll = new AccountsVoucherJournalBll();
        private readonly AccountsVoucherJournalDetailsBll _accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
        public void StoreIssue(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId, int enroll)
        {
            InventoryBll inventoryBll = new InventoryBll();
            int jvId = inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            if (jvId > 0)
            {
                ItemListBll itemList = new ItemListBll();
                int coaId = itemList.GetItemCoaId(itemId);
                if (coaId > 0)
                {
                    _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
                    if (_dt.Rows.Count > 0)
                    {
                        _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId);
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
                            int intId = InsertJournalVoucherDetails(jvId, coaId, itemValue);
                            if (intId > 0)
                            {
                                // TODO: success
                            }
                            else
                            {
                                // TODO: RollBack
                            }
                        }
                    }
                    else
                    {
                        int voucherId = InsertJournalVoucher(whId, itemValue, enroll);
                        if (voucherId > 0)
                        {
                            InsertJournalVoucherDetails(voucherId, coaId, itemValue);

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

            }


        }

        private int InsertJournalVoucher(int whId, decimal amount, int enroll)
        {
            WareHouseBll wareHouseBll = new WareHouseBll();
            int unitId = wareHouseBll.GetUnitIdByWhId(whId);
            if (unitId > 0)
            {
                CodeInfoBll codeInfoBll = new CodeInfoBll();
                string voucherCode = codeInfoBll.GetJurnalVoucherCode(unitId);
                return _accountsVoucherJournalBll.Insert(voucherCode, unitId, "Store Issue", amount, enroll);

            }
            return 0;
        }

        private int InsertJournalVoucherDetails(int voucherId, int coaId, decimal itemValue)
        {
            AccountsChartOfAccBll accountsChartOfAccBll = new AccountsChartOfAccBll();
            string accName = accountsChartOfAccBll.GetAccountName(coaId);
            if (!string.IsNullOrWhiteSpace(accName))
            {
                int intId = _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId, "Meterial Issue", itemValue, accName);
                if (intId > 0)
                {
                    int globalCoaId = accountsChartOfAccBll.GetGlobalCoaId(coaId);

                    if (globalCoaId == 31)
                    {
                        int coaId2 = accountsChartOfAccBll.GetCoaIdByGlobalCoaId(32);
                        string accName2 = accountsChartOfAccBll.GetAccountNameByGlobalCoaId(32);
                        if (coaId2 > 0 && !string.IsNullOrWhiteSpace(accName2))
                        {
                            intId = _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId, "Transfer to WIP", itemValue * -1, accName);
                            if (intId > 0)
                            {
                                //TODO: success
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
                    else if (globalCoaId == 349)
                    {
                        int coaId2 = accountsChartOfAccBll.GetCoaIdByGlobalCoaId(199);
                        string accName2 = accountsChartOfAccBll.GetAccountNameByGlobalCoaId(199);
                        if (coaId2 > 0 && !string.IsNullOrWhiteSpace(accName2))
                        {
                            intId = _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId, "Transfer to MRO", itemValue * -1, accName);
                            if (intId > 0)
                            {
                                if (UpdateJournalVoucherDetails())
                                {
                                    if (UpdateJournalVoucher())
                                    {
                                        //TODO: success
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
                        //TODO: unknown
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
            return 0;
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
