using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.BudgetTDSTableAdapters;
using System.Data;

namespace BLL.Accounts.Voucher
{
    public class Budget
    {
        public DataTable GetCostCenterList (int unit)
        {
            try
            {
                if (unit == 2)
                {
                    TblCostCenterTableAdapter adp = new TblCostCenterTableAdapter();
                    return adp.GetAFBLDataCostcenter(unit);
                }
                else
                {
                    TblCostCenterTableAdapter adp = new TblCostCenterTableAdapter();                   
                    return adp.GetCCntrListData(unit);
                }
               
            }
            catch { return new DataTable(); }
        }
        public BudgetTDS.SprAccountsVoucherBankGetBudgetDataTable GetBudget(string userID, string unitID, string bankID, string branchID, string accountID, DateTime fromDate, bool isDr, ref string unitName, ref string unitAddress)
        {
            DateTime frm, to;
            try { frm = fromDate.Date; }
            catch { frm = DateTime.Now.Date; }

            to = frm.Date.AddDays(1);

            int? bnk, brn, acc;
            try { bnk = int.Parse(bankID); if (bnk == 0)bnk = null; }
            catch { bnk = null; }

            try { brn = int.Parse(branchID); if (brn == 0)brn = null; }
            catch { brn = null; }

            try { acc = int.Parse(accountID); if (acc == 0)acc = null; }
            catch { acc = null; }

            SprAccountsVoucherBankGetBudgetTableAdapter ta = new SprAccountsVoucherBankGetBudgetTableAdapter();
            return ta.GetData(int.Parse(userID), int.Parse(unitID), bnk, brn, acc, frm, to, isDr, ref unitName, ref unitAddress);
        }
        public BudgetTDS.SprAccountsVoucherBankGetBudgetFullDataTable GetBudgetFull(string userID, DateTime fromDate, bool isDr, ref string unitName, ref string unitAddress)
        {
            DateTime frm, to;
            try { frm = fromDate.Date; }
            catch { frm = DateTime.Now.Date; }
            //string unitID, bankID, branchID, accountID;

            to = frm.Date.AddDays(1);

            int? bnk = null, brn = null, acc = null;
            /*try { bnk = int.Parse(bankID); if (bnk == 0)bnk = null; }
            catch { bnk = null; }

            try { brn = int.Parse(branchID); if (brn == 0)brn = null; }
            catch { brn = null; }

            try { acc = int.Parse(accountID); if (acc == 0)acc = null; }
            catch { acc = null; }*/

            SprAccountsVoucherBankGetBudgetFullTableAdapter ta = new SprAccountsVoucherBankGetBudgetFullTableAdapter();
            return ta.GetData(int.Parse(userID), null, bnk, brn, acc, frm, to, isDr, ref unitName, ref unitAddress);
        }
        public DataTable GetAccountsStartDate(int unit)
        {
            try
            {
                TblAccountsAccountingPeriodTableAdapter adp = new TblAccountsAccountingPeriodTableAdapter();
                return adp.GetAccStartDateData(unit);
            }
            catch { return new DataTable(); }
        }


    }
}
