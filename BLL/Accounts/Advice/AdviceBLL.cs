﻿using DAL.Accounts.Advice.AdviceTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.Advice
{
    public class AdviceBLL
    {
        public DataTable GetPartyAdvice(int intAdviceType, int intActionBy, int intUnitID, DateTime dteDate, int intWork, string strAccountMandatory, string strBankName, int ysnCompleted, int intChillingID)
        {
            try
            {
                SprAdviceForBFTNTableAdapter adp = new SprAdviceForBFTNTableAdapter();
                return adp.GetPartyAdvice(intAdviceType, intActionBy, intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted, intChillingID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetUnitAddress(int intUnitID)
        {
            try
            {
                UnitAddressTableAdapter adp = new UnitAddressTableAdapter();
                return adp.GetUnitAddress(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetIBBLBank(int intUnitID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetIBBLBank(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetOtherBank(int intUnitID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetOtherBank(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAccountDetails(int intAutoID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetAccountDetails(intAutoID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAdviceData(int intActionBy)
        {
            try
            {
                AdviceDataTableAdapter adp = new AdviceDataTableAdapter();
                return adp.GetAdviceData(intActionBy);
            }
            catch { return new DataTable(); }
        }
        public void DeleteData(int intID)
        {
            try
            {
                DeleteDataTableAdapter adp = new DeleteDataTableAdapter();
                adp.DeleteAdviceData(intID);
            }
            catch { }
        }
        public void UpdateChqPrint(int intUnitID, int intActionBy)
        {
            try
            {
                TblAccountsVoucherBankTableAdapter adp = new TblAccountsVoucherBankTableAdapter();
                adp.UpdateChqPrint(intUnitID, intActionBy);
            }
            catch { }
        }
        public DataTable GetChillingCenter()
        {
            try
            {
                ChillingCenterListTableAdapter adp = new ChillingCenterListTableAdapter();
                return adp.GetChillingCenter();
            }
            catch { return new DataTable(); }
        }
    }
}
