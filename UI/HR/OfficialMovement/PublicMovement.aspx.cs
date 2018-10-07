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

namespace UI.HR.OfficialMovement
{
    public partial class PublicMovement1 : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/OfficialMovement/PublicMovement.aspx";
        string stop = "stopping HR/OfficialMovement/PublicMovement.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PublicMovement.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                    {
                        string strSearchKey = txtEmployeeSearch.Text;
                        string[] searchKey = Regex.Split(strSearchKey, ",");
                        hdfEmpCode.Value = searchKey[1];
                        if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                        {
                            LoadFieldValue(searchKey[1]);
                            hdfSearchBoxTextChange.Value = "false";
                        }
                    }
                    else
                    {
                        ClearControls();
                    }
                }                
            }
            catch { }

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
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        private void LoadFieldValue(string empCode)
        {
            var fd = log.GetFlogDetail(start, location, "LoadFieldValue", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PublicMovement.aspx LoadFieldValue", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        txtJobStatus.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                        txtStation.Text = objDT.Rows[0]["strJobStationName"].ToString();
                        txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            fd = log.GetFlogDetail(stop, location, "LoadFieldValue", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void ClearControls()
        {
            //txtEmployeeSearch.Text = ""; txtJobStatus.Text = ""; txtUnit.Text = ""; txtStation.Text = "";
            //txtDepartment.Text = ""; txtDesignation.Text = ""; 
            txtAddress.Text = ""; txtDescription.Text = ""; txtDteFrom.Text = ""; txtDteTo.Text = "";
        }

        public string GetJSFunctionString(object status, object appID, object country, object district, object frmDate, object todate, object reason, object address)
        {
            string str = "";
            str = appID.ToString()  + ',' + status.ToString() + ',' + country.ToString() + ',' + district.ToString() + ',' + frmDate.ToString() + ',' + todate.ToString() + ',' + reason.ToString() + ',' + address.ToString();
            return str;
        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
                string value = (e.CommandArgument).ToString();
                string[] data = value.Split(',');
                if (data[1] == "Pending")
                {
                    hdnappid.Value = data[0].ToString();
                    ddlCountry.SelectedValue = data[2].ToString(); ddlDistrict.SelectedValue = data[3].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FilterControls", "UpdateControls('" + data[4] + "','" + data[5] + "','" + data[6] + "','" + data[7] + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry this application is " + data[1] + " !!!');", true);
                }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PublicMovement.aspx btnSubmit_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.OfficialMovement.OfficialMovement objmovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    string empcode = hdfEmpCode.Value; int counrty = int.Parse(ddlCountry.SelectedValue.ToString());
                    int district = int.Parse(ddlDistrict.SelectedValue.ToString());
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    string reason = txtDescription.Text; string address = txtAddress.Text; 
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string insertStatus = objmovement.SubmitMovementApplication(empcode, counrty, district, fromdate, todate, reason, address, actionBy);
                    if (insertStatus != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                        ClearControls(); dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + ", Sorry to submit this application !!!');", true);
                    }
                }
                catch 
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit this application !!!');", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnUpdate_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PublicMovement.aspx btnUpdate_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.OfficialMovement.OfficialMovement objmovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    int appid = int.Parse(hdnappid.Value);
                    string empcode = hdfEmpCode.Value; int counrty = int.Parse(ddlCountry.SelectedValue.ToString());
                    int district = int.Parse(ddlDistrict.SelectedValue.ToString());
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    string reason = txtDescription.Text; string address = txtAddress.Text;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string insertStatus = objmovement.UpdateMovementApplication(appid, counrty, district, fromdate, todate, reason, address, actionBy);
                    if (insertStatus != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                        ClearControls(); dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + ", Sorry to update this application !!!');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to update this application !!!');", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnUpdate_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDelete_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PublicMovement.aspx btnDelete_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.OfficialMovement.OfficialMovement objmovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    int appid = int.Parse(hdnappid.Value);
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string insertStatus = objmovement.DeleteMovementApplication(appid, actionBy);
                    if (insertStatus != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                        ClearControls(); dgvApplicationSummary.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + ", Sorry to delete this application !!!');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to delete this application !!!');", true);
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnDelete_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        { ClearControls(); }


    }
}