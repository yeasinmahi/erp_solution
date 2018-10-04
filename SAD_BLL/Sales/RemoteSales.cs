using SAD_DAL.Sales.RemoteSalesTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_BLL.Sales
{
    class RemoteSales
    {       

        public DataTable GetRegionbyUnit(int unit) 
        {
            try
            {
                TblItemPriceManagerTableAdapter taRegion = new TblItemPriceManagerTableAdapter();
                return taRegion.GetRegionData(unit);
            }
            catch { return new DataTable();  }

        }

        public DataTable GetAreaName(int unit, int Region)
        {
            try
            {
                TblItemPriceManager1TableAdapter taRegion = new TblItemPriceManager1TableAdapter();
                return taRegion.GetAreaData(unit, Region);
            }
            catch { return new DataTable(); }


        }

        public DataTable GetTerritoryName(int unit, int Area)
        {
            try
            {
                tblItemPriceManager2TableAdapter taRegion = new tblItemPriceManager2TableAdapter();
                return taRegion.GetTeritoryData(unit, Area);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetDeliveroderDetaillsinfo(int unit, DateTime fromDate, DateTime ToDate, int Territoryid)
        {
            try
            {
                RptDODtlsTableAdapter taDelvOrderDet = new RptDODtlsTableAdapter();
                return taDelvOrderDet.GetDODetailsData(unit, fromDate, ToDate, Territoryid);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetShopvsSalesbll(int unit, DateTime FromDate, DateTime ToDate, int ShopId)
        {
            try
            {
                RptShpvsSalesTableAdapter taDelvOrderDet = new RptShpvsSalesTableAdapter();
                return taDelvOrderDet.GetShopvsSalesData(unit, FromDate, ToDate, ShopId);
            }
            catch { return new DataTable(); }
        }

       

    }
}
