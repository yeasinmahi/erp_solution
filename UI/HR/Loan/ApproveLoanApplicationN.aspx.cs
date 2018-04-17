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
    public partial class ApproveLoanApplicationN : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        DataTable dt;

        int intPart, intEnroll, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment;
        DateTime dteEffectiveDate; string strStatus, xml, strRemarks;
        #endregion =====================================================================================

        #region===== Page Load Event ===================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();
                    LoadGrid();
                }
            }
            catch { }
        }
        #endregion======================================================================================

        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            try
            {
                intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                dgvLoan.DataSource = "";
                dgvLoan.DataBind();
                intPart = 3;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intUserID);
                dgvLoan.DataSource = dt;
                dgvLoan.DataBind();
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion======================================================================================

        #region===== Loan Approve & Delete Before Approve ==============================================
        protected void dgvLoan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvLoan.Rows[rowIndex];

                try
                {
                    if (hdnconfirm.Value == "1")
                    {
                        try
                        {
                            intPart = 3;
                            intLType = 0;
                            intApplicationId = int.Parse((row.FindControl("lblApplicationID") as Label).Text);
                            intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                            intLoanAmount = 0;
                            intNumberOfInstallment = 0;
                            //intApproveLoanAmount = int.Parse((row.FindControl("txtAppAmount") as TextBox).Text);
                            //intApproveNumberOfInstallment = int.Parse((row.FindControl("txtAppInstall") as TextBox).Text);
                            intApproveLoanAmount = int.Parse((row.FindControl("lblLoanAmountT") as Label).Text);
                            intApproveNumberOfInstallment = int.Parse((row.FindControl("lblInstallment") as Label).Text);
                            dteEffectiveDate = DateTime.Parse((row.FindControl("txtEffDate") as TextBox).Text);
                            xml = "";
                            strRemarks = "";

                            //** Final Insert
                            string message = objLoan.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            hdnconfirm.Value = "0";
                            LoadGrid();
                        }
                        catch { }
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
            else if (e.CommandName == "R")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvLoan.Rows[rowIndex];

                try
                {
                    if (hdnconfirm.Value == "1")
                    {
                        try
                        {
                            intPart = 5;
                            intLType = 0;
                            intApplicationId = int.Parse((row.FindControl("lblApplicationID") as Label).Text);
                            intUserID = int.Parse(Session[SessionParams.USER_ID].ToString());
                            intLoanAmount = 0;
                            intNumberOfInstallment = 0;
                            intApproveLoanAmount = int.Parse((row.FindControl("txtAppAmount") as TextBox).Text);
                            intApproveNumberOfInstallment = int.Parse((row.FindControl("txtAppInstall") as TextBox).Text);
                            dteEffectiveDate = DateTime.Parse((row.FindControl("txtEffDate") as TextBox).Text);
                            xml = "";
                            strRemarks = "";

                            //** Final Insert
                            string message = objLoan.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                            hdnconfirm.Value = "0";
                            LoadGrid();
                        }
                        catch { }
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }
        #endregion======================================================================================

























    }
}