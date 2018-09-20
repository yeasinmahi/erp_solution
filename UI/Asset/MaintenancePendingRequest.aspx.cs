using Flogging.Core;
using GLOBAL_BLL;
using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class MaintenanceServiceRequest : System.Web.UI.Page
    {
        Report_BLL objReport = new Report_BLL();
        DataTable dt = new DataTable(); int intEnroll;
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\MaintenanceServiceRequest";
        string stop = "stopping Asset\\MaintenanceServiceRequest";
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Asset\\MaintenanceServiceRequest BtnIssue_Click", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    pnlUpperControl.DataBind();
                intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                
                dt = objReport.GetData(4, "", 0, 0, DateTime.Now, DateTime.Now, 0, intEnroll); //change in loginProcess
                ddlJobStation.DataSource = dt;
                ddlJobStation.DataTextField = "strName";
                ddlJobStation.DataValueField = "Id";
                ddlJobStation.DataBind();
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

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\MaintenanceServiceRequest Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
				int jobstation = int.Parse(ddlJobStation.SelectedItem.Value.ToString());
				string strJobStation = ddlJobStation.SelectedItem.Text;
				DateTime fromdate = DateTime.Parse(txtFormDate.Text);
				DateTime toDate = DateTime.Parse(txtToDate.Text);
				lbldate.Text = "From " + DateTime.Parse(txtFormDate.Text).ToString("yyyy-MM-dd") + " To " + DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd"); ;
				dt = objReport.GetData(6, "", 4, jobstation, fromdate, toDate, 0, intEnroll);
				GVMaintenanceReport.DataSource = dt;
				GVMaintenanceReport.DataBind();
			}
			catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}

			fd = GetFlogDetail("stopping Asset\\MaintenancePendingRequest Show", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();
		}

		private FlogDetail GetFlogDetail(string message, Exception ex)
		{
			return new FlogDetail
			{
				Product = "ERP",
				Location = "Asset",
				Layer = "Maintenance Pending Request\\Show",
				UserName = Environment.UserName,
				Hostname = Environment.MachineName,
				Message = message,
				Exception = ex
			};
		}
	}
}