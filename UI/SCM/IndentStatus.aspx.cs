using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class IndentStatus : BasePage
    {
        private Indents_BLL objIndent = new Indents_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intwh, indentId;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IndentStatus";
        private string stop = "stopping SCM\\IndentStatus";
        private string perform = "Performance on SCM\\IndentStatus";
        private DateTime dteFrom, dteTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDteFrom.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                txtdteTo.Text = DateTime.Now.ToString("yyyy-MM-dd");

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIndent.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                dt = objIndent.DataView(11, "", 0, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
            }
            else { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnShow_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                try { indentId = int.Parse(txtIndentNo.Text); } catch { indentId = 0; }
                if (indentId == 0 && Common.GetDdlSelectedValue(ddlDept) < 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alertMessage", "alert('Please select Type');", true);
                    dgvStatement.UnLoad();
                    return;
                }
                dgvIndent.Visible = true;
                dgvStatement.Visible = false;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                try
                {
                    dteFrom = DateTime.Parse(txtDteFrom.Text);
                }
                catch
                {
                    dteFrom = DateTime.Now;
                }
                try
                {
                    dteTo = DateTime.Parse(txtdteTo.Text);
                }
                catch
                {
                    dteTo = DateTime.Now;
                }

                string dept = ddlDept.SelectedItem.ToString();

                dt = objIndent.GetDataIndentView(12, dept, indentId, dteFrom, dteTo, intwh);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblDueDate = row.FindControl("lblDueDate") as Label;
                Label lblIndentDate = row.FindControl("lblIndentDate") as Label;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                Label lblType = row.FindControl("lblType") as Label;
                string dteIndent = lblIndentDate.Text;
                string dteDue = lblDueDate.Text;
                string indentID = lblIndent.Text;
                string dept = lblType.Text;
                string whname = ddlWH.SelectedItem.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + dteIndent + "','" + dteDue.ToString() + "','" + indentID + "','" + dept + "','" + whname + "');", true);
            }
            catch { }
        }

        protected void btnStementDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblDueDate = row.FindControl("lblDueDate") as Label;
                Label lblIndentDate = row.FindControl("lblIndentDate") as Label;
                Label lblIndent = row.FindControl("lblIndent") as Label;
                Label lblType = row.FindControl("lblType") as Label;
                string dteIndent = lblIndentDate.Text;
                string dteDue = lblDueDate.Text;
                string indentID = lblIndent.Text;
                string dept = lblType.Text;
                string whname = ddlWH.SelectedItem.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + dteIndent + "','" + dteDue.ToString() + "','" + indentID + "','" + dept + "','" + whname + "');", true);
            }
            catch (Exception ex) { }
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                try { indentId = int.Parse(txtIndentNo.Text); } catch { indentId = 0; }
                if (indentId == 0 && Common.GetDdlSelectedValue(ddlDept) < 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alertMessage", "alert('Please select Type');", true);
                    dgvStatement.UnLoad();
                    return;
                }

                dgvIndent.Visible = false;
                dgvStatement.Visible = true;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intwh = int.Parse(ddlWH.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                string dept = ddlDept.SelectedItem.ToString();
                try { indentId = int.Parse(txtIndentNo.Text); } catch { indentId = 0; }

                //Code Stop By alamin@akij.net
                //dt = objIndent.DataView(13, xmlData, intwh, indentId, dteFrom, enroll);

                dt = objIndent.GetDataIndentView(13, dept, indentId, dteFrom, dteTo, intwh);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
            }
            catch (Exception ex) { }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIndent.Rows.Count > 0)
                {
                    dgvIndent.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("Indent.xls", dgvIndent);
                }
                else if (dgvStatement.Rows.Count > 0)
                {
                    dgvStatement.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("Indent.xls", dgvStatement);
                }
            }
            catch { }
        }
    }
}