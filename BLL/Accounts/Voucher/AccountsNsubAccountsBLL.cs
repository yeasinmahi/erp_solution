using DAL.Accounts.Voucher.AccountsNsubAccountsTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.Voucher
{
    public class AccountsNsubAccountsBLL
    {
        #region INIT
        private readonly AccountsNoTableAdapter accountsAdapter = new AccountsNoTableAdapter();
        #endregion

        #region A/C No
        public DataTable GetBRAccountsNumber(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetBankReceiveACNoData(1, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public DataTable GetBPAccountsNumber(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetBankPaymentACNoData(1, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public DataTable GetContraAccountsNumber(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetContraAccountsNoData(4, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        #endregion

        #region A/C Head
        public DataTable GetJVAccountsHead(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetJVAccountsHeaderData(5, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        #endregion

        #region A/C Debit/Credit
        public DataTable GetBRCreditAccountsNo(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetBRCreditAccountsData(2, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        public DataTable GetBPDebitAccountsNo(int UnitId, int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountsAdapter.GetBPDebitAccountsData(3, UnitId, Enroll);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
        #endregion

        #region Bank Receive
        public string InsertBankReceiveVoucher(int typeid,int unitid, string strXML, int accountid,string accountName, string checkNumber,
            DateTime chkReceivedate,int ysnCheck,int ysnDemandDraft, int ysnPayorder,int ysnDepositeSlip, int ysnAdvanced, int ysnAdjustment,
            int ysnOnline,string narration,decimal debitamount, decimal creditamount, string recpayfrom, int enroll)
        {
            SubAccountVoucherEntryTableAdapter adapter = new SubAccountVoucherEntryTableAdapter();
            string voucherno = string.Empty;
            try
            {
               DataTable dt = adapter.InsertSubAccountNgetVoucherID(typeid, unitid, strXML, accountid, accountName, checkNumber, chkReceivedate, ysnCheck,
                    ysnDemandDraft, ysnPayorder, ysnDepositeSlip, ysnAdvanced, ysnAdjustment, ysnOnline, narration, debitamount, creditamount,
                    recpayfrom, enroll);
                if(dt != null && dt.Rows.Count > 0)
                {
                    voucherno = dt.Rows[0]["Column1"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return voucherno;
        }
        #endregion

        #region INIT
        #endregion
    }
}
