using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.VoucherForChqPrintTDSTableAdapters;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.BankVoucherPrintTDSTableAdapters;
using GLOBAL_BLL;
using System.Data;

namespace BLL.Accounts.Banking
{
    public class VoucherForChqPrint
    {
        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public VoucherForChqPrintTDS.sprAccountsVoucherBankGetDataForChqPrintDataTable GetBankVoucherList(string unitID, string fromDate, string toDate, bool isChequeDate,bool isChqPrinted, string code, bool isByCode)
        {
            if (!isByCode) code = null;
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);
            if (frm == null) { frm = DateTime.Now.Date.AddDays(-180); }
            if (to == null) { to = DateTime.Now.Date.AddDays(180); }
            to = to.Value.AddDays(1);

            sprAccountsVoucherBankGetDataForChqPrintTableAdapter ta = new sprAccountsVoucherBankGetDataForChqPrintTableAdapter();
            //DataTable dt = new DataTable(); dt = ta.GetCheckData(code, int.Parse(unitID), isChequeDate, frm, to, isChqPrinted);
            return ta.GetCheckData(code, int.Parse(unitID), isChequeDate, frm, to,isChqPrinted);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void UpdateBankVoucherList(int unitID, string fromDate, string toDate, bool isChequeDate, bool isChqPrinted, string code, bool isByCode, string strCode, string strBankName, string strAccountNo, string strUsedChequeNoList, string strPayToPrint, string strType,Int64 intBankVoucherID, string userID)
        {
            /*if (!isByCode) code = null;
            DateTime? frm = DateFormat.GetDateAtSQLDateFormat(fromDate), to = DateFormat.GetDateAtSQLDateFormat(toDate);
            if (frm == null) { frm = DateTime.Now.Date.AddDays(-7); }
            if (to == null) { to = DateTime.Now.Date.AddDays(6); }
            to = to.Value.AddDays(1);*/

            SprAccountsVoucherBankGetDataForChqPrintTableAdapter ta = new SprAccountsVoucherBankGetDataForChqPrintTableAdapter();
            if(code.ToLower().StartsWith("b"))ta.UpdatePayTo(strPayToPrint,int.Parse(userID), intBankVoucherID);
            else ta.UpdatePayToContra(strPayToPrint, int.Parse(userID), intBankVoucherID);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void UpdateBankVoucherPayTo(int unitID, string fromDate, string toDate, bool isChequeDate, bool isChqPrinted, string code, bool isByCode, string strCode, string strBankName, string strAccountNo, string strUsedChequeNoList, string strPayToPrint, string strType, Int64 intBankVoucherID, string userID)
        {           

            SprAccountsVoucherBankGetDataForChqPrintTableAdapter ta = new SprAccountsVoucherBankGetDataForChqPrintTableAdapter();
            if (strCode.ToLower().StartsWith("b")) ta.UpdatePayTo(strPayToPrint, int.Parse(userID), intBankVoucherID);
            else ta.UpdatePayToContra(strPayToPrint, int.Parse(userID), intBankVoucherID);
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void MakePrinted(string userID, string intBankVoucherID)
        {
            SprAccountsVoucherBankGetDataForChqPrintTableAdapter ta = new SprAccountsVoucherBankGetDataForChqPrintTableAdapter();
            ta.ChqPrintCompleted(int.Parse(userID), long.Parse(intBankVoucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void MakePrintedContra(string userID, string intContraVoucherID)
        {
            SprAccountsVoucherBankGetDataForChqPrintTableAdapter ta = new SprAccountsVoucherBankGetDataForChqPrintTableAdapter();
            ta.ChqPrintCompletedContra(int.Parse(userID), long.Parse(intContraVoucherID));
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeRegisterDataTable GetBankChequeRegisterPrint(string date, string userID, string unitID,string bankAccountId, string idList, string idListContra, bool isPrinted,ref string unitName, ref int? totalPreviuosData)
        {
            if ("" + unitID != "" && "" + bankAccountId != "")
            {
                SprAccountsVoucherBankGetPrintChequeRegisterTableAdapter ta = new SprAccountsVoucherBankGetPrintChequeRegisterTableAdapter();
                return ta.GetData(DateFormat.GetDateAtSQLDateFormat(date).Value.Date, int.Parse(userID), int.Parse(unitID), int.Parse(bankAccountId), idList, idListContra, isPrinted, ref unitName, ref totalPreviuosData);
            }

            return new BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeRegisterDataTable();
        }

        /// <summary>
        /// Developped By Akramul Haider
        /// </summary>
        public void ChequeRegisterPrinted(string idList, string idListContra)
        {
            SprAccountsVoucherBankChequeRegisterPrintedTableAdapter ta = new SprAccountsVoucherBankChequeRegisterPrintedTableAdapter();
            ta.GetData(idList, idListContra);
        }

        
    }
}
