using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class CorrectiveRequestUserPopUP :BasePage
    {
        AssetMaintenance objUserRequest = new AssetMaintenance(); 
        DataTable dt = new DataTable();
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\CorrectiveRequestUserPopUP";
        string stop = "stopping Asset\\CorrectiveRequestUserPopUP";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Asset\\CorrectiveRequestUserPopUP Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    int Mnumber = int.Parse(Request.QueryString["ID"].ToString());
                //int Mnumber = 159933;
                dt = objUserRequest.CorrectiveUserRequestDetalisView(63, Mnumber, 0, 0, 0);//51 was before
                dgvView.DataSource = dt;
                dgvView.DataBind();
                dt.Clear();
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
}