using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.AFBLSMSServer;
using BLL.Inventory;
using DALOOP.Inventory;
using NUnit.Framework;

namespace UnitTest.AFBLSMSServer
{
    [TestFixture]
    public class ApiSmsTdd
    {
        private readonly ApiSmsBll _bll = new ApiSmsBll();
        [Test]
        public void Dal_GetAllInventoryAdjustments_DataTable()
        {
            bool result = _bll.InsertApiSms(23, "Challan", "ATML", "01676272718", 0);
            Assert.That(result);
        }
    }
}
