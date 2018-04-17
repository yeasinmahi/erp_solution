using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.Voucher;
using DAL.Accounts.Voucher;
using BLL;
using UI.ClassFiles;
using GLOBAL_BLL;

/// <summary>
/// Developped By Akramul Haider
/// Modified By Himadri Das at 24/05/2010 
/// </summary>
namespace UI.Accounts.Print
{
    public partial class PrintMR : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            string barcode = "";
            if (Request.QueryString.Count > 0)
            {

                string id = Request.QueryString["id"];
                string type = (Request.QueryString["type"]);//Bank > bn ,Cash > ch

                if (type == "bn") // bank MRR
                {
                    BankVoucher bn = new BankVoucher();
                    BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintMRDataDataTable mrBank = bn.GetBankMRPrintData(id, Session[SessionParams.USER_ID].ToString());

                    if (mrBank[0].ysnCheque)
                    {
                        lblPayThrough.Text = "By Cheque";
                    }
                    else if (mrBank[0].ysnDemandDraft)
                    {
                        lblPayThrough.Text = "By Demand Draft";
                    }
                    else if (mrBank[0].ysnAdjustment)
                    {
                        lblPayThrough.Text = "By Adjustment";
                    }
                    else if (mrBank[0].ysnAdvance)
                    {
                        lblPayThrough.Text = "By Advice";
                    }
                    else if (mrBank[0].ysnDepositSlip)
                    {
                        lblPayThrough.Text = "By Deposit Slip";
                    }
                    else if (mrBank[0].ysnPayOrder)
                    {
                        lblPayThrough.Text = "By Pay Order";
                    }
                    else if (mrBank[0].ysnOnline)
                    {
                        lblPayThrough.Text = "By Online";
                    }
                    else
                    {
                        lblPayThrough.Text = "";
                    }

                    if (mrBank[0].strNo != "") lblPayThrough.Text += " No. " + mrBank[0].strNo;
                    if (mrBank[0].strDepositorBank != "")
                    {
                        lblPayThrough.Text += " Dt. " + CommonClass.GetShortDateAtLocalDateFormat(mrBank[0].dteDate)
                            + ", Bank: " + mrBank[0].strDepositorBank
                            + ", Branch: " + mrBank[0].strDepositorBranch;
                    }

                    lblPayThrough.Text += "</br><span style=\"font-size:9px;font-weight:bold;\">In " + mrBank[0].strBankName + " (" + mrBank[0].strAccNo + ")</span>";

                    string date = CommonClass.GetShortDateAtLocalDateFormat(mrBank[0].dteDate);
                    lblMR.Text = mrBank[0].strCode;
                    lblDD.Text = date.Substring(0, 2);
                    lblMM.Text = date.Substring(3, 2);
                    lblYY.Text = date.Substring(6, 4);

                    lblAmount.Text = new AmountFormat().SetCommaInAmount(mrBank[0].monAmount, "", "");
                    lblInWords.Text = new AmountFormat().GetTakaInWords(mrBank[0].monAmount, "", " Only");

                    lblReceiveFrom.Text = mrBank[0].strReceiveFrom;
                    if (mrBank[0].strNarration.Length > 90)
                    {
                        lblNarr.Text = mrBank[0].strNarration.Substring(0, 90);
                    }
                    else
                    {
                        lblNarr.Text = mrBank[0].strNarration;
                    }

                    lblCompany.Text = mrBank[0].strUnit.ToUpper();
                    lblAddress.Text = mrBank[0].strUnitAddress;


                    barcode = mrBank[0].strCode.Replace("-", "") + mrBank[0].strSecurityCode;

                    imgLogo.ImageUrl = "../../Content/images/img/" + mrBank[0].intUnitID + ".png";
                    imgLogo1.ImageUrl = "../../Content/images/img/" + mrBank[0].intUnitID + ".png";
                }
                else //Cash Mrr
                {

                    CashVoucher ch = new CashVoucher();
                    CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintMRDataDataTable mrCash = ch.GetCashMRPrintData(id, Session[SessionParams.USER_ID].ToString());

                    lblPayThrough.Text = "By Cash";

                    string date = CommonClass.GetShortDateAtLocalDateFormat(mrCash[0].dteDate);
                    lblMR.Text = mrCash[0].strCode;
                    lblDD.Text = date.Substring(0, 2);
                    lblMM.Text = date.Substring(3, 2);
                    lblYY.Text = date.Substring(6, 4);

                    lblAmount.Text = new AmountFormat().SetCommaInAmount(mrCash[0].monAmount, "", "");
                    lblInWords.Text = new AmountFormat().GetTakaInWords(mrCash[0].monAmount, "", " Only");

                    lblReceiveFrom.Text = mrCash[0].strReceiveFrom;
                    if (mrCash[0].strNarration.Length > 90)
                    {
                        lblNarr.Text = mrCash[0].strNarration.Substring(0, 90);
                    }
                    else
                    {
                        lblNarr.Text = mrCash[0].strNarration;
                    }

                    lblCompany.Text = mrCash[0].strUnit.ToUpper();
                    lblAddress.Text = mrCash[0].strUnitAddress;

                    barcode = mrCash[0].strCode.Replace("-", "") + mrCash[0].strSecurityCode;
                    imgLogo.ImageUrl = "../../Content/images/img/" + mrCash[0].intUnitID + ".png";
                    imgLogo1.ImageUrl = "../../Content/images/img/" + mrCash[0].intUnitID + ".png";
                }
            }

            Image1.ImageUrl = "BarCodeHandler.ashx?info=" + barcode;
            Image2.ImageUrl = "BarCodeHandler.ashx?info=" + barcode;

            lblAddress1.Text = lblAddress.Text;
            lblAmount1.Text = lblAmount.Text;
            lblCompany1.Text = lblCompany.Text;
            lblDD1.Text = lblDD.Text;
            lblInWords1.Text = lblInWords.Text;
            lblMM1.Text = lblMM.Text;
            lblMR1.Text = lblMR.Text;
            lblPayThrough1.Text = lblPayThrough.Text;
            lblReceiveFrom1.Text = lblReceiveFrom.Text;
            lblNarr1.Text = lblNarr.Text;
            lblYY1.Text = lblYY.Text;
        }
    }
}
