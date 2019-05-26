using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.Delivery;
using SAD_DAL.Delivery.Delivery_TDSTableAdapters;
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

        private static Delivery_TDS.QryDOProfileDataTable[] tblDoProfile = null;
        private static Delivery_TDS.QryDOPendingItemDataTable[] tblDoPendintItem = null;
        private static Delivery_TDS.QryShipToPartyDataTable[] tblShipParty = null;


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


        public static string[] GetDoPendingItemByCustomer(string customerId,string shipPointId, string prefix)
        {
            tblDoPendintItem = new Delivery_TDS.QryDOPendingItemDataTable[Convert.ToInt32(customerId)];
            QryDOPendingItemTableAdapter adp = new QryDOPendingItemTableAdapter();
            tblDoPendintItem[e] = adp.GetDoPendingByCustomer(int.Parse(customerId), int.Parse(shipPointId));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblDoPendintItem[e]//Convert.ToInt32(ht[unitID])                           
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

                    var rows = from tmp in tblDoPendintItem[e]
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

                    retStr[i] = tbl.Rows[i]["strProductName"] + " [" + tbl.Rows[i]["intDoId"] + "]" + " [" + tbl.Rows[i]["intProductId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetDoPendingItemByDo(string doId,string shipPointId, string prefix)
        {
            tblDoPendintItem = new Delivery_TDS.QryDOPendingItemDataTable[Convert.ToInt32(shipPointId)];
            // tblDoPendintItem = new Delivery_TDS.QryDOProfileDataTable[Convert.ToInt32];
            QryDOPendingItemTableAdapter adp = new QryDOPendingItemTableAdapter();
            tblDoPendintItem[e] = adp.GetPendingByDo(int.Parse(doId),int.Parse(shipPointId));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblDoPendintItem[e]//Convert.ToInt32(ht[unitID])                           
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

                    var rows = from tmp in tblDoPendintItem[e]
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

                    retStr[i] = tbl.Rows[i]["strProductName"] + " [" + tbl.Rows[i]["intDoId"] + "]" + " [" + tbl.Rows[i]["intProductId"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static string[] GetShipToParty(string customerId, string prefix)
        {
            tblShipParty = new Delivery_TDS.QryShipToPartyDataTable[Convert.ToInt32(customerId)];
            QryShipToPartyTableAdapter adp = new QryShipToPartyTableAdapter();
            tblShipParty[e] = adp.GetShipToParty(int.Parse(customerId));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tblShipParty[e]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.strName
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

                    var rows = from tmp in tblShipParty[e]
                               where tmp.strName.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.strName
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
                    retStr[i] = tbl.Rows[i]["strName"]+"["+ tbl.Rows[i]["intCusID"] + "]";
                    //  retStr[i] = tbl.Rows[i]["strProductName"] + " [" + tbl.Rows[i]["intDoId"] + "]" + " [" + tbl.Rows[i]["intProductId"] + "]";
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
            else if(prefix.Trim().Length >= 3)
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
            else if (prefix.Trim().Length >= 3)
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
