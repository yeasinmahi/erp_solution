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
using System.Text;
using DAL.Accounts.Voucher;
using BLL;
using BLL.Accounts.Banking;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Accounts.Print
{
    public partial class ChequeRegister : BasePage
    {
        protected StringBuilder sb = new StringBuilder();
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Print\\ChequeRegister";
        string stop = "stopping Accounts\\Print\\ChequeRegister";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Pageload", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Print\\ChequeRegister   Page load ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int count = 1;
            int? previousCount = 0;
            string unitName = "", bank = "", accNo = "";
            VoucherForChqPrint bv = new VoucherForChqPrint();
            BankVoucherPrintTDS.SprAccountsVoucherBankGetPrintChequeRegisterDataTable table = bv.GetBankChequeRegisterPrint(Request.QueryString["dte"], Session["sesUserID"].ToString(), Request.QueryString["unt"], Request.QueryString["acc"], Request.QueryString["ids"], Request.QueryString["idsC"], true, ref unitName, ref previousCount);
            bank = Request.QueryString["bnkN"];
            accNo = Request.QueryString["accN"];

            int rest = (int)previousCount % 10;
            if (rest > 0)
            {
                count = rest + 1;
                sb.Append(@"<tr style=""height:90px;""><td colspan=""9"" class=""regTableWhite""></td></tr>");
                sb.Append(@"<tr style=""height:35px;""><td colspan=""9"" class=""regTableWhite""></td></tr>");
                sb.Append(@"<tr style=""height:35px;""><td colspan=""9"" class=""regTableWhite""></td></tr>");

                for (int i = 1; i <= count; i++)
                {
                    sb.Append(@"<tr style=""height:50px;"" class=""regTableWhite"">
                        <td style=""width:100px;"" class=""regTableWhite""></td>
                        <td style=""width:75px;"" class=""regTableWhite""></td>
                        <td style=""width:75px;"" class=""regTableWhite""></td>
                        <td style=""width:90px;"" class=""regTableWhite""></td>
                        <td style=""width:290px;"" class=""regTableWhite""></td>                        
                        <td style=""width:100px;"" class=""regTableWhite""></td>
                        <td style=""width:100px;"" class=""regTableWhite""></td>
                        <td style=""width:100px;"" class=""regTableWhite""></td>
                        <td style=""width:100px;"" class=""regTableWhite""></td>
                    </tr>");
                }
            }
            else
            {
                sb.Append(@"<tr style=""height:50px;""><td colspan=""2"" class=""header"" align=""left"">" + CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now) + @"</td><td colspan=""7"" class=""header"">Cheque Register</td></tr>");
                sb.Append(@"<tr style=""height:35px;""><td colspan=""2"" class=""unit""></td><td colspan=""7"" class=""unit"">" + unitName + "</td></tr>");
                sb.Append(@"<tr style=""height:35px;""><td colspan=""5""  class=""bnk""  align=""left"">" + bank + @"</td><td colspan=""4""  class=""bnk"" align=""right"">" + accNo + @"</td></tr>");
                sb.Append(@"<tr style=""height:50px; font-size:11px; font-weight:bold; text-align:center; background-color:#C0C0C0;"" class=""regTable"">
                        <td style=""width:100px;"" class=""regTable"">Code</td>
                        <td style=""width:75px;"" class=""regTable"">Date</td>
                        <td style=""width:75px;"" class=""regTable"">Chq. Date</td>
                        <td style=""width:90px;"" class=""regTable"">Chq. No</td>
                        <td style=""width:290px;"" class=""regTable"">Pay To</td>
                        <td style=""width:100px;"" class=""regTable"">Amount</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                    </tr>");
            }


            AmountFormat af = new AmountFormat();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                sb.Append(@"<tr style=""height:50px;"" class=""regTable"">
                        <td style=""width:100px;"" class=""regTable"">" + table[i].strCode + @"</td>
                        <td style=""width:75px;"" class=""regTable"">" + table[i].dteVoucherDate + @"</td>
                        <td style=""width:75px;"" class=""regTable"">" + table[i].dteChequeDate + @"</td>
                        <td style=""width:90px;"" class=""regTable"">" + table[i].strChequeNo + @"</td>
                        <td style=""width:290px;"" class=""regTable"">" + table[i].strPayToPrint + @"</td>                        
                        <td style=""width:100px;text-align:right;font-size:12px;"" class=""regTable"">" + af.SetCommaInAmount(table[i].monAmount, "", "") + @"</td>
                        <td style=""width:100px;"" class=""regTable""></td>
                        <td style=""width:100px;"" class=""regTable""></td>
                        <td style=""width:100px;"" class=""regTable""></td>
                    </tr>");

                count++;
                if (count > 10)
                {
                    count = 1;
                }

                if (count == 1 && i < (table.Rows.Count - 1))
                {
                    sb.Append(@"<tr ><td colspan=""9"" style=""page-break-before:always;height:10px;""></td></tr>");
                    sb.Append(@"<tr style=""height:50px;""><td colspan=""2"" class=""header"" align=""left"">" + CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now) + @"</td><td colspan=""7"" class=""header"">Cheque Register</td></tr>");
                    sb.Append(@"<tr style=""height:35px;""><td colspan=""2"" class=""unit""></td><td colspan=""7"" class=""unit"">" + unitName + "</td></tr>");
                    sb.Append(@"<tr style=""height:35px;""><td colspan=""5""  class=""bnk"" align=""left"">" + bank + @"</td><td colspan=""4""  class=""bnk"" align=""right"">" + accNo + @"</td></tr>");
                    sb.Append(@"<tr style=""height:50px; font-size:11px; font-weight:bold; text-align:center; background-color:#C0C0C0;"" class=""regTable"">
                        <td style=""width:100px;"" class=""regTable"">Code</td>
                        <td style=""width:75px;"" class=""regTable"">Date</td>
                        <td style=""width:75px;"" class=""regTable"">Chq. Date</td>
                        <td style=""width:90px;"" class=""regTable"">Chq. No</td>
                        <td style=""width:290px;"" class=""regTable"">Pay To</td>
                        <td style=""width:100px;"" class=""regTable"">Amount</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                        <td style=""width:100px;"" class=""regTable"">Signature</td>
                    </tr>");
                }
            }

            Panel1.DataBind();
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
