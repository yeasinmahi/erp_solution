using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemTDSTableAdapters;
using System.Collections;
using HR_BLL.Global;
using HR_DAL.Global;


namespace SAD_BLL.Item
{
    public static class ItemStCommercial
    {
        private static ItemTDS.TblItemDataTable[] tableProducts = null;
        private static Hashtable ht = new Hashtable();
        private static void Inatialize()
        {
            if (tableProducts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableProducts = new ItemTDS.TblItemDataTable[tblUnit.Rows.Count];
                TblItemTableAdapter adpCOA = new TblItemTableAdapter();

                //int id = 0;

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    /*TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
                    SAD_DAL.Item.ItemTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(tblUnit[i].intUnitID);

                    if (tbl.Rows.Count > 0) id = tbl[0].intID;*/

                    ht.Add(tblUnit[i].intUnitID.ToString(), i);
                    tableProducts[i] = adpCOA.GetDataUnit_CommercialItem(tblUnit[i].intUnitID, true);
                }
            }
        }

        public static string[] GetProductDataForAutoFill(string unitID, string prefix)
        {
            Inatialize();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();


            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableProducts[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strProductName
                           select tmp;
                if (rows.Count() > 0)
                {
                    tbl = rows.CopyToDataTable();
                }
            }
            else
            {
                try
                {
                    var rows = from tmp in tableProducts[Convert.ToInt32(ht[unitID])]
                               where tmp.strProductName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strProductName
                               select tmp;
                    if (rows.Count() > 0)
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strProductName"] + " [" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

    }
}
