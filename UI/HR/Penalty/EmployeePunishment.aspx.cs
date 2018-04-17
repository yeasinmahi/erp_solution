using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Penalty
{
    public partial class EmployeePunishment : BasePage
    {
        HR_BLL.Penalty.Penalty pnlty = new HR_BLL.Penalty.Penalty();
        string msgStatus = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                {
                    hdfEmpCode.Value = "";
                    string strSearchKey = txtEmployeeSearch.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdfEmpCode.Value = searchKey[1];
                    if (bool.Parse((hdfSearchBoxTextChange.Value.ToString() == null ? "false" : hdfSearchBoxTextChange.Value.ToString())))
                    {
                        //FillControls(searchKey[1]);
                        hdfSearchBoxTextChange.Value = "false";
                    }
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string temp = ((Button)sender).CommandArgument.ToString();
                    msgStatus = pnlty.CancelPunishment(int.Parse(temp));
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    dgvSummary.DataBind();
                }
                catch { }
            }
        }

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString())
            , int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try {

                    string empcode = hdfEmpCode.Value;
                    int ptype = int.Parse(ddlPType.SelectedValue);
                    string dptype = ddlPType.SelectedItem.ToString();
                    DateTime effective = DateTime.Parse(txtEffectiveDate.Text); decimal amount = decimal.Parse(txtAmount.Text);
                    string reason = txtReason.Text;
                    int actionBy = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    msgStatus = pnlty.InsertDisciplinaryPunishment(empcode, ptype, dptype, effective, amount, reason, actionBy);
                    if (msgStatus != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                        ResetControls();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + ", Sorry to submit this disciplinary punishment !!!');", true);
                    }
                    dgvSummary.DataBind();
                }
                catch { }
            }
        }

        private void ResetControls()
        {
            txtEmployeeSearch.Text = ""; txtEffectiveDate.Text = ""; txtAmount.Text = ""; txtReason.Text = "";
        }

    }
}