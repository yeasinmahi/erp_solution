using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Internal;
using System.Web.Services;
using UI.ClassFiles;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
namespace UI.HR.Internal
{
    public partial class UserApproval : BasePage
    {
        internaltranfer objuser = new internaltranfer();
        DataTable requestview = new DataTable();
        DataTable status= new DataTable();
        int intPart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string subject = "0".ToString();
                string description = "0".ToString();
                Int32 empto = Int32.Parse("0".ToString());
                 string path ="0".ToString();
                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    intPart = 2;
                    requestview = objuser.Requestview(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                    dgvViewRequest.DataSource = requestview;
                    dgvViewRequest.DataBind();
                    //intPart = 12;
                    pnlUpperControl.DataBind();
                    status = new DataTable();
                    intPart = 17;
                    status = objuser.Statusview(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                    dgvStatus.DataSource = status;
                    dgvStatus.DataBind();
                    status = new DataTable();
                    intPart = 18;
                    status = objuser.StatusCCview(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                    dgvCC.DataSource = status;
                    dgvCC.DataBind();

            }
        }

        protected void BtnDetalis_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('InternalApprovalDetalis.aspx');", true);

                }
                catch { }
            }
        }

        protected void BtnDetalisView_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrations('UserDetalisview.aspx');", true);

                }
                catch { }
            }
        }

        protected void BtnCCView_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrations('UserDetalisview.aspx');", true);

                }
                catch { }
            }
        }


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber2 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intID"] = ordernumber2;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrationapprove('ApprovalPopUp.aspx');", true);

            }
            catch { }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber3 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intID"] = ordernumber3;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrationreject('RejectPopUp.aspx');", true);

            }
            catch { }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber4 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intID"] = ordernumber4;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrationclose('ClosePopUp.aspx');", true);

            }
            catch { }
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber5 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intID"] = ordernumber5;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registrationforward('ForwardPopUp.aspx');", true);

            }
            catch { }
        }
    }
}