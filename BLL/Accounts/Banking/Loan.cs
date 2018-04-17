using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Accounts.Banking;
using DAL.Accounts.Banking.LoanTDSTableAdapters;

/*
 * Class For Short and long term Loan
 * Developed By --> Himadri Das
 * Date         --> 12/02/2011
 * 
 */

namespace BLL.Accounts.Banking
{
    public class Loan
    {
        private LoanTDS.SprBankLoanLogTermScheduleDataTable GetLongTermSchedule(int bankAccountID)
        {
            SprBankLoanLogTermScheduleTableAdapter adp = new SprBankLoanLogTermScheduleTableAdapter();
            return adp.GetLongTernScheduleData(bankAccountID);

        }

       /* private LoanTDS.SprBankLoanShortTermGetDataDataTable GetShortTermData(int unitID)
        {
            SprBankLoanShortTermGetDataTableAdapter adp = new SprBankLoanShortTermGetDataTableAdapter();
            return adp.GetShortTermData(unitID);
        }*/

        public string GetLongTermScheduleTable(int bankAccountID)
        {
            StringBuilder tbl = new StringBuilder();
            LoanTDS.SprBankLoanLogTermScheduleDataTable tblData = GetLongTermSchedule(bankAccountID);
            if (tblData.Rows.Count > 0)
            {
                tbl.Append("<table class=\"captionGrid1\" cellspacing=\"0\" rules=\"all\" border=\"1\"  style=\"width:100%;border-collapse:collapse;\">");
                tbl.Append("<tr>");
                tbl.Append("<td class=\"HeaderStyleT\">No</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Installment Date</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Opening Balance</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Rate</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Installment Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Principal Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Interest Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Rent</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Extra Interest</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Status</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Payment Date</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Remaining Balance</td>");
                tbl.Append("</tr>");



                //double InstallmentAmount = 0, interestAmount = 0, principalAmount = 0;
                //double rent = 0, extraInterest = 0;
                string tdWithClass = "";

                for (int i = 0; i < tblData.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        tdWithClass = "<td " + "class=\"EvenRowStyle\">";
                    }
                    else
                    {
                        tdWithClass = "<td " + "class=\"OddRowStyle\">";
                    }
                    tbl.Append("<tr>");
                    // Serial Number
                    tbl.Append(tdWithClass);
                    tbl.Append((i + 1).ToString());
                    tbl.Append("</td>");

                    //Intallment Date
                    tbl.Append(tdWithClass);
                    tbl.Append(tblData[i].dteInstallmentDate);
                    tbl.Append("</td>");

                    //opening balance
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monOpeningPrincipal));
                    tbl.Append("</td>");

                    //Rate
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F0}", tblData[i].intInterestRate) + "%");
                    tbl.Append("</td>");

                    //Installment Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monTotalInstallmentAmount));
                    tbl.Append("</td>");

                    //Principal Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monPrincipalAmount));
                    tbl.Append("</td>");

                    // Interest Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monInterestAmount));
                    tbl.Append("</td>");

                    //Grace Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monGraceAmount));
                    tbl.Append("</td>");

                    //extra Interest
                    tbl.Append(tdWithClass);
                    tbl.Append("&nbsp");
                    tbl.Append("</td>");

                    //Status
                    tbl.Append(tdWithClass);
                    if (tblData[i].ysnPaid)
                    {
                        tbl.Append("Paid");
                    }
                    else if (tblData[i].ysnPaid)
                    {
                        tbl.Append("Advanced");
                    }
                    else
                    {
                        tbl.Append("&nbsp");
                    }
                    tbl.Append("</td>");

                    // Paymrnt Date 
                    tbl.Append(tdWithClass);
                    tbl.Append("&nbsp");
                    tbl.Append("</td>");

                    //Remaining Balance
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].monRemainingPrincipal));
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                }
                tbl.Append("</table>");
            }
            else
            {
                tbl.Append("No Data Found");
            }
           return tbl.ToString();
        }


        public string GetShortTermHtml(int unitID, ref bool? ysnShow)
        {
            StringBuilder stHTML = new StringBuilder();
            SprBankLoanShortTermGetDataTableAdapter adp = new SprBankLoanShortTermGetDataTableAdapter();
            ysnShow = true;
            LoanTDS.SprBankLoanShortTermGetDataDataTable tbl = adp.GetShortTermData(unitID,ref ysnShow);

            if (tbl.Rows.Count > 0)
            {
                stHTML.Append("<table class=\"captionGrid1\" cellspacing=\"0\" rules=\"all\" border=\"1\"  style=\"width:100%;border-collapse:collapse;\">");
                stHTML.Append("<tr>");
                stHTML.Append("<td class=\"HeaderStyleT\">Account No.</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Total Recive</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Interest Paid</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Total Paid</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Balance</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Other Paid</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Rate</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Principal Payable</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Interest Payable</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Total Payable</td>");
                stHTML.Append("<td class=\"HeaderStyleT\">Command</td>");
                /* stHTML.Append("<td class=\"HeaderStyle\">Extra Interest</td>");
                 stHTML.Append("<td class=\"HeaderStyle\">Status</td>");
                 stHTML.Append("<td class=\"HeaderStyle\">Payment Date</td>");
                 stHTML.Append("<td class=\"HeaderStyle\">Remaining Balance</td>");*/
                stHTML.Append("</tr>");

                string tdWithClass = "";

                decimal dr=0;
                decimal cr=0;
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        tdWithClass = "<td " + "class=\"EvenRowStyle\">";
                    }
                    else
                    {
                        tdWithClass = "<td " + "class=\"OddRowStyle\">";
                    }
                    stHTML.Append("<tr>");

                    // Account Number
                    stHTML.Append(tdWithClass);
                    stHTML.Append(tbl[i].strAccountNo);
                    stHTML.Append("</td>");

                    // total Receive
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}",(tbl[i].monLoanAmount+tbl[i].monTotalOtherCharge)));
                    stHTML.Append("</td>");

                    // total Bank Charge
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}",tbl[i].IsmonInterestChargeNull()?0: tbl[i].monInterestCharge));
                    stHTML.Append("</td>");

                    // total payment
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}",(tbl[i].monTotalPayment+tbl[i].monTotalIntersetPays)));
                    stHTML.Append("</td>");

                    // total Balance 
                    dr = (tbl[i].IsmonTotalPaymentNull() ? 0 : tbl[i].monTotalPayment) + (tbl[i].IsmonTotalIntersetPaysNull() ? 0 : tbl[i].monTotalIntersetPays);
                    cr = (tbl[i].IsmonLoanAmountNull() ? 0 : tbl[i].monLoanAmount) + (tbl[i].IsmonTotalOtherChargeNull() ? 0 : tbl[i].monTotalOtherCharge);
                    cr = cr + (tbl[i].IsmonInterestChargeNull() ? 0 : tbl[i].monInterestCharge);
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}", (dr-cr)));
                    stHTML.Append("</td>");
                    dr = 0;
                    cr = 0;

                    // total other payment
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}", tbl[i].monOtherPaid ));
                    stHTML.Append("</td>");

                    // Rate
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F0}",tbl[i].intRate)+"%");
                    stHTML.Append("</td>");

                    // principal Amount
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}",tbl[i].monRemainingLoanAmount));
                    stHTML.Append("</td>");

                    // Interest
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}", (tbl[i].IsmonInterestPayableNull() ? 0 : tbl[i].monInterestPayable)));
                    stHTML.Append("</td>");

                    // total Payable
                    stHTML.Append(tdWithClass);
                    stHTML.Append(string.Format("{0:F2}", (tbl[i].monRemainingLoanAmount + (tbl[i].IsmonInterestPayableNull() ? 0 : tbl[i].monInterestPayable))));
                    stHTML.Append("</td>");

                    //command
                    stHTML.Append(tdWithClass);
                    stHTML.Append("&nbsp");
                    //stHTML.Append("<a href=\"#\" onClick=\"ShowReceive('"+tbl[i].strAccountNo+"',"+tbl[i].intShortTermLoanID+")\"> Receive </a>");
                    stHTML.Append("</td>");

                    stHTML.Append("</tr>");


                }

                stHTML.Append("</table>");

            }
            else
            {
                stHTML.Append("No Data Found");
            }
            return stHTML.ToString();
        }

        public LoanTDS.SprBankLoanShortTermGetAccountsForPaymentDataTable GetBankccountsForPayment(string amount,string unitID)
        {
            if (amount != "" && amount!=null)
            {
                SprBankLoanShortTermGetAccountsForPaymentTableAdapter adp = new SprBankLoanShortTermGetAccountsForPaymentTableAdapter();
                return adp.GetPaymentAccountData(decimal.Parse(amount), int.Parse(unitID));

            }
            else
            {
                return null;
            }

        }

        public string ShortTermLoanPayment(decimal amount, int unitID, int currentAccNo, string narration, DateTime paymentDate, int userID)
        {
            string rtnStr = "";
            SprBankLoanShortTermPaymentTableAdapter adp = new SprBankLoanShortTermPaymentTableAdapter();
            try
            {
                LoanTDS.SprBankLoanShortTermPaymentDataTable tbl = adp.PayShortTerm(amount, unitID, currentAccNo, narration, paymentDate, userID);
                rtnStr = "success";
            }
            catch
            {
                rtnStr = "";
            }
            return rtnStr;
        }

        public LoanTDS.SprBankLoanShortTermGetReciveAmountForDivitationDataTable GetReceiveAmountForDivitation(string unitID)
        {
            SprBankLoanShortTermGetReciveAmountForDivitationTableAdapter adp = new SprBankLoanShortTermGetReciveAmountForDivitationTableAdapter();
            return adp.GetData(int.Parse(unitID));
        }

        public bool InsertShortTimeOtherAmount(int receiveID, int stID, decimal priAmount, decimal otherAmount)
        {
            bool ysnSuccess = false;
            SprBankLoanShortTermInsertOtherAmountTableAdapter adp = new SprBankLoanShortTermInsertOtherAmountTableAdapter();
            try
            {
                adp.InsertOtherData(receiveID, stID, priAmount, otherAmount);
                ysnSuccess = true;
            }
            catch
            {
                ysnSuccess = false;
            }

            return ysnSuccess;
        }

        public LoanTDS.SprBankLoanLongTermGetScheduleSuggestionDataTable GetSuggestionData(int bankAccountID,int instalmment,int days)
        {
            SprBankLoanLongTermGetScheduleSuggestionTableAdapter adp = new SprBankLoanLongTermGetScheduleSuggestionTableAdapter();
            return adp.GetData(bankAccountID, instalmment, days);
        }

        public bool LongTermpayment(int bankAccountID,decimal monAmount,DateTime paymentDate,int userID)
        {
            SprBankLoanLongTermPayment2TableAdapter adp = new SprBankLoanLongTermPayment2TableAdapter();
            try
            {
                adp.PaymentLTData(bankAccountID, monAmount, paymentDate, userID);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public string GetLongTermScheduleSuggession(int bankID,int ins,int days)
        {

            StringBuilder tbl = new StringBuilder();
            SprBankLoanLongTermGetScheduleSuggestionTableAdapter adp = new SprBankLoanLongTermGetScheduleSuggestionTableAdapter();
            LoanTDS.SprBankLoanLongTermGetScheduleSuggestionDataTable tblData = adp.GetData(bankID, ins, days);
            if (tblData.Rows.Count > 0)
            {
                tbl.Append("<table class=\"captionGrid1\" cellspacing=\"0\" rules=\"all\" border=\"1\"  style=\"width:100%;border-collapse:collapse;\">");
                tbl.Append("<tr>");
                tbl.Append("<td class=\"HeaderStyleT\">No</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Installment Date</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Opening Balance</td>");
                //tbl.Append("<td class=\"HeaderStyleT\">Rate</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Installment Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Principal Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Interest Amount</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Rent</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Extra Interest</td>");
                //tbl.Append("<td class=\"HeaderStyleT\">Status</td>");
                //tbl.Append("<td class=\"HeaderStyleT\">Payment Date</td>");
                tbl.Append("<td class=\"HeaderStyleT\">Remaining Balance</td>");
                tbl.Append("</tr>");



                //double InstallmentAmount = 0, interestAmount = 0, principalAmount = 0;
                //double rent = 0, extraInterest = 0;
                string tdWithClass = "";

                for (int i = 0; i < tblData.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        tdWithClass = "<td " + "class=\"EvenRowStyle\">";
                    }
                    else
                    {
                        tdWithClass = "<td " + "class=\"OddRowStyle\">";
                    }
                    tbl.Append("<tr>");
                    // Serial Number
                    tbl.Append(tdWithClass);
                    tbl.Append((i + 1).ToString());
                    tbl.Append("</td>");

                    //Intallment Date
                    tbl.Append(tdWithClass);
                    tbl.Append(tblData[i].dteInstallment);
                    tbl.Append("</td>");

                    //opening balance
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].begininBalance));
                    tbl.Append("</td>");

                    //Rate
                    //tbl.Append(tdWithClass);
                    //tbl.Append(string.Format("{0:F0}", tblData[i].intInterestRate) + "%");
                    //tbl.Append("</td>");

                    //Installment Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].intallment));
                    tbl.Append("</td>");

                    //Principal Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].principalAmount));
                    tbl.Append("</td>");

                    // Interest Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].interest));
                    tbl.Append("</td>");

                    //Grace Amount
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].graceAmount));
                    tbl.Append("</td>");

                    //extra Interest
                    tbl.Append(tdWithClass);
                    tbl.Append("&nbsp");
                    tbl.Append("</td>");

                    ////Status
                    //tbl.Append(tdWithClass);
                    //if (tblData[i].ysnPaid)
                    //{
                    //    tbl.Append("Paid");
                    //}
                    //else if (tblData[i].ysnPaid)
                    //{
                    //    tbl.Append("Advanced");
                    //}
                    //else
                    //{
                    //    tbl.Append("&nbsp");
                    //}
                    //tbl.Append("</td>");

                    //// Paymrnt Date 
                    //tbl.Append(tdWithClass);
                    //tbl.Append("&nbsp");
                    //tbl.Append("</td>");

                    //Remaining Balance
                    tbl.Append(tdWithClass);
                    tbl.Append(string.Format("{0:F2}", tblData[i].remainingAmount));
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                }
                tbl.Append("</table>");
            }
            else
            {
                tbl.Append("No Data Found");
            }
            return tbl.ToString();

        }

        public LoanTDS.SprBankLoanPaymentHistoryDataTable GetLongTermPaymentHistory(string bankID)
        {
            
            SprBankLoanPaymentHistoryTableAdapter adp = new SprBankLoanPaymentHistoryTableAdapter();
            try
            {
                return adp.GetPaymentHistory(int.Parse(bankID));
            }
            catch
            {
                return null;
            }
        }
       

    }
}
