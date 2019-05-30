using System;
using System.Web;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class HomePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
        }

    }
}
