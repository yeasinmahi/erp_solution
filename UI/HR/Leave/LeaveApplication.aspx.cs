using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Leave
{
    public partial class LeaveApplication : BasePage
    {
        string alertMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtAddress.Attributes.Add("onkeyUp", "SearchAddressByGoogle();");
                hdnAction.Value = "0";
                hdnAppId.Value = "";
            }
            else
            { 
                if (hdnAction.Value == "1") { Submit(); }
                else if (hdnAction.Value == "2") 
                { UpdateApplication(hdnAppId.Value.ToString()); }
                else if (hdnAction.Value == "3") { DeleteApplication(hdnAppId.Value.ToString()); }
                else { /*Nothing To Do*/}
            }

            string employeeCode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
            if (!String.IsNullOrEmpty(employeeCode)) { FillControls(employeeCode); }
        }

        private void FillControls(string employeeCode)
        {
            HR_BLL.Employee.EmployeeRegistration basicinfo = new HR_BLL.Employee.EmployeeRegistration();
            DataTable dtbl = basicinfo.GetEmployeeProfileByEmpCode(employeeCode);
            if (dtbl.Rows.Count > 0)
            {
                txtEmployeeName.Text = dtbl.Rows[0]["strEmployeeName"].ToString();
                txtUnit.Text = dtbl.Rows[0]["strUnit"].ToString();
                txtDept.Text = dtbl.Rows[0]["strDepatrment"].ToString();
                txtDesig.Text = dtbl.Rows[0]["strDesignation"].ToString();
                txtJobStatus.Text = dtbl.Rows[0]["strJobType"].ToString();
                txtContact.Text = dtbl.Rows[0]["strContactNo1"].ToString();
                txtStation.Text = dtbl.Rows[0]["strJobStationName"].ToString();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry !!! Employee not found.');", true); }

        }

        private void Submit()
        {
            try
            {
                HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                int leavetype = int.Parse(ddlLvType.SelectedValue); DateTime appdate = DateTime.Now;
                DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                string reason = txtReason.Text; string address = txtAddress.Text; string phone = txtContact.Text;
                int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (fromdate <= todate)
                {
                    alertMessage = appProcessed.SubmitLeaveApplication(empcode, leavetype, appdate, fromdate, todate, reason, address, phone, actionBy);
                    if (alertMessage != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to submit this application !!!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to from-date is greater than to-date !!!');", true);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        
        public void UpdateApplication(string appID)
        {
            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    int leavetype = int.Parse(ddlLvType.SelectedValue); DateTime appdate = DateTime.Now;
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    string reason = txtReason.Text; string address = txtAddress.Text; string phone = txtContact.Text;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    if (fromdate <= todate)
                    {
                        alertMessage = appProcessed.UpdateLeaveApplication(empcode, int.Parse(appID), leavetype, appdate, fromdate, todate, reason, address, actionBy);
                        if (alertMessage != "0")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                            dgvApplicationSummary.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to update this application !!!');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to from-date is greater than to-date !!!');", true);
                    }

                }
                catch (Exception ex) { throw ex; }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a pending application.');", true);
            }
        }

        public void DeleteApplication(string appID)
        {
            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    alertMessage = appProcessed.DeleteLeaveApplication(empcode, int.Parse(appID), actionBy);
                    if (alertMessage != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                        dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to delete this application !!!');", true);
                    }
                }
                catch (Exception ex) { throw ex; } 
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a pending application.');", true); }
        }

        public string GetJSFunctionString(object appID, object lvTypeID, object frmDate, object todate, object address, object reason, object status)
        {
            string str = "";
            str = appID.ToString() + ',' + lvTypeID.ToString() + ',' + frmDate.ToString() + ',' + todate.ToString() + ',' + address.ToString() + ',' + reason.ToString() + ',' + status.ToString();
            return str;
        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("PROCESS"))
            {
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(',');
                if (data[0] == "Pending")
                {
                    ddlLvType.SelectedValue = data[1].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FilterControls", "UpdateControls('" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "','" + data[6] + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this application is " + data[0] + " !!!');", true);

                }
            }
        }

    }
}