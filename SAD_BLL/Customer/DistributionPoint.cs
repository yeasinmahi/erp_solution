using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer;
using SAD_DAL.Customer.DistributionPointTDSTableAdapters;

namespace SAD_BLL.Customer
{
    public class DistributionPoint
    {
        public DistributionPointTDS.QryDisPointDataTable GetData()
        {
            QryDisPointTableAdapter ta = new QryDisPointTableAdapter();
            return ta.GetData();
        }

        public DistributionPointTDS.QryDisPointDataTable GetDataById(string disPoint)
        {
            QryDisPointTableAdapter ta = new QryDisPointTableAdapter();
            return ta.GetDataById(int.Parse(disPoint));
        }

        public DistributionPointTDS.QryDisPointDataTable GetDataByCustomer(string customerId,bool isActive)
        {
            QryDisPointTableAdapter ta = new QryDisPointTableAdapter();
            if ("" + customerId == "") return new DistributionPointTDS.QryDisPointDataTable();
            return ta.GetDataByCustomer(int.Parse(customerId), isActive);
        }

        public DistributionPointTDS.SprGetDisPointInfoForSalesOrderDataTable GetDisPointInfoForSalesOrder(string disPointId, string userId,string unitId, DateTime dte)
        {
            if(disPointId==""||userId==""||unitId=="")return new DistributionPointTDS.SprGetDisPointInfoForSalesOrderDataTable();
            SprGetDisPointInfoForSalesOrderTableAdapter ta = new SprGetDisPointInfoForSalesOrderTableAdapter();
            return ta.GetData(int.Parse(disPointId), int.Parse(unitId), dte, int.Parse(userId));
        }

        public DistributionPointTDS.SprUndeliverQntpricevalueDataTable GetUndeliverQntPriceValue(string customerid)
        {
            if (customerid == "") return new DistributionPointTDS.SprUndeliverQntpricevalueDataTable();
            SprUndeliverQntpricevalueTableAdapter ta = new SprUndeliverQntpricevalueTableAdapter();
            return ta.GetData(int.Parse(customerid));
        }
    }
}
