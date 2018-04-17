using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking.StatementTDSTableAdapters;
using DAL.Accounts.Banking;
using GLOBAL_BLL;

namespace BLL.Accounts.Banking
{
    public class BankStatement
    {
        public int? GetAccountIdByKey(string key)
        {
            TblBankAccountStatementCollectorInfoDetailsTableAdapter ta = new TblBankAccountStatementCollectorInfoDetailsTableAdapter();
            StatementTDS.TblBankAccountStatementCollectorInfoDetailsDataTable table = ta.GetDataByKey(key);
            if (table.Rows.Count > 0)
            {
                return table[0].intAccountID;
            }

            return null;
        }

        public bool InsertStatementData(int accountId,DateTime date,string particulars,string chequeNo,decimal drAmount,decimal crAmount,decimal running)
        {
            bool? ysnSuccess=false;
            SprBankAccountStatementAddTableAdapter ta = new SprBankAccountStatementAddTableAdapter();
            StatementTDS.SprBankAccountStatementAddDataTable tbl = ta.GetData(accountId, date, particulars, chequeNo, drAmount, crAmount, running,ref ysnSuccess);

            return ysnSuccess.Value;

        }

        public StatementTDS.TblBankAccountStatementDataTable GetStatementData(string accountId, string date)
        {
            DateTime dte; int bnkid;
            try
            {
                bnkid = int.Parse(accountId);
            }
            catch { bnkid = 0; }

            try
            {
                dte = DateFormat.GetDateAtSQLDateFormat(date).Value;
            }
            catch { dte = DateTime.Now; }

            TblBankAccountStatementTableAdapter ta = new TblBankAccountStatementTableAdapter();
            return ta.GetData(dte.ToString(), bnkid);
        }

        public void UpdateStatement(DateTime dteDate, string strParticulars, string strChequeNo, decimal monAmount, decimal monRunningBalance, DateTime dteInsertionTime, DateTime dteCompleteDate, DateTime dteAutoReconciled, int original_intID, decimal monDrAmount, decimal monCrAmount)
        {
            decimal amnt = 0;

            if (monDrAmount == 0)
            {
                amnt = monCrAmount;
            }
            else
            {
                amnt = monDrAmount * -1;
            }


            TblBankAccountStatementTableAdapter ta = new TblBankAccountStatementTableAdapter();
            ta.UpdateData(monRunningBalance, amnt, original_intID);

        }

        public void CancelAutoReconcile(string id)
        {
            TblBankAccountStatementTableAdapter ta = new TblBankAccountStatementTableAdapter();
            ta.CancelAutoReconcile(long.Parse(id));
        }

    }
}
