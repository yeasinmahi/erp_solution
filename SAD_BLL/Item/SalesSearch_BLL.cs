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
using SAD_DAL.Transport.InternalTransportTDSTableAdapters;

namespace SAD_BLL.Item
{
    public class SalesSearch_BLL
    {
      
        private static SearchSales_TDS.SprSalesOrderDetaillsForTripDataTable[] tblPendingItem = null;
        private static SearchSales_TDS.TblVehicleRentDataDataTable[] tblVehicleRent = null;
        private static SearchSales_TDS.TblVehicleCustomerDataDataTable[] tblVehicleCustomer = null;
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

        public static string[] GetRentVehicleList(string unitid, string prefix)
        {

            tblVehicleRent = new SearchSales_TDS.TblVehicleRentDataDataTable[Convert.ToInt32(unitid)];
            TblVehicleRentDataTableAdapter adp = new TblVehicleRentDataTableAdapter();
            tblVehicleRent[e] = adp.GetRentVehicleList(int.Parse(unitid));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblVehicleRent[e]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strRegNo
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

                    var rows = from tmp in tblVehicleRent[e]
                               where tmp.strRegNo.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strRegNo
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

                    retStr[i] = tbl.Rows[i]["strRegNo"] + " [" + tbl.Rows[i]["intID"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetCustomerVehicleList(string unitid, string prefix)
        {

            tblVehicleCustomer = new SearchSales_TDS.TblVehicleCustomerDataDataTable[Convert.ToInt32(unitid)];
            TblVehicleCustomerDataTableAdapter adp = new TblVehicleCustomerDataTableAdapter();
            tblVehicleCustomer[e] = adp.GetCustomerVehicleList(int.Parse(unitid));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblVehicleCustomer[e]//Convert.ToInt32(ht[unitID])                           
                    orderby tmp.strRegNo
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

                    var rows = from tmp in tblVehicleCustomer[e]
                        where tmp.strRegNo.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                        orderby tmp.strRegNo
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

                    retStr[i] = tbl.Rows[i]["strRegNo"] + " [" + tbl.Rows[i]["intID"] + "]";
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
