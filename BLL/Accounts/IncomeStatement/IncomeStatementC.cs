using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.IncomeSatement;
using DAL.Accounts.IncomeSatement.IncomestatementTDSTableAdapters;

namespace BLL.Accounts.IncomeStatement
{
    public class IncomeStatementC
    {
        public IncomestatementTDS.SprAccountsIncomeStatementDataTable GetIncomeStatement(DateTime fromDate, DateTime toDate, bool ysnAccountingPeriod, int unitID, int userID, ref string unitName, ref string unitAddress)
        {
            SprAccountsIncomeStatementTableAdapter adp = new SprAccountsIncomeStatementTableAdapter();
            return adp.GetDataIncomeStatement(fromDate, toDate, ysnAccountingPeriod, unitID, userID, ref unitName, ref unitAddress);
        }
    }
}
