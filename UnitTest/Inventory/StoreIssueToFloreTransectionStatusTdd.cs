using System.Data;
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class StoreIssueToFloreTransectionStatusTdd
    {
        private readonly StoreIssueToFloreTransectionStatusBll _bll = new StoreIssueToFloreTransectionStatusBll();
        private DataTable _dt;

        [TestCase(0,0,0,0)]
        public void bll_insert_int(int itemId,int inventoryId, int whId, int unitId)
        {
            int result = _bll.Insert(itemId, inventoryId,whId,unitId);
            Assert.That(result>0);
        }
        [Test]
        public void bll_GetAll_DataTable()
        {
            _dt = _bll.GetAll();
            Assert.That(_dt.Rows.Count > 0);
        }
        [Test]
        public void bll_GetTodays_DataTable()
        {
            _dt = _bll.GetTodays();
            Assert.That(_dt.Rows.Count > 0);
        }
        [Test]
        public void bll_GetTodaysComplete_DataTable()
        {
            _dt = _bll.GetTodaysComplete();
            Assert.That(_dt.Rows.Count > 0);
        }
        [TestCase(true,1)]
        public void bll_UpdateIsProcessed_bool(bool isProcessed, int autoId)
        {
            bool result = _bll.UpdateIsProcessed(isProcessed, autoId);
            Assert.That(result);
        }
        [TestCase(1, 1)]
        public void bll_UpdateJv_bool(int jvId, int autoId)
        {
            bool result = _bll.UpdateJv(jvId, autoId);
            Assert.That(result);
        }
        [TestCase(1, 1)]
        public void bll_UpdateCoaId1_bool(int coaId1, int autoId)
        {
            bool result = _bll.UpdateCoaId1(coaId1, autoId);
            Assert.That(result);
        }
        [TestCase(2, 1)]
        public void bll_UpdateCoaId2_bool(int coaId2, int autoId)
        {
            bool result = _bll.UpdateCoaId2(coaId2, autoId);
            Assert.That(result);
        }
    }
}
