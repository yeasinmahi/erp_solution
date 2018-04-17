using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemPriceManagerTDSTableAdapters;

namespace SAD_BLL.Item
{
    public class ItemPriceManager
    {
        public ItemPriceManagerTDS.TblItemPriceManagerDataTable GetDataByParent(string parentID, string unitID)
        {
            ItemPriceManagerTDS.TblItemPriceManagerDataTable table = new ItemPriceManagerTDS.TblItemPriceManagerDataTable();

            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int uID = 0;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            TblItemPriceManagerTableAdapter ta = new TblItemPriceManagerTableAdapter();
            table = ta.GetDataByParent(pid, uID);

            return table;
        }

        public int GetChildCount(string ID)
        {

            TblItemPriceManagerTableAdapter ta = new TblItemPriceManagerTableAdapter();
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

            SprItemPriceManagerAddItemTableAdapter ta = new SprItemPriceManagerAddItemTableAdapter();
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

            SprItemPriceManagerAddItemTableAdapter ta = new SprItemPriceManagerAddItemTableAdapter();
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

            SprItemPriceManagerUpdateLabelTableAdapter ta = new SprItemPriceManagerUpdateLabelTableAdapter();
            ta.GetData(pid, int.Parse(level), text, uID);
        }

        public ItemPriceManagerTDS.SprItemPriceManagerGetAllUpperLevelDataTable GetAllUpperLevel(string id)
        {
            if (id.Trim() == "") return null;
            SprItemPriceManagerGetAllUpperLevelTableAdapter ta = new SprItemPriceManagerGetAllUpperLevelTableAdapter();
            ItemPriceManagerTDS.SprItemPriceManagerGetAllUpperLevelDataTable tbl = ta.GetData(long.Parse(id));

            tbl.Columns[0].ColumnName = "intID";
            tbl.Columns[1].ColumnName = "intParentID";
            tbl.Columns[2].ColumnName = "intLevel";
            return tbl;
        }
        public string GetLabel(string level, string unitID, string parentId)
        {
            TblItemPriceManagerLabelTableAdapter ta = new TblItemPriceManagerLabelTableAdapter();

            int pid;
            try { pid = int.Parse(parentId); }
            catch { pid = 0; }

            ItemPriceManagerTDS.TblItemPriceManagerLabelDataTable table = ta.GetDataByLP(long.Parse(level), int.Parse(unitID), pid);
            if (table.Rows.Count > 0) return table[0].strLabel;
            else return "No Label";

        }
    }
}