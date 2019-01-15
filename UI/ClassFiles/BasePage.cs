using System;
using System.Web;
using System.Web.UI;
using UserSecurity;

/// <summary>
/// Developped By Akramul Haider
/// Base of al *.aspx pages
/// </summary>
namespace UI.ClassFiles
{
    public class BasePage : Page
    {
        protected int Enroll = 0;
        protected int JobStationId = 0;

        protected override void OnPreInit(EventArgs e)
        {
            Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            JobStationId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            base.OnPreInit(e);
            UserActivityCheck();
            Page.Title = @"Welcome to Akij Group";
        }

        //protected void OnLoad(object sender, EventArgs e)
        //{
        //    base.OnLoad(e);
        //}

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

        public void Alert(string message)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                "alert('" + message + "');", true);
        }
    }
}