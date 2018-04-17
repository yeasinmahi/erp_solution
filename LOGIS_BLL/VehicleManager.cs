using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LOGIS_DAL;
using LOGIS_DAL.VehicleManagerTDSTableAdapters;

namespace LOGIS_BLL
{
    public class VehicleManager
    {

        public VehicleManagerTDS.TblVehiclePriceManagerDataTable GetDataByParent(string parentID, string unitID)
        {
            VehicleManagerTDS.TblVehiclePriceManagerDataTable table = new VehicleManagerTDS.TblVehiclePriceManagerDataTable();

            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int uID = 0;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            TblVehiclePriceManagerTableAdapter ta = new TblVehiclePriceManagerTableAdapter();
            table = ta.GetDataByParent(pid, uID);

            return table;
        }

        public int GetChildCount(string ID)
        {

            TblVehiclePriceManagerTableAdapter ta = new TblVehiclePriceManagerTableAdapter();
            return int.Parse(ta.GetChildCount(long.Parse(ID)).ToString());
        }

        public void AddItem(string parentID, string level, string text, string unitID, string label, string code)
        {
            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprVehiclePriceManagerAddItemTableAdapter ta = new SprVehiclePriceManagerAddItemTableAdapter();
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

            SprVehiclePriceManagerAddItemTableAdapter ta = new SprVehiclePriceManagerAddItemTableAdapter();
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

            SprVehiclePriceManagerUpdateLabelTableAdapter ta = new SprVehiclePriceManagerUpdateLabelTableAdapter();
            ta.GetData(pid, int.Parse(level), text, uID);
        }

        public VehicleManagerTDS.SprVehiclePriceManagerGetAllUpperLevelDataTable GetAllUpperLevel(string id)
        {
            if (id.Trim() == "") return null;
            SprVehiclePriceManagerGetAllUpperLevelTableAdapter ta = new SprVehiclePriceManagerGetAllUpperLevelTableAdapter();
            VehicleManagerTDS.SprVehiclePriceManagerGetAllUpperLevelDataTable tbl = ta.GetData(long.Parse(id));

            tbl.Columns[0].ColumnName = "intID";
            tbl.Columns[1].ColumnName = "intParentID";
            tbl.Columns[2].ColumnName = "intLevel";
            return tbl;
        }
        public string GetLabel(string level, string unitID, string parentId)
        {
            TblVehiclePriceManagerLabelTableAdapter ta = new TblVehiclePriceManagerLabelTableAdapter();

            int pid;
            try { pid = int.Parse(parentId); }
            catch { pid = 0; }

            VehicleManagerTDS.TblVehiclePriceManagerLabelDataTable table = ta.GetDataByLP(long.Parse(level), int.Parse(unitID), pid);
            if (table.Rows.Count > 0) return table[0].strLabel;
            else return "No Label";

        }
    }
}