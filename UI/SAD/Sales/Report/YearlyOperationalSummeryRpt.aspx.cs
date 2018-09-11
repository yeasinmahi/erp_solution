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
    public partial class YearlyOperationalSummeryRpt : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid, areaid, regionid, shippoint, salesoffice, rpttype, custid,enrol;

       
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount, gpendingqnt, gpendingamount;

        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\YearlyOperationalSummeryRpt";
        string stop = "stopping SAD\\Sales\\Report\\YearlyOperationalSummeryRpt";


        DateTime fromdate, todate;
        SalesView bll = new SalesView();
        DataTable dt = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region click event
        private void Loadgrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\YearlyOperationalSummeryRpt Yearly Operational Summery Rpt", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                fromdate = DateTime.Parse(txtFDate.Text);
                todate = DateTime.Parse(txtTo.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                shippoint = int.Parse(ddlShip.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
                enrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            custid = 0;
                if (rpttype == 1|| rpttype == 2 || rpttype == 3 || rpttype == 4 || rpttype == 5 || rpttype == 6 || rpttype == 7 || rpttype == 8 || rpttype == 9)
                {
                    //fromdate,  todate,  rpttype,  salesoffid,  unitid,  intteritoryid,  intareaid,  regionid
                    dt = bll.getYearlyDOSummery(fromdate, todate, rpttype, salesoffice,unitid, teritoryid, areaid, regionid);
                    if (dt.Rows.Count > 0)
                    {
                    grdvItemCatgBasis.DataSource = null;
                    grdvItemCatgBasis.DataBind();
                    grdvDOCHPENDING.DataSource = null;
                    grdvDOCHPENDING.DataBind();
                    dgvYearlysDOSummery.DataSource = dt;
                    dgvYearlysDOSummery.DataBind();
                       
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
                }


           else if (rpttype == 10 || rpttype == 11 || rpttype == 12 || rpttype == 13)
            {
                //fromdate,  todate,  rpttype,  salesoffid,  unitid,  intteritoryid,  intareaid,  regionid
                dt = bll.getYearlyItemCatgBasisDO(fromdate, todate, rpttype, salesoffice, unitid, teritoryid, areaid, regionid);
                if (dt.Rows.Count > 0)
                {
                    dgvYearlysDOSummery.DataSource = null;
                    dgvYearlysDOSummery.DataBind();
                    grdvDOCHPENDING.DataSource = null;
                    grdvDOCHPENDING.DataBind();
                    grdvItemCatgBasis.DataSource = dt;
                    grdvItemCatgBasis.DataBind();
                   
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
            }
            else if (rpttype == 14  || rpttype == 15)
            {
                dt = bll.getPendingDOCHALLANPENDING( rpttype, unitid, fromdate, todate, salesoffice,shippoint,  teritoryid, areaid, regionid,custid);
                if (dt.Rows.Count > 0)
                {
                    dgvYearlysDOSummery.DataSource = null;
                    dgvYearlysDOSummery.DataBind();
                    grdvItemCatgBasis.DataSource = null;
                    grdvItemCatgBasis.DataBind();
                    grdvDOCHPENDING.DataSource = dt;
                    grdvDOCHPENDING.DataBind();

                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
            }

            else if (rpttype == 16 || rpttype == 17 || rpttype == 18)
            {
                //fromDate, toDate, customerId, productId, userID, unitID, intCusType, intSOid, intrptType
                dt = bll.getProductGroupvsChallanDet( fromdate, todate,  unitid,rpttype);

                if (dt.Rows.Count > 0)
                {
                    dgvYearlysDOSummery.DataSource = null;
                    dgvYearlysDOSummery.DataBind();
                    grdvItemCatgBasis.DataSource = null;
                    grdvItemCatgBasis.DataBind();
                    grdvDOCHPENDING.DataSource = null;
                    grdvDOCHPENDING.DataBind();
                    grdvProductGroupbaseChallan.DataSource = dt;
                    grdvProductGroupbaseChallan.DataBind();

                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
            }

            else if ( rpttype == 17 )
            {
                //fromDate, toDate, customerId, productId, userID, unitID, intCusType, intSOid, intrptType
                dt = bll.getProductGroupvsChallanDet(fromdate, todate, unitid, rpttype);

                if (dt.Rows.Count > 0)
                {
                    dgvYearlysDOSummery.DataSource = null;
                    dgvYearlysDOSummery.DataBind();
                    grdvItemCatgBasis.DataSource = null;
                    grdvItemCatgBasis.DataBind();
                    grdvDOCHPENDING.DataSource = null;
                    grdvDOCHPENDING.DataBind();
                    grdvProductGroupbaseChallan.DataSource = dt;
                    grdvProductGroupbaseChallan.DataBind();

                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }
            }

            else if (rpttype == 18)
            {
                ////fromDate, toDate, customerId, productId, userID, unitID, intCusType, intSOid, intrptType
                dt = bll.getProductGroupvsChallanDet(fromdate, todate, unitid, rpttype);

                if (dt.Rows.Count > 0)
                {
                    dgvYearlysDOSummery.DataSource = null;
                    dgvYearlysDOSummery.DataBind();
                    grdvItemCatgBasis.DataSource = null;
                    grdvItemCatgBasis.DataBind();
                    grdvDOCHPENDING.DataSource = null;
                    grdvDOCHPENDING.DataBind();
                    grdvProductGroupbaseChallan.DataSource = dt;
                    grdvProductGroupbaseChallan.DataBind();
                    //GG
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
            //catch (Exception ex)
            //{ ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }




        #endregion click event


        #region change event
        protected void dgvYearlysDOSummery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

        }
        protected void drdlrpttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
            if (rpttype == 1 || rpttype == 2 || rpttype == 3 || rpttype == 4 || rpttype == 5)
            {
                dgvYearlysDOSummery.Columns[1].Visible = true;
                dgvYearlysDOSummery.Columns[2].Visible = true;
            }
             if (rpttype == 6 || rpttype == 7 || rpttype == 8 || rpttype == 9 )
            { 
                dgvYearlysDOSummery.Columns[1].Visible = false;
                dgvYearlysDOSummery.Columns[2].Visible = false;
            }
             if (rpttype == 14 )
            {
                grdvDOCHPENDING.Columns[0].Visible = false;
                grdvDOCHPENDING.Columns[1].Visible = false;
                grdvDOCHPENDING.Columns[2].Visible = false;
                grdvDOCHPENDING.Columns[3].Visible = false;
                grdvDOCHPENDING.Columns[4].Visible = false;
                
            }
            if (rpttype == 15)
            {
                grdvDOCHPENDING.Columns[0].Visible = true;
                grdvDOCHPENDING.Columns[1].Visible = true;
                grdvDOCHPENDING.Columns[2].Visible = true;
                grdvDOCHPENDING.Columns[3].Visible = true;
                grdvDOCHPENDING.Columns[4].Visible = true;

            }
            if (rpttype == 16)
            {
                grdvProductGroupbaseChallan.Columns[0].Visible = true;
                grdvProductGroupbaseChallan.Columns[1].Visible = true;
                grdvProductGroupbaseChallan.Columns[2].Visible = true;
                grdvProductGroupbaseChallan.Columns[3].Visible = true;
                grdvProductGroupbaseChallan.Columns[4].Visible = true;
                grdvProductGroupbaseChallan.Columns[5].Visible = true;
                grdvProductGroupbaseChallan.Columns[6].Visible = true;
                grdvProductGroupbaseChallan.Columns[7].Visible = true;
                grdvProductGroupbaseChallan.Columns[8].Visible = true;
                grdvProductGroupbaseChallan.Columns[9].Visible = true;
                grdvProductGroupbaseChallan.Columns[10].Visible = true;


            }




        }
        #endregion change event


    }
}