using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GLOBAL_BLL;
using HR_BLL.Attendance;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Reports
{
    public partial class Absent : System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Reports/Absent.aspx";
        string stop = "stopping HR/Reports/Absent.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnLoginUserID.Value = Session[SessionParams.USER_ID].ToString();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        public string GetJSFunctionString(string  empID,string empCode,string empName)
        {
            return "ShowReasonDiv('"+empID+"','"+empCode+"','"+empName+"' )";
        }

        protected void btnMakePresent_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnMakePresent_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Reports/Absent.aspx btnMakePresent_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            int empIDforpresent = int.Parse(hdnEmpIDForPresent.Value);
            DateTime? dteForpresent = DateFormat.GetDateAtSQLDateFormat(txtDate.Text);
            int loginUserID = int.Parse("" + Session[SessionParams.USER_ID]);
            string reason = ddlAbsentReason.SelectedValue;

            EmployeeAttendance attendance = new EmployeeAttendance();

            string respose = attendance.InsertAttendanceManual(empIDforpresent, dteForpresent, reason, loginUserID);

            GridView1.DataBind();

            fd = log.GetFlogDetail(stop, location, "btnMakePresent_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}