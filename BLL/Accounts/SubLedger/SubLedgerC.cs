using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.SubLedger.SubLedgerFromVoucherTDSTableAdapters;
using DAL.Accounts.SubLedger;
using DAL.Accounts.SubLedger.SubLedgerTDSTableAdapters;
using DAL.Accounts.SubLedger.SubLedgerCodeRangeTDSTableAdapters;
using GLOBAL_BLL;


namespace BLL.Accounts.SubLedger
{
    public class SubLedgerC
    {
        public void SaveSubLedger(SubLedgerType.SubLedgerInputTypes type,string voucherID,string unitID, string userID,string transDate)
        {
            SprAccountsSubledgerEntryFromVoucherTableAdapter ta = new SprAccountsSubledgerEntryFromVoucherTableAdapter();
            SubLedgerType tp = new SubLedgerType();
            ta.GetData(tp.GetKeyForType(type), long.Parse(voucherID), int.Parse(unitID), int.Parse(userID), DateFormat.GetDateAtSQLDateFormat(transDate));
        }

        public SubLedgerTDS.SprAccountsSubledgerByAccountDataTable GetSubLedgerByID(string fromDate, string toDate, string coaID, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            SprAccountsSubledgerByAccountTableAdapter ta = new SprAccountsSubledgerByAccountTableAdapter();
            return ta.GetData(frm, to, int.Parse(coaID), "", int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }

        public SubLedgerTDS.SprAccountsSubledgerByAccountDataTable GetSubLedgerByCode(string fromDate, string toDate, string coaCode, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            SprAccountsSubledgerByAccountTableAdapter ta = new SprAccountsSubledgerByAccountTableAdapter();
            return ta.GetData(frm, to, null, coaCode, int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }

        public SubLedgerCodeRangeTDS.SprAccountsSubledgerByAccountCodeRangeDataTable GetSubLedgerByCodeRange(string fromDate, string toDate, string coaCodeFrom, string coaCodeTo, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch { }

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.AddDays(1);
            }
            catch { to = DateTime.Now.Date.AddDays(1); }

            SprAccountsSubledgerByAccountCodeRangeTableAdapter ta = new SprAccountsSubledgerByAccountCodeRangeTableAdapter();
            return ta.GetData(frm, to, coaCodeFrom, coaCodeTo, int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }
       
    }
}
