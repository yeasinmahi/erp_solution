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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Loan
{
    public partial class LoanApplicationN : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Loan/LoanApplicationN.aspx";
        string stop = "stopping HR/Loan/LoanApplicationN.aspx";

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

                    //*** Loan Type DDL Bind
                    dt = objLoan.GetLoanType();
                    ddlLoanType.DataTextField = "strLoanType";
                    ddlLoanType.DataValueField = "intLoanTypeID";
                    ddlLoanType.DataSource = dt;
                    ddlLoanType.DataBind();
                }
            }
            catch { }        
        }
        #endregion======================================================================================

        #region===== Web Method For Employee Search ====================================================
        [WebMethod]
        [ScriptMethod]
        public static string[] AutoSearchEmpListGlobal(string prefixText, int count)
        {
            int intEnroll = Convert.ToInt32(HttpContext.Current.Session["Enroll"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.AutoSearchEmpListGlobal(intEnroll.ToString(), prefixText);
        }
        #endregion======================================================================================

        #region===== Text Box Change Event =============================================================
        protected void txtSearchEmp_TextChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "txtSearchEmp_TextChanged", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/LoanApplicationN.aspx txtSearchEmp_TextChanged", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intEnroll = int.Parse(temp1[1].ToString());
                }
                catch { intEnroll = 0; }

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
                    txtLoanAmount.Text = "";
                    txtNumberOfInstallment.Text = "";
                    lblRemenderMessage.Text = "";
                }
                else
                {
                    txtName.Text = "";
                    txtUnit.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    txtJobStatus.Text = "";
                    txtJobStation.Text = "";
                    txtLoanAmount.Text = "";
                    txtNumberOfInstallment.Text = "";
                    lblRemenderMessage.Text = "";
                }
                //*** Reload Grid
                LoadGrid();
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "txtSearchEmp_TextChanged", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        #endregion======================================================================================

        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            try
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intUserID = int.Parse(temp1[1].ToString());
                }
                catch { intUserID = 0; return; }

                dgvLoan.DataSource = "";
                dgvLoan.DataBind();
                intPart = 1;
                dt = new DataTable();
                dt = objLoan.GetLoanReportByEnroll(intPart, intUserID);
                dgvLoan.DataSource = dt;
                dgvLoan.DataBind();
            }
            catch (Exception ex) { throw ex; }
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

        #region===== Loan Insert =======================================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/LoanApplicationN.aspx btnAdd_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intPart = 1;
                    intApplicationId = 0;
                    intLType = int.Parse(ddlLoanType.SelectedValue.ToString());

                    try
                    {
                        char[] ch1 = { '[', ']' };
                        string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                        intUserID = int.Parse(temp1[1].ToString());
                    }
                    catch { intUserID = 0; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Employee Select For Loan.');", true); return; }

                    try { intLoanAmount = int.Parse(txtLoanAmount.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Loan Amount.');", true); return; }
                    if(intLoanAmount == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Loan Amount.');", true); return; }

                    try { intNumberOfInstallment = int.Parse(txtNumberOfInstallment.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Number Of Installment.');", true); return; }
                    if (intNumberOfInstallment == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Number Of Installment.');", true); return; }
                    
                    intApproveLoanAmount = 0;
                    intApproveNumberOfInstallment = 0;
                    dteEffectiveDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    xml = "";
                    strRemarks = "";

                    //*** Final Insert
                    string message = objLoan.InsertUpdateLoan(intPart, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment, dteEffectiveDate, xml, strRemarks);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtNumberOfInstallment.Text = "";
                    txtLoanAmount.Text = "";
                    txtInstallmentAmount.Text = "";
                    hdnconfirm.Value = "0";
                    //*** Re Load For Report
                    LoadGrid();
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion======================================================================================

        #region===== Loan Delete Before Approve ========================================================
        protected void dgvLoan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "dgvLoan_RowCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Loan/LoanApplicationN.aspx dgvLoan_RowCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName == "Y")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvLoan.Rows[rowIndex];

                try
                {
                    intApplicationId = int.Parse((row.FindControl("lblApplicationID") as Label).Text);
                    strStatus = (row.FindControl("lblAppStatus") as Label).Text;

                    if (strStatus == "Pending")
                    {
                        if (hdnconfirm.Value == "1")
                        {
                            try
                            {
                                intPart = 2;
                                intLType = 0;
                                intUserID = 0;
                                intLoanAmount = 0;
                                intNumberOfInstallment = 0;
                                intApproveLoanAmount = 0;
                                intApproveNumberOfInstallment = 0;
                                dteEffectiveDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
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
                    else if (strStatus == "Approved")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This loan is approved. Delete not posible.');", true);
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }               
            }
            else if (e.CommandName == "D")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvLoan.Rows[rowIndex];

                hdnLoanID.Value = (row.FindControl("lblApplicationID") as Label).Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDispatchPopup('" + hdnLoanID.Value + "');", true);
            }

            fd = log.GetFlogDetail(stop, location, "dgvLoan_RowCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion======================================================================================
        












    }
}