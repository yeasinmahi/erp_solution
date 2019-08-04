using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
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
            int whId = ddlWh.SelectedValue();
            string path = Path.Combine("/Content/images/img", whId + ".png");
            //if (!File.Exists(path))
            //{
            //    path = Path.Combine("/Content/images/img", "ag.png");
            //}
            imgUnit.ImageUrl = path;

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
                LoadMasterCategory();
                LoadImage();
                LoadSubCategory();
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
        

        
        public void LoadCostCenter()
        {
            int whId = ddlWh.SelectedValue();
            _dt = _bll.GetViewData(4, "", whId, 0, DateTime.Now, Enroll);
            ddlCostCenter.LoadWithAll(_dt, "Id", "strName");
        }
        public void LoadDepartment()
        {
            _intwh = ddlWh.SelectedValue();
            _dt = _bll.GetDepartment(_intwh);
            ddlDepartment.LoadWithSelect(_dt, "Id", "strName");
        }
        public void LoadSection()
        {
            int whId = ddlWh.SelectedValue();
            _dt = _bll.GetViewData(10, "", whId, 0, DateTime.Now, Enroll);
            ddlSection.LoadWithSelect(_dt, "Id", "strName");
        }
        public void LoadMasterCategory()
        {
            _dt = _bll.GetViewData(20, "", 0, 0, DateTime.Now, Enroll);
            ddlMasterCategory.LoadWithSelect(_dt, "Id", "strName");
        }
        public void LoadMinorCategory()
        {
            _dt = _bll.GetViewData(21, "", 0, 0, DateTime.Now, Enroll);
            ddlMinorCategory.LoadWithSelect(_dt, "Id", "strName");
        }
        public void LoadSubCategory()
        {
            _dt = _bll.GetViewData(22, "", 0, 0, DateTime.Now, Enroll);
            ddlSubCategory.LoadWithSelect(_dt, "Id", "strName");
        }

        public void LoadWh()
        {
            _dt = _bll.GetViewData(1, "", 0, 0, DateTime.Now, Enroll);
            ddlWh.Loads(_dt, "Id", "strName");

        }


        protected void btnDept_OnClick(object sender, EventArgs e)
        {
            int id = ddlDepartment.SelectedValue();
            if (id == 0)
            {
                Toaster("Please select department first", Common.TosterType.Warning);
                return;
            }


            LoadReport(2, id);
            //LoadGridView(2, id);
        }

        protected void btnSection_OnClick(object sender, EventArgs e)
        {
            int id = ddlSection.SelectedValue();
            if (id == 0)
            {
                Toaster("Please select section first", Common.TosterType.Warning);
                return;
            }
            LoadReport(1, id);
            //LoadGridView(1, id);
        }

        protected void btnCostCenter_OnClick(object sender, EventArgs e)
        {
            int id = ddlCostCenter.SelectedValue();
            LoadReport(3, id);
            //LoadGridView(3, id);
        }
        
        protected void btnMasterCategory_OnClick(object sender, EventArgs e)
        {
            int id = ddlMasterCategory.SelectedValue();
            if (id == 0)
            {
                Toaster("Please select master category first", Common.TosterType.Warning);
                return;
            }
            LoadReport(4, id);
            //LoadGridView(4, id);
        }
        public void LoadReport(int part, int id)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/SCM/Consumption_Report&part=" + part + "&whId=" + ddlWh.SelectedValue + "&fromDate=" + txtDteFrom.Text + "&toDate=" + txtdteTo.Text + "&id=" + id + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }
        protected void btnMinorCategory_OnClick(object sender, EventArgs e)
        {
            Toaster("Comming Soon",Common.TosterType.Warning);
        }

        protected void btnSubCategory_OnClick(object sender, EventArgs e)
        {
            Toaster("Comming Soon", Common.TosterType.Warning);
        }
        public void LoadGridView(int part, int id)
        {
            try
            {
                int whId = ddlWh.SelectedValue();

                if (DateTime.TryParse(txtDteFrom.Text, out DateTime fromDate))
                {
                    if (DateTime.TryParse(txtdteTo.Text, out DateTime toDate))
                    {
                        DataTable dt = _bll.GetConsumerReport(part, whId, fromDate, toDate, id);
                        if (dt.Rows.Count > 0)
                        {
                            gridView.DataSource = dt;
                            gridView.DataBind();
                        }
                        else
                        {
                            Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                        }
                    }
                    else
                    {
                        // to date
                        Toaster("To "+Message.DateFormatError, Common.TosterType.Warning);
                    }
                }
                else
                {
                    // from date
                    Toaster("From " + Message.DateFormatError, Common.TosterType.Warning);
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
            

        }

       
    }
}