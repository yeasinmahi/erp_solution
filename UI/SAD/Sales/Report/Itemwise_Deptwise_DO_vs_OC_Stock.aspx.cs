using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales.Report
{
    public partial class Itemwise_Deptwise_DO_vs_OC_Stock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Sales%20And%20Distribution/Itemwise_Deptwise_vs_Oc_vs_Stock?rs:Embed=true');", true);

        }
    }
}