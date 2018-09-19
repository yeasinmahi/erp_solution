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
    public partial class OfficialHourChange : BasePage  //System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Attendance/OfficialHourChange.aspx";
        string stop = "stopping HR/Attendance/OfficialHourChange.aspx";

        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <10-01-2013>
        Description: <Official Hour Change>
        =============================================*/

        string alertMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnAction.Value = "0";
            }
            else {
                    Submit_Click(); 
            }
        }



        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static List<string> Getdata(string prefixText, int count, string contextKey)
        {
            //Make your database connection here
            //string strSQL = "SELECT * FROM YourTable WHERE coloumnName Like '" + prefixText + "%'";
            ////Get data in datatable 

            List<String> list = new List<String>();
            //foreach (DataRow dr in dataTable.Rows)
            //{
            //    list.Add(dr["coloumnName "].ToString());
            //}
            return list;

            /*
             AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
             */


        }





        
        private void Submit_Click()
        {
            var fd = log.GetFlogDetail(start, location, "Submit_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/OfficialHourChange.aspx Submit_Click", "", fd.UserName, fd.Location,
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

            fd = log.GetFlogDetail(stop, location, "Submit_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Attendance/OfficialHourChange.aspx btnCancel_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                ClearControls();
            }
            catch (Exception ex)
            { throw ex; }

            fd = log.GetFlogDetail(stop, location, "btnCancel_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void ClearControls()
        {
            txtReason.Text = ""; ddlUnit.DataBind(); ddlJobStation.DataBind(); ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
            txtFromDate.Text = ""; txtToDate.Text = ""; hdnAction.Value = "0";
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlJobStation.DataBind(); ddlShiftStatus.DataBind(); ddlPresentShift.DataBind();
        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlShiftStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}