using System;
using System.Data;
using DAL.Accounts.AccountsVoucherJournalDetailsTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class AccountsVoucherJournalDetailsDal
    {
        public void Insert()
        {
            try
            {

            }
            catch (Exception e)
            {

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
    }
}
