using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class Employee_Attendance_with_Overtime_Status : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEmp.Text))
                {
                    //string strSearchKey = txtEmp.Text;
                    //char[] deli = { '[', ']' };
                    //string[] searchKey = strSearchKey.Split(deli);
                    //hdnEnroll.Value = searchKey[3];
                    string strSearchKey = txtEmp.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(hdfEmpCode.Value);
                    if (objDT.Rows.Count > 0)
                    {
                        hdnEnroll.Value = objDT.Rows[0]["intEmployeeID"].ToString();
                    }

                }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Employee_Attendance_with_overtime_status&type=0" + "&enroll=" + hdnEnroll.Value + "&fdate=" + txtFromDate.Text + "&tdate=" + txtToDate.Text + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        //[WebMethod]
        //[ScriptMethod]
        //public static string[] SearchEmployee(string prefixText, int count)
        //{

        //    //AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        //    //int Active = int.Parse(1.ToString());
        //    //return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText.ToLower());

        //}

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
    }
}