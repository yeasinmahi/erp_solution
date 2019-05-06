using System.Data;
using BLL.Inventory;
using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class InventoryAdjustmentTdd
    {
        private readonly InventoryAdjustmentDal _dal = new InventoryAdjustmentDal();
        private readonly InventoryAdjustmentBll _bll = new InventoryAdjustmentBll();
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
        public void Dal_GetLabel1PendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _dal.GetLabel1PendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result==expectedReselt);
        }
        [TestCase(2, false)]
        public void Dal_GetLabel2PendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _dal.GetLabel2PendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result == expectedReselt);
        }
        [TestCase(2, false)]
        public void Bll_GetLabel1PendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _bll.GetLabel1PendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result==expectedReselt);
        }
        [TestCase(2, false)]
        public void Bll_GetLabel2PendingInventoryAdjustmentByWh_DataTable(int whId, bool expectedReselt)
        {
            DataTable dt = _bll.GetLabel2PendingInventoryAdjustmentByWh(whId);
            bool result = dt.Rows.Count > 0;
            Assert.That(result == expectedReselt);
        }
    }
}
