using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.BankVoucherTDSTableAdapters;
using System.Xml;
using DAL.Accounts.Voucher.BankVoucherPrintTDSTableAdapters;
using BLL.Accounts.SubLedger;
using BLL.Accounts.Bank;
using GLOBAL_BLL;


namespace BLL.Accounts.Voucher
{
    public class BankVoucher
    {

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdateDr(string xml,ref string voucherID, string userID, string unitID, string bankID, string bnkAccID, string chequeNo, DateTime chequeDate, string narration, bool isCheque, bool isAdvance, bool isAdjustment, string payTo, string payToPrint, DateTime voucherDate,bool isManualChqEntry,string remarks, ref string code)
        {
            SprAccountsVoucherBankInsertUpdateTableAdapter ta = new SprAccountsVoucherBankInsertUpdateTableAdapter();
            payToPrint = payToPrint.Trim();

            bool? isNeedReloadDepositor = false;

            long? vid = null;
            if (voucherID == "" || voucherID == null) vid = null;
            else vid = long.Parse(voucherID);

            ta.GetData(xml
                , ref vid
                , int.Parse(userID), int.Parse(unitID)
                , int.Parse(bankID)
                , int.Parse(bnkAccID)
                , chequeNo, chequeDate, narration
                , true, false, true, isCheque
                , false, false, false, isAdvance, isAdjustment
                , payToPrint, "", voucherDate, isManualChqEntry,"","","",remarks,false, ref isNeedReloadDepositor, ref code);

            if (vid == null) vid = 0;
            voucherID = vid.ToString();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdateCr(string xml, ref string voucherID, string userID, string unitID, string bankID, string bnkAccID, string chequeNo, DateTime chequeDate, string narration, bool isCheque, bool isDemandDraft, bool isPayOrder, bool isDepositSlip, bool isAdvance, bool isAdjustment,bool isOnline, string receiveFromPrint, DateTime voucherDate, string depositorBank, string depositorBranch, string depositorDrawn, string remarks, ref string code)
        {
            bool? isNeedReloadDepositor = false;
            long? vid = null;
            if (voucherID == "" || voucherID == null) vid = null;
            else vid = long.Parse(voucherID);

            SprAccountsVoucherBankInsertUpdateTableAdapter ta = new SprAccountsVoucherBankInsertUpdateTableAdapter();
            ta.GetData(xml
                , ref vid
                , int.Parse(userID), int.Parse(unitID)
                , int.Parse(bankID)
                , int.Parse(bnkAccID)
                , chequeNo, chequeDate, narration
                , true, false, false, isCheque, isDemandDraft, isDepositSlip, isPayOrder, isAdvance, isAdjustment
                , "", receiveFromPrint, voucherDate, true, depositorBank, depositorBranch, depositorDrawn, remarks,isOnline, ref isNeedReloadDepositor, ref code);

            if (isNeedReloadDepositor == true)
            {
                DepositorBankInfo.Reload();
            }

            if (vid == null) vid = 0;
            voucherID = vid.ToString();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherTDS.SprAccountsVoucherBankGetDataDataTable GetBankVoucherList(string unitID,bool completed,bool active,bool isDrVoucher, string fromDate, string toDate,bool isChequeDate,string code, bool isByCode)
        {
            if (!isByCode) code = null;
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

            SprAccountsVoucherBankGetDataTableAdapter ta = new SprAccountsVoucherBankGetDataTableAdapter();
            return ta.GetData(code, int.Parse(unitID), active, completed, isChequeDate, frm, to, isDrVoucher);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherTDS.QryAccountsVoucherBankDataTable GetBankVoucherByID(string voucherID)
        {
            QryAccountsVoucherBankTableAdapter ta = new QryAccountsVoucherBankTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherTDS.QryAccountsVoucherBankDataTable GetBankVoucherByCode(string code,string unitId)
        {
            QryAccountsVoucherBankTableAdapter ta = new QryAccountsVoucherBankTableAdapter();
            return ta.GetDataByCode(code, int.Parse(unitId));
        }
        
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void VoucherCancel(string voucherID, string userID)
        {            
            SprAccountsVoucherBankCancelTableAdapter ta = new SprAccountsVoucherBankCancelTableAdapter();
            ta.GetData(long.Parse(voucherID), int.Parse(userID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void ChangeChequeNo(string voucherID, string userID)
        {
            SprAccountsVoucherBankChangeCheckNoTableAdapter ta = new SprAccountsVoucherBankChangeCheckNoTableAdapter();
            ta.GetData(long.Parse(voucherID), int.Parse(userID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int VoucherComplete(string voucherID, string userID)
        {
            QryAccountsVoucherBankTableAdapter ta = new QryAccountsVoucherBankTableAdapter();
            return ta.VoucherComplete(int.Parse(userID), long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int VoucherFinished(string voucherID, string userID)
        {
            QryAccountsVoucherBankTableAdapter ta = new QryAccountsVoucherBankTableAdapter();
            return ta.VoucherFinished(int.Parse(userID), long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherTDS.QryAccountsVoucherBankDetailsDataTable GetBankVoucherDetailsByID(string voucherID)
        {
            QryAccountsVoucherBankDetailsTableAdapter ta = new QryAccountsVoucherBankDetailsTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeDataDataTable GetBankChequePrintData(string voucherID, string userID,string type)
        {
            string tp = type.ToLower().StartsWith("b") ? "bn" : "cn";
            SprAccountsVoucherBankGetPrintChequeDataTableAdapter ta = new SprAccountsVoucherBankGetPrintChequeDataTableAdapter();
            BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID), tp);
                        
            return table;
        }
        

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintMRDataDataTable GetBankMRPrintData(string voucherID, string userID)
        {
            SprAccountsVoucherBankGetPrintMRDataTableAdapter ta = new SprAccountsVoucherBankGetPrintMRDataTableAdapter();
            BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintMRDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID));

            return table;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintVoucherDataDataTable GetBankVoucherPrintData(string voucherID, string userID
            ,ref string bankName,ref string accountNo,ref string chequeNo,ref DateTime chequeDate,ref string voucherCode,ref string narration,ref decimal amount
            , ref string unit, ref string unitAddress, ref string securityCode, ref DateTime? voucherDate, ref string unitID,ref string chequeString)
        {
            DateTime? chequeDate_ = null;
            decimal? amount_ = null;
            int? untID = null;

            SprAccountsVoucherBankGetPrintVoucherDataTableAdapter ta = new SprAccountsVoucherBankGetPrintVoucherDataTableAdapter();
            BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintVoucherDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID), ref bankName, ref accountNo, ref chequeNo, ref chequeDate_, ref voucherCode, ref narration, ref amount_, ref unit, ref unitAddress, ref securityCode, ref voucherDate, ref untID,ref chequeString);

            chequeDate = (DateTime)chequeDate_;
            amount = (decimal)amount_;
            unitID = untID.ToString();

            return table;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveDr(string voucherID, string unitID, string userID,string date)
        {

            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.BankPay, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveCr(string voucherID, string unitID, string userID, string date)
        {
            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.BankReceive, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterCompleteDr(string xml, string voucherID, string userID, string narration, string unitID)
        {
            SprAccountsVoucherBankEditAfterCompleteTableAdapter ta = new SprAccountsVoucherBankEditAfterCompleteTableAdapter();
            ta.GetData(xml, long.Parse(voucherID), int.Parse(userID), narration, true, int.Parse(unitID), SubLedgerType.SubLedgerInputTypes.BankPay.ToString());
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterCompleteCr(string xml, string voucherID, string userID, string narration, string unitID)
        {
            SprAccountsVoucherBankEditAfterCompleteTableAdapter ta = new SprAccountsVoucherBankEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(voucherID), int.Parse(userID), narration, false, int.Parse(unitID),tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.BankReceive));
        }
    }
}
