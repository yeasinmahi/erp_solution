using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Sales.Report
{
    public partial class Invoice_Print_Report : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnit();
            }
        }

        private void LoadUnit()
        {
            dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            ddlCustomer.Loads(dt, "intUnitID", "strUnit");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string CustomerID = ddlCustomer.SelectedItem.Value;
            string FromDate = txtFromDate.Text;
            string ToDate = txtToDate.Text;
            LoadReport(CustomerID, FromDate, ToDate);
        }

        private void LoadReport(string CustomerID, string FromDate, string ToDate)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/Invoice_Print" + "&intcustid=" + CustomerID + "&fromdate=" + FromDate + "&todate=" + ToDate + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

    }
}