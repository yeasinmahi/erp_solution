using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;

namespace UI.HR.Loan
{
    public partial class PublicLoanApplication : BasePage
    {
        #region Variable Declaration
        EmployeeBasicInfo objEmployeeBasicInfo = new EmployeeBasicInfo();
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        int? userID = null;
        static int intLoginUerId;
        static int intjobStationID;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Load initial Feild variable 
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters : 

            intLoginUerId = int.Parse(Session[SessionParams.USER_ID].ToString());
            intjobStationID = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
            if (!IsPostBack)
            {
                hdfUserID.Value = null;//hdfUserID value set null cause this public leave application functions are only operate by empCode

                pnlUpperControl.DataBind();

                string srt = "";
                srt = "GotoNextFocus('" + txtNumberOfInstallment.ClientID + "',event);";
                txtLoanAmount.Attributes.Add("onkeyPress", srt);

                srt = "GotoNextFocus('" + btnAdd.ClientID + "',event);";
                txtNumberOfInstallment.Attributes.Add("onkeyPress", srt);

                txtNumberOfInstallment.Attributes.Add("onblur", "CalculateInstallmentAmount()");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtSearchByName.Text))
                {
                    string strSearchKey = txtSearchByName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    LoadDefultFieldValue(searchKey[1]);
                }
                else
                {
                    RefreshPage();
                }
            }
        }
        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetAutoFillEmployeeListBySearchKey(string prefixText, int count)
        //{
        //    return EmployeeBasicInfo.GetAutoFillEmployeeListBySearchKey(prefixText, intLoginUerId, intjobStationID);
        //}

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(intLoginUerId, intjobStationID, strSearchKey);
            return result;
        }

        private void LoadDefultFieldValue(string empCode)
        {
            //Summary    :   This function will use to Load Employee's name,designation,depart,unit and jobstatus 
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :   employeeID
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
                    }
                }
            }
            catch
            {

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert loan application data
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,intuserID,intLoanAmount,intNumberOfLoanInstallment and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                {
                    objLoan = new HR_BLL.Loan.Loan();
                    string insertStatus = objLoan.SprInsertLoanApplication(null, hdfEmpCode.Value.ToString(), int.Parse(txtLoanAmount.Text), int.Parse(txtNumberOfInstallment.Text));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + insertStatus + "');", true);
                    RefreshPage();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                }
            }
            catch { }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to update loan application data
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID,intLoanAmount,intNumberOfLoanInstallment and get update status

            try
            {
                if (dgvLoanApplication.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                    {
                        hdnApplicationId.Value = dgvLoanApplication.SelectedRow.Cells[0].Text;
                        objLoan = new HR_BLL.Loan.Loan();
                        string updateStatus = objLoan.SprUpdateLoanApplication(int.Parse(hdnApplicationId.Value.ToString()), null, hdfEmpCode.Value.ToString(), int.Parse(txtLoanAmount.Text), int.Parse(txtNumberOfInstallment.Text));
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + updateStatus + "');", true);
                        RefreshPage();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                    }
                }
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to delete loan application data
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID and accept deleteStatus

            try
            {
                if (dgvLoanApplication.Rows.Count > 0)
                {
                    if (!Boolean.Parse(((HiddenField)dgvLoanApplication.SelectedRow.Cells[4].FindControl("hdnYsnApprove")).Value.ToString()))
                    {
                        if (!String.IsNullOrEmpty(hdfEmpCode.Value.ToString()))
                        {
                            objLoan = new HR_BLL.Loan.Loan();
                            string deleteStatus = objLoan.SprDeleteLoanApplication(int.Parse(hdnApplicationId.Value.ToString()), null, hdfEmpCode.Value.ToString());
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                            RefreshPage();
                            dgvLoanApplication.DataBind();
                            if (dgvLoanApplication.Rows.Count == 0)
                            {
                                txtName.Text = "";
                                txtDepartment.Text = "";
                                txtDesignation.Text = "";
                                txtJobStatus.Text = "";
                                txtUnit.Text = "";
                                //AutoCompleteBox.Text = "";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! User Id not found.Please recheck form..');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry!You can not delete approved data.');", true);
                    }
                }
            }
            catch { }
        }

        private void RefreshPage()
        {
            try
            {
                txtLoanAmount.Text = "";
                txtInstallmentAmount.Text = "";
                txtNumberOfInstallment.Text = "";
                lblRemenderMessage.Text = "";
                dgvLoanApplication.DataBind();
            }
            catch { }
        }
        protected void dgvLoanApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters : 
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
                    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvLoanApplication, "Select$" + e.Row.RowIndex);
                    e.Row.Style.Add("cursor", "pointer");
                }
            }
            catch { }
        }
        protected void dgvLoanApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary    :   This function will use to reload field value by application id
            //Created    :   Md. Yeasir Arafat / June-03-2012
            //Modified   :   
            //Parameters :

            try
            {
                if (dgvLoanApplication.Rows.Count > 0)
                {
                    hdnApplicationId.Value = dgvLoanApplication.SelectedRow.Cells[0].Text;
                    bool ysnApprove = Boolean.Parse(((HiddenField)dgvLoanApplication.SelectedRow.Cells[4].FindControl("hdnYsnApprove")).Value.ToString());
                    bool ysnLoanStatus = Boolean.Parse(((HiddenField)dgvLoanApplication.SelectedRow.Cells[5].FindControl("hdnYsnLoanStatus")).Value.ToString());

                    if (ysnApprove && !ysnLoanStatus)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "PopupScript", "launchModal(" + hdnApplicationId.Value.ToString() + ");", true);
                    }
                    else if (ysnLoanStatus)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your loan installment is complete.If you want to see previous loan details please contract with your software administrator');", true);
                        return; //Installment complete 
                    }
                    else if (!ysnApprove)
                    {
                        txtLoanAmount.Text = dgvLoanApplication.SelectedRow.Cells[1].Text;
                        txtNumberOfInstallment.Text = dgvLoanApplication.SelectedRow.Cells[2].Text;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CalculateInstallmentAmount", "javascript:CalculateInstallmentAmount(); ", true);
                    }
                }
            }
            catch { }
        }

        //protected void btnShowReport_Click(object sender, EventArgs e)
        //{
        //    if (!String.IsNullOrEmpty(AutoCompleteBox.Text))
        //    {
        //        string strSearchKey = AutoCompleteBox.Text;
        //        string[] searchKey = Regex.Split(strSearchKey, ",");
        //        hdfEmpCode.Value = searchKey[1];
        //        LoadDefultFieldValue(searchKey[1]);
        //    }
        //    else
        //    {
        //        RefreshPage();
        //    }
        //}
    }
}