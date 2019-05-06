using System.Data;
using BLL.Inventory;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class PoTypeTdd
    {
        private readonly PoTypeBll _dal = new PoTypeBll();
        [Test]
        public void Bll_GetAllPoType_DataTable()
        {
            DataTable dt = _dal.GetAllPoType();
            Assert.That(dt.Rows.Count > 0);
        }
    }
}
