using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales;
using SAD_DAL.Sales.OrderByTripTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class OrderByTrip
    {
        public OrderByTripTDS.TblSalesOrderTripDataTable GetDataByTrip(string tripId)
        {
            TblSalesOrderTripTableAdapter ta = new TblSalesOrderTripTableAdapter();
            return ta.GetDataByTrip(int.Parse(tripId));
        }

        public OrderByTripTDS.TblSalesOrderTripDataTable GetDataBySO(string soId)
        {
            TblSalesOrderTripTableAdapter ta = new TblSalesOrderTripTableAdapter();
            return ta.GetDataBySO(int.Parse(soId));
        }


        public OrderByTripTDS.SprGetCustomeridFromTripIdDataTable Getcustomeridfromtripid(string tripid)
        {
            SprGetCustomeridFromTripIdTableAdapter ta = new SprGetCustomeridFromTripIdTableAdapter();
            return ta.GetDataGetCustomeridFromTripId(int.Parse(tripid));
        }

        public OrderByTripTDS.SprCustomerTripIdvsChallanDetaillsDataTable GetDataByTripForPendingQnt(string tripId)
        {
            SprCustomerTripIdvsChallanDetaillsTableAdapter ta = new SprCustomerTripIdvsChallanDetaillsTableAdapter();
            return ta.GetDataCustomerTripIdvsChallanDetaills(int.Parse(tripId));
        }

        public OrderByTripTDS.SprCustomerOrdervsChallanDetaillsDataTable GetDataByInformation()
        {
            SprCustomerOrdervsChallanDetaillsTableAdapter ta = new SprCustomerOrdervsChallanDetaillsTableAdapter();
            return ta.GetDataCustomerOrdervsChallanDetaills();
        }

    }
}
