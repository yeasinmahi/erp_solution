using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters;

namespace SAD_BLL.Sales.Report
{
    public class UDTCLSalesBLL
    {
        public DataTable getShippingPoint(int unitid)
        {
            tblShippingPointTableAdapter adp = new tblShippingPointTableAdapter();
            return adp.GetShippingPointDataByUnitid(unitid);
        }

        public DataTable getUDTCLSalesData(DateTime fromDate,DateTime toDate,int unitId,int reportType,int salesOffId,int shippingId)
        {
            sprUDTCLSalesStausTableAdapter adp = new sprUDTCLSalesStausTableAdapter();
            return adp.GetUDTCLSalesData(fromDate, toDate, unitId, reportType, salesOffId, shippingId);
        }

        public DataTable getSalesData(DateTime fromDate, DateTime toDate, int unitId, int reportType, int salesOffId, int shippingId)
        {
            sprUDTCLSalesStausDetaillsTableAdapter adp = new sprUDTCLSalesStausDetaillsTableAdapter();
            return adp.GetSalesData(fromDate, toDate, unitId, reportType, salesOffId, shippingId);
        }
    }
}
