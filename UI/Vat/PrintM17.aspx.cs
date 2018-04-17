using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Vat
{
    public partial class PrintM17 : System.Web.UI.Page
    {
        BLL.Accounts.PartyPayment.PartyBill vat = new BLL.Accounts.PartyPayment.PartyBill();
        string frmdte; string todte; string itemid; string vtacc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                frmdte = Request.QueryString["FROMDATE"];
                todte = Request.QueryString["TODATE"];
                itemid = Request.QueryString["ITEMID"];
                vtacc = Request.QueryString["VATACC"];
                MakeReport();
            }
        }
        
        private void MakeReport()
        {
            string innerReportHtml = ""; string innerBodyHtml = ""; decimal totalOpeningQty = 0; decimal totalOpeningVal = 0;
            decimal totalProductionQnty = 0; decimal totalProductionValue = 0; decimal totalSalesQty = 0;decimal totalWithoutSDvatValue = 0;
            decimal totalSDValue = 0; decimal totalVatValue = 0; decimal totalClosingQty = 0; decimal totalClosingVal = 0;
            DataTable objDT = new DataTable();
            objDT = vat.GetSalesRegister(DateTime.Parse(frmdte), DateTime.Parse(todte), int.Parse(itemid), vtacc);

            #region =======================Body Region ==================
            for (int row = 0; row < objDT.Rows.Count; row++)
            {
                string ChalanDate = "-"; 
                string date_ = DateTime.Parse(objDT.Rows[row]["Date_"].ToString()).ToString("yyyy-MM-dd");
                if (objDT.Rows[row]["ChalanDate"].ToString() != "")
                { ChalanDate = DateTime.Parse(objDT.Rows[row]["ChalanDate"].ToString()).ToString("yyyy-MM-dd hh:mm:ss"); }

                string OpeningQty = Math.Round(decimal.Parse(objDT.Rows[row]["OpeningQty"].ToString()), 2).ToString();
                totalOpeningQty = totalOpeningQty + Math.Round(decimal.Parse(objDT.Rows[row]["OpeningQty"].ToString()), 2);

                string OpeningVal = Math.Round(decimal.Parse(objDT.Rows[row]["OpeningVal"].ToString()), 2).ToString();
                totalOpeningVal = totalOpeningVal + Math.Round(decimal.Parse(objDT.Rows[row]["OpeningVal"].ToString()), 2);

                string ProductionQnty = Math.Round(decimal.Parse(objDT.Rows[row]["ProductionQnty"].ToString()), 2).ToString();
                totalProductionQnty = totalProductionQnty + Math.Round(decimal.Parse(objDT.Rows[row]["ProductionQnty"].ToString()), 2);

                string ProductionValue = Math.Round(decimal.Parse(objDT.Rows[row]["ProductionValue"].ToString()), 2).ToString();
                totalProductionValue = totalProductionValue + Math.Round(decimal.Parse(objDT.Rows[row]["ProductionValue"].ToString()), 2);

                string SalesQty = Math.Round(decimal.Parse(objDT.Rows[row]["SalesQty"].ToString()), 2).ToString();
                totalSalesQty = totalSalesQty + Math.Round(decimal.Parse(objDT.Rows[row]["SalesQty"].ToString()), 2);

                string WithoutSDvatValue = Math.Round(decimal.Parse(objDT.Rows[row]["WithoutSDvatValue"].ToString()), 2).ToString();
                totalWithoutSDvatValue = totalWithoutSDvatValue + Math.Round(decimal.Parse(objDT.Rows[row]["WithoutSDvatValue"].ToString()), 2);

                string SDValue = Math.Round(decimal.Parse(objDT.Rows[row]["SDValue"].ToString()), 2).ToString();
                totalSDValue = totalSDValue + Math.Round(decimal.Parse(objDT.Rows[row]["SDValue"].ToString()), 2);

                string VatValue = Math.Round(decimal.Parse(objDT.Rows[row]["VatValue"].ToString()), 2).ToString();
                totalVatValue = totalVatValue + Math.Round(decimal.Parse(objDT.Rows[row]["VatValue"].ToString()), 2);

                string ClosingQty = Math.Round(decimal.Parse(objDT.Rows[row]["ClosingQty"].ToString()), 2).ToString();
                totalClosingQty = totalClosingQty + Math.Round(decimal.Parse(objDT.Rows[row]["ClosingQty"].ToString()), 2);

                string ClosingVal = Math.Round(decimal.Parse(objDT.Rows[row]["ClosingVal"].ToString()), 2).ToString();
                totalClosingVal = totalClosingVal + Math.Round(decimal.Parse(objDT.Rows[row]["ClosingVal"].ToString()), 2);

                innerBodyHtml = innerBodyHtml + @"
                <tr style = 'text-align:left; font:normal 9px verdana;'>
                <td>" + objDT.Rows[row]["SalesCode"].ToString() + @"</td>
                <td>" + date_ + @"</td>
                <td>" + OpeningQty + @"</td>
                <td>" + OpeningVal + @"</td>
                <td>" + ProductionQnty + @"</td>
                <td>" + ProductionValue + @"</td>
                <td>" + objDT.Rows[row]["CusName"].ToString() + @"</td>
                <td>" + objDT.Rows[row]["CusRegNo"].ToString() + @"</td>
                <td>" + objDT.Rows[row]["CusAdd"].ToString() + @"</td>
                <td>" + objDT.Rows[row]["ChalanNo"].ToString() + @"</td>
                <td>" + ChalanDate + @"</td>
                <td>" + objDT.Rows[row]["ProductName"].ToString() + @"</td>
                <td>" + SalesQty + @"</td>
                <td>" + WithoutSDvatValue + @"</td>
                <td>" + SDValue + @"</td>
                <td>" + VatValue + @"</td>
                <td>" + ClosingQty + @"</td>
                <td>" + ClosingVal + @"</td>
                <td>" + objDT.Rows[row]["Remarks"].ToString() + @"</td>
                </tr>";
            }
            #endregion

            #region ================= Header Region =====================
            innerReportHtml = @"<table border='0' style='text-align:center; font:bold 9px verdana;'> 
            <tr class='noborders'><td colspan='19' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
            <tr class='noborders'><td colspan='19' style='text-align:right;font-size:11px;'>Musok-17</td></tr>
            <tr class='noborders'><td colspan='19' style='font-size:11px;'>Sales Register<br/><br/></td></tr>
            <tr class='noborders'><td colspan='19' style='text-align:right;font-size:11px;'>From "; innerReportHtml = innerReportHtml + frmdte + @" To " + todte + @"<br/><br/></td></tr>
            <tbody class='border'> 
            <tr class='border'><td style='width:50px;' rowspan='2'>SL</td><td style='width:120px;' rowspan='2'>Date</td><td colspan='2'>Opening Balance Of Material</td><td colspan='2'>Production</td>
            <td colspan='3'>Purchaser / Customer</td><td colspan='2'>Challan</td><td colspan='5'>Material Purchase</td><td colspan='2'>Closing Balance Of Material</td><td style='width:50px;' rowspan='2'>Remarks</td></tr>

            <tr><td style='width:100px;'>Quantity</td><td style='width:100px;'>Value</td><td style='width:100px;'>Quantity</td>
            <td style='width:85px;'>Value</td><td style='width:300px;'>Name</td><td style='width:150px;'>Reg No</td><td style='width:100px;'>Address</td><td style='width:155px;'>No</td>
            <td style='width:120px;'>Date & Time</td><td style='width:85px;'>Description</td><td style='width:75px;'>Quantity</td><td style='width:50px;'>SD Chargeable Price</td><td style='width:85px;'>SD</td>
            <td style='width:85px;'>Vat</td><td style='width:85px;'>Quantity</td><td style='width:85px;'>Value</td></tr>

            <tr><td style='width:100px;'>1</td><td style='width:120px;'>2</td><td style='width:100px;'>3</td><td style='width:100px;'>4</td><td style='width:100px;'>5</td>
            <td style='width:85px;'>6</td><td style='width:300px;'>7</td><td style='width:150px;'>8</td><td style='width:100px;'>9</td><td style='width:155px;'>10</td>
            <td style='width:120px;'>11</td><td style='width:85px;'>12</td><td style='width:75px;'>13</td><td style='width:50px;'>14</td><td style='width:85px;'>15</td>
            <td style='width:85px;'>16</td><td style='width:85px;'>17</td><td style='width:85px;'>18</td><td style='width:50px;'>19</td></tr>
            <tr><td colspan='19'>"; innerReportHtml = innerReportHtml + innerBodyHtml + @"</td></tr>
            
            <tr style='text-align:left; color:Blue;'><td colspan='2' style = 'text-align:right;'>GRAND TOTAL : </td>
            <td>"; innerReportHtml = innerReportHtml + totalOpeningQty + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalOpeningVal + @"</td>            
            <td>"; innerReportHtml = innerReportHtml + totalProductionQnty + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalProductionValue + @"</td>
            <td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>            
            <td>"; innerReportHtml = innerReportHtml + totalSalesQty + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalWithoutSDvatValue + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalSDValue + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalVatValue + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalClosingQty + @"</td>
            <td>"; innerReportHtml = innerReportHtml + totalClosingVal + @"</td><td>-</td></tr>
            </tbody>
            </table>";

            #endregion

            report.InnerHtml = innerReportHtml;
        }

    }
}