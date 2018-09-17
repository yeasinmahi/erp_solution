using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.IHB;

namespace UI.SAD.IHB
{
    public partial class DistributorWithIhbReport : System.Web.UI.Page
    {
        private DistributorWithIhbBll _bll = new DistributorWithIhbBll();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\IHB\\DistributorWithIhbReport";
        string stop = "stopping SAD\\IHB\\DistributorWithIhbReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            LoadGreadView();
        }

        private void LoadGreadView()
        {

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on   SAD\\IHB\\DistributorWithIhbReport Distributro IHB Report show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                grdvDistributorWithIhb.DataSource = _bll.GetDistributorWithIhbReport();
            grdvDistributorWithIhb.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
    }
}