using System.Data;
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class SupplierTdd
    {
        private readonly SupplierBll _bll = new SupplierBll();
        private DataTable _dt = new DataTable();
        [TestCase(69385)]
        public void Bll_GetSupplier_DataTable(int supplierId)
        {
            _dt = _bll.GetSupplier(supplierId);
            Assert.That(_dt.Rows.Count>0);
        }
        [TestCase(69385, "BTO SINGAPORE PTE LTD")]
        public void Bll_GetSupplierName_string(int supplierId, string expectedResult)
        {
            string result = _bll.GetSupplierName(supplierId);
            Assert.That(result==expectedResult);
        }
        [TestCase(69385, "31 JURONG PORT ROAD, #06-04/05, JURONG LOGISTICS HUB, SINGAPORE 619115")]
        public void Bll_GetSupplierAddress_string(int supplierId, string expectedResult)
        {
            string result = _bll.GetSupplierAddress(supplierId);
            Assert.That(result == expectedResult);
        }
        [TestCase(69385, "sazed.billah@banglacat.com")]
        public void Bll_GetSupplierEmail_string(int supplierId, string expectedResult)
        {
            string result = _bll.GetSupplierEmail(supplierId);
            Assert.That(result == expectedResult);
        }
        [TestCase(69385, "+65 65152690")]
        public void Bll_GetSupplierPhone_string(int supplierId, string expectedResult)
        {
            string result = _bll.GetSupplierPhone(supplierId);
            Assert.That(result == expectedResult);
        }
        [TestCase(69385, 133634)]
        public void Bll_GetCoaId_int(int supplierId, int expectedResult)
        {
            int result = _bll.GetCoaId(supplierId);
            Assert.That(result == expectedResult);
        }
        
    }
}
