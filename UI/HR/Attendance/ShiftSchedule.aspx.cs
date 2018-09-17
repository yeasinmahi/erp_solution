using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Attendance;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.Attendance
{
    public partial class ShiftSchedule : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/ShiftSchedule.aspx";
        string stop = "stopping HR/Attendance/ShiftSchedule.aspx";

        string msg = ""; int onOff;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/ShiftSchedule.aspx btnSave_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            EmployeesJobStation sftStatus = new EmployeesJobStation();

            int unitId = int.Parse(ddlUnit.SelectedValue.ToString());
            int jobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            int shiftID = int.Parse(ddlPresentShift.SelectedValue.ToString());
            DateTime frmDate = DateTime.Parse(txtFromDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);
            if (rdoOpen.Checked == true)
            { onOff = 1; }
            if (rdoClose.Checked == true)
            { onOff = 0; }
            int userID = int.Parse(Session[SessionParams.USER_ID].ToString());
            msg = sftStatus.InsertShiftStatus(unitId, jobStationID, shiftID, frmDate, toDate, onOff, userID);
            ClearControls();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

            fd = log.GetFlogDetail(stop, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void ClearControls()
        {
            ddlUnit.DataBind(); ddlPresentShift.DataBind();
            ddlJobStation.DataBind();
        }
    }
}