using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class PurchaseReturnTdd
    {
        private readonly  FactoryPurchaseReturnBll _bll = new FactoryPurchaseReturnBll();
        [TestCase(2,697607,280505,"Test",1,1,1,1,22044,"Test", 69210, "Test Supplier",369116)]
        public void Bll_PurchaseReturn_int(int intWhId, int intMrrId, int itemId, string itemName, decimal poQty, decimal numRcvQty, decimal returnQty, decimal returnValue, int locationId, string remarks, int supplierId, string supplierName, int intEnroll)
        {
            int purchaseReturnId = _bll.PurchaseReturn(intWhId, intMrrId, itemId, itemName, poQty, numRcvQty, returnQty,
                returnValue, locationId, remarks, supplierId, supplierName, intEnroll);
            Assert.That(purchaseReturnId>0);
        }
    }
}
