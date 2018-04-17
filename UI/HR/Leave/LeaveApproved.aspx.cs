using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Leave
{
    public partial class LeaveApproved : BasePage
    {

        string alertMessage = ""; int payStatus; string applicationStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAction.Value = "0";
            }
            else
            { if (hdnAction.Value != "0") { Submit(); } }
        }

        protected void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlist.SelectedValue == "0")
            {
                dgvUPLeaveApplication.Columns[5].Visible = true;
            }
            else
            {
                dgvUPLeaveApplication.Columns[5].Visible = false;
            }
        }

        public string GetJSFunctionString(string appID, string empCode, string empName, string frmDate, string todate, string lvTypeID, string lvType, string totaldys, string empJobType, string remainingDays)
        {
            return "ShowApprovedDiv('" + appID + "','" + empCode + "','" + empName + "','" + frmDate + "','" + todate + "','" + lvTypeID + "','" + lvType + "','" + totaldys + "','" + empJobType + "','" + remainingDays + "' )";
        }

        public void Submit()
        {
            try
            {
                HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();
                
                int applicationId = int.Parse(hdnAppID.Value);
                DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                if (hdnApproved.Value == "Y") { applicationStatus = "Y"; }  else { applicationStatus = "R"; }
                int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (rdoWithpay.Checked == true) { payStatus = 1; } else { payStatus = 0; } //With pay(1) --- Without pay(0) 
                if (fromdate <= todate)
                {
                    alertMessage = appProcessed.LeaveApplicationProcessed(applicationId, fromdate, todate, payStatus, applicationStatus, actionBy);
                    if (alertMessage != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "HideReasonDiv();", true);
                        dgvUPLeaveApplication.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to process this application !!!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to from-date is greater than to-date !!!');", true);
                }
            }
            catch (Exception ex) { throw ex; }

        }

    }
}