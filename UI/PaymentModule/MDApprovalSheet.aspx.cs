using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.PaymentModule
{
    public partial class MDApprovalSheet : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        SeriLog log = new SeriLog();
        string location = "PaymentModule";
        string start = "starting PaymentModule/MDApprovalSheet.aspx";
        string stop = "stopping PaymentModule/MDApprovalSheet.aspx";

        Billing_BLL objBillReg = new Billing_BLL();
        Payment_All_Voucher_BLL obj = new Payment_All_Voucher_BLL();
        DataTable dt;

        int intUnitID, intType;
        DateTime dteFDate, dteTDate;
        #endregion ====================================================================================      

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MDApprovalSheet.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                if (!IsPostBack)
                {                    
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    dt = objBillReg.GetAllUnit();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "divVisibleFalse();", true);
                    lblReportName.Text = "STATEMENT OF PARTY BILL";
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Page_Load", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
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
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "btnExport_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/MDApprovalSheet.aspx btnExport_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
            
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intType = 2;
                dteFDate = DateTime.Parse(txtFromDate.Text);
                dteTDate = DateTime.Parse(txtToDate.Text);
                
                //lblUnitName.Text = ddlUnit.SelectedItem.ToString();
                dt = new DataTable();
                dt = obj.GetUnitAddress(intUnitID);
                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                }
                lblAddress.Text = "Akij House, 198 Bir Uttam Mir Shawkat Sarak, Tejgaon, Dhaka-1208";
                lblReportName.Text = "STATEMENT OF PARTY BILL";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");
                
                dt = obj.GetMDApprovalData(intUnitID, dteFDate, dteTDate, intType);
                if (dt.Rows.Count > 0)
                {
                    dgvMDApprovalSheet.DataSource = dt;
                    dgvMDApprovalSheet.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "divVisibleFalse();", true);
                }
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "btnExport_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetUnitAddress(intUnitID);
                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                }

                dgvMDApprovalSheet.DataSource = "";
                dgvMDApprovalSheet.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "divVisibleFalse();", true);
            }
            catch { }
        }
















    }
}