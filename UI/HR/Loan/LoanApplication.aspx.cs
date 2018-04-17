using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Loan;
using UI.ClassFiles;


namespace UI.HR.Loan
{
    public partial class LoanApplication : BasePage
    {
        #region Declare variable
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnUserId.Value = "1397";//Session[SessionParams.USER_ID].ToString();

                string srt = "";
                srt = "GotoNextFocus('" + txtNumberOfInstallment.ClientID + "',event);";
                txtLoanAmount.Attributes.Add("onkeyPress", srt);

                srt = "GotoNextFocus('" + btnAdd.ClientID + "',event);";
                txtNumberOfInstallment.Attributes.Add("onkeyPress", srt);

                txtNumberOfInstallment.Attributes.Add("onblur", "CalculateInstallmentAmount()");

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Summary    :   This function will use to Insert loan application data
            //Created    :   Md. Yeasir Arafat / FEB-22-2012
            //Modified   :   
            //Parameters :   passing parameters intuserID,intuserID,intLoanAmount,intNumberOfLoanInstallment and accept insertStatus

            try
            {
                if (!String.IsNullOrEmpty(hdnUserId.Value.ToString()))
                {
                    objLoan = new HR_BLL.Loan.Loan();
                    string insertStatus = objLoan.SprInsertLoanApplication(int.Parse(hdnUserId.Value.ToString()), null, int.Parse(txtLoanAmount.Text), int.Parse(txtNumberOfInstallment.Text));

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
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID,intLoanAmount,intNumberOfLoanInstallment and get update status

            try
            {
                if (dgvLoanApplication.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(hdnUserId.Value.ToString()))
                    {
                        hdnApplicationId.Value = dgvLoanApplication.SelectedRow.Cells[0].Text;
                        objLoan = new HR_BLL.Loan.Loan();
                        string updateStatus = objLoan.SprUpdateLoanApplication(int.Parse(hdnApplicationId.Value.ToString()), int.Parse(hdnUserId.Value.ToString()), null, int.Parse(txtLoanAmount.Text), int.Parse(txtNumberOfInstallment.Text));
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
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
            //Modified   :   
            //Parameters :   passing parameters intApplicationId,intuserID and accept deleteStatus

            try
            {
                if (dgvLoanApplication.Rows.Count > 0)
                {
                    if (!Boolean.Parse(((HiddenField)dgvLoanApplication.SelectedRow.Cells[4].FindControl("hdnYsnApprove")).Value.ToString()))
                    {
                        if (!String.IsNullOrEmpty(hdnUserId.Value.ToString()))
                        {
                            objLoan = new HR_BLL.Loan.Loan();
                            string deleteStatus = objLoan.SprDeleteLoanApplication(int.Parse(hdnApplicationId.Value.ToString()), int.Parse(hdnUserId.Value.ToString()), null);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + deleteStatus + "');", true);
                            RefreshPage();
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
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
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
            //Created    :   Md. Yeasir Arafat / FEB-23-2012
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
    }
}