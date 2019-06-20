using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.DelivaryViewTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class DelivaryView
    {
        public DelivaryViewTDS.SprDelivaryOrderByCustomerDataTable GetDelivaryOrder(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprDelivaryOrderByCustomerTableAdapter adp = new SprDelivaryOrderByCustomerTableAdapter();

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

        public void CancelDO(string doId, string userId)
        {
            SprDelivaryOrderByCustomerTableAdapter adp = new SprDelivaryOrderByCustomerTableAdapter();
            adp.CancelDO(int.Parse(userId), long.Parse(doId));
        }

        public void CompleteDO(string doId, string userId,string unitId)
        {
            SprDelivaryOrderCompleteTableAdapter adp = new SprDelivaryOrderCompleteTableAdapter();
            adp.GetData(int.Parse(unitId), long.Parse(doId), int.Parse(userId));
        }

        public DelivaryViewTDS.SprReturnSalesDOViewDataTable GetSalesReturnDOView(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
          , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprReturnSalesDOViewTableAdapter adp = new SprReturnSalesDOViewTableAdapter();

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
            return adp.GetDataReturnSalesDOView(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }


        public void CancelSalesReturnDO(string doId, string userId)
        {
            SprReturnSalesDOViewTableAdapter adp = new SprReturnSalesDOViewTableAdapter();
            adp.CancelSalesReturnDO(int.Parse(userId), long.Parse(doId));
        }

        public void CompleteSalesReturnDO(string doId, string userId, string unitId)
        {
            SprReturnSalesDelivaryOrderCompleteTableAdapter adp = new SprReturnSalesDelivaryOrderCompleteTableAdapter();
            adp.GetDataReturnSalesDelivaryOrderComplete(int.Parse(unitId), long.Parse(doId), int.Parse(userId));
        }

        public DataTable GetAreaName (int unitid)
        {
            TblAreaNameTableAdapter adp = new TblAreaNameTableAdapter();
            return adp.GetDataAreaName(unitid);
        }

        public DataTable getAreaBaseCommission (DateTime from,DateTime to, string salesofname,string reptname,int unitid ,int areaid, decimal factrate, decimal ghatrate)
        {
            try
            {
                SprACCCashDOCommission1TableAdapter ta = new SprACCCashDOCommission1TableAdapter();
                return ta.GetDataACCCashDOCommission(from, to, salesofname, reptname, unitid, areaid, factrate, ghatrate);
            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }

    }
}
