using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales.Report
{
    public partial class CustomerWiseSalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
           
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromDate.Text))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select From Date');", true);
                return;
            }
            else if (string.IsNullOrEmpty(txtToDate.Text))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select To Date');", true);
                return;
            }

            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/CustomerWise_Sales_Report" + "&dteFrom=" + txtFromDate.Text + "&dteTo=" + txtToDate.Text + "&rc:LinkTarget=_self";

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }
    }
}