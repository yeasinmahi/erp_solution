using System;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ProcurementStatus : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/SCM/Procurement_Status?rs:Embed=true');", true);
        }
    }
}