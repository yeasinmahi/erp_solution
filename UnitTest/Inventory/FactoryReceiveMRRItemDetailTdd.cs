using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class FactoryReceiveMRRItemDetailTdd
    {
        private readonly FactoryReceiveMRRItemDetailDal _dal = new FactoryReceiveMRRItemDetailDal();

        [TestCase(1, 1, 1, 1, 1,1, 1, 1, 1, "test", 0, 0, "2019-06-16","2019-06-16","")]
        public void _dal_Insert_int(int intMrrid,int intItemId,decimal numPoQty, decimal numReceiveQty,decimal monFcRate, decimal monFcTotal, decimal monBdtTotal,
            int intLocationId, int intPoid, string strReceiveRemarks, decimal monVatAmount, decimal monAitAmount, string dteExpireDate, string dteMfGdate,
            string strBatchNo)
        {
            int result = _dal.Insert(intMrrid, intItemId, numPoQty, numReceiveQty, monFcRate, monFcTotal, monBdtTotal,
                intLocationId, intPoid, strReceiveRemarks, monVatAmount, monAitAmount, dteExpireDate, dteMfGdate,
                strBatchNo);
            Assert.That(result > 0);
        }
    }
}
