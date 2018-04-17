using Dairy_BLL;
using SAD_BLL.Transport;
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
using HR_BLL.Settlement;

namespace UI.HR.Insurance
{
    public partial class InsuranceDateRangeReport : BasePage
    {
        GlobalClass obj = new GlobalClass(); DataTable dt;
        InternalTransportBLL objunit = new InternalTransportBLL();

        int intPart, intUnitID, intJobStationID, intAll;
        DateTime dteFrom, dteTo;         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                //pnlUpperControl.DataBind();
                txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string html = HdnValue.Value;
            ExportToExcel(ref html, "InsuranceReport");
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
            dgvDependant.DataSource = ""; dgvDependant.DataBind();
        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDependant.DataSource = ""; dgvDependant.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            dgvDependant.DataSource = ""; dgvDependant.DataBind();
            System.Threading.Thread.Sleep(1500);
            LoadGrid();
        }
        protected void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoActive.Checked == true)
            {
                rdoInactive.Checked = false;
            }
            else { rdoActive.Checked = true; }
        }

        protected void rdoInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInactive.Checked == true)
            {
                rdoActive.Checked = false;
            }
            else { rdoInactive.Checked = true; }
        }
        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = "AKIJ GROUP";
                lblReportName.Text = "INSURANCE REPORT";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtTDate.Text).ToString("yyyy-MM-dd");

                intPart = 1;
                try
                {
                    dteFrom = DateTime.Parse(txtFDate.Text);
                    dteTo = DateTime.Parse(txtTDate.Text);
                }
                catch { }

                if (rdoActive.Checked == true) { intPart = 1; }
                else if (rdoInactive.Checked == true) { intPart = 2; }
                try
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                }
                catch { }
                if(cbAll.Checked == true) { intAll = 1; } else { intAll = 0; }

                dt = new DataTable();
                dt = obj.GetDateRangeReport(intPart, intUnitID, intJobStationID, intAll, dteFrom, dteTo);
                if (dt.Rows.Count > 0) { dgvDependant.DataSource = dt; dgvDependant.DataBind(); }
                else { dgvDependant.DataSource = ""; dgvDependant.DataBind(); }
            }
            catch { }
        }

























    }
}