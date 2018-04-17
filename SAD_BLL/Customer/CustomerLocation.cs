using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer.RegionTDSTableAdapters;
using SAD_DAL.Customer;
using SAD_DAL.Customer.AreaTDSTableAdapters;
using SAD_DAL.Customer.TerriotoryTDSTableAdapters;

namespace SAD_BLL.Customer
{
    public class CustomerLocation
    {
        public RegionTDS.TblRegionDataTable GetRegionByUnit(string unitID)
        {
            TblRegionTableAdapter adp = new TblRegionTableAdapter();
            return adp.GetRegionDataByUnit(int.Parse(unitID));
        }

        public AreaTDS.TblAreaDataTable GetAreaByUnit_Region(string unitID, string regionID)
        {
            TblAreaTableAdapter adp = new TblAreaTableAdapter();
            int rid;
            try
            {
                rid = int.Parse(regionID);
            }
            catch
            {
                rid = 0;
            }
           return adp.GetAreaDataByRegion(int.Parse(unitID), rid);
            
        }

        public TerriotoryTDS.TblTerritoryDataTable GetTerritoryByUnit_Region_Area(string unitID, string regionID, string areaID)
        {
            TblTerritoryTableAdapter adp = new TblTerritoryTableAdapter();
            try
            {
                return adp.GetTerritoryDataByRegionAndArea(int.Parse(unitID), int.Parse(areaID), int.Parse(regionID));
            }
            catch
            {
               return adp.GetTerritoryDataByRegionAndArea(int.Parse(unitID), -1, -1); ;
            }
        }
    }
}
