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
    public partial class ShortDatedItemsReport : BasePage
    {
        int intWHID, intEnroll, intType; DataTable dt = new DataTable(); FPReportBLL bll = new FPReportBLL();
        Receive_BLL objRec = new Receive_BLL();
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\ShortDatedItemsReport";
        string stop = "stopping AEFPS\\ShortDatedItemsReport";


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
            var tracker = new PerfTracker("Performance on AEFPS\\ShortDatedItemsReport Short Date Item Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                intType = int.Parse(ddlType.SelectedValue.ToString());

                dt = new DataTable();
                if (intType == 1)
                {
                    dt = bll.GetShortDatedItem(intWHID);
                    dgvShortDated.DataSource = dt;
                    dgvShortDated.DataBind();
                    lblReportName.Text = "Short Dated Items List";
                }
                else if (intType == 2)
                {
                    dt = bll.GetExpiredItem(intWHID);
                    dgvShortDated.DataSource = dt;
                    dgvShortDated.DataBind();
                    lblReportName.Text = "Date Expired Items List";
                }
                if (dt.Rows.Count > 0)
                {
                    lblReportDate.Text = "Report Precessed On : " + DateTime.Now.ToShortDateString();
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
            dgvShortDated.DataSource = "";
            dgvShortDated.DataBind();
            lblReportDate.Visible = false;
            lblWHName.Visible = false;
            lblReportName.Visible = false;
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvShortDated.DataSource = "";
            dgvShortDated.DataBind();
            lblReportDate.Visible = false;
            lblWHName.Visible = false;
            lblReportName.Visible = false;
        }
    }
}