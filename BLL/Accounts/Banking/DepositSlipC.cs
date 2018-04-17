using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.DepositSlipTDSTableAdapters;

namespace BLL.Accounts.Banking
{
    public class DepositSlipC 
    {
        public DepositSlipTDS.SprAccountsVoucherBankGetDepositSlipDataTable GetAllDatas(string userID, string unitID, string bankID, string branchID, string accountID, DateTime fromDate, DateTime toDate, bool isChq, bool isDD, bool isPO, bool isDS, bool isAdj, bool isAdv,ref decimal totalAmount, ref string unitName, ref string unitAddress)
        {
            int? bnk, brn, acc;
            try { bnk = int.Parse(bankID); if (bnk == 0)bnk = null; }
            catch { bnk = null; }

            try { brn = int.Parse(branchID); if (brn == 0)brn = null; }
            catch { brn = null; }

            try { acc = int.Parse(accountID); if (acc == 0)acc = null; }
            catch { acc = null; }

            decimal? tot = null;            

            SprAccountsVoucherBankGetDepositSlipTableAdapter ta = new SprAccountsVoucherBankGetDepositSlipTableAdapter();
            DepositSlipTDS.SprAccountsVoucherBankGetDepositSlipDataTable table = ta.GetData(int.Parse(userID), int.Parse(unitID), bnk, brn, acc, fromDate.Date, toDate.Date, isChq, isDD, isPO, isDS, isAdj, isAdv, ref tot, ref unitName, ref unitAddress);

            if (tot == null)
            {
                totalAmount = 0;
            }
            else
            {
                totalAmount = (decimal)tot;
            }
            return table;
        }
    }
}
