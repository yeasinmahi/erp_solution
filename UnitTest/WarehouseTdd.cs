using System.Data;
using BLL.Inventory;
using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class WarehouseTdd
    {
        private readonly WareHouseDal _dal = new WareHouseDal();
        private readonly WareHouseBll _bll = new WareHouseBll();
        public void Dal_GetAllWarehouse_DataTable()
        {
            DataTable dt = _dal.GetAllWarehouse();
            Assert.That(dt.Rows.Count>0);
        }
        [TestCase(369116)]
        [TestCase(373605)]
        public void Dal_GetAllWarehouseByEnroll_DataTable(int enroll)
        {
            DataTable dt = _dal.GetAllWarehouseByEnroll(enroll);
            Assert.That(dt.Rows.Count > 0);
        }
        [TestCase(369116)]
        [TestCase(373605)]
        public void Dal_GetIndentWarehouse_DataTable(int enroll)
        {
            DataTable dt = _dal.GetIndentWarehouse(enroll);
            Assert.That(dt.Rows.Count > 0);
        }
        //[TestCase(2)]
        //[TestCase(3)]
        //public void Dal_GetUnitIdByWhId_DataTable(int whid)
        //{
        //    DataTable dt = _dal.GetUnitIdByWhId(whid);
        //    Assert.That(dt.Rows.Count > 0);
        //}
        [TestCase(369116)]
        [TestCase(373605)]
        public void Bll_GetAllWarehouseByEnroll_DataTable(int enroll)
        {
            DataTable dt = _bll.GetAllWarehouseByEnroll(enroll);
            Assert.That(dt.Rows.Count > 0);
        }
        
    }
}
