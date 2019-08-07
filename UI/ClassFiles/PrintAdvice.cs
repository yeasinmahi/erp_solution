using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.CashVoucherPrintTDSTableAdapters;
using BLL.Accounts.Voucher;
using BLL.Accounts.Advice;
using BLL.Accounts.Banking;
using DAL.Accounts.Banking;
using GLOBAL_BLL;
using System.Text;

namespace UI.ClassFiles
{
    public class PrintAdvice
    {

        //string unitName = "";
        //string address = "";
        string voucherNumber = "";
        string voucherDate = "";
        string voucherNarration = "";
        decimal totalAmount = 0;
        string totalAmountInWord = "";
        string securityCode = "";

        string bankName = "";
        string accountNumber = "";
        string ChequeNumber = "";
        string chequeString = "";
        DateTime ChequeDate;

        AmountFormat format = new AmountFormat();

        public string PrintBankVoucher(string voucherType, string voucherID, string userID, ref string unitName, ref string unitAddress, ref string strForBarCode, ref string unitID)
        {
            string htmlString = "";
            DateTime? vDate = null;

            BankVoucher bnkv = new BankVoucher();
            BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintVoucherDataDataTable itemTable = bnkv.GetBankVoucherPrintData(voucherID, userID,
                                                                                                                           ref bankName, ref accountNumber,
                                                                                                                           ref ChequeNumber, ref ChequeDate,
                                                                                                                           
                                                                                                                           ref voucherNumber, ref voucherNarration,
                                                                                                                           ref totalAmount, ref unitName,
                                                                                                                           ref unitAddress, ref securityCode, ref vDate, ref unitID, ref chequeString);
            voucherDate = CommonClass.GetShortDateAtLocalDateFormat(vDate);
            strForBarCode = voucherNumber + securityCode;
            VoucherItem[] vitem = new VoucherItem[itemTable.Rows.Count];
            for (int i = 0; i < itemTable.Rows.Count; i++)
            {
                vitem[i] = new VoucherItem();

                vitem[i].AccountCode = itemTable[i].strCode;
                vitem[i].AccountName = itemTable[i].strAccName;
                vitem[i].Description = itemTable[i].strNarration;
                string strCode= itemTable[i].strCode;
                string strAccName = itemTable[i].strAccName;
                string strNarration = itemTable[i].strNarration;
                decimal Amount = 0;
                if (itemTable[i].monAmountControl == 0) // not Control Head
                {
                    vitem[i].Amount = double.Parse("" + itemTable[i].monAmountSub);
                    vitem[i].YsnControlHead = false;

                    Amount = itemTable[i].monAmountSub;
                }
                else
                {
                    vitem[i].Amount = double.Parse("" + itemTable[i].monAmountControl);
                    vitem[i].YsnControlHead = true;

                    Amount = itemTable[i].monAmountControl;
                }
                AmountFormat formatAmount = new AmountFormat();
                totalAmountInWord = formatAmount.GetTakaInWords(totalAmount, "", "Only");
                string[] addressLines = new string[1];
                addressLines[0] = unitAddress;


                bnkv.InsertVoucherData(voucherID, voucherDate, strForBarCode, strCode, strAccName, strNarration, Amount,
                bankName, accountNumber, ChequeNumber, ChequeDate.ToString(), voucherNumber, voucherNarration,
                totalAmount, unitName, unitAddress, securityCode, vDate.ToString(), Convert.ToInt32(unitID), chequeString, totalAmountInWord);



            }



            //htmlString = PreparePrintableBankVoucher(unitName, addressLines, voucherType, voucherNumber,
            //                                        voucherDate, vitem, totalAmountInWord, voucherNarration,
            //                                        bankName, accountNumber,
            //                                        ChequeNumber, CommonClass.GetShortDateAtLocalDateFormat(ChequeDate), chequeString);


            return htmlString;
        }

        private string PreparePrintableBankVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, VoucherItem[] itemDetails, string totalAmountInWords, string voucherNarration, string bankName, string accountNo, string chequeNo, string chequeDate, string chequeStringP)
        {
            StringBuilder sb = new StringBuilder();

          
            sb.Append(MakeHeaderRowForBankVoucher(unitName, addressLines, voucherTypeString, bankName, accountNo)); 
            sb.Append("<table style=\"width: 100%;\">");
            sb.Append("<tr>");
            sb.Append("<td  style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append(chequeStringP);

            sb.Append("<b>");
            sb.Append(chequeNo);
            sb.Append("</b></td>");
            sb.Append("<td  style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append(" <td width=\"28%\"  style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append("Voucher No. &nbsp");
            sb.Append(voucherNumber);
            sb.Append("</td>");
            sb.Append("</tr>");

            sb.Append("<tr>");
            sb.Append("<td style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append("Cheque Date :");
            sb.Append(chequeDate);
            sb.Append("</td>");
            sb.Append("<td  style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append("<td width=\"28%\" style=\"text-align:left\" class=\"HeaderStyle2\">");
            sb.Append("Voucher Date &nbsp&nbsp");
            sb.Append(date);
            //sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            sb.Append("<table style=\"width: 100%;\">");
            sb.Append("<tr>");
            sb.Append("<td style=\"text-align: center\" colspan=\"3\">");

            sb.Append(MakeItemTableForCashVoucher(itemDetails));
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan=\"3\">");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td class=\"CombinedAmmountNarration\" valign=\"top\">");
            sb.Append("<b style=\"text-align: left\">Sum Of Taka</b>&nbsp;");
            sb.Append("</td>");
            sb.Append("<td style=\"text-align: center\" valign=\"top\"> <b>: &nbsp</b></td>");
            sb.Append("<td class=\"CombinedAmmountNarration3\" valign=\"top\">");
            sb.Append(totalAmountInWords);
            sb.Append("</td>");
            sb.Append("</tr>");

            sb.Append("<tr style=\"text-align: right\">");
            sb.Append("<td class=\"CombinedAmmountNarration\" valign=\"top\">");
            sb.Append("<b>Description</b> &nbsp;");
            sb.Append("</td>");
            sb.Append("<td style=\"text-align: center\" valign=\"top\"><b>: &nbsp</b></td>");
            sb.Append("<td class=\"CombinedAmmountNarration2\" valign=\"top\">");
            sb.Append(voucherNarration);
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td >");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(MakeSignatureTableWith6Sign());
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<br />");

            return sb.ToString();
        }

        private string MakeHeaderRowForBankVoucher(string unitName, string[] addressLines, string voucherTypeString, string bankName, string accountNo)
        {
            StringBuilder headerRow = new StringBuilder();
            headerRow.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            headerRow.Append("<tr>");
            headerRow.Append(" <td style=\"text-align: center\" colspan=\"3\">");
            headerRow.Append("&nbsp;<span class=\"HeaderStyle\">");
            headerRow.Append(unitName);
            headerRow.Append("</span><br /><span class=\"HeaderStyle2\">");
            for (int i = 0; i < addressLines.Length; i++)
            {
                headerRow.Append(addressLines[i]);
                headerRow.Append("<br />");

            }

            headerRow.Append("</span><br />");
            headerRow.Append("<span class=\"VoucherStyle\">");
            headerRow.Append(voucherTypeString);
            headerRow.Append("</span><br /><br />");
            headerRow.Append("<span class=\"VoucherStyle2\">Bank Name and A/C NO.&nbsp</span>");
            headerRow.Append("<span class=\"VoucherStyle2\">");
            headerRow.Append(bankName);
            headerRow.Append("&nbsp;");
            headerRow.Append(accountNo);
            headerRow.Append("</span>");

            headerRow.Append("</td>");
            headerRow.Append("</tr>");
            headerRow.Append("<tr>");
            headerRow.Append("<td>");

            headerRow.Append("</td>");
            headerRow.Append("</tr>");
            headerRow.Append("</table >");
            return headerRow.ToString();
        }

        private string MakeSignatureTableWith6Sign()
        {
            StringBuilder signatureTable = new StringBuilder();
            signatureTable.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            signatureTable.Append("<tr>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"bottom\">");
            signatureTable.Append("____________");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"bottom\">");
            signatureTable.Append("_______________");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"bottom\">");
            signatureTable.Append("__________________");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle2\" valign=\"bottom\">");
            signatureTable.Append("______________");
            signatureTable.Append("</td>");
            //signatureTable.Append("<td class=\"SignStyle2\" valign=\"bottom\">");
            //signatureTable.Append("____________________");
            //signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"bottom\">");
            signatureTable.Append("_____________");
            //signatureTable.Append("&nbsp;");
            signatureTable.Append("</td>");
            signatureTable.Append("</tr>");
            signatureTable.Append("<tr>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"top\">");
            signatureTable.Append("Prepared By");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"top\">");
            signatureTable.Append("Reviewed By");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"top\">");
            signatureTable.Append("Authorised Signatory<br />");
            signatureTable.Append("Akij Group");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle2\" valign=\"top\">");
            signatureTable.Append("Authorised Signatory<br />");
            signatureTable.Append("Akij Group");
            signatureTable.Append("</td>");
            //signatureTable.Append("<td class=\"SignStyle2\" valign=\"top\">");
            //signatureTable.Append("Authorised Signatory<br>");
            //signatureTable.Append(" Akij Group");
            //signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"top\">");
            signatureTable.Append("Payee");
            signatureTable.Append("</td>");
            signatureTable.Append("</tr>");
            signatureTable.Append("</table>");

            return signatureTable.ToString();
        }


        public string PrintCashVoucher(string voucherType, string voucherID, string userID, ref string unitName, ref string unitAddress, ref string strForBarCode, ref string unitID)
        {
            string htmlString = "";
            CashVoucher chv = new CashVoucher();
            DateTime? vDate = null;

            CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintVoucherDataDataTable itemTable = chv.GetCashVoucherPrintData(voucherID, userID,
                                                                                                                          ref voucherNumber,
                                                                                                                          ref voucherNarration,
                                                                                                                          ref totalAmount,
                                                                                                                          ref unitName,
                                                                                                                          ref unitAddress,
                                                                                                                          ref securityCode,
                                                                                                                          ref vDate,
                                                                                                                          ref unitID
                                                                                                                          );
            voucherDate = CommonClass.GetShortDateAtLocalDateFormat(vDate);
            strForBarCode = voucherNumber + securityCode;
            VoucherItem[] vitem = new VoucherItem[itemTable.Rows.Count];
            for (int i = 0; i < itemTable.Rows.Count; i++)
            {
                vitem[i] = new VoucherItem();
                vitem[i].AccountCode = itemTable[i].strCode;
                vitem[i].AccountName = itemTable[i].strAccName;
                vitem[i].Description = itemTable[i].strNarration;
                if (itemTable[i].monAmountControl == 0) // not Control Head
                {
                    vitem[i].Amount = double.Parse("" + itemTable[i].monAmountSub);
                    vitem[i].YsnControlHead = false;
                }
                else
                {
                    vitem[i].Amount = double.Parse("" + itemTable[i].monAmountControl);
                    vitem[i].YsnControlHead = true;
                }

            }

            AmountFormat formatAmount = new AmountFormat();
            totalAmountInWord = formatAmount.GetTakaInWords(totalAmount, "", "Only");
            string[] addressLines = new string[1];
            addressLines[0] = unitAddress;

            htmlString = PreparePrintableCashVoucher(unitName, addressLines, voucherType, voucherNumber, voucherDate, vitem, totalAmountInWord, voucherNarration);



            return htmlString;
        }

        private string PreparePrintableCashVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, VoucherItem[] itemDetails, string totalAmountInWords, string voucherNarration)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"width: 100%;\">");

            sb.Append(MakeHeaderRowForCashVoucher(unitName, addressLines, voucherTypeString));
            sb.Append("</table>");
            sb.Append("<tr>");
            sb.Append("<td colspan=\"3\">");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<table style=\"width: 100%;\">");
            sb.Append("<tr>");
            sb.Append(" <td width=\"20%\"  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append(" <td width=\"52%\"  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append(" <td  style=\"text-align: left\" class=\"HeaderStyle2\">");
            sb.Append("Voucher No. &nbsp");
            sb.Append(voucherNumber);
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td width=\"20%\" style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append(" <td width=\"52%\"  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append("<td style=\"text-align: left\" class=\"HeaderStyle2\">");
            sb.Append("Voucher Date &nbsp");
            sb.Append(date);
            //sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style=\"text-align: center\" colspan=\"3\">");

            sb.Append(MakeItemTableForCashVoucher(itemDetails));
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan=\"3\">");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td width=\"20%\" class=\"CombinedAmmountNarration\" valign=\"top\">");
            sb.Append("<b style=\"text-align: left\">Sum Of Taka</b>&nbsp;");
            sb.Append("</td>");
            //sb.Append("<td style=\"text-align: center\" valign=\"top\"> <b>: &nbsp</b></td>");
            sb.Append("<td colspan=\"2\" class=\"CombinedAmmountNarration3\" valign=\"top\">");
            sb.Append(totalAmountInWords);
            sb.Append("</td>");
            sb.Append("</tr>");

            sb.Append("<tr style=\"text-align: right\">");
            sb.Append("<td width=\"20%\" class=\"CombinedAmmountNarration\" valign=\"top\">");
            sb.Append("<b>Description</b> &nbsp;");
            sb.Append("</td>");
            //sb.Append("<td style=\"text-align: center\" valign=\"top\"><b>: &nbsp</b></td>");
            sb.Append("<td colspan=\"2\" class=\"CombinedAmmountNarration2\" valign=\"top\">");
            sb.Append(voucherNarration);
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td >");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(MakeSignatureTableWith6Sign());





            return sb.ToString();
        }
        private string MakeItemTableForCashVoucher(VoucherItem[] items)
        {
            double totalAmount = 0;
            StringBuilder itemTable = new StringBuilder();

            itemTable.Append("<table style=\"border-color: #000000; width: 100%\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\">");
            itemTable.Append("<tr>");
            itemTable.Append("<td class=\"AccStyleHeader\">");
            itemTable.Append("Account Code No");
            itemTable.Append("</td>");
            itemTable.Append("<td class=\"NarationStyleHeader\">");
            itemTable.Append("Head of Accounts");
            itemTable.Append("</td>");
            //itemTable.Append("<td class=\"DescriptionStyleHeader\">"); 
            //itemTable.Append("Description");                   
            //itemTable.Append("</td>");                
            itemTable.Append("<td class=\"AmountStyleHeader\">");
            itemTable.Append("Sub-Account");
            itemTable.Append("</td>");
            itemTable.Append("<td class=\"AmountStyleHeader\">");
            itemTable.Append("Control-Account");
            itemTable.Append("</td>");
            for (int i = 0; i < items.Length; i++)
            {
                itemTable.Append("<tr>");
                itemTable.Append("<td class=\"AccStyle\">");
                itemTable.Append(items[i].AccountCode);
                itemTable.Append("</td>");
                itemTable.Append("<td class=\"NarationStyle\">");
                if (items[i].YsnControlHead)
                {
                    itemTable.Append("&nbsp;");
                }
                else
                {
                    itemTable.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

                }
                itemTable.Append(items[i].AccountName);
                itemTable.Append("</td>");

                //Description
                //itemTable.Append("<td class=\"DescriptionStyle\">");
                //itemTable.Append(items[i].Description);
                //itemTable.Append("</td>");
                // sub Account Amount
                itemTable.Append("<td class=\"AmountStyle\">");
                if (items[i].YsnControlHead)
                {
                    itemTable.Append("&nbsp;");
                }
                else
                {
                    itemTable.Append(format.SetCommaInAmount(items[i].Amount, "", ""));
                }
                itemTable.Append("</td>");

                // Control Account Amount
                itemTable.Append("<td class=\"AmountStyle\">");
                if (items[i].YsnControlHead)
                {
                    itemTable.Append(format.SetCommaInAmount(items[i].Amount, "", ""));
                    totalAmount = totalAmount + items[i].Amount;
                }
                else
                {
                    itemTable.Append("&nbsp;");
                }
                itemTable.Append("</td>");

                itemTable.Append("</tr>");

            }
            // total Row
            itemTable.Append("<tr>");
            itemTable.Append("<td class=\"TotalStyle1\" colspan=\"2\">");
            itemTable.Append("TOTAL &nbsp&nbsp");
            itemTable.Append("</td>");
            itemTable.Append("<td class=\"TotalAmountStyle\">");
            itemTable.Append(format.SetCommaInAmount(totalAmount, "", ""));
            itemTable.Append("</td>");
            itemTable.Append("<td class=\"TotalAmountStyle\">");
            itemTable.Append(format.SetCommaInAmount(totalAmount, "", ""));
            itemTable.Append("</td>");
            itemTable.Append("</tr>");
            itemTable.Append("</table>");
            return itemTable.ToString();
        }


        private string MakeHeaderRowForCashVoucher(string unitName, string[] addressLines, string voucherTypeString)
        {
            StringBuilder headerRow = new StringBuilder();
            headerRow.Append("<tr>");
            headerRow.Append("<td style=\"text-align: center\"  valign=\"top\" width=\"20%\">");
            headerRow.Append("&nbsp");
            headerRow.Append("</td>");
            headerRow.Append(" <td style=\"text-align: center\"  valign=\"top\" width=\"60%\">");
            headerRow.Append("&nbsp;<span class=\"HeaderStyle\">");
            headerRow.Append(unitName);
            headerRow.Append("</span><br /><span class=\"HeaderStyle2\">");
            for (int i = 0; i < addressLines.Length; i++)
            {
                headerRow.Append(addressLines[i]);
                headerRow.Append("<br />");

            }

            headerRow.Append("</span><br />");
            headerRow.Append("<span class=\"VoucherStyle\">");
            headerRow.Append(voucherTypeString);
            headerRow.Append("</span>");
            headerRow.Append("</td>");
            headerRow.Append("<td style=\"text-align: center\"  valign=\"top\" width=\"20%\">");
            headerRow.Append("&nbsp");
            headerRow.Append("</td>");
            headerRow.Append("</tr>");
            return headerRow.ToString();
        }

    }
}