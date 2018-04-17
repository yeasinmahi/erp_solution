using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankLoanTDSTableAdapters;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.LoanTypeTDSTableAdapters;
using DAL.Accounts.Bank.BankAccountTypeTDSTableAdapters;

namespace BLL.Accounts.Bank
{
    public class LoanType
    {

        public BankLoanTDS.TblBankLoanTypeDataTable GetLoanTypeByUnit(string unitID)
        {
            TblBankLoanTypeTableAdapter adp = new TblBankLoanTypeTableAdapter();
            return adp.GetLoanTypeDataByUnit(int.Parse(unitID));
        }


        public BankLoanTDS.TblBankLoanTypeDataTable GetLoanTypeByID(string loanTypeID)
        {
            TblBankLoanTypeTableAdapter adp = new TblBankLoanTypeTableAdapter();
            if (loanTypeID == null)
            {
                return null;
            }
            return adp.GetLoanTypeDataByID(int.Parse(loanTypeID));
        }

      /*  public BankLoanTDS.TblBankLoantypeDetailsDataTable GetLoanTypeDetailsByID(string loanTypeID)
        {
            TblBankLoantypeDetailsTableAdapter adp = new TblBankLoantypeDetailsTableAdapter();
            if (loanTypeID == null)
            {
                return null;
            }

            return adp.GetLoanTypeDetailsDataByID(int.Parse(loanTypeID));
        }*/

        public bool InsertLoanType(string userID, string name, decimal limit, int unitID)
        {
            bool ysnSuccess = false;
            SprBankLoanTypeAddTableAdapter adp = new SprBankLoanTypeAddTableAdapter();
            try
            {
                adp.InsertLoanTypeData(unitID, name, limit, int.Parse(userID));
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }
            return ysnSuccess;
        }

        public bool EditLoanType(string strLoanTypeName, decimal monLoanLimit, int intLoanTypeID)
        {
            return true;
        }

        public bool InsertLoanTypeDetails(string userID, int bankID, int accTypeID, int loanTypeID,int unitID)
        {
            bool ysnSuccess = false;
            SprBankLoanTypeDetailsInsertTableAdapter adp = new SprBankLoanTypeDetailsInsertTableAdapter();
            try
            {
                adp.InsertLoanTypeDetailsData(bankID, accTypeID, loanTypeID, int.Parse(userID), unitID);
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }
            return ysnSuccess;
        }


        public BankLoanTDS.QryBankLoanTypeDetailsDataTable GetLoanTypeDetailsByID(string loanTypeID)
        {
            if (loanTypeID == null)
            {
                return null;
            }

            QryBankLoanTypeDetailsTableAdapter adp = new QryBankLoanTypeDetailsTableAdapter();
            return adp.GetDataByLoanTypeID(int.Parse(loanTypeID));
        }

       /******************************************************
        * Adding for Loan Type Interest 
        * ********************************************************
        */
        public LoanTypeTDS.TblBankLoanTypesDataTable GetLoanTypes()
        {
            TblBankLoanTypesTableAdapter adp = new TblBankLoanTypesTableAdapter();
            return adp.GetLoanTypeData();
        }


        public string GetLoanTypeID(int accTypeID)
        {
            string shortLoanTypeID = "";
            TblBankAccountTypeTableAdapter adp = new TblBankAccountTypeTableAdapter();
            BankAccountTypeTDS.TblBankAccountTypeDataTable tbl = adp.GetDataByAccTypeID(accTypeID);
            if (tbl.Rows.Count > 0)
            {
                if (tbl[0].IsintLoanTypeIDNull())
                {
                    shortLoanTypeID = "0";
                }
                else
                {
                    shortLoanTypeID = tbl[0].intLoanTypeID.ToString();
                }
            }
            else
            {
                shortLoanTypeID = "0";
            }

            return shortLoanTypeID;
        }

        


    }
}
