using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankAccountTypeTDSTableAdapters;
using DAL.Accounts.Banking.LoanTypeTDSTableAdapters;
using DAL.Accounts.Banking;

namespace BLL.Accounts.Bank
{
    public class BankAccountType
    {

        /// <summary>
        /// Developped By Himadri Das
        /// </summary>
        public BankAccountTypeTDS.TblBankAccountTypeDataTable GetAccountTypeData(int bankID)
        {
           
            TblBankAccountTypeTableAdapter adp = new TblBankAccountTypeTableAdapter();
            return adp.GetAccTypeByBankID(bankID);

        }
         /// <summary>
        /// Developped By Himadri Das
        /// </summary>
        public string AddBankAccountType(int bankID,string accTypeName,string description,int userID,string code)
        {
            string result="";
            SprBankAccountTypeAddTableAdapter adp = new SprBankAccountTypeAddTableAdapter();
            try
            {
                adp.InsertAccountType(bankID, accTypeName, description, userID,code, ref result);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        /// <summary>
        /// Developped By Himadri Das
        /// </summary>
        public void EditAccountType(int bankid, string strAccType, string strDescription, bool ysnEnable, string userID,int original_intAccountTypeID)
        {
            try
            {
                new SprBankAccountTypeEditTableAdapter().EditAccountType(original_intAccountTypeID, strAccType, ysnEnable, strDescription, int.Parse(userID));
            }
            catch
            {
            }
        }

        public BankAccountTypeTDS.TblBankAccountTypeDataTable BankAccountTypeIDByLoanTypeShortName(string loanTypeShortName)
        {
            int loanTypeID = 0;
            TblBankLoanTypesTableAdapter adpLoanType = new TblBankLoanTypesTableAdapter();
            LoanTypeTDS.TblBankLoanTypesDataTable tblLoanType = adpLoanType.GetDataByShortName(loanTypeShortName);
            if (tblLoanType.Rows.Count > 0)
            {
                loanTypeID = tblLoanType[0].intLoanTypeID;
            }
            else
            {
                loanTypeID= 0;
            }

            TblBankAccountTypeTableAdapter adp = new TblBankAccountTypeTableAdapter();
            return adp.GetDataByLoanTypeID(loanTypeID);
        }
       
    }
}
