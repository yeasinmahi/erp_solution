using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer;
using SAD_DAL.Customer.CustomerGeoTDSTableAdapters;

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
    }
}
