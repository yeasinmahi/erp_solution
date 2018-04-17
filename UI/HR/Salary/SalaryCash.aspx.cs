using HR_BLL.Employee;
using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Salary
{
    public partial class SalaryCash : BasePage
    {
        HR_BLL.Salary.SalaryInfo bll = new HR_BLL.Salary.SalaryInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                    hdnAction.Value = ""; txtEDate.Text=DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    if (hdnAction.Value == "0") { InsertCashData(); }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                        {
                            string strSearchKey = txtEmployeeSearch.Text;
                            string[] searchKey = Regex.Split(strSearchKey, ",");
                            hdfEmpCode.Value = searchKey[1];
                            if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                            { LoadFieldValue(searchKey[1]); hdfSearchBoxTextChange.Value = "false";}
                        }
                        else
                        { ClearControls(); }
                    }
                }
            }
            catch { }
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
            int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        private void LoadFieldValue(string empCode)
        {
            try
            {
                if (!String.IsNullOrEmpty(empCode))
                {
                    EmployeeRegistration objGetProfile = new EmployeeRegistration(); DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(empCode);
                    if (objDT.Rows.Count > 0)
                    {
                        txtJobStatus.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                        txtStation.Text = objDT.Rows[0]["strJobStationName"].ToString();
                        txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                        txtGross.Text = objDT.Rows[0]["monSalary"].ToString();
                        txtBasic.Text = objDT.Rows[0]["monBasic"].ToString();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearControls()
        {
            txtEmployeeSearch.Text = ""; hdfEmpCode.Value = ""; txtJobStatus.Text = ""; txtUnit.Text = ""; txtStation.Text = ""; hdnAction.Value = ""; 
            txtDepartment.Text = ""; txtDesignation.Text = ""; txtGross.Text = ""; txtBasic.Text = ""; txtEDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtAccholdr.Text = ""; ddlBank.DataBind(); ddlDistrict.DataBind(); ddlBranch.DataBind(); txtAccountNo.Text = ""; txtAmount.Text = "0.00";
        }
        private void InsertCashData()
        {
            if (hdnAction.Value == "0")
            {
                try
                {
                    string empcode = hdfEmpCode.Value;
                    int bank = int.Parse(ddlBank.SelectedValue.ToString());
                    int branch = int.Parse(ddlBranch.SelectedValue.ToString());
                    int dist = int.Parse(ddlDistrict.SelectedValue.ToString());
                    string accholder = txtAccholdr.Text;
                    string accountno = txtAccountNo.Text;
                    decimal cash = decimal.Parse(txtAmount.Text);
                    DateTime eDate = DateTime.Parse(txtEDate.Text);
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string msg = bll.SubmitCashSalary(empcode, bank, branch, dist, accholder, accountno, cash, eDate, actionBy);
                    ClearControls(); dgvcash.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit this application !!!');", true);
                }
            }
        }
        protected void Action_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdndelete.Value == "1")
                {
                    string senderdata = ((Button)sender).CommandArgument.ToString();
                    string[] searchKey = senderdata.Split('^');
                    int allwid = int.Parse(searchKey[0].ToString());
                    int cashid = int.Parse(searchKey[1].ToString());
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    string empcode = hdfEmpCode.Value;
                    string msg = bll.SubmitCashSalary(empcode, 0, allwid, cashid, "", "", 0, DateTime.Now.Date, actionBy); 
                    ClearControls(); dgvcash.DataBind();
                    //"Allowance : " + allwid.ToString() + ", Cash : " + cashid.ToString();bnft.DeleteBenifit(int.Parse(hdnenroll.Value), rowid); dgvBenifit.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg  + "');", true);
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }








    }
}