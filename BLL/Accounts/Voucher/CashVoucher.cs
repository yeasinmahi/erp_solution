using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher.CashVoucherTDSTableAdapters;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.CashVoucherPrintTDSTableAdapters;
using BLL.Accounts.SubLedger;
using GLOBAL_BLL;

namespace BLL.Accounts.Voucher
{
    public class CashVoucher
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdateDr(string xml,ref string voucherID, string userID, string unitID, string narration, string payTo, string payToPrint, DateTime voucherDate, ref string code)
        {
            SprAccountsVoucherCashInsertUpdateTableAdapter ta = new SprAccountsVoucherCashInsertUpdateTableAdapter();
            payToPrint = payToPrint.Trim();

            int? pt = null;
            try { pt = int.Parse(payTo.Trim()); }
            catch { }

            long? vid = null;
            if (voucherID == "" || voucherID == null) vid = null;
            else vid = long.Parse(voucherID);

            ta.GetData(xml
                , ref vid
                , int.Parse(userID), int.Parse(unitID)
                , narration
                , true, false, true, null, pt, payToPrint, "", voucherDate,ref code);

            voucherID = vid.ToString();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdateCr(string xml,ref string voucherID, string userID, string unitID, string narration, string receivedFrom, string receivedFromPrint, DateTime voucherDate, ref string code)
        {
            int? rf = null;
            try { rf = int.Parse(receivedFrom.Trim()); }
            catch { }

            long? vid = null;
            if (voucherID == "" || voucherID == null) vid = null;
            else vid = long.Parse(voucherID);

            SprAccountsVoucherCashInsertUpdateTableAdapter ta = new SprAccountsVoucherCashInsertUpdateTableAdapter();
            ta.GetData(xml
                , ref vid
                , int.Parse(userID), int.Parse(unitID)
                , narration
                , true, false, false
                , rf, null, "", receivedFromPrint, voucherDate,ref code);

            voucherID = vid.ToString();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherTDS.SprAccountsVoucherCashGetDataDataTable GetCashVoucherList(string unitID, bool completed, bool active, bool isDrVoucher, string fromDate, string toDate, string code, bool isByCode)
        {
            if (!isByCode) { code = null; }            
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);

            if (active && !completed)
            {
                if (frm == null) { frm = DateTime.Now.Date.AddDays(-1000); }
                if (to == null) { to = DateTime.Now.Date.AddDays(1000); }
            }
            else
            {
                if (frm == null) { frm = DateTime.Now.Date.AddDays(-7); }
                if (to == null) { to = DateTime.Now.Date.AddDays(6); }
            }

            to = to.Value.AddDays(1);

            SprAccountsVoucherCashGetDataTableAdapter ta = new SprAccountsVoucherCashGetDataTableAdapter();
            return ta.GetData(code, int.Parse(unitID), active, completed, frm, to, isDrVoucher);
        }
               

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherTDS.TblAccountsVoucherCashDataTable GetCashVoucherByID(string voucherID)
        {
            TblAccountsVoucherCashTableAdapter ta = new TblAccountsVoucherCashTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherTDS.TblAccountsVoucherCashDataTable GetCashVoucherByCode(string code,string unitId)
        {
            TblAccountsVoucherCashTableAdapter ta = new TblAccountsVoucherCashTableAdapter();
            return ta.GetDataByCode(code, int.Parse(unitId));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void CancelVoucher(string userID, string voucherID)
        {
            TblAccountsVoucherCashTableAdapter ta = new TblAccountsVoucherCashTableAdapter();
            ta.VoucherCancel(int.Parse(userID), long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int CompleteVoucher(string userID, string voucherID)
        {
            TblAccountsVoucherCashTableAdapter ta = new TblAccountsVoucherCashTableAdapter();
            return ta.VoucherComplete(int.Parse(userID), long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int FinishedVoucher(string userID, string voucherID)
        {
            TblAccountsVoucherCashTableAdapter ta = new TblAccountsVoucherCashTableAdapter();
            return ta.VoucherFinished(int.Parse(userID), long.Parse(voucherID));
        }


        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherTDS.QryAccountsVoucherCashDetailsDataTable GetCashVoucherDetailsByID(string voucherID)
        {
            QryAccountsVoucherCashDetailsTableAdapter ta = new QryAccountsVoucherCashDetailsTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintMRDataDataTable GetCashMRPrintData(string voucherID, string userID)
        {
            SprAccountsVoucherCashGetPrintMRDataTableAdapter ta = new SprAccountsVoucherCashGetPrintMRDataTableAdapter();
            CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintMRDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID));

            return table;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintVoucherDataDataTable GetCashVoucherPrintData(string voucherID, string userID
            ,ref string voucherCode, ref string narration, ref decimal amount
            , ref string unit, ref string unitAddress, ref string securityCode, ref DateTime? voucherDate, ref string unitID)
        {
            decimal? amount_ = null;
            int? untID = null;

            SprAccountsVoucherCashGetPrintVoucherDataTableAdapter ta = new SprAccountsVoucherCashGetPrintVoucherDataTableAdapter();
            CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintVoucherDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID), ref voucherCode, ref narration, ref amount_, ref unit, ref unitAddress,ref securityCode,ref voucherDate,ref untID);

            amount = (decimal)amount_;
            unitID = untID.ToString();

            return table;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveDr(string voucherID, string unitID, string userID, string date)
        {
            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.CashPay, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveCr(string voucherID, string unitID, string userID, string date)
        {
            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.CashReceive, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterCompleteDr(string xml, string voucherID, string userID, string narration, string unitID)
        {
            SprAccountsVoucherCashEditAfterCompleteTableAdapter ta = new SprAccountsVoucherCashEditAfterCompleteTableAdapter();
            ta.GetData(xml, long.Parse(voucherID), int.Parse(userID), narration, true, int.Parse(unitID), SubLedgerType.SubLedgerInputTypes.CashPay.ToString());
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterCompleteCr(string xml, string voucherID, string userID, string narration, string unitID)
        {
            SprAccountsVoucherCashEditAfterCompleteTableAdapter ta = new SprAccountsVoucherCashEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(voucherID), int.Parse(userID), narration, false, int.Parse(unitID),tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.CashReceive));
        }
    }
}
