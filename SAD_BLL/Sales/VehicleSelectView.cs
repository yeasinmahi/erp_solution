using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.VehicleSelectViewTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class VehicleSelectView
    {
        public VehicleSelectViewTDS.SprVehicleSelectByCustomerDataTable GetDelivaryOrder(DateTime? fromDate, DateTime? toDate, string code, string unitID, string userID
            , string customerId, string customerType, bool isCompleted, string shippingPoint, string salesOffice)
        {
            SprVehicleSelectByCustomerTableAdapter adp = new SprVehicleSelectByCustomerTableAdapter();

            int? cId = null;
            if ("" + customerId != "")
            {
                cId = int.Parse(customerId);
            }

            if ("" + code == "")
            {
                code = null;
            }

            //if (fromDate == null)
            //{
            //    fromDate = DateTime.Now.AddDays(-45);
            //}

            //if (toDate == null)
            //{
            //    toDate = DateTime.Now.AddDays(45);
            //}

            if (fromDate == null && unitID=="90")
            {
                fromDate = DateTime.Now.AddDays(-90);
            }
            if (fromDate == null && unitID != "90")
            {
                fromDate = DateTime.Now.AddDays(-45);
            }

            if (toDate == null && unitID == "90")
            {
                toDate = DateTime.Now.AddDays(90);
            }

            if (toDate == null && unitID != "90")
            {
                toDate = DateTime.Now.AddDays(45);
            }




            if ("" + customerType == "") return null;
            return adp.GetData(int.Parse(unitID), cId, fromDate, toDate, int.Parse(customerType), isCompleted, code, int.Parse(shippingPoint), int.Parse(salesOffice));

        }
    }
}
