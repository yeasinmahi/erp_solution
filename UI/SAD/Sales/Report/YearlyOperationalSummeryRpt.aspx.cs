using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales.Report
{
    public partial class YearlyOperationalSummeryRpt : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int unitid, teritoryid, areaid, regionid, shippoint, salesoffice, rpttype, custid;

       
        decimal gtotaldoqnt, gtotaldoamount, gtotalchlqnt, gtotalchamount, gpendingqnt, gpendingamount;

    

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
            //try
            //{
                fromdate = DateTime.Parse(txtFDate.Text);
                todate = DateTime.Parse(txtTo.Text);
                teritoryid = int.Parse(drdlTerritory.SelectedValue.ToString());
                areaid = int.Parse(drdlArea.SelectedValue.ToString());
                regionid = int.Parse(drdlRegionName.SelectedValue.ToString());
                unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                shippoint = int.Parse(ddlShip.SelectedValue.ToString());
                salesoffice = int.Parse(ddlSo.SelectedValue.ToString());
                rpttype = int.Parse(drdlrpttype.SelectedValue.ToString());
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

            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }


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

        }
        #endregion change event


    }
}