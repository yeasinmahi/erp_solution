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
    public partial class SalesReport : BasePage
    {
        int intWHID, intEnroll, intPart; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        DateTime dteFrom, dteTo;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\SalesReport";
        string stop = "stopping AEFPS\\SalesReport";

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
            var tracker = new PerfTracker("Performance on AEFPS\\SalesReport Sales Report Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dgvSales.DataSource = "";
                dgvSales.DataBind();

                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFrom.Text.ToString());
                dteTo = DateTime.Parse(txtTo.Text.ToString());

                if (txtEnroll.Text == "")
                {
                    intEnroll = 0;
                    intPart = 1;
                }
                else
                {
                    intEnroll = int.Parse(txtEnroll.Text);
                    intPart = 2;
                }

                dt = new DataTable();
                dt = bll.GetSales(intPart, intWHID, dteFrom, dteTo, intEnroll, true);
                dgvSales.DataSource = dt;
                dgvSales.DataBind();

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
            dgvSales.DataSource = "";
            dgvSales.DataBind();
        }

        protected decimal totalcash = 0;
        protected decimal totalcredit = 0;
        protected decimal totalamount = 0;

        protected void dgvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalcash += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblCashSales")).Text);
                    totalcredit += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblCreditSales")).Text);
                    totalamount += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblTotalSales")).Text);
                }
            }
            catch { }
        }

    }
}