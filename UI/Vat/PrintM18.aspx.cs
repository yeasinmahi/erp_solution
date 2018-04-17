using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class PrintM18 : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill vat = new BLL.Accounts.PartyPayment.PartyBill();
        string vtacc; string frmdte; string todte; string type_;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vtacc = Request.QueryString["VATACC"];
                frmdte = Request.QueryString["FROMDATE"];
                todte = Request.QueryString["TODATE"];
                type_ = Request.QueryString["TYPE"];
                MakeReport();
            }
        }

        private void MakeReport()
        {
            string innerReportHtml = ""; string innerBodyHtml = ""; decimal totalTreasuryDeposit = 0; decimal totalRebate = 0;
            decimal totalAdjust = 0; decimal totalPayable = 0; decimal totalRunningBalance = 0;
            DataTable objDT = new DataTable();
            DataTable objDTUNIT = new DataTable();
            objDTUNIT = vat.GetUnitInfo(int.Parse(vtacc));
            objDT = vat.GetCurrentRegister(int.Parse(vtacc), DateTime.Parse(frmdte), DateTime.Parse(todte), int.Parse(type_));

            #region =======================Body Region ==================
            for (int row = 0; row < objDT.Rows.Count; row++)
            {
                string date_ = DateTime.Parse(objDT.Rows[row]["Date_"].ToString()).ToString("yyyy-MM-dd");
                string RefferenceDate = DateTime.Parse(objDT.Rows[row]["RefferenceDate"].ToString()).ToString("yyyy-MM-dd");
                string TreasuryDeposit = Math.Round(decimal.Parse(objDT.Rows[row]["TreasuryDeposit"].ToString()), 2).ToString();
                totalTreasuryDeposit = totalTreasuryDeposit + Math.Round(decimal.Parse(objDT.Rows[row]["TreasuryDeposit"].ToString()), 2);

                string Rebate = Math.Round(decimal.Parse(objDT.Rows[row]["Rebate"].ToString()), 2).ToString();
                totalRebate = totalRebate + Math.Round(decimal.Parse(objDT.Rows[row]["Rebate"].ToString()), 2);

                string Adjust = Math.Round(decimal.Parse(objDT.Rows[row]["Adjust"].ToString()), 2).ToString();
                totalAdjust = totalAdjust + Math.Round(decimal.Parse(objDT.Rows[row]["Adjust"].ToString()), 2);

                string Payable = Math.Round(decimal.Parse(objDT.Rows[row]["Payable"].ToString()), 2).ToString();
                totalPayable = totalPayable + Math.Round(decimal.Parse(objDT.Rows[row]["Payable"].ToString()), 2);

                string RunningBalance = Math.Round(decimal.Parse(objDT.Rows[row]["RunningBalance"].ToString()), 2).ToString();                

                innerBodyHtml = innerBodyHtml + @"
                <tr style = 'text-align:left; font:normal 9px verdana;'>
                <td>" + objDT.Rows[row]["intRowID"].ToString() + @"</td>
                <td>" + date_ + @"</td>
                <td>" + objDT.Rows[row]["TransactionDescription"].ToString() + @"</td>
                <td>" + objDT.Rows[row]["RefferenceSL"].ToString() + @"</td>
                <td>" + RefferenceDate + @"</td>
                <td>" + TreasuryDeposit + @"</td>
                <td>" + Rebate + @"</td>
                <td>" + Adjust + @"</td>
                <td>" + Payable + @"</td>
                <td>" + RunningBalance + @"</td>
                <td>" + objDT.Rows[row]["Remarks"].ToString() + @"</td>
                </tr>";
            }

            totalRunningBalance = Math.Round(decimal.Parse(objDT.Rows[objDT.Rows.Count - 1]["RunningBalance"].ToString()), 2);
            //totalRunningBalance = Math.Round(decimal.Parse(objDT.Rows[0]["RunningBalance"].ToString())) + totalTreasuryDeposit + totalRebate - totalPayable;
            #endregion

            #region ================= Header Region =====================
            innerReportHtml = @"<table border='0' style='text-align:center; font:bold 9px verdana;'> 
            <tr class='noborders'><td colspan='10' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
            <tr class='noborders'><td colspan='10' style='text-align:right;font-size:11px;'>Musok-18</td></tr>
            <tr class='noborders'><td colspan='10' style='font-size:11px;'>Current Register</td></tr>
            <tr class='noborders'><td colspan='10' style='text-align:right;font-size:11px;'>From "; innerReportHtml = innerReportHtml + frmdte + @" To " + todte + @"<br/><br/></td></tr>
            <tr class='noborders' style='text-align:left;'><td colspan='3' style='text-align:right;'>VAT Registration No. : </td><td colspan='7'>"; innerReportHtml = innerReportHtml + objDTUNIT.Rows[0]["strVATRegNo"].ToString() + @"</td></tr>
            <tr class='noborders' style='text-align:left;'><td colspan='3' style='text-align:right;'>Name : </td><td colspan='7'>"; innerReportHtml = innerReportHtml + objDTUNIT.Rows[0]["strDescription"].ToString() + @"</td></tr>
            <tr class='noborders' style='text-align:left;'><td colspan='3' style='text-align:right;'>Address : </td><td colspan='7'>"; innerReportHtml = innerReportHtml + objDTUNIT.Rows[0]["strAddress"].ToString() + @"</td></tr>
            <tr class='noborders' style='text-align:left;'><td colspan='3' style='text-align:right;'>Telephone : </td><td colspan='7'>"; innerReportHtml = innerReportHtml + objDTUNIT.Rows[0]["strPhoneNo"].ToString() + @"</td></tr>
            <tr class='noborders'><td colspan='10'><br /><br /></td></tr>

            <tbody class='border'> 

            <tr class='border'><td rowspan='2'>SL</td><td rowspan='2'>Date</td><td rowspan='2'>Transaction Description</td><td colspan='2'>Purchase / Sales Register&#39;s</td>
            <td>Treasury Deposite</td><td>Rebate</td><td>Adjust</td><td>Payable</td><td>Closing Balance</td><td>Remarks</td></tr>
            <tr><td>SL no.</td><td>Date</td>
            <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>Value</td><td>&nbsp;</td></tr>

            <tr><td style='width:50px;'>1</td><td style='width:125px;'>2</td><td style='width:190px;'>3</td><td style='width:100px;'>4</td><td style='width:120px;'>5</td>
            <td style='width:100px;'>6</td><td style='width:100px;'>7</td><td style='width:100px;'>8</td><td style='width:100px;'>9</td><td style='width:125px;'>10</td><td style='width:155px;'>11</td>
            </tr>
            <tr><td colspan='10'>"; innerReportHtml = innerReportHtml + innerBodyHtml + @"</td></tr>

            <tr style='text-align:left; color:Blue;'><td colspan='5' style = 'text-align:right;'>GRAND TOTAL : </td>
            <td>"; innerReportHtml = innerReportHtml + totalTreasuryDeposit + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalRebate + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalAdjust + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalPayable + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalRunningBalance + @"</td><td>-</td>
            </tr>

            </tbody>
            </table>";

            #endregion

            report.InnerHtml = innerReportHtml;
        }







    }
}