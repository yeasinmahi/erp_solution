using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Attendance
{
    public partial class AttendanceDetailsView : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/AttendanceDetailsView.aspx";
        string stop = "stopping HR/Attendance/AttendanceDetailsView.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceDetailsView.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            string innerTableHtml = ""; StringBuilder strrows = new StringBuilder();
            DataTable objDT = new DataTable();
            DataTable objinfo = new DataTable();
            HR_BLL.Attendance.EmployeeAttendance objatt = new HR_BLL.Attendance.EmployeeAttendance();
            string enroll = Request.QueryString["ENROLL"];
            string _date = Request.QueryString["ATTDATE"];
            string viewtype = Request.QueryString["VTP"];

            #region ------------- Preview Punch Details ------------------
            if (enroll != null && viewtype == "daily")
            {
                objDT = objatt.GetDailyPunchDetails(int.Parse(enroll), _date);
            }
            else if (enroll != null && (viewtype == "" || viewtype == null))
            {
                objDT = objatt.GetMonthlyPunchDetails(int.Parse(enroll), _date);
            }
            if (objDT.Rows.Count > 0)
            {
                #region ----------- Set Data ------------

                objinfo = objatt.EmployeeInformation(int.Parse(enroll));
                string name = objinfo.Rows[0]["strEmployeeName"].ToString().ToUpper();
                string unit = objinfo.Rows[0]["strUnit"].ToString().ToUpper();
                string station = objinfo.Rows[0]["strJobStationName"].ToString().ToUpper();
                string department = objinfo.Rows[0]["strDepatrment"].ToString().ToUpper();
                string designation = objinfo.Rows[0]["strDesignation"].ToString().ToUpper();
                string jobtype = objinfo.Rows[0]["strJobTypeShort"].ToString().ToUpper();

                innerTableHtml = @" <table border='0' style = 'width:340px; '>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Employee :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + name + @"</td></tr>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Unit :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + unit + @"</td></tr>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Station :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + station + @"</td></tr>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Department :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + department + @"</td></tr>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Designation :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + designation + @"</td></tr>
                    <tr><td style='text-align: right; width:100px; font-size: 10px; font-weight: bold;'>Job-Type :</td>
                    <td colspan='2' style='text-align: left; font-size: 10px; font-weight: bold;'>"; innerTableHtml = innerTableHtml + jobtype + @"</td></tr>                    
                    <tr><td colspan='3'><hr /></td></tr></table>";

                strrows.Append("<table border='1'><tr style=\"text-align:left\"><td style=\"width:100px\"><b>Punch Date</b></td><td style=\"width:100px\"><b>Punch Time</b></td><td style=\"width:100px\"><b>Status</b></td></tr>");
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    strrows.Append("<tr style=\"text-align:left\font-size:10px\font-weight:normal\"><td>" + DateTime.Parse(objDT.Rows[i]["dteAttendanceDate"].ToString()).ToString("yyyy-MM-dd") + "</td><td>" + objDT.Rows[i]["dteAttendanceTime"].ToString() + "</td><td>" + objDT.Rows[i]["strRemark"].ToString() + "</td></tr>");
                }
                strrows.Append("</table>");
                innerTableHtml = innerTableHtml + strrows.ToString();
                #endregion

                #region ------------ Filter Div By InnerHTML ---------------
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                createDiv.ID = "createDiv";
                createDiv.InnerHtml = innerTableHtml;
                createDiv.Attributes.Add("class", "attendancedetails");
                this.Controls.Add(createDiv);
                #endregion
            }
            #endregion

            else { }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }
    }
}