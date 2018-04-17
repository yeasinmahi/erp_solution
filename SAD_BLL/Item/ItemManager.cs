using System;
using System.Collections.Generic;
using System.Text;
using SAD_DAL.Item;
using SAD_DAL;
using SAD_DAL.Item.ItemManagerTDSTableAdapters;

namespace SAD_BLL.Item
{
    public class ItemManager
    {

        public ItemManagerTDS.TblItemManagerCetagoryDataTable GetItemCatagoryByID(string ID)
        {
            TblItemManagerCetagoryTableAdapter ta = new TblItemManagerCetagoryTableAdapter();
            return ta.GetDataByID(int.Parse(ID));
        }
        public ItemManagerTDS.TblItemManagerCetagoryDataTable GetItemCatagory()
        {
            TblItemManagerCetagoryTableAdapter ta = new TblItemManagerCetagoryTableAdapter();
            return ta.GetData();
        }
        public ItemManagerTDS.TblItemManagerDataTable GetDataByParent(string parentID, string subLevel,string itemType, string unitID)
        {
            ItemManagerTDS.TblItemManagerDataTable table = new ItemManagerTDS.TblItemManagerDataTable();
            if (itemType != null && itemType != "")
            {
                long pid;
                try { pid = long.Parse(parentID); }
                catch { pid = 0; }

                int uID = 0;
                try { uID = int.Parse(unitID); }
                catch { uID = 0; }

                int? item = int.Parse(itemType);


                TblItemManagerTableAdapter ta = new TblItemManagerTableAdapter();
                table = ta.GetDataByParentID(pid, int.Parse(subLevel), uID, item);                
            }

            return table;
        }
        public int GetMaxSubLevelByParent(string parentID)
        {
            long pid;
            try{pid=long.Parse(parentID);}
            catch{pid=0;}

            TblItemManagerTableAdapter ta = new TblItemManagerTableAdapter();
            return (int)ta.GetMaxSubLevel(pid);
        }

        public void AddItem(string parentID, string level, string sublevel, string text, string unitID,string itemType,string code)
        {
            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprItemManagerAddItemTableAdapter ta = new SprItemManagerAddItemTableAdapter();
            ta.AddUpdateData(null, pid, int.Parse(level), int.Parse(sublevel), text, "", uID, int.Parse(itemType), code, false);
        }

        public void AddSubItem(string parentID, string level, string sublevel, string text, string label, string unitID, string itemType, string code)
        {
            long pid;
            try { pid = long.Parse(parentID); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprItemManagerAddItemTableAdapter ta = new SprItemManagerAddItemTableAdapter();
            ta.AddUpdateData(null, pid, int.Parse(level), int.Parse(sublevel), text, label, uID, int.Parse(itemType), code, true);
        }

        public void UpdateLabel(string label, string subLevel, string level, string unitID)
        {
            long pid;
            try { pid = long.Parse(level); }
            catch { pid = 0; }

            int? uID = null;
            try { uID = int.Parse(unitID); }
            catch { uID = 0; }

            SprItemManagerUpdateLabelTableAdapter ta = new SprItemManagerUpdateLabelTableAdapter();
            ta.AddUpdateData(pid, int.Parse(subLevel), label, uID);
        }

        public ItemManagerTDS.SprItemManagerGetAllUpperLevelDataTable GetAllUpperLevel(string id)
        {            
            if (id.Trim() == "") return null;
            SprItemManagerGetAllUpperLevelTableAdapter ta = new SprItemManagerGetAllUpperLevelTableAdapter();
            ItemManagerTDS.SprItemManagerGetAllUpperLevelDataTable tbl = ta.GetData(long.Parse(id));
            
            tbl.Columns[0].ColumnName = "intID";
            tbl.Columns[1].ColumnName = "intParentID";
            tbl.Columns[2].ColumnName = "intLevel";
            return tbl;
        }
        public string GetLabel(string subLevel, string level, string unitID,string parentId)
        {
            TblItemManagerLabelTableAdapter ta = new TblItemManagerLabelTableAdapter();

            int pid;
            try { pid = int.Parse(parentId); }
            catch { pid = 0; }

            ItemManagerTDS.TblItemManagerLabelDataTable table = ta.GetDataByLS(long.Parse(level), int.Parse(subLevel), int.Parse(unitID), pid);
            if (table.Rows.Count > 0) return table[0].strLabel;
            else return "No Label";

        }

    }
}
