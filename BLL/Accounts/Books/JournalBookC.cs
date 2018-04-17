using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Books;
using DAL.Accounts.Books.JournalBookTDSTableAdapters;
using GLOBAL_BLL;

namespace BLL.Accounts.Books
{
    public class JournalBookC
    {
        public JournalBookTDS.SprAccountsBookJournalBookDataTable GetJournalBook(int unitID,int userID,string fromDate,string todate,ref string unitName,ref string unitAddress)
        {
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(todate);

            if (frm == null) { frm = DateTime.Now.Date.AddDays(-7); }
            if (to == null) { to = DateTime.Now.Date.AddDays(6); }

            SprAccountsBookJournalBookTableAdapter adp = new SprAccountsBookJournalBookTableAdapter();
            return adp.GetJournalBookData(frm, to, userID, unitID, ref unitName, ref unitAddress);
        }
    }
}
