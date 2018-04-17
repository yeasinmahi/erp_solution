using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Employee;
using System.Web.Services;
using HR_BLL.Global;
using System.Web.Script.Services;
using System.Data;
using System.Text.RegularExpressions;
using HR_BLL.Benifit;
using UI.ClassFiles;


namespace UI.HR.Benifit
{
    public partial class PF_Release : BasePage
    {
        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        PfRelease_BLL objPfRelease_BLL;
        static int intLoginUerId;
        static int intjobStationID;
        int? userID = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Load initial Feild variable 
            //Created    :   Md. Yeasir Arafat / August-05-2012
            //Modified   :   
            //Parameters : 

            intLoginUerId = 1056;//int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = 1;//int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtSearchEmployee.Attributes.Add("onkeyUp", "SearchText();");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtSearchEmployee.Text))
                {
                    string strSearchKey = txtSearchEmployee.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    LoadDefultFieldValue(searchKey[1]);
                    LoadProvidentFundDetailsForRelease(searchKey[1]);
                }
                else
                {
                    RefreshPage();
                }
            }
        }


        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            //Summary    :   This procedure will be used to search employee's details by employee code or employee name 
            //Created    :   Md. Yeasir Arafat / August-05-2012
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
            //Created    :   Md. Yeasir Arafat / August-05-2012
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
        private void LoadProvidentFundDetailsForRelease(string empCode)
        {
            //Summary    :   This procedure will be used to load provident fund details that means employee's contribution,
            //               employer's contribution and profit  
            //Created    :   Md. Yeasir Arafat / August-05-2012
            //Modified   :   
            //Parameters :   employee code

            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    DataTable odtPfSummary = new DataTable();
                    objPfRelease_BLL = new PfRelease_BLL();
                    bool? ysnPaid = false;
                    odtPfSummary = objPfRelease_BLL.GetProvidentFundSummaryByEmployeeCode(empCode, ref ysnPaid);
                    if (odtPfSummary.Rows.Count > 0)
                    {
                        txtEmployeesContribution.Text = Decimal.Parse(odtPfSummary.Rows[0]["monEmployeeContribution"].ToString()).ToString("#.##");
                        txtEmployersContribution.Text = Decimal.Parse(odtPfSummary.Rows[0]["monEmployerContribution"].ToString() == null ? "0" : odtPfSummary.Rows[0]["monEmployerContribution"].ToString()).ToString("#.##");
                        txtProfit.Text = Decimal.Parse(odtPfSummary.Rows[0]["monProfit"].ToString()).ToString("#.##");
                        txtTotalPayable.Text = Decimal.Parse(odtPfSummary.Rows[0]["totalPayable"].ToString()).ToString("#.##");
                        CheckingEmptyFeild(ysnPaid);
                    }
                }
            }
            catch
            {
            }
        }

        private void CheckingEmptyFeild(bool? ysnPaid)
        {
            if (String.IsNullOrEmpty(txtEmployeesContribution.Text)) txtEmployeesContribution.Text = "0";
            if (String.IsNullOrEmpty(txtEmployersContribution.Text))
            {
                txtEmployersContribution.Text = "0";
                txtEmployersContribution.ForeColor = System.Drawing.Color.Red;
                txtJoiningDate.ForeColor = System.Drawing.Color.Red;
                lblJoiningDate.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtEmployersContribution.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3b5871");
                txtJoiningDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3b5871");
                lblJoiningDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3b5871");
            }
            if (String.IsNullOrEmpty(txtProfit.Text)) txtProfit.Text = "0";
            if (String.IsNullOrEmpty(txtTotalPayable.Text)) txtTotalPayable.Text = "0";

            if (ysnPaid == true)
            {
                lblPaidStatus.Text = "Sorry! Provident fund has already been released.";
                btnPay.Visible = false;
            }
            else
            {
                lblPaidStatus.Text = "";
                btnPay.Visible = true;
            }
        }

        private void RefreshPage()
        {
            //Summary    :   This procedure will be used to refresh page due to change searching key
            //Created    :   Md. Yeasir Arafat / August-05-2012
            //Modified   :   
            //Parameters :   


            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtEmployeesContribution.Text = "";
            txtEmployersContribution.Text = "";
            txtJobStatus.Text = "";
            txtJoiningDate.Text = "";
            txtName.Text = "";
            txtProfit.Text = "";
            //txtSearchEmployee.Text = "";
            txtTotalPayable.Text = "";
            txtUnit.Text = "";
            lblPaidStatus.Text = "";
            btnPay.Visible = true;
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                PfRelease_BLL objPfRelease_BLL = new PfRelease_BLL();
                string strReleaseStatus = "";
                //strReleaseStatus = objPfRelease_BLL.ReleaseProvidentFund(hdfEmpCode.Value, decimal.Parse(txtProfit.Text == "" ? "0" : txtProfit.Text), decimal.Parse(txtTotalPayable.Text == "" ? "0" : txtTotalPayable.Text), DateTime.Now, intLoginUerId);
                strReleaseStatus = objPfRelease_BLL.ReleaseProvidentFund(hdfEmpCode.Value, decimal.Parse(txtProfit.Text == "" ? "0" : txtProfit.Text), decimal.Parse(txtTotalPayable.Text == "" ? "0" : txtTotalPayable.Text), decimal.Parse(txtEmployeesContribution.Text == "" ? "0" : txtEmployeesContribution.Text), decimal.Parse(txtEmployersContribution.Text == "" ? "0" : txtEmployersContribution.Text), DateTime.Now, intLoginUerId, intLoginUerId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strReleaseStatus + "');", true);
                RefreshPage();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! Error has been occured.Please see the error details' + " + ex.Message + ");", true);
            }
        }
    }
}