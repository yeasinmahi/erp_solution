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
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {

                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                hdnunit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                txtItem.Attributes.Add("onkeyUp", "SearchItemText();");
                txtSupplierName.Attributes.Add("onkeyUp", "SearchSupplierlistText();");
                txtCustName.Attributes.Add("onkeyUp", "SearchCustnameText();");
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
        public static List<string> GetAutoCompleteDepotName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getDepotName(int.Parse("13"), prefix);
            return result;

        }




        [WebMethod]
        public static List<string> GetAutoCompleteSupplierName(string prefix)
        {
            TourPlanning objbll = new TourPlanning(); DataTable dt = new DataTable();
            List<string> result = new List<string>();
            result = objbll.getBrandItemSupplierList(int.Parse("16"), prefix);
            return result;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());



            if (rptTypeid == 1021)               //grdvSinglePointAllotmentVsRcvCompare
            {

                try
                {
                    DateTime dteFromDate = DateTime.Parse(txtDueDate.Text);
                    DateTime dteToDate = DateTime.Parse(txtToDate.Text);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    dt = bll.GetBrandItemSTockstatusHorizontallay(dteFromDate, dteToDate, "0", Unit, "1021");
                    if (dt.Rows.Count > 0)
                    {

                        grdvBrandItemChallan.DataSource = null;
                        grdvBrandItemChallan.DataBind();
                        grdvReceiveChallan.DataSource = null;
                        grdvReceiveChallan.DataBind();

                        grdvStockStatusHorizontaly.DataSource = dt;
                        grdvStockStatusHorizontaly.DataBind();
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                }

                catch { }

            

            }

             else if (rptTypeid == 1022)               //grdvSinglePointAllotmentVsRcvCompare
                {

                    try
                    {
                        DateTime dteFromDate = DateTime.Parse(txtDueDate.Text);
                        DateTime dteToDate = DateTime.Parse(txtToDate.Text);
                        string Unit = (drdlUnitName.SelectedValue.ToString());
                        dt = bll.GetBrandItemChallanstatusHorizontallay(dteFromDate, dteToDate, "0", Unit, "1022");
                    if (dt.Rows.Count > 0)
                    {
                        grdvStockStatusHorizontaly.DataSource = null;
                        grdvStockStatusHorizontaly.DataBind();
                        grdvReceiveChallan.DataSource = null;
                        grdvReceiveChallan.DataBind();

                        grdvBrandItemChallan.DataSource = dt;
                        grdvBrandItemChallan.DataBind();


                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                    catch { }

                  

                }
            /////
         else   if (rptTypeid == 1023)               //grdvSinglePointAllotmentVsRcvCompare
            {

                try
                {
                    DateTime dteFromDate = DateTime.Parse(txtDueDate.Text);
                    DateTime dteToDate = DateTime.Parse(txtToDate.Text);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    dt = bll.GetBrandItemReceiveStatusHorizontallay(dteFromDate, dteToDate, "0", Unit, "1023");
                    if (dt.Rows.Count > 0)
                    {
                        grdvStockStatusHorizontaly.DataSource = null;
                        grdvStockStatusHorizontaly.DataBind();
                        grdvBrandItemChallan.DataSource = null;
                        grdvBrandItemChallan.DataBind();
                        grdvReceiveChallan.DataSource = dt;
                        grdvReceiveChallan.DataBind();

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                catch { }

             

            }

            else if (rptTypeid == 1025 || rptTypeid == 1026 || rptTypeid == 1027||rptTypeid == 1028 || rptTypeid == 1029)               //Receive status at a Glance Vertically
            {

                try
                {
                    DateTime dteFromDate = DateTime.Parse(txtDueDate.Text);
                    DateTime dteToDate = DateTime.Parse(txtToDate.Text);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    string strsupplier = txtSupplierName.Text.ToString();
                    arrayKey = strsupplier.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    int supid = int.Parse(code);


                    dt = bll.GetBrandItemReceiveStatusVertically(dteFromDate, dteToDate, supid, Convert.ToInt32(Unit), rptTypeid);
                    if (dt.Rows.Count > 0)
                    {
                        grdvStockStatusHorizontaly.DataSource = null;
                        grdvStockStatusHorizontaly.DataBind();
                        grdvBrandItemChallan.DataSource = null;
                        grdvBrandItemChallan.DataBind();
                        grdvReceiveChallan.DataSource = null;
                        grdvReceiveChallan.DataBind();
                        grdvchallanVerticallay.DataSource = null;
                        grdvchallanVerticallay.DataBind();
                        grdvVerticalyrptReceive.DataSource = dt;
                        grdvVerticalyrptReceive.DataBind();

                        decimal totalqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("qnt"));

                        grdvVerticalyrptReceive.FooterRow.Cells[4].Text = "zxTotal";
                        grdvVerticalyrptReceive.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                        grdvVerticalyrptReceive.FooterRow.Cells[5].Text = totalqnt.ToString("N2");

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                catch(Exception ex) {  ex.ToString(); }



            }

            else if (rptTypeid == 1030 || rptTypeid == 1031 || rptTypeid == 1032 || rptTypeid == 1033 || rptTypeid == 1034)               //Receive status at a Glance Vertically
            {
                //from,  to,  unit,  custmid,  itmid,  type
                try
                {
                    DateTime dteFromDate = DateTime.Parse(txtDueDate.Text);
                    DateTime dteToDate = DateTime.Parse(txtToDate.Text);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    string strsupplier = txtSupplierName.Text.ToString();
                    arrayKey = strsupplier.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    int supid = int.Parse(code);

                    string itmname = txtItem.Text.ToString();
                    arrayKey = itmname.Split(delimiterChars);
                    string itmcode = arrayKey[1].ToString();
                    int prdid = int.Parse(itmcode);

                    string depotorcustomer = txtCustName.Text.ToString();
                    arrayKey = depotorcustomer.Split(delimiterChars);
                    string custcode = arrayKey[1].ToString();
                    int custid = int.Parse(custcode);


                    dt = bll.GetBrandItemChallanStatusVertically(dteFromDate, dteToDate,  Convert.ToInt32(Unit), custid, prdid, rptTypeid);
                    if (dt.Rows.Count > 0)
                    {
                        grdvStockStatusHorizontaly.DataSource = null;
                        grdvStockStatusHorizontaly.DataBind();
                        grdvBrandItemChallan.DataSource = null;
                        grdvBrandItemChallan.DataBind();
                        grdvReceiveChallan.DataSource = null;
                        grdvReceiveChallan.DataBind();
                        grdvVerticalyrptReceive.DataSource = null;
                        grdvVerticalyrptReceive.DataBind();
                        grdvVerticalyrptReceive.DataSource = null;
                        grdvVerticalyrptReceive.DataBind();
                        grdvchallanVerticallay.DataSource = dt;
                        grdvchallanVerticallay.DataBind();

                        decimal totalqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decqnt"));

                        grdvchallanVerticallay.FooterRow.Cells[5].Text = "zxTotal";
                        grdvchallanVerticallay.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                        grdvchallanVerticallay.FooterRow.Cells[6].Text = totalqnt.ToString("N2");
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

                catch (Exception ex) { ex.ToString(); }



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

        protected void grdvVerticalyrptReceive_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvVerticalyrptReceive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 1026 || rptTypeid == 1027)
            { 
                grdvVerticalyrptReceive.Columns[0].Visible = true;
                grdvVerticalyrptReceive.Columns[1].Visible = true;
                grdvVerticalyrptReceive.Columns[2].Visible = true;
                grdvVerticalyrptReceive.Columns[3].Visible = true;
                grdvVerticalyrptReceive.Columns[4].Visible = true;
                grdvVerticalyrptReceive.Columns[5].Visible = true;
                grdvVerticalyrptReceive.Columns[6].Visible = true;
            }
            else if (rptTypeid == 1025)
            {
                grdvVerticalyrptReceive.Columns[0].Visible = true;
                grdvVerticalyrptReceive.Columns[1].Visible = true;
                grdvVerticalyrptReceive.Columns[2].Visible = false;
                grdvVerticalyrptReceive.Columns[3].Visible = true;
                grdvVerticalyrptReceive.Columns[4].Visible = true;
                grdvVerticalyrptReceive.Columns[5].Visible = true;
                grdvVerticalyrptReceive.Columns[6].Visible = false;
            }

            else if (rptTypeid == 1028 || rptTypeid == 1029)
            {
                grdvVerticalyrptReceive.Columns[0].Visible = true;
                grdvVerticalyrptReceive.Columns[1].Visible = false;
                grdvVerticalyrptReceive.Columns[2].Visible = false;
                grdvVerticalyrptReceive.Columns[3].Visible = true;
                grdvVerticalyrptReceive.Columns[4].Visible = true;
                grdvVerticalyrptReceive.Columns[5].Visible = true;
                grdvVerticalyrptReceive.Columns[6].Visible = true;
            }

        }

        protected void grdvchallanVerticallay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvchallanVerticallay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 1030 || rptTypeid == 1033 || rptTypeid == 1034)
            {
                grdvchallanVerticallay.Columns[0].Visible = true;
                grdvchallanVerticallay.Columns[1].Visible = true;
                grdvchallanVerticallay.Columns[2].Visible = true;
                grdvchallanVerticallay.Columns[3].Visible = true;
                grdvchallanVerticallay.Columns[4].Visible = true;
                grdvchallanVerticallay.Columns[5].Visible = true;
                grdvchallanVerticallay.Columns[6].Visible = true;
                grdvchallanVerticallay.Columns[7].Visible = true;
                
            }
            if (rptTypeid == 1031 || rptTypeid == 1032)
            {
                grdvchallanVerticallay.Columns[0].Visible = true;
                grdvchallanVerticallay.Columns[1].Visible = true;
                grdvchallanVerticallay.Columns[2].Visible = true;
                grdvchallanVerticallay.Columns[3].Visible = true;
                grdvchallanVerticallay.Columns[4].Visible = true;
                grdvchallanVerticallay.Columns[5].Visible = true;
                grdvchallanVerticallay.Columns[6].Visible = true;
                grdvchallanVerticallay.Columns[7].Visible = false;
            }

        }
    }
}