using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SalesOrderViewTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class SalesOrderView
    {
        public SalesOrderViewTDS.SprSalesOrderByCustomerDataTable GetSalesOrder(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            if (fromDate == null)
            {
                fromDate = DateTime.Now.AddDays(-7);
            }

            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(7);
            }

            if ("" + customerType == "") return null;
            return adp.GetData(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }
        
        public void CancelSO(string soId, string userId)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();
            adp.CancelSO(int.Parse(userId), long.Parse(soId));
        }
        
        public void CompleteSO(string soId, string userId)
        {
            SprSalesOrderByCustomerTableAdapter adp = new SprSalesOrderByCustomerTableAdapter();
            adp.CompleteSO(int.Parse(userId), long.Parse(soId));
        }        
    }  
}
