using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using UserSecurity;

namespace UI
{
    public partial class SessionExpired : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSecurityService uss = new UserSecurityService();
            try
            {
                uss.SignOut(Session[SessionParams.EMAIL].ToString(), Session.SessionID);
            }
            catch
            {

            }
            Session.Abandon();
            Session.Clear();
        }
    }
}