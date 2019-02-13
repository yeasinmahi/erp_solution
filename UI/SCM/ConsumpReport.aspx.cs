using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ConsumpReport : BasePage
    {
        private readonly StoreIssue_BLL _bll = new StoreIssue_BLL();
        private DataTable _dt = new DataTable();
        private int _intwh;

        private readonly SeriLog _log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ConsumpReport";
        private string stop = "stopping SCM\\ConsumpReport";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWh();
                GetDefaultLoad();
                
            }
        }

        public void LoadImage()
        {
            int whId = Common.GetDdlSelectedValue(ddlWh);
            imgUnit.ImageUrl = Path.Combine("/Content/images/img", whId + ".png");

        }
        private void GetDefaultLoad()
        {
            var fd = _log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\ConsumpReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                //  ddlSection.Items.Insert(0, new ListItem("Select", ""));
                //dt = _bll.GetViewData(9, "", 0, 0, DateTime.Now, Enroll);
                //ddlFilter.DataSource = dt;
                //ddlFilter.DataValueField = "Id";
                //ddlFilter.DataTextField = "strName";
                //ddlFilter.DataBind();

                //intwh = int.Parse(ddlWh.SelectedValue.ToString());
                //intwh=Common.GetDdlSelectedValue(ddlWh);

                //_dt = _bll.GetDepartment(intwh);
                //Common.LoadDropDownWithSelect(ddlFilter, _dt, "Id", "strName");

                
                //_dt = _bll.GetViewData(10, "", intwh, 0, DateTime.Now, Enroll);
                //Common.LoadDropDownWithSelect(ddlSection, _dt, "Id", "strName");
                // ddlSection.Items.Insert(0, new ListItem("Select", ""));
                //ddlSection.DataSource = dt;
                //ddlSection.DataValueField = "Id";
                //ddlSection.DataTextField = "strName";
                //ddlSection.DataBind();

                LoadDepartment();
                LoadSection();
                LoadCostCenter();
                LoadImage();
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                GetDefaultLoad();
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                Toaster(ex.Message,Common.TosterType.Error);
            }

            fd = _log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\ConsumpReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int sectionId = Common.GetDdlSelectedValue(ddlSection);
                if (sectionId == 0)
                {
                    Toaster("Please Select Section First",Common.TosterType.Warning);
                    return;
                }
                string dept = Common.GetDdlSelectedText(ddlSection);
                _intwh = Common.GetDdlSelectedValue(ddlWh);

                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);

                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";
                
                _dt = _bll.GetViewData(12, xmlData, _intwh, sectionId, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    dgvConsump.DataSource = _dt;
                    dgvConsump.DataBind();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
                }
                
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        
        
        protected void btnFilterDept_Click(object sender, EventArgs e)
        {
            var fd = _log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\PoRegisterReport Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int deptId = Common.GetDdlSelectedValue(ddlFilter);
                if (deptId == 0)
                {
                    Toaster("Please select department first",Common.TosterType.Warning);
                    return;
                }
                string dept = ddlFilter.SelectedItem.ToString();
                _intwh = int.Parse(ddlWh.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                string xmlData = "<voucher><voucherentry dteTo=" + '"' + dteTo + '"' + " dteFrom=" + '"' + dteFrom + '"' + " dept=" + '"' + dept + '"' + "/></voucher>";

                _dt = _bll.GetViewData(11, xmlData, _intwh, deptId, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    dgvConsump.DataSource = _dt;
                    dgvConsump.DataBind();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                var efd = _log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = _log.GetFlogDetail(stop, location, "Show", null);
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
            _dt = _bll.GetViewData(4, "", whId, 0, DateTime.Now, Enroll);
            Common.LoadDropDown(ddlCostCenter, _dt, "Id", "strName");
        }
        public void LoadDepartment()
        {
            _intwh = Common.GetDdlSelectedValue(ddlWh);
            _dt = _bll.GetDepartment(_intwh);
            Common.LoadDropDownWithSelect(ddlFilter, _dt, "Id", "strName");
        }
        public void LoadSection()
        {
            int whId = Common.GetDdlSelectedValue(ddlWh);
            _dt = _bll.GetViewData(10, "", whId, 0, DateTime.Now, Enroll);
            Common.LoadDropDownWithSelect(ddlSection, _dt, "Id", "strName");
        }

        public void LoadWh()
        {
            _dt = _bll.GetViewData(1, "", 0, 0, DateTime.Now, Enroll);
            Common.LoadDropDown(ddlWh, _dt, "Id", "strName");

        }
    }
}