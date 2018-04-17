using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher.JournalVoucherTDSTableAdapters;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.JournalVoucherPrintTDSTableAdapters;
using BLL.Accounts.SubLedger;
using GLOBAL_BLL;
using DAL.Accounts.Voucher.VoucherUploadTDSTableAdapters;

namespace BLL.Accounts.Voucher
{
    public class JournalVoucher
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void InsertUpdate(string xml,ref string voucherID, string userID, string unitID, string narration, DateTime voucherDate, ref string code)
        {
            long? vid = null;
            if (voucherID == "" || voucherID == null) vid = null;
            else vid = long.Parse(voucherID);

            SprAccountsVoucherJournalInsertUpdateTableAdapter ta = new SprAccountsVoucherJournalInsertUpdateTableAdapter();
            ta.GetData(xml
                , ref vid
                , int.Parse(userID), int.Parse(unitID)
                , narration
                , true, false, voucherDate,ref code);

            voucherID = vid.ToString();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public JournalVoucherTDS.SprAccountsVoucherJournalGetDataDataTable GetJournalVoucherList(string unitID, bool completed, bool active, string fromDate, string toDate, string code, bool isByCode)
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


            SprAccountsVoucherJournalGetDataTableAdapter ta = new SprAccountsVoucherJournalGetDataTableAdapter();            
            return ta.GetData(code, int.Parse(unitID), active, completed, frm, to);
        }

                
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public JournalVoucherTDS.TblAccountsVoucherJournalDataTable GetJournalVoucherByID(string voucherID)
        {
            TblAccountsVoucherJournalTableAdapter ta = new TblAccountsVoucherJournalTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }


        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public JournalVoucherTDS.TblAccountsVoucherJournalDataTable GetJournalVoucherByCode(string code,string unitId)
        {
            TblAccountsVoucherJournalTableAdapter ta = new TblAccountsVoucherJournalTableAdapter();
            return ta.GetDataByCode(code, int.Parse(unitId));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int CancelVoucher(string userID, string voucherID)
        {
            TblAccountsVoucherJournalTableAdapter ta = new TblAccountsVoucherJournalTableAdapter();
            return ta.VoucherCancel(int.Parse(userID), long.Parse(voucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public int CompleteVoucher(string userID, string voucherID)
        {
            TblAccountsVoucherJournalTableAdapter ta = new TblAccountsVoucherJournalTableAdapter();
            return ta.VoucherComplete(int.Parse(userID), long.Parse(voucherID));
        }


        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public JournalVoucherTDS.QryAccountsVoucherJournalDetailsDataTable GetJournalVoucherDetailsByID(string voucherID)
        {
            QryAccountsVoucherJournalDetailsTableAdapter ta = new QryAccountsVoucherJournalDetailsTableAdapter();
            return ta.GetDataByID(long.Parse(voucherID));
        }

        

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public JournalVoucherPrintTDS.SprAccountsVoucherJournalGetPrintVoucherDataDataTable GetJournalVoucherPrintData(string voucherID, string userID
            ,ref string voucherCode, ref string narration, ref decimal amountDr, ref decimal amountCr
            , ref string unit, ref string unitAddress,ref string securityCode,ref DateTime? voucherDate,ref string unitID)
        {
            decimal? amountDr_ = null, amountCr_ = null;
            int? untID = null;

            SprAccountsVoucherJournalGetPrintVoucherDataTableAdapter ta = new SprAccountsVoucherJournalGetPrintVoucherDataTableAdapter();
            JournalVoucherPrintTDS.SprAccountsVoucherJournalGetPrintVoucherDataDataTable table = ta.GetData(long.Parse(voucherID), int.Parse(userID), ref voucherCode, ref narration, ref amountDr_, ref amountCr_, ref unit, ref unitAddress, ref securityCode, ref voucherDate, ref untID);

            amountDr = (decimal)amountDr_;
            amountCr = (decimal)amountCr_;
            unitID = untID.ToString();

            return table;
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void Save(string voucherID, string unitID, string userID, string date)
        {
            SubLedger.SubLedgerC sl = new SubLedger.SubLedgerC();
            sl.SaveSubLedger(SubLedgerType.SubLedgerInputTypes.Journal, voucherID, unitID, userID, date);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void SaveAfterComplete(string xml, string voucherID, string userID, string narration, string unitID)
        {
            SprAccountsVoucherJournalEditAfterCompleteTableAdapter ta = new SprAccountsVoucherJournalEditAfterCompleteTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(xml, long.Parse(voucherID), int.Parse(userID), narration, int.Parse(unitID),tp.GetKeyForType(SubLedgerType.SubLedgerInputTypes.Journal));
        }

        public void VoucherDocUpload(string voucherCode, string voucherID, string voucherFile, int unit)
        {
            try
            {
                TblAccountsVoucherUploadTableAdapter adpUpload = new TblAccountsVoucherUploadTableAdapter();
                adpUpload.VoucherUploadData(voucherCode, voucherID, voucherFile, unit);
            }
            catch { }
            
        }
    }
}
