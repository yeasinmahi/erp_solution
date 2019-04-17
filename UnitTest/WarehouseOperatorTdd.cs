
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest
{

    [TestFixture]
    public class WarehouseOperatorTdd
    {
        private readonly WarehouseOperatorBll _bll = new WarehouseOperatorBll();
        [TestCase(369116,true)]
        [TestCase(373605,true)]
        public void Get_IsSuperUser_Bool(int enroll,bool result)
        {
            bool isSupperuser = _bll.IsSuperUser(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Get_IsAllPoAccess_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Get_IsStoreUser_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Get_IsIndentUser_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }

    }
}
