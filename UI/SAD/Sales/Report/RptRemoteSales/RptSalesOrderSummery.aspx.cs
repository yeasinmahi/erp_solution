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
    public partial class RptSalesOrderSummery :BasePage
    {
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bllcomp = new SAD_BLL.Customer.Report.StatementC();
        SalesView bll = new SalesView();

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
            int intDeptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
          
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            int deptid = int.Parse(hdnDepartment.Value);
            int jobstation = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            int enr = int.Parse(hdnenrol);
            int unit = int.Parse(drdlUnitName.SelectedValue.ToString());
            int salesoff = int.Parse(ddlSo.SelectedValue.ToString());
            int shippingpoint = int.Parse(ddlShip.SelectedValue.ToString());
           
            if (rptTypeid == 1 )               //Detaills report  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(1, unit, dteFromDate, dteToDate, 0, 0, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvDOSummeryReport.DataSource = dt;
                    grdvDOSummeryReport.DataBind();
                 
                    decimal totalqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvDOSummeryReport.FooterRow.Cells[10].Text = "Total";
                    grdvDOSummeryReport.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                    grdvDOSummeryReport.FooterRow.Cells[12].Text = totalqnt.ToString("N2");

                    decimal totalchallanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
                    grdvDOSummeryReport.FooterRow.Cells[13].Text = totalchallanqnt.ToString("N2");

                    decimal totalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("remainingqnt"));
                    grdvDOSummeryReport.FooterRow.Cells[14].Text = totalremainingqnt.ToString("N2");

                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvDOSummeryReport.FooterRow.Cells[15].Text = totalDOPrice.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

           else if (rptTypeid == 2)               //Price Compare report  
            {
                DataTable dt = new DataTable();
                try
                { dt = bllcomp.getDelvOrderSummerReports(rptTypeid, unit, dteFromDate, dteToDate); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvpriceCompare.DataSource = dt;
                    grdvpriceCompare.DataBind();
                    
                    decimal totaldobasedonchallannumber = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvpriceCompare.FooterRow.Cells[5].Text = "Total";
                    grdvpriceCompare.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    grdvpriceCompare.FooterRow.Cells[6].Text = totaldobasedonchallannumber.ToString("N2");
                    decimal totalmoney = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvpriceCompare.FooterRow.Cells[8].Text = totalmoney.ToString("N2");


                   
                    
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

           else if (rptTypeid == 5 || rptTypeid == 6 || rptTypeid == 7 || rptTypeid == 8)               //Detaills report  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(rptTypeid, unit, dteFromDate, dteToDate, salesoff, shippingpoint, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvitemvsSalesOfficeandShipp.DataSource = dt;
                    grdvitemvsSalesOfficeandShipp.DataBind();


                    decimal totalqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvitemvsSalesOfficeandShipp.FooterRow.Cells[2].Text = "Total";
                    grdvitemvsSalesOfficeandShipp.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    grdvitemvsSalesOfficeandShipp.FooterRow.Cells[3].Text = totalqnt.ToString("N2");

                    
                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvitemvsSalesOfficeandShipp.FooterRow.Cells[4].Text = totalDOPrice.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }

            else if (rptTypeid == 20 || rptTypeid == 21 || rptTypeid == 22 )               //Detaills report  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(rptTypeid, unit, dteFromDate, dteToDate, salesoff, shippingpoint, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();
                    
                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvDOSummeryall.DataSource = dt;
                    grdvDOSummeryall.DataBind();

                    decimal totadolqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvDOSummeryall.FooterRow.Cells[4].Text = "Total";
                    grdvDOSummeryall.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    grdvDOSummeryall.FooterRow.Cells[9].Text = totadolqnt.ToString("N2");
                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvDOSummeryall.FooterRow.Cells[10].Text = totalDOPrice.ToString("N2");
                    decimal totalchallanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
                    grdvDOSummeryall.FooterRow.Cells[11].Text = totalchallanqnt.ToString("N2");
                    decimal totalchalanamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanamount"));
                    grdvDOSummeryall.FooterRow.Cells[12].Text = totalchalanamount.ToString("N2");
                    decimal totalchalPendingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    grdvDOSummeryall.FooterRow.Cells[13].Text = totalchalPendingqnt.ToString("N2");
                    decimal totalchalpendingamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    grdvDOSummeryall.FooterRow.Cells[14].Text = totalchalpendingamount.ToString("N2");
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 23 || rptTypeid == 24 || rptTypeid == 25)               //Detaills report  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(rptTypeid, unit, dteFromDate, dteToDate, salesoff, shippingpoint, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();

                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvCustomerVsDOQnt.DataSource = dt;
                    grdvCustomerVsDOQnt.DataBind();

                    decimal totadolqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvCustomerVsDOQnt.FooterRow.Cells[2].Text = "Total";
                    grdvCustomerVsDOQnt.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    grdvCustomerVsDOQnt.FooterRow.Cells[3].Text = totadolqnt.ToString("N2");
                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvCustomerVsDOQnt.FooterRow.Cells[4].Text = totalDOPrice.ToString("N2");
                   
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 26 || rptTypeid == 27 || rptTypeid == 28)               //itevspendingspecific  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(rptTypeid, unit, dteFromDate, dteToDate, salesoff, shippingpoint, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();

                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = dt;
                    grdvItemvsPendingqntspecific.DataBind();

                    decimal totadolqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[1].Text = "Total";
                    grdvItemvsPendingqntspecific.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    grdvItemvsPendingqntspecific.FooterRow.Cells[4].Text = totadolqnt.ToString("N2");
                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[5].Text = totalDOPrice.ToString("N2");

                    decimal totalchallanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[6].Text = totalchallanqnt.ToString("N2");
                    decimal totalchallanamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanamount"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[7].Text = totalchallanamount.ToString("N2");

                    decimal totalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[8].Text = totalremainingqnt.ToString("N2");
                    decimal totalremainingvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    grdvItemvsPendingqntspecific.FooterRow.Cells[9].Text = totalremainingvalue.ToString("N2");
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 29)               //itevspendingspecific  
            {

                try
                { dt = bll.getUndelvqntTopsheetPartybase(rptTypeid, unit, dteFromDate, dteToDate, salesoff, shippingpoint, 0, 0, 0, 0); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();

                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = dt;
                    grdvSalesOfficeBaseTopsheet.DataBind();

                    decimal totadolqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[1].Text = "Total";
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[2].Text = totadolqnt.ToString("N2");
                    decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[3].Text = totalDOPrice.ToString("N2");

                    decimal totalchallanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[4].Text = totalchallanqnt.ToString("N2");
                    decimal totalchallanamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanamount"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[5].Text = totalchallanamount.ToString("N2");

                    decimal totalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[6].Text = totalremainingqnt.ToString("N2");
                    decimal totalremainingvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[7].Text = totalremainingvalue.ToString("N2");

                    decimal grtotalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[8].Text = grtotalremainingqnt.ToString("N2");
                    decimal grtotalremainingvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    grdvSalesOfficeBaseTopsheet.FooterRow.Cells[9].Text = grtotalremainingvalue.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 30)               //itevspendingspecific  
            {

                try
                { dt = bll.getMissingchallan(rptTypeid); }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();

                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvPointtopsheet.DataSource = null;
                    grdvPointtopsheet.DataBind();
                    grdvMissingChallan.DataSource = dt;
                    grdvMissingChallan.DataBind();

                    //decimal totadolqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[1].Text = "Total";
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[2].Text = totadolqnt.ToString("N2");
                    //decimal totalDOPrice = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotalAmount"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[3].Text = totalDOPrice.ToString("N2");

                    //decimal totalchallanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanqnt"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[4].Text = totalchallanqnt.ToString("N2");
                    //decimal totalchallanamount = dt.AsEnumerable().Sum(row => row.Field<decimal>("challanamount"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[5].Text = totalchallanamount.ToString("N2");

                    //decimal totalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[6].Text = totalremainingqnt.ToString("N2");
                    //decimal totalremainingvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[7].Text = totalremainingvalue.ToString("N2");

                    //decimal grtotalremainingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numRestPieces"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[8].Text = grtotalremainingqnt.ToString("N2");
                    //decimal grtotalremainingvalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    //grdvSalesOfficeBaseTopsheet.FooterRow.Cells[9].Text = grtotalremainingvalue.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            else if (rptTypeid == 31 || rptTypeid == 32 || rptTypeid == 33 || rptTypeid == 34)               //itevspendingspecific  
            {

                try
                {
                    dt = bll.getDelvPointStatus(unit, dteFromDate, dteToDate, shippingpoint, rptTypeid, salesoff);
                }
                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvDOSummeryReport.DataSource = null;
                    grdvDOSummeryReport.DataBind();
                    grdvpriceCompare.DataSource = null;
                    grdvpriceCompare.DataBind();

                    grdvitemvsSalesOfficeandShipp.DataSource = null;
                    grdvitemvsSalesOfficeandShipp.DataBind();
                    grdvDOSummeryall.DataSource = null;
                    grdvDOSummeryall.DataBind();
                    grdvCustomerVsDOQnt.DataSource = null;
                    grdvCustomerVsDOQnt.DataBind();
                    grdvItemvsPendingqntspecific.DataSource = null;
                    grdvItemvsPendingqntspecific.DataBind();
                    grdvSalesOfficeBaseTopsheet.DataSource = null;
                    grdvSalesOfficeBaseTopsheet.DataBind();
                    grdvMissingChallan.DataSource = null;
                    grdvMissingChallan.DataBind();
                    grdvPointtopsheet.DataSource = dt;
                    grdvPointtopsheet.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
        }



        //protected void grdvDOSummeryReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdvDOSummeryReport.PageIndex = e.NewPageIndex;
        //    loadgrid();
        //}

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 1)
            {
                try
                {
                    grdvDOSummeryReport.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("DOSummery.xls", grdvDOSummeryReport);
                }
                catch { }
            }
         else if (rptTypeid == 2)
            {
                try
                {
                    grdvpriceCompare.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("PriceCompare.xls", grdvpriceCompare);
                }
                catch { }
            }

          else  if (rptTypeid == 5 || rptTypeid == 6 || rptTypeid == 7 || rptTypeid == 8)
            {
                try
                {
                    grdvitemvsSalesOfficeandShipp.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("item.xls", grdvitemvsSalesOfficeandShipp);
                }
                catch { }
            }

            else if (rptTypeid == 20 )
            {
                try
                {
                    grdvDOSummeryall.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvDOSummeryallpoint.xls", grdvDOSummeryall);
                }
                catch { }
            }


            else if (rptTypeid == 21 )
            {
                try
                {
                    grdvDOSummeryall.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvDOSummeryallso.xls", grdvDOSummeryall);
                }
                catch { }
            }

            else if ( rptTypeid == 22)
            {
                try
                {
                    grdvDOSummeryall.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvDOSummeryall.xls", grdvDOSummeryall);
                }
                catch { }
            }

            else if (rptTypeid == 23 || rptTypeid == 24 || rptTypeid == 25)
            {
                try
                {
                    grdvCustomerVsDOQnt.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("OnlyDOSummerry.xls", grdvCustomerVsDOQnt);
                }
                catch { }
            }
            else if (rptTypeid == 26)
            {
                try
                {
                    grdvItemvsPendingqntspecific.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvItemvsPendingqntspecific.xls", grdvItemvsPendingqntspecific);
                }
                catch { }
            }
            else if (rptTypeid == 27)
            {
                try
                {
                    grdvItemvsPendingqntspecific.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvItemvsPendingqntspecific.xls", grdvItemvsPendingqntspecific);
                }
                catch { }
            }

            else if (rptTypeid == 28)
            {
                try
                {
                    grdvItemvsPendingqntspecific.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("grdvItemvsPendingqntspecific.xls", grdvItemvsPendingqntspecific);
                }
                catch { }
            }
          


        }

        protected void grdvDOSummeryReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                
            e.Row.Attributes.Add("onmouseover",
            "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


               

            }

        }

        protected void grdvpriceCompare_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover",
            "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        }

        protected void grdvitemvsSalesOfficeandShipp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover",
            "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void grdvDOSummeryall_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("onmouseover",
        //    "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

        //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        //}

        protected void grdvCustomerVsDOQnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvItemvsPendingqntspecific_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid==26 || rptTypeid == 27)
            {
                grdvItemvsPendingqntspecific.Columns[10].Visible = true;
                grdvItemvsPendingqntspecific.Columns[11].Visible = true;
            }
            else
            {
                grdvItemvsPendingqntspecific.Columns[10].Visible = false;
                grdvItemvsPendingqntspecific.Columns[11].Visible = false;
            }
        }

        protected void grdvSalesOfficeBaseTopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           


        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 31)
            {
                grdvPointtopsheet.Columns[0].Visible = true;
                grdvPointtopsheet.Columns[1].Visible = true;
                grdvPointtopsheet.Columns[2].Visible = true;
                grdvPointtopsheet.Columns[3].Visible = true;
                grdvPointtopsheet.Columns[4].Visible = true;
                grdvPointtopsheet.Columns[5].Visible = true;
                grdvPointtopsheet.Columns[6].Visible = false;
                
                grdvPointtopsheet.Columns[7].Visible = true;
                grdvPointtopsheet.Columns[8].Visible = true;
                grdvPointtopsheet.Columns[9].Visible = false;
                grdvPointtopsheet.Columns[10].Visible = false;
                grdvPointtopsheet.Columns[11].Visible = false;
                grdvPointtopsheet.Columns[12].Visible = false;
                grdvPointtopsheet.Columns[13].Visible = false;
                grdvPointtopsheet.Columns[14].Visible = false;
            }

            if (rptTypeid == 32)
            {
                grdvPointtopsheet.Columns[0].Visible = true;
                grdvPointtopsheet.Columns[1].Visible = false;
                grdvPointtopsheet.Columns[2].Visible = false;
                grdvPointtopsheet.Columns[3].Visible = true;
                grdvPointtopsheet.Columns[4].Visible = true;
                grdvPointtopsheet.Columns[5].Visible = true;
                grdvPointtopsheet.Columns[6].Visible = false;

                grdvPointtopsheet.Columns[7].Visible = true;
                grdvPointtopsheet.Columns[8].Visible = true;
                grdvPointtopsheet.Columns[9].Visible = false;
                grdvPointtopsheet.Columns[10].Visible = false;
                grdvPointtopsheet.Columns[11].Visible = false;
                grdvPointtopsheet.Columns[12].Visible = false;
                grdvPointtopsheet.Columns[13].Visible = false;
                grdvPointtopsheet.Columns[14].Visible = false;
            }

            if (rptTypeid == 33)
            {
                grdvPointtopsheet.Columns[0].Visible = true;
                grdvPointtopsheet.Columns[1].Visible = false;
                grdvPointtopsheet.Columns[2].Visible = false;
                grdvPointtopsheet.Columns[3].Visible = true;
                grdvPointtopsheet.Columns[4].Visible = false;
                grdvPointtopsheet.Columns[5].Visible = true;
                grdvPointtopsheet.Columns[6].Visible = true;

                grdvPointtopsheet.Columns[7].Visible = true;
                grdvPointtopsheet.Columns[8].Visible = true;
                grdvPointtopsheet.Columns[9].Visible = false;
                grdvPointtopsheet.Columns[10].Visible = false;
                grdvPointtopsheet.Columns[11].Visible = false;
                grdvPointtopsheet.Columns[12].Visible = false;
                grdvPointtopsheet.Columns[13].Visible = false;
                grdvPointtopsheet.Columns[14].Visible = false;

            }

            if (rptTypeid == 34)
            {
                grdvPointtopsheet.Columns[0].Visible = false;
                grdvPointtopsheet.Columns[1].Visible = false;
                grdvPointtopsheet.Columns[2].Visible = false;
                grdvPointtopsheet.Columns[3].Visible = false;
                grdvPointtopsheet.Columns[4].Visible = false;
                grdvPointtopsheet.Columns[5].Visible = true;
                grdvPointtopsheet.Columns[6].Visible = false;

                grdvPointtopsheet.Columns[7].Visible = false;
                grdvPointtopsheet.Columns[8].Visible = false;
                grdvPointtopsheet.Columns[9].Visible = true;
                grdvPointtopsheet.Columns[10].Visible = true;
                grdvPointtopsheet.Columns[11].Visible = true;
                grdvPointtopsheet.Columns[12].Visible = true;
                grdvPointtopsheet.Columns[13].Visible = true;
                grdvPointtopsheet.Columns[14].Visible = true;

            }

        }
}
}