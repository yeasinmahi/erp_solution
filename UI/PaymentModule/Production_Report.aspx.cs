using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Data;

namespace UI.PaymentModule
{
    public partial class Production_Report : BasePage
    {
        private DataTable dt = new DataTable();
        private InventoryTransfer_BLL objbll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    int enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
                    dt = new MrrReceive_BLL().DataView(19, "", 0, 0, DateTime.Now, enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string fromTime = txtFormTime.Text;
            string toTime = txtToTime.Text;



            string url;
            if (string.IsNullOrWhiteSpace(fromTime) || string.IsNullOrWhiteSpace(toTime))
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Payment/Production_Report" + "&wh=" + ddlWH.SelectedItem.Value + "&intUnit=" + ddlWH.SelectedItem.Value + "&fTime=" + txtFromDate.Text + "&tTime=" + txtToDate.Text + "&rc:LinkTarget=_self";
            }
            else
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Payment/Production_Report" + "&wh=" + ddlWH.SelectedItem.Value + "&intUnit=" + ddlWH.SelectedItem.Value + "&fTime=" + txtFromDate.Text + " " + fromTime + "&tTime=" + txtToDate.Text + " " + toTime + "&rc:LinkTarget=_self";
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }
    }
}