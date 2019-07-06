using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Sales.SalesConfigTDSTableAdapters;
using SAD_DAL.Sales;
using System.Data;
using SAD_DAL.Sales.RemoteSalesTDSTableAdapters;

namespace SAD_BLL.Sales
{
    public class SalesConfig
    {
        public SalesConfigTDS.TblSalesConfigDataTable GetConfigByUnit(string unitID)
        {
            TblSalesConfigTableAdapter ta = new TblSalesConfigTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitID));
        }
        public string GetSupplierParentCOAByUnit(string unitID)
        {
            TblSalesConfigTableAdapter ta = new TblSalesConfigTableAdapter();
            return ta.GetSupplierCOAParent(int.Parse(unitID)).Value.ToString();
        }
        public SalesConfigTDS.TblSalesConfigDataTable GetInfoForDO(string unitID)
        {
            if (unitID == "") return new SalesConfigTDS.TblSalesConfigDataTable();
            TblSalesConfigTableAdapter ta = new TblSalesConfigTableAdapter();
            return ta.GetDataByUnit(int.Parse(unitID));
        }
        public SalesConfigTDS.TblSalesTypeDataTable GetSalesTypeForDO(string unitID)
        {
            TblSalesTypeTableAdapter ta = new TblSalesTypeTableAdapter();
            return ta.GetDataForDO(int.Parse(unitID));
        }

        public SalesConfigTDS.TblSalesTypeDataTable GetSalesTypeForDO2(string unitID)
        {
            TblSalesTypeTableAdapter ta = new TblSalesTypeTableAdapter();
            return ta.GetDataForDO2(int.Parse(unitID));
        }

        public SalesConfigTDS.SprSalesTypeByItemTypeDataTable GetSalesTypeByItemType(string unitID, string itemTypeID)
        {
            SprSalesTypeByItemTypeTableAdapter ta = new SprSalesTypeByItemTypeTableAdapter();
            
            if(itemTypeID==null || itemTypeID=="")
                return new SalesConfigTDS.SprSalesTypeByItemTypeDataTable();

            return ta.GetData(int.Parse(unitID), int.Parse(itemTypeID));
        }

        #region ================== Remote Sales ========
        public DataTable GetRegionbyUnit(int unit)
        {
            try
            {
                TblItemPriceManagerTableAdapter taRegion = new TblItemPriceManagerTableAdapter();
                return taRegion.GetRegionData(unit);
            }
            catch { return new DataTable(); }

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
#endregion

        public DataTable getItemSpecification (int prdid)
        {
            try
            {
                SprItemSpecificationTextboxTableAdapter obj = new SprItemSpecificationTextboxTableAdapter();
                return obj.GetDataItemSpecificationTextbox(prdid);
            }
            catch(Exception ex)
            {
                return new DataTable();          }
        }
        public DataTable GetQutationsSpec(int unitId,int itemId)
        {
            try
            {
                DataTable1TableAdapter obj = new DataTable1TableAdapter();
                return obj.GetData(unitId,itemId);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable getItemSpecificationFroDDL1(int prdid)
        {
            try
            {
                SprItemSpecificationDropDownTableAdapter obj = new SprItemSpecificationDropDownTableAdapter();
                return obj.GetDataItemSpecificationDropDown(prdid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetRegion(int unitd)
        {
            try
            {
                SprOSRegionTableAdapter obj = new SprOSRegionTableAdapter();
                return obj.GetDataOSRegion(unitd);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetArea(int unitd,int regionid)
        {
            try
            {
                SprOSAreaTableAdapter obj = new SprOSAreaTableAdapter();
                return obj.GetDataOSArea(unitd,regionid);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


        public DataTable GetPrdLine(int unitd)
        {
            try
            {
                SprPrdGrpNameTableAdapter obj = new SprPrdGrpNameTableAdapter();
                return obj.GetDataPrdGrpName(unitd);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}
