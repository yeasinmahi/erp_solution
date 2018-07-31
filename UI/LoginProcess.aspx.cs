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
using HR_BLL.User;
using HR_DAL.User;
using System.Security.Principal;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class LoginProcess :System.Web.UI.Page
    {
       public string  retStr = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            /*if (!IsPostBack && Request.Form.Count >= 2)
            {*/

            string user = "" + Request.Form["txtUserID"];
                string pass = "" + Request.Form["txtPass"];
                if (user == "" && pass == "")
                {
                    LoginAuto();
                }
                else
                {
                    LoginFromWeb(user, pass);
                }

            /*}

            else
            {
                Panel1.Visible = true;
                Panel1.DataBind();
            }*/
       }

        private void LoginAuto()
        {
            string id = "";
            string domainUser = Request.LogonUserIdentity.Name;
            try
            {
                string[] donainpatrs = domainUser.Split('\\');
                id = donainpatrs[1] + "@akij.net";
                //id = "test.corp@akij.net";

                string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ip == string.Empty || ip == null)
                {
                    ip = Request.ServerVariables["REMOTE_ADDR"];
                }

                try
                {
                    UserSecurityService uss = new UserSecurityService();


                    if (User.Identity.IsAuthenticated && donainpatrs[0].ToUpper() == "AKIJ")
                    {

                        uss.DomainLoginUpdate(id.Trim(), Session.SessionID, "WEB", ip);
                    }
                    else
                    {
                        uss.DomainLoginFails(id.Trim(), ip, DateTime.Now);
                    }
                }
                catch
                {
                    //DB Error
                    retStr = domainUser + "r1";
                    Panel1.Visible = true;
                    Panel1.DataBind();
                    return;
                }

                if (User.Identity.IsAuthenticated && donainpatrs[0].ToUpper() == "AKIJ")
                {

                    SetLogin(id);


                }
                else
                {
                    retStr = "Your are not at AKIJ domain";
                    Panel1.Visible = true;
                    Panel1.DataBind();
                }
            }
            catch (Exception e)
            {
                retStr = domainUser + "r";
                Panel1.Visible = true;
                Panel1.DataBind();
            }
        }
        private void LoginFromWeb(string userID, string password)
        {
            if (!userID.Contains("@akij.net"))
            {
                userID = userID + "@akij.net";
            }
            // Check the domain

            MembershipProvider provider = Membership.Providers["MyADMembershipProvider"];


            if (provider.ValidateUser(userID, password))
            {
                string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ip == string.Empty || ip == null)
                {
                    ip = Request.ServerVariables["REMOTE_ADDR"];
                }

                try
                {
                    UserSecurityService uss = new UserSecurityService();
                    uss.DomainLoginUpdate(userID.Trim(), Session.SessionID, "WEB", ip);
                    SetLogin(userID);
                }
                catch (Exception e)
                {
                    retStr = "You Have No Access at Akij ERP";
                    Panel1.Visible = true;
                    Panel1.DataBind();
                }
            }
            else
            {

                retStr = "Active Directory Authentication Fails.....";
                Panel1.Visible = true;
                Panel1.DataBind();
            }


        }
        private void SetLogin(string id)
        {

            Panel1.Visible = false;
            //Panel1.DataBind();
            int? userID = 0;
            string userCode = "";
            string userName = "";

            int? unitID = 0;
            int? unitID_pf = 0;
            string unitName = "";

            int? deptID = 0;
            string deptName = "";


            int? desigID = 0;
            string desigName = "";

            int? jobStationID = 0;
            string jobStationName = "";

            int? jobTypeID = 0;
            string jobTypeName = "";

            DateTime? appoinmentDate = DateTime.Now;
            string email = "";
            string phone = "";
            string supervisor = "";

            UserInfo ui = new UserInfo();

            // UserInfoTDS.TblUserInfoDataTable table = ui.GetUserInfoByUserCode(id.Trim());
            ui.GetUserInfoByUserCode(id.Trim(),
                                        ref  userID,
                                        ref  userCode,
                                        ref  userName,
                                        ref  unitID,
                                        ref  unitName,
                                        ref  deptID,
                                        ref  deptName,
                                        ref  desigID,
                                        ref  desigName,
                                        ref  jobStationID,
                                        ref  jobStationName,
                                        ref  jobTypeID,
                                        ref  jobTypeName,
                                        ref  appoinmentDate,
                                        ref  email,
                                        ref  phone,
                                        ref  supervisor,
                                        ref  unitID_pf
                                    );

            //Create Session After Login

            Session[SessionParams.USER_ID] = userID.Value.ToString();
            Session[SessionParams.USER_CODE] = userCode;
            Session[SessionParams.USER_NAME] = userName;

            Session[SessionParams.UNIT_ID] = unitID.Value.ToString();
            Session[SessionParams.UNIT_ID_PF] = unitID_pf.Value.ToString();
            Session[SessionParams.UNIT_NAME] = unitName;

            Session[SessionParams.DEPT_ID] = deptID.Value.ToString();
            Session[SessionParams.DEPT_NAME] = deptName;

            Session[SessionParams.DESIG_ID] = desigID.Value.ToString();
            Session[SessionParams.DESIG_NAME] = desigName;


            Session[SessionParams.JOBSTATION_ID] = jobStationID.Value.ToString();
            Session[SessionParams.JOBSTATION_NAME] = jobStationName;

            Session[SessionParams.JOBTYPE_ID] = jobTypeID.Value.ToString();
            Session[SessionParams.JOBTYPE_NAME] = jobTypeName;

            Session[SessionParams.APPOINTMENT_DATE] = appoinmentDate.ToString();
            Session[SessionParams.EMAIL] = id.Trim();
            Session[SessionParams.PHONE] = phone;
            Session[SessionParams.Supervisor] = supervisor;

            string useID = Session[SessionParams.EMAIL].ToString();

            Random rd = new Random();

            Response.Redirect("HomePage.aspx");

        }


    }
}
