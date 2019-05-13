using System;
using System.Data;
using DAL.Accounts.AccountsVoucherJournalDetailsTdsTableAdapters;
using DAL.Accounts.AccountsVoucherJournalTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class AccountsVoucherJournalDetailsDal
    {
        private DataTable _dt;
        public int Insert(int intJournalVoucherId, int intAccId, string strNarration, decimal monAmount, string strAccName)
        {
            try
            {
                tblAccountsVoucherJournalDetailsTableAdapter adp = new tblAccountsVoucherJournalDetailsTableAdapter();
                _dt = adp.Insert1(intJournalVoucherId, intAccId, strNarration,monAmount,strAccName);
                if (_dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intID"].ToString());
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public DataTable GetJurnalVoucherDetails(int voucherId)
        {
            try
            {
                tblAccountsVoucherJournalDetails1TableAdapter adp = new tblAccountsVoucherJournalDetails1TableAdapter();
                return adp.GetData(voucherId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public DataTable GetJurnalVoucherDetails(int voucherId,int accId)
        {
            try
            {
                tblAccountsVoucherJournalDetails2TableAdapter adp = new tblAccountsVoucherJournalDetails2TableAdapter();
                return adp.GetData(voucherId,accId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
    }
}
