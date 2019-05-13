using System;
using System.Data;
using DAL.Accounts.AccountsVoucherJournalTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class AccountsVoucherJournalDal
    {
        //public int Insert(string strCode, int intUnitID, string strNarration, decimal amount, int intLastActionBy,
        //        ysnPostedInSubLedger,
        //    strSecurityCode,  dtePostingSubledger)
        //{
        //    try
        //    {
        //        tblAccountsVoucherJournalTableAdapter adp = new tblAccountsVoucherJournalTableAdapter();
        //        return adp.Insert1(strCode, intUnitID, strNarration, amount, amount, intLastActionBy,
        //            DateTime.Now, true, false, 0, ysnPostedInSubLedger,
        //            strSecurityCode, DateTime.Now, dtePostingSubledger);
        //    }
        //    catch (Exception e)
        //    {
                
        //    }
        //}
        public DataTable GetJurnalVoucher(int voucherId)
        {
            try
            {
                tblAccountsVoucherJournal1TableAdapter adp = new tblAccountsVoucherJournal1TableAdapter();
                return adp.GetData(voucherId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
