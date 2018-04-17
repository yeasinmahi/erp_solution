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

using UserSecurity;
using DAL.Accounts.ChartOfAccount;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
public partial class Logout : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        bool forceLogout = false;
        UserSecurityService uss = new UserSecurityService();
        try
        {
            
            uss.SignOut(Session[SessionParams.EMAIL].ToString(), Session.SessionID);
        }
        catch
        {
            forceLogout = true;
        }
        Session.Abandon();
        Session.Clear();

        if (forceLogout)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Panel1.Visible = true;
        }
    }
}
}
