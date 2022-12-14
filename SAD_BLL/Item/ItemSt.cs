using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HR_BLL.Global;
using HR_DAL.Global;
using System.Data;
using SAD_DAL.Item;
using SAD_DAL.Item.ItemTDSTableAdapters;
using SAD_DAL.Sales;
using SAD_DAL.Sales.SearchSales_TDSTableAdapters;

namespace SAD_BLL.Item
{
    public static class ItemSt
    {
        private static ItemTDS.tblItemBridge1DataTable[] tableProductsAPL = null;
        private static ItemTDS.TblItemDataTable[] tableProducts = null;
        private static SearchSales_TDS.SprSalesOrderDetaillsForTripDataTable[] tblPendingItem = null;

        private static ItemTDS.SprBudgetItemSearchingDataTable[] tableBudgetProducts = null;

        public static int e;
        private static Hashtable ht = new Hashtable();
       
        //SprSalesOrderDetaillsForTripAssign
        private static void Inatialize()
        {
            if (tableProducts == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableProducts = new ItemTDS.TblItemDataTable[tblUnit.Rows.Count];
                TblItemTableAdapter adpCOA = new TblItemTableAdapter();

                int id = 0;

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
                    SAD_DAL.Item.ItemTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(tblUnit[i].intUnitID);

                    if (tblUnit[i].intUnitID == 105)
                    {
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableProducts[i] = adpCOA.GetDataForUdtclItem(tblUnit[i].intUnitID, true);

                    }
                    else
                    {
                        if (tbl.Rows.Count > 0) id = tbl[0].intID;
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableProducts[i] = adpCOA.GetDataByUnit_Type(tblUnit[i].intUnitID, id, true);
                    }
                    //try { if (tbl.Rows.Count > 0) id = tbl[0].intID; } catch { }


                }
            }
        }
        private static void InatializeAPL()
        {
           if (tableProductsAPL == null)
            {
                Unit unt = new Unit();
                UnitTDS.TblUnitDataTable tblUnit = unt.GetUnits();
                ht = new Hashtable();

                tableProductsAPL = new ItemTDS.tblItemBridge1DataTable[tblUnit.Rows.Count];
                tblItemBridge1TableAdapter adpCOA = new tblItemBridge1TableAdapter();

                int id = 0;

                for (int i = 0; i < tblUnit.Rows.Count; i++)
                {
                    TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
                    SAD_DAL.Item.ItemTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(tblUnit[i].intUnitID);

                    if (tblUnit[i].intUnitID == 105)
                    {
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableProductsAPL[i] = adpCOA.GetDataForUdtclItem(tblUnit[i].intUnitID, true);

                    }
                    else
                    {
                        if (tbl.Rows.Count > 0) id = tbl[0].intID;
                        ht.Add(tblUnit[i].intUnitID.ToString(), i);
                        tableProductsAPL[i] = adpCOA.GetDataByUnit_Type(tblUnit[i].intUnitID, id, true);
                    }
                    //try { if (tbl.Rows.Count > 0) id = tbl[0].intID; } catch { }


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

        public static string[] GetProductDataForAutoFillAPL(string unitID, string prefix)
        {
            InatializeAPL();
            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableProductsAPL[Convert.ToInt32(ht[unitID])]//Convert.ToInt32(ht[unitID])                           
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

                    var rows = from tmp in tableProductsAPL[Convert.ToInt32(ht[unitID])]
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

        public static void ReloadProduct(string unitID)
        {
            Inatialize();

            int id = 0;
            TblItemTypeTableAdapter taTp = new TblItemTypeTableAdapter();
            SAD_DAL.Item.ItemTDS.TblItemTypeDataTable tbl = taTp.GetTopFinishGoods(int.Parse(unitID));

            if (tbl.Rows.Count > 0) id = tbl[0].intID;

            TblItemTableAdapter adpCOA = new TblItemTableAdapter();
            tableProducts[Convert.ToInt32(ht[unitID])] = adpCOA.GetDataByUnit_Type(int.Parse(unitID), id, true);
        }

        public static string[] GetBudgetProductItem(string budgettype, string unitid, string prefix)
        {
            tableBudgetProducts = new ItemTDS.SprBudgetItemSearchingDataTable[Convert.ToInt32(unitid)];
            // tblDoPendintItem = new Delivery_TDS.QryDOProfileDataTable[Convert.ToInt32];
            SprBudgetItemSearchingTableAdapter adp = new SprBudgetItemSearchingTableAdapter();
            tableBudgetProducts[e] = adp.GetDataBudgetItemSearching(int.Parse(budgettype), int.Parse(unitid));

            prefix = prefix.Trim().ToLower();
            DataTable tbl = new DataTable();

            if (prefix == "" || prefix == "*")
            {
                var rows = from tmp in tableBudgetProducts[e]//Convert.ToInt32(ht[unitID])                           
                           orderby tmp.straccname
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

                    var rows = from tmp in tableBudgetProducts[e]
                               where tmp.straccname.ToLower().Contains(prefix)//, true, System.Globalization.CultureInfo.CurrentUICulture)
                               orderby tmp.straccname
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

                    retStr[i] = tbl.Rows[i]["straccname"] + " [" + tbl.Rows[i]["intaccid"] + "]" ;
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