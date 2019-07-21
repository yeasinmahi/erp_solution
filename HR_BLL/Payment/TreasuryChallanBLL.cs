using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_DAL.Payment.TreasuryChallanTDSTableAdapters;
namespace HR_BLL.Payment
{
    public class TreasuryChallanBLL
    {
        public DataTable getUnitByUser(int userId)
        {
            sprGetVATAccountByAccountsUserTableAdapter adp = new sprGetVATAccountByAccountsUserTableAdapter();
            return adp.GetUnitByUserId(userId);
        }

        public DataTable getChallanByVatAccountId(int vatAccountId)
        {
            TblChallanListTableAdapter adp = new TblChallanListTableAdapter();
            return adp.GetChallanDataByVatAcountId(vatAccountId);
        }

        public DataTable getChallanDetails(int vatAccountId)
        {
            TblDetailsTableAdapter adp = new TblDetailsTableAdapter();
            return adp.GetDetails(vatAccountId);
        }

        public DataTable getVatreg(int intTreasuryId)
        {
            TblVatTableAdapter adp = new TblVatTableAdapter();
            return adp.GetVatRegData(intTreasuryId);
        }

        public DataTable updateVat(string BankName, string strDistrict, string strBranch, string dteChallan, string strChallan, string strInstrument,int intTreasuryID)
        {
            tblVATTreasuryDepositTableAdapter adp = new tblVATTreasuryDepositTableAdapter();
            return adp.UpdateData(BankName,strDistrict,strBranch,dteChallan,strChallan,strInstrument,intTreasuryID);
        }

        public DataTable ShowAdvice(int intVatAcc,int intType)
        {
            sprAccountsAdviceForTreasuryDepositWebTableAdapter adp = new sprAccountsAdviceForTreasuryDepositWebTableAdapter();
            return adp.GetData(intVatAcc, intType);
        }

        public DataTable GetForecastDetails(int intVatAcc)
        {
            sprVATTreasuryDepositForecastTableAdapter adp = new sprVATTreasuryDepositForecastTableAdapter();
            return adp.GetTreasuryForecastData(intVatAcc);
        }

        public DataTable GetBankListData(int intUnit)
        {
            tblBankInfoTableAdapter adp = new tblBankInfoTableAdapter();
            return adp.GetBankList(intUnit);
        }

        public DataTable GetAccountListData(int intUnit ,int intBank)
        {
            tblBankAccountInfoTableAdapter adp = new tblBankAccountInfoTableAdapter();
            return adp.GetAccountList(intUnit, intBank);
        }
        
        public DataTable GetChartOfAccIdList(int intVatacc, int intTreasuryId)
        {
            TblChartOfAccIdTableAdapter adp = new TblChartOfAccIdTableAdapter();
            return adp.GetChartOfAccId(intVatacc, intTreasuryId);
        }

        //public DataTable InsertVoucharList(int intUnit, string strCodeFor,DateTime datefor,string prefix,bool ysnNeedPrefix,ref string strCode)
        //{            
        //    sprGetGeneratedCodeTableAdapter adp = new sprGetGeneratedCodeTableAdapter();
        //    return adp.InsertVoucharData(intUnit, strCodeFor, datefor, prefix, ysnNeedPrefix,ref strCode);            
        //}
        //public DataTable GetSetAndUpdateChequeList(int intAcc, string strCode, ref string strCheckNo)
        //{
        //    sprBankSetCheckNoTableAdapter adp = new sprBankSetCheckNoTableAdapter();
        //    return adp.SetAndUpdateCheque(intAcc, strCode, ref strCheckNo);
        //}

        //public DataTable GetSetAndUpdateAdviceList(int intUnit, ref string strCode)
        //{
        //    sprGetGeneratedAdviceCodeTableAdapter adp = new sprGetGeneratedAdviceCodeTableAdapter();
        //    return adp.GetAdviceCode(intUnit,ref strCode);
        //}

        //public DataTable InsertVoucharBank(string strVoucharCode,int intUnit, int intBank, int intBankAcc, string strInstrument,DateTime dteVoucherDate, string strNarration,decimal monCrAmount, int intUser,DateTime date,bool ysnEnable, bool ysnCompleted, int intVoucherPrintCount, bool ysnCheque,string strPayTo, bool ysnPostedInSubLedger, bool ysnAdvance, bool ysnAdjustment, bool ysnFinished)
        //{
        //    tblAccountsVoucherBankTableAdapter adp = new tblAccountsVoucherBankTableAdapter();
        //    return adp.InsertIntoVoucharBank(strVoucharCode,intUnit, intBank,intBankAcc,strInstrument,dteVoucherDate,strNarration,monCrAmount,intUser,date,ysnEnable,ysnCompleted,intVoucherPrintCount,ysnCheque,strPayTo,ysnPostedInSubLedger,ysnAdvance,ysnAdjustment,ysnFinished);
        //}

        public DataTable InsertVoucharBank(string strVoucharCode, int intUnit, int intBank, int intBankAcc, string strInstrument, DateTime dteVoucherDate, string strNarration, decimal monCrAmount, int intUser, DateTime dteLastActiondate, string strPayTo,int intCOA,decimal monDrAmount,string strAccName, ref string msg)
        {
            sprInsertVoucharBankTableAdapter adp = new sprInsertVoucharBankTableAdapter();
            return adp.InsertVoucharBankAndDetails(strVoucharCode, intUnit, intBank, intBankAcc, strInstrument, dteVoucherDate, strNarration, monCrAmount, intUser, dteLastActiondate,strPayTo,intCOA,monDrAmount,strAccName,ref msg);
        }

        
        public DataTable GetTreasuryForcastDataList(int intPart,int intUserId, int intVatAcc, int intUnit,DateTime dteVdate, decimal monCrAmount, decimal monDramount, int intBank, int intBankAcc, string Address, string strName, int intTreasuryId, int intCOA,string strAccName, string strPayTo, string strNarration)
        {
            sprTreasuryForecastTableAdapter adp = new sprTreasuryForecastTableAdapter();
            return adp.InsertVoucharData(intPart, intUserId, intVatAcc, intUnit, dteVdate,  monCrAmount, monDramount, intBank, intBankAcc, Address, strName, intTreasuryId, intCOA, strAccName, strPayTo, strNarration);
        }












    }
}
