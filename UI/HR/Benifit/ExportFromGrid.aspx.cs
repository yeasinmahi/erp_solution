using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Benifit
{
    public partial class ExportFromGrid : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Benifit/ExportFromGrid.aspx";
        string stop = "stopping HR/Benifit/ExportFromGrid.aspx";

        HR_BLL.Benifit.Bonus_BLL bll = new HR_BLL.Benifit.Bonus_BLL();
        ExportToExcelClass cll = new ExportToExcelClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/ExportFromGrid.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {txtDteTo.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtDteFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");}
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExcell);

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Benifit/ExportFromGrid.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                DataTable dt = new DataTable();
                dt = bll.GetExcellProfile();
                dgvSummary.DataSource = dt; dgvSummary.DataBind();
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnExcell_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSummary.AllowPaging = false; dgvSummary.AllowSorting = false;
                ExportToExcelClass.Export("ExcellFile.xls", dgvSummary);
            }
            catch { }
        }
    }
}