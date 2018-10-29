using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class PaySlipReport : BasePage
    {
        string[] arrayKey;
        char[] delimiterChars = { '[', ']' };
        int EmpID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); 
            }
            else
            {
                if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                {
                    arrayKey = txtEmployeeSearch.Text.Split(delimiterChars);

                    if (arrayKey.Length > 0)
                    {
                        EmpID = Convert.ToInt32( arrayKey[3].ToString());                       
                    }
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/HR/Monthly_PaySlip_Report3&intEmpID=" + EmpID + "&date=" + txtFromDate.Text + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText.ToLower());

        }
    }
}