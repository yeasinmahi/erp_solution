using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class InconsistanceItemTdd
    {
        private readonly InconsistanceItemBll _inconsistanceItemBll = new InconsistanceItemBll();
        [TestCase(13, 294973, 1, 0.1, 45671, 369116)]
        public void Bll_inconsistanceItemBll_int(int whId,int itemId,decimal itemQuantity,decimal itemValue,int locationId,int enroll)
        {
            int result = _inconsistanceItemBll.Insert(whId, itemId, itemQuantity, itemValue, locationId, enroll);
            Assert.That(result>0);
        }
    }
}
