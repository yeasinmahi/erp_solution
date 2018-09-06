using SCM_DAL.Payment_All_Voucher_TDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_BLL
{
    public class Payment_All_Voucher_BLL
    {
        public DataTable GetUnitList(int intUserID)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUnitList(intUserID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUserRollCheck(string strEmail)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUserRollCheck(strEmail); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBankList(int intUnitID)
        {
            BankAndAccountListTableAdapter adp = new BankAndAccountListTableAdapter();
            try
            { return adp.GetBankList(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAccountList(int intUnitID, int intBankID)
        {
            BankAndAccountListTableAdapter adp = new BankAndAccountListTableAdapter();
            try
            { return adp.GetAccountList(intUnitID, intBankID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBankAndAccNameForAFBL(int intUnitID)
        {
            BankAndAccountListTableAdapter adp = new BankAndAccountListTableAdapter();
            try
            { return adp.GetBankAndAccNameForAFBL(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetReportForPaymentVoucher(int intUnitID)
        {
            SprAccountsApprovedPaymentForChequeTableAdapter adp = new SprAccountsApprovedPaymentForChequeTableAdapter();
            
            try
            { return adp.GetReportForPaymentVoucher(intUnitID, 2); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable CreateVoucher(int intUnitID, int intUser, int intBank, int intBankAcc, string xml)
        {
            SprAccountsInsertBPForBillWithoutAdjustmentForWebTableAdapter adp = new SprAccountsInsertBPForBillWithoutAdjustmentForWebTableAdapter();
            try
            { return adp.CreateVoucher(intUnitID, intUser, intBank, intBankAcc, xml); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertPaymentVoucherBP(int intUnitID, string strCCName, int intCCID, int intBank, int intBankAcc, string strInstrument, DateTime dteInstrumentDate, DateTime dteVoucherDate, int intUserID, string strPayTo, int intBillID, string strBillCode, decimal monApproveAmount, decimal monVoucherTotal, string strNarration, string xml, string strInstrumentNo)
        {
            try
            {
                string msg = "";
                SprPaymentVoucherBPForWebTableAdapter adp = new SprPaymentVoucherBPForWebTableAdapter();
                adp.InsertPaymentVoucherBP(intUnitID, strCCName, intCCID, intBank, intBankAcc, strInstrument, dteInstrumentDate, dteVoucherDate, intUserID, strPayTo, intBillID, strBillCode, monApproveAmount, monVoucherTotal, strNarration, xml, strInstrumentNo, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetChequeOrAdvice(int intBankAccID, int intUnitID, string strInstrument)
        {
            SprBankGetCheckNoForWebTableAdapter adp = new SprBankGetCheckNoForWebTableAdapter();
            try
            { return adp.GetChequeOrAdvice(intBankAccID, intUnitID, strInstrument); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertPaymentVoucherCP(int intUnitID, string strCCName, int intCCID, int intBank, int intBankAcc, string strInstrument, DateTime dteInstrumentDate, DateTime dteVoucherDate, int intUserID, string strPayTo, int intBillID, string strBillCode, decimal monApproveAmount, decimal monVoucherTotal, string strNarration, string xml, string strInstrumentNo)
        {
            try
            {
                string msg = "";
                SprPaymentVoucherCPForWebTableAdapter adp = new SprPaymentVoucherCPForWebTableAdapter();
                adp.InsertPaymentVoucherCP(intUnitID, strCCName, intCCID, intBank, intBankAcc, strInstrument, dteInstrumentDate, dteVoucherDate, intUserID, strPayTo, intBillID, strBillCode, monApproveAmount, monVoucherTotal, strNarration, xml, strInstrumentNo, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable InsertPOVoucherForAFBL(int intUnitID, int intUser, int intBank, int intBankAcc, string xml)
        {
            SprAccountsInsertBPForBillWithoutAdjustmentForWebForAFBLTableAdapter adp = new SprAccountsInsertBPForBillWithoutAdjustmentForWebForAFBLTableAdapter();
            try
            { return adp.InsertPOVoucherForAFBL(intUnitID, intUser, intBank, intBankAcc, xml); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetSupplierListForAddToChartOfAcount(int intUnitID)
        {
            SupplierListForAddToChartOfAccountTableAdapter adp = new SupplierListForAddToChartOfAccountTableAdapter();
            try
            { return adp.GetSupplierListForAddToChartOfAcount(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetAccountHeadForSupplierBridgeCOA(int intUnitID)
        {
            SprGetAccountHeadByParentIDAndUnitIDForWebTableAdapter adp = new SprGetAccountHeadByParentIDAndUnitIDForWebTableAdapter();
            try
            { return adp.GetAccountHeadForSupplierBridgeCOA(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertAndUpdateSupplierCOA(int intPart, int intSupplierID, int intUnitID, string strSupplier, int intUser, int intCOAID)
        {
            try
            {
                string msg = "";
                SprInsertUpdateSupplierCOAForWebTableAdapter adp = new SprInsertUpdateSupplierCOAForWebTableAdapter();
                adp.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, intUser, intCOAID, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetItemForCOABridge(int intUnitID)
        {
            ItemForCOABridgeTableAdapter adp = new ItemForCOABridgeTableAdapter();
            try
            { return adp.GetItemForCOABridge(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemForCOABridgeByUnitAndCategory(int intUnitID, int intCategoryID)
        {
            ItemForCOABridgeByUnitAndCategoryTableAdapter adp = new ItemForCOABridgeByUnitAndCategoryTableAdapter();
            try
            { return adp.GetItemForCOABridgeByUnitAndCategory(intUnitID, intCategoryID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetItemCOA(int intUnitID)
        {
            SprGetCOAChildByUnitTableAdapter adp = new SprGetCOAChildByUnitTableAdapter();
            try
            { return adp.GetItemCOA(intUnitID, null, true, null, null, null); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetCategory()
        {
            TblItemCategoryTableAdapter adp = new TblItemCategoryTableAdapter();
            try
            { return adp.GetCategory(); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetCOABankItem(int intUnitID)
        {
            QryItemListTableAdapter adp = new QryItemListTableAdapter();
            try
            { return adp.GetCOABankItem(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetCOABankItemByUnitAndCategoryID(int intUnitID, int intCategoryID)
        {
            COABankItemByUnitAndCategoryIDTableAdapter adp = new COABankItemByUnitAndCategoryIDTableAdapter();
            try
            { return adp.GetCOABankItemByUnitAndCategoryID(intUnitID, intCategoryID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string UpdateItemCOABridge(string xml)
        {
            try
            {
                string msg = "";
                SprMaterialCOABridgeForWebTableAdapter adp = new SprMaterialCOABridgeForWebTableAdapter();
                adp.UpdateItemCOABridge(xml, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetAllApproveReport(int intUnitID, DateTime dteFDate, DateTime dteTDate)
        {
            SprAllApprovedBillTableAdapter adp = new SprAllApprovedBillTableAdapter();
            try
            { return adp.GetAllApproveReport(intUnitID, dteFDate, dteTDate); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetBillRegisterForWeb(int intUnitID, DateTime dteFDate, DateTime dteTDate)
        {
            SprBillRegisterForWebTableAdapter adp = new SprBillRegisterForWebTableAdapter();
            try
            { return adp.GetBillRegisterForWeb(intUnitID, dteFDate, dteTDate); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetPendingPurchaseVoucher(int intUnitID, int intType)
        {
            SprAccountPendingPurchaseVoucherTableAdapter adp = new SprAccountPendingPurchaseVoucherTableAdapter();
            try
            { return adp.GetPendingPurchaseVoucher(intUnitID, intType); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public string InsertPurchaseVoucher(int intUnitID, int intUser, int intType, string xml)
        {
            try
            {
                string msg = "";
                SprInsertPurchaseVoucherForWebTableAdapter adp = new SprInsertPurchaseVoucherForWebTableAdapter();
                adp.InsertPurchaseVoucher(intUnitID, intUser, intType, xml, ref msg);
                return msg;
            }
            catch (Exception ex) { return ex.ToString(); }
        }
        public DataTable GetMDApprovalData(int intUnit, DateTime fDate, DateTime tDate, int intType)
        {
            SprPaymentRequestStatementTableAdapter adp = new SprPaymentRequestStatementTableAdapter();
            try
            { return adp.GetMDApprovalData(intUnit, fDate, tDate, intType); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }
        public DataTable GetUnitAddress(int intUnitID)
        {
            SprGetUnitTableAdapter adp = new SprGetUnitTableAdapter();
            try
            { return adp.GetUnitAddress(intUnitID); }
            catch (Exception ex) { ex.ToString(); return new DataTable(); }
        }

        public DataTable GetCount(int intEnroll)
        {
            SprGetUnitListForBillRegReportTableAdapter adp = new SprGetUnitListForBillRegReportTableAdapter();
            return adp.GetCountData(intEnroll);
        }
        public DataTable GetUnitListForAll()
        {
            TblUnitTableAdapter adp = new TblUnitTableAdapter();
            return adp.GetUnitForAll();
        }








































    }
}
