using BLL.AutoSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Web.Services;

namespace UI.HR.Reports
{
    public partial class EmployeeServiceInformation : BasePage
    {
        public static EmployeeBll employeeBll = new EmployeeBll();
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
                        EmpID = Convert.ToInt32(arrayKey[1].ToString());
                    }
                }
            }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string url;
            bool gratuity = false;

            if(ddlBenifit.SelectedItem.Value == "true")
            {
                gratuity = true;
            }
            else
            {
                gratuity = false;
            }

            url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/AFBL/HR/Employee_Service_Information"+ "&sessionEnroll=" + Enroll + "&intEnroll=" + EmpID + "&dteDate=" + txtDate.Text + "&ysnGratuity=" + gratuity + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }


        [WebMethod]
        public static string[] GetAutoCompleteData(string strSearchKey)
        {
            return employeeBll.GetAllEmployee(strSearchKey);
        }
    }
}