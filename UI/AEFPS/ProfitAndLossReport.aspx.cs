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
    public partial class ProfitAndLossReport : BasePage
    {
        int intWHID, intEnroll, intPart; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        DateTime dteFrom, dteTo;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\ProfitAndLossReport";
        string stop = "stopping AEFPS\\ProfitAndLossReport";
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
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvProfitLoss.DataSource = "";
            dgvProfitLoss.DataBind();
        }
        protected decimal costvalue = 0;
        protected decimal salesvalue = 0;
        protected decimal profit = 0;
        protected decimal loss = 0;
        protected decimal netprofit = 0;
        protected void dgvProfitLoss_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    costvalue += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblCostValue")).Text);
                    salesvalue += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalValue")).Text);
                    profit += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblProfit")).Text);
                    loss += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblLoss")).Text);
                    netprofit += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblPEarned")).Text);
                }
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\ProfitAndLossReport Profit and Loass", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dgvProfitLoss.DataSource = "";
                dgvProfitLoss.DataBind();

                intPart = 6;
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFrom.Text.ToString());
                dteTo = DateTime.Parse(txtTo.Text.ToString());
                intEnroll = 0;

                dt = new DataTable();
                dt = bll.GetSales(intPart, intWHID, dteFrom, dteTo, intEnroll, true);
                dgvProfitLoss.DataSource = dt;
                dgvProfitLoss.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblReportDate.Text = "Report Precessed On : " + DateTime.Now.ToShortDateString();
                    lblReportName.Text = "Profit & Loss Report From " + DateTime.Parse(txtFrom.Text).ToShortDateString() + " To " + DateTime.Parse(txtTo.Text).ToShortDateString();
                    lblReportDate.Visible = true;
                    lblWHName.Text = ddlWH.SelectedItem.ToString();
                    lblWHName.Visible = true;
                    lblReportName.Visible = true;
                }
                else
                {
                    lblReportDate.Visible = false;
                    lblWHName.Visible = false;
                    lblReportName.Visible = false;
                }
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