using SAD_DAL.AEFPS;
using SAD_DAL.AEFPS.ReceiveTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SAD_BLL.AEFPS
{
    public class Receive_BLL
    {
        private static ReceiveTDS.TblItemListSearchDataTable[] tableItem = null;
        int e;
        public string[] GetFairPriceItem(Int32 Active, string prefix)
        { 
            tableItem = new ReceiveTDS.TblItemListSearchDataTable[Convert.ToInt32(Active)];
            TblItemListSearchTableAdapter adpCOA = new TblItemListSearchTableAdapter();
            tableItem[e] = adpCOA.GetFPSItemData(Convert.ToBoolean(Active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItem[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strItemName
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
                        var rows = from tmp in tableItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strItemName.ToLower().Contains(prefix)  
                                   orderby tmp.intItemID
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                   
                    retStr[i] = tbl.Rows[i]["strItemName"] +" "+ tbl.Rows[i]["strDescription"] + "[" + tbl.Rows[i]["intItemID"] + "]"  + "[" + tbl.Rows[i]["strUoM"] + "]";

                }
                return retStr;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetItem(string prefix)
        {
            DataTable dt = GetItem();
            if (dt.Rows.Count > 0)
            {
                prefix = prefix.Trim().ToLower();
                DataTable tbl = new DataTable();
                try
                {
                    var rows = from row in dt.AsEnumerable()
                        where row.Field<string>("strName").ToLower().Contains(prefix) ||
                              row.Field<int>("intMasterId").ToString().Contains(prefix)
                        select row;
                    if (rows.Any())
                    {
                        tbl = rows.CopyToDataTable();
                    }
                }
                catch
                {
                    return new List<string>();
                }

                if (tbl.Rows.Count > 0)
                {
                    List<string> retStr = new List<string>();
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        retStr.Add(tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["intMasterId"] + "]");
                    }

                    return retStr;
                }
            }
            return new List<string>();
        }

        private static DataTable GetItem()
        {
            tblShopItemListTableAdapter adp = new tblShopItemListTableAdapter();
            return adp.GetShopItems();
        }

        public DataTable DataView(int type, string xml, int intwh, int intMrr, DateTime dteDate, int enroll)
        {
            try
            {
                string strMsg = "";
                SprFpsReceiveTableAdapter adp = new SprFpsReceiveTableAdapter();
                return adp.GetReceiveData(type, xml, intwh, intMrr, dteDate, enroll, ref strMsg);
            }
            catch { return new DataTable(); }
        }

        public string MrrReceiveInsert(int type, string xml, int intwh, int intMrr, DateTime dteDate, int enroll)
        {
            string strMsg = "";
            try
            {
                
                SprFpsReceiveTableAdapter adp = new SprFpsReceiveTableAdapter();
                adp.GetReceiveData(type, xml, intwh, intMrr, dteDate, enroll, ref strMsg);
                
            }
            catch (Exception ex) { return strMsg = ex.ToString(); }
            return strMsg;
        }

        public void RePrintVoucher(int intWhId, string sv)
        {
            try
            {
                tblSalesTableAdapter adp = new tblSalesTableAdapter();
                adp.RePrintVoucher(intWhId,sv);

            }
            catch (Exception ex)
            {
                // ignored
            }
        }
        public void ClearPrinter(int intWhId)
        {
            try
            {
                tblSales1TableAdapter adp = new tblSales1TableAdapter();
                adp.ClearPrinter(intWhId);

            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        
        public DataTable GetPurchase(int intType,int mrrNo)
        {
            sprPurchaseReturnTableAdapter adp = new sprPurchaseReturnTableAdapter();
            try
            {
                return adp.GetPurchaseReturnDetails(intType,mrrNo);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetActiveItemInfo(int itemId, int whId)
        {
            DataTable1TableAdapter adp = new DataTable1TableAdapter();
            try
            {
                return adp.GetActiveItemInfo(itemId, whId);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetInActiveItemInfo(int whId)
        {
            DataTable3TableAdapter adp = new DataTable3TableAdapter();
            try
            {
                return adp.GetInActiveItemInfo(whId);
            }
            catch { return new DataTable(); }
        }
        public DataTable InactiveItem(string strRemarks ,int itemId, int whId)
        {
            DataTable2TableAdapter adp = new DataTable2TableAdapter();
            try
            {
                return adp.InactiveItem(strRemarks, itemId, whId);
            }
            catch
            {
                return null;
            }
        }
        public DataTable ActiveItem(int itemId, int whId)
        {
            DataTable4TableAdapter adp = new DataTable4TableAdapter();
            try
            {
                return adp.ActiveItem(itemId, whId);
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetDamageItemList(int WHId)
        {
            TblDamageTableAdapter adp = new TblDamageTableAdapter();
            try
            {
                return adp.GetDamageItemData(WHId);
            }
            catch
            {
                return new DataTable();
            }
        }
        public string UpdateRejectedDamageItemList(int itemId,int WHId,int MrrId)
        {
            string msg = "";
            TblDamageTableAdapter adp = new TblDamageTableAdapter();
            try
            {
                 adp.UpdateRejectedDamageItem(itemId,WHId, MrrId);
                return msg = "Rejected";
            }
            catch
            {
                
            }
            return msg;
        }

        public DataTable DamageItem(string xml)
        {
            SprDamageItemTableAdapter adp = new SprDamageItemTableAdapter();
            try
            {
                return adp.DamageEntry(xml);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
