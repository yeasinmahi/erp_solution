using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class BrandItemReport : System.Web.UI.Page
    {
        int rptTypeid;
        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {

                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                hdnunit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                txtItem.Attributes.Add("onkeyUp", "SearchItemText();");
                txtSupplierName.Attributes.Add("onkeyUp", "SearchSupplierlistText();");
                hdnAction.Value = "0";
                ////---------xml----------
               
                ////-----**----------//
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["Warehouseid"] = hdnwh.Value;
            }
            catch { }
        }

        protected void ddlWH_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["Warehouseid"] = hdnwh.Value;
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
         [WebMethod]
        public static List<string> GetAutoCompleteBrandItemNameWithStockStatus(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemNameWithstockstatus(int.Parse(HttpContext.Current.Session["Warehouseid"].ToString()), prefix);
            return result;

        }







        [WebMethod]
        public static List<string> GetAutoCompleteSupplierName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemSupplierList(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), prefix);
            return result;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            
            if (rptTypeid == 2)               //Ware house base stock status
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string whid = (ddlWH.SelectedValue.ToString());
                    int whidd = int.Parse(whid);
                    dt = bll.GetBrandItemWHBaseStockTopSheet(whidd, unit);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvBrandItemWHBaseTopsheet.DataSource = dt;
                    grdvBrandItemWHBaseTopsheet.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


            else if (rptTypeid == 1)               //Ware house base stock status
            {
               
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string whid = (ddlWH.SelectedValue.ToString());
                    int whidd = int.Parse(whid);
                    dt = bll.GetBrandItemREPORT(1, 0, unit, whidd, dteFromDate, dteToDate);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    
                grdvBrandItemWHBaseTopsheet.DataSource = null;
                grdvBrandItemWHBaseTopsheet.DataBind();
                grdvRptFromRequisitionToUserRecv.DataSource = null;
                grdvRptFromRequisitionToUserRecv.DataBind();
                grdvRptForACLEmailsendtoSupplier.DataSource = null;
                grdvRptForACLEmailsendtoSupplier.DataBind();
                grdvAllpointRcvCompare.DataSource = null;
                grdvAllpointRcvCompare.DataBind();
                grdvSinglePointAllotmentVsRcvCompare.DataSource = null;
                grdvSinglePointAllotmentVsRcvCompare.DataBind();
                grdvVheicleStatusMonitoring.DataSource = dt;
                grdvVheicleStatusMonitoring.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


            else if (rptTypeid == 5)               //from Requistion to user Recv overall status
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string whid = (ddlWH.SelectedValue.ToString());
                    int whidd = int.Parse(whid);
                    dt = bll.GetBrandItemREPORT(5, 0, unit, whidd, dteFromDate, dteToDate);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {

                    grdvBrandItemWHBaseTopsheet.DataSource = null;
                    grdvBrandItemWHBaseTopsheet.DataBind();
                    grdvVheicleStatusMonitoring.DataSource = null;
                    grdvVheicleStatusMonitoring.DataBind();
                    grdvRptForACLEmailsendtoSupplier.DataSource = null;
                    grdvRptForACLEmailsendtoSupplier.DataBind();
                    grdvAllpointRcvCompare.DataSource = null;
                    grdvAllpointRcvCompare.DataBind();
                    grdvSinglePointAllotmentVsRcvCompare.DataSource = null;
                    grdvSinglePointAllotmentVsRcvCompare.DataBind();
                    grdvRptFromRequisitionToUserRecv.DataSource = dt;
                    grdvRptFromRequisitionToUserRecv.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }

            else if (rptTypeid == 1019)               //from Requistion to user Recv overall status
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string whid = (ddlWH.SelectedValue.ToString());
                    int whidd = int.Parse(whid);
                    dt = bll.GetBrandItemREPORT(6, 0, unit, whidd, dteFromDate, dteToDate);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {

                    grdvBrandItemWHBaseTopsheet.DataSource = null;
                    grdvBrandItemWHBaseTopsheet.DataBind();
                    grdvVheicleStatusMonitoring.DataSource = null;
                    grdvVheicleStatusMonitoring.DataBind();
                    grdvRptFromRequisitionToUserRecv.DataSource = null;
                    grdvRptFromRequisitionToUserRecv.DataBind();
                    grdvAllpointRcvCompare.DataSource = null;
                    grdvAllpointRcvCompare.DataBind();
                    grdvSinglePointAllotmentVsRcvCompare.DataSource = null;
                    grdvSinglePointAllotmentVsRcvCompare.DataBind();
                    grdvRptForACLEmailsendtoSupplier.DataSource = dt;
                    grdvRptForACLEmailsendtoSupplier.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }

            else if (rptTypeid == 1020)               //grdvAllpointRcvCompare
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string whid = (ddlWH.SelectedValue.ToString());
                    int whidd = int.Parse(whid);
                    dt = bll.GetBrandItemREPORT(7, 0, unit, whidd, dteFromDate, dteToDate);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {

                    grdvBrandItemWHBaseTopsheet.DataSource = null;
                    grdvBrandItemWHBaseTopsheet.DataBind();
                    grdvVheicleStatusMonitoring.DataSource = null;
                    grdvVheicleStatusMonitoring.DataBind();
                    grdvRptFromRequisitionToUserRecv.DataSource = null;
                    grdvRptFromRequisitionToUserRecv.DataBind();
                    grdvRptForACLEmailsendtoSupplier.DataSource = null;
                    grdvRptForACLEmailsendtoSupplier.DataBind();
                    grdvSinglePointAllotmentVsRcvCompare.DataSource = null;
                    grdvSinglePointAllotmentVsRcvCompare.DataBind();
                    grdvAllpointRcvCompare.DataSource = dt;
                    grdvAllpointRcvCompare.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }

            else if (rptTypeid == 1021)               //grdvSinglePointAllotmentVsRcvCompare
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtDueDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    string directpointid = (drdlPointNamelist.SelectedValue.ToString());
                    int dpointid= int.Parse(directpointid);
                    dt = bll.GetBrandItemREPORT(8, enr, unit, dpointid, dteFromDate, dteToDate);

                }

                catch { }

                if (dt.Rows.Count > 0)
                {

                    grdvBrandItemWHBaseTopsheet.DataSource = null;
                    grdvBrandItemWHBaseTopsheet.DataBind();
                    grdvVheicleStatusMonitoring.DataSource = null;
                    grdvVheicleStatusMonitoring.DataBind();
                    grdvRptFromRequisitionToUserRecv.DataSource = null;
                    grdvRptFromRequisitionToUserRecv.DataBind();
                    grdvRptForACLEmailsendtoSupplier.DataSource = null;
                    grdvRptForACLEmailsendtoSupplier.DataBind();
                    grdvAllpointRcvCompare.DataSource = null;
                    grdvAllpointRcvCompare.DataBind();
                    grdvSinglePointAllotmentVsRcvCompare.DataSource = dt;
                    grdvSinglePointAllotmentVsRcvCompare.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }

        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 2)
            {
                try
                {
                    grdvBrandItemWHBaseTopsheet.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("stocktopsheet.xls", grdvBrandItemWHBaseTopsheet);
                }
                catch { }
            }

            else if (rptTypeid == 1019)
            {
                try
                {
                    grdvRptForACLEmailsendtoSupplier.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("ACLAllotmentAprv.xls", grdvRptForACLEmailsendtoSupplier);
                }
                catch { }
            }

            else 
            {
                try
                {
                    grdvRptFromRequisitionToUserRecv.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("RequistionstatsMonitoring.xls", grdvRptFromRequisitionToUserRecv);
                }
                catch { }
            }
        }






        protected void grdvBrandItemWHBaseTopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvBrandItemWHBaseTopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvVheicleStatusMonitoring_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvVheicleStatusMonitoring_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvRptFromRequisitionToUserRecv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvRptFromRequisitionToUserRecv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal SupvAprvPending = Convert.ToDecimal(e.Row.Cells[8].Text);
                Decimal eventDeptPendingQnt = Convert.ToDecimal(e.Row.Cells[10].Text);
                Decimal UserRecvQntPending = Convert.ToDecimal(e.Row.Cells[13].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (SupvAprvPending > 0)
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                }
                else { e.Row.Cells[8].BackColor = System.Drawing.Color.Green; }


                if (eventDeptPendingQnt >0)
                {
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Red;

                }
                else { e.Row.Cells[10].BackColor = System.Drawing.Color.Green; }

                if (UserRecvQntPending > 0)
                {
                    e.Row.Cells[13].BackColor = System.Drawing.Color.Red;

                }
                else { e.Row.Cells[13].BackColor = System.Drawing.Color.Green; }


            }
        }

        protected void grdvRptForACLEmailsendtoSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvRptForACLEmailsendtoSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvAllpointRcvCompare_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvAllpointRcvCompare_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void drdlPointNamelist_DataBound(object sender, EventArgs e)
        {

        }

        protected void drdlPointNamelist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}