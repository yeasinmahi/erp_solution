using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class StockReport : BasePage
    {
        int intWHID, intEnroll, intPayType; DataTable dt; FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        string strFrom, strTo;

        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\StockReport";
        string stop = "stopping AEFPS\\StockReport";

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
            var tracker = new PerfTracker("Performance on AEFPS\\StockReport Stock Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetStockReport(intWHID);
                dgvStock.DataSource = dt;
                dgvStock.DataBind();
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
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = "";
            dgvStock.DataBind();
        }
        protected decimal totalvalue = 0;
        protected void dgvReceive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblTotalValue")).Text);
                }
            }
            catch { }
        }
    }
}