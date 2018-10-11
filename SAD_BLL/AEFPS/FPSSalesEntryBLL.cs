using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.AEFPS.FPSSalesEntryTDSTableAdapters;
using SAD_DAL.AEFPS;
using System.Data;

namespace SAD_BLL.AEFPS
{
    public class FPSSalesEntryBLL
    {
        
        int e;
        private static FPSSalesEntryTDS.tblEmployeeDataTable[] tableemp = null;
        private static FPSSalesEntryTDS.tblShopItemListSearchDataTable[] tableempItem = null;
        public string[] GetEmployeeSearch(string prefix)
        {
            int intwh = Int32.Parse("1".ToString());
            tableemp = new FPSSalesEntryTDS.tblEmployeeDataTable[intwh];
            tblEmployeeTableAdapter adpCOA = new tblEmployeeTableAdapter();
            tableemp[e] = adpCOA.GetEmployeeList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableemp[e]//Convert.ToInt32(ht[unitID])                           
                               orderby tmp.strEmployeeName
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
                        var rows = from tmp in tableemp[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strEmployeeName.ToLower().Contains(prefix) || Convert.ToString(tmp.intEmployeeID)==(prefix)
                                   orderby tmp.strEmployeeName
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

                    retStr[i] = tbl.Rows[i]["strEmployeeName"] + "[" + tbl.Rows[i]["intEmployeeID"] + "]";

                 }

                return retStr;

            }


            else
            {
                return null;
            }


        }

        public DataTable getmemoCount(int whid)
        {
            try
            {
                tblmemoCountTableAdapter getMemocount = new tblmemoCountTableAdapter();
                return getMemocount.GetData(whid);


            }
            catch { return new DataTable(); }
        }

        public DataTable getPricesPer(int part,int intWID, int intitemid, decimal salesQty)
        {
            try
            {
                sprFPSProductPriceTableAdapter getShopPrice = new sprFPSProductPriceTableAdapter();
                return getShopPrice.Getprice(part,intWID, intitemid, salesQty);


            }
            catch { return new DataTable(); }
        }

        public DataTable getShopLedger(DateTime dtefdate, DateTime dtetdate, int intWID, int partid)
        {
            try
            {
                sprShopLedgerTableAdapter shopledger = new sprShopLedgerTableAdapter();
                return shopledger.GetShopLedger(dtefdate, dtetdate, intWID, partid);
            }
            catch { return new DataTable(); }
        }

       

        public DataTable getCashbook(DateTime dtefdate, DateTime dtetdate, int intWID, int part)
        {
            try
            {
                sprCashBookTableAdapter getCashbook = new sprCashBookTableAdapter();
                return getCashbook.GetCashbook(dtefdate, dtetdate, intWID, part);


            }
            catch { return new DataTable(); }
        }

        public string getCreditEntry(int empid, DateTime dtefdate, string purpose, string narration, decimal amount, int intWID, int intInsertby)
        {
            string msg = "";
            try
            {
                sprCreditVoucherEntryTableAdapter getCashEntry = new sprCreditVoucherEntryTableAdapter();
                getCashEntry.GetEmpCreditVoucerh(empid, dtefdate, purpose, narration, amount, intWID, intInsertby);
                 msg = "Successfully";

            }
            catch (Exception){ msg = e.ToString(); }
            return msg;
        }

        public void GetVoucherEntry( DateTime dtefdate, string purpose, string narration, decimal amount, int intInsertby, int intWID)
        {
            try
            {
                sprVoucherEntryTableAdapter getInsertV = new sprVoucherEntryTableAdapter();
                getInsertV.GetVoucherEntry(dtefdate,  purpose, narration, amount, intWID, intInsertby);
            }
            catch { }
        }

        public DataTable GetDueReport(DateTime dtefdate, int intWID)
        {
            try
            {
                tblDueRptTableAdapter duerpt = new tblDueRptTableAdapter();
                return duerpt.GetDue(dtefdate, intWID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSubLedgerEmpAEFPS(DateTime dtefdate, DateTime dtetdate, int empid)
        {
            try
            {
                sprAccountsSubledgerByEmpTableAdapter getEmpsubledger = new sprAccountsSubledgerByEmpTableAdapter();
                return getEmpsubledger.GetEmpSubledgerAEFPS(dtefdate, dtetdate, empid);
            }
            catch { return new DataTable(); }
        }

        public string getSalesEntry(DateTime dtedate, int empid, int intWID, int intpaymenttype, decimal monCashReceive, decimal monCashReturn, int intInsertby)
        {
            string msg = "";
            try
            {
                sprSalesEntryTableAdapter SalesEntry = new sprSalesEntryTableAdapter();
                 SalesEntry.GetSalesEntry(dtedate, empid, intWID, intpaymenttype, monCashReceive, monCashReturn, intInsertby,ref msg);            
            }
            catch(Exception e) { msg = e.ToString(); }
            return msg;
        }

        public void getTemtableDelete(int intInsertby)
        {
            try
            {
                tblDeletefromTempAdapter getDeletetemp = new tblDeletefromTempAdapter();
                getDeletetemp.GetDeleteTemProduct(intInsertby);
            }
            catch { }
        }

        public DataTable getQRCodeinf(string qrcode)
        {
            try
            {
                tblQrcodeinfoTableAdapter getQRcodeinfo = new tblQrcodeinfoTableAdapter();
                return getQRcodeinfo.GetQRcodeResult(qrcode);
            }
            catch { return new DataTable(); }
        }

        public DataTable getSalesVoucherPrint(int empid, string msg)
        {
            try
            {
                tblSVPrintTableAdapter getSVPrint = new tblSVPrintTableAdapter();
                return getSVPrint.GetPrintSV(empid, msg);
            }
            catch { return new DataTable(); }
        }

        public DataTable getCreditAmountPurches(string v)
        {
            try
            {
                tblCreditPurchesamountTableAdapter getCreditPUrchesAmt = new tblCreditPurchesamountTableAdapter();
                return getCreditPUrchesAmt.GetCreditAmountPurcesh(int.Parse(v));
            }
            catch { return new DataTable(); }
        }

        public DataTable getEmpinfo(int empid)
        {
            try
            {
                tblemployeeinfoTableAdapter gempinfo = new tblemployeeinfoTableAdapter();
                return gempinfo.GetEmplinfo(empid);
            }
            catch { return new DataTable(); }
        }

        public DataTable getReport(int intEntryid)
        {
            try
            {
                tblSalesDetailsTem1TableAdapter getTemEntryrpt = new tblSalesDetailsTem1TableAdapter();
                return getTemEntryrpt.GetTempDeatils(intEntryid);
                
            }
            catch { return new DataTable(); }
        }

        public DataTable getWH(int intInsertby)
        {
            try
            {
                tblWHTableAdapter getWHlist = new tblWHTableAdapter();
                return getWHlist.GetShippoint(intInsertby);
            }
            catch { return new DataTable(); }
        }

        public void getinsert(string qrcode, int intitemid, string itemName, decimal qty, decimal price, decimal Amount,int intEntryid)
        {
            try
            {
                tblSalesDetailsTemTableAdapter getIsertget = new tblSalesDetailsTemTableAdapter();
                 getIsertget.GetInsertSalesEntryAEFPS(qrcode, intitemid, itemName, qty, price, Amount, intEntryid);
            }
            catch { }
        }

        public void InsertUpdateAndReport(int id)
        {
            try
            {
                DataTable1TableAdapter getDelete = new DataTable1TableAdapter();
                getDelete.GetDelete(id);
            }
            catch { }
        }

        public DataTable getInventoryStock(int intitemid, int intWHID)
        {
            try
            {
                tblInvstockTableAdapter getInvstock = new tblInvstockTableAdapter();
                return getInvstock.GetStockInv(intitemid, intWHID);
            }
            catch { return new DataTable(); }
        }

        public DataTable getPrices(string qrcode,decimal SalesQty)
        {
            try
            {
                sprPriceTableAdapter getPrices = new sprPriceTableAdapter();
                return getPrices.GetPrice(qrcode, SalesQty);
            }
            catch { return new DataTable(); }
        }

        public DataTable getQRCodeforitem(string qrcode)
        {
            
            try
            {
                tblShopItemListTableAdapter getQRItemList = new tblShopItemListTableAdapter();
                return getQRItemList.GetQRCodeItemid((qrcode));
            }
            catch { return new DataTable(); }
        }

        public string[] GetItemSearch(string prefix)
        {

            int intwh = Int32.Parse("1".ToString());
            //Inatialize(intwh);
            tableempItem = new FPSSalesEntryTDS.tblShopItemListSearchDataTable[intwh];
            tblShopItemListSearchTableAdapter adpCOA = new tblShopItemListSearchTableAdapter();
            tableempItem[e] = adpCOA.GetItemList();

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)

            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableempItem[e]//Convert.ToInt32(ht[unitID])                           
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
                        var rows = from tmp in tableempItem[e]  //[Convert.ToInt32(ht[WHID])]
                                   where tmp.strName.ToLower().Contains(prefix) || Convert.ToString(tmp.intMasterId).ToLower().Contains(prefix)
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

            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    retStr[i] = tbl.Rows[i]["strName"] + "[" + tbl.Rows[i]["intMasterId"] + "]";

                    //retStr[i] = tbl.Rows[i]["strItem"] +"[" + "Stock:" + " " + tbl.Rows[i]["monstock"] + " " + tbl.Rows[i]["strUom"] + "]" ;
                }

                return retStr;

            }


            else
            {
                return null;
            }

        }

        public DataTable getEmpCheck(string whid, string Enroll)
        {
            try
            {
                sprEmpCheckTableAdapter adp = new sprEmpCheckTableAdapter();
                return adp.GetEmployeeCheck(int.Parse(whid),int.Parse(Enroll));
            }
            catch { return new DataTable(); }
        }

        public DataTable getItembyQRcode(int intitemid)
        {
            try
            {
                tblShopItemList1TableAdapter getQRItemList = new tblShopItemList1TableAdapter();
                return getQRItemList.GetItemByBRCode((intitemid));
            }
            catch { return new DataTable(); }
        }
    }
}
