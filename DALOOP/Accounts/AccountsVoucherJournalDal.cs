using System;
using System.Data;
using DAL.Accounts.AccountsVoucherJournalTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class AccountsVoucherJournalDal
    {
        private DataTable _dt;
        public int Insert(string strCode, int intUnitId, string strNarration, decimal amount, int intLastActionBy, string strSecurityCode, string dtePostingSubledger)
        {
            try
            {
                tblAccountsVoucherJournalTableAdapter adp = new tblAccountsVoucherJournalTableAdapter();
                _dt = adp.Insert1(strCode, intUnitId, strNarration, amount, amount, intLastActionBy,DateTime.Now, true, false, 0, false,strSecurityCode, DateTime.Now, dtePostingSubledger);
                if (_dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intJournalVoucherID"].ToString());
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
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
        public DataTable GetJurnalVoucher(int voucherId,DateTime voucherDate)
        {
            try
            {
                tblAccountsVoucherJournal2TableAdapter adp = new tblAccountsVoucherJournal2TableAdapter();
                return adp.GetData(voucherId,voucherDate);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
