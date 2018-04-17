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

namespace UI.HR.OfficialMovement
{
    public partial class PubMovement : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    pnlUpperControl.DataBind(); txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        txtDetails.Text="["+objDT.Rows[0]["strJobStationName"].ToString()+"]["+objDT.Rows[0]["strJobType"].ToString()+"]["+
                        objDT.Rows[0]["strDepatrment"].ToString()+"]["+objDT.Rows[0]["strDesignation"].ToString()+"]";
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearControls()
        {
            //txtEmployeeSearch.Text = ""; txtJobStatus.Text = ""; txtUnit.Text = ""; txtStation.Text = ""; txtDesignation.Text = "";
            txtDetails.Text = ""; txtAddress.Text = ""; txtDescription.Text = ""; txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                    string insertStatus = objmovement.SubmitMovementApplication(null,empcode, mtp, tmstart, tmend, counrty, district, fromdate, todate, reason, address, actionBy);
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
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
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
        }
        


    }
}