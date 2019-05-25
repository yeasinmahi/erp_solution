using System;
using System.Collections.Generic;
using BLL.Inventory;
using Model;
using NUnit.Framework;

namespace UnitTest.Inventory
{
    [TestFixture]
    public class StoreIssueTdd
    {
        private readonly StoreIssueBll _bll = new StoreIssueBll();
        //[TestCase(13,294973,1,0.1,45671, 369116)]
        //public void StoreIssue(int whId,int itemId,decimal itemQuantity,decimal itemValue,int locationId,int enroll)
        //{
        //    bool result = _bll.StoreIssue(whId,itemId,itemQuantity,itemValue,locationId,enroll);
        //    Assert.That(result);
        //}

        [TestCase(842734, 606)]
        public void StoreIssue(int itemId,int whId)
        {
            StoreIssue storeIssue = new StoreIssue
            {
                Section = "test",
                WhId = whId,
                CostCenterId = 1,
                ReceiveBy = "arafat.corp",
                InsertBy = 369116,
                RequsitionId = 1,
                RequsitionCode = "rCode",
                DepartmentId = 1,
                RequsitionDate = "2019-05-23"
            };
            StoreIssueByItem strIssueByItem = new StoreIssueByItem
            {
                ItemId = itemId,
                IssueValue = (decimal) 0.1,
                IssueQuantity = (decimal).01,
                LocationId = 1,
                Remarks = "Unit Test",
                StockQuantity = 5
            };
            List<StoreIssueByItem> storeIssueByItems = new List<StoreIssueByItem>();
            storeIssueByItems.Add(strIssueByItem);
            int result = _bll.StoreIssue(storeIssue, storeIssueByItems);
            Assert.That(result>0);
        }

    }
}
