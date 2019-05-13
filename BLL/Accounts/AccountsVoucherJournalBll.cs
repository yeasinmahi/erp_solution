using System;
using System.Data;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalBll
    {
        private readonly AccountsVoucherJournalDal _dal = new AccountsVoucherJournalDal();
        public int Insert(string strCode, int intUnitId, string strNarration, decimal amount, int intLastActionBy,
            string strSecurityCode, DateTime dtePostingSubledger)
        {
            return _dal.Insert(strCode, intUnitId, strNarration, amount, intLastActionBy,
                null, null);
        }

        public DataTable GetJurnalVoucher(int voucherId)
        {
            return _dal.GetJurnalVoucher(voucherId);
        }
    }
}
