using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Report
{
    public partial class DailyCollectionReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'http://report.akij.net/reports/report/AFBL/Marketing/Management/DailyCollectionReport?rs:Embed=true');", true);

            }

        }
    }
}