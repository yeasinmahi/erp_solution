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
        private readonly StoreIssueToFloreTransectionStatusBll _storeIssueToFloorTransectionStatusBll = new StoreIssueToFloreTransectionStatusBll();
        private readonly AccountsVoucherJournalBll _accountsVoucherJournalBll = new AccountsVoucherJournalBll();
        private readonly AccountsVoucherJournalDetailsBll _accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
        private readonly AccountsChartOfAccBll _accountsChartOfAccBll = new AccountsChartOfAccBll();
        private string storeIssueNarration = "Store Issue";
        private readonly string materialNarration = "Material Issue";

        private bool GetUnitId(int whId, out int unitId)
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
            int requisitionId = storeIssue.RequsitionId;
            int enroll = storeIssue.InsertBy;

            if (GetUnitId(whId, out int unitId))
            {
                int issueId = _dal.Insert(unitId, whId, requisitionId, storeIssue.RequsitionCode,
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
                                int inventoryStatusId = _storeIssueToFloorTransectionStatusBll.Insert(issueByItem.ItemId, inventoryId);
                                if (inventoryStatusId > 0)
                                {
                                    int coaId = _itemList.GetItemCoaId(itemId);
                                    if (coaId > 0)
                                    {
                                        int globalCoaId = _accountsChartOfAccBll.GetGlobalCoaId(coaId);
                                        if (globalCoaId < 1)
                                        {
                                            continue;
                                        }
                                        _dt = _storeIssueToFloorTransectionStatusBll.GetTodaysComplete();
                                        if (_dt.Rows.Count > 0)
                                        {
                                            int jvId = Convert.ToInt32(_dt.Rows[0]["jvId"].ToString());
                                            if (jvId > 0)
                                            {
                                                if (_inventoryBll.UpdateDailyJv(jvId, inventoryId))
                                                {
                                                    _storeIssueToFloorTransectionStatusBll.UpdateJv(jvId,
                                                        inventoryStatusId);
                                                    _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId,
                                                        DateTime.Now);
                                                    if (_dt.Rows.Count > 0)
                                                    {

                                                        _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucherDetails(
                                                            jvId, coaId);
                                                        if (_dt.Rows.Count > 0)
                                                        {
                                                            if (_accountsVoucherJournalDetailsBll
                                                                .UpdateJournalVoucherDetails(jvId, coaId, issueValue))
                                                            {
                                                                _storeIssueToFloorTransectionStatusBll.UpdateCoaId1(
                                                                    coaId,
                                                                    inventoryStatusId);

                                                                if (_accountsVoucherJournalDetailsBll.GetAltJvDetails(
                                                                    globalCoaId, coaId, out int coaId2, out string accName2,
                                                                    out string strNarration))
                                                                {
                                                                    _dt = _accountsVoucherJournalDetailsBll
                                                                        .GetJurnalVoucherDetails(jvId, coaId2);
                                                                    if (_dt.Rows.Count > 0)
                                                                    {
                                                                        if (_accountsVoucherJournalDetailsBll
                                                                            .UpdateJournalVoucherDetails(jvId, coaId2,
                                                                                issueValue * -1))
                                                                        {
                                                                            _storeIssueToFloorTransectionStatusBll
                                                                                .UpdateCoaId2(coaId2,
                                                                                    inventoryStatusId);
                                                                            if (_accountsVoucherJournalBll
                                                                                .UpdateJournalVoucher(jvId, issueValue,
                                                                                    enroll))
                                                                            {
                                                                                _storeIssueToFloorTransectionStatusBll
                                                                                    .UpdateIsProcessed(true,
                                                                                        inventoryStatusId);
                                                                                // TODO: success
                                                                                return issueId;
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
                                                                        if (_accountsVoucherJournalDetailsBll.Insert(
                                                                                jvId, coaId2, strNarration,
                                                                                issueValue * -1, accName2) > 0)
                                                                        {
                                                                            _storeIssueToFloorTransectionStatusBll
                                                                                .UpdateCoaId1(coaId2,
                                                                                    inventoryStatusId);
                                                                            if (_accountsVoucherJournalBll
                                                                                .UpdateJournalVoucher(jvId, issueValue,
                                                                                    enroll))
                                                                            {
                                                                                // TODO: success
                                                                                _storeIssueToFloorTransectionStatusBll
                                                                                    .UpdateIsProcessed(true,
                                                                                        inventoryStatusId);
                                                                                return issueId;
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
                                                            int intId = _accountsVoucherJournalDetailsBll
                                                                .InsertJournalVoucherDetails(jvId, globalCoaId, coaId,
                                                                    materialNarration, issueValue, inventoryStatusId);
                                                            if (intId > 0)
                                                            {
                                                                if (_accountsVoucherJournalBll.UpdateJournalVoucher(
                                                                    jvId, issueValue, enroll))
                                                                {
                                                                    // TODO: success
                                                                    _storeIssueToFloorTransectionStatusBll
                                                                        .UpdateIsProcessed(true, inventoryStatusId);
                                                                    return issueId;
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
                                                        if (InsertJournalVoucherWithVoucherDetails(whId, issueValue, globalCoaId,
                                                            coaId,
                                                            storeIssueNarration, materialNarration, inventoryStatusId, inventoryId,
                                                            enroll))
                                                        {
                                                            return issueId;
                                                        }

                                                    }
                                                }
                                                else
                                                {
                                                    // TODO: RollBack
                                                }

                                            }
                                            else
                                            {
                                                if (InsertJournalVoucherWithVoucherDetails(whId, issueValue, globalCoaId, coaId,
                                                    storeIssueNarration, materialNarration, inventoryStatusId, inventoryId,
                                                    enroll))
                                                {
                                                    return issueId;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (InsertJournalVoucherWithVoucherDetails(whId, issueValue, globalCoaId, coaId,
                                                storeIssueNarration, materialNarration, inventoryStatusId, inventoryId,
                                                enroll))
                                            {
                                                return issueId;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        InconsistanceItemBll inconsistanceItemBll = new InconsistanceItemBll();
                                        if (inconsistanceItemBll.Insert(whId, itemId, issueQuantity, issueValue, locationId, enroll) > 0)
                                        {
                                            //TODO: success insert inconsistence
                                            return issueId;
                                        }
                                        else
                                        {
                                            //TODO: fails insert inconsistence
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

        private bool InsertJournalVoucherWithVoucherDetails(int whId, decimal issueValue, int globalCoaId, int coaId,
            string storeIssueNarration, string meterialNarration, int inventoryStatusId, int intventoryId, int enroll)
        {

            if (_accountsVoucherJournalBll.InsertJournalVoucherWithVoucherDetails(whId, issueValue, globalCoaId, coaId,
                storeIssueNarration, meterialNarration, inventoryStatusId, intventoryId, enroll))
            {
                //TODO: successs
                _storeIssueToFloorTransectionStatusBll.UpdateIsProcessed(true, inventoryStatusId);
                return true;
            }
            else
            {
                //TODO: RollBack
                return false;
            }
        }

    }
}
