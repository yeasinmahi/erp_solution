﻿using System.Data;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsVoucherJournalDetailsBll
    {
        private readonly AccountsVoucherJournalDetailsDal _dal = new AccountsVoucherJournalDetailsDal();
        public int Insert(int intJournalVoucherId, int intAccId, string strNarration, decimal monAmount, string strAccName)
        {
            return _dal.Insert(intJournalVoucherId, intAccId, strNarration, monAmount, strAccName);
        }

        public DataTable GetJurnalVoucher(int voucherId)
        {
            return _dal.GetJurnalVoucherDetails(voucherId);
        }
        public DataTable GetJurnalVoucher(int voucherId,int accId)
        {
            return _dal.GetJurnalVoucherDetails(voucherId,accId);
        }
        public bool UpdateAmount(decimal amount, int jvId, int accId)
        {
            return _dal.UpdateAmount(amount, jvId, accId);
        }
    }
}