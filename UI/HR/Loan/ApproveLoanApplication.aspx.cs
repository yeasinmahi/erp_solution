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
    public partial class ApproveLoanApplication : BasePage
    {
        #region Object Declare
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // hdnUserID.Value = "1056";
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
            }
        }
        public static DateTime DefaultDateFormat
        {
            get { return DateTime.Now.Date; }
        }
        protected void dgvApproveLoanApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Summary    :   This function will use to Select Row
            //Created    :   Md. Yeasir Arafat / FEB-25-2012
            //Modified   :   
            //Parameters : 

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='none';this.style.color='blue';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.color='black';";
            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.dgvApproveLoanApplication, "Select$" + e.Row.RowIndex);
            //    e.Row.Style.Add("cursor", "pointer");
            //}
        }
        protected void dgvApproveLoanApplication_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvApproveLoanApplication.EditIndex = e.NewEditIndex;
            dgvApproveLoanApplication.DataBind();
        }
        protected void dgvApproveLoanApplication_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            /*objLoan = new Loan();
            if (dgvApproveLoanApplication.Rows.Count > 0)
            {
                dgvApproveLoanApplication.DataBind();

    
                int applicationID = int.Parse(((HiddenField)dgvApproveLoanApplication.SelectedRow.Cells[0].FindControl("hdnApplicationId")).Value.ToString());
                int intApprovedAmount = int.Parse(((TextBox)dgvApproveLoanApplication.SelectedRow.Cells[6].FindControl("txtLoanAmount")).Text);
                int intApproveInstallment = int.Parse(((TextBox)dgvApproveLoanApplication.SelectedRow.Cells[7].FindControl("txtNumberOfApproveAmount")).Text);
                DateTime dteEffectiveDate = DateTime.Parse(((TextBox)dgvApproveLoanApplication.SelectedRow.Cells[8].FindControl("txtEffectiveDate")).Text);
                String strUpdateStatus = objLoan.SprApproveLoanApplication(applicationID, int.Parse(hdnUserID.Value.ToString()), true, intApprovedAmount, intApproveInstallment, dteEffectiveDate);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strUpdateStatus + "');", true);

            }
            dgvApproveLoanApplication.EditIndex = -1;
            dgvApproveLoanApplication.DataBind();*/
        }
        protected void dgvApproveLoanApplication_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvApproveLoanApplication.EditIndex = -1;
            dgvApproveLoanApplication.DataBind();

        }


    }
}