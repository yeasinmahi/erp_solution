using System;
using System.Configuration;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (ConfigurationManager.AppSettings["UM"].ToUpper() == "Y")
            {
                Response.Redirect("UnderMaintanance.aspx?err=-1");
            }
            else
            {
                Response.Redirect("LoginProcess.aspx");
            }

            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "r", "thePopupWindows(LoginProcess.aspx)", false);

            //}
        }
    }
}
