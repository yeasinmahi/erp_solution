using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HR_BLL.Global;
using System.Web.Services;
using System.Text.RegularExpressions;
using HR_BLL.Employee;
using HR_BLL.Loan;
using UI.ClassFiles;

namespace UI.HR.Loan
{
    public partial class LoanInstallmentRepay : BasePage
    {
        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        HR_BLL.Loan.Loan objLoan;
        static int intLoginUerId;
        static int intjobStationID;
        int? userID = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            //Summary    :   This function will use to Load initial Feild variable 
            //Created    :   Md. Yeasir Arafat / October-16-2012
            //Modified   :   
            //Parameters : 

            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            if (!IsPostBack)
            {
                hdnLoanApplicationId.Value = "0";
                pnlUpperControl.DataBind();
                txtSearchEmployee.Attributes.Add("onkeyUp", "SearchText();");

                btnRepay.Attributes.Add("onclick", "this.disabled=true;" + GetPostBackEventReference(btnRepay).ToString());

                string srt = "";
                srt = "GotoNextFocus('" + btnSearch.ClientID + "',event);";
                txtSearchEmployee.Attributes.Add("onkeyPress", srt);
            }
            else
            {
                if (!String.IsNullOrEmpty(txtSearchEmployee.Text))
                {
                    string strSearchKey = txtSearchEmployee.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    LoadDefultFieldValue(searchKey[1]);
                    GetLoanScheduleDetails(searchKey[1]);
                }
                else
                {
                    RefreshPage();
                }
            }

        }

        private void GetLoanScheduleDetails(string strEmployeeCode)
        {
            try
            {
                objLoan = new HR_BLL.Loan.Loan();
                int? loanApplicationId = 0;
                decimal? monTotalLoanScheduleAmount = 0;
                DataTable odtLoanScheduleDetails = objLoan.GetLoanScheduleDetailsByEmployeeCode(strEmployeeCode, ref loanApplicationId, ref monTotalLoanScheduleAmount);

                hdnLoanApplicationId.Value = loanApplicationId.ToString();
                hdfTotalLoanScheduleAmount.Value = monTotalLoanScheduleAmount.ToString();
                lblTotalRemaining.Text = "Total remaining Tk." + String.Format("{0:0.00}", monTotalLoanScheduleAmount); // monTotalLoanScheduleAmount.ToString("#.##");
                lblTotalRemaining.ForeColor = System.Drawing.Color.Red;

                dgvLoanScheduleDetails.DataBind();
            }
            catch { }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            //Summary    :   This procedure will be used to search employee's details by employee code or employee name 
            //Created    :   Md. Yeasir Arafat / October-16-2012
            //Modified   :   
            //Parameters :   searching key. It's may employee's name or code


            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(intLoginUerId, intjobStationID, strSearchKey);
            return result;
        }
        private void LoadDefultFieldValue(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / October-16-2012
            //Modified   :   
            //Parameters :   empCode
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {

                    DataTable oDT_EmpInfo = new DataTable();
                    oDT_EmpInfo = objEmployeeBasicInfo.Get_Employee_Basic_Info_By_EmpCodeOrUserID(userID, empCode);
                    if (oDT_EmpInfo.Rows.Count > 0)
                    {
                        txtName.Text = oDT_EmpInfo.Rows[0]["strEmployeeName"].ToString();
                        txtUnit.Text = oDT_EmpInfo.Rows[0]["strUnit"].ToString();
                        txtDepartment.Text = oDT_EmpInfo.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = oDT_EmpInfo.Rows[0]["strDesignation"].ToString();
                        txtJobStatus.Text = oDT_EmpInfo.Rows[0]["strJobType"].ToString();
                        txtJoiningDate.Text = oDT_EmpInfo.Rows[0]["dteJoiningDate"].ToString();
                    }
                }
            }
            catch
            {
            }
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / October-16-2012
            //Modified   :   
            //Parameters :   empCode

            try
            {
                LoadDefultFieldValue(hdfEmpCode.Value);
            }
            catch { }
        }
        private void RefreshPage()
        {
            //Summary    :   This procedure will be used to refresh page due to change searching key
            //Created    :   Md. Yeasir Arafat / October-16-2012
            //Modified   :   
            //Parameters :   
            try
            {
                txtDepartment.Text = "";
                txtDesignation.Text = "";
                txtJobStatus.Text = "";
                txtJoiningDate.Text = "";
                txtName.Text = "";
                txtUnit.Text = "";
                hdnLoanApplicationId.Value = "";
                hdfTotalLoanScheduleAmount.Value = "";
            }
            catch { }
        }
        protected void btnRepay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(hdnLoanApplicationId.Value.ToString()))
                {
                    if (Convert.ToDouble(txtRepayLoanAmount.Text) > Convert.ToDouble(hdfTotalLoanScheduleAmount.Value))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! repay loan amount cannot be gratter than due amount..');", true);
                        return;
                    }

                    objLoan = new HR_BLL.Loan.Loan();
                    string strRepayStatus = objLoan.RepayLoanAmount(int.Parse(hdnLoanApplicationId.Value), int.Parse(txtRepayLoanAmount.Text));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strRepayStatus + "');", true);
                    dgvLoanScheduleDetails.DataBind();
                    GetLoanScheduleDetails(hdfEmpCode.Value);
                    txtRepayLoanAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.Message + "');", true);
            }
        }

    }
}