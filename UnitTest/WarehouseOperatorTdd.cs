
using System.Data;
using BLL.Inventory;
using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest
{

    [TestFixture]
    public class WarehouseOperatorTdd
    {
        private readonly WarehouseOperatorDal _bll = new WarehouseOperatorDal();
        [TestCase(369116)]
        [TestCase(373605)]
        public void Dal_GetWarehouseByEnroll_DataTable(int enroll)
        {
            DataTable dt = _bll.GetWarehouseByEnroll(enroll);
            Assert.That(dt.Rows.Count>0);
        }
        [TestCase(369116,true)]
        [TestCase(373605,true)]
        public void Dal_IsSuperUser_Bool(int enroll,bool result)
        {
            bool isSupperuser = _bll.IsSuperUser(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Dal_IsAllPoAccess_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Dal_IsStoreUser_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }
        [TestCase(369116, true)]
        [TestCase(373605, false)]
        public void Dal_IsIndentUser_Bool(int enroll, bool result)
        {
            bool isSupperuser = _bll.IsAllPoAccess(enroll);
            Assert.AreEqual(isSupperuser, result);
        }

    }
}
