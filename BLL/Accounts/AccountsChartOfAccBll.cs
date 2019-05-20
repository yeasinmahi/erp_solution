using System;
using System.Data;
using DAL.Accounts.CodeInfoTdsTableAdapters;
using DALOOP.Accounts;

namespace BLL.Accounts
{
    public class AccountsChartOfAccBll
    {
        private readonly AccountsChartOfAccDal _dal = new AccountsChartOfAccDal();
        public DataTable GetChartOfAccount(int accId)
        {
            return _dal.GetChartOfAccount(accId);
        }
        public int GetGlobalCoaId(int accId)
        {
            return _dal.GetGlobalCoaId(accId);
        }
        public string GetAccountName(int accId)
        {
            return _dal.GetAccountName(accId);
        }
        public DataTable GetChartOfAccountByGlobalCoaId(int globalCoaId)
        {
            return _dal.GetChartOfAccountByGlobalCoaId(globalCoaId);
        }
        public int GetCoaIdByGlobalCoaId(int globalCoaId)
        {
            return _dal.GetCoaIdByGlobalCoaId(globalCoaId);
        }
        public string GetAccountNameByGlobalCoaId(int globalCoaId)
        {
            return _dal.GetAccountNameByGlobalCoaId(globalCoaId);
        }
    }
}
