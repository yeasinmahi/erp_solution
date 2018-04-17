using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.BalanceSheet;
using DAL.Accounts.BalanceSheet.BalanceSheetTDSTableAdapters;

namespace BLL.Accounts.BalanceSheet
{
    public class BalanceSheetC
    {

        public BalanceSheetTDS.SprAccountsBalanceSheetDataTable GetBalanceSheet(DateTime fromDate, DateTime toDate, bool ysnAccountingPeriod, int unitID, int userID, ref string unitName, ref string unitAddress)
        {
            SprAccountsBalanceSheetTableAdapter adp = new SprAccountsBalanceSheetTableAdapter();
            return adp.GetBalanceSheetData(fromDate, toDate, ysnAccountingPeriod, unitID, userID, ref unitName, ref unitAddress);
        }


    }
}
