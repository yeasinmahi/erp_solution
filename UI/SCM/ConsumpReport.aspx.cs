using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ConsumpReport : BasePage
    {
        StoreIssue_BLL objIssue = new StoreIssue_BLL();
        Location_BLL objOperation = new Location_BLL();
        DataTable dt = new DataTable();
        int enroll, intwh;


        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\ConsumpReport";
        string stop = "stopping SCM\\ConsumpReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(1, "", 0, 0, DateTime.Now, enroll);
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
               

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
              //  ddlSection.Items.Insert(0, new ListItem("Select", ""));
                dt = objIssue.GetViewData(9, "", 0, 0, DateTime.Now, enroll);
                ddlFilter.DataSource = dt;
                ddlFilter.DataValueField = "Id";
                ddlFilter.DataTextField = "strName";
                ddlFilter.DataBind();
                 

                dt = objIssue.GetViewData(10, "", 0, 0, DateTime.Now, enroll);
               // ddlSection.Items.Insert(0, new ListItem("Select", ""));
                ddlSection.DataSource = dt;
                ddlSection.DataValueField = "Id";
                ddlSection.DataTextField = "strName";
                ddlSection.DataBind();
                
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
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int deptId =int.Parse(ddlSection.SelectedValue.ToString());
                dt = objIssue.GetViewData(12, xmlData, intwh, deptId, DateTime.Now, enroll);
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
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIssue.GetViewData(11, xmlData, intwh, deptId, DateTime.Now, enroll);
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
    }
}