using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Bank;
using DAL.Accounts.Bank.DepositorBankTDSTableAdapters;
using System.Data;

namespace BLL.Accounts.Bank
{
    public static class DepositorBankInfo
    {
        private static DepositorBankTDS.TblBankDepositorBankInfoDataTable table = null;

        private static void Initialized()
        {
            if (table == null)
            {
                TblBankDepositorBankInfoTableAdapter ta = new TblBankDepositorBankInfoTableAdapter();
                table = ta.GetData();
            }
        }

        public static void Reload()
        {
            TblBankDepositorBankInfoTableAdapter ta = new TblBankDepositorBankInfoTableAdapter();
            table = ta.GetData();
        }
        public static string[] BankList(string prefix)
        {
            Initialized();
            prefix = prefix.Trim();
            DataTable tbl;

            try
            {
                var rows = from tmp in table
                           where tmp.intType == 1 && tmp.strInfo.ToLower().Contains(prefix.ToLower())
                           orderby tmp.strInfo
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            catch
            {
                return null;
            }

            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strInfo"].ToString();
            }

            return retStr;
        }

        public static string[] BranchList(string prefix)
        {
            Initialized();
            prefix = prefix.Trim();
            DataTable tbl;

            try
            {
                var rows = from tmp in table
                           where tmp.intType == 2 && tmp.strInfo.ToLower().Contains(prefix.ToLower())
                           orderby tmp.strInfo
                           select tmp;
                tbl = rows.CopyToDataTable();
            }
            catch
            {
                return null;
            }
            string[] retStr = new string[tbl.Rows.Count];
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                retStr[i] = tbl.Rows[i]["strInfo"].ToString();
            }

            return retStr;
        }
    }
}
