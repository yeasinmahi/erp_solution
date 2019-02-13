using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.Web;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ConsumpReport : BasePage
    {
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
        private Location_BLL objOperation = new Location_BLL();
        private DataTable dt = new DataTable();
        private int intwh;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ConsumpReport";
        private string stop = "stopping SCM\\ConsumpReport";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, Enroll);

                ddlWh.DataSource = dt;
                ddlWh.DataValueField = "Id";
                ddlWh.DataTextField = "strName";
                ddlWh.DataBind();
                getDefaultLoad();
            }
            else
            {
            }
        }

        private void getDefaultLoad()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\ConsumpReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                //  ddlSection.Items.Insert(0, new ListItem("Select", ""));
                //dt = objIssue.GetViewData(9, "", 0, 0, DateTime.Now, Enroll);
                //ddlFilter.DataSource = dt;
                //ddlFilter.DataValueField = "Id";
                //ddlFilter.DataTextField = "strName";
                //ddlFilter.DataBind();

                //intwh = int.Parse(ddlWh.SelectedValue.ToString());
                intwh=Common.GetDdlSelectedValue(ddlWh);

                dt = objIssue.GetDepartment(intwh);
                Common.LoadDropDown(ddlFilter, dt, "Id", "strName");

                
                dt = objIssue.GetViewData(10, "", intwh, 0, DateTime.Now, Enroll);

                // ddlSection.Items.Insert(0, new ListItem("Select", ""));
                ddlSection.DataSource = dt;
                ddlSection.DataValueField = "Id";
                ddlSection.DataTextField = "strName";
                ddlSection.DataBind();

                LoadCostCenter();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\ConsumpReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string dept = ddlSection.SelectedItem.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                int deptId = int.Parse(ddlSection.SelectedValue.ToString());
                dt = objIssue.GetViewData(12, xmlData, intwh, deptId, DateTime.Now, Enroll);
                dgvConsump.DataSource = dt;
                dgvConsump.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                getDefaultLoad();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnFilterDept_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int deptId = int.Parse(ddlFilter.SelectedValue.ToString());
                string dept = ddlFilter.SelectedItem.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(txtdteTo.Text.ToString());
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>".ToString();
                dt = objIssue.GetViewData(11, xmlData, intwh, deptId, DateTime.Now, Enroll);
                dgvConsump.DataSource = dt;
                dgvConsump.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShowCostCenter_OnClick(object sender, EventArgs e)
        {
            //int whId = Common.GetDdlSelectedValue(ddlWh);
            //int ccId = Common.GetDdlSelectedValue(ddlCostCenter);
            //DateTime fromDate = Convert.ToDateTime(txtDteFrom.Text);
            //DateTime toDate = Convert.ToDateTime(txtdteTo.Text);

            //DataTable dt = new StoreIssue_BLL().GetConsumerStatementByCostCenterId(whId, fromDate, toDate, ccId);

            Toaster("Comming soon",Common.TosterType.Warning);

        }

        public void LoadCostCenter()
        {
            int whId = Common.GetDdlSelectedValue(ddlWh);
            DataTable dt = new StoreIssue_BLL().GetViewData(4, "", whId, 0, DateTime.Now, Enroll);
            Common.LoadDropDown(ddlCostCenter, dt, "Id", "strName");
        }
    }
}