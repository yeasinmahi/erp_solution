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
    public partial class PrintTreasury : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string innerReportHtml = "";
                BLL.Accounts.PartyPayment.PartyBill vat = new BLL.Accounts.PartyPayment.PartyBill();
                string entryid = Request.QueryString["AUTOID"];
                string vtacc = Request.QueryString["VTACC"];
                DataTable objDT = new DataTable();
                objDT = vat.GetTreasuryPrint(int.Parse(entryid));
                #region ================= Header Region =====================
                innerReportHtml = @" <table border='1' style = 'width:650px; text-align:left; font-size: 11px;'>
                <tr><td colspan='7' style='font-weight: bold; text-align:center;'>Challan Form <br/> T.R Form No-06</td></tr>
                <tr><td colspan='2' style='text-align:right;'>Challan No:</td>

                <td style='font-weight: bold; text-align:center;'>";
                innerReportHtml = innerReportHtml + objDT.Rows[0]["strInstumentNo"].ToString() + @"</td>
                <td style='font-weight: bold; text-align:right;'></td>

                <td style='text-align:center;'>Date:</td>
                <td colspan='2' style='font-weight: bold; text-align:left;'>";
                innerReportHtml = innerReportHtml + objDT.Rows[0]["strInstumentDate"].ToString() + @"</td>
                </tr>
                <tr><td colspan='7' style='text-align:center;'>
                Bangladesh Bank <b>Dhaka</b> District <b>Motijheel</b> Branch Deposit Challan. </td></tr>


                <tr><td colspan='7' style='font-weight: bold; text-align:left;'>Code:";
                innerReportHtml = innerReportHtml + objDT.Rows[0]["strTreasuryDepositCode"].ToString() +
                @"</td></tr>

                <tr>
                <td colspan='4' style='font-weight: bold; text-align:center;'> To be filled by depositor </td>
                <td colspan='2' style='font-weight: bold; text-align:center;'> Amount (Tk.)</td>
                <td>Name of Department and Name, designation & dept. of challan creator</td>
                </tr>

                <tr>
                <td style='font-weight: bold; text-align:center;'>Depositor Name & Address </td>
                <td style='font-weight: bold; text-align:center;'>Name, Designation & Address of individual/organization</td>
                <td style='font-weight: bold; text-align:center;'>Purpose of Deposite</td>
                <td style='font-weight: bold; text-align:center;'>Description of payment Instrument</td>
                <td style='font-weight: bold; text-align:center;'>Taka</td>
                <td style='font-weight: bold; text-align:center;'>Paisa</td>
                </tr>

                <tr style='text-align:left;'>
                <td>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["strDepositorName"].ToString() + @"</td>
                <td>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["strDepositorAddress"].ToString() + @"</td>
                <td>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["strTreasuryDepositDescription"].ToString() +
                @"<br/>Vat registration no-" + objDT.Rows[0]["strVATRegNo"].ToString() + @"</td>
                <td>Bangladesh Bank Cheque No-"; innerReportHtml = innerReportHtml + objDT.Rows[0]["strInstumentNo"].ToString() +
                @"<br/><br/>Date-" + objDT.Rows[0]["strInstumentDate"].ToString() + @"</td>
                <td>"; innerReportHtml = innerReportHtml + objDT.Rows[0]["monAmount"].ToString() + @"</td>
                <td></td><td></td>
                </tr>
                </table>";
                #endregion
                report.InnerHtml = innerReportHtml;

            }
        }
    }
}