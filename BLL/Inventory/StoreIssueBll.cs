using System;
using System.Collections.Generic;
using System.Data;
using BLL.Accounts;
using DALOOP.Inventory;
using Model;

namespace BLL.Inventory
{
    public class StoreIssueBll
    {
        private DataTable _dt;
        private readonly StoreIssueDal _dal = new StoreIssueDal();
        private readonly StoreIssueByItemDal _issueByItemDal = new StoreIssueByItemDal();
        private readonly InventoryBll _inventoryBll = new InventoryBll();
        private readonly ItemListBll _itemList = new ItemListBll();
        private readonly StoreIssueToFloreTransectionStatusBll _storeIssueToFloreTransectionStatusBll = new StoreIssueToFloreTransectionStatusBll();
        private readonly AccountsVoucherJournalBll _accountsVoucherJournalBll = new AccountsVoucherJournalBll();
        private readonly AccountsVoucherJournalDetailsBll _accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
        private readonly AccountsChartOfAccBll _accountsChartOfAccBll = new AccountsChartOfAccBll();
        public bool StoreIssue(int whId, int itemId, decimal itemQuantity, decimal issueValue, int locationId, int enroll)
        {
            int jvId = _inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            
            int coaId = _itemList.GetItemCoaId(itemId);
            if (coaId > 0)
            {
                if (jvId > 0)
                {
                    _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
                    if (_dt.Rows.Count > 0)
                    {
                        _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId);
                        if (_dt.Rows.Count > 0)
                        {
                            if (UpdateJournalVoucherDetails(jvId, coaId, issueValue))
                            {
                                if (GetAltJvDetails(coaId, out int coaId2, out string accName2,
                                    out string strNarration))
                                {
                                    _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId2);
                                    if (_dt.Rows.Count > 0)
                                    {
                                        if (UpdateJournalVoucherDetails(jvId, coaId2, issueValue * -1))
                                        {
                                            if (UpdateJournalVoucher(jvId, issueValue, enroll))
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
                                                issueValue * -1, accName2) > 0)
                                        {
                                            if (UpdateJournalVoucher(jvId, issueValue, enroll))
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
                                // TODO: RollBack
                            }
                        }
                        else
                        {
                            int intId = InsertJournalVoucherDetails(jvId, coaId, issueValue);
                            if (intId > 0)
                            {
                                if (UpdateJournalVoucher(jvId, issueValue, enroll))
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
                        int voucherId = InsertJournalVoucher(whId, issueValue, enroll);
                        if (voucherId > 0)
                        {
                            if (InsertJournalVoucherDetails(voucherId, coaId, issueValue) > 0)
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
                    int voucherId = InsertJournalVoucher(whId, issueValue, enroll);
                    if (voucherId > 0)
                    {
                        if (InsertJournalVoucherDetails(voucherId, coaId, issueValue) > 0)
                        {
                            return true;
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
                if (inconsistanceItemBll.Insert(whId, itemId, itemQuantity, issueValue, locationId, enroll) > 0)
                {
                    //TODO: success insert
                }
                else
                {
                    //TODO: fails insert
                }
            }

            return false;
        }

        private bool GetAltJvDetails(int coaId, out int coaId2, out string accName2, out string strNarration2)
        {
            int globalCoaId = _accountsChartOfAccBll.GetGlobalCoaId(coaId);
            coaId2 = 0;
            accName2 = String.Empty;
            strNarration2 = String.Empty;
            if (globalCoaId > 0)
            {
                if (globalCoaId == 31)
                {
                    coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(32);
                    accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(32);
                    strNarration2 = "Transfer To WIP";
                }
                else if (globalCoaId == 349)
                {
                    coaId2 = _accountsChartOfAccBll.GetCoaIdByGlobalCoaId(199);
                    accName2 = _accountsChartOfAccBll.GetAccountNameByGlobalCoaId(199);
                    strNarration2 = "Transfer To MRO";
                }
                else
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private int InsertJournalVoucher(int whId, decimal amount, int enroll)
        {
            if (GetUnitId(whId,out int unitId))
            {
                CodeInfoBll codeInfoBll = new CodeInfoBll();
                string voucherCode = codeInfoBll.GetJurnalVoucherCode(unitId);
                return _accountsVoucherJournalBll.Insert(voucherCode, unitId, "Store Issue", amount, enroll);

            }
            return 0;
        }

        private int InsertJournalVoucherDetails(int voucherId, int coaId, decimal issueValue)
        {
            string accName = _accountsChartOfAccBll.GetAccountName(coaId);
            if (!string.IsNullOrWhiteSpace(accName))
            {
                int intId = _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId, "Meterial Issue", issueValue, accName);
                if (intId > 0)
                {
                    if (GetAltJvDetails(coaId, out int coaId2, out string accName2,
                        out string strNarration))
                    {
                        return _accountsVoucherJournalDetailsBll.Insert(voucherId, coaId2, strNarration, issueValue * -1, accName2);
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
            return 0;
        }
        private bool UpdateJournalVoucher(int jvId, decimal jvAmount, int enroll)
        {
            _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
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
            _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, accId);
            if (_dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(_dt.Rows[0]["monAmount"].ToString());
                amount += jvAmount;
                if (_accountsVoucherJournalDetailsBll.UpdateAmount(amount, jvId, accId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool GetUnitId(int whId,out int unitId)
        {
            WareHouseBll wareHouseBll = new WareHouseBll();
            unitId = wareHouseBll.GetUnitIdByWhId(whId);
            if (unitId > 0)
            {
                return true;
            }
            return false;
        }
        public int StoreIssue(StoreIssue storeIssue, List<StoreIssueByItem> storeIssueByItems)
        {
            int whId = storeIssue.WhId;
            int requsitionId = storeIssue.RequsitionId;
            int enroll = storeIssue.InsertBy;
            
            if (GetUnitId(whId, out int unitId))
            {
                int issueId = _dal.Insert(unitId, whId, requsitionId, storeIssue.RequsitionCode,
                    storeIssue.RequsitionDate, storeIssue.ReceiveBy, storeIssue.InsertBy, storeIssue.CostCenterId);
                if (issueId > 0)
                {
                    foreach (StoreIssueByItem issueByItem in storeIssueByItems)
                    {
                        int itemId = issueByItem.ItemId;
                        decimal issueQuantity = issueByItem.IssueQuantity;
                        decimal issueValue = issueByItem.IssueValue;
                        int locationId = issueByItem.LocationId;
                        

                        int issueItemByItemId = _issueByItemDal.Insert(issueId, issueByItem.ItemId, unitId,
                            whId, storeIssue.DepartmentId, 0, storeIssue.ReceiveBy, issueByItem.LocationId,
                            issueByItem.IssueQuantity, issueByItem.IssueValue, storeIssue.Section,
                            storeIssue.CostCenterId, issueByItem.Remarks);
                        if (issueItemByItemId > 0)
                        {
                            int inventoryId = _inventoryBll.InsertBySpInventoryTransection(unitId, whId, issueByItem.LocationId,
                                issueByItem.ItemId, issueByItem.IssueQuantity * -1, issueByItem.IssueValue * -1,
                                issueId, 3);
                            if (inventoryId > 0)
                            {
                                int inventoryStatusId = _storeIssueToFloreTransectionStatusBll.Insert(issueByItem.ItemId, inventoryId);
                                if (inventoryStatusId > 0)
                                {
                                    int coaId = _itemList.GetItemCoaId(itemId);
                                    if (coaId > 0)
                                    {
                                        _dt = _storeIssueToFloreTransectionStatusBll.GetTodaysComplete();
                                        if (_dt.Rows.Count > 0)
                                        {
                                            int jvId = Convert.ToInt32(_dt.Rows[0]["jvId"].ToString());
                                            if (jvId > 0)
                                            {
                                                _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
                                                if (_dt.Rows.Count > 0)
                                                {
                                                    _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId);
                                                    if (_dt.Rows.Count > 0)
                                                    {
                                                        if (UpdateJournalVoucherDetails(jvId, coaId, issueValue))
                                                        {
                                                            if (GetAltJvDetails(coaId, out int coaId2, out string accName2,
                                                                out string strNarration))
                                                            {
                                                                _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucher(jvId, coaId2);
                                                                if (_dt.Rows.Count > 0)
                                                                {
                                                                    if (UpdateJournalVoucherDetails(jvId, coaId2, issueValue * -1))
                                                                    {
                                                                        if (UpdateJournalVoucher(jvId, issueValue, enroll))
                                                                        {
                                                                            // TODO: succes
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
                                                                            issueValue * -1, accName2) > 0)
                                                                    {
                                                                        if (UpdateJournalVoucher(jvId, issueValue, enroll))
                                                                        {
                                                                            // TODO: succes
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
                                                            // TODO: RollBack
                                                        }
                                                    }
                                                    else
                                                    {
                                                        int intId = InsertJournalVoucherDetails(jvId, coaId, issueValue);
                                                        if (intId > 0)
                                                        {
                                                            if (UpdateJournalVoucher(jvId, issueValue, enroll))
                                                            {
                                                                // TODO: succes
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
                                                    int voucherId = InsertJournalVoucher(whId, issueValue, enroll);
                                                    if (voucherId > 0)
                                                    {
                                                        if (InsertJournalVoucherDetails(voucherId, coaId, issueValue) > 0)
                                                        {
                                                            // TODO: succes
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
                                                int voucherId = InsertJournalVoucher(whId, issueValue, enroll);
                                                if (voucherId > 0)
                                                {
                                                    if (InsertJournalVoucherDetails(voucherId, coaId, issueValue) > 0)
                                                    {
                                                        // TODO: succes
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
                                            int voucherId = InsertJournalVoucher(whId, issueValue, enroll);
                                            if (voucherId > 0)
                                            {
                                                if (InsertJournalVoucherDetails(voucherId, coaId, issueValue) > 0)
                                                {
                                                    //TODO: success
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
                                        if (inconsistanceItemBll.Insert(whId, itemId, issueQuantity, issueValue, locationId, enroll) > 0)
                                        {
                                            //TODO: success insert inconsistance
                                        }
                                        else
                                        {
                                            //TODO: fails insert inconsistance
                                        }
                                    }
                                }
                                else
                                {
                                    // TODO: Inventory Status insert Failed;
                                }


                            }
                            else
                            {
                                // TODO: Inventory insert Failed;
                            }
                        }
                        else
                        {
                            // TODO: Issue by item insert Failed;
                        }
                    }
                    
                }
                else
                {
                    // TODO: Issue insert Failed;
                }
            }
            else
            {
                // TODO: Issue Failed;
            }

            return 0;
        }

    }
}
