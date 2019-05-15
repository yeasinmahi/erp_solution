using System.Data;
using BLL.Accounts;
using NUnit.Framework;

namespace UnitTest.Accounts
{
    public class AccountsVoucherJournalDetailsTdd
    {
        private readonly AccountsVoucherJournalDetailsBll _bll = new AccountsVoucherJournalDetailsBll();
        [TestCase(3436797)]
        public void Bll_GetJurnalVoucher_DataTable(int voucherId)
        {
            DataTable dt = _bll.GetJurnalVoucher(voucherId);
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase(3436797, 10000001, "TestVoucher", 0.1, "Test1Account")]
        [TestCase(3436797, 10000002, "TestVoucher", -0.1, "Test2Account")]
        public void Bll_Insert_int(int intJournalVoucherId, int intAccId, string strNarration, decimal amount, string strAccName)
        {
            int result = _bll.Insert(intJournalVoucherId, intAccId, strNarration, amount, strAccName);
            Assert.That(result > 0);
        }
        [TestCase(0.2, 3436797, 10000001)]
        [TestCase(-0.2, 3436797, 10000002)]
        public void Bll_UpdateAmount_bool(decimal amount, int jvId, int accId)
        {
            bool result = _bll.UpdateAmount(amount, jvId, accId);
            Assert.That(result);
        }
    }
}
