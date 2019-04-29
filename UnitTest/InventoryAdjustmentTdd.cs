using System.Data;
using BLL.Inventory;
using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class InventoryAdjustmentTdd
    {
        private InventoryAdjustmentDal _dal = new InventoryAdjustmentDal();
        private InventoryAdjustmentBll _bll = new InventoryAdjustmentBll();
        [Test]
        public void Dal_GetAllInventoryAdjustments_DataTable()
        {
            DataTable dt = _dal.GetAllInventoryAdjustments();
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase(0, true)]
        [TestCase(2, true)]
        [TestCase(4, true)]
        public void Dal_GetInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _dal.GetInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result==expectedReselt);
        }
        [TestCase(2, false)]
        public void Dal_GetPendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _dal.GetPendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result==expectedReselt);
        }
        [TestCase(2, false)]
        public void Bll_GetPendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _bll.GetPendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result==expectedReselt);
        }
    }
}
