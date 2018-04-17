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
    public partial class PrintReturn : BasePage
    {
        string innerReportHtml = ""; string innerReportHtml1 = ""; string innerReportHtml2 = ""; string innerReportHtml34 = "";
        BLL.Accounts.PartyPayment.PartyBill vat = new BLL.Accounts.PartyPayment.PartyBill(); string vtacc; string date;
        string innerReportHtmlFooter = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vtacc = Request.QueryString["VATACC"];
                date = Request.QueryString["DATE"];
                MakeReport();
            }
        }

        private void MakeReport()
        {
            DataTable objDT = new DataTable();
            objDT = vat.GetMonthlyVatReturn(int.Parse(vtacc), DateTime.Parse(date));
            #region ================= Header Region =====================
            innerReportHtml = @" <table border='0' style = 'width:650px; text-align:left; font-size: 11px;'>
            <tr class='noborders'><td colspan='3'><img src='../../Content/Images/img/M19.png' width='640' height='100' /></td>
            </tr>
            <tr>
            <td style='font-weight: bold;'>Vat Period :</td>
            <td>Month: ";
            innerReportHtml = innerReportHtml + objDT.Rows[0]["Fullmonth"].ToString() + @"    Year: " + objDT.Rows[0]["Fullyear"].ToString() + @"</td>
            <td style='font-weight: bold;'>Vat Registration Number: "; 
            innerReportHtml = innerReportHtml + objDT.Rows[0]["VatRegNo"].ToString() + @"</td>
            </tr>
            <tr><td style='font-weight: bold;'>Name :</td>
            <td colspan='2'>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["Unitname"].ToString() + @"</td>
            </tr>

            <tr><td style='font-weight: bold;'>Address :</td>
            <td colspan='2'>";innerReportHtml = innerReportHtml + objDT.Rows[0]["UnitAddress"].ToString() + @"</td>
            </tr>

            <tr><td style='font-weight: bold;'>Phone :</td>
            <td colspan='2'>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["Phone"].ToString() + @"</td>
            </tr>
            </table>";
            #endregion

            #region ============= Body First Part ================
            innerReportHtml1 = @" <table border='0' style = 'width:650px; font-size: 11px;'><tbody class='border'> 
            <tr style='text-align:center; font-weight: bold;'>
            <td colspan='2'>Sales Information</td>   <td>Sales Price</td>   <td>Suplimentary Duty</td>   <td>VAT</td>
            </tr>

            <tr style='text-align:left;'><td>01.</td>
            <td>Net Sales Of VAT Chargeable Goods or Service</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_1t"].ToString() + @"</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_1sd"].ToString() + @"</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_1vt"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>02.</td>
            <td>Sales Of Goods or Service with 0 SD/VAT (Export)</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_2"].ToString() + @"</td>
            <td></td><td></td>
            </tr>

            <tr style='text-align:left;'><td>03.</td>
            <td>Net Sales Of Exempted Goods or Service</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_3"].ToString() + @"</td>
            <td></td><td ></td>
            </tr>

            <tr style='text-align:center; font-weight: bold;'><td colspan='2'>Accounts Payable</td>
            <td>Amount</td><td></td><td></td>
            </tr>

            <tr style='text-align:left; '><td>04.</td>
            <td>Total Tax Payable (SD + VAT from Row-01)</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_4"].ToString() + @"</td>
            <td></td><td></td>
            </tr>

            <tr style='text-align:left;'><td>05.</td> 
            <td>Other Adjustment (Payable)</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_5"].ToString() + @"</td>
            <td></td><td></td>
            </tr>

            <tr style='text-align:left;'><td>06.</td>
            <td>Total Payable (Row 04 + 05)</td>
            <td>"; innerReportHtml1 = innerReportHtml1 + objDT.Rows[0]["M19_6"].ToString() + @"</td>
            <td></td><td></td>
            </tr></tbody>
            </table><br/>";


            #endregion

            #region ============= Body Second Part ================
            innerReportHtml2 = @" <table border='0' style = 'width:650px; font-size: 11px;'><tbody class='border'> 
            <tr style='text-align:center; font-weight: bold;'>
            <td colspan='2'>Purchase Information</td>   <td>Purchase Price</td>   <td>Tax Rebate</td>
            </tr>

            <tr style='text-align:left;'><td>07.</td>
            <td>Local Purchase Of Tax Chargeable Goods or Service</td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_7t"].ToString() + @"</td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_7vt"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left; '><td>08.</td>
            <td>Import Of Tax Chargeable Goods or Service</td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_8t"].ToString() + @"</td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_8vt"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>09.</td>
            <td>Other Tax Rebate For Export</td>
           <td></td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_9vt"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>10.</td>
            <td>Purchase Of Tax Exemted Goods or Service</td>
            <td>"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_10"].ToString() + @"</td>
            <td></td>
            </tr></tbody>
            </table><br/>";

            //"; innerReportHtml2 = innerReportHtml2 + objDT.Rows[0]["M19_9t"].ToString() + @"
            #endregion

            #region ============= Body Third & Fourth Part ================
            innerReportHtml34 = @" <table border='0' style = 'width:650px; font-size: 11px;'><tbody class='border'> 
            <tr style='text-align:center; font-weight: bold;'>
            <td colspan='2'>Rebate Return Account</td>   <td>Amount</td>
            </tr>

            <tr style='text-align:left; '><td>11.</td>
            <td>Total Tax Rebate (Row 07 + 08 + 09)</td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_11"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>12.</td>
            <td>Other Adjustment (Rebate/Receivable)</td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_12"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>13.</td>
            <td>Balance Of Previous Month</td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_13"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>14.</td>
            <td>Total Rebate (Row 11 + 12 + 13)</td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_14"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td colspan='3'><br/></td></tr>

            <tr style='text-align:center; font-size: 10px; font-weight: bold;'>
            <td colspan='2'>Final Account</td>   <td>Amount</td>
            </tr>

            <tr style='text-align:left;'><td>15.</td>
            <td>Net Payable (Row 06 - 14)</td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_15"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>16.</td>
            <td>Treasury Deposit </td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_16"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>17.</td>
            <td>Opening Balance Of Next Month </td>
            <td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_17"].ToString() + @"</td>
            </tr>

            <tr style='text-align:left;'><td>18.</td>
            <td>DEDO</td><td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_18"].ToString() + @"</td>
            </tr>
            <tr style='text-align:left;'><td>19.</td>
            <td>Total VAT Deducted at Source (VDS)</td><td>"; innerReportHtml34 = innerReportHtml34 + objDT.Rows[0]["M19_19"].ToString() + @"</td></tr>
            </tbody>
            </table>";

            // I declare that, all given information in this return statement is true and accurate.
            #endregion

            #region =============== ReportHtmlFooter =================
            innerReportHtmlFooter = @" <table border='0' style = 'width:650px; height:120px; text-align:left; font-size: 11px;'>
            <tr class='noborders'><td style='font-weight: bold;' colspan='2'>I declare that, all given information in this return statement is true and accurate.<br/><br/></td></tr>
            <tr class='noborders'><td style='font-weight: bold;'>Date :</td>
            <td style='font-weight: bold; text-align:right;'>Seal And Signature</td>
            </tr></table>";
            #endregion

            report.InnerHtml = innerReportHtml + innerReportHtml1 + innerReportHtml2 + innerReportHtml34 + innerReportHtmlFooter;
        }





    }
}