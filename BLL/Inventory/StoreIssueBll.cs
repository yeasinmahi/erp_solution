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
        private readonly AccountsChartOfAccBll _accountsChartOfAccBll = new AccountsChartOfAccBll();
        public bool StoreIssue(int whId, int itemId, decimal itemQuantity, decimal itemValue, int locationId, int enroll)
        {
            InventoryBll inventoryBll = new InventoryBll();
            int jvId = inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            ItemListBll itemList = new ItemListBll();
            int coaId = itemList.GetItemCoaId(itemId);
            if (jvId > 0)
            {
                if (coaId > 0)
                {
                    _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
                    if (_dt.Rows.Count > 0)
                    {
                        _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId);
                        if (_dt.Rows.Count > 0)
                        {
                            if (UpdateJournalVoucherDetails(jvId, coaId, itemValue))
                            {
                                int globalCoaId = _accountsChartOfAccBll.GetGlobalCoaId(coaId);

                                if (globalCoaId >0)
                                {
                                    int coaId2 = 0;
                                    string accName2 = String.Empty;
                                    string strNarration = String.Empty;
                                    if (globalCoaId == 31)
                                    {
                                        coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(32);
                                        accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(32);
                                        strNarration = "Transfer To WIP";
                                    }
                                    else if(globalCoaId == 349)
                                    {
                                        coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(199);
                                        accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(199);
                                        strNarration = "Transfer To MRO";
                                    }
                                    if (coaId2 > 0)
                                    {
                                        _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId2);
                                        if (_dt.Rows.Count > 0)
                                        {
                                            if (UpdateJournalVoucherDetails(jvId, coaId2, itemValue * -1))
                                            {
                                                if (UpdateJournalVoucher(jvId, itemValue, enroll))
                                                {
                                                    return true;
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
                                            if (_accountsVoucherJournalDetailsBll.Insert(jvId, coaId2, strNarration,
                                                    itemValue * -1, accName2) > 0)
                                            {
                                                if (UpdateJournalVoucher(jvId, itemValue, enroll))
                                                {
                                                    return true;
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
                                // TODO: RollBack
                            }
                        }
                        else
                        {
                            int intId = InsertJournalVoucherDetails(jvId, coaId, itemValue,enroll);
                            if (intId > 0)
                            {
                                if (UpdateJournalVoucher(jvId, itemValue, enroll))
                                {
                                    return true;
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
                        int voucherId = InsertJournalVoucher(whId, itemValue, enroll);
                        if (voucherId > 0)
                        {
                            if (InsertJournalVoucherDetails(voucherId, coaId, itemValue, enroll) > 0)
                            {
                                return true;
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
                int voucherId = InsertJournalVoucher(whId, itemValue, enroll);
                if (voucherId > 0)
                {
                    if (InsertJournalVoucherDetails(voucherId, coaId, itemValue, enroll)>0)
                    {
                        return true;
                    }

                }
                else
                {
                    //TODO: RollBack
                }

            }

            return false;
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

        private int InsertJournalVoucherDetails(int voucherId, int coaId, decimal itemValue,int enroll)
        {
            string accName = _accountsChartOfAccBll.GetAccountName(coaId);
            if (!string.IsNullOrWhiteSpace(accName))
            {
                int intId = _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId, "Meterial Issue", itemValue, accName);
                if (intId > 0)
                {
                    int globalCoaId = _accountsChartOfAccBll.GetGlobalCoaId(coaId);

                    if (globalCoaId == 31)
                    {
                        int coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(32);
                        string accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(32);
                        if (coaId2 > 0 && !string.IsNullOrWhiteSpace(accName2))
                        {
                            return _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId2, "Transfer to WIP", itemValue * -1, accName2);
                            
                        }
                        else
                        {
                            //TODO: RollBack
                        }
                        
                    }
                    else if (globalCoaId == 349)
                    {
                        int coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(199);
                        string accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(199);
                        if (coaId2 > 0 && !string.IsNullOrWhiteSpace(accName2))
                        {
                            return _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId2, "Transfer to MRO", itemValue * -1, accName2);
                            
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
        private bool UpdateJournalVoucher(int jvId, decimal jvAmount, int enroll)
        {
            _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId,DateTime.Now);
            if (_dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(_dt.Rows[0]["monAmountDr"].ToString());
                amount += jvAmount;
                if (_accountsVoucherJournalBll.UpdateAmount(amount, enroll, jvId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool UpdateJournalVoucherDetails(int jvId, int accId, decimal jvAmount)
        {
            _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId,accId);
            if (_dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(_dt.Rows[0]["monAmount"].ToString());
                amount += jvAmount;
                if (_accountsVoucherJournalDetailsBll.UpdateAmount(amount, jvId,accId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }


    }
}
