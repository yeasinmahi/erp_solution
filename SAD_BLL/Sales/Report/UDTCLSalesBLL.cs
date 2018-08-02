using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLOBAL_BLL;
using SAD_DAL.Sales.Report;
using SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters;

namespace SAD_BLL.Sales.Report
{
    public class UDTCLSalesBLL
    {
        AmountFormat format = new AmountFormat();
        decimal totalAmountDr, totalAmountCr;
        string voucherDate, voucherNumber, securityCode, totalAmountInWord, voucherNarration;
        public DataTable getShippingPoint(int unitid)
        {
            tblShippingPointTableAdapter adp = new tblShippingPointTableAdapter();
            return adp.GetShippingPointDataByUnitid(unitid);
        }

        public DataTable getUDTCLSalesData(DateTime fromDate,DateTime toDate,int unitId,int reportType,int salesOffId,int shippingId)
        {
            sprUDTCLSalesStausTableAdapter adp = new sprUDTCLSalesStausTableAdapter();
            return adp.GetUDTCLSalesData(fromDate, toDate, unitId, reportType, salesOffId, shippingId);
        }
        public DataTable getSalesData(DateTime fromDate, DateTime toDate, int unitId, int reportType)
        {
            sprUDTCLSalesStausDetaillsTableAdapter adp = new sprUDTCLSalesStausDetaillsTableAdapter();
            return adp.GetSalesData(fromDate, toDate, unitId, reportType);
        }
        public string SVPrintView(int unit, string code, int Id)
        {
            string htmlString = "";
            DateTime? vDate = null;
           
            //TblSalesEntryTableAdapter
            DataTable dt = new DataTable();
            DataTable dtDetalis = new DataTable();
            UDTCLSalesBLL obj = new UDTCLSalesBLL(); 
            dt = getData(unit, code, Id);

            dtDetalis = getSvDetalisData(Id, unit);
            if (dtDetalis.Rows.Count > 0)
            {
                voucherNumber = dtDetalis.Rows[0]["strCode"].ToString();
                voucherNarration = dtDetalis.Rows[0]["strNarration"].ToString();
                DateTime dteDates = DateTime.Parse(dtDetalis.Rows[0]["dteDate"].ToString());
                voucherDate = dteDates.ToString("dd-MM-yyyy");  
            }
            if (dt.Rows.Count > 0) { totalAmountCr =decimal.Parse(dt.Rows[0]["monAmountControlDr"].ToString()); }
            AmountFormat formatAmount = new AmountFormat();
            totalAmountInWord = formatAmount.GetTakaInWords(totalAmountCr, "", "Only");
            string[] addressLines = new string[1];
            addressLines[0] = "UDTCL";
            htmlString = PreparePrintableJournelVoucher("UDTCL", addressLines, "SV", voucherNumber, voucherDate, (DataTable)dt, totalAmountInWord, voucherNarration, totalAmountDr, totalAmountCr);
            return htmlString;


        }

        private DataTable getSvDetalisData(int unit, int id)
        {
            try
            {
                TblSalesEntryTableAdapter adpTable = new TblSalesEntryTableAdapter();
                return adpTable.GetSvDetalisData(unit, id);
            }
            catch { return new DataTable(); }
           
        }

        private DataTable getData(int unit, string code, int id)
        {
            SprUDTCLSVAccountsViewTableAdapter adpTable = new SprUDTCLSVAccountsViewTableAdapter();
            return adpTable.GetSVData(unit, code, id);
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
    }
}
