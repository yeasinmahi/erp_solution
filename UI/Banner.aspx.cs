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
    public partial class Banner : BasePage
    {
        public string links = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
            if (!IsPostBack)
            {
                lblName.Text = "Welcome Mr. " + Session[SessionParams.USER_NAME].ToString();

                /*RoleOnUser rou = new RoleOnUser();
                RoleOnUserTDS.SprGetRolesCompForUserDataTable table = rou.GetComponents(Session["sesUserID"].ToString());
            
                links = @"<div id=""navbar"">
                            <ul>
                            <li style=""width:110px;""></li>
                            <li><a target=""main"" href=""NOTICE/Default.aspx"">NOTICE BOARD</a></li>
                            <li><a target=""main"" href=""PERSONAL/Default.aspx"">PERSONAL INFO</a></li>";

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    links +=
                        @"<li><a target=""main"" href=" + table[i].strCompUrl + @">" + table[i].strCompText + @"</a></li>";
                }

                links += @"</ul>
                            <br clear=""left"" />
                            </div>";*/

                this.DataBind();
            }
        }

      
    }
}
