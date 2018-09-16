using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.Accounts.MDSlip;
using Flogging.Core;
using GLOBAL_BLL;
using UI.ClassFiles;
namespace UI.Accounts.MDSlip
{
    public partial class MDSlipRequestHandler : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\MDSlip\\MDSlipRequestHandler";
        string stop = "stopping Accounts\\MDSlip\\MDSlipRequestHandler";
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\MDSlip\\MDSlipRequestHandler   PageLoad ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                string requestDateForMDSlip = Request.QueryString["rdate"];
            string unitID = Request.QueryString["unit"];
            string userID = "" + Session[SessionParams.USER_ID];

            MDSlipRequst req = new MDSlipRequst();

            int? waitTimeinSeconds = null;
            req.InsertMDSlipRequest(unitID, userID, requestDateForMDSlip, ref waitTimeinSeconds);
            string jsString = "<script type=\"text/javascript\">";
            jsString = jsString + "parent.ShowStatus(" + waitTimeinSeconds + ")";
            jsString = jsString + "</script>";

            Response.Write(jsString);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
    }
}
