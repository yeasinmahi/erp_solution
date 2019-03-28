﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using HR_BLL.Employee;

namespace UI.HR.Leave
{
    public partial class LeaveApproved : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Leave/LeaveApproved.aspx";
        string stop = "stopping HR/Leave/LeaveApproved.aspx";
        public static EmployeeBasicInfo bll = new EmployeeBasicInfo();
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

        public void LoadReport(string enroll,string lvTypeID)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/HR/Employee_Leave_Status" + "&enroll="+ enroll + "&leaveType=" +lvTypeID + "&rc:LinkTarget=_self";
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
            LoadIFrame(frame.ClientID, url);
        }
        public void Submit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApproved.aspx Submit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

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

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
      
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            SetVisibilityModal(true);

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string code = Convert.ToString((row.FindControl("lblCode") as Label).Text); 
            string LeaveTypeID = Convert.ToString((row.FindControl("lblLeaveTypeID") as Label).Text);
            string enroll = bll.Get_EmpID_By_EmpCode(code);
            LoadReport(enroll, LeaveTypeID);

            string appID = Convert.ToString((row.FindControl("lblintApplicationId") as Label).Text);
            string empName = Convert.ToString((row.FindControl("lblName") as Label).Text);
            string frmDate = Convert.ToString((row.FindControl("lblFromDate") as Label).Text);
            string todate = Convert.ToString((row.FindControl("lblToDate") as Label).Text);
            string totaldys = Convert.ToString((row.FindControl("lblTotalday") as Label).Text);
            string lvType = Convert.ToString((row.FindControl("lblLeaveType") as Label).Text);
            string empJobType = Convert.ToString((row.FindControl("lblstrJobType") as Label).Text);
            string remainingDays = Convert.ToString((row.FindControl("lblintRemainingDays") as Label).Text);


            txtCode.Text = code;
            txtEmployeeName.Text = empName;
            txtDteFrom.Text = frmDate;
            txtDteTo.Text = todate;
            txtJobStatus.Text = empJobType;
            txtRemainingDays.Text = remainingDays;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "app", "ShowApprovedDiv('" + appID + "','" + code + "','" + empName + "','" + frmDate + "','" + todate + "','" + LeaveTypeID + "','" + lvType + "','" + totaldys + "','" + empJobType + "','" + remainingDays + "' )", true);
            
        }
    }
}