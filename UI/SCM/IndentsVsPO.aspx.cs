using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class IndentsVsPO : BasePage
    {
        private Indents_BLL objIndent = new Indents_BLL();

        private DataTable dt = new DataTable();
        private int intwh;
        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\IndentsVsPO";
        private string stop = "stopping SCM\\IndentsVsPO";
        private string perform = "Performance on SCM\\IndentsVsPO";
        private DateTime dteFrom;
        private DateTime dteTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dteFrom = DateTime.Now.AddMonths(-1);
                dteTo = DateTime.Now;
                txtDteFrom.Text = dteFrom.ToString("yyyy-MM-dd");
                txtdteTo.Text = dteTo.ToString("yyyy-MM-dd");

                dt = objIndent.DataView(1, "", 0, 0, DateTime.Now, Enroll);
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
                intwh = int.Parse(ddlWH.SelectedValue);

                try
                {
                    dteFrom = DateTime.Parse(txtDteFrom.Text);
                    dteTo = DateTime.Parse(txtdteTo.Text);
                }
                catch (Exception exception)
                {
                    Alert("Date format problem");
                    return;
                }

                int sortBy = int.Parse(ddlSortBy.SelectedValue);
                string dept = ddlType.SelectedItem.ToString();

                dt = objIndent.GetIndentVsPo(intwh, dteFrom, dteTo, dept, sortBy);
                dgvStatement.DataSource = dt;
                dgvStatement.DataBind();
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