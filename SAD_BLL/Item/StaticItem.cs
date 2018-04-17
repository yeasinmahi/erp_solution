using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemTDSTableAdapters;
using System.Data;

namespace SAD_BLL.Item
{
    
    public static class StaticItem
    {
        static ItemTDS.TblItemDataTable table;
        public static void Inatialize()
        {
            if (table == null)
            {
                TblItemTableAdapter ta = new TblItemTableAdapter();
                table = ta.GetData();
            }
        }

        public static string[] GetActiveFinishGoods(string unitId, string prefix)
        {
            DataTable tbl = new DataTable();
            Inatialize();
            prefix = prefix.Trim();
            if (prefix == "" || prefix == "*")
            {
                try
                {
                    var rows = from tmp in table
                               where tmp.ysnActive == true
                                    && tmp.intUnitID == int.Parse(unitId)
                                    && tmp.intTypeID == 1
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
            else
            {
                try
                {
                    var rows = from tmp in table
                               where tmp.ysnActive == true
                                    && tmp.intUnitID == int.Parse(unitId)
                                    && tmp.intTypeID == 1
                                    && tmp.strProductName.StartsWith(prefix, true, System.Globalization.CultureInfo.CurrentUICulture)
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
