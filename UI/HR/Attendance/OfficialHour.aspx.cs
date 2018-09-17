using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HR_BLL.Global;
using HR_BLL.Attendance;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Attendance
{
    public partial class OfficialHour : BasePage//System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/OfficialHour.aspx";
        string stop = "stopping HR/Attendance/OfficialHour.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/OfficialHour.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtSearchEmp.Attributes.Add("onkeyUp", "SearchText();");
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData//(1396, 12, strSearchKey);
            (int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        private void ClearControls()
        {
            txtSearchEmp.Text = ""; txtReason.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/OfficialHour.aspx btnAdd_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                EmployeeAttendance changeOfficeHour = new EmployeeAttendance();
                string nameCode = txtSearchEmp.Text;
                string[] spltData = nameCode.Split(',');
                string empCode = spltData[1].ToString();
                TimeSpan startTime = TimeSpan.Parse(txtStartTime.Date.ToString("HH:mm:ss"));
                TimeSpan endTime = TimeSpan.Parse(txtEndTime.Date.ToString("HH:mm:ss"));
                string reason = txtReason.Text;
                int softwareLoginUserID = int.Parse(Session[SessionParams.USER_ID].ToString());  //Session["sesUserId"].ToString());

                string msgStatus = changeOfficeHour.InsertEmployeeOfficeHour(empCode, startTime, endTime, reason, softwareLoginUserID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                ClearControls();
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please set all field.');", true); }

            fd = log.GetFlogDetail(stop, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


    }
}