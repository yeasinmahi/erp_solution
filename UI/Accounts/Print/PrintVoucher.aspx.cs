using Flogging.Core;
using GLOBAL_BLL;
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
using UI.ClassFiles;


namespace UI.Accounts.Print
{
    //public partial class Accounts_Voucher_PrintVoucher : System.Web.UI.Page
    public partial class PrintVoucher : BasePage
    {
        UI.ClassFiles.Print printVoucher = new UI.ClassFiles.Print();
        string htmlString = "";
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Print\\PrintVoucher";
        string stop = "stopping Accounts\\Print\\PrintVoucher";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Pageload", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Print\\PrintVoucher   Page load ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            { //Session["sesUserID"] = "1";
                string userID = "" + Session[SessionParams.USER_ID];

            if (Request.QueryString.Count > 0)
            {
                string id = Request.QueryString["id"];
                string type = Request.QueryString["type"];//Bank > bn ,Cash > ch, Journal > jr
                string unitName = "";
                string unitAddress = "";
                string strCodeForbarCode = "";
                string voucherCode = "";
                bool isDebitVoucher = false;

                try
                {
                    isDebitVoucher = bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
                }
                catch
                {
                }


                /*
                string id = "13";
                string type = "ch";//Bank > bn ,Cash > ch, Journal > jr
                bool isDebitVoucher = true;//bool.Parse(Request.QueryString["isDr"]);//if true then Debit voucher else Credit Voucher
                */
                string voucherType = "";
                if (isDebitVoucher)
                {
                    voucherType = "Debit Voucher";
                }
                else
                {
                    voucherType = "Credit Voucher";
                }

                string unitID = "";
                if (type == "bn") // Bank Voucher
                {
                    voucherType = voucherType + " (BANK)";
                    htmlString = printVoucher.PrintBankVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }
                else if (type == "ch")// Cash Voucher
                {
                    voucherType = voucherType + " (CASH)";

                    htmlString = printVoucher.PrintCashVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);

                }
                else if (type == "cn")
                {
                    voucherType = "Contra";
                    htmlString = printVoucher.PrintContraVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }
                else // Journel Voucher
                {
                    voucherType = "Journal Voucher";
                    htmlString = printVoucher.PrintJournalVoucher(voucherType, id, userID, ref unitName, ref unitAddress, ref strCodeForbarCode, ref unitID);
                }

                //string jsString = "<script type=\"text/javascript\">";
                //jsString = jsString + "DivItem(" + htmlString + ")";
                //jsString = "</script>";
                //Response.Write(jsString);
                lblUnitName.Text = unitName.ToUpper();
                lblUnitAddress.Text = unitAddress;
                lblVoucherType.Text = "<br><br>" + voucherType;
                strCodeForbarCode = strCodeForbarCode.Replace("-", "");
                Image1.ImageUrl = "BarCodeHandler.ashx?info=" + strCodeForbarCode;
                Image1.Width = 180;
                Image1.Height = 50;

                //logo image
                Image2.ImageUrl = "../../Content/Images/img/" + unitID + ".png";
                //Image2.Width = 180;
                //Image2.Height = 50;
                Label1.Text = htmlString;

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
