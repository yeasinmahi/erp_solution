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
using System.Text;

using UserRole;
using UserRole.DAL;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class Left : BasePage
    {
        protected StringBuilder links = new StringBuilder();
        protected StringBuilder link1 = new StringBuilder();
        protected StringBuilder link2 = new StringBuilder();
        protected StringBuilder link3 = new StringBuilder();
        protected StringBuilder divs = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));

            RolesOfUser rl = new RolesOfUser();
            RoleTDS.SprRoleGetRolesForUserDataTable table = rl.GetMenuItems(Session[SessionParams.EMAIL].ToString());//"alamin@akij.net");//

            if (table.Rows.Count > 0)
            {
                int count = 0;
                int preComp = table[0].intParentId;

                divs.Append("<div class=\"sggbe_panel\" id=\"" + count + "\"><div>");
                divs.Append("<a href=\"" + table[0].strRelativeURL + "\" class=\"xp\" target=\"filter\">");
                //divs.Append("<img src=\"App_Themes/" + this.Theme + "/Icons/" + table[0].strImage + "\" class=\"menuicon\" border=\"0\">" + table[0].strFunc + "</a><br />");
                divs.Append("<img src=\"Content/images/icons/" + table[0].strImage + "\" class=\"menuicon\" border=\"0\">" + table[0].strFunc + "</a><br />");

                link1.Append("'" + table[0].strFuncParent + "'");
                link2.Append("true");
                link3.Append("'" + count + "'");

                count++;


                for (int i = 1; i < table.Rows.Count; i++)
                {
                    if (preComp == table[i].intParentId)
                    {
                        divs.Append("<a href=\"" + table[i].strRelativeURL + "\" class=\"xp\" target=\"filter\">");
                        //divs.Append("<img src=\"App_Themes/" + this.Theme + "/Icons/" + table[i].strImage + "\" class=\"menuicon\" border=\"0\">" + table[i].strFunc + "</a><br />");
                        divs.Append("<img src=\"Content/images/icons/" + table[i].strImage + "\" class=\"menuicon\" border=\"0\">" + table[i].strFunc + "</a><br />");
                    }
                    else
                    {
                        divs.Append("</div></div>");
                        divs.Append("<div class=\"sggbe_panel\" id=\"" + count + "\"><div>");
                        divs.Append("<a href=\"" + table[i].strRelativeURL + "\" class=\"xp\" target=\"filter\">");
                       // divs.Append("<img src=\"App_Themes/" + this.Theme + "/Icons/" + table[i].strImage + "\" class=\"menuicon\" border=\"0\">" + table[i].strFunc + "</a><br />");
                        divs.Append("<img src=\"Content/images/icons/" + table[i].strImage + "\" class=\"menuicon\" border=\"0\">" + table[i].strFunc + "</a><br />");

                        link1.Append(",'" + table[i].strFuncParent + "'");
                        link2.Append(",false");
                        link3.Append(",'" + count + "'");

                        count++;
                        preComp = table[i].intParentId;
                    }
                }

                divs.Append("</div></div>");

                links.Append(
                            @"initsggbe_xpPane(
                    Array(" + link1.ToString() + @"),
                    Array(" + link2.ToString() + @"),
                    Array(" + link3.ToString() + @"),
                    'Content/images/img/xpmenu');
                    ");
            }

            this.DataBind();

        }
    }
}
