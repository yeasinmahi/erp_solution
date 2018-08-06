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
using HR_BLL.PolicyBLL;

namespace UI.HR.policyDoc
{
    public partial class frmPolicy : BasePage
    {
        HR_BLL.Salary.SalaryInfo bll = new HR_BLL.Salary.SalaryInfo();
        PolicyBLL objpolicy = new PolicyBLL();bool hdnCheck,check;
        DataTable dt;int docid;
        int enroll;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind();
                    GetDocinfo();
                    lblenroll.Text = Session[SessionParams.USER_ID].ToString();
                    lblname.Text="MR. "+ Session[SessionParams.USER_NAME].ToString();
                }

            }
            catch { }
        }

        private void GetDocinfo()
        {
            try
            {
                enroll =int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objpolicy.getPolicyRpt(enroll);
                dgvRpt.DataSource = dt;
                dgvRpt.DataBind();
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
        protected void dgvRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkStatus");

                    if (chkSelect.Checked==true)
                    {
                        chkSelect.Enabled = false;
                    }
                }
            }
            catch (Exception) {}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvRpt.Rows.Count > 0)
            {
                for (int index = 0; index < dgvRpt.Rows.Count; index++)
                {
                    hdnCheck = bool.Parse(((HiddenField)dgvRpt.Rows[index].FindControl("hdnsatus")).Value.ToString());
                    check = ((CheckBox)dgvRpt.Rows[index].FindControl("chkStatus")).Checked;
                 
                    if ((check == true)&&(hdnCheck == false))
                    {
                        docid = int.Parse(((HiddenField)dgvRpt.Rows[index].FindControl("hdndocid")).Value.ToString());
                        string msg= objpolicy.getDocinsertAcno(docid, int.Parse(Session[SessionParams.USER_ID].ToString()));

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        
                    }
                    
                }
                GetDocinfo();
            }
        }
   }
}