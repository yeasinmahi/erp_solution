using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Asset.Report
{
    public partial class VehicleMaintenanceSummaryByUnit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Asset_Module/VehicleMaintenanceSummaryByUnit?rs:Embed=true');", true);

        }
    }
}