using System;
using System.Web.UI;

namespace UI.Inventory
{
    public partial class PoReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); 
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Ruhul/Binti/Purchase%20Order%20Report?rs:Embed=true');", true);

        }
    }
}