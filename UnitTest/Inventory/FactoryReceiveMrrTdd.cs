using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class FactoryReceiveMrrTdd
    {
        private readonly FactoryReceiveMrrDal _dal = new FactoryReceiveMrrDal();

        [TestCase(1,1,1,369116,1,"test","2019-06-16",1,"0",0,0,false,1)]
        public void _dal_Insert_int(int poId, int supplierId, int shipmentSl, int lastActionBy, int unitId,
            string externalRef, string challanDate, int whId, string vatChallan, int totalVat, int totalAit,
            bool isInventoryInserted, int shipmentId)
        {
            int result = _dal.Insert(poId, supplierId, shipmentSl, lastActionBy, unitId,
                externalRef, challanDate, whId, vatChallan, totalVat, totalAit,
                isInventoryInserted, shipmentId);
            Assert.That(result > 0);
        }
    }
}
