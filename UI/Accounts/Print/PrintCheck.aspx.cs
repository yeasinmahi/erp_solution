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
using BLL;
using BLL.Accounts.Voucher;
using DAL.Accounts.Voucher;
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;
/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI.Accounts.Print
{
    public partial class PrintCheck : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Print\\PrintCheck";
        string stop = "stopping Accounts\\Print\\PrintCheck";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            var fd = log.GetFlogDetail(start, location, "Pageload", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Print\\PrintCheck   Page load ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (Request.QueryString.Count > 0)
            {

                BankVoucher bv = new BankVoucher();
                BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeDataDataTable table = bv.GetBankChequePrintData(Request.QueryString["id"], Session["sesUserID"].ToString(), Request.QueryString["type"]);
                //BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeDataDataTable table = bv.GetBankChequePrintData("296", Session["sesUserID"].ToString());

                if (table.Rows.Count > 0)
                {
                    decimal amount = table[0].monAmount;
                    string spacerForAmountInWords = "";

                    //if (table[0].intBankID == 1)
                    {
                        spacerForAmountInWords = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                        pnlAccPay.CssClass = "pnlAccPay";
                        pnlAmount.CssClass = "pnlAmount";
                        pnlDate.CssClass = "pnlDate";
                        pnlInWords.CssClass = "pnlInWords";
                        pnlPayTo.CssClass = "pnlPayTo";
                        pnlUnit.CssClass = "pnlUnit";
                        pnlSig1.CssClass = "pnlSig1";
                        pnlSig2.CssClass = "pnlSig2";
                        pnlSig3.CssClass = "pnlSig3";
                        pnlTokAmount.CssClass = "pnlTokAmount";
                        pnlTokDate.CssClass = "pnlTokDate";
                        pnlTokPayee.CssClass = "pnlTokPayee";
                        pnlTokCode.CssClass = "pnlTokCode";
                    }
                    AmountFormat af = new AmountFormat();
                    DateTime dte = table[0].dteChequeDate;

                    lblChequeNo.Text = table[0].strChequeNo + " [" + table[0].strBankName + "]";
                    lblAmount.Text = af.SetCommaInAmount(amount, "", "/=");
                    lblInWord.Text = spacerForAmountInWords + af.GetTakaInWords(amount, "", "Only.");
                    lblPayTo.Text = table[0].strPayTo;
                    string str = String.Format("{0:D2}", dte.Day);
                    lblD1.Text = str[0].ToString();
                    lblD2.Text = str[1].ToString();
                    str = String.Format("{0:D2}", dte.Month);
                    lblM1.Text = str[0].ToString();
                    lblM2.Text = str[1].ToString();
                    str = dte.Year.ToString();
                    lblY1.Text = str[0].ToString();
                    lblY2.Text = str[1].ToString();
                    lblY3.Text = str[2].ToString();
                    lblY4.Text = str[3].ToString();
                    lblUnit.Text = "FOR " + table[0].strUnit.ToUpper();
                    lblSig1.Text = "Authorised Signature";
                    lblSig2.Text = "Authorised Signature";
                    lblSig3.Text = "Authorised Signature";
                    lblTokAmount.Text = af.SetCommaInAmount(amount, "", "/=");
                    lblTokDate.Text = CommonClass.GetShortDateAtLocalDateFormat(table[0].dteChequeDate);
                    lblTokPayee.Text = table[0].strPayTo;
                    imgTokCode.ImageUrl = "BarCodeHandler.ashx?info=" + table[0].strCode.Replace("-", "");
                }
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Pageload", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Pageload", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
















    }
}

