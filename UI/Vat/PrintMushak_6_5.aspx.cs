using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class PrintMushak_6_5 : BasePage
    {
        string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string M65 = "5";//Request.QueryString["M65"];
                string VATPointID = "1";// Request.QueryString["VATPointID"];
                string VATYear = "20182019";//Request.QueryString["VATYear"];


                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/VAT_Management/M-6.5" + "&M65=" + M65 + "&VATPointID=" + VATPointID + "&intVATYear=" + VATYear +  "&rc:LinkTarget=_self"; 
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
            }
        }
    }
}