using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class StoreIssueTdd
    {
        private readonly StoreIssueBll _bll = new StoreIssueBll();
        [TestCase(13,294973,1,0.1,45671, 369116)]
        public void StoreIssue(int whId,int itemId,decimal itemQuantity,decimal itemValue,int locationId,int enroll)
        {
          //  bool result = _bll.StoreIssue(whId,itemId,itemQuantity,itemValue,locationId,enroll);
           // Assert.That(result);
        }
    }
}
