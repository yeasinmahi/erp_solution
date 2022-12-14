using DAL.Accounts.Advice.AdviceTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.Advice
{
    public class AdviceBLL
    {
        public DataTable GetPartyAdvice(int intAdviceType, int intActionBy, int intUnitID, DateTime dteDate, int intWork, string strAccountMandatory, string strBankName, int ysnCompleted, int intChillingID)
        {
            try
            {
                SprAdviceForBFTNTableAdapter adp = new SprAdviceForBFTNTableAdapter();
                return adp.GetPartyAdvice(intAdviceType, intActionBy, intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted, intChillingID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyAdviceForSCB(int intUnitID, DateTime dteDate, int intWork, string strAccountMandatory, string strBankName, int ysnCompleted)
        {
            try
            {
                sprAdviceForBFTNNewNewTableAdapter adp = new sprAdviceForBFTNNewNewTableAdapter();
                return adp.GetAdviceDataForSCB(intUnitID,dteDate,intWork,strAccountMandatory,strBankName,ysnCompleted);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetUnitAddress(int intUnitID)
        {
            try
            {
                UnitAddressTableAdapter adp = new UnitAddressTableAdapter();
                return adp.GetUnitAddress(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetIBBLBank(int intUnitID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetIBBLBank(intUnitID);
            }
            catch { return new DataTable(); }
        }

        public DataTable GetBankVoucherId(string voucher, int intUnitID)
        {
            try
            {
                BankVoucherTableAdapter adp = new BankVoucherTableAdapter();
                return adp.GetBankVoucherId(voucher,intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetOtherBank(int intUnitID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetOtherBank(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAccountDetails(int intAutoID)
        {
            try
            {
                BankListTableAdapter adp = new BankListTableAdapter();
                return adp.GetAccountDetails(intAutoID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAdviceData(int type,int intActionBy)
        {
            try
            {
                AdviceDataTableAdapter adp = new AdviceDataTableAdapter();
                return adp.GetAdviceData(type,intActionBy);
            }
            catch { return new DataTable(); }
        }
        public void DeleteData(int intID)
        {
            try
            {
                DeleteDataTableAdapter adp = new DeleteDataTableAdapter();
                adp.DeleteAdviceData(intID);
            }
            catch { }
        }
        public void UpdateChqPrint(int intUnitID, int intActionBy)
        {
            try
            {
                TblAccountsVoucherBankTableAdapter adp = new TblAccountsVoucherBankTableAdapter();
                adp.UpdateChqPrint(intUnitID, intActionBy);
            }
            catch { }
        }
        public DataTable GetChillingCenter()
        {
            try
            {
                ChillingCenterListTableAdapter adp = new ChillingCenterListTableAdapter();
                return adp.GetChillingCenter();
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPrintData(int intID)
        {
            try
            {
                GetPrintDataTableAdapter adp = new GetPrintDataTableAdapter();
                return adp.GetPrintData(intID);
            }
            catch { return new DataTable(); }
        }
       
        public DataTable GetLastCollectDate(int intAccountID)
        {
            try
            {
                TblBankAccountStatementTableAdapter adp = new TblBankAccountStatementTableAdapter();
                return adp.GetLastCollectDate(intAccountID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetAccountList(int intUnitID)
        {
            try
            {
                TblBankAccountListTableAdapter adp = new TblBankAccountListTableAdapter();
                return adp.GetAccountList(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public void InsertTempData(int intAccountID, string dteDate, string strParticulars, string strInstrumentNo, decimal monDebit, decimal monCredit, decimal monBalance, int intInsertBy)
        {
            try
            {
                TblTempBankAccountStatementTableAdapter adp = new TblTempBankAccountStatementTableAdapter();
                adp.InsertTempData(intAccountID, dteDate, strParticulars, strInstrumentNo, monDebit, monCredit, monBalance, intInsertBy);
            }
            catch { }
        }
        public void DeleteStatement(int intEnroll)
        {
            try
            {
                DeleteStatementTableAdapter adp = new DeleteStatementTableAdapter();
                adp.DeleteData(intEnroll);
            }
            catch { }
        }
        public DataTable InsertStatement(int intAccountID, int intInsertBy)
        {
            try
            {
                SprBankAccountStatementEntryFromERPTableAdapter adp = new SprBankAccountStatementEntryFromERPTableAdapter();
                return adp.InsertBankStatement(intAccountID, intInsertBy);
            }
            catch { return new DataTable(); }
        }
        #region--------Payment Advice---------
        public DataTable PaymentAdviceEntry(int intPart, int intInsertBy,int unitId, string adviceForBank, string xml)
        {
            try
            {
                SprAdvice_Entry_ReportTableAdapter adp = new SprAdvice_Entry_ReportTableAdapter();
                return adp.GetData(intPart, intInsertBy, unitId, adviceForBank, xml);
            }
            catch(Exception ex) { return new DataTable(); }
        }
        public DataTable GetVoucherPrintData(string strCodeNo, int intUnitID, int intPartID)
        {
            try
            {
                SprAdviceVoucherPrintTableAdapter adp = new SprAdviceVoucherPrintTableAdapter();
                return adp.GetVoucherPrintData(strCodeNo, intUnitID, intPartID);
            }
            catch { return new DataTable(); }
        }
        public string SendEmail(string strSupplierName, string strEmailAddress, string strBankName, string strBranchName, string strBankAccNo, decimal monAmount, string strPONo, string strUnitName, string strDays, string strPaymentInfo, string strBillNo, int intSupplierID, int intUnitID)
        {
            string msg = "";
            try
            {
                sprEmailCreateTableAdapter adp = new sprEmailCreateTableAdapter();
                adp.SendData(strSupplierName,strEmailAddress,strBankName,strBranchName,strBankAccNo,monAmount,strPONo,strUnitName,strDays,strPaymentInfo,strBillNo,intSupplierID,intUnitID);
                msg = "Email Send Successfully.";
            }
            catch (Exception ex) { return ex.Message; }
            return msg;
        }
        #endregion
        #region ================== Bank Receive ===========================
        public DataTable GetBankData (string intUnitID)
        {
            try
            {
                BankDataTableAdapter adp = new BankDataTableAdapter();
                return adp.GetBankData(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetCustomerList(int intUnitID)
        {
            try
            {
                TblCustomerTableAdapter adp = new TblCustomerTableAdapter();
                return adp.GetCustomerList(intUnitID);
            }
            catch { return new DataTable(); }
        }
        public void InserBankReceive (int intUnit, int intEnroll, int intCustID, int intBSId, string strNarration)
        {
            try
            {
                SprBankReciveBRMakingTableAdapter adp = new SprBankReciveBRMakingTableAdapter();
                adp.InsertBankReceive(intUnit, intEnroll, intCustID, intBSId, strNarration);
            }
            catch { }
        }
        #endregion =========================================================
    }
}
