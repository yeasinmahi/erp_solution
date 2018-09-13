using HR_BLL.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Attendance
{
    public partial class HourChange : BasePage //System.Web.UI.Page //
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/HourChange.aspx";
        string stop = "stopping HR/Attendance/HourChange.aspx";
        
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <10-01-2013>
        Description: <Official Hour Change>
        =============================================*/

        string alertMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/HourChange.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {   pnlUpperControl.DataBind(); hdnAction.Value = "0";  }
            else
            {   if (hdnAction.Value == "1") { Submit(); }
                else if (hdnAction.Value == "2") { ClearControls(); }
                else { }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void Submit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/HourChange.aspx Submit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                int stationid = int.Parse(ddlJobStation.SelectedValue);
                int teamID = int.Parse(ddlShiftStatus.SelectedValue.ToString());
                int shiftId = int.Parse(ddlPresentShift.SelectedValue.ToString());
                DateTime fromDate = DateTime.Parse(txtFromDate.Text);
                DateTime toDate = DateTime.Parse(txtToDate.Text);
                TimeSpan startTime = TimeSpan.Parse(tpkStart.Date.ToString("HH:mm:ss"));
                TimeSpan endTime = TimeSpan.Parse(tpkEnd.Date.ToString("HH:mm:ss"));
                string reason = txtReason.Text;
                int loginUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                EmployeeAttendance changeOfficeHour = new EmployeeAttendance();
                alertMessage = changeOfficeHour.InsertOfficeHourChange(reason, fromDate, toDate, startTime, endTime, stationid, shiftId, loginUserID);

                if (alertMessage != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                    ClearControls();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to register this employee !!!');", true);
                }
            }
            catch (Exception ex) { throw ex; }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlJobStation.DataBind(); ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
        }

        public void ClearControls()
        {
            txtReason.Text = ""; ddlUnit.DataBind(); ddlJobStation.DataBind(); ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
            txtFromDate.Text = ""; txtToDate.Text = ""; hdnAction.Value = "0";
        }
    }
}