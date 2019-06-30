using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;
using System.Drawing;

namespace UI.Wastage
{
    public partial class rptInventory : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;
        int  intwork;
        int?  intTransferJobStationID = null;
           
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    WHlist();
                  
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
       
        private void WHlist()
        {
            dt = obj.getWHALL();
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWHID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
          
        }  
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
                intwork = 2;
                dt = obj.getInvRpt(txtSODate.Text, txtToDate.Text, int.Parse(ddlWHName.SelectedValue));
                dgvReportDetails.DataSource = dt;
                dgvReportDetails.DataBind();
                lblHeder.Text = "Inventory Report From " + DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy") + " To " + DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy");
            

        }
        protected decimal clovalue = 0, issvalue = 0, avavalue = 0, recvalue = 0, OtotalOpening = 0;

        

        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    clovalue += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblClosingValue")).Text);
                    avavalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAvailableValue")).Text);
                    issvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblIssueValue")).Text);
                    recvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblIssueValue")).Text);
                }
            }
            catch { }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReportDetails.Rows.Count > 0)
            {
                ExportToExcel();
            }
        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    //required to avoid the runtime error "  
        //    //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        //}

        private void ExportToExcel()
        {
            string html = HdnValue.Value;
            string fileName = ddlWHName.SelectedItem.ToString();

            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }
    }
}