using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using SAD_BLL.Corporate_sales;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Corporate_sales
{
    public partial class AFBLCorporateDistributor : System.Web.UI.Page
    {
        Bridge obj = new Bridge();
        DataTable dt = new DataTable();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Corporate_sales\\AFBLCorporateDistributor";
        string stop = "stopping SAD\\Corporate_sales\\AFBLCorporateDistributor";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Corporate_sales\\AFBLCorporateDistributor Distributor", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dt = obj.distributor();
                gvdistlist.DataSource = dt;
                gvdistlist.DataBind();
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