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
    public partial class CreditReport : BasePage
    {
        int intWHID, intEnroll; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\CreditReport";
        string stop = "stopping AEFPS\\CreditReport";

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
            dgvCreditReport.DataSource = "";
            dgvCreditReport.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\CreditReport Credit Report Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetCreditReport(intWHID);
                dgvCreditReport.DataSource = dt;
                dgvCreditReport.DataBind();
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
        protected decimal totalamount = 0;
        protected void dgvCreditReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblDue")).Text);
                }
            }
            catch { }
        }
    }
}