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

namespace UI.HR.Cafeteria
{
    public partial class CafeteriaReport : Page
    {
        GlobalBLL obj = new GlobalBLL(); DataTable dt;
        InternalTransportBLL objunit = new InternalTransportBLL();

        int intPart, intRptType;
        DateTime fdate, tdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                //pnlUpperControl.DataBind();
                txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
                //dt = objunit.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                //ddlUnit.DataTextField = "strUnit";
                //ddlUnit.DataValueField = "intUnitID";
                //ddlUnit.DataSource = dt;
                //ddlUnit.DataBind();
                //ddlUnit.Items.Insert(0, new ListItem("All Unit", 0.ToString()));
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

        protected decimal tqtyown = 0;
        protected decimal tqtyguest = 0;
        protected decimal tqtytotal = 0;
        protected decimal ttkown = 0;
        protected decimal ttkcom = 0;
        protected decimal ttkguest = 0;
        protected decimal ttktotal = 0;

        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    tqtyown += decimal.Parse(((Label)e.Row.Cells[1].FindControl("lblOwn")).Text);
                    tqtyguest += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblGuest")).Text);
                    tqtytotal += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblTotal")).Text);
                    ttkown += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblOwnTk")).Text);
                    ttkcom += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblCompanyPay")).Text);
                    ttkguest += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblGuestTk")).Text);
                    ttktotal += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalTk")).Text);
                }
            }
            catch { }
        }

        protected void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                rdoPunch.Checked = false;
                rdoNonPunch.Checked = false;
            }
            else { rdoAll.Checked = true; }
        }

        protected void rdoPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPunch.Checked == true)
            {
                rdoAll.Checked = false;
                rdoNonPunch.Checked = false;
            }
            else { rdoPunch.Checked = true; }
        }

        protected void rdoNonPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNonPunch.Checked == true)
            {
                rdoAll.Checked = false;
                rdoPunch.Checked = false;
            }
            else { rdoNonPunch.Checked = true; }
        }

        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = "AKIJ GROUP";
                lblReportName.Text = "CAFETERIA DETAILS REPORT";
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtTDate.Text).ToString("yyyy-MM-dd");

                intPart = 1;
                fdate = DateTime.Parse(txtFDate.Text);
                tdate = DateTime.Parse(txtTDate.Text);  
                
                if(rdoAll.Checked == true) { intRptType = 1;}
                else if(rdoNonPunch.Checked == true) { intRptType = 2;}          
                else if(rdoPunch.Checked == true) {intRptType = 3;}

                dt = new DataTable();
                dt = obj.GetCafeteriaRAll(intPart, fdate, tdate, intRptType);
                if (dt.Rows.Count > 0) { dgvReport.DataSource = dt; dgvReport.DataBind(); }
                else { dgvReport.DataSource = ""; dgvReport.DataBind(); }
            }
            catch { }
        }

       























    }
}