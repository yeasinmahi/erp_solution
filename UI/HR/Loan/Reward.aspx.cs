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
    public partial class Reward : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        HR_BLL.Loan.Loan objLoan = new HR_BLL.Loan.Loan();
        DataTable dt;

        int intPart, intRType, intInsertBy, intEnroll, intApplicationId, intLType, intUserID, intLoanAmount, intNumberOfInstallment, intApproveLoanAmount, intApproveNumberOfInstallment;
        DateTime dteEffectiveDate, dteDate; string strStatus, xml, strRemarks;
        decimal monAmount;
        
        #endregion =====================================================================================

        #region===== Page Load Event ===================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();
                    //*** Reward Type DDL Bind
                    dt = objLoan.GetRewardType();
                    ddlRewardType.DataTextField = "strRewardType";
                    ddlRewardType.DataValueField = "intRewardTypeID";
                    ddlRewardType.DataSource = dt;
                    ddlRewardType.DataBind();
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
        #endregion======================================================================================

        #region ===== Submit Action =====================================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intPart = 1;
                    intRType = int.Parse(ddlRewardType.SelectedValue.ToString());
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchEmp.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    try { intEnroll = int.Parse(temp1[1].ToString());}
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Employee.');", true); return; }
                    try { dteDate = DateTime.Parse(txtDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Effective Date.');", true); return; }
                    try { monAmount = decimal.Parse(txtAmount.Text);}
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Reward Amount.');", true); return; }
                    if(txtRemarks.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Remarks.');", true); return; }
                    strRemarks = txtRemarks.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    //*** Final Insert 
                    string message = objLoan.InsertReward(intPart, intRType, intEnroll, dteDate, monAmount, strRemarks, intInsertBy);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    txtSearchEmp.Text = "";
                    txtDate.Text = "";
                    txtAmount.Text = "";
                    txtRemarks.Text = "";
                    txtName.Text = "";
                    txtUnit.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    txtJobStatus.Text = "";
                    txtJobStation.Text = "";
                }
                catch { }
            }
        }
        #endregion=======================================================================================






















    }
}