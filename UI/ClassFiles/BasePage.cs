using System;
using System.Web;
using System.Web.UI;
using UserSecurity;
using Utility;

#pragma warning disable 1587
/// <summary>
/// Developped By Akramul Haider, Update by MD. Yeasin Arafat
/// Base of all *.aspx pages
/// </summary>
#pragma warning restore 1587
namespace UI.ClassFiles
{
    public class BasePage : Page
    {
        //protected int Enroll = 0;
        public int Enroll { get; private set; }
        public int JobStationId { get; private set; }
        public int UnitId { get; private set; }
        public String UnitName { get; private set; }
        public string UserEmail { get; private set; }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            UserActivityCheck();
            Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            JobStationId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            UnitId = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            UnitName = HttpContext.Current.Session[SessionParams.UNIT_NAME].ToString();
            UserEmail = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            Page.Title = @"Welcome to Akij Group";
        }

        //protected void OnLoad(object sender, EventArgs e)
        //{
        //    base.OnLoad(e);
        //}
        public string GetActivePageUrl()
        {
            return Request.Url.AbsoluteUri;
        }

        public string GetPageName()
        {
            string[] segments = Request.Url.Segments;
            string pageName = segments[Array.FindIndex(segments, row => row.Contains(".aspx"))];
            return pageName.Replace(".aspx", "");
        }
        
        // ReSharper disable once EmptyConstructor
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
                    retStr = "~/LoginProcess.aspx?returnUrl=" + GetActivePageUrl();
                }
            }
            catch
            {
                retStr = "~/LoginProcess.aspx?returnUrl=" + GetActivePageUrl();
            }

            if (retStr != "")
            {
                Response.Redirect(retStr);
            }
        }

        public void Alert(string message)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                "alert('" + message + "');", true);
        }

        public void Toaster(string message)
        {
            if (message.ToLower().Contains("success"))
            {
                Toaster(message, GetPageName().SplitCamelCase(), Common.TosterType.Success);
            }
            else if (message.ToLower().Contains("exception"))
            {
                Toaster(message, GetPageName().SplitCamelCase(), Common.TosterType.Error);
            }
            else
            {
                Toaster(message, GetPageName().SplitCamelCase(), Common.TosterType.Warning);
            }

        }
        public void Toaster(string message, Common.TosterType type)
        {
            Toaster(message, GetPageName().SplitCamelCase(), type);
        }
        public void Toaster(string message, string header, Common.TosterType type)
        {
            message = message.Replace("'", "\"");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                "ShowNotification('" + message + "','" + header + "','" + type.ToString().ToLower() + "')", true);
        }
        public void ConfirmMsg()
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                "confirmMsg();", true);
        }
        public void SetVisibility(string id, bool isVisible)
        {
            SetVisibility(id, id, isVisible);

        }
        private void SetVisibility(string head ,string id, bool isVisible)
        {
            if (isVisible)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), head, "showDiv('" + id + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), head, "hideDiv('" + id + "');", true);
            }

        }
        public void SetVisibilityModal(bool isVisible)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", isVisible ? "openModal();" : "closeModal();",
                true);
        }
        public void LoadIFrame(string iFrameId, string url)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('" + iFrameId + "', '" + url + "');", true);
        }
    }
}