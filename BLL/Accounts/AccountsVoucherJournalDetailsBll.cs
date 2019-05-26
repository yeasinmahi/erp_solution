using System;
using System.Data;
using BLL.Inventory;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalDetailsBll
    {
        private readonly AccountsVoucherJournalDetailsDal _dal = new AccountsVoucherJournalDetailsDal();
        private readonly AccountsChartOfAccBll _accountsChartOfAccBll = new AccountsChartOfAccBll();
        private readonly StoreIssueToFloreTransectionStatusBll _storeIssueToFloreTransectionStatusBll = new StoreIssueToFloreTransectionStatusBll();
        private DataTable _dt;
        public int Insert(int intJournalVoucherId, int intAccId, string strNarration, decimal monAmount, string strAccName)
        {
            return _dal.Insert(intJournalVoucherId, intAccId, strNarration, monAmount, strAccName);
        }

        public DataTable GetJurnalVoucherDetails(int voucherId)
        {
            return _dal.GetJurnalVoucherDetails(voucherId);
        }
        public DataTable GetJurnalVoucherDetails(int voucherId,int accId)
        {
            return _dal.GetJurnalVoucherDetails(voucherId,accId);
        }
        public bool UpdateAmount(decimal amount, int jvId, int accId)
        {
            return _dal.UpdateAmount(amount, jvId, accId);
        }
        public bool GetAltJvDetails(int globalCoaId, int coaId, out int coaId2, out string accName2, out string strNarration2)
        {
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
        public int InsertJournalVoucherDetails(int voucherId,int globalCoaId, int coaId, string narration, decimal issueValue, int inventoryStatusId)
        {
            string accName = _accountsChartOfAccBll.GetAccountName(coaId);
            if (!string.IsNullOrWhiteSpace(accName))
            {
                int intId = Insert(voucherId, coaId, narration, issueValue, accName);
                if (intId > 0)
                {
                    _storeIssueToFloreTransectionStatusBll.UpdateCoaId1(coaId, inventoryStatusId);
                    if (GetAltJvDetails(globalCoaId,coaId, out int coaId2, out string accName2,
                        out string strNarration))
                    {
                        intId = Insert(voucherId, coaId2, strNarration, issueValue * -1, accName2);
                        if (intId > 0)
                        {
                            _storeIssueToFloreTransectionStatusBll.UpdateCoaId2(coaId2, inventoryStatusId);
                            return intId;
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
            return 0;
        }
        public bool UpdateJournalVoucherDetails(int jvId, int accId, decimal jvAmount)
        {
            _dt = GetJurnalVoucherDetails(jvId, accId);
            if (_dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(_dt.Rows[0]["monAmount"].ToString());
                amount += jvAmount;
                if (UpdateAmount(amount, jvId, accId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

    }
}
