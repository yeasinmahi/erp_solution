using System;
using BLL.Accounts;
using NUnit.Framework;

namespace UnitTest.Accounts
{
    [TestFixture]
    public class CodeInfoTdd
    {
        private readonly CodeInfoBll _bll = new CodeInfoBll();
        [TestCase(3)]
        public void Bll_GetInventoryJvByDateType_DataTable(int unitId)
        {
            string result = _bll.GetJurnalVoucherCode(unitId);
            Assert.That(!string.IsNullOrWhiteSpace(result));
        }
    }
}
