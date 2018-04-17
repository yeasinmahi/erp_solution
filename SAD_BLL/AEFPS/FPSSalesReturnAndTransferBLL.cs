using SAD_DAL.AEFPS.FPSSalesReturnAndTransferTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD_DAL.AEFPS;

namespace SAD_BLL.AEFPS
{
    public class FPSSalesReturnAndTransferBLL
    {

        #region ===== Final Coding ================================================================
        private static FPSSalesReturnAndTransfer.SearchProductDataTable[] tableItem = null;
        int e;
        public string[] GetItemName(Int32 Active, string prefix)
        {
            tableItem = new FPSSalesReturnAndTransfer.SearchProductDataTable[Convert.ToInt32(Active)];
            SearchProductTableAdapter adp = new SearchProductTableAdapter();
            tableItem[e] = adp.ProductSearch(Convert.ToBoolean(Active));

            DataTable tbl = new DataTable();
            if (prefix.Trim().Length >= 3)
            {
                if (prefix == "" || prefix == "*")
                {
                    var rows = from tmp in tableItem[e]                       
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
                        var rows = from tmp in tableItem[e]
                                   where tmp.strName.ToLower().Contains(prefix) || tmp.strCode.ToLower().Contains(prefix) || tmp.intMasterId.ToString().ToLower().Contains(prefix)                                   
                                   orderby tmp.intMasterId
                                   select tmp;

                        if (rows.Count() > 0)
                        { tbl = rows.CopyToDataTable();}
                    }
                    catch { return null; }
                }
            }
            if (tbl.Rows.Count > 0)
            {
                string[] retStr = new string[tbl.Rows.Count];
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    retStr[i] = tbl.Rows[i]["strName"] + " [" + tbl.Rows[i]["strUoM"] + "]" + " [" + tbl.Rows[i]["strCode"] + "] [" + tbl.Rows[i]["intMasterId"] + "]";
                }
                return retStr;
            }
            else { return null; }
        }

        public DataTable GetProductStockAndPrice(int intPart, int intWHID, int intItemID, decimal monQty)
        {
            SprFPSProductPriceTableAdapter adp = new SprFPSProductPriceTableAdapter();
            try
            { return adp.GetProductPriceAndStock(intPart, intWHID, intItemID, monQty); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetTransferOutInReport(int intPart, int intWHID, int intToWHID, string strSV)
        {
            SprReportForTransferInOutSalesReturnTableAdapter adp = new SprReportForTransferInOutSalesReturnTableAdapter();
            try
            { return adp.GetTransferOutInReport(intPart, intWHID, intToWHID, strSV); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        
        public DataTable GetVoucherForTransfer(int intWHID, int intToWHID)
        {
            TblTransferMainTableAdapter adp = new TblTransferMainTableAdapter();
            try
            { return adp.GetVoucherForTransfer(intWHID, intToWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        

        #endregion ================================================================================















        public DataTable SalesRAndTransfer(int intPart, int intWHID, int intToWHID, string strSV, string xml, int intEnroll, int intInsertBy)
        {
            SprSReturnAndTransferTableAdapter adp = new SprSReturnAndTransferTableAdapter();
            try
            { return adp.SalesRAndTransfer(intPart, intWHID, intToWHID, strSV, xml, intEnroll, intInsertBy); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetReportForTransferOut(int intWHID, string strSV)
        {
            DataForTransferOutTableAdapter adp = new DataForTransferOutTableAdapter();
            try
            { return adp.GetReportForTransferOut(intWHID, strSV); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetReport(int intPart, int intWHID, string strCode)
        {
            SprReportForSalesRAndTransferTableAdapter adp = new SprReportForSalesRAndTransferTableAdapter();
            try
            { return adp.GetReport(intPart, intWHID, strCode); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public string InsertUpdate(int intPart, int intWHID, int intToWHID, int intEnroll, string strVoucher, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprInsertUpdateSalesRAndTransferTableAdapter adp = new SprInsertUpdateSalesRAndTransferTableAdapter();
                adp.InsertUpdate(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetReportBySV(string strCode, int intWHID)
        {
            GetReportBySVTableAdapter adp = new GetReportBySVTableAdapter();
            try
            { return adp.GetReportBySV(strCode, intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        #region===== New Code Start ============================================
        
        public DataTable GetDataForEntry(int intPart, int intWHID, int intEnroll)
        {
            SprFPSDataForEntryTableAdapter adp = new SprFPSDataForEntryTableAdapter();
            try
            { return adp.GetDataForEntry(intPart, intWHID, intEnroll); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDataForTransfer(int intEnroll, int intWHID)
        {
            GetDataForTransferTableAdapter adp = new GetDataForTransferTableAdapter();
            try
            { return adp.GetDataForTransfer(intEnroll, intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetMasterIDByBarcode(string strBarcode)
        {
            GetDataForTransferTableAdapter adp = new GetDataForTransferTableAdapter();
            try
            { return adp.GetMasterIDByBarcode(strBarcode); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }        
        public string InsertUpdateST(int intPart, int intWHID, int intToWHID, int intEnroll, string strVoucher, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprSalesRAndTransferInsertTableAdapter adp = new SprSalesRAndTransferInsertTableAdapter();
                adp.InsertUpdateST(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        public DataTable GetVoucherForTransferIn(int intWHID)
        {
            GetDataForTransferTableAdapter adp = new GetDataForTransferTableAdapter();
            try
            { return adp.GetVoucherForTransferIn(intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetDataForTransferIn(int intWHID, string strVoucher)
        {
            GetDataForTransferTableAdapter adp = new GetDataForTransferTableAdapter();
            try
            { return adp.GetDataForTransferIn(intWHID, strVoucher); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetReportForSalesReturn(string strVoucher, int intWHID)
        {
            GetReportSalesReturnTableAdapter adp = new GetReportSalesReturnTableAdapter();
            try
            { return adp.GetReportForSalesReturn(strVoucher, intWHID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string TransferFinalInsert(int intPart, int intWHID, int intToWHID, int intEnroll, string strVoucher, int intInsertBy, string xml)
        {
            string msg = "";
            try
            {
                SprTransferInOutTableAdapter adp = new SprTransferInOutTableAdapter();
                adp.TransferFinalInsert(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml, ref msg);
            }
            catch (Exception ex) { msg = ex.ToString(); }
            return msg;
        }
        



        #endregion ===== New Code End ==========================================











    }
}
