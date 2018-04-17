using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using UserSecurity;

/// <summary>
/// Developped By Akramul Haider
/// Base of al *.aspx pages
/// </summary>
namespace UI.ClassFiles
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            UserActivityCheck();
            Page.Title = "Welcome to Akij Group";
        }
        public BasePage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void UserActivityCheck()
        {
            string retStr = "";
            UserSecurityService us = new UserSecurityService();
            //try
            //{
            //    retStr = Session["Test"].ToString();       
            //}
            //catch
            //{
            //    retStr = "0";
            //}
            try
            {
                if (!us.UpdateUserActivity(Session[SessionParams.EMAIL].ToString(), Session.SessionID))
                {
                    retStr = "~/SessionExpired.aspx";
                }



            }
            catch
            {
                retStr = "~/SessionExpired.aspx";
            }

            if (retStr != "")
            {
                Response.Redirect(retStr);
                return;
            }
        }
    }
}
