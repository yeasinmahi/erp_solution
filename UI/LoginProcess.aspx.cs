using System;
using System.Web.Security;
using UserSecurity;
using HR_BLL.User;
using UI.ClassFiles;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI
{
    public partial class LoginProcess : System.Web.UI.Page
    {
        public string RetStr = null;
        public string ReturnUrl = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack && Request.Form.Count >= 2)
            {*/
             ReturnUrl = Request.QueryString["returnUrl"];
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
            if (Request.LogonUserIdentity != null)
            {
                string domainUser = Request.LogonUserIdentity.Name;
                try
                {
             
                    string[] donainpatrs = domainUser.Split('\\');
                     var id = donainpatrs[1] + "@akij.net";


                    // var id = "test@akij.net";


                    string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
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
                    catch (Exception ex)
                    {
                        //DB Error
                        RetStr = domainUser + " Error: " + ex.Message;
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
                        RetStr = "Your are not at AKIJ domain";
                        Panel1.Visible = true;
                        Panel1.DataBind();
                    }
                }
                catch (Exception e)
                {
                    RetStr = domainUser + "r";
                    Panel1.Visible = true;
                    Panel1.DataBind();
                }
            }
        }

        private void LoginFromWeb(string userId, string password)
        {
            if (!userId.Contains("@akij.net"))
            {
                userId = userId + "@akij.net";
            }

            // Check the domain

            MembershipProvider provider = Membership.Providers["MyADMembershipProvider"];

            if (provider != null && provider.ValidateUser(userId, password))
            {
                string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                {
                    ip = Request.ServerVariables["REMOTE_ADDR"];
                }

                try
                {
                    UserSecurityService uss = new UserSecurityService();
                    uss.DomainLoginUpdate(userId.Trim(), Session.SessionID, "WEB", ip);
                    SetLogin(userId);
                }
                catch (Exception e)
                {
                    RetStr = "You Have No Access at Akij ERP";
                    Panel1.Visible = true;
                    Panel1.DataBind();
                }
            }
            else
            {
                RetStr = "Active Directory Authentication Fails.....";
                Panel1.Visible = true;
                Panel1.DataBind();
            }
        }

        private void SetLogin(string id)
        {
            Panel1.Visible = false;
            //Panel1.DataBind();
            int? userId = 0;
            string userCode = "";
            string userName = "";

            int? unitId = 0;
            int? unitIdPf = 0;
            string unitName = "";

            int? deptId = 0;
            string deptName = "";

            int? desigId = 0;
            string desigName = "";

            int? jobStationId = 0;
            string jobStationName = "";

            int? jobTypeId = 0;
            string jobTypeName = "";

            DateTime? appoinmentDate = DateTime.Now;
            string email = "";
            string phone = "";
            string supervisor = "";

            UserInfo ui = new UserInfo();

            // UserInfoTDS.TblUserInfoDataTable table = ui.GetUserInfoByUserCode(id.Trim());
            ui.GetUserInfoByUserCode(id.Trim(),
                                        ref userId,
                                        ref userCode,
                                        ref userName,
                                        ref unitId,
                                        ref unitName,
                                        ref deptId,
                                        ref deptName,
                                        ref desigId,
                                        ref desigName,
                                        ref jobStationId,
                                        ref jobStationName,
                                        ref jobTypeId,
                                        ref jobTypeName,
                                        ref appoinmentDate,
                                        ref email,
                                        ref phone,
                                        ref supervisor,
                                        ref unitIdPf
                                    );

            //Create Session After Login

            Session[SessionParams.USER_ID] = userId?.ToString();
            Session[SessionParams.USER_CODE] = userCode;
            Session[SessionParams.USER_NAME] = userName;

            Session[SessionParams.UNIT_ID] = unitId?.ToString();
            Session[SessionParams.UNIT_ID_PF] = unitIdPf?.ToString();
            Session[SessionParams.UNIT_NAME] = unitName;

            Session[SessionParams.DEPT_ID] = deptId?.ToString();
            Session[SessionParams.DEPT_NAME] = deptName;

            Session[SessionParams.DESIG_ID] = desigId?.ToString();
            Session[SessionParams.DESIG_NAME] = desigName;

            Session[SessionParams.JOBSTATION_ID] = jobStationId?.ToString();
            Session[SessionParams.JOBSTATION_NAME] = jobStationName;

            Session[SessionParams.JOBTYPE_ID] = jobTypeId?.ToString();
            Session[SessionParams.JOBTYPE_NAME] = jobTypeName;

            Session[SessionParams.APPOINTMENT_DATE] = appoinmentDate.ToString();
            Session[SessionParams.EMAIL] = id.Trim();
            Session[SessionParams.PHONE] = phone;
            Session[SessionParams.Supervisor] = supervisor;

            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect(ReturnUrl);
            }
            // string useID = Session[SessionParams.EMAIL].ToString();

            // Random rd = new Random();

            // Response.Redirect("HomePage.aspx");
        }
    }
}