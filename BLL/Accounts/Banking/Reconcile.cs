using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.ReconcileTDSTableAdapters;
using System.Web.UI.WebControls;
using System.Data;
using GLOBAL_BLL;

namespace BLL.Accounts.Banking
{
    public class Reconcile
    {
        public ReconcileTDS.SprBankAccountStatementDataDataTable GetAccountStatementData(string bankAccountID, string toDate, string userID, string unitID, ref string bankName, ref string branchName, ref string unitName, ref string unitAddress, ref decimal bankBookBalance, ref decimal bankStatementBalance, ref decimal bankActualStatementBalance,ref DateTime lastDate)
        {
            DateTime? frm = null, to = null, ld = null; int? bnkid;
            /*string fromDate;
            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value.Date;
            }
            catch{}*/
            try
            {
                bnkid = int.Parse(bankAccountID);
            }
            catch { bnkid = 0; }
            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.Date;
            }
            catch { to = DateTime.Now.Date; }


            decimal? bankBookBalance_ = 0;
            decimal? bankStatementBalance_ = 0;
            decimal? bankActualStatementBalance_ = 0;
            
            SprBankAccountStatementDataTableAdapter ta = new SprBankAccountStatementDataTableAdapter();
            ReconcileTDS.SprBankAccountStatementDataDataTable table = ta.GetData(bnkid, frm, to, int.Parse(userID), int.Parse(unitID), ref unitName, ref unitAddress, ref bankName, ref branchName, ref bankBookBalance_, ref bankStatementBalance_, ref bankActualStatementBalance_, ref ld);

            bankBookBalance = Convert.ToDecimal(bankBookBalance_);
            bankStatementBalance = Convert.ToDecimal(bankStatementBalance_);
            bankActualStatementBalance = Convert.ToDecimal(bankActualStatementBalance_);
            lastDate = ld.Value;

            return table;

            
        }

        public ReconcileTDS.SprBankAccountStatementDataMatchedDataTable GetAccountStatementMatchedData(string bankAccountID,string fromDate, string toDate, string userID, string unitID)
        {
            DateTime? frm = null, to = null; int? bnkid;
            try
            {
                bnkid = int.Parse(bankAccountID);
            }
            catch { bnkid = 0; }
            try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value.Date;
            }
            catch{}

            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.Date;
            }
            catch { to = DateTime.Now.Date; }

            SprBankAccountStatementDataMatchedTableAdapter ta = new SprBankAccountStatementDataMatchedTableAdapter();
            return ta.GetData(bnkid, frm, to, int.Parse(userID), int.Parse(unitID));
        }

        public DataTable GetReconcileTypeForDDL()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("key", typeof(string));
            dt.Columns.Add("value", typeof(string));

            dt.Rows.Add("1", GetReconcileType("1"));
            dt.Rows.Add("2", GetReconcileType("2"));
            
            return dt;
        }

        public string GetReconcileType(string key)
        {
            if (key == "1") return "Cheque issued but not presented in bank";
            else if (key == "2") return "Amount debited in bank book but not credited in bank statement";
            else if (key == "3") return "Amount credited in bank statement but not yet debited in bank book";
            else if (key == "4") return "Amount debited in bank statement but not yet credited in bank book";
            else return "";
        }

        public string GetReconcileTypeMatched(string key)
        {
            if (key == "1") return GetReconcileType(GetReconcileTypeAlternateValue("1"));
            else if (key == "2") return GetReconcileType(GetReconcileTypeAlternateValue("2"));            
            else if (key == "3") return GetReconcileType(GetReconcileTypeAlternateValue("3"));
            else if (key == "4") return GetReconcileType(GetReconcileTypeAlternateValue("4"));
            else return "";
        }
        public string GetReconcileTypeAlternateValue(string key)
        {
            if (key == "1") return"4";
            else if (key == "2") return "3";
            else if (key == "4") return "1";
            else if (key == "3") return "2";
            else return "";
        }
        public ReconcileTDS.SprBankAccountStatementDataByTypeDataTable GetAccountStatementDataByType(string bankAccountID, string toDate, string userID, string unitID, string type,bool isCompleted)
        {
            DateTime? frm = null, to = null; int? bnkid;          
            /*try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value.Date;
            }
            catch{}*/
            try { bnkid = int.Parse(bankAccountID); }
            catch { bnkid = 0; } 
            try
            { to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.Date;
            }
            catch { to = DateTime.Now.Date; }
            
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            ReconcileTDS.SprBankAccountStatementDataByTypeDataTable table = ta.GetData(bnkid, frm, to, int.Parse(userID), int.Parse(unitID), type, isCompleted);
            
            return table;
        }
        public ReconcileTDS.SprBankAccountStatementDataByTypeDataTable GetAccountStatementDataByTypeMatched(string bankAccountID, string toDate, string userID, string unitID, string type, bool isCompleted)
        {
            DateTime? frm = null, to = null; int? bnkid; 
            /*try
            {
                frm = DateFormat.GetDateAtSQLDateFormat(fromDate).Value.Date;
            }
            catch{}*/
            try
            {
                bnkid = int.Parse(bankAccountID);
            }
            catch { bnkid = 0; } 
            try
            {
                to = DateFormat.GetDateAtSQLDateFormat(toDate).Value.Date;
            }
            catch { to = DateTime.Now.Date; }

            if (type == "1") type = "4";
            else if (type == "2") type = "3";

            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            ReconcileTDS.SprBankAccountStatementDataByTypeDataTable table = ta.GetData(bnkid, frm, to, int.Parse(userID), int.Parse(unitID), type, isCompleted);

            return table;
        }
        public void ManualBankReconcile(string bankVoucherID, bool isCompleted, string dateReconcile)
        {
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            DateTime? dt = null;
            if (isCompleted) dt = DateFormat.GetDateAtSQLDateFormat(dateReconcile);
            ta.UpdateBankReconcile(isCompleted, dt, long.Parse(bankVoucherID));
        }
        public void ManualContraReconcile(string ContraVoucherID, bool isCompleted, string dateReconcile)
        {
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            DateTime? dt = null;
            if (isCompleted) dt = DateFormat.GetDateAtSQLDateFormat(dateReconcile);
            ta.UpdateContraReconcile(isCompleted, dt, long.Parse(ContraVoucherID));
        }
        public void ManualContraDetailsReconcile(string ContraVoucherID, bool isCompleted, string dateReconcile)
        {
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            DateTime? dt = null;
            if (isCompleted) dt = DateFormat.GetDateAtSQLDateFormat(dateReconcile);
            ta.UpdateContraDetailsReconcile(isCompleted, dt, long.Parse(ContraVoucherID));
        }
        public void ManualStatementReconcile(string statementID, bool isCompleted, string dateReconcile)
        {
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            DateTime? dt = null;
            if (isCompleted) dt = DateFormat.GetDateAtSQLDateFormat(dateReconcile);
            ta.UpdateStatement(isCompleted, dt, long.Parse(statementID));
        }
        public void ManualOpeningReconcile(string oldVoucherID, bool isCompleted,string dateReconcile)
        {
            SprBankAccountStatementDataByTypeTableAdapter ta = new SprBankAccountStatementDataByTypeTableAdapter();
            DateTime? dt = null;
            if (isCompleted) dt = DateFormat.GetDateAtSQLDateFormat(dateReconcile);
            ta.UpdateOpening(isCompleted, dt, int.Parse(oldVoucherID));
        }
    }
}
