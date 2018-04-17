using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Vat
{
    public partial class PrintM16 : System.Web.UI.Page
    {
        BLL.Accounts.PartyPayment.PartyBill vat = new BLL.Accounts.PartyPayment.PartyBill();
        string frmdte; string todte; string matid; string vtacc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                frmdte = Request.QueryString["FROMDATE"];
                todte = Request.QueryString["TODATE"];
                matid = Request.QueryString["MATID"];
                vtacc = Request.QueryString["VATACC"];
                MakeReport();
            }
        }

        private void MakeReport()
        {
            string innerReportHtml = ""; string innerBodyHtml = ""; decimal totalOpeningQty = 0; decimal totalOpeningVal = 0;
            decimal totalRcvQty = 0; decimal totalWithoutSDvatValue = 0; decimal totalSDValue = 0; decimal totalVatValue = 0;
            decimal totalIssueQty = 0; decimal totalIssueVal = 0; decimal totalClosingQty = 0; decimal totalClosingVal = 0;
            DataTable objDT = new DataTable();
            objDT = vat.GetPurchaseRegister(DateTime.Parse(frmdte), DateTime.Parse(todte), int.Parse(matid), vtacc);

            #region =======================Body Region ==================
            for (int row = 0; row < objDT.Rows.Count; row++)
            {
                string ChDate = "-";
                string date_ = DateTime.Parse(objDT.Rows[row]["Date_"].ToString()).ToString("yyyy-MM-dd");
                if (objDT.Rows[row]["ChDate"].ToString() != "")
                { ChDate = DateTime.Parse(objDT.Rows[row]["ChDate"].ToString()).ToString("yyyy-MM-dd"); }

                string OpeningQty = Math.Round(Convert.ToDecimal((objDT.Rows[row]["OpeningQty"].ToString())), 2).ToString();
                totalOpeningQty = totalOpeningQty + Math.Round(Convert.ToDecimal(objDT.Rows[row]["OpeningQty"].ToString()),2);
                string OpeningVal = Math.Round(Convert.ToDecimal(objDT.Rows[row]["OpeningVal"].ToString()), 2).ToString();
                totalOpeningVal = totalOpeningVal + Math.Round(Convert.ToDecimal(objDT.Rows[row]["OpeningVal"].ToString()), 2);

                string RcvQty = Math.Round(Convert.ToDecimal(objDT.Rows[row]["RcvQty"].ToString()), 2).ToString();
                totalRcvQty = totalRcvQty + Math.Round(Convert.ToDecimal(objDT.Rows[row]["RcvQty"].ToString()), 2);

                string WithoutSDvatValue = Math.Round(Convert.ToDecimal(objDT.Rows[row]["WithoutSDvatValue"].ToString()), 2).ToString();
                totalWithoutSDvatValue = totalWithoutSDvatValue + Math.Round(Convert.ToDecimal(objDT.Rows[row]["WithoutSDvatValue"].ToString()), 2);

                string SDValue = Math.Round(Convert.ToDecimal(objDT.Rows[row]["SDValue"].ToString()), 2).ToString();
                totalSDValue = totalSDValue + Math.Round(Convert.ToDecimal(objDT.Rows[row]["SDValue"].ToString()), 2);

                string VatValue = Math.Round(Convert.ToDecimal(objDT.Rows[row]["VatValue"].ToString()), 2).ToString();
                totalVatValue = totalVatValue + Math.Round(Convert.ToDecimal(objDT.Rows[row]["VatValue"].ToString()), 2);

                string IssueQty = Math.Round(Convert.ToDecimal(objDT.Rows[row]["IssueQty"].ToString()), 2).ToString();
                totalIssueQty = totalIssueQty + Math.Round(Convert.ToDecimal(objDT.Rows[row]["IssueQty"].ToString()), 2);

                string IssueVal = Math.Round(Convert.ToDecimal(objDT.Rows[row]["IssueVal"].ToString()), 2).ToString();
                totalIssueVal = totalIssueVal + Math.Round(decimal.Parse(objDT.Rows[row]["IssueVal"].ToString()), 2);

                string ClosingQty = Math.Round(decimal.Parse(objDT.Rows[row]["ClosingQty"].ToString()), 2).ToString();
                totalClosingQty = totalClosingQty + Math.Round(decimal.Parse(objDT.Rows[row]["ClosingQty"].ToString()), 2);

                string ClosingVal = Math.Round(decimal.Parse(objDT.Rows[row]["ClosingVal"].ToString()), 2).ToString();
                totalClosingVal = totalClosingVal + Math.Round(decimal.Parse(objDT.Rows[row]["ClosingVal"].ToString()), 2);

                innerBodyHtml = innerBodyHtml + @"
                <tr style = 'text-align:left; font:normal 9px verdana;'>
                <td style='width:100px;'>" + objDT.Rows[row]["PurchaseCode"].ToString() + @"</td>
                <td style='width:120px;'>" + date_ + @"</td>
                <td style='width:100px;'>" + OpeningQty + @"</td>
                <td style='width:100px;'>" + OpeningVal + @"</td>
                <td style='width:100px;'>" + objDT.Rows[row]["Chalan"].ToString() + @"</td>
                <td style='width:120px;'>" + ChDate + @"</td>
                <td style='width:300px;'>" + objDT.Rows[row]["SupName"].ToString() + @"</td>
                <td style='width:150px;'>" + objDT.Rows[row]["SupAdd"].ToString() + @"</td>
                <td style='width:100px;'>" + objDT.Rows[row]["SupRegNo"].ToString() + @"</td>
                <td style='width:155px;'>" + objDT.Rows[row]["MaterialName"].ToString() + @"</td>
                <td style='width:50px;'>" + RcvQty + @"</td>
                <td style='width:85px;'>" + WithoutSDvatValue + @"</td>
                <td style='width:75px;'>" + SDValue + @"</td>
                <td style='width:50px;'>" + VatValue + @"</td>
                <td style='width:85px;'>" + IssueQty + @"</td>
                <td style='width:85px;'>" + IssueVal + @"</td>
                <td style='width:85px;'>" + ClosingQty + @"</td>
                <td style='width:85px;'>" + ClosingVal + @"</td>
                <td style='width:50px;'>" + objDT.Rows[row]["Remarks"].ToString() + @"</td>
                </tr>";
            }
            #endregion

            #region ================= Header Region =====================
            innerReportHtml = @"<table border='0' style='text-align:center; font:bold 9px verdana;'> 
            <tr class='noborders'><td colspan='19' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
            <tr class='noborders'><td colspan='19' style='text-align:right;font-size:11px;'>Musok-16</td></tr>
            <tr class='noborders'><td colspan='19' style='font-size:11px;'>Purchase Register</td></tr>
            <tr class='noborders'><td colspan='19' style='text-align:right;font-size:11px;'>From "; innerReportHtml = innerReportHtml + frmdte + @" To " + todte  + @"<br/><br/></td></tr>
            <tbody class='border'>            
            <tr><td rowspan='3'>SL</td><td rowspan='3'>Date</td><td colspan='2' rowspan='2'>Opening Balance Of Material</td><td colspan='12'>Material Purchase</td><td colspan='2' rowspan='2'>Closing Balance Of Material</td><td rowspan='3'>Remarks</td></tr>
            <tr><td rowspan='2'>Challan/BEO Number</td><td rowspan='2'>Date</td><td colspan='3'>Seller / Supplier</td><td rowspan='2'>Description</td>
            <td rowspan='2'>Quantity</td><td rowspan='2'>Value(Without SD & Vat)</td><td rowspan='2'>SD (if any)</td><td rowspan='2'>VAT</td><td colspan='2'>Use In Production</td></tr>
            <tr><td>Quantity</td><td>Value</td><td>Name</td><td>Address</td><td>Reg No</td><td>Quantity</td><td>Value</td><td>Quantity</td><td>Value</td></tr>
            
            <tr><td style='width:100px;'>1</td><td style='width:120px;'>2</td><td style='width:100px;'>3</td><td style='width:100px;'>4</td><td style='width:100px;'>5</td>
            <td style='width:120px;'>6</td><td style='width:300px;'>7</td><td style='width:150px;'>8</td><td style='width:100px;'>9</td><td style='width:155px;'>10</td>
            <td style='width:50px;'>11</td><td style='width:85px;'>12</td><td style='width:75px;'>13</td><td style='width:50px;'>14</td><td style='width:85px;'>15</td>
            <td style='width:85px;'>16</td><td style='width:85px;'>17</td><td style='width:85px;'>18</td><td style='width:50px;'>19</td></tr>
      
            <tr><td colspan='19'>"; innerReportHtml = innerReportHtml + innerBodyHtml + @"</td></tr>

            <tr style='text-align:left; color:Blue;'><td colspan='2' style = 'text-align:right;'>GRAND TOTAL : </td>
            <td style='width:100px;'>"; innerReportHtml = innerReportHtml + totalOpeningQty + @"</td>
            <td style='width:100px;'>"; innerReportHtml = innerReportHtml + totalOpeningVal + @"</td>
            <td style='width:100px;'>-</td><td style='width:120px;'>-</td><td style='width:300px;'>-</td><td style='width:150px;'>-</td>
            <td style='width:100px;'>-</td><td style='width:155px;'>-</td>
            <td style='width:50px;'>"; innerReportHtml = innerReportHtml + totalRcvQty + @"</td>
            <td style='width:85px;'>"; innerReportHtml = innerReportHtml + totalWithoutSDvatValue + @"</td>
            <td style='width:75px;'>"; innerReportHtml = innerReportHtml + totalSDValue + @"</td>
            <td style='width:50px;'>"; innerReportHtml = innerReportHtml + totalVatValue + @"</td>
            <td style='width:85px;'>"; innerReportHtml = innerReportHtml + totalIssueQty + @"</td>
            <td style='width:85px;'>"; innerReportHtml = innerReportHtml + totalIssueVal + @"</td>
            <td style='width:85px;'>"; innerReportHtml = innerReportHtml + totalClosingQty + @"</td>
            <td style='width:85px;'>"; innerReportHtml = innerReportHtml + totalClosingVal + @"</td><td style='width:50px;'>-</td></tr>
            </tbody>
            </table>";

            #endregion

            report.InnerHtml = innerReportHtml;
        }











    }
}