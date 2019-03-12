using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Asset.Report
{
    public partial class AssetAccountingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frmDepreciation', 'https://report.akij.net/reports/report/Asset_Module/Accounts/Depreciation_Report?rs:Embed=true');", true);

            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            Tab5.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('FrmDisposal', 'https://report.akij.net/reports/report/Asset_Module/Accounts/Disposal_Retirement_Report?rs:Embed=true');", true);

            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            Tab5.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('FrmRevaluation', 'https://report.akij.net/reports/report/Asset_Module/Accounts/Revaluation_Report?rs:Embed=true');", true);


            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            Tab4.CssClass = "Initial";
            MainView.ActiveViewIndex = 2;
        }
        protected void Tab4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('FrmTransection', 'https://report.akij.net/reports/report/Asset_Module/Accounts/Transanction_Report?rs:Embed=true');", true);


            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Clicked";
            Tab5.CssClass = "Initial";
            MainView.ActiveViewIndex = 3;


        }

        protected void Tab5_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Asset_Module/Land_Report?rs:Embed=true');", true);


            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            Tab4.CssClass = "Initial";
            Tab5.CssClass = "Clicked";
            MainView.ActiveViewIndex = 4;


        }
    }
}