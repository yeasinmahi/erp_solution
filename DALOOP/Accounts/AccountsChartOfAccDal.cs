using System;
using System.Data;
using DAL.Accounts.AccountsChartOfAccTdsTableAdapters;

namespace DALOOP.Accounts
{
    public class AccountsChartOfAccDal
    {
        private DataTable _dt;
        public DataTable GetChartOfAccount(int accId)
        {
            try
            {
                tblAccountsChartOfAccTableAdapter adp = new tblAccountsChartOfAccTableAdapter();
                return adp.GetData(accId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
       
        public int GetGlobalCoaId(int accId)
        {
            try
            {
                _dt = GetChartOfAccount(accId);
                if (_dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intGlobalCOAID"].ToString());
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public string GetAccountName(int accId)
        {
            try
            {
                _dt = GetChartOfAccount(accId);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.Rows[0]["strAccName"].ToString();
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
        public DataTable GetChartOfAccountByGlobalCoaId(int globalCoaId)
        {
            try
            {
                tblAccountsChartOfAcc1TableAdapter adp = new tblAccountsChartOfAcc1TableAdapter();
                return adp.GetData(globalCoaId);
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }
        public int GetCoaIdByGlobalCoaId(int globalCoaId)
        {
            try
            {
                _dt = GetChartOfAccountByGlobalCoaId(globalCoaId);
                if (_dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(_dt.Rows[0]["intAccID"].ToString());
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public string GetAccountNameByGlobalCoaId(int globalCoaId)
        {
            try
            {
                _dt = GetChartOfAccountByGlobalCoaId(globalCoaId);
                if (_dt.Rows.Count > 0)
                {
                    return _dt.Rows[0]["strAccName"].ToString();
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
