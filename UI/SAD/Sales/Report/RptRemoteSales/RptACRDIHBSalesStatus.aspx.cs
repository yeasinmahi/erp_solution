using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RptACRDIHBSalesStatus : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        SalesView bll = new SalesView();
        int rptTypeid, deptid, jobstation, enr, unit, salesoff, shippingpoint;

      

        DateTime dteFromDate, dteToDate;

       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        string hdnenrol,officeemail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnDepartment.Value = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
            }
        }


        private void loadgrid()
        {

            officeemail = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            officeemail = "moshiur.accl@akij.net";
            rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            deptid = int.Parse(hdnDepartment.Value);
            jobstation = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            enr = int.Parse(hdnenrol);
            unit = int.Parse(drdlUnitName.SelectedValue.ToString());
            salesoff = int.Parse(ddlSo.SelectedValue.ToString());
            shippingpoint = int.Parse(ddlShip.SelectedValue.ToString());
            if (rptTypeid == 1 || rptTypeid == 2 || rptTypeid == 3 || rptTypeid == 4 || rptTypeid == 5 || rptTypeid == 6)
            {
                try { dt = bll.ACRDIHBSalesStatus(officeemail, rptTypeid, dteFromDate, dteToDate, unit, salesoff, shippingpoint); }
                catch { }
            }
            else if(rptTypeid == 7 || rptTypeid == 8)
            {
                try { dt = bll.ManapowerAchivement(officeemail, rptTypeid, dteFromDate, dteToDate, unit, salesoff, shippingpoint); }
                catch { }
            }

            if (rptTypeid == 1 || rptTypeid == 2 || rptTypeid == 3 || rptTypeid == 4)               //Detaills report  
            {
               if (dt.Rows.Count > 0)
                {
                    grdvACRDSales.DataSource = dt;
                    grdvACRDSales.DataBind();


                    decimal totalqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decdelvqnt"));
                    grdvACRDSales.FooterRow.Cells[2].Text = "Total";
                    grdvACRDSales.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    grdvACRDSales.FooterRow.Cells[3].Text = totalqnt.ToString("N2");

                    decimal totalcashcom = dt.AsEnumerable().Sum(row => row.Field<decimal>("cashsalestotal"));
                    grdvACRDSales.FooterRow.Cells[5].Text = totalcashcom.ToString("N2");

                    decimal totalsalescom = dt.AsEnumerable().Sum(row => row.Field<decimal>("salescomtotal"));
                    grdvACRDSales.FooterRow.Cells[7].Text = totalsalescom.ToString("N2");

                    decimal totalflat = dt.AsEnumerable().Sum(row => row.Field<decimal>("flattotal"));
                    grdvACRDSales.FooterRow.Cells[9].Text = totalflat.ToString("N2");

                    decimal totalBoostupcom = dt.AsEnumerable().Sum(row => row.Field<decimal>("boostuptotal"));
                    grdvACRDSales.FooterRow.Cells[11].Text = totalBoostupcom.ToString("N2");
                    decimal totalcom = dt.AsEnumerable().Sum(row => row.Field<decimal>("grandtotalcomm"));
                    grdvACRDSales.FooterRow.Cells[12].Text = totalcom.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

           else if ( rptTypeid == 5)               //shop report  
            {

                if (dt.Rows.Count > 0)
                {
                    grdvACRDSales.DataSource = null;
                    grdvACRDSales.DataBind();
                    grdvShopList.DataSource = dt;
                    grdvShopList.DataBind();



                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

           else if (rptTypeid == 6)               //shop report  
            {

                if (dt.Rows.Count > 0)
                {
                    grdvACRDSales.DataSource = null;
                    grdvACRDSales.DataBind();
                    grdvShopList.DataSource = null;
                    grdvShopList.DataBind();
                    grdvRetaillerCommission.DataSource = dt;
                    grdvRetaillerCommission.DataBind();


                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 7 || rptTypeid == 8)               //shop report  
            {

                if (dt.Rows.Count > 0)
                {
                    grdvACRDSales.DataSource = null;
                    grdvACRDSales.DataBind();
                    grdvShopList.DataSource = null;
                    grdvShopList.DataBind();
                    grdvRetaillerCommission.DataSource = null;
                    grdvRetaillerCommission.DataBind();
                    grdvManpowerAchv.DataSource = dt;
                    grdvManpowerAchv.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

        }


        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void grdvACRDSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");




            }
        }


    }
}