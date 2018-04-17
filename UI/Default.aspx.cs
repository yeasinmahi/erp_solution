using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

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
