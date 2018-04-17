using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SAD_DAL.Item.ItemPromotionTDSTableAdapters;
using SAD_DAL.Item;
namespace SAD_BLL.Item
{
    public class ItemPromotion
    {
        private static ItemPromotionTDS.tblCustomerDataTable[] tableCustsName = null;
        private static ItemPromotionTDS.tblItemDataTable[] tableItem = null;
        int e;
        public decimal GetPromotion(string productId, string customerId, string priceVariable,
            string UOM, string currency, string salesType
            , DateTime date,string quantity, ref decimal promQnty
            , ref int promItemId, ref string promItem, ref int promItemUOM, ref string promUom, ref int promItemCOAid)
        {
            int? cus = null, pv = null;
            try { cus = int.Parse(customerId); }
            catch { }
            try { pv = int.Parse(priceVariable); }
            catch { }

            decimal? price = 0;     
            decimal? promQnty_ = 0;
            int? promItemId_ = 0;
            int? promItemUOM_ = 0;
            int? promItemCOAid_ = 0;

            if (productId.ToString() == "" || quantity == "") return price.Value;

            SprItemGetPromotionTableAdapter ta = new SprItemGetPromotionTableAdapter();
            ta.GetData(int.Parse(productId), decimal.Parse(quantity), cus, pv, int.Parse(UOM), int.Parse(currency), int.Parse(salesType), date.Date, ref promQnty_, ref promItemId_, ref promItem, ref promItemUOM_, ref promUom, ref price, ref promItemCOAid_);
                        
            promQnty = promQnty_.Value;
            promItemId = promItemId_.Value;
            promItemUOM = promItemUOM_.Value;
            promItemCOAid = promItemCOAid_.Value;

            return price.Value;
        }

        public DataTable getPromotionReport(int intActive, int customertype, int custid, int itemidSales)
        {
            try
            {
                sprFreeReportTableAdapter adpPromotion = new sprFreeReportTableAdapter();
                return adpPromotion.GetPromotionReport(intActive, customertype,custid,itemidSales);

            }
            catch { return new DataTable(); }
        }

        public DataTable GetLine()
        {
            try
            {
                tblItemFGGroupTableAdapter adpLine = new tblItemFGGroupTableAdapter();
                return adpLine.GetLine();

            }
            catch { return new DataTable(); }
        }
        public DataTable GetareaName(int Reginid,int Lineid)
        {
            try
            {
                tblAreaListTableAdapter adpArea = new tblAreaListTableAdapter();
                return adpArea.GetAreaList(Reginid, Lineid);
            }
            catch { return new DataTable(); }
        }

        public string[] GetCstomer(string prefix)
        {
            int ysnActive = 1;
            tableCustsName = new ItemPromotionTDS.tblCustomerDataTable[Convert.ToInt32(ysnActive)];
            tblCustomerTableAdapter Vehicle = new tblCustomerTableAdapter();
            tableCustsName[e] = Vehicle.GetCustomerList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableCustsName[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strname
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
                        var rows = from tmp in tableCustsName[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strname.ToLower().Contains(prefix)
                                   orderby tmp.strname
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
                    retStr[i] = tbl.Rows[i]["strname"] + "," + "[" + tbl.Rows[i]["intcusid"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public string getPromotionEntry(int part, int custid, string promotionName, int itemidSales, int intUomid, decimal salesQty, int itemidPromotion, int pUomId, decimal promotionQty, int Enroll, DateTime dteFdate, DateTime dteTDate, int rid, int aid, int intLineid)
        {
            string msg = "";
            try
            {
                sprAccountTradeOfferEntryTableAdapter adpAccTrade = new sprAccountTradeOfferEntryTableAdapter();
                adpAccTrade.GetPromEntry(part, custid, promotionName, itemidSales, intUomid, salesQty, itemidPromotion, pUomId, promotionQty, Enroll, dteFdate, dteTDate, rid, aid, intLineid,ref msg);
            }
            catch (Exception e) { msg = e.ToString();  }
            return msg;
        }

        public string[] GetItem(string prefix)
        {
            int ysnActive = 1;
            tableItem = new ItemPromotionTDS.tblItemDataTable[Convert.ToInt32(ysnActive)];
            tblItemTableAdapter Item = new tblItemTableAdapter();
            tableItem[e] = Item.GetItemList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItem[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strProductName.ToLower().Contains(prefix)
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
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strProductName"] + "," + "[" + tbl.Rows[i]["intid"] + "]";
                }

                return retStr;
            }
            else
            {
                return null;
            }
        }

        public void getNationalPINactiveEnd(DateTime dteTdate, int itemidSales, string batchno,int custid,int part)
        {
            try
            {
                if (part == 1)
                {
                    tblSalesPromotionUpdateTableAdapter PromUpdate = new tblSalesPromotionUpdateTableAdapter();
                    PromUpdate.GetUpDateFreebyNationalInActiveEndDate(dteTdate, itemidSales, batchno);
                }
                else if (part == 2)
                {
                    tblSalesPromotionUpdateTableAdapter PromUpdate = new tblSalesPromotionUpdateTableAdapter();
                    PromUpdate.GetNationalEndDate(dteTdate, itemidSales, batchno);
                }
                else if (part == 3)
                {
                    tblSalesPromotionUpdateTableAdapter PromUpdate = new tblSalesPromotionUpdateTableAdapter();
                    PromUpdate.GetCustomerInactiveEnd(dteTdate, custid,batchno, itemidSales);
                }
                else if (part == 4)
                {
                    tblSalesPromotionUpdateTableAdapter PromUpdate = new tblSalesPromotionUpdateTableAdapter();
                    PromUpdate.GetCustomerEnd(dteTdate, custid, batchno, itemidSales);
                }


            }
            catch { }
        }

        public DataTable getUom(int unitid)
        {
            try { tblUOMTableAdapter adpUom = new tblUOMTableAdapter();
                return adpUom.GetUOM(unitid);
            } catch { return new DataTable(); }
        }

        public DataTable getRegionList()
        {
            try
            {
                qryAFBLNewSetupTableAdapter adpRegioin = new qryAFBLNewSetupTableAdapter();
                return adpRegioin.GetRegionList();

            }
            catch { return new DataTable(); }
        }
    }
}
