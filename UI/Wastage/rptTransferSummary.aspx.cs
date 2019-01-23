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

namespace UI.Wastage
{
    public partial class rptTransferSummary : BasePage
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
        protected decimal stotalQty = 0;
        protected decimal totalvalue = 0;
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
            if (int.Parse(hdnRpt.Value) == 1)
            {
                intwork = 1;
                dt = obj.getReportForTransfer(intwork, txtSODate.Text, txtToDate.Text, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(ddlWHName.SelectedValue), intTransferJobStationID);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
                lblHeder.Text = "Transfer Summary Report From "+ DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy")+" To " +DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy"); 
            }
            else
            {
                intwork = 2;
                dt = obj.getReportForTransfer(intwork, txtSODate.Text, txtToDate.Text, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(ddlWHName.SelectedValue), intTransferJobStationID);
                dgvReportDetails.DataSource = dt;
                dgvReportDetails.DataBind();
                lblHeder.Text = "Transfer Details Report From " + DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy") + " To " + DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy");
            }

        }      
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    stotalQty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                }
            }
            catch { }
        }

        protected void rdnReport_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            hdnRpt.Value = "1";
        }

        protected void rdnRptDetails_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            hdnRpt.Value = "2";
        }
    }
}