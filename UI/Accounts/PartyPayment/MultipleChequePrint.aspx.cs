using BLL.Accounts.Voucher;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class MultipleChequePrint : BasePage
    {
        BankVoucher bv = new BankVoucher(); string spacerForAmountInWords = ""; AmountFormat amountformate = new AmountFormat();
        string payType = ""; string sessionUserId = ""; string selectedVoucherId = ""; string InWord1; string InWord2;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            selectedVoucherId = Request.QueryString["selectedvouchers"].ToString();
            payType = Request.QueryString["paytype"].ToString();
            sessionUserId = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            if (!String.IsNullOrEmpty(selectedVoucherId))
            {
                string[] voucherid = Regex.Split(selectedVoucherId, ",");
                for (int item = 0; item < voucherid.Count(); item++)
                {
                    string innerTableHtml = "";
                    string singlevoucher = voucherid[item];
                    DAL.Accounts.Voucher.BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeDataDataTable dtvinfo = bv.GetBankChequePrintData(singlevoucher, sessionUserId, payType);

                    #region ---------- Set Data In Controls ---------------
                    decimal amount = dtvinfo[0].monAmount;
                    DateTime dte = dtvinfo[0].dteChequeDate;
                    string ChequeNo = dtvinfo[0].strChequeNo + " [" + dtvinfo[0].strBankName + "]";
                    string Amount_ = amountformate.SetCommaInAmount(amount, "", "/=");
                    string InWord = spacerForAmountInWords + amountformate.GetTakaInWords(amount, "", "Only.");

                    string[] inwrd = Regex.Split(InWord, " ");
                    InWord1 = ""; InWord2 = "";
                    for (int i = 0; i < inwrd.Length; i++)
                    {
                        if (i <= 6)
                        { InWord1 += inwrd[i] + " "; }
                        else { InWord2 += inwrd[i] + " "; }
                    }

                    string PayTo = dtvinfo[0].strPayTo;
                    string str = String.Format("{0:D2}", dte.Day);
                    string D1 = str[0].ToString();
                    string D2 = str[1].ToString();
                    str = String.Format("{0:D2}", dte.Month);
                    string M1 = str[0].ToString();
                    string M2 = str[1].ToString();
                    str = dte.Year.ToString();
                    string Y1 = str[0].ToString();
                    string Y2 = str[1].ToString();
                    string Y3 = str[2].ToString();
                    string Y4 = str[3].ToString();
                    string Unit = "FOR " + dtvinfo[0].strUnit.ToUpper();
                    string Sig1 = "Authorised Signature";
                    string Sig2 = "Authorised Signature";
                    string Sig3 = "Authorised Signature";
                    string TokAmount = amountformate.SetCommaInAmount(amount, "", "/=");
                    string TokDate = CommonClass.GetShortDateAtLocalDateFormat(dtvinfo[0].dteChequeDate);
                    string TokPayee = dtvinfo[0].strPayTo;
                    string TokCodeImageUrl = "../Print/BarCodeHandler.ashx?info=" + dtvinfo[0].strCode.Replace("-", "");
                    #endregion

                    #region ----------- Generate InnerHTML -----------
                    if (payType == "bn")
                    {
                        innerTableHtml = @" <table border='0' style='margin-left:8px;margin-top:15px;'>
                        <tr>
                        <td style='width:132px; padding-top:40px;'>"; innerTableHtml = innerTableHtml + TokDate + @"</td>
                        <td style='width:415px;padding-left:200px;'><img src=../PartyPayment/acPayee.png></td>
                        <td style='padding-left:16px;padding-top:8px;font-size: 15px;letter-spacing: 11px; font-weight: bold;'>";
                        innerTableHtml = innerTableHtml + D1 + D2 + M1 + M2 + Y1 + Y2 + Y3 + Y4 + @"</td>
                        </tr>
                        <tr><td style='width:132px;'></td>
                        <td colspan='2' style='padding-left:200px; padding-top:1px;font-size: 14px;'>";
                        innerTableHtml = innerTableHtml + @"<b>" + PayTo + @"</td>
                        </tr>                        
                        <tr>
                        <td style='width:132px; padding-top:0px;'>"; innerTableHtml = innerTableHtml + TokPayee + @"</br>" + TokAmount + @"</td>
                        <td colspan='2'><table border='0'><tr><td style='width:230px;'></td>
                        <td style='width:367px; padding-left:10px; padding-top:5px;font-size: 13px; line-height: 27px;'>";
                        innerTableHtml = innerTableHtml + InWord1 + @"<br />" + InWord2 + @"</td>
                        <td style='padding-left:15px; padding-top:-10px; font-size: 15px;'>"; innerTableHtml = innerTableHtml + @"<b>" + Amount_ + @"</td>
                        </tr></table>
                        </td>
                        </tr>
                        <tr><td style='width:132px;'>";
                        innerTableHtml = innerTableHtml + @"<img src=" + TokCodeImageUrl + @" Height='10px' Width='132px'>
                        </td>
                        <td colspan='2' style='width:500px; padding-right:30px; padding-top:1px;font-size: 10px; text-align:right;'>";
                        innerTableHtml = innerTableHtml + @"<b>" + Unit + @"</td>                 
                        </tr>
                        <tr><td style='width:132px;'></td>
                        <td colspan='2' style='width:500px; padding-right:2px; padding-top:27px;font-size: 9px; text-align:right;'>";
                        innerTableHtml = innerTableHtml + Sig1 + "&nbsp;&nbsp;&nbsp;" + Sig2 + "&nbsp;&nbsp;&nbsp;" + Sig3 + @"</td>
                        </tr>
                        </table>";
                    }


                    else
                    {
                        innerTableHtml = @" <table border='0' style='margin-left:8px;margin-top:15px;'>
                        <tr>
                        <td style='width:132px; padding-top:40px;'>"; innerTableHtml = innerTableHtml + TokDate + @"</td>
                        <td style='width:415px;padding-left:200px;'><img src=../PartyPayment/acPayee_.png></td>
                        <td style='padding-left:16px;padding-top:8px;font-size: 15px;letter-spacing: 11px; font-weight: bold;'>";
                        innerTableHtml = innerTableHtml + D1 + D2 + M1 + M2 + Y1 + Y2 + Y3 + Y4 + @"</td>
                        </tr>
                        <tr><td style='width:132px;'></td>
                        <td colspan='2' style='padding-left:200px; padding-top:1px;font-size: 14px;'>";
                        innerTableHtml = innerTableHtml + @"<b>" + PayTo + @"</td>
                        </tr>                        
                        <tr>
                        <td style='width:132px; padding-top:0px;'>"; innerTableHtml = innerTableHtml + TokPayee + @"</br>" + TokAmount + @"</td>
                        <td colspan='2'><table border='0'><tr><td style='width:230px;'></td>
                        <td style='width:367px; padding-left:10px; padding-top:5px;font-size: 13px; line-height: 27px;'>";
                        innerTableHtml = innerTableHtml + InWord1 + @"<br />" + InWord2 + @"</td>
                        <td style='padding-left:15px; padding-top:-10px; font-size: 15px;'>"; innerTableHtml = innerTableHtml + @"<b>" + Amount_ + @"</td>
                        </tr></table>
                        </td>
                        </tr>
                        <tr><td style='width:132px;'>";
                        innerTableHtml = innerTableHtml + @"<img src=" + TokCodeImageUrl + @" Height='10px' Width='132px'>
                        </td>
                        <td colspan='2' style='width:500px; padding-right:30px; padding-top:1px;font-size: 10px; text-align:right;'>";
                        innerTableHtml = innerTableHtml + @"<b>" + Unit + @"</td>                 
                        </tr>
                        <tr><td style='width:132px;'></td>
                        <td colspan='2' style='width:500px; padding-right:2px; padding-top:27px;font-size: 9px; text-align:right;'>";
                        innerTableHtml = innerTableHtml + Sig1 + "&nbsp;&nbsp;&nbsp;" + Sig2 + "&nbsp;&nbsp;&nbsp;" + Sig3 + @"</td>
                        </tr>
                        </table>";
                    }


                    #endregion

                    #region ----------- Generate Div and Filter InnerHTML -----------
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    createDiv.ID = "createDiv";
                    createDiv.InnerHtml = innerTableHtml;
                    createDiv.Attributes.Add("class", "dynamicDivbn");
                    this.Controls.Add(createDiv);
                    #endregion
                                
                }
            }
        }

















    }
}