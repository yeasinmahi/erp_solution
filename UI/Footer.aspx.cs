using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class Footer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            /* ScriptManager.RegisterStartupScript(
                pnlJSScroll, pnlJSScroll.GetType(), "scrollPanel",
                "scrollPanel();",
                true);*/
        }
    }
}
