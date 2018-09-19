using Dairy_BLL;
using HR_BLL.Cafeteria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Cafeteria
{
    public partial class CafeteriaSummaryR : Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Cafeteria/CafeteriaSummaryR.aspx";
        string stop = "stopping HR/Cafeteria/CafeteriaSummaryR.aspx";

        GlobalBLL obj = new GlobalBLL(); DataTable dt;

        int intPart, intRptType;
        DateTime fdate, tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Cafeteria/CafeteriaSummaryR.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string html = HdnValue.Value;
            ExportToExcel(ref html, "MyReport");
        }
        public void ExportToExcel(ref string html, string fileName)
        {
            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Cafeteria/CafeteriaSummaryR.aspx btnShow_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            dgvReport.DataSource = ""; dgvReport.DataBind();
            System.Threading.Thread.Sleep(1500);
            LoadGrid();

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected decimal tqtyown = 0;
        protected decimal tqtyguest = 0;
        protected decimal tqtytotal = 0;
        protected decimal ttkown = 0;
        protected decimal ttkcom = 0;
        protected decimal tgtk = 0;
        protected decimal ttktotal = 0;

        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    tqtyown += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblOwn")).Text);
                    tqtyguest += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblGuest")).Text);
                    tqtytotal += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblTotal")).Text);
                    ttkown += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblOwnTk")).Text);
                    ttkcom += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblCompanyPay")).Text);
                    tgtk += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblGTK")).Text);
                    ttktotal += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblTotalTk")).Text);
                }
            }
            catch { }
        }

        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = "AKIJ GROUP";
                lblReportName.Text = "CAFETERIA SUMMARY REPORT";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtTDate.Text).ToString("yyyy-MM-dd");

                intPart = 2;
                fdate = DateTime.Parse(txtFDate.Text);
                tdate = DateTime.Parse(txtTDate.Text);
                intRptType = 1;
                dt = new DataTable();
                dt = obj.GetCafeteriaRAll(intPart, fdate, tdate, intRptType);
                if (dt.Rows.Count > 0) { dgvReport.DataSource = dt; dgvReport.DataBind(); }
                else { dgvReport.DataSource = ""; dgvReport.DataBind(); }
            }
            catch { }
        }






























    }
}