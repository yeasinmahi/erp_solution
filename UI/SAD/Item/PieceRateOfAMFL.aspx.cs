using System;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SAD.Item
{
    public partial class PieceRateOfAMFL : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Sales%20And%20Distribution/PieceRateOfAMFL?rs:Embed=true');", true);

        }
    }
}