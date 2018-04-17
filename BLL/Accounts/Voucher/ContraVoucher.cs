using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.ContraVoucherTDSTableAdapters;
using BLL.Accounts.SubLedger;
using DAL.Accounts.Voucher.ContraVoucherPrintTDSTableAdapters;
using GLOBAL_BLL;

namespace BLL.Accounts.Voucher
{
    public class ContraVoucher
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdateContraBC(string xmlString,ref string contraVoucherID, string unitID, string bankID, string bankAccountID, string narration, string userID
            , DateTime voucherDate, ref string code,string chequeNo,bool isCheque, bool isAdvance, bool isAdjustment,DateTime chequeDate, string name,bool isManualChqEntry)
        {
            long? vid = null;
            if (contraVoucherID == "" || contraVoucherID == null) vid = null;
            else vid = long.Parse(contraVoucherID);

            SprAccountsVoucherContraInsertUpdateTableAdapter ta = new SprAccountsVoucherContraInsertUpdateTableAdapter();
            ta.GetData(xmlString, ref vid, int.Parse(userID), int.Parse(unitID), int.Parse(bankID), int.Parse(bankAccountID), narration, true, false, true, voucherDate, 0, ref code, chequeNo, isCheque, isAdvance, isAdjustment, chequeDate, name, isManualChqEntry);

            if (vid == null) vid = 0;

            contraVoucherID = vid.ToString();
        }
        public void InsertUpdateContraCB(string xmlString, ref string contraVoucherID, string unitID, string bankID, string bankAccountID, string narration, string userID, DateTime voucherDate, ref string code, string name)
        {
            long? vid = null;
            if (contraVoucherID == "" || contraVoucherID == null) vid = null;
            else vid = long.Parse(contraVoucherID);

            SprAccountsVoucherContraInsertUpdateTableAdapter ta = new SprAccountsVoucherContraInsertUpdateTableAdapter();
            ta.GetData(xmlString, ref vid, int.Parse(userID), int.Parse(unitID), int.Parse(bankID), int.Parse(bankAccountID), narration, true, false, false, voucherDate, 1, ref code, "", false, false, true, DateTime.Now, name, true);
            
            if (vid == null) vid = 0;
            
            contraVoucherID = vid.ToString();
        }
        public void InsertUpdateContraBB(string xmlString, ref string contraVoucherID, string unitID, string bankID, string bankAccountID, string narration, string userID, DateTime voucherDate, bool isDR, ref string code, string chequeNo, bool isCheque, bool isAdvance, bool isAdjustment, DateTime chequeDate, string name, bool isManualChqEntry)
        {
            long? vid = null;
            if (contraVoucherID == "" || contraVoucherID == null) vid = null;
            else vid = long.Parse(contraVoucherID);

            SprAccountsVoucherContraInsertUpdateTableAdapter ta = new SprAccountsVoucherContraInsertUpdateTableAdapter();
            ta.GetData(xmlString, ref vid, int.Parse(userID), int.Parse(unitID), int.Parse(bankID), int.Parse(bankAccountID), narration, true, false, isDR, voucherDate, 2, ref code, chequeNo, isCheque, isAdvance, isAdjustment, chequeDate, name, isManualChqEntry);

            if (vid == null) vid = 0;

            contraVoucherID = vid.ToString();
        }
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int CancelContra(string userID, string contraVoucherID)
        {
            SprAccountsVoucherContraCancelTableAdapter ta = new SprAccountsVoucherContraCancelTableAdapter();
            ta.GetData(long.Parse(contraVoucherID), int.Parse(userID));
            return 0;
            //QryAccountsVoucherContraTableAdapter ta = new QryAccountsVoucherContraTableAdapter();
            //return ta.Cancel(int.Parse(userID), long.Parse(contraVoucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int CompleteContra(string userID, string contraVoucherID)
        {
            QryAccountsVoucherContraTableAdapter ta = new QryAccountsVoucherContraTableAdapter();
            return ta.Complete(int.Parse(userID), long.Parse(contraVoucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ContraVoucherTDS.SprAccountsVoucherContraGetDataDataTable GetContraVoucherList(string unitID, bool completed, bool active, string type, string fromDate, string toDate, string code, bool isByCode)
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

            SprAccountsVoucherContraGetDataTableAdapter ta = new SprAccountsVoucherContraGetDataTableAdapter();
            return ta.GetData(code, int.Parse(unitID), active, completed, frm, to, int.Parse(type));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ContraVoucherTDS.QryAccountsVoucherContraDataTable GetContraVoucherByID(string voucherID)
        {
            QryAccountsVoucherContraTableAdapter ta = new QryAccountsVoucherContraTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ContraVoucherTDS.QryAccountsVoucherContraDataTable GetContraVoucherByCode(string code,string unitId)
        {
            QryAccountsVoucherContraTableAdapter ta = new QryAccountsVoucherContraTableAdapter();
            return ta.GetDataByCode(code, int.Parse(unitId));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public ContraVoucherTDS.TblAccountsVoucherContraDetailsDataTable GetContraVoucherDetailsByID(string voucherID)
        {
            TblAccountsVoucherContraDetailsTableAdapter ta = new TblAccountsVoucherContraDetailsTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void Save(string voucherID, string unitID, string userID, string date)
        {
            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.Contra, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterCompleteBC(string xml, string contraVoucherID, decimal amount, string narration, string userID,string unitID)
        {
            SprAccountsVoucherContraEditAfterCompleteTableAdapter ta = new SprAccountsVoucherContraEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(contraVoucherID), int.Parse(userID), narration,true, int.Parse(unitID),tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.Contra));
        }
        public void SaveAfterCompleteCB(string xml, string contraVoucherID, decimal amount, string narration, string userID, string unitID)
        {
            SprAccountsVoucherContraEditAfterCompleteTableAdapter ta = new SprAccountsVoucherContraEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(contraVoucherID), int.Parse(userID), narration, false, int.Parse(unitID), tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.Contra));
        }
        public void SaveAfterCompleteBB(string xml, string contraVoucherID, decimal amount, string narration, string userID, string unitID)
        {
            SprAccountsVoucherContraEditAfterCompleteTableAdapter ta = new SprAccountsVoucherContraEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(contraVoucherID), int.Parse(userID), narration, false, int.Parse(unitID), tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.Contra));
        }

        public ContraVoucherPrintTDS.SprAccountsVoucherContraGetPrintVoucherDataDataTable GetContraVoucherPrintData(string voucherID, string userID
            , ref string voucherCode, ref string narration, ref decimal amount
            , ref string unit, ref string unitAddress, ref string securityCode, ref DateTime? voucherDate, ref string unitID,ref string bankName,ref string bankAccountNo, ref string chequeNo, ref DateTime? chequeDate)
        {
            decimal? amount_ = null;
            int? untID = null;

            SprAccountsVoucherContraGetPrintVoucherDataTableAdapter ta = new SprAccountsVoucherContraGetPrintVoucherDataTableAdapter();
            ContraVoucherPrintTDS.SprAccountsVoucherContraGetPrintVoucherDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID), ref voucherCode, ref narration, ref amount_, ref unit, ref unitAddress, ref securityCode, ref voucherDate, ref bankName, ref bankAccountNo, ref chequeNo, ref chequeDate, ref untID);

            amount = (decimal)amount_;
            unitID = untID.ToString();
            return table;

        }
    }
}
