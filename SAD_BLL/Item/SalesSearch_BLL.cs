using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Item.ItemTDSTableAdapters;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SearchSales_TDSTableAdapters;

namespace SAD_BLL.Item
{
    public class SalesSearch_BLL
    {
      
        private static SearchSales_TDS.SprSalesOrderDetaillsForTripDataTable[] tblPendingItem = null;
        private static Hashtable ht = new Hashtable();
        public static int e;

        public static string[] GetPendingProductAutoFill(string SalesOrderId, string prefix)
        {

            tblPendingItem = new SearchSales_TDS.SprSalesOrderDetaillsForTripDataTable[Convert.ToInt32(SalesOrderId)];
            SprSalesOrderDetaillsForTripTableAdapter adp = new SprSalesOrderDetaillsForTripTableAdapter();
            tblPendingItem[e] = adp.GetPendingDoItem(int.Parse(SalesOrderId));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblPendingItem[e]//Convert.ToInt32(ht[unitID])                           
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

                    var rows = from tmp in tblPendingItem[e]
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
                    
                       retStr[i] = tbl.Rows[i]["strProductName"] + " [" + tbl.Rows[i]["strUOM"] + "]" + " [" + tbl.Rows[i]["intProductId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public DataTable getSONPrdIDBaseDet (int soid ,int prdid)
        {
            try
            {
                SprSalesOrderDetaillsBySOIdNItmIDTableAdapter obj = new SprSalesOrderDetaillsBySOIdNItmIDTableAdapter();
                return obj.GetDataSalesOrderDetaillsBySOIdNItmID(soid, prdid);


            }
            catch(Exception ex)
            {
                return new DataTable();
            }
        }

        public SearchSales_TDS.SprSalesOrderDetaillsBySOIdNItmIDDataTable GetSalesOrderDetailsTrip(int soid, int prdid)
        {

            SprSalesOrderDetaillsBySOIdNItmIDTableAdapter obj = new SprSalesOrderDetaillsBySOIdNItmIDTableAdapter();
            return obj.GetDataSalesOrderDetaillsBySOIdNItmID(soid, prdid);

        }

         

    }
}
