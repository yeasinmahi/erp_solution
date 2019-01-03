using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IssueStatement : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();

        private DataTable dt = new DataTable();
        private int enroll, intwh, intIssue; private string[] arrayKey; private char[] delimiterChars = { '[', ']' }; private string strIssue;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IssueStatement";
        private string stop = "stopping SCM\\IssueStatement";
        private string perform = "Performance on SCM\\IssueStatement";

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStatement.DataSource = "";
                dgvStatement.DataBind();
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataValueField = "Id";
                ddlWH.DataTextField = "strName";
                ddlWH.DataBind();
            }
            else { }
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnStatement_Click", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnStatement_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                try { intIssue = int.Parse(txtIssueNo.Text.ToString()); } catch { intIssue = 0; }
                if (txtIssueNo.Text.Length > 2) { strIssue = txtIssueNo.Text.ToString(); } else { strIssue = "0".ToString(); }
                string xmlData = "<voucher><voucherentry dteFrom=" + '"' + dteFrom + '"' + " dteTo=" + '"' + dteTo + '"' + " strIssue=" + '"' + strIssue + '"' + " intIssue=" + '"' + intIssue + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(8, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvStatement.DataSource = dt;
                    dgvStatement.DataBind();
                }
                else
                {
                    dgvStatement.DataSource = null;
                    dgvStatement.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                }
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
    }
}