using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.HR.Attendance
{
    public partial class RealTimeAttendanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Real_Time_Attendance_Report&intunitid="+ddlUnit.SelectedItem.Value+"&intstationid=" + ddlJobStation.SelectedItem.Value + "&intshiftid="+ ddlPresentShift.SelectedItem.Value + "&date=" + txtDate.Text + "&strtype=" + ddlType.SelectedItem.Value + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }
    }
}