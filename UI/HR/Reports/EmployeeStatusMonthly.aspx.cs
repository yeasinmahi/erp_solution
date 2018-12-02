using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Data;
using Microsoft.Reporting.WebForms;
using HR_BLL.Reports;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeStatusMonthly : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Common_Reports/HR/EmployeeMonthLyStatus?rs:Embed=true');", true);
        }
    }
}