using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AutoSearch.ItemTdsTableAdapters;

namespace BLL.AutoSearch
{
    public class ItemBll
    {
        string[] results;
        string[] items = new string[0];
        private DataTable dt = new DataTable();
        public string[] GetAllItemListByUnit(string prefix,string Unit)
        {
            prefix = prefix.ToLower();
            TblItemListTableAdapter adp = new TblItemListTableAdapter();
            if (dt.Rows.Count < 1)
            {
                dt = adp.GetData(Convert.ToInt32(Unit));
            }
            if (prefix.Trim().Length >= 3)
            {
                if (dt.Rows.Count > 0)
                {
                    if (items.Length < 1)
                    {
                        items = new string[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            items[i] = dt.Rows[i]["strProductName"] + "[" + dt.Rows[i]["intItemID"] + "][" + dt.Rows[i]["strUoM"] + "]";
                        }
                    }
                    results = Array.FindAll(items, x => x.ToLower().Contains(prefix));
                    return results;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
