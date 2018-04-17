using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Ledger;
using DAL.Accounts.Ledger.LedgerTDSTableAdapters;
using GLOBAL_BLL;
using System.Data;

namespace BLL.Accounts.Ledger
{
    public class LedgerC
    {
        public LedgerTDS.SprAccountsLedgerByAccountDataTable GetLedgerByID(string fromDate, string toDate, string coaID, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress,ref bool? isAssetOrLiabilities)
        {
            DateTime? frm = null, to = null;

            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value;
            }
            catch{}

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value;
            }
            catch { to = DateTime.Now.Date; }

            SprAccountsLedgerByAccountTableAdapter ta = new SprAccountsLedgerByAccountTableAdapter();
            return ta.GetData(frm, to, int.Parse(coaID), "", int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress,ref isAssetOrLiabilities);
        }

        public LedgerTDS.SprAccountsLedgerByAccountDataTable GetLedgerByCode(string fromDate, string toDate, string coaCode, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
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

            SprAccountsLedgerByAccountTableAdapter ta = new SprAccountsLedgerByAccountTableAdapter();
            return ta.GetData(frm, to, null, coaCode, int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }

        public LedgerTDS.SprAccountsLedgerByAccountDrCrDataTable GetLedgerByCodeDrCr(string fromDate, string toDate, string coaCode, string userID, string unitID, ref string accountName, ref string accountCode, ref string unitName, ref string unitAddress, ref bool? isAssetOrLiabilities)
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

            SprAccountsLedgerByAccountDrCrTableAdapter ta = new SprAccountsLedgerByAccountDrCrTableAdapter();
            return ta.GetData(frm, to, null, coaCode, int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress, ref isAssetOrLiabilities);
        }
    }
}
