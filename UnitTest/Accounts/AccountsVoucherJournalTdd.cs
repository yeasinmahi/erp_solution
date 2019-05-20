using System.Data;
using BLL.Accounts;
using NUnit.Framework;

namespace UnitTest.Accounts
{
    [TestFixture]
    public class AccountsVoucherJournalTdd
    {
        private readonly AccountsVoucherJournalBll _bll = new AccountsVoucherJournalBll();
        [TestCase(3436797)]
        public void Bll_GetJurnalVoucher_DataTable(int voucherId)
        {
            DataTable dt = _bll.GetJurnalVoucher(voucherId);
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase("TestCode",0,"TestVoucher",0.1,369116)]
        public void Bll_Insert_int(string strCode,int intUnitId, string strNarration,decimal amount,int intLastActionBy)
        {
            int result = _bll.Insert(strCode,intUnitId,strNarration,amount,intLastActionBy);
            Assert.That(result > 0);
        }
        [TestCase(0.2, 369116, 3436797)]
        public void Bll_UpdateAmount_bool(decimal amount, int enroll, int jvId)
        {
            bool result = _bll.UpdateAmount(amount,enroll,jvId);
            Assert.That(result);
        }
    }
}
