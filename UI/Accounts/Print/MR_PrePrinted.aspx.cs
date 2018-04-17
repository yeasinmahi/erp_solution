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

namespace UI.Accounts.Print
{
    public partial class MR_PrePrinted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            string barcode = "";
            if (Request.QueryString.Count > 0)
            {

                string id = Request.QueryString["id"];
                string type = (Request.QueryString["type"]);//Bank > bn ,Cash > ch
                string spacer = "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp";

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
                    else
                    {
                        lblPayThrough.Text = "";
                    }

                    if (mrBank[0].strNo != "") lblPayThrough.Text += " No. " + mrBank[0].strNo;

                    lblMR.Text = mrBank[0].strCode;
                    lblDD.Text = CommonClass.GetShortDateAtLocalDateFormat(mrBank[0].dteDate);
                    lblChqDD.Text = CommonClass.GetShortDateAtLocalDateFormat(mrBank[0].dteChequeDate);
                    lblAmount.Text = new AmountFormat().SetCommaInAmount(mrBank[0].monAmount, "", "");
                    lblAmountBox.Text = lblAmount.Text;
                    lblInWords.Text = spacer + spacer + new AmountFormat().GetTakaInWords(mrBank[0].monAmount, "", " Only");

                    lblReceiveFrom.Text = spacer + mrBank[0].strReceiveFrom;


                    barcode = mrBank[0].strCode.Replace("-", "") + mrBank[0].strSecurityCode;
                }
                else //Cash Mrr
                {

                    CashVoucher ch = new CashVoucher();
                    CashVoucherPrintTDS.SprAccountsVoucherCashGetPrintMRDataDataTable mrCash = ch.GetCashMRPrintData(id, Session[SessionParams.USER_ID].ToString());

                    lblPayThrough.Text = "By Cash";

                    string date = CommonClass.GetShortDateAtLocalDateFormat(mrCash[0].dteDate);
                    lblMR.Text = mrCash[0].strCode;
                    lblDD.Text = date;
                    lblChqDD.Text = "";

                    lblAmount.Text = new AmountFormat().SetCommaInAmount(mrCash[0].monAmount, "", "");
                    lblAmountBox.Text = lblAmount.Text;
                    lblInWords.Text = spacer + spacer + new AmountFormat().GetTakaInWords(mrCash[0].monAmount, "", " Only");

                    lblReceiveFrom.Text = spacer + mrCash[0].strReceiveFrom;

                    barcode = mrCash[0].strCode.Replace("-", "") + mrCash[0].strSecurityCode;
                }
            }

            Image1.ImageUrl = "BarCodeHandler.ashx?info=" + barcode;


        }
    }
}
