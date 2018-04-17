using HR_BLL.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Attendance
{
    public partial class HourChange : BasePage //System.Web.UI.Page //
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <10-01-2013>
        Description: <Official Hour Change>
        =============================================*/

        string alertMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   pnlUpperControl.DataBind(); hdnAction.Value = "0";  }
            else
            {   if (hdnAction.Value == "1") { Submit(); }
                else if (hdnAction.Value == "2") { ClearControls(); }
                else { }
            }
        }

        private void Submit()
        {
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