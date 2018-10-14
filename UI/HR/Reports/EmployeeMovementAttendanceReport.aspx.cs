using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Reports
{
    public partial class EmployeeMovementAttendanceReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Ruhul/Binti/Brand%20Stock%20Report?rs:Embed=true');", true);

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Ruhul/Binti/MovementAttendance&dteDate=" + txtAuditDate.Text+ "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '"+url+"');", true);
            

        }


    }
}