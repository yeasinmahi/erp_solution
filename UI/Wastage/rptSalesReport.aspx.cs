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
    public partial class rptSalesReport : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;
        int  intwork;
        int?  intTransferJobStationID = null;
        string SalesOrderNo,DeliveryChallan;
           
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
            dt = obj.getWHbyUnit(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWareHouseID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
          
        }  
        protected void btnShow_Click(object sender, EventArgs e)
        {

            if (int.Parse(hdnRpt.Value) == 1)
            {
                dt = obj.getSalesReport(txtSODate.Text, txtToDate.Text, int.Parse(ddlWHName.SelectedValue), 1);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
                lblHeder.Text = "Sales Report From " + DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy") + " To " + DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy");
            }
            else
            {
                dt = obj.getSalesReport(txtSODate.Text, txtToDate.Text, int.Parse(ddlWHName.SelectedValue), 2);
                dgvPending.DataSource = dt;
                dgvPending.DataBind();
                lblHeder.Text = "Pending Report From " + DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy") + " To " + DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy");
            }

        }
        protected decimal TotalValueSales = 0;
        protected decimal stotalQty = 0;
        #region ********* Report ************
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   
                    TotalValueSales += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblQty")).Text);
                }
            }
            catch { }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");
            SalesOrderNo = searchKey[0].ToString();
            DeliveryChallan = searchKey[1].ToString();
            dt = obj.SalesDetials(SalesOrderNo, DeliveryChallan, int.Parse(ddlWHName.SelectedValue));
            dgvDetalis.DataSource = dt;
            dgvDetalis.DataBind();
            dgvDetalis.Visible = true;
            dgvPendingDetails.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
        }
        protected void btnDetailsPending_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");
            SalesOrderNo = searchKey[0].ToString();
        
            dt = obj.pendingDetials(SalesOrderNo, int.Parse(ddlWHName.SelectedValue));
            dgvPendingDetails.DataSource = dt;
            dgvPendingDetails.DataBind();
            dgvDetalis.Visible = false;
            dgvPendingDetails.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
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
        #endregion ********* end ***********
        protected void btnClsoe_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "CloseHdnDiv();", true);
            dgvPendingDetails.Visible = false;
            dgvDetalis.Visible = false;
        }

        protected void dgvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TotalValueSales += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblQty")).Text);
                }
            }
            catch { }
        }
    }
}