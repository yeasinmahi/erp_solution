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
    public partial class HRResignCancel : BasePage
    {
        SelfClass obj = new SelfClass();
        DataTable dt;
        HRClass objhr = new HRClass();

        int intEnroll; int intApproveBy; int intPart; decimal monAmount; string strRemarks; string strEmailAdd; string strCurrentAddress;
        DateTime dteSeparateDateTime; DateTime dteLastOfficeDate; DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason; int intSeparateInsertBy; int intSeparateType;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnstation.Value = Session[SessionParams.JOBSTATION_ID].ToString(); hdnenroll.Value = Session[SessionParams.USER_ID].ToString();
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
            if (!String.IsNullOrEmpty(empCode))
            {
                strEmpCode = empCode;

                dt = new DataTable();
                dt = objhr.GetEnrollByEmpCode(strEmpCode); ;

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
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();

            }
        }

        protected void ddlSearchEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt = obj.GetSelfResignCancelData(intEnroll);

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
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = obj.CheckSelfResignWithdraw(intEnroll);
            int intCheckID = int.Parse(dt.Rows[0]["intCheck"].ToString());

            if (intCheckID == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please do not try again.');", true);
            }
            else
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 2;
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    obj.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);

                    //ddlJobStationList.DataBind();

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
                    txtUnit.Text = "";
                    txtJobStation.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Resign Withdraw Successfully');", true);
                }
            }
        }



    }
}