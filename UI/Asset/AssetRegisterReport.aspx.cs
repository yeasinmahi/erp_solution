using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Asset
{
    public partial class AssetRegisterReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else { }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frameGEneral', 'https://report.akij.net/reports/report/Asset_Module/Land_Report?rs:Embed=true');", true);

            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('IframeVehicle', 'http://report.akij.net/reports/report/Asset_Module/Register_Report/Vehicle_Asset_Registration_2?rs:Embed=true');", true);

            Tab1.CssClass = "Initial";
                Tab2.CssClass = "Clicked";
                Tab3.CssClass = "Initial";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 1; 
        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('IframeLand', 'https://report.akij.net/reports/report/Asset_Module/Land_Report?rs:Embed=true');", true);


            Tab1.CssClass = "Initial";
                Tab2.CssClass = "Initial";
                Tab3.CssClass = "Clicked";
                Tab4.CssClass = "Initial";
                MainView.ActiveViewIndex = 2; 
        }
        protected void Tab4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Asset_Module/Land_Report?rs:Embed=true');", true);


            Tab1.CssClass = "Initial";
                    Tab2.CssClass = "Initial";
                    Tab3.CssClass = "Initial";
                    Tab4.CssClass = "Clicked";
                    MainView.ActiveViewIndex = 3;
               
 
        }
    }
}