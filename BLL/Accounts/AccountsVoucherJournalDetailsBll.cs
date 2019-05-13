using System.Data;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalDetailsBll
    {
        private readonly AccountsVoucherJournalDetailsDal _dal = new AccountsVoucherJournalDetailsDal();
        public int Insert(int intJournalVoucherId, int intAccId, string strNarration, decimal monAmount, string strAccName)
        {
            return _dal.Insert(intJournalVoucherId, intAccId, strNarration, monAmount, strAccName);
        }

        public DataTable GetJurnalVoucher(int voucherId)
        {
            return _dal.GetJurnalVoucherDetails(voucherId);
        }
    }
}
