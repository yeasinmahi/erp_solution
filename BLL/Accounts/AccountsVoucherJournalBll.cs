using System;
using System.Data;
using BLL.Inventory;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalBll
    {
        private readonly AccountsVoucherJournalDal _dal = new AccountsVoucherJournalDal();
        private readonly AccountsVoucherJournalDetailsBll _accountsVoucherJournalDetailsBll = new AccountsVoucherJournalDetailsBll();
        private readonly StoreIssueToFloreTransectionStatusBll _storeIssueToFloreTransectionStatusBll = new StoreIssueToFloreTransectionStatusBll();
        private readonly InventoryBll _inventoryBll = new InventoryBll();
        private DataTable _dt;
        public int Insert(string strCode, int intUnitId, string strNarration, decimal amount, int intLastActionBy)
        {
            return _dal.Insert(strCode, intUnitId, strNarration, amount, intLastActionBy,null, null);
        }

        public DataTable GetJurnalVoucher(int voucherId)
        {
            return _dal.GetJurnalVoucher(voucherId);
        }
        public DataTable GetJurnalVoucher(int voucherId,DateTime voucherDate)
        {
            return _dal.GetJurnalVoucher(voucherId,voucherDate.ToString("yyyy/MM/dd"));
        }
        public bool UpdateAmount(decimal amount, int enroll, int jvId)
        {
            return _dal.UpdateAmount(amount,enroll,jvId);
        }
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

        public int InsertJournalVoucher(int whId, decimal amount, string narration ,int enroll)
        {
            if (GetUnitId(whId, out int unitId))
            {
                CodeInfoBll codeInfoBll = new CodeInfoBll();
                string voucherCode = codeInfoBll.GetJurnalVoucherCode(unitId);
                return Insert(voucherCode, unitId, narration, amount, enroll);

            }
            return 0;
        }
        public bool UpdateJournalVoucher(int jvId, decimal jvAmount, int enroll)
        {
            _dt = GetJurnalVoucher(jvId, DateTime.Now);
            if (_dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(_dt.Rows[0]["monAmountDr"].ToString());
                amount += jvAmount;
                if (UpdateAmount(amount, enroll, jvId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool InsertJournalVoucherWithVoucherDetails(int whId, decimal issueValue, int coaId, string storeIssueNarration, string meterialNarration,int inventoryStatusId, int inventoryId, int enroll)
        {
            int voucherId = InsertJournalVoucher(whId, issueValue, storeIssueNarration, enroll);
            if (voucherId > 0)
            {
                
                if (_inventoryBll.UpdateDailyJv(voucherId, inventoryId))
                {
                    _storeIssueToFloreTransectionStatusBll.UpdateJv(voucherId, inventoryStatusId);
                    if (_accountsVoucherJournalDetailsBll.InsertJournalVoucherDetails(voucherId, coaId, meterialNarration, issueValue, inventoryStatusId) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        //TODO: RollBack
                        return false;
                    }
                }
                return false;

            }
            else
            {
                //TODO: RollBack
                return false;
            }
        }

    }
}
