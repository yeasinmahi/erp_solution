using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class SalesCollectonReport : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Advice\\SalesCollectonReport";
        string stop = "stopping Accounts\\Advice\\SalesCollectonReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { //pnlUpperControl.DataBind(); 
            }
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Advice\\SalesCollectonReport Collection Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Accounts/Sales_Collection?rs:Embed=true');", true);
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