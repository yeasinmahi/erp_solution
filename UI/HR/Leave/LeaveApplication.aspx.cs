using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Leave
{
    public partial class LeaveApplication : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Leave/LeaveApplication.aspx";
        string stop = "stopping HR/Leave/LeaveApplication.aspx";

        string alertMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplication.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtAddress.Attributes.Add("onkeyUp", "SearchAddressByGoogle();");
                hdnAction.Value = "0";
                hdnAppId.Value = "";
            }
            else
            { 
                if (hdnAction.Value == "1") { Submit(); }
                else if (hdnAction.Value == "2") 
                { UpdateApplication(hdnAppId.Value.ToString()); }
                else if (hdnAction.Value == "3") { DeleteApplication(hdnAppId.Value.ToString()); }
                else { /*Nothing To Do*/}
            }

            string employeeCode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
            if (!String.IsNullOrEmpty(employeeCode)) { FillControls(employeeCode); }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void FillControls(string employeeCode)
        {
            var fd = log.GetFlogDetail(start, location, "FillControls", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplication.aspx FillControls", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            HR_BLL.Employee.EmployeeRegistration basicinfo = new HR_BLL.Employee.EmployeeRegistration();
            DataTable dtbl = basicinfo.GetEmployeeProfileByEmpCode(employeeCode);
            if (dtbl.Rows.Count > 0)
            {
                txtEmployeeName.Text = dtbl.Rows[0]["strEmployeeName"].ToString();
                txtUnit.Text = dtbl.Rows[0]["strUnit"].ToString();
                txtDept.Text = dtbl.Rows[0]["strDepatrment"].ToString();
                txtDesig.Text = dtbl.Rows[0]["strDesignation"].ToString();
                txtJobStatus.Text = dtbl.Rows[0]["strJobType"].ToString();
                txtContact.Text = dtbl.Rows[0]["strContactNo1"].ToString();
                txtStation.Text = dtbl.Rows[0]["strJobStationName"].ToString();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry !!! Employee not found.');", true); }

            fd = log.GetFlogDetail(stop, location, "FillControls", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void Submit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplication.aspx Submit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                int leavetype = int.Parse(ddlLvType.SelectedValue); DateTime appdate = DateTime.Now;
                DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                string reason = txtReason.Text; string address = txtAddress.Text; string phone = txtContact.Text;
                int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (fromdate <= todate)
                {
                    alertMessage = appProcessed.SubmitLeaveApplication(empcode, leavetype, appdate, fromdate, todate, reason, address, phone, actionBy);
                    if (alertMessage != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to submit this application !!!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to from-date is greater than to-date !!!');", true);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
                throw ex;
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        
        public void UpdateApplication(string appID)
        {
            var fd = log.GetFlogDetail(start, location, "UpdateApplication", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplication.aspx UpdateApplication", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    int leavetype = int.Parse(ddlLvType.SelectedValue); DateTime appdate = DateTime.Now;
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    string reason = txtReason.Text; string address = txtAddress.Text; string phone = txtContact.Text;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    if (fromdate <= todate)
                    {
                        alertMessage = appProcessed.UpdateLeaveApplication(empcode, int.Parse(appID), leavetype, appdate, fromdate, todate, reason, address, actionBy);
                        if (alertMessage != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                            dgvApplicationSummary.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to update this application !!!');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to from-date is greater than to-date !!!');", true);
                    }

                }
                catch (Exception ex) { throw ex; }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a pending application.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "UpdateApplication", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void DeleteApplication(string appID)
        {
            var fd = log.GetFlogDetail(start, location, "DeleteApplication", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplication.aspx DeleteApplication", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    alertMessage = appProcessed.DeleteLeaveApplication(empcode, int.Parse(appID), actionBy);
                    if (alertMessage != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to delete this application !!!');", true);
                    }
                }
                catch (Exception ex) { throw ex; } 
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a pending application.');", true); }

            fd = log.GetFlogDetail(stop, location, "DeleteApplication", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public string GetJSFunctionString(object appID, object lvTypeID, object frmDate, object todate, object address, object reason, object status)
        {
            string str = "";
            str = appID.ToString() + ',' + lvTypeID.ToString() + ',' + frmDate.ToString() + ',' + todate.ToString() + ',' + address.ToString() + ',' + reason.ToString() + ',' + status.ToString();
            return str;
        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("PROCESS"))
            {
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(',');
                if (data[0] == "Pending")
                {
                    ddlLvType.SelectedValue = data[1].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FilterControls", "UpdateControls('" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "','" + data[6] + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this application is " + data[0] + " !!!');", true);

                }
            }
        }

    }
}