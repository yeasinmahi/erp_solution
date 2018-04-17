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

namespace UI.HR.Attendance
{
    public partial class OfficialHour : BasePage//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtSearchEmp.Attributes.Add("onkeyUp", "SearchText();");
            }
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

        }


    }
}