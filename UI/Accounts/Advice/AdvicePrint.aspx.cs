using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class AdvicePrint : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bankName = Request.QueryString["bankName"];
                string unitId = Request.QueryString["unitId"];
                string accountId = Request.QueryString["accountId"];
                string insertBy = Request.QueryString["insertBy"];
                string dteDate = Request.QueryString["dteDate"];
                string url = "";
                if (bankName=="IBBL")
                {
                    url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Payment/PaymentAdviceIBBLReport" + "&bankName=" + bankName + "&intUnitID=" + unitId + "&intBankID=" + accountId + "&insertBy=" + insertBy + "&dteDate=" + dteDate + "&rs:Embed=true&rc:LinkTarget=_self";

                }
                else
                {
                    url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Payment/PaymentAdviceReport" + "&bankName=" + bankName + "&intUnitID=" + unitId + "&intBankID=" + accountId + "&insertBy=" + insertBy + "&dteDate=" + dteDate + "&rs:Embed=true&rc:LinkTarget=_self";

                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
            }
        }
    }
}