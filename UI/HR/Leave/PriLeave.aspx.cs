using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Leave
{
    public partial class PriLeave : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Leave/PriLeave.aspx";
        string stop = "stopping HR/Leave/PriLeave.aspx";

        string alertMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/PriLeave.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    pnlUpperControl.DataBind(); txtEmployeeSearch.Text = HttpContext.Current.Session[SessionParams.USER_NAME].ToString() + "," +
                    HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    hdfEmpCode.Value = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    txtDetails.Text = "[" + HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString() + "][" + HttpContext.Current.Session[SessionParams.JOBTYPE_NAME].ToString() + "][" +
                    HttpContext.Current.Session[SessionParams.DEPT_NAME].ToString() + "][" + HttpContext.Current.Session[SessionParams.DESIG_NAME].ToString() + "]";
                }                   
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
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
                    hdnAppId.Value = data[2].ToString();
                    txtDteFrom.Text = DateTime.Parse(data[3].ToString()).ToString("yyyy-MM-dd");
                    txtDteTo.Text = DateTime.Parse(data[4].ToString()).ToString("yyyy-MM-dd");
                    txtAddress.Text = data[5].ToString();
                    txtReason.Text = data[6].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this application is " + data[0] + " !!!');", true);

                }
            }
        }
        private void ClearControls()
        {
            txtAddress.Text = ""; txtReason.Text = ""; txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); ddlLvType.DataBind();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDelete_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/PriLeave.aspx btnDelete_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();
                    int appid = int.Parse(hdnAppId.Value);
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    alertMessage = appProcessed.DeleteLeaveApplication(hdfEmpCode.Value, appid, actionBy);
                    if (alertMessage != "0")
                    {
                        ClearControls(); dgvApplicationSummary.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to delete this application !!!');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to delete this application !!!');", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnDelete_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/PriLeave.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();
                    string empcode = hdfEmpCode.Value; int ltp = int.Parse(ddlLvType.SelectedValue.ToString());
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
                    TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
                    string reason = txtReason.Text; string address = txtAddress.Text; string phone = hdncontact.Value;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    alertMessage = appProcessed.SubmitLeaveApplication(empcode, ltp, tmstart, tmend, fromdate, todate, reason, address, phone, actionBy);
                    if (alertMessage != "0")
                    {
                        ClearControls(); dgvApplicationSummary.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to submit this application !!!');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit this application !!!');", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }  

    }
}