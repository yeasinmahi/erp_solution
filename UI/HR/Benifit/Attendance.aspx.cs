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

namespace UI.HR.Benifit
{
    public partial class Attendance : BasePage
    {
        HR_BLL.Benifit.Bonus_BLL bnft = new HR_BLL.Benifit.Bonus_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                {
                    string strSearchKey = txtEmployeeSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    EmployeeRegistration objGetProfile = new EmployeeRegistration();
                    DataTable objDT = new DataTable();
                    objDT = objGetProfile.GetEmployeeProfileByEmpCode(hdfEmpCode.Value);
                    if (objDT.Rows.Count > 0)
                    {
                        txtJobtype.Text = objDT.Rows[0]["strJobType"].ToString();
                        txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                    }
                    hdfSearchBoxTextChange.Value = "false";
                }
            }

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
        protected void Action_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdndelete.Value == "1")
                {
                    string senderdata = ((Button)sender).CommandArgument.ToString();
                    string[] searchKey = senderdata.Split(',');
                    int rowid = int.Parse(searchKey[0].ToString());
                    string msg = bnft.DeleteBenifit(int.Parse(hdnenroll.Value), rowid); dgvBenifit.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Benifit has been successfully deleted.');", true);
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    string code = hdfEmpCode.Value; 
                    string amount = double.Parse(txtAmount.Text).ToString();
                    string narration=ddlBType.SelectedItem.ToString();
                    string btype = ddlBType.SelectedValue.ToString();
                    string userid = hdnenroll.Value;
                    string msg = bnft.InsertBenifit(btype, code, amount, narration, userid); dgvBenifit.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Benifit has been successfully submitted.');", true);
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
            txtEmployeeSearch.Text = ""; txtJobtype.Text = ""; txtDesignation.Text = ""; txtAmount.Text = "0.00"; ddlBType.DataBind();
        }

    }
}