using BLL.AutoSearch;
using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using BLL.Accounts.ChartOfAccount;
using System.Data;
using UI.ClassFiles;

namespace UI.Accounts.ChartOfAccount
{
    public partial class GLCodeBridge : System.Web.UI.Page
    {
        #region INIT
        public static EmployeeBll employeeBll = new EmployeeBll();
        private GLCodeBLL gLCodeBLL = new GLCodeBLL();
        string[] arrayKey;
        char[] delimiterChars = { '[', ']' };
        int EmpID, ActionBy;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            if (hfSearch.Value == "1")
            {
                if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                {
                    arrayKey = txtEmployeeSearch.Text.Split(delimiterChars);

                    if (arrayKey.Length > 0)
                    {
                        EmpID = Convert.ToInt32(arrayKey[1].ToString());
                        hfEmployee.Value = EmpID.ToString();
                        LoadEmployeeDetails(EmpID);
                        LoadGridview(EmpID);
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if(validation() == true)
                {
                    if(hfConfirm.Value.ToString() == "1")
                    {
                        ActionBy = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        string strGLCodeCr = txtLoanCredit.Text.ToString();
                        string strGLCodeDr = txtLoanDebit.Text.ToString();
                        int Enroll = !string.IsNullOrEmpty(hfEmployee.Value) ? Convert.ToInt32(hfEmployee.Value) : 0;
                        result = gLCodeBLL.GLCodeBridgeSubmition(Enroll, strGLCodeDr, strGLCodeCr, ActionBy);
                        if(result == true)
                        {
                            Clear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('GL Code Submit Successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('GL Code Submit Failed.');", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Canceled Submition.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string sms = "Submit Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        

        #region Method
        private void LoadEmployeeDetails(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = gLCodeBLL.GetEmployeeDetails(Enroll);
                if(dt != null && dt.Rows.Count > 0)
                {
                    lblEmpName.Text = !string.IsNullOrEmpty(dt.Rows[0]["strEmployeeName"].ToString()) ? 
                        dt.Rows[0]["strEmployeeName"].ToString() : string.Empty;
                    lblEmpEmail.Text = !string.IsNullOrEmpty(dt.Rows[0]["strOfficeEmail"].ToString()) ?
                        dt.Rows[0]["strOfficeEmail"].ToString() : string.Empty;
                    lblEmpDesignation.Text = !string.IsNullOrEmpty(dt.Rows[0]["strDesignation"].ToString()) ?
                        dt.Rows[0]["strDesignation"].ToString() : string.Empty;
                    lblEmpDepartment.Text = !string.IsNullOrEmpty(dt.Rows[0]["strDepatrment"].ToString()) ?
                        dt.Rows[0]["strDepatrment"].ToString() : string.Empty;
                    lblEmpUnit.Text = !string.IsNullOrEmpty(dt.Rows[0]["strUnit"].ToString()) ?
                        dt.Rows[0]["strUnit"].ToString() : string.Empty;
                    lblJobStation.Text = !string.IsNullOrEmpty(dt.Rows[0]["strJobStationName"].ToString()) ?
                        dt.Rows[0]["strJobStationName"].ToString() : string.Empty;
                    lblEmpStatus.Text = !string.IsNullOrEmpty(dt.Rows[0]["strStatus"].ToString()) ?
                        dt.Rows[0]["strStatus"].ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                string sms = "Employee Data Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadGridview(int Enroll)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = gLCodeBLL.GetGLCodeData(Enroll);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvGLCodeBridge.DataSource = dt;
                    dgvGLCodeBridge.DataBind();
                }
            }
            catch (Exception ex)
            {
                string sms = "GL Code Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private bool validation()
        {
            if(string.IsNullOrEmpty(txtLoanCredit.Text) && txtLoanCredit.Text.Length <= 0)
            {
                txtLoanCredit.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Credit Loan Amount.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtLoanDebit.Text) && txtLoanDebit.Text.Length <= 0)
            {
                txtLoanDebit.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Debit Loan Amount.');", true);
                return false;
            }

            return true;
        }
        private void Clear()
        {
            txtLoanCredit.Text = string.Empty;
            txtLoanDebit.Text = string.Empty;
            lblEmpName.Text = string.Empty;
            lblEmpEmail.Text = string.Empty;
            lblEmpDesignation.Text = string.Empty;
            lblEmpDepartment.Text = string.Empty;
            lblEmpUnit.Text = string.Empty;
            lblJobStation.Text = string.Empty;
            lblEmpStatus.Text = string.Empty;
            txtEmployeeSearch.Text = string.Empty;
            dgvGLCodeBridge.DataSource = null;
            dgvGLCodeBridge.DataBind();
            hfEmployee.Value = string.Empty;
            hfSearchID.Value = string.Empty;
        }



        [WebMethod]
        [ScriptMethod]
        public static string[] GetAutoCompleteData(string strSearchKey)
        {
           return employeeBll.GetAllEmployee(strSearchKey);
        }
        #endregion
    }
}