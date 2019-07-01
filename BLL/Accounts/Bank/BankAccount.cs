using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Bank.BankAccountTDSTableAdapters;
using DAL.Accounts.Bank;
using System.Data;

namespace BLL.Accounts.Bank
{
    public class BankAccount
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankAccountTDS.QryBankAccInfoForDDLDataTable GetActiveForDDL(string bankID, string unitID)
        {
            QryBankAccInfoForDDLTableAdapter ta = new QryBankAccInfoForDDLTableAdapter();
            try
            {
                return ta.GetData(int.Parse(unitID), int.Parse(bankID));
            }
            catch { return new BankAccountTDS.QryBankAccInfoForDDLDataTable(); }            
        }
        

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankAccountTDS.QryBankAccInfoForDDLDataTable GetActiveForDDLByBranch(string branchID, string unitID)
        {
            QryBankAccInfoForDDLTableAdapter ta = new QryBankAccInfoForDDLTableAdapter();
            try
            {
                return ta.GetDataByBranch(int.Parse(unitID), int.Parse(branchID));
            }
            catch { return new BankAccountTDS.QryBankAccInfoForDDLDataTable(); }
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankAccountTDS.QryBankAccInfoForDDLDataTable GetActiveForDDLByBranchWithAll(string branchID, string unitID)
        {
            try
            {
                QryBankAccInfoForDDLTableAdapter ta = new QryBankAccInfoForDDLTableAdapter();
                BankAccountTDS.QryBankAccInfoForDDLDataTable table = ta.GetDataByBranch(int.Parse(unitID), int.Parse(branchID));
                BankAccountTDS.QryBankAccInfoForDDLRow row = table.NewQryBankAccInfoForDDLRow();
                row.intAccountID = 0;
                row.intBankID = 0;
                row.intBranchID = 0;
                row.intUnitID = 0;
                row.strAccountNo = "All";
                row.strAccountNoOriginal = "All";
                table.AddQryBankAccInfoForDDLRow(row);
                
                return table;
            }
            catch { return new BankAccountTDS.QryBankAccInfoForDDLDataTable(); }
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void GetCOAInfoByBankAccNo(string accountID, string unitID,ref int? coaID,ref string coaName)
        {
            SprBankGetCOAInfoByAccountTableAdapter ta = new SprBankGetCOAInfoByAccountTableAdapter();
            ta.GetData(accountID==""?0 : int.Parse(accountID), int.Parse(unitID), ref coaID, ref coaName);
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public BankAccountTDS.SprBankGetBankAccountInfoDataTable GetAccountInfo(int branchID,int unitID)
        {
            SprBankGetBankAccountInfoTableAdapter adp = new SprBankGetBankAccountInfoTableAdapter();
            BankAccountTDS.SprBankGetBankAccountInfoDataTable tbl = adp.GetData(unitID, branchID);
            return tbl;

        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public string BankAccountInsertion(int branchID,int unitID,string accountNumber,string accountName,string accountDescription,int accountTypeID,int userID,string code, decimal loanLimit,
                                            int? accLoanTypeID, decimal? loanAmount,decimal? loanRate,DateTime? loanDate,bool? ysnCommulative,int? comPeriodInDays,
                                            int? gracePriodInDays,decimal? gracerate,
                                            int? loanPeriodInYear, int? installmentInYear)
        {
            string result="";

            SprBankAccountAddTableAdapter adp = new SprBankAccountAddTableAdapter();
            try
            {
                adp.GetData(branchID, 
                    unitID, 
                    accountNumber, 
                    accountName, 
                    accountDescription,
                    accountTypeID,
                    userID,
                    code,
                    loanLimit, 
                    ref result,
                            accLoanTypeID,
                            loanAmount,
                            loanRate,
                            loanDate,
                            ysnCommulative,
                            comPeriodInDays,
                            gracePriodInDays,
                            gracerate,
                            loanPeriodInYear,
                            installmentInYear);
            }
            catch
            {
                result = "Account Cannot Be Inserted";
            }


            return result;

        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public void BankAccountEdit(string strAccountName, string strDescription, bool ysnEnable, string  strAccType,string strAccountNo,int intAccountID,decimal monLoanLimit, string userID)
        {            
            SprBankAccountEditTableAdapter adp = new SprBankAccountEditTableAdapter();
            try
            {
                adp.GetData(intAccountID, strAccountNo, strDescription, ysnEnable, monLoanLimit, int.Parse(userID));
            }
            catch
            {
            }
        }

        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public BankAccountTDS.TblBankAccountInfoDataTable GetBankAccountsByAccountType(int unitID, int accTypeID)
        {
            TblBankAccountInfoTableAdapter adp = new TblBankAccountInfoTableAdapter();
            return adp.GetDataByAccType(accTypeID, unitID);

        }


        /// <summary>
        /// Developped By Himadri das
        /// </summary>
        public BankAccountTDS.TblBankAccountInfoDataTable GetBankAccountsByUnit(string unitID)
        {
            TblBankAccountInfoTableAdapter adp = new TblBankAccountInfoTableAdapter();
            return adp.GetDataByUnitID(int.Parse(unitID));

        }

        public DataTable GetBankReceiveData(string unitid)
        {
            try
            {
                TblBankAccountStatementTableAdapter adp = new TblBankAccountStatementTableAdapter();
                return adp.GetBankReceiveInfo(unitid);
            }
            catch { return new DataTable(); }
        }


    }
}
