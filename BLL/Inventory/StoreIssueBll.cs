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
        private string storeIssueNarration = "Store Issue";
        private string meterialNarration = "Meterial Issue";
        //public bool StoreIssue(int whId, int itemId, decimal itemQuantity, decimal issueValue, int locationId, int enroll)
        //{
        //    int jvId = _inventoryBll.GetInventoryJvByDateType(DateTime.Now, 3);
            
        //    int coaId = _itemList.GetItemCoaId(itemId);
        //    if (coaId > 0)
        //    {
        //        if (jvId > 0)
        //        {
        //            _dt = _accountsVoucherJournalBll.GetJurnalVoucher(jvId, DateTime.Now);
        //            if (_dt.Rows.Count > 0)
        //            {
        //                _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucherDetails(jvId, coaId);
        //                if (_dt.Rows.Count > 0)
        //                {
        //                    if (_accountsVoucherJournalDetailsBll.UpdateJournalVoucherDetails(jvId, coaId, issueValue))
        //                    {
        //                        if (_accountsVoucherJournalDetailsBll.GetAltJvDetails(coaId, out int coaId2, out string accName2,
        //                            out string strNarration))
        //                        {
        //                            _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucherDetails(jvId, coaId2);
        //                            if (_dt.Rows.Count > 0)
        //                            {
        //                                if (_accountsVoucherJournalDetailsBll.UpdateJournalVoucherDetails(jvId, coaId2, issueValue * -1))
        //                                {
        //                                    if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
        //                                    {
        //                                        return true;
        //                                    }
        //                                    else
        //                                    {
        //                                        // TODO: RollBack
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    // TODO: RollBack
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (_accountsVoucherJournalDetailsBll.Insert(jvId, coaId2, strNarration,
        //                                        issueValue * -1, accName2) > 0)
        //                                {
        //                                    if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
        //                                    {
        //                                        return true;
        //                                    }
        //                                    else
        //                                    {
        //                                        // TODO: RollBack
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    // TODO: RollBack
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //TODO: RollBack
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // TODO: RollBack
        //                    }
        //                }
        //                else
        //                {
        //                    int intId = _accountsVoucherJournalDetailsBll.InsertJournalVoucherDetails(jvId, coaId, meterialNarration, issueValue, 0);
        //                    if (intId > 0)
        //                    {
        //                        if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
        //                        {
        //                            return true;
        //                        }
        //                        else
        //                        {
        //                            // TODO: RollBack
        //                        }
        //                    }
        //                    else
        //                    {
        //                        // TODO: RollBack
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (_accountsVoucherJournalBll.InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId,
        //                    storeIssueNarration, meterialNarration, enroll,0))
        //                {
        //                    //TODO: Success
        //                }
        //                else
        //                {
        //                    //TODO: RollBack
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (_accountsVoucherJournalBll.InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId,
        //                storeIssueNarration, meterialNarration, enroll,0))
        //            {
        //                //TODO: Success
        //            }
        //            else
        //            {
        //                //TODO: RollBack
        //            }

        //        }
        //    }
        //    else
        //    {
        //        InconsistanceItemBll inconsistanceItemBll = new InconsistanceItemBll();
        //        if (inconsistanceItemBll.Insert(whId, itemId, itemQuantity, issueValue, locationId, enroll) > 0)
        //        {
        //            //TODO: success insert
        //        }
        //        else
        //        {
        //            //TODO: fails insert
        //        }
        //    }

        //    return false;
        //}
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
                                                    _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucherDetails(jvId, coaId);
                                                    if (_dt.Rows.Count > 0)
                                                    {
                                                        if (_accountsVoucherJournalDetailsBll.UpdateJournalVoucherDetails(jvId, coaId, issueValue))
                                                        {
                                                            _storeIssueToFloreTransectionStatusBll.UpdateCoaId1(coaId,
                                                                inventoryStatusId);
                                                            if (_accountsVoucherJournalDetailsBll.GetAltJvDetails(coaId, out int coaId2, out string accName2,
                                                                out string strNarration))
                                                            {
                                                                _dt = _accountsVoucherJournalDetailsBll.GetJurnalVoucherDetails(jvId, coaId2);
                                                                if (_dt.Rows.Count > 0)
                                                                {
                                                                    if (_accountsVoucherJournalDetailsBll.UpdateJournalVoucherDetails(jvId, coaId2, issueValue * -1))
                                                                    {
                                                                        _storeIssueToFloreTransectionStatusBll.UpdateCoaId1(coaId2,
                                                                            inventoryStatusId);
                                                                        if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
                                                                        {
                                                                            _storeIssueToFloreTransectionStatusBll.UpdateIsProcessed(true,inventoryStatusId);
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
                                                                        _storeIssueToFloreTransectionStatusBll.UpdateCoaId1(coaId2,
                                                                            inventoryStatusId);
                                                                        if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
                                                                        {
                                                                            // TODO: succes
                                                                            _storeIssueToFloreTransectionStatusBll
                                                                                .UpdateIsProcessed(true,
                                                                                    inventoryStatusId);
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
                                                        int intId = _accountsVoucherJournalDetailsBll.InsertJournalVoucherDetails(jvId, coaId, meterialNarration, issueValue,inventoryStatusId);
                                                        if (intId > 0)
                                                        {
                                                            if (_accountsVoucherJournalBll.UpdateJournalVoucher(jvId, issueValue, enroll))
                                                            {
                                                                // TODO: succes
                                                                _storeIssueToFloreTransectionStatusBll.UpdateIsProcessed(true,inventoryStatusId);
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
                                                    InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId, storeIssueNarration, meterialNarration, inventoryStatusId, enroll);
                                                }
                                            }
                                            else
                                            {
                                                InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId, storeIssueNarration, meterialNarration, inventoryStatusId, enroll);

                                            }
                                        }
                                        else
                                        {
                                            InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId, storeIssueNarration, meterialNarration, inventoryStatusId, enroll);
                                            
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

        private bool InsertJournalVoucherWithVoucherDetails(int whId, decimal issueValue, int coaId,
            string storeIssueNarration, string meterialNarration, int inventoryStatusId, int enroll)
        {
            if (_accountsVoucherJournalBll.InsertJournalVoucherWithVoucherDetails(whId, issueValue, coaId,
                storeIssueNarration, meterialNarration, enroll, inventoryStatusId))
            {
                //TODO: Success
                _storeIssueToFloreTransectionStatusBll.UpdateIsProcessed(true,inventoryStatusId);
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
