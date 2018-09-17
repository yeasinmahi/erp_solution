using HR_BLL.Attendance;
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

namespace UI.HR.Attendance
{
    public partial class RealtimeAttendance : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/RealtimeAttendance.aspx";
        string stop = "stopping HR/Attendance/RealtimeAttendance.aspx";

        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <02-09-2013>
        Description: <View Realtime Attendance>
        =============================================*/
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/RealtimeAttendance.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            { pnlUpperControl.DataBind();}
            else
            {         }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/RealtimeAttendance.aspx Show_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            DataTable dtbl = new DataTable();
            EmployeeAttendance objAttendance = new EmployeeAttendance();
            int unit = int.Parse(ddlUnit.SelectedValue.ToString());
            int station = int.Parse(ddlJobStation.SelectedValue.ToString());
            int shift = int.Parse(ddlPresentShift.SelectedValue.ToString());
            DateTime showdate = DateTime.Parse(txtDate.Text);
            string showtype = ddlType.SelectedValue.ToString();

            //dtbl = objAttendance.GetRealtimeAttendance(unit, station, shift, showdate, showtype);
            //dgvRealtimeSummary.DataSource = dtbl; 

            fd = log.GetFlogDetail(stop, location, "Show_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


    }
}