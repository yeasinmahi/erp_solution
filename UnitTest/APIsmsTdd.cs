using BLL.AFBLSMSServer;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class APIsmsTdd
    {
        private readonly ApiSmsBll _bll = new ApiSmsBll();
        [TestCase(10,"test","Textile","01676272718",2)]
        public void Bll_InsertApiSms_bool(int poId, string chalanNo, string unitName, string customerPhnNumber, int unitId)
        {
            bool result = _bll.InsertApiSms(poId, chalanNo, unitName, customerPhnNumber, unitId);
            Assert.That(result);
        }
    }
}
