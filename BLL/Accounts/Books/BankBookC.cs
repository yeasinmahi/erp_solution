using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Books;
using DAL.Accounts.Books.BankBookTDSTableAdapters;
using BLL.Accounts.Bank;
using GLOBAL_BLL;

namespace BLL.Accounts.Books
{
   public class BankBookC
    {
       public BankBookTDS.SprAccountsBookBankBookDataTable GetBankBook(string bankAccountID, string fromDate, string toDate, string unitID, bool ysnOpeningBalance, string userID, ref string accountCode, ref string accountName, ref string unitAddress, ref string unitName)
       {
           DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);
           if (frm == null) { frm = DateTime.Now.Date.AddDays(-7); }
           if (to == null) { to = DateTime.Now.Date.AddDays(6); }
                      
           int? coaID=null;
           string coaName = "";
           
           BankAccount ba = new BankAccount();
           ba.GetCOAInfoByBankAccNo(bankAccountID, unitID, ref coaID, ref coaName);
           SprAccountsBookBankBookTableAdapter adp = new SprAccountsBookBankBookTableAdapter();
           return adp.GetData(coaID, frm, to, ysnOpeningBalance, int.Parse(userID), int.Parse(unitID), ref accountName, ref accountCode, ref unitName, ref unitAddress);
       }
    }
}
