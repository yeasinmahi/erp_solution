using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.OfficialMovement
{
    public partial class PriMovement : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/OfficialMovement/PriMovement.aspx";
        string stop = "stopping HR/OfficialMovement/PriMovement.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    pnlUpperControl.DataBind(); txtEmployeeSearch.Text = HttpContext.Current.Session[SessionParams.USER_NAME].ToString() + "," +
                    HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    hdfEmpCode.Value = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    txtDetails.Text = "[" + HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString() + "][" + HttpContext.Current.Session[SessionParams.JOBTYPE_NAME].ToString() + "][" +
                    HttpContext.Current.Session[SessionParams.DEPT_NAME].ToString() + "][" + HttpContext.Current.Session[SessionParams.DESIG_NAME].ToString() + "]";
                }                
            }
            catch { }
        }
        private void ClearControls()
        {
            txtAddress.Text = ""; txtDescription.Text = ""; txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); ddlCountry.DataBind(); ddlDistrict.DataBind(); ddlMovement.DataBind();
        }
        public string GetJSFunctionString(object status, object appID, object country, object district, object frmDate, object todate, object reason, object address)
        {
            string str = "";
            str = appID.ToString() + ',' + status.ToString() + ',' + country.ToString() + ',' + district.ToString() + ',' + frmDate.ToString() + ',' + todate.ToString() + ',' + reason.ToString() + ',' + address.ToString();
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
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PriMovement.aspx btnSubmit_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    HR_BLL.OfficialMovement.OfficialMovement objmovement = new HR_BLL.OfficialMovement.OfficialMovement();
                    string empcode = hdfEmpCode.Value; int counrty = int.Parse(ddlCountry.SelectedValue.ToString());
                    int mtp = int.Parse(ddlMovement.SelectedValue.ToString());
                    int district = int.Parse(ddlDistrict.SelectedValue.ToString());
                    DateTime fromdate = DateTime.Parse(txtDteFrom.Text); DateTime todate = DateTime.Parse(txtDteTo.Text);
                    TimeSpan tmstart = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
                    TimeSpan tmend = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
                    string reason = txtDescription.Text; string address = txtAddress.Text;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string insertStatus = objmovement.SubmitMovementApplication(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), empcode, mtp, tmstart, tmend, counrty, district, fromdate, todate, reason, address, actionBy);
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDelete_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/OfficialMovement/PriMovement.aspx btnDelete_Click", "", fd.UserName, fd.Location,
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





    }
}