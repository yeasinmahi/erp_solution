using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using UI.ClassFiles;
using HR_BLL.Dispatch;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Dispatch
{
    public partial class rptDispatch : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Dispatch/rptDispatch.aspx";
        string stop = "stopping HR/Dispatch/rptDispatch.aspx";

        DispatchBLL objdp = new DispatchBLL();
        DataTable dt;

        string fdate; string tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatch.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try 
                { 
                    pnlUpperControl.DataBind(); txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "LoadGrid", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatch.aspx LoadGrid", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                fdate = txtFromDate.Text;
                tdate = txtToDate.Text;
                
                dt = new DataTable();
                dt = objdp.GetDispatchR(fdate, tdate);
                dgvReport.DataSource = dt; 
                dgvReport.DataBind();
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "LoadGrid", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnDslVew_Click(object sender, CommandEventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);
            }
            catch { }
        }













    }
}