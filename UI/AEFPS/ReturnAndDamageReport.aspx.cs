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
    public partial class ReturnAndDamageReport : System.Web.UI.Page
    {
        int intWHID, intEnroll, intPart; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        DateTime dteFrom, dteTo; string strRepotDate; bool ysnEnable;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\ReturnAndDamageReport";
        string stop = "stopping AEFPS\\ReturnAndDamageReport";
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
            var tracker = new PerfTracker("Performance on AEFPS\\ReturnAndDamageReport Return And Damage Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dgvSalesReturn.DataSource = "";
                dgvSalesReturn.DataBind();

                intPart = int.Parse(ddlType.SelectedValue.ToString());
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFrom.Text.ToString());
                dteTo = DateTime.Parse(txtTo.Text.ToString());
                intEnroll = 0;
                ysnEnable = true;

                dt = new DataTable();
                dt = bll.GetSales(intPart, intWHID, dteFrom, dteTo, intEnroll, ysnEnable);
                dgvSalesReturn.DataSource = dt;
                dgvSalesReturn.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblReportDate.Text = "Report Precessed On : " + DateTime.Now.ToShortDateString();
                    lblReportName.Text = ddlType.SelectedItem.ToString() + " Report From " + DateTime.Parse(txtFrom.Text).ToShortDateString() + " To " + DateTime.Parse(txtTo.Text).ToShortDateString();
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
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSalesReturn.DataSource = "";
            dgvSalesReturn.DataBind();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSalesReturn.DataSource = "";
            dgvSalesReturn.DataBind();
        }
        
        protected decimal totalamount = 0;

        protected void dgvSalesReturn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblTotalValue")).Text);
                }
            }
            catch { }
        }
    }
}