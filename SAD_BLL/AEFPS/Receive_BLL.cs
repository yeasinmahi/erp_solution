using SAD_DAL.AEFPS;
using SAD_DAL.AEFPS.ReceiveTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable GetSupplierList(int mrrNo)
        {
            TblSupplierTableAdapter adp = new TblSupplierTableAdapter();
            try
            {
                return adp.GetSupplierDetails(mrrNo);
            }
            catch { return new DataTable(); }
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
        


    }
}
