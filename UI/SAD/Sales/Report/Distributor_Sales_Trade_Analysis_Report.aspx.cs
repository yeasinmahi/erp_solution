using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class Distributor_Sales_Trade_Analysis_Report : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                // btn
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Sales%20And%20Distribution/Distributor_Sales_Trade_Analysis?rs:Embed=true');", true);

        }
    }
}