using System.Data;
using BLL.Accounts;
using NUnit.Framework;

namespace UnitTest.Accounts
{
    public class AccountsChartOfAccTdd
    {
        private readonly AccountsChartOfAccBll _bll = new AccountsChartOfAccBll();
        [TestCase(202423)]
        public void Bll_GetChartOfAccount_DataTable(int accId)
        {
            DataTable dt = _bll.GetChartOfAccount(accId);
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase(114)]
        public void Bll_GetChartOfAccountByGlobalCoaId_DataTable(int globalCoaId)
        {
            DataTable dt = _bll.GetChartOfAccountByGlobalCoaId(globalCoaId);
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase(202423, 114)]
        public void Bll_GetGlobalCoaId_DataTable(int accId,int expectedResult)
        {
            int result = _bll.GetGlobalCoaId(accId);
            Assert.That(result == expectedResult);
        }
        [TestCase(32, 191624)]
        [TestCase(199, 202366)]
        public void Bll_GetCoaIdByGlobalCoaId_DataTable(int globalCoaId, int expectedResult)
        {
            int result = _bll.GetCoaIdByGlobalCoaId(globalCoaId);
            Assert.That(result == expectedResult);
        }
        [TestCase(202423, "Texmate Engineering")]
        public void Bll_GetAccountName_DataTable(int accId, string expectedResult)
        {
            string result = _bll.GetAccountName(accId);
            Assert.That(result == expectedResult);
        }
        [TestCase(32, "Repairs & Maintenance ,Miscellaneous & Others exp ( Project-01 Uttra )")]
        [TestCase(199, "MRO Materials Expenses")]
        public void Bll_GetAccountNameByGlobalCoaId_DataTable(int globalCoaId, string expectedResult)
        {
            string result = _bll.GetAccountNameByGlobalCoaId(globalCoaId);
            Assert.That(result == expectedResult);
        }
    }
}
