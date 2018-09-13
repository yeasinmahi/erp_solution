using HR_BLL.Attendance;
using HR_BLL.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.Attendance
{
    public partial class AttendanceManual : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/AttendanceManual.aspx";
        string stop = "stopping HR/Attendance/AttendanceManual.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceManual.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);


            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtEffectiveDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdnsearch.Value = searchKey[1];
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(hdnsearch.Value);
                    if (objDT.Rows.Count > 0)
                    {
                        txtJobtype.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                    }
                }
            }
            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceManual.aspx btnSave_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                DateTime effectivedate = DateTime.Parse(txtEffectiveDate.Text);
                int userID = int.Parse(Session[SessionParams.USER_ID].ToString());
                EmployeeAttendance att = new EmployeeAttendance();
                string msg = att.InsertACLManualAttendance(effectivedate, userID, hdnsearch.Value);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                txtEffectiveDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtFullName.Text = "";
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

            fd = log.GetFlogDetail(stop, location, "btnSave_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }












    }
}