using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class MrrStatement : BasePage
    {
        private MrrReceive_BLL obj = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intWh, Mrrid;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\MrrStatement";
        private string stop = "stopping SCM\\MrrStatement";
        private string perform = "Performance on SCM\\MrrStatement";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDteFrom.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                txtdteTo.Text = DateTime.Now.ToString("yyyy-MM-dd");

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = obj.DataView(19, "", intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                dt = obj.DataView(2, "", intWh, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
            }
            else { }
        }

        protected void btnAttachment_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAttachment_Click Upload", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnAttachment_Click Upload", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblMrrId = row.FindControl("lblMrrId") as Label;

                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewdetails('" + MrrId + "');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnAttachment_Click Upload", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnAttachment_Click Uplaod", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnMRRSDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Common_Reports/MRR_Statement_Report?rs:Embed=true');", true);

        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnStatement_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnStatement_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Now.AddMonths(-1);
                DateTime dteTo = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(txtDteFrom.Text) && !string.IsNullOrWhiteSpace(txtdteTo.Text))
                {
                    dteFrom = DateTime.Parse(txtDteFrom.Text);
                    dteTo = DateTime.Parse(txtdteTo.Text);
                }

                string dept = ddlDept.SelectedItem.ToString();

                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                try
                {
                    Mrrid = int.Parse(txtMrrNo.Text);
                }
                catch
                {
                    Mrrid = 0;
                }
                dt = obj.DataView(12, xmlData, intWh, Mrrid, dteFrom, enroll);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnStatement_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnStatement_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnDetalis_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblMrrId = row.FindControl("lblMrrId") as Label;

                string MrrId = lblMrrId.Text;

                Session["MrrID"] = lblMrrId;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + MrrId + "');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDetalis_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDetalis_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}