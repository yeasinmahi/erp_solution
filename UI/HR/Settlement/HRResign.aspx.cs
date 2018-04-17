using HR_BLL.Global;
using HR_BLL.Settlement;
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

namespace UI.HR.Settlement
{
    public partial class HRResign : BasePage
    {
        HRClass objhr = new HRClass();
        SelfClass obj = new SelfClass();
        DataTable dt;

        int intEnroll; int intSeparateType; DateTime dteLastOfficeDate; DateTime dteLastOfficeDateByUser;
        DateTime dteSeparateDateTime; string strSeparateReason; int intSVID; DateTime dteLastOfficeDateByAuthority;
        int intPart; int intSeparateInsertBy; int intApproveBy; decimal monAmount; string strRemarks;
        string strEmailAdd; string strCurrentAddress;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { hdnstation.Value = Session[SessionParams.JOBSTATION_ID].ToString(); hdnEnrollUnit.Value = Session[SessionParams.USER_ID].ToString();
            pnlUpperControl.DataBind(); txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
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
                        GetSearchResult(searchKey[1]);
                        hdfSearchBoxTextChange.Value = "false";
                    }
                }
                
            }

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
        private void GetSearchResult(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    strEmpCode = empCode;

                    dt = new DataTable();
                    dt = objhr.GetEnrollByEmpCode(strEmpCode);

                    intEnroll = int.Parse(dt.Rows[0]["intEmployeeID"].ToString());

                    dt = new DataTable();
                    dt = obj.GetEmpInfoForSeltResign(intEnroll);

                    txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
                    txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                    txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                    txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                    txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                    txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                    txtJobType.Text = dt.Rows[0]["strJobType"].ToString();
                    txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                    txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                    txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
                    txtLastOfficeDateWillbe.Text = dt.Rows[0]["dteLastWorkingDate"].ToString();
                    txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                }
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = obj.CheckSelfResign(intEnroll);
            int intCheckID = int.Parse(dt.Rows[0]["intCheck"].ToString());

            if (intCheckID != 0)
            {
                txtReason.Text = "";
                txtLastOfficeDateByUser.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already resign submited.');", true);
            }
            else
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intSeparateType = int.Parse(ddlSeparateType.SelectedValue.ToString());
                        dteLastOfficeDate = DateTime.Parse(txtLastOfficeDateWillbe.Text);
                        dteLastOfficeDateByUser = DateTime.Parse(txtLastOfficeDateByUser.Text);
                        dteSeparateDateTime = DateTime.Parse(txtSeparationDate.Text);
                        strSeparateReason = txtReason.Text;
                        dteLastOfficeDateByAuthority = DateTime.Parse(txtLastOfficeDateByUser.Text);
                        intSeparateInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                        intPart = 1;

                        obj.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);

                        //ddlJobStationList.DataBind();

                        txtReason.Text = "";
                        txtLastOfficeDateByUser.Text = "";

                        txtSupervisorName.Text = "";
                        txtSupervisorDesignation.Text = "";
                        txtEmpCode.Text = "";
                        txtEmpEnroll.Text = "";
                        txtName.Text = "";
                        txtDesignation.Text = "";
                        txtDept.Text = "";
                        txtJobType.Text = "";
                        txtBasic.Text = "";
                        txtGross.Text = "";
                        txtJoiningDate.Text = "";
                        txtLastOfficeDateWillbe.Text = "";
                        txtUnit.Text = "";
                        txtJobStation.Text = "";

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Submited Successfully');", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please try again.');", true);
                    }
                }
            }

        }





    }
}