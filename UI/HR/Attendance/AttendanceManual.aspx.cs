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

namespace UI.HR.Attendance
{
    public partial class AttendanceManual : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
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
            
        }












    }
}