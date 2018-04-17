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
using HR_BLL.TeamBuild;
using UI.ClassFiles;

namespace UI.HR.TeamBuild
{
    public partial class TeamShiftChange : BasePage //System.Web.UI.Page
    {
        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <16-01-2013>
        Description: <Employee Team Shift Change>
        =============================================*/

        string alertMessage = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                hdnAction.Value = "0";
            }

            else
            {

                if (hdnAction.Value != "0") { Change_Shift(); }
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
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData
            (int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }

        private void LoadFieldValue(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    HR_BLL.Employee.EmployeeRegistration objGetProfile = new HR_BLL.Employee.EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        txtJobStatus.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtShiftStatus.Text = objDT.Rows[0]["strTeamName"].ToString();
                        txtCurrentShift.Text = objDT.Rows[0]["strShiftName"].ToString();
                        /*==================================================================
                        ddlUnit.DataBind();
                        ddlUnit.SelectedValue = objDT.Rows[0]["intUnitID"].ToString();
                        ddlJobStation.DataBind();
                        ddlJobStation.SelectedValue = objDT.Rows[0]["intEmployeeJobStationId"].ToString();                        
                        ddlShiftStatus.DataBind();
                        ddlShiftStatus.SelectedValue = objDT.Rows[0]["intTeamId"].ToString();
                        ddlPresentShift.DataBind();
                        ddlPresentShift.SelectedValue = objDT.Rows[0]["intShiftId"].ToString();*/
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void Change_Shift()
        {
            try
            {
                TeamAndShiftInformation teamShiftUpdate = new TeamAndShiftInformation();
                string empCode = hdfEmpCode.Value;
                int intTeamId = int.Parse(ddlShiftStatus.SelectedValue);
                int intShiftId = int.Parse(ddlPresentShift.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtFromDate.Text);
                DateTime dteTo = DateTime.Parse(txtToDate.Text);
                int loginUserID = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                alertMessage = teamShiftUpdate.UpdateTeamShiftInformationByEmpCode(empCode, intTeamId, intShiftId, dteFrom, dteTo, loginUserID);
                hdnAction.Value = "0";

                if (alertMessage != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + "');", true);
                    ClearControls();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertMessage + ", Sorry to update this employee !!!');", true);
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        private void ClearControls()
        {
            txtEmployeeSearch.Text = ""; hdfEmpCode.Value = ""; txtJobStatus.Text = ""; txtShiftStatus.Text = ""; txtCurrentShift.Text = "";
            ddlShiftStatus.DataBind(); ddlPresentShift.DataBind(); txtFromDate.Text = ""; txtToDate.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try { ClearControls(); }
            catch (Exception ex) { throw ex; }
        }

    }
}