using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using DAL.Accounts.Voucher;
using DAL.Accounts.Voucher.CashVoucherPrintTDSTableAdapters;
using BLL.Accounts.Voucher;

using BLL.Accounts.Banking;
using DAL.Accounts.Banking;
using GLOBAL_BLL;


/// <summary>
/// Summary description for Print
/// Developed By Himadri Das
/// </summary>
namespace UI.ClassFiles
{
    public class Print
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

            htmlString = PreparePrintableBankVoucher(unitName, addressLines, voucherType, voucherNumber,
                                                    voucherDate, vitem, totalAmountInWord, voucherNarration,
                                                    bankName, accountNumber,
                                                    ChequeNumber, CommonClass.GetShortDateAtLocalDateFormat(ChequeDate), chequeString);


            return htmlString;
        }

        public string PrintJournalVoucher(string voucherType, string voucherID, string userID, ref string unitName, ref string unitAddress, ref string strForBarCode, ref string unitID)
        {
            string htmlString = "";
            DateTime? vDate = null;
            decimal totalAmountDr = 0, totalAmountCr = 0;

            JournalVoucher jv = new JournalVoucher();
            JournalVoucherPrintTDS.SprAccountsVoucherJournalGetPrintVoucherDataDataTable itemTable = jv.GetJournalVoucherPrintData(voucherID, userID,
                                                                                                                                   ref voucherNumber,
                                                                                                                                   ref voucherNarration,
                                                                                                                                   ref totalAmountDr,
                                                                                                                                   ref totalAmountCr,
                                                                                                                                   ref unitName,
                                                                                                                                   ref unitAddress,
                                                                                                                                   ref securityCode,
                                                                                                                                   ref vDate,
                                                                                                                                   ref unitID);

            voucherDate = CommonClass.GetShortDateAtLocalDateFormat(vDate);
            strForBarCode = voucherNumber + securityCode;
            AmountFormat formatAmount = new AmountFormat();
            totalAmountInWord = formatAmount.GetTakaInWords(totalAmountCr, "", "Only");
            string[] addressLines = new string[1];
            addressLines[0] = unitAddress;
            htmlString = PreparePrintableJournelVoucher(unitName, addressLines, voucherType, voucherNumber, voucherDate, (DataTable)itemTable, totalAmountInWord, voucherNarration, totalAmountDr, totalAmountCr);
            return htmlString;
        }
        /*
        public string PrintMoneyReceipt(string id, string type, string userID)
        {
            string htmlString = ""; 
            string bankPayType="";        
            string mrDate = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
           // AmountFormat format = new AmountFormat();
        
            if (type == "bn") // bank MRR
                {
                    BankVoucher bn = new BankVoucher();
                    BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintMRDataDataTable mrBank = bn.GetBankMRPrintData(id, userID);
                    if(mrBank[0].ysnCheque)
                    {
                        bankPayType="Cheque";
                    }
                    else if(mrBank[0].ysnDemandDraft)
                    {
                        bankPayType="Demand Draft";
                    }
                    else
                    {
                        bankPayType="Pay Order";
                    }

                
                    htmlString = PreparePrintableMonetReceipt(mrBank[0].strUnit,
                                                              mrBank[0].strUnitAddress,
                                                              mrBank[0].strReceiveFrom,
                                                              format.SetCommaInAmount(mrBank[0].monAmount,"",""),
                                                              new AmountFormat().GetTakaInWords(mrBank[0].monAmount, "Only", ""),
                                                              true,
                                                              bankPayType,
                                                              mrBank[0].strNo,
                                                              CommonClass.GetShortDateAtLocalDateFormat(mrBank[0].dteDate),
                                                              mrBank[0].strBankName,
                                                              mrBank[0].strBranchName,
                                                              mrBank[0].strCode,
                                                              mrDate);
                                                          
                }
                else //Cash Mrr
                {

                    CashVoucher ch = new CashVoucher();
                    CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintMRDataDataTable mrCash = ch.GetCashMRPrintData(id, userID);
                    htmlString = PreparePrintableMonetReceipt(mrCash[0].strUnit,
                                                              mrCash[0].strUnitAddress,
                                                              mrCash[0].strReceiveFrom,
                                                              format.SetCommaInAmount(mrCash[0].monAmount,"",""),
                                                              new AmountFormat().GetTakaInWords(mrCash[0].monAmount, "Only", ""),
                                                              false,
                                                              "",
                                                              "",
                                                              "",
                                                              "",
                                                              "",
                                                              mrCash[0].strCode,
                                                              mrDate);




                }

            return htmlString;
        }
        */
        public string PrintContraVoucher(string voucherType, string voucherID, string userID, ref string unitName, ref string unitAddress, ref string strForBarCode, ref string unitID)
        {
            string htmlString = "";
            DateTime? vDate = null;
            DateTime? cDate = null;
            string bankName = "", accountNo = "", CheckNO = "";

            ContraVoucher cnv = new ContraVoucher();
            ContraVoucherPrintTDS.SprAccountsVoucherContraGetPrintVoucherDataDataTable itemTable = cnv.GetContraVoucherPrintData(voucherID, userID,
                                                                                                                          ref voucherNumber,
                                                                                                                          ref voucherNarration,
                                                                                                                          ref totalAmount,
                                                                                                                          ref unitName,
                                                                                                                          ref unitAddress,
                                                                                                                          ref securityCode,
                                                                                                                          ref vDate,
                                                                                                                          ref unitID,
                                                                                                                          ref bankName,
                                                                                                                          ref accountNo,
                                                                                                                          ref CheckNO,
                                                                                                                          ref cDate);
            voucherDate = CommonClass.GetShortDateAtLocalDateFormat(vDate);
            strForBarCode = voucherNumber + securityCode;
            /* VoucherItem[] vitem = new VoucherItem[itemTable.Rows.Count];
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

             }*/

            AmountFormat formatAmount = new AmountFormat();
            totalAmountInWord = formatAmount.GetTakaInWords(totalAmount, "", "Only");
            string[] addressLines = new string[1];
            addressLines[0] = unitAddress;

            htmlString = PreparePrintableContraVoucher(unitName, addressLines, voucherType, voucherNumber, voucherDate, itemTable, totalAmountInWord, voucherNarration, bankName, accountNo, CheckNO, cDate);



            return htmlString;
        }

        public string PrintAdvice(string vCode, int vID, int unitID, ref string unitName, ref string unitAddress, ref DateTime? adviceDate, ref string adviceNumber, ref string securityCode)
        {
            Advice ad = new Advice();
            string accountNo = "";
            AdviceTDS.SprBankLoanAdvicePrintGetDataDataTable tbl = ad.GetPrintData(vCode, vID, unitID, ref unitName, ref unitAddress, ref accountNo, ref adviceDate, ref adviceNumber, ref securityCode);
            StringBuilder sb = new StringBuilder();
            decimal total = 0;
            //decimal totalP = 0;
            sb.Append("");

            sb.Append("<br />");
            sb.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("Please Adjust Our loan according to following manners by debiting our <b><u>Current Accout No : " + accountNo + "</u></b>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align=\"left\">");
            sb.Append("<table width=\"98%\" border=\"1px\"  style=\"text-align:center; border-color:Black; border-collapse:collapse\" cellpadding=\"0\" cellspacing=\"0\">");
            sb.Append("<tr class=\"HeaderStyleAdvice\" >");
            sb.Append("<td rowspan=\"2\" class=\"style1\">No.</td>");
            sb.Append("<td rowspan=\"2\"  class=\"style1\">Account Number</td>");
            sb.Append("<td colspan=\"3\" class=\"style1\">Adjusted Amount</td>");
            sb.Append("</tr>");
            sb.Append("<tr class=\"HeaderStyleAdvice\" >");
            //sb.Append("<td class=\"style1\">No.</td>");
            //sb.Append("<td class=\"style1\">Account Name</td>");
            //sb.Append("<td class=\"style1\">Account Number</td>");

            sb.Append("<td class=\"style1\">Principal</td>");
            sb.Append("<td class=\"style1\">Profit</td>");
            sb.Append("<td class=\"style1\">Total </td>");
            sb.Append("</tr>");
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td style=\"border-color:Black\">");
                sb.Append((i + 1).ToString());
                sb.Append("</td>");
                /* sb.Append("<td style=\"border-color:Black\">");
                              sb.Append(tbl[i].strAccountName);
                 sb.Append("</td>");*/
                sb.Append("<td style=\"border-color:Black\">");
                sb.Append(tbl[i].strName);
                sb.Append("</td>");

                sb.Append("<td style=\"text-align: right;border-color:Black \" >");
                //sb.Append(string.Format("{0:F2}", tbl[i].IsmonPrincipleNull()?0: tbl[i].monPrinciple));
                sb.Append("&nbsp");
                sb.Append("</td>");
                sb.Append("<td style=\"text-align: right;border-color:Black \" >");
                //sb.Append(string.Format("{0:F2}", tbl[i].IsmonInterestNull()?0:tbl[i].monInterest));
                sb.Append("&nbsp");
                sb.Append("</td>");
                sb.Append("<td style=\"text-align: right;border-color:Black \" >");
                sb.Append(string.Format("{0:F2}", tbl[i].IsmonAmountNull() ? 0 : tbl[i].monAmount));
                sb.Append("</td>");
                sb.Append("</tr>");
                total = total + (tbl[i].IsmonAmountNull() ? 0 : tbl[i].monAmount);
            }
            /* <tr  >
              <td style="border-color:Black">1.</td>
              <td style="border-color:Black">AFBL</td>
              <td style="border-color:Black" >MPI-9990</td>
              <td style="text-align: right;border-color:Black " >50,000/=</td>
             </tr>
             <tr >
             <td style="border-color:Black">2.</td>
             <td style="border-color:Black">AFBL</td>
              <td style="border-color:Black" >MPI-3352</td>
              <td style="text-align: right;border-color:Black ">7,00,000/=</td>
             </tr>*/
            sb.Append("<tr style=\"border-color:Black\">");
            sb.Append("<td colspan=\"4\" style=\"border-color:Black\"><b>Total</b></td>");
            sb.Append("<td style=\"text-align: right;border-color:Black \" ><b style=\"text-align: right\">" + string.Format("{0:F2}", total) + "</b></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</td>");

            sb.Append("</tr>");
            sb.Append("</table>");

            sb.Append("<table width=\"100%\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"20%\">");
            sb.Append("<b>Amount In Word:</b>");
            sb.Append("</td>");
            sb.Append("<td style=\"font-weight: 700\">");
            AmountFormat formatAmount = new AmountFormat();

            sb.Append(formatAmount.GetTakaInWords(total, "Taka", "Only"));
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<table width=\"100%\">");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("_________________");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("__________________");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("Officer(Accounts)");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("Manager(Banking)");
            sb.Append("</td>");
            sb.Append("</tr>");

            sb.Append("</table>");


            return sb.ToString();
        }
        private string PreparePrintableMonetReceipt(string unitName, string addressLine, string recipientName, string totalAmount, string amountInWords, bool ysnBankReceive, string bankPayType, string bankPayTypeNumber, string bankDate, string bankName, string branchName, string moneyReceiptID, string mrDate)
        {
            StringBuilder mr = new StringBuilder();
            //header table
            mr.Append("<table style=\"width: 100%;\">");
            mr.Append("<tr>");
            mr.Append("<td style=\"text-align: center\" colspan=\"3\"  valign=\"top\">");
            mr.Append("<span class=\"MoneyReceiptStyle\">MONEY RECEIPT</span><br />");
            mr.Append("&nbsp;<span class=\"HeaderStyleMR\">");
            mr.Append(unitName);
            mr.Append("</span><br />");
            mr.Append(" <span class=\"HeaderStyleMR2\">");
            mr.Append(addressLine);
            mr.Append("</span>");
            mr.Append("</td>");
            mr.Append("</tr>");
            mr.Append("</table>");

            // MR and Date
            mr.Append("<table width=\"100%\">");
            mr.Append("<tr>");
            mr.Append("<td class=\"MoneyReceiptBodyStyle\" style=\"text-align:left\">");
            mr.Append("<b>MR N0-&nbsp;" + moneyReceiptID + "</b>");
            mr.Append("</td>");
            mr.Append("<td class=\"MoneyReceiptBodyStyle\" style=\"text-align:right\">");
            mr.Append(" Date :" + mrDate);
            mr.Append("</td>");
            mr.Append("</tr>");
            mr.Append("</table>");

            //body of MR

            //Receipnt Line
            mr.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            mr.Append("<tr class=\"MoneyReceiptBodyStyle\">");
            mr.Append(" <td  style=\"width:22%\">Receive With Thanks From </td>");
            mr.Append("<td  style=\"width:78%; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
            mr.Append("&nbsp;&nbsp; <b>" + recipientName + "</b>");
            mr.Append(" </td>");
            mr.Append("</tr>");
            mr.Append("<tr class=\"MoneyReceiptBodyStyle\">");
            mr.Append("<td colspan=\"2\" >&nbsp;</td>");
            mr.Append("</tr>");
            mr.Append("</table>");

            // taka in Words Line

            mr.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            mr.Append("<tr class=\"MoneyReceiptBodyStyle\">");
            mr.Append("<td valign=\"top\" style=\"width:5%\"> Taka</td>");
            mr.Append("<td style=\"width:95%; text-align:left; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
            mr.Append("&nbsp; &nbsp; <b>" + amountInWords + "</b> ");
            mr.Append("</td>");
            mr.Append("</tr>");
            mr.Append("<td colspan=\"4\"> &nbsp;</td>");
            mr.Append("</tr>");
            mr.Append(" </table>");

            if (!ysnBankReceive) // Cash Receive
            {
                mr.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
                mr.Append("<tr class=\"MoneyReceiptBodyStyle\">");
                mr.Append("<td>");
                mr.Append("Only by Cash.");
                mr.Append("</td>");
                mr.Append("</tr>");
                mr.Append(" </table>");

            }

            else // bank receive
            {
                // Line For pay type number,and bank Date\
                mr.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
                mr.Append(" <tr class=\"MoneyReceiptBodyStyle\">");
                mr.Append("<td style=\"width:22%\">");
                mr.Append(" Only by &nbsp;" + bankPayType + "&nbsp;No");
                mr.Append("</td>");
                mr.Append("<td style=\"width:40%; text-align:center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
                mr.Append(bankPayTypeNumber);
                mr.Append("</td>");
                mr.Append("<td style=\"width:13%; text-align:center\">Date</td>");
                mr.Append("<td style=\"width:25%; text-align:center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
                mr.Append(bankDate);
                mr.Append("</td></tr>");
                mr.Append(" <tr class=\"MoneyReceiptBodyStyle\">");
                mr.Append("<td colspan=\"4\">&nbsp</td>");
                mr.Append(" </tr>");
                mr.Append("</table>");

                // Line For Bank name and Branch Name
                mr.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
                mr.Append("<tr class=\"MoneyReceiptBodyStyle\">");
                mr.Append("<td style=\"width:7%\">Bank</td>");
                mr.Append("<td style=\"width:50%; text-align:center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
                mr.Append(bankName);
                mr.Append("</td>");
                mr.Append("<td style=\"width:10%; text-align:center;\">Branch</td>");
                mr.Append("<td style=\"width:33%; text-align:center; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000\">");
                mr.Append(branchName);
                mr.Append("</td>");
                mr.Append(" </tr>");
                mr.Append(" </table>");

            }

            mr.Append("<br />");

            // Add Total BOX
            mr.Append("<table>");
            mr.Append("<tr>");
            mr.Append("<td> TK </td>");
            mr.Append("<td> &nbsp </td>");
            mr.Append("<td style=\"border: thin solid #000000; width: 85%;\">" + totalAmount + "/=</td>");
            mr.Append("</tr>");
            mr.Append("</table>");
            mr.Append(" <br /> ");

            // add Sign Table
            mr.Append(PrepareSignTableWith5Sign());


            return mr.ToString();
        }
        private string PreparePrintableCashVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, VoucherItem[] itemDetails, string totalAmountInWords, string voucherNarration)
        {
            StringBuilder sb = new StringBuilder();
            /*sb.Append("<table style=\"width: 100%;\">");

            sb.Append(MakeHeaderRowForCashVoucher(unitName, addressLines, voucherTypeString));
            sb.Append("</table>");*/
            //sb.Append("<tr>");
            //sb.Append("<td colspan=\"3\">");
            //sb.Append("&nbsp;");
            //sb.Append("</td>");
            //sb.Append("</tr>");
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
            return sb.ToString();
        }
        public string PrintBnkVoucher(string voucherType, string voucherID, string userID, ref string unitName, ref string unitAddress, ref string strForBarCode, ref string unitID)
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

            htmlString = PreparePrintablBankVoucher(unitName, addressLines, voucherType, voucherNumber,
                                                    voucherDate, vitem, totalAmountInWord, voucherNarration,
                                                    bankName, accountNumber,
                                                    ChequeNumber, CommonClass.GetShortDateAtLocalDateFormat(ChequeDate), chequeString);


            return htmlString;
        }
        private string PreparePrintablBankVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, VoucherItem[] itemDetails, string totalAmountInWords, string voucherNarration, string bankName, string accountNo, string chequeNo, string chequeDate, string chequeStringP)
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
            //sb.Append(MakeSignatureTableWith6Sign());
            return sb.ToString();
        }
        private string PreparePrintableJournelVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, DataTable tbl, string totalAmountInWords, string voucherNarration, decimal debitAmount, decimal crediAmount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"width: 100%;\">");

            //sb.Append(MakeHeaderRowForCashVoucher(unitName, addressLines, voucherTypeString));

            sb.Append("<tr>");
            sb.Append(" <td width=\"20%\" style=\"text-align: right\" class=\"HeaderStyle2\">");
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

            sb.Append(MakeItemTableForJournel(tbl, debitAmount, crediAmount));
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan=\"3\">");
            sb.Append("&nbsp;");
            sb.Append("</td>");
            //sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td width=\"20%\" class=\"CombinedAmmountNarration\" valign=\"top\">");
            sb.Append("<b style=\"text-align: left\">Sum Of Taka :</b>&nbsp;");
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
        private string PreparePrintableContraVoucher(string unitName, string[] addressLines, string voucherTypeString, string voucherNumber, string date, ContraVoucherPrintTDS.SprAccountsVoucherContraGetPrintVoucherDataDataTable itemDetails, string totalAmountInWords, string voucherNarration, string bankName, string accountNo, string chequeNo, DateTime? chequeDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(MakeHeaderRowForBankVoucher(unitName, addressLines, voucherTypeString, bankName, accountNo));
            sb.Append("<table style=\"width: 100%;\">");
            sb.Append("<tr>");
            sb.Append(" <td width=\"20%\"  style=\"text-align: left\" class=\"HeaderStyle2\">");
            sb.Append("Cheque Number :");
            sb.Append(chequeNo);
            sb.Append("</td>");
            sb.Append(" <td width=\"52%\"  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("");
            sb.Append("</td>");
            sb.Append(" <td  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("Voucher No. &nbsp");
            sb.Append(voucherNumber);
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td width=\"20%\" style=\"text-align: left\" class=\"HeaderStyle2\">");
            sb.Append("Cheque Date :");
            sb.Append(CommonClass.GetShortDateAtLocalDateFormat(chequeDate));
            sb.Append("</td>");
            sb.Append(" <td width=\"52%\"  style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("&nbsp");
            sb.Append("</td>");
            sb.Append("<td style=\"text-align: right\" class=\"HeaderStyle2\">");
            sb.Append("Voucher Date &nbsp");
            sb.Append(date);
            //sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td style=\"text-align: center\" colspan=\"3\">");

            sb.Append(MakeItemTableForContraVoucher(itemDetails));
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
        private string MakeItemTableForJournel(DataTable tbl, decimal debitToal, decimal creditTotal)
        {
            StringBuilder itemBuilder = new StringBuilder();
            itemBuilder.Append("<table style=\"border-color: #000000; width: 100%\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\">");
            itemBuilder.Append("<tr>");
            itemBuilder.Append("<td class=\"AccStyleHeaderJR\" rowspan=\"2\"> Account Code No</td>");
            itemBuilder.Append("<td class=\"NarationStyleHeaderJR\" rowspan=\"2\">Head of Accounts</td>");
            // itemBuilder.Append("<td class=\"DescriptionStyleHeaderJR\" rowspan=\"2\">Description</td>");
            itemBuilder.Append("<td class=\"AmountStyleHeaderJR\" colspan=\"2\">Debit</td>");
            itemBuilder.Append("<td class=\"AmountStyleHeaderJR\" colspan=\"2\">Credit</td>");
            itemBuilder.Append("</tr>");
            itemBuilder.Append("<tr>");
            itemBuilder.Append("<td class=\"AmountStyleJR\">Sub</td>");
            itemBuilder.Append("<td class=\"AmountStyleJR\"> Control</td>");
            itemBuilder.Append("<td class=\"AmountStyleJR\"> Sub</td>");
            itemBuilder.Append("<td class=\"AmountStyleJR\"> Control</td>");
            itemBuilder.Append("</tr>");
            itemBuilder.Append("");
            itemBuilder.Append("");
            itemBuilder.Append("");
            itemBuilder.Append("");

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                // code
                itemBuilder.Append(" <tr>");
                itemBuilder.Append("<td class=\"AccStyleJR\">");
                itemBuilder.Append(tbl.Rows[i][0].ToString());
                itemBuilder.Append("</td>");
                // account Name
                itemBuilder.Append("<td class=\"NarationStyleJR\">");
                itemBuilder.Append(tbl.Rows[i][1].ToString());
                itemBuilder.Append("</td>");
                //description
                /*itemBuilder.Append("<td class=\"DescriptionStyleJR\">");
                itemBuilder.Append(tbl.Rows[i][2].ToString());
                itemBuilder.Append("</td>");*/
                // debit sub Control

                itemBuilder.Append("<td class=\"AmountStyleJR\">");
                //itemBuilder.Append(CommonClass.GetFormettingNumber(tbl.Rows[i][3]));
                if (double.Parse(tbl.Rows[i][3].ToString()) != 0)
                {
                    itemBuilder.Append(format.SetCommaInAmount(double.Parse(tbl.Rows[i][3].ToString()), "", ""));
                }
                else
                {
                    itemBuilder.Append("&nbsp");
                }
                itemBuilder.Append("</td>");
                // debit Control
                itemBuilder.Append("<td class=\"AmountStyleJR\">");
                //itemBuilder.Append(CommonClass.GetFormettingNumber(tbl.Rows[i][4]));
                if (double.Parse(tbl.Rows[i][4].ToString()) != 0)
                {
                    itemBuilder.Append(format.SetCommaInAmount(double.Parse(tbl.Rows[i][4].ToString()), "", ""));
                }
                else
                {
                    itemBuilder.Append("&nbsp");
                }
                itemBuilder.Append("</td>");
                // credit sub Control
                itemBuilder.Append("<td class=\"AmountStyleJR\">");
                //itemBuilder.Append(CommonClass.GetFormettingNumber(tbl.Rows[i][5]));
                if (double.Parse(tbl.Rows[i][5].ToString()) != 0)
                {
                    itemBuilder.Append(format.SetCommaInAmount(double.Parse(tbl.Rows[i][5].ToString()), "", ""));
                }
                else
                {
                    itemBuilder.Append("&nbsp");
                }
                itemBuilder.Append("</td>");
                //Credit Control
                itemBuilder.Append("<td class=\"AmountStyleJR\">");
                //itemBuilder.Append(CommonClass.GetFormettingNumber(tbl.Rows[i][6]));
                if (double.Parse(tbl.Rows[i][6].ToString()) != 0)
                {
                    itemBuilder.Append(format.SetCommaInAmount(double.Parse(tbl.Rows[i][6].ToString()), "", ""));
                }
                else
                {
                    itemBuilder.Append("&nbsp");
                }
                itemBuilder.Append("</td>");
                itemBuilder.Append("</tr>");

            }


            itemBuilder.Append("<tr>");
            itemBuilder.Append("<td  colspan=\"2\" class=\"TotalStyle1JR\">TOTAL</td>");

            itemBuilder.Append("<td class=\"TotalAmountStyleJR\">");
            itemBuilder.Append(" &nbsp;");
            itemBuilder.Append("</td>");
            itemBuilder.Append(" <td class=\"TotalAmountStyleJR\">");
            itemBuilder.Append(format.SetCommaInAmount(debitToal, "", ""));
            itemBuilder.Append("</td>");
            itemBuilder.Append("<td class=\"TotalAmountStyleJR\">");
            itemBuilder.Append("&nbsp;");
            itemBuilder.Append("</td>");
            itemBuilder.Append("<td class=\"TotalAmountStyleJR\">");
            // itemBuilder.Append(CommonClass.GetFormettingNumber(creditTotal));
            itemBuilder.Append(format.SetCommaInAmount(creditTotal, "", ""));
            itemBuilder.Append("</td>");
            itemBuilder.Append("</tr>");
            itemBuilder.Append("</table>");
            return itemBuilder.ToString();
        }
        private string MakeItemTableForContraVoucher(ContraVoucherPrintTDS.SprAccountsVoucherContraGetPrintVoucherDataDataTable items)
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
            itemTable.Append("Debit");
            itemTable.Append("</td>");
            itemTable.Append("<td class=\"AmountStyleHeader\">");
            itemTable.Append("Credit");
            itemTable.Append("</td>");
            for (int i = 0; i < items.Rows.Count; i++)
            {
                itemTable.Append("<tr>");
                itemTable.Append("<td class=\"AccStyle\">");
                itemTable.Append(items[i].strCode);
                itemTable.Append("</td>");
                itemTable.Append("<td class=\"NarationStyle\">");
                if (items[i].monAmountControl != 0)
                {
                    itemTable.Append("&nbsp;");
                }
                else
                {
                    itemTable.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

                }
                itemTable.Append(items[i].strAccName);
                itemTable.Append("</td>");

                //Description
                //itemTable.Append("<td class=\"DescriptionStyle\">");
                //itemTable.Append(items[i].Description);
                //itemTable.Append("</td>");
                // sub Account Amount
                itemTable.Append("<td class=\"AmountStyle\">");
                if (items[i].monAmountSub == 0)
                {
                    itemTable.Append("&nbsp;");
                }
                else
                {
                    itemTable.Append(format.SetCommaInAmount(items[i].monAmountSub, "", ""));
                }
                itemTable.Append("</td>");

                // Control Account Amount
                itemTable.Append("<td class=\"AmountStyle\">");
                if (items[i].monAmountControl != 0)
                {
                    itemTable.Append(format.SetCommaInAmount(items[i].monAmountControl, "", ""));
                    totalAmount = totalAmount + double.Parse("" + items[i].monAmountControl);
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
            signatureTable.Append("<td class=\"SignStyle2\" valign=\"bottom\">");
            signatureTable.Append("____________________");
            signatureTable.Append("</td>");
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
            signatureTable.Append("<td class=\"SignStyle2\" valign=\"top\">");
            signatureTable.Append("Authorised Signatory<br>");
            signatureTable.Append(" Akij Group");
            signatureTable.Append("</td>");
            signatureTable.Append("<td class=\"SignStyle\" valign=\"top\">");
            signatureTable.Append("Payee");
            signatureTable.Append("</td>");
            signatureTable.Append("</tr>");
            signatureTable.Append("</table>");

            return signatureTable.ToString();
        }
        private string MakeHeaderRowForBankVoucher(string unitName, string[] addressLines, string voucherTypeString, string bankName, string accountNo)
        {
            StringBuilder headerRow = new StringBuilder();
            headerRow.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            headerRow.Append("<tr>");
            headerRow.Append(" <td style=\"text-align: center\" colspan=\"3\">");
            //headerRow.Append("&nbsp;<span class=\"HeaderStyle\">");
            //headerRow.Append(unitName);
            //headerRow.Append("</span><br /><span class=\"HeaderStyle2\">");
            //for (int i = 0; i < addressLines.Length; i++)
            //{
            //    headerRow.Append(addressLines[i]);
            //    headerRow.Append("<br />");

            //}

            //headerRow.Append("</span><br />");
            //headerRow.Append("<span class=\"VoucherStyle\">");
            //headerRow.Append(voucherTypeString);
            //headerRow.Append("</span><br /><br />");
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
        private string PrepareSignTableWith5Sign()
        {
            StringBuilder signTable = new StringBuilder();
            signTable.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            signTable.Append("<tr>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"bottom\">");
            signTable.Append("&nbsp;______________");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"bottom\">");
            signTable.Append(" &nbsp;______________");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"bottom\">");
            signTable.Append("&nbsp;_________________");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR2\" valign=\"bottom\">");
            signTable.Append("&nbsp;__________________");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR2\" valign=\"bottom\">");
            signTable.Append("&nbsp;__________________");
            signTable.Append("</td>");


            signTable.Append("</tr>");
            signTable.Append(" <tr>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"top\">");
            signTable.Append("Prepared By");//signTable.Append(" Officer(Cash)");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"top\">");
            signTable.Append("Reviewed By");//signTable.Append("Accounts Officer");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR\" valign=\"top\">");
            signTable.Append("Authorised Signatory<br />");
            signTable.Append("Akij Group");//signTable.Append("Manager (Accounts)");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR2\" valign=\"top\">");
            signTable.Append("Authorised Signatory<br />");
            signTable.Append("Akij Group");
            //signTable.Append("General Manager<br />");
            //signTable.Append("(Accounts & Finance) AG.");
            signTable.Append("</td>");
            signTable.Append("<td class=\"SignStyleMR2\" valign=\"top\">");
            signTable.Append("Authorised Signatory<br>");
            signTable.Append(" Akij Group");//signTable.Append("Executive Director<br />");
            //signTable.Append("(Corporate Affairs) AG");
            signTable.Append("</td>");


            signTable.Append("</tr>");
            signTable.Append("</table>");
            return signTable.ToString();
        }

    }
}
