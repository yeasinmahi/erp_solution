using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Attendance
{
    public partial class AttendanceDetails : BasePage
    {
        string strdate = "";
        
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/AttendanceDetails.aspx";
        string stop = "stopping HR/Attendance/AttendanceDetails.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Loan Event", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceDetails.aspx Load Event", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind(); //btnMonthly.Enabled = false;
                    txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                    {
                        string strSearchKey = txtEmployeeSearch.Text;
                        string[] searchKey = Regex.Split(strSearchKey, ",");
                        hdfEmpCode.Value = searchKey[1];
                        EmployeeRegistration objGetProfile = new EmployeeRegistration();
                        DataTable objDT = new DataTable();
                        objDT = objGetProfile.GetEmployeeProfileByEmpCode(hdfEmpCode.Value);
                        if (objDT.Rows.Count > 0)
                        {
                            hdnempid.Value = objDT.Rows[0]["intEmployeeID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Load Event", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Load Event", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        //public string ViewPunchDetails(object intEmployeeId, object AttendanceDate, object Vewtype)
        //{ return "ViewPunchDetails('" + intEmployeeId.ToString() + "','" + AttendanceDate.ToString() + "','" + Vewtype.ToString() + "')"; }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Attendance_Report&type=0" + "&empCode=" + hdfEmpCode.Value + "&fdate=" + txtFromDate.Text + "&tdate=" + txtToDate.Text + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

            #region====previous Code============
            //var fd = log.GetFlogDetail(start, location, "Loan Event", null);
            //Flogger.WriteDiagnostic(fd);

            //// starting performance tracker
            //var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceDetails.aspx btnSubmit_Click", "", fd.UserName, fd.Location,
            //fd.Product, fd.Layer);

            //if (hdnconfirm.Value == "1")
            //{
            //    try
            //    {
            //        HR_BLL.Attendance.EmployeeAttendance punchdetails = new HR_BLL.Attendance.EmployeeAttendance();
            //        string empcode = hdfEmpCode.Value; int monthid = int.Parse(ddlMonth.SelectedValue.ToString());
            //        int yearid = DateTime.Now.Year;
            //        DataTable objDT = new DataTable();
            //        objDT = punchdetails.GetAttendanceDetails(hdfEmpCode.Value, null, monthid, yearid);
            //        if (objDT.Rows.Count > 0)
            //        {
            //            dgvattendancedetails.DataSource = objDT;
            //            dgvattendancedetails.DataBind();
            //            btnMonthly.Enabled = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        var efd = log.GetFlogDetail(stop, location, "btnSubmit_Click", ex);
            //        Flogger.WriteError(efd);
            //    }
            #endregion=============end ========================
        }

        //fd = log.GetFlogDetail(stop, location, "btnSubmit_Click", null);
        //    Flogger.WriteDiagnostic(fd);
        //    // ends
        //    tracker.Stop();
        //}

        //protected void btnMonthly_Click(object sender, EventArgs e)
        //{
        //    var fd = log.GetFlogDetail(start, location, "Loan Event", null);
        //    Flogger.WriteDiagnostic(fd);

        //    // starting performance tracker
        //    var tracker = new PerfTracker("Performance on HR/Attendance/AttendanceDetails.aspx btnMonthly_Click", "", fd.UserName, fd.Location,
        //    fd.Product, fd.Layer);

        //    if (ddlMonth.SelectedValue.ToString().Length > 1)
        //    {
        //        strdate = (DateTime.Now.Year).ToString() + "-" + ddlMonth.SelectedValue.ToString() + "-" + "01";
        //    }
        //    else
        //    {
        //        strdate = (DateTime.Now.Year).ToString() + "-0" + ddlMonth.SelectedValue.ToString() + "-" + "01";
        //    }
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "h", "ViewPunchDetails('" + hdnempid.Value + "','" + strdate.ToString() + "','');", true);

        //    fd = log.GetFlogDetail(stop, location, "btnMonthly_Click", null);
        //    Flogger.WriteDiagnostic(fd);
        //    // ends
        //    tracker.Stop();
        //}


    }
}