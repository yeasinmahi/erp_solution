
using System;
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class InventoryTdd
    {
        private readonly InventoryBll _bll = new InventoryBll();
        [TestCase("2019/05/15",3,0)]
        public void Bll_GetInventoryJvByDateType_int(DateTime transectionDate,int transectionTypeId, int expectedResult)
        {
            int result = _bll.GetInventoryJvByDateType(transectionDate,transectionTypeId);
            Assert.That(result==expectedResult);
        }
    }
}
