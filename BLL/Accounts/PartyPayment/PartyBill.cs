using DAL.Accounts.Bank;
using DAL.Accounts.Bank.BankAccountTDSTableAdapters;
using DAL.Accounts.PartyPayment.PartyBillTDSTableAdapters;
using DAL.Accounts.Vat.VATInformationTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Accounts.PartyPayment
{
    public class PartyBill
    {
        #region ---------- Party Bill Cheque Authorization and Print ------------

        public DataTable GetVoucherStatusReport(string vouchercode, int unitid, DateTime fromdate, DateTime todate, bool completed)
        {
            SprVoucherStatusReportTableAdapter ta = new SprVoucherStatusReportTableAdapter();
            try
            { return ta.GetVoucherStatusReportData(vouchercode, unitid, fromdate, todate, completed); }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyBankVoucher(int unitid, string vouchercode, int userid)
        {
            SprPartyBankVoucherTableAdapter ta = new SprPartyBankVoucherTableAdapter();
            try
            { return ta.GetPartyBankVoucherData(vouchercode, unitid, userid); }
            catch { return new DataTable(); }
        }
        public string GetVoucherAuthorization(int usrid, int unitid, int voucherid)
        {
            SprVoucherAuthorizationInfoTableAdapter adtp = new SprVoucherAuthorizationInfoTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.GetVoucherAuthorizationData(usrid, unitid, voucherid, ref statusmsg);
            }
            catch { statusmsg = "0"; }
            return statusmsg;
        }
        public DataTable GetAuthorizedPartyCheque(int unitid, string vouchercode, int bankID, int bankaccID, bool printed)
        {
            SprAuthorizedPartyChequeTableAdapter ta = new SprAuthorizedPartyChequeTableAdapter();
            try
            { return ta.GetAuthorizedPartyChequeData(vouchercode, unitid, bankID, bankaccID, printed); }
            catch { return new DataTable(); }
        }
        public void UpdatePrintStatusAndComplteAuthorization(int selectedvoucherid, int unitid, int usrid)
        {
            QuryUpdatePrintStatusAndComplteAuthorizationTableAdapter qury = new QuryUpdatePrintStatusAndComplteAuthorizationTableAdapter();
            qury.UpdatePrintStatusBankVoucherData(usrid, selectedvoucherid, unitid);
            //qury.UpdateComplteAuthorization(selectedvoucherid, usrid);
        }
        public DataTable GetSignatureDetails(int voucherid)
        {
            SprGetSignatureDetailsTableAdapter ta = new SprGetSignatureDetailsTableAdapter();
            try
            { return ta.GetSignatureDetailsData(voucherid); }
            catch { return new DataTable(); }
        }

        #endregion

        #region ------------- Management and Accounts View and Action Party Bill ----------

        public string GetLastChequeNo(int bnkaccid, string vcode)
        {
            SprBankSetCheckNoTableAdapter adtp = new SprBankSetCheckNoTableAdapter();
            string chequeno = "";
            try
            {
                adtp.GetLastChequeNoData(bnkaccid, vcode, ref chequeno);
            }
            catch (Exception ex) { chequeno = ex.ToString(); }
            return chequeno;
        }
        public DataTable GetUnitInformation(int unitid)
        {
            UnitDataTableTableAdapter ta = new UnitDataTableTableAdapter();
            try
            {
                return ta.GetUnitInformationData(unitid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetBankAccount(string bankID, string userID)
        {
            SprGetBankAccountByBankUserTableAdapter ta = new SprGetBankAccountByBankUserTableAdapter();
            try
            {
                return ta.GetAccountListData(int.Parse(userID), int.Parse(bankID));
            }
            catch { return new DataTable(); }

        }
        public DataTable GetBankAccountBy(string bankID, string unitID)
        {
            SprGetBankAccountByBankUserTableAdapter ta = new SprGetBankAccountByBankUserTableAdapter();
            try
            {
                return ta.GetBankAccountData(int.Parse(bankID), int.Parse(unitID));
            }
            catch { return new DataTable(); }

        }

        public DataTable GetExpenceHeadList(int userid, string strSearchKey)
        {
            SprGetAccountsExpenseHeadTableAdapter ta = new SprGetAccountsExpenseHeadTableAdapter();
            try
            { return ta.GetCOAExpencesData(userid, strSearchKey); }
            catch { return new DataTable(); }
        }
        public DataTable GetWithoutExpenceHeadList(int userid, string strSearchKey)
        {
            SprGetAccountsWithoutExpenseHeadTableAdapter ta = new SprGetAccountsWithoutExpenseHeadTableAdapter();
            try
            { return ta.GetCOAWithoutExpencesData(userid, strSearchKey); }
            catch { return new DataTable(); }
        }

        public DataTable GetPaymentOrderList(int unitid, string viewtype)
        {
            SprGetPaymentOrderListTableAdapter ta = new SprGetPaymentOrderListTableAdapter();
            try
            { return ta.GetPaymentOrderListData(unitid, viewtype); }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyCashCreditBill(int userid)
        {
            SprGetPartyBillForCashCreditTableAdapter ta = new SprGetPartyBillForCashCreditTableAdapter();
            try
            {
                return ta.GetCashCreditBillData(userid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyAdjustmentBill(int userid)
        {
            SprGetPartyBillForAdjustmentTableAdapter ta = new SprGetPartyBillForAdjustmentTableAdapter();
            try
            {
                return ta.GetAdjustmentBillData(userid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyBill(int strbill, int strpo, int strShip)
        {
            TblDocumentUploadTableAdapter ta = new TblDocumentUploadTableAdapter();
            try
            {
                return ta.GetShowBillData(strpo, strShip, strbill);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyAdjust(int strbill, int strpo, int strShip)
        {
            TblDocumentUploadTableAdapter ta = new TblDocumentUploadTableAdapter();
            try
            {
                return ta.GetShowAdjustData(strpo, strShip, strbill);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPartyVat(int strbill, int strpo, int strShip)
        {
            TblDocumentUploadTableAdapter ta = new TblDocumentUploadTableAdapter();
            try
            {
                return ta.GetShowVatData(strpo, strShip, strbill);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetPOList(int poid, int shpid)
        {
            SprPOPreviewTableAdapter ta = new SprPOPreviewTableAdapter();
            try
            {
                return ta.GetPOPreviewData(poid, shpid);
            }
            catch { return new DataTable(); }
        }
        public DataTable GetMrrList(int poid, int shpid)
        {
            MRRDataTableTableAdapter ta = new MRRDataTableTableAdapter();
            try
            {
                return ta.GetMrrDataByposhpmntid(poid);
            }
            catch { return new DataTable(); }
        }
        public string PartybillActionByManagement(int billno, string remarks, bool action, int actionby)
        {
            SprPartybillActionByManagementTableAdapter adtp = new SprPartybillActionByManagementTableAdapter();
            string statusmsg = ""; //Action = False then Reject; Action = True then Approved;
            try
            {
                adtp.PartybillActionByManagementData(billno, remarks, action, actionby, ref statusmsg);
            }
            catch { statusmsg = "0"; }
            return statusmsg;
        }
        public string PartybillActionByAccounts(string billtype, int billid, int unitid, int poid, int shipmentid, int bnkid, int bnkaccid, string chequeno, DateTime chequedte,
        decimal amountcr, string bnknarration, string remarks, DateTime actualpaydte, string supcoaid, decimal amountdr, string supname, string supnarration,
        bool isCheque, bool isAdvice, bool isOnline, string payToPrint, int userid)
        {
            SprPartybillActionByAccountsTableAdapter adtp = new SprPartybillActionByAccountsTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.PartybillActionByAccountsData(billtype, billid, unitid, poid, shipmentid, bnkid, bnkaccid, chequeno, chequedte, amountcr, bnknarration, remarks,
                actualpaydte, supcoaid, amountdr, supname, supnarration, isCheque, isAdvice, isOnline, true, false, true, payToPrint, userid, 
                ref statusmsg);
            }
            catch  { statusmsg = "0"; }
            return statusmsg;
        }
        public void Updateusedchequeafteraccountsaction(int lstvid, string lastchequeno)
        {
            SprPartybillActionByAccountsTableAdapter adtp = new SprPartybillActionByAccountsTableAdapter();
            adtp.UpdateChequeNoData(lastchequeno, lstvid);
        }
                      
        #endregion

        #region ----------------- Vat Information -----------------
        public DataTable GetUnitList(int userid)
        {
            SprGetUnitWithoutACLTableAdapter ta = new SprGetUnitWithoutACLTableAdapter();
            try
            { return ta.GetUnitWithoutACLData(userid); }
            catch { return new DataTable(); }
        }
        public DataTable GetVatAccountList(int userid, int unitid)
        {
            TblVATAccountTableAdapter ta = new TblVATAccountTableAdapter();
            try
            { return ta.GetVatAccData(userid); }
            catch { return new DataTable(); }
        }
        public DataTable GetVatItemList(int vatacc)
        {
            TblItemVatTableAdapter ta = new TblItemVatTableAdapter();
            try
            { return ta.GetProductListData(vatacc); }
            catch { return new DataTable(); }
        }


        public DataTable GetUnitInfo(int vtacc)
        {
            UnitInformationDataTableAdapter ta = new UnitInformationDataTableAdapter();
            try
            { return ta.GetUnitInformationData(vtacc); }
            catch { return new DataTable(); }
        }
        public DataTable GetProductList(int vtacc)
        {
            TblItemVatTableAdapter ta = new TblItemVatTableAdapter();
            //SprVatItemAndVatMaterialTableAdapter ta = new SprVatItemAndVatMaterialTableAdapter();
            try
            { return ta.GetProductListData(vtacc); }//, "item"); }
            catch { return new DataTable(); }
        }
        public DataTable GetMaterialList(int vtacc)
        {
            TblConfigMaterialVATTableAdapter ta = new TblConfigMaterialVATTableAdapter();
            //SprVatItemAndVatMaterialTableAdapter ta = new SprVatItemAndVatMaterialTableAdapter();
            try
            { return ta.GetMaterialListData(vtacc); }//, "material"); }
            catch { return new DataTable(); }
        }
        public DataTable GetTreasuryDepositList()
        {
            TblConfigTreasuryDepositCodeTableAdapter ta = new TblConfigTreasuryDepositCodeTableAdapter();
            try
            { return ta.GetTreasuryDepositCodeData(); }
            catch { return new DataTable(); }
        }
        public string InsertProductionInformation(string itemid, string quantity, string date, string vatacc, string userid)
        {
            SprProductionEntryTableAdapter adtp = new SprProductionEntryTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.InsertProductionEntryData(int.Parse(itemid), decimal.Parse(quantity), DateTime.Parse(date), int.Parse(vatacc), int.Parse(userid), ref statusmsg);
            }
            catch (Exception ex) { statusmsg = ex.ToString(); }
            return statusmsg;
        }
        public DataTable GetDeclaredProductBOM(int itemid)
        {
            SprPriceDeclarationM1TableAdapter ta = new SprPriceDeclarationM1TableAdapter();
            try
            { return ta.GetDeclaredProductBOMData(itemid); }
            catch { return new DataTable(); }
        }
        //public DataTable GetPurchaseRegister(DateTime frmdate, DateTime todate, int vatmatid)
        //{
        //    SprPurchaseRegisterM16TableAdapter ta = new SprPurchaseRegisterM16TableAdapter();
        //    try
        //    { return ta.GetPurchaseRegisterM16Data(frmdate, todate, vatmatid); }
        //    catch { return new DataTable(); }
        //}
        //public DataTable GetSalesRegister(DateTime frmdate, DateTime todate, int vatitemid)
        //{
        //    SprSalesRegisterM17TableAdapter ta = new SprSalesRegisterM17TableAdapter();
        //    try
        //    { return ta.GetSalesRegisterM17Data(frmdate, todate, vatitemid); }
        //    catch { return new DataTable(); }
        //}

        public DataTable GetPurchaseRegister(DateTime frmdate, DateTime todate, int vatmatid, string vatacc)
        {
            //DataTable dt = new DataTable(); GetYsnFactoryTableAdapter ysn=new GetYsnFactoryTableAdapter();
            //dt = ysn.GetYsnFactoryData(int.Parse(vatacc));
            //if()
            SprPurchaseRegisterM16TableAdapter ta = new SprPurchaseRegisterM16TableAdapter();
            try
            { return ta.GetPurchaseRegisterM16Data(frmdate, todate, vatmatid, int.Parse(vatacc)); }
            catch { return new DataTable(); }
        }
        public DataTable GetSalesRegister(DateTime frmdate, DateTime todate, int vatitemid, string vatacc)
        {
            SprSalesRegisterM17TableAdapter ta = new SprSalesRegisterM17TableAdapter();
            try
            { return ta.GetSalesRegisterM17Data(frmdate, todate, vatitemid, int.Parse(vatacc)); }
            catch { return new DataTable(); }
        }
        public DataTable GetCurrentRegister(int vtacc, DateTime frmdate, DateTime todate, int type)
        {
            SprCurrentRegisterM18TableAdapter ta = new SprCurrentRegisterM18TableAdapter();
            try
            { return ta.GetCurrentRegisterM18Data(vtacc, frmdate, todate, type); }
            catch { return new DataTable(); }
        }
        public string InsertTreasuryDepositInformation(string treasuryid, decimal amount, int vatacc, string userid)
        {
            SprTreasuryDepositTableAdapter adtp = new SprTreasuryDepositTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.TreasuryDepositInformationData(vatacc, int.Parse(treasuryid), amount, false, int.Parse(userid), null, null, null, null, 0, ref statusmsg);
            }
            catch  { statusmsg = "0"; }
            return statusmsg;
        }
        public DataTable GetTreasuryDepositInformation(int vatacc, bool ysnComplete)
        {
            TreasuryDepositDataTableTableAdapter ta = new TreasuryDepositDataTableTableAdapter();
            try
            { return ta.GetTreasuryDepositData(ysnComplete, vatacc); }
            catch { return new DataTable(); }
        }
        public string UpdateTreasuryDepositInformation(string treasuryid, string challanno, DateTime challandt, string instrumentno, DateTime instrumentdt, string userid)
        {
            SprTreasuryDepositTableAdapter adtp = new SprTreasuryDepositTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.TreasuryDepositInformationData(null, int.Parse(treasuryid), 0, true, int.Parse(userid), challanno, challandt, instrumentno, instrumentdt, 1, ref statusmsg);
            }
            catch { statusmsg = "0"; }
            return statusmsg;
        }
        public string InsertMonthlyVatReturn(decimal OtherAdjustment, decimal OtherRebateForExport, decimal ExemptedPurchase, decimal OtherRebateAdjustment, decimal DEDO, DateTime Date_, int vtacc, int userid)
        {
            SprVatMonthlyReturnM19TableAdapter adtp = new SprVatMonthlyReturnM19TableAdapter();
            string statusmsg = "";
            try
            {
                adtp.VatMonthlyReturnM19Data(OtherAdjustment, OtherRebateForExport, ExemptedPurchase, OtherRebateAdjustment, DEDO, Date_, vtacc, userid, ref statusmsg);
            }
            catch { statusmsg = "0"; }
            return statusmsg;
        }
        public DataTable GetMonthlyVatReturn(int vtacc, DateTime date)
        {
            SprVatMonthlyReturnReportM19TableAdapter ta = new SprVatMonthlyReturnReportM19TableAdapter();
            try
            { return ta.GetVatMonthlyReturnReportM19Data(vtacc, date); }
            catch { return new DataTable(); }
        }
        public DataTable GetTreasuryPrint(int autoid)
        {
            TreasuryPrintDataTableTableAdapter ta = new TreasuryPrintDataTableTableAdapter();
            try
            { return ta.GetTreasuryPrintData(autoid); }
            catch { return new DataTable(); }
        }
        public string InsertOtherTaxRebateForExport(int unitid, DateTime date, decimal puramount, decimal rbtamount, string boeno, int vtacc)
        {
            SprOtherTaxRebateForExportDepositTableAdapter adtp = new SprOtherTaxRebateForExportDepositTableAdapter();
            string statusmsg = "";
            try
            {
                adtp.InsertOtherTaxRebateForExportData(unitid, date, puramount, rbtamount, boeno, vtacc, ref statusmsg);
            }
            catch { statusmsg = "0"; }
            return statusmsg;
        }

        #endregion

    }
}
