using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer;
using SAD_DAL.Customer.CustomerGeoTDSTableAdapters;
using SAD_DAL.Customer.TerriotoryTDSTableAdapters;
using SAD_DAL.Customer.RegionTDSTableAdapters;
using SAD_DAL.Customer.AreaTDSTableAdapters;
using SAD_DAL.Customer.DistributionPointTDSTableAdapters;
using System.Data;

namespace SAD_BLL.Customer
{
    public class CustomerGeo
    {

        public CustomerGeoTDS.TblCustomerGeoManagerDataTable GetDataByParent(string parentID, string unitID)
        {
            CustomerGeoTDS.TblCustomerGeoManagerDataTable table = new CustomerGeoTDS.TblCustomerGeoManagerDataTable();

            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int uID = 0;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            TblCustomerGeoManagerTableAdapter ta = new TblCustomerGeoManagerTableAdapter();
            table = ta.GetDataByParent(pid, uID);

            return table;
        }

        public int GetChildCount(string ID)
        {
            
            TblCustomerGeoManagerTableAdapter ta = new TblCustomerGeoManagerTableAdapter();
            return int.Parse(ta.GetChildCount(long.Parse(ID)).ToString());
        } 

        public void AddItem(string parentID, string level, string text, string unitID,string label, string code)
        {
            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprCustomerGeoManagerAddItemTableAdapter ta = new SprCustomerGeoManagerAddItemTableAdapter();
            ta.GetData(null, pid, int.Parse(level), text, label, uID, code, false);
        }

       public void AddSubItem(string parentID, string level, string sublevel, string text, string label, string unitID, string code)
        {
            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprCustomerGeoManagerAddItemTableAdapter ta = new SprCustomerGeoManagerAddItemTableAdapter();
            ta.GetData(null, pid, int.Parse(level), text, label, uID, code, true);
        }

       public void UpdateLabel(string parentId, string level, string text, string unitID)
        {
            long pid;
            try { pid = long.Parse(parentId); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprCustomerGeoManagerUpdateLabelTableAdapter ta = new SprCustomerGeoManagerUpdateLabelTableAdapter();
            ta.GetData(pid, int.Parse(level), text, uID);
        }

       public CustomerGeoTDS.SprCustomerGeoManagerGetAllUpperLevelDataTable GetAllUpperLevel(string id)
        {
            if (id.Trim() == "") return null;
            SprCustomerGeoManagerGetAllUpperLevelTableAdapter ta = new SprCustomerGeoManagerGetAllUpperLevelTableAdapter();
            CustomerGeoTDS.SprCustomerGeoManagerGetAllUpperLevelDataTable tbl = ta.GetData(long.Parse(id));

            tbl.Columns[0].ColumnName = "intID";
            tbl.Columns[1].ColumnName = "intParentID";
            tbl.Columns[2].ColumnName = "intLevel";
            return tbl;
        }
        public string GetLabel(string level, string unitID, string parentId)
        {
            TblCustomerGeoManagerLabelTableAdapter ta = new TblCustomerGeoManagerLabelTableAdapter();

            int pid;
            try { pid = int.Parse(parentId); }
            catch { pid = 0; }

            CustomerGeoTDS.TblCustomerGeoManagerLabelDataTable table = ta.GetDataByLP(long.Parse(level), int.Parse(unitID), pid);
            if (table.Rows.Count > 0) return table[0].strLabel;
            else return "No Label";

        }

        #region========== Line Region Area Territory Point =====
        public DataTable GetLine()
        {
            TblItemFGGroupTableAdapter adp = new TblItemFGGroupTableAdapter();
            return adp.GetData();
        }
        public DataTable GetRegion()
        {
            SAD_DAL.Customer.RegionTDSTableAdapters.TblGEOSetupTableAdapter adp = new SAD_DAL.Customer.RegionTDSTableAdapters.TblGEOSetupTableAdapter();
            return adp.GetData();
        }
        public DataTable GetArea(int regionId)
        {
            SAD_DAL.Customer.AreaTDSTableAdapters.TblGEOSetupTableAdapter adp = new SAD_DAL.Customer.AreaTDSTableAdapters.TblGEOSetupTableAdapter();
            return adp.GetDataByAreaId(regionId);
        }
        public DataTable GetTerritory(int areaId)
        {
            SAD_DAL.Customer.TerriotoryTDSTableAdapters.TblGEOSetupTableAdapter adp = new SAD_DAL.Customer.TerriotoryTDSTableAdapters.TblGEOSetupTableAdapter();
            return adp.GetDataByAreaId(areaId);
        }
        public DataTable GetPoint(int territoryId)
        {
            SAD_DAL.Customer.DistributionPointTDSTableAdapters.TblGEOSetupTableAdapter adp = new SAD_DAL.Customer.DistributionPointTDSTableAdapters.TblGEOSetupTableAdapter();
            return adp.GetDataByTerritoryId(territoryId);
        }

        public DataTable GetTargetChange(int type, int intline, int intpoint,DateTime dteDate,int intproductid, decimal intQtypcs,decimal intQty, int intproductuom)
        {
            sprPointTargetChangeTableAdapter adp = new sprPointTargetChangeTableAdapter();
            return adp.GetData(type,intline,intpoint,dteDate,intproductid,intQtypcs,intQty,intproductuom);
        }
        #endregion======= Line Region Area Territory Point =====

    }
}
