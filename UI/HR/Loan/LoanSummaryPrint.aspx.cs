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
    public partial class LoanSummaryPrint : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        DataTable dt;

        int intPart, intEnroll, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment;
        DateTime dteEffectiveDate; string strStatus;
        #endregion =====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intEnroll = int.Parse(Request.QueryString["Id"]);
                LoadGrid();
            }
        }

        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            try
            {   
                dgvLoan.DataSource = "";
                dgvLoan.DataBind();
                intPart = 1;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intEnroll);
                dgvLoan.DataSource = dt;
                dgvLoan.DataBind();
            }
            catch (Exception ex) { throw ex; }

            try
            {
                intPart = 2;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intEnroll);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtDepartment.Text = dt.Rows[0]["strDepatrment"].ToString();
                    txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                    txtJobStatus.Text = dt.Rows[0]["strJobType"].ToString();
                    txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                }
                else
                {
                    txtName.Text = "";
                    txtUnit.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    txtJobStatus.Text = "";
                    txtJobStation.Text = "";
                }
            }
            catch { }
        }
        protected int totalloanamountn = 0;
        protected int totalremainloanamountn = 0;
        protected void dgvLoan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalloanamountn += int.Parse(((Label)e.Row.Cells[3].FindControl("lblLoanAmountT")).Text);
                    totalremainloanamountn += int.Parse(((Label)e.Row.Cells[4].FindControl("lblRemainLoanAmountT")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion======================================================================================





































    }
}