using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class InventoryReport : BasePage
    {
        int intWHID, intEnroll, intPayType; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL();
        DateTime dteFrom, dteTo;
        
        Receive_BLL objRec = new Receive_BLL();
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\InventoryReport";
        string stop = "stopping AEFPS\\InventoryReport";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                    dt = objRec.DataView(1, "", 0, 0, DateTime.Now, intEnroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                    

                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\InventoryReport inventory Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFrom.Text.ToString());
                dteTo = DateTime.Parse(txtTo.Text.ToString());

                dt = new DataTable();
                dt = bll.GetInventory(intWHID, dteFrom, dteTo);
                if (dt.Rows.Count > 0)
                {
                    dgvInventory.DataSource = dt;
                    dgvInventory.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data.');", true); dgvInventory.DataSource = ""; dgvInventory.DataBind(); }
                   }
            catch (Exception ex)
            {

            var efd = log.GetFlogDetail(stop, location, "Submit", ex);
            Flogger.WriteError(efd);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something went wrong.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();


        }

protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvInventory.DataSource = "";
                dgvInventory.DataBind();
            }
            catch { }
        }
        
    }
}