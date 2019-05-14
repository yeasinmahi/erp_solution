using System;
using System.Data;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalBll
    {
        private readonly AccountsVoucherJournalDal _dal = new AccountsVoucherJournalDal();
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
            return _dal.GetJurnalVoucher(voucherId,voucherDate);
        }
        public bool UpdateAmount(decimal amount, int enroll, int jvId)
        {
            return _dal.UpdateAmount(amount,enroll,jvId);
        }
    }
}
