using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class WarehouseTdd
    {
        private readonly WareHouseBll _bll = new WareHouseBll();
        public void Get_GetAllWarehouse_DataTable(int enroll, bool result)
        {
            DataTable dt = _bll.GetAllWarehouse();
            Assert.That(dt.Rows.Count>0);
        }
        [TestCase(369116)]
        [TestCase(373605)]
        public void Get_GetAllWarehouseByEnroll_DataTable(int enroll)
        {
            DataTable dt = _bll.GetAllWarehouseByEnroll(enroll);
            Assert.That(dt.Rows.Count > 0);
        }
    }
}
