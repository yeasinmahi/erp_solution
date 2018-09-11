using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class OperationalSetupBaseStatus : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid,  areaid,  regionid,shippoint,salesoffice,  rpttype,customertypeid;
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount,gpendingqnt,gpendingamount,debitamount,creditamount;
        DateTime fromdate ,  todate;

        SalesView bll = new SalesView();
        DataTable dt = new DataTable();

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\OperationalSetupBaseStatus";
        string stop = "stopping SAD\\Sales\\Report\\OperationalSetupBaseStatus";
        #endregion


        protected void grdvcollectionreport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); }
        }

        #region click event

        private void Loadgrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\OperationalSetupBaseStatus Operational SetupBase Status Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                fromdate = DateTime.Parse(txtFDate.Text);
                todate = DateTime.Parse(txtTo.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid= int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                shippoint= int.Parse(ddlShip.SelectedValue.ToString());
                salesoffice= int.Parse(ddlSo.SelectedValue.ToString());
                rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
                customertypeid = int.Parse(ddlCusType.SelectedValue.ToString());
                if (rpttype == 1 || rpttype == 2 || rpttype == 3 || rpttype == 4)
                {
                    dt = bll.getDOAndChallan(unitid, fromdate, todate, teritoryid, areaid, regionid, rpttype);
                    if (dt.Rows.Count > 0)
                    {
                        grdvUndelvQntAndAmount.DataSource = null;
                        grdvUndelvQntAndAmount.DataBind();
                        grdvUndelvTopsheet.DataSource = null;
                        grdvUndelvTopsheet.DataBind();
                        grdvcollectionreport.DataSource = null;
                        grdvcollectionreport.DataBind();
                        dgvDOAndChallanqnt.DataSource = dt;
                        dgvDOAndChallanqnt.DataBind();
                        gtotaldoqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decOrderqnt"));
                        gtotaldoamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalorderamount"));
                        gtotalchlqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decchallanqnt"));
                        gtotalchamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalchallanamount"));
                        dgvDOAndChallanqnt.FooterRow.Cells[2].Text = "Total";
                        dgvDOAndChallanqnt.FooterRow.Cells[7].Text = gtotaldoqnt.ToString("N2");
                        dgvDOAndChallanqnt.FooterRow.Cells[8].Text = gtotaldoamount.ToString("N2");
                        dgvDOAndChallanqnt.FooterRow.Cells[9].Text = gtotalchlqnt.ToString("N2");
                        dgvDOAndChallanqnt.FooterRow.Cells[10].Text = gtotalchamount.ToString("N2");
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }
             

                else if (rpttype == 11 || rpttype == 12 || rpttype == 13 || rpttype == 14 || rpttype == 15 || rpttype == 16 || rpttype == 17)
                {
                    fromdate = DateTime.Parse(txtFDate.Text);
                    todate = DateTime.Parse(txtTo.Text);
                    DataTable dtundelv = new DataTable();
                    dtundelv = bll.getUndelvqntTopsheetPartybase(rpttype, unitid, fromdate, todate, salesoffice, shippoint, teritoryid, areaid, regionid, 0);
                    
                    if (dtundelv.Rows.Count > 0)
                    {
                        dgvDOAndChallanqnt.DataSource = null;
                        dgvDOAndChallanqnt.DataBind();
                        grdvUndelvQntAndAmount.DataSource = null;
                        grdvUndelvQntAndAmount.DataBind();
                        grdvcollectionreport.DataSource = null;
                        grdvcollectionreport.DataBind();
                        grdvUndelvTopsheet.DataSource = dtundelv;
                        grdvUndelvTopsheet.DataBind();


                    gpendingqnt = dtundelv.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    gpendingamount = dtundelv.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));

                    grdvUndelvTopsheet.FooterRow.Cells[2].Text = "Total";
                    if (rpttype == 11)
                    {
                        grdvUndelvTopsheet.FooterRow.Cells[8].Text = gpendingqnt.ToString("N2");
                        grdvUndelvTopsheet.FooterRow.Cells[9].Text = gpendingamount.ToString("N2");
                    }
                    else if (rpttype == 12 || rpttype == 13 || rpttype == 14 || rpttype == 15 || rpttype == 16 || rpttype == 17)
                    {
                        grdvUndelvTopsheet.FooterRow.Cells[8].Text = gpendingqnt.ToString("N2");
                        grdvUndelvTopsheet.FooterRow.Cells[9].Text = gpendingamount.ToString("N2");
                    }
                    else { }

                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }
                else if (rpttype == 18 || rpttype == 19 || rpttype == 20 || rpttype == 21 || rpttype == 22)
                {
                    fromdate = DateTime.Parse(txtFDate.Text);
                    todate = DateTime.Parse(txtTo.Text);
                    DataTable dtundelv = new DataTable();
                    //fromdate, todate, intunitid, salesofficeid, customertypeid, reporttype, intteritoryid, intareaid, regionid
                    dtundelv = bll.getSetupvsCollection( fromdate, todate, unitid, salesoffice, customertypeid, rpttype,  teritoryid, areaid, regionid);

                    if (dtundelv.Rows.Count > 0)
                    {
                        dgvDOAndChallanqnt.DataSource = null;
                        dgvDOAndChallanqnt.DataBind();
                        grdvUndelvQntAndAmount.DataSource = null;
                        grdvUndelvQntAndAmount.DataBind();
                        grdvUndelvTopsheet.DataSource = null;
                        grdvUndelvTopsheet.DataBind();
                        grdvcollectionreport.DataSource = dtundelv;
                        grdvcollectionreport.DataBind();
                        debitamount = dtundelv.AsEnumerable().Sum(row => row.Field<decimal>("debit"));
                        creditamount = dtundelv.AsEnumerable().Sum(row => row.Field<decimal>("credit"));
                        grdvcollectionreport.FooterRow.Cells[6].Text = "Total";
                        grdvcollectionreport.FooterRow.Cells[8].Text = debitamount.ToString("N2");
                        grdvcollectionreport.FooterRow.Cells[9].Text = creditamount.ToString("N2");


                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }



                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }


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

      



        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();

        }




        #endregion

        #region change event 
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvDOAndChallanqnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvDOAndChallanqnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvUndelvQntAndAmount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvUndelvQntAndAmount_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grdvUndelvTopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {

            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void grdvUndelvTopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            rpttype = int.Parse(drdlrpttype.SelectedValue);
            e.Row.Attributes.Add("onmouseover",
               "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            if (rpttype == 11)
            {
                grdvUndelvTopsheet.Columns[0].Visible = true;
                grdvUndelvTopsheet.Columns[1].Visible = true;
                grdvUndelvTopsheet.Columns[2].Visible = true;
                grdvUndelvTopsheet.Columns[3].Visible = true;
                grdvUndelvTopsheet.Columns[4].Visible = true;
                grdvUndelvTopsheet.Columns[5].Visible = true;
                grdvUndelvTopsheet.Columns[6].Visible = true;
                grdvUndelvTopsheet.Columns[7].Visible = true;
                grdvUndelvTopsheet.Columns[8].Visible = true;
                grdvUndelvTopsheet.Columns[9].Visible = true;
                
            }
            else if(rpttype == 12 || rpttype == 13 || rpttype == 14 || rpttype == 15 || rpttype == 16 || rpttype == 17)
            {

                grdvUndelvTopsheet.Columns[0].Visible = true;
                grdvUndelvTopsheet.Columns[1].Visible = true;
                grdvUndelvTopsheet.Columns[2].Visible = true;
                grdvUndelvTopsheet.Columns[3].Visible = true;
                grdvUndelvTopsheet.Columns[4].Visible = true;
                grdvUndelvTopsheet.Columns[5].Visible = true;
                grdvUndelvTopsheet.Columns[6].Visible = false;
                grdvUndelvTopsheet.Columns[7].Visible = false;
                grdvUndelvTopsheet.Columns[8].Visible = true;
                grdvUndelvTopsheet.Columns[9].Visible = true;
                
            }
        }
        #endregion

    }
}