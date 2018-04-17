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

using System.DirectoryServices;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// Update by Himadri At 10/07/2012
/// </summary>
namespace UI.Personal
{
    public partial class Personal_Password :BasePage
    {
        public string succ = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserSecurityService uss = new UserSecurityService();
            try
            {
                if (uss.ChangePassword(Session[SessionParams.EMAIL].ToString(), txtOld.Text, txtNew.Text, Session.SessionID))
                {
                    succ = "Successfully password changed.";
                }
                else
                {
                    succ = "Password not changed. Please try again.";
                }

                /* MembershipProvider provider = Membership.Providers["MyADMembershipProvider"];
                 bool ysnValid = provider.ValidateUser("himadri@akij.net", "123");
                 string name=provider.GetUserNameByEmail("himadri@akij.net");
                 MembershipUser user = provider.GetUser("himadri@akij.net", true);


                 var directoryEntry = new DirectoryEntry("LDAP://akij.net/CN=himadri@akij.net,CN=Users,DC=akij,DC=net", "akij.net\\Administrator","AkijGroupit1234",AuthenticationTypes.Secure);
                // var userDetails = directoryEntry.Children.Find("himadri@akij.net");
           
            
                 directoryEntry.Invoke("SetPassword", "password" );
                 directoryEntry.CommitChanges();*/

            }
            catch { succ = "Password not changed. Please try again."; }

            Panel1.Visible = true;
            Panel1.DataBind();
        }
    }

}
