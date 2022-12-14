using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Leave
{
    public partial class LeaveApplicationPublic : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Leave/LeaveApplicationPublic.aspx";
        string stop = "stopping HR/Leave/LeaveApplicationPublic.aspx";

        string alertMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                txtAddress.Attributes.Add("onkeyUp", "SearchAddressByGoogle();");
                hdnAction.Value = "0";
            }
            else 
            {
                if (hdnAction.Value == "1") { Submit(); }
                else if (hdnAction.Value == "2")
                { UpdateApplication(hdnAppId.Value.ToString()); }
                else if (hdnAction.Value == "3") { DeleteApplication(hdnAppId.Value.ToString()); }
                else
                {
                    if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                    {
                        hdfEmpCode.Value = "";
                        string strSearchKey = txtEmployeeSearch.Text;
                        string[] searchKey = Regex.Split(strSearchKey, ",");
                        hdfEmpCode.Value = searchKey[1];
                        if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                        {
                            FillControls(searchKey[1]);
                            hdfSearchBoxTextChange.Value = "false";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "resetScript", "ResetControls();", true);
                    }
                }
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
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString())
            , int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        private void FillControls(string employeeCode)
        {
            var fd = log.GetFlogDetail(start, location, "FillControls", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx FillControls", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            HR_BLL.Employee.EmployeeRegistration basicinfo = new HR_BLL.Employee.EmployeeRegistration();
            DataTable dtbl = basicinfo.GetEmployeeProfileByEmpCode(employeeCode);
            if (dtbl.Rows.Count > 0)
            {
                txtUnit.Text = dtbl.Rows[0]["strUnit"].ToString();
                txtDept.Text = dtbl.Rows[0]["strDepatrment"].ToString();
                txtDesig.Text = dtbl.Rows[0]["strDesignation"].ToString();
                txtJobStatus.Text = dtbl.Rows[0]["strJobType"].ToString();
                txtContact.Text = dtbl.Rows[0]["strContactNo1"].ToString();
                txtStation.Text = dtbl.Rows[0]["strJobStationName"].ToString();
                ddlLvType.DataBind();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry !!! Employee not found.');", true); }

            fd = log.GetFlogDetail(stop, location, "FillControls", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void Submit()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx Submit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                string empcode = hdfEmpCode.Value;//HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
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

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void UpdateApplication(string appID)
        {
            var fd = log.GetFlogDetail(start, location, "UpdateApplication", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx UpdateApplication", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = hdfEmpCode.Value;
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

            fd = log.GetFlogDetail(stop, location, "UpdateApplication", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void DeleteApplication(string appID)
        {
            var fd = log.GetFlogDetail(start, location, "DeleteApplication", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx DeleteApplication", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (appID != "")
            {
                try
                {
                    HR_BLL.Leave.LeaveApplicationProcess appProcessed = new HR_BLL.Leave.LeaveApplicationProcess();

                    string empcode = hdfEmpCode.Value;
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

            fd = log.GetFlogDetail(stop, location, "DeleteApplication", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public string GetJSFunctionString(object appID, object lvTypeID, object frmDate, object todate, object address, object reason, object status)
        {
            string str = "";
            str = appID.ToString() + ',' + lvTypeID.ToString() + ',' + frmDate.ToString() + ',' + todate.ToString() + ',' + address.ToString() + ',' + reason.ToString() + ',' + status.ToString();
            return str;
        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAction_OnCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Leave/LeaveApplicationPublic.aspx btnAction_OnCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName.Equals("PROCESS"))
            {
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(',');
                if (data[0] == "Pending")
                {
                    ddlLvType.SelectedValue = data[1].ToString();
                    hdnAppId.Value = data[2].ToString();
                    txtDteFrom.Text = DateTime.Parse(data[3].ToString()).ToString("yyyy-MM-dd");
                    txtDteTo.Text = DateTime.Parse(data[4].ToString()).ToString("yyyy-MM-dd");
                    txtAddress.Text = data[5].ToString();
                    txtReason.Text = data[6].ToString();
                    //ddlLvType.SelectedValue = data[1].ToString();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "FilterControls", "UpdateControls('" + data[2] + "','" + data[3] + "','" + data[4] + "','" + data[5] + "','" + data[6] + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this application is " + data[0] + " !!!');", true);

                }
            }

            fd = log.GetFlogDetail(stop, location, "btnAction_OnCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

    }
}