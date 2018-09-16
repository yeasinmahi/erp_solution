using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Accounts.Report
{
    public partial class SubledgerDetalis : System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Report\\SubledgerDetalis";
        string stop = "stopping Accounts\\Report\\SubledgerDetalis";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
     
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Report\\SubledgerDetalis   Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Ruhul/Binti/Ledger%20Data%20Report%20for%20Account?rs:Embed=true');", true);
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