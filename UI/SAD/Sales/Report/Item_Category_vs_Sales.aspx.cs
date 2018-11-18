using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class Item_Category_vs_Sales : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); 
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Vehicle%20Report/APL%20Sales%20By%20Item%20Group?rs:Embed=true');", true);

        }
    }
}