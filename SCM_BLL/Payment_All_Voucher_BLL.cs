﻿using SCM_DAL.Payment_All_Voucher_TDSTableAdapters;
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
        

































    }
}
