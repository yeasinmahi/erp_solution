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
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using HR_BLL.Settlement;

namespace UI.Support
{
    public partial class CertificateReceiveDeliveryReport : System.Web.UI.Page
    {
        Support_BLL.SupportBLL obj = new Support_BLL.SupportBLL();
        DataTable dt;

        int intPart;
        DateTime fdate, tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                RadioButton1.Checked = true;
            }
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
            dgvReport.DataSource = ""; dgvReport.DataBind();
            System.Threading.Thread.Sleep(1500);
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = "AKIJ GROUP";
                lblReportName.Text = "CERTIFICATE RECEIVED & DELIVERY REPORT";
                lblFromToDate.Text = "Joining Date Between " + Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MMM-dd") + " To " + Convert.ToDateTime(txtTDate.Text).ToString("yyyy-MMM-dd");

                if(RadioButton1.Checked == true) { intPart = 1; }
                else if (RadioButton2.Checked == true) { intPart = 2; }
                else if (RadioButton3.Checked == true) { intPart = 3; }
                
                fdate = DateTime.Parse(txtFDate.Text);
                tdate = DateTime.Parse(txtTDate.Text);

                dt = new DataTable();
                dt = obj.GetRecReportAll(intPart, fdate, tdate);
                if (dt.Rows.Count > 0) { dgvReport.DataSource = dt; dgvReport.DataBind(); }
                else { dgvReport.DataSource = ""; dgvReport.DataBind(); }
            }
            catch { }
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }
        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();
        }







    }
}