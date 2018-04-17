using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Books;
using DAL.Accounts.Books.CashBookTDSTableAdapters;
using GLOBAL_BLL;

namespace BLL.Accounts.Books
{
    public class CashBookC
    {
        public CashBookTDS.SprAccountsBookCashBookDataTable GetCashBook(string fromDate, string toDate, int unitID,bool ysnOpeningBalance,int userID, ref string unitAddress, ref string unitName)
        {
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);

            if (frm == null) { frm = DateTime.Now.Date.AddDays(-7); }
            if (to == null) { to = DateTime.Now.Date.AddDays(6); }

            SprAccountsBookCashBookTableAdapter adp = new SprAccountsBookCashBookTableAdapter();
            return adp.GetCashBookData(frm, to, ysnOpeningBalance, userID, unitID, ref unitName, ref unitAddress);
        }
    }
}
