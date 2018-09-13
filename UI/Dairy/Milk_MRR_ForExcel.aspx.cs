using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Dairy
{
    public partial class Milk_MRR_ForExcel : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_MRR_ForExcel.aspx";
        string stop = "stopping Dairy/Milk_MRR_ForExcel.aspx";

        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; DateTime dteFrom; DateTime dteTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_MRR_ForExcel.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    //pnlUpperControl.DataBind();

                    dt = obj.GetUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                   
                }
                catch
                { }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_MRR_ForExcel.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dteFrom = DateTime.Parse(txtFromDate.Text);
                dteTo = DateTime.Parse(txtTo.Text); 
                 
                dt = new DataTable();
                dt = obj.GetMRReportForExecl(intUnitID, dteFrom, dteTo); 
                dgvMRReport.DataSource = dt;
                dgvMRReport.DataBind();

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

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMRReport.DataSource = "";
            dgvMRReport.DataBind();
        }

        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    string data = hdnData.Value;
        //    data = HttpUtility.UrlDecode(data);
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=ExcelData.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/excel";
        //    HttpContext.Current.Response.Write(data);
        //    HttpContext.Current.Response.Flush();
        //    HttpContext.Current.Response.End();
        //}

        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    Response.Clear();

        //    Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

        //    Response.Charset = "";

        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    Response.ContentType = "application/vnd.xls";

        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        //    divExport.RenderControl(htmlWrite);

        //    Response.Write(stringWrite.ToString());

        //    Response.End();

        //}














    }
}