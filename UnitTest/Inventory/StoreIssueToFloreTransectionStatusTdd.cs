using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class StoreIssueToFloreTransectionStatusTdd
    {
        private readonly StoreIssueToFloreTransectionStatusBll _bll = new StoreIssueToFloreTransectionStatusBll();

        [TestCase(0,0)]
        public void bll_insert_int(int itemId,int inventoryId)
        {
            int result = _bll.Insert(itemId, inventoryId);
            Assert.That(result>0);
        }
    }
}
