using SAD_BLL.Item;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RemoteGhatTransferChallan : System.Web.UI.Page
    {

     #region Global Variables
        DataTable dt = new DataTable();
        SalesView bll = new SalesView();
        int unitid, fshipid, tshipid,rpttypeid, rpttype;
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }
   
        protected void btnGhatReport_Click(object sender, EventArgs e)
        {

            loadGrid();

        }

        private void loadGrid()
        {

            try
            {
                String strEamilTSO = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                fshipid= int.Parse(ddlShip.SelectedValue.ToString());
                tshipid = int.Parse(drdltoshippoint.SelectedValue.ToString());
                rpttypeid= int.Parse(ddlrpttype.SelectedValue.ToString());
               
                if (rpttypeid==1|| rpttypeid==2)
                { dt = bll.getPointToPointDelv(dtFromDate, dtToDate, unitid, fshipid, tshipid, rpttypeid); }
                else if (rpttypeid == 7 || rpttypeid == 8 || rpttypeid == 13 || rpttypeid == 14)
                { dt = bll.DRSummeryRpt(unitid, tshipid,dtFromDate, dtToDate,  rpttypeid); }


                else { dt = bll.getPointToPointDelvWithItemCode(dtFromDate, dtToDate, unitid, fshipid, tshipid, rpttypeid); }
               

                if (rpttypeid == 1 && dt.Rows.Count > 0)
                {
                    grdvTopSheet.DataSource = null;
                    grdvTopSheet.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = null;
                    grdvForItemcodevsSpecificPoint.DataBind();
                    grdvTransportvsPoint.DataSource = null;
                    grdvTransportvsPoint.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = null;
                    grdvDRSummerySpecificPoint.DataBind();
                    grdvDRSummeryDetaills.DataSource = null;
                    grdvDRSummeryDetaills.DataBind();
                    grdtransferdet.DataSource = dt;
                    grdtransferdet.DataBind();
                    decimal txtTotalDelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdtransferdet.FooterRow.Cells[5].Text = "total";
                    grdtransferdet.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    grdtransferdet.FooterRow.Cells[3].Text = txtTotalDelv.ToString("N2");
                }


                else if (rpttypeid == 2 && dt.Rows.Count > 0)
                {
                    grdtransferdet.DataSource = null;
                    grdtransferdet.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = null;
                    grdvForItemcodevsSpecificPoint.DataBind();
                    grdvTransportvsPoint.DataSource = null;
                    grdvTransportvsPoint.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = null;
                    grdvDRSummerySpecificPoint.DataBind();
                    grdvDRSummeryDetaills.DataSource = null;
                    grdvDRSummeryDetaills.DataBind();
                    grdvTopSheet.DataSource = dt;
                    grdvTopSheet.DataBind();
                    decimal txtTotalDelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvTopSheet.FooterRow.Cells[1].Text = "total";
                    grdvTopSheet.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvTopSheet.FooterRow.Cells[2].Text = txtTotalDelv.ToString("N2");
                }

                else if( (rpttypeid == 3 && dt.Rows.Count > 0) || (rpttypeid == 4 && dt.Rows.Count > 0))
                {
                    grdtransferdet.DataSource = null;
                    grdtransferdet.DataBind();
                    grdvTransportvsPoint.DataSource = null;
                    grdvTransportvsPoint.DataBind();
                    grdvTopSheet.DataSource = null;
                    grdvTopSheet.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = null;
                    grdvDRSummerySpecificPoint.DataBind();
                    grdvDRSummeryDetaills.DataSource = null;
                    grdvDRSummeryDetaills.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = dt;
                    grdvForItemcodevsSpecificPoint.DataBind();

                    decimal txtTotalDelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvForItemcodevsSpecificPoint.FooterRow.Cells[3].Text = "total";
                    grdvForItemcodevsSpecificPoint.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvForItemcodevsSpecificPoint.FooterRow.Cells[9].Text = txtTotalDelv.ToString("N2");
                }
                else if ((rpttypeid == 5 && dt.Rows.Count > 0) || (rpttypeid == 6 && dt.Rows.Count > 0))
                {
                    grdtransferdet.DataSource = null;
                    grdtransferdet.DataBind();
                    grdvDRSummeryDetaills.DataSource = null;
                    grdvDRSummeryDetaills.DataBind();
                    grdvTopSheet.DataSource = null;
                    grdvTopSheet.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = null;
                    grdvForItemcodevsSpecificPoint.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = null;
                    grdvDRSummerySpecificPoint.DataBind();
                    grdvTransportvsPoint.DataSource = dt;
                    grdvTransportvsPoint.DataBind();

                    decimal txtTotalDelv = dt.AsEnumerable().Sum(row => row.Field<decimal>("numPieces"));
                    grdvTransportvsPoint.FooterRow.Cells[3].Text = "total";
                    grdvTransportvsPoint.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvTransportvsPoint.FooterRow.Cells[6].Text = txtTotalDelv.ToString("N2");
                }
                else if ((rpttypeid == 7 && dt.Rows.Count > 0) || (rpttypeid == 8 && dt.Rows.Count > 0))
                {
                    grdtransferdet.DataSource = null;
                    grdtransferdet.DataBind();

                    grdvTopSheet.DataSource = null;
                    grdvTopSheet.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = null;
                    grdvForItemcodevsSpecificPoint.DataBind();

                    grdvTransportvsPoint.DataSource = null;
                    grdvTransportvsPoint.DataBind();
                    grdvDRSummeryDetaills.DataSource = null;
                    grdvDRSummeryDetaills.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = dt;
                    grdvDRSummerySpecificPoint.DataBind();

                    decimal txtopenundqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("opendingdoqnt"));
                    grdvDRSummerySpecificPoint.FooterRow.Cells[3].Text = "total";
                    grdvDRSummerySpecificPoint.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvDRSummerySpecificPoint.FooterRow.Cells[4].Text = txtopenundqnt.ToString("N2");
                    decimal doqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decdoqnt"));
                    grdvDRSummerySpecificPoint.FooterRow.Cells[5].Text = doqnt.ToString("N2");
                    decimal challanqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("decchallanqnt"));
                    grdvDRSummerySpecificPoint.FooterRow.Cells[6].Text = challanqnt.ToString("N2");
                    decimal prsntundlvqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("numresqntbyso"));
                    grdvDRSummerySpecificPoint.FooterRow.Cells[7].Text = prsntundlvqnt.ToString("N2");
                }
                else if ((rpttypeid == 13 && dt.Rows.Count > 0) || (rpttypeid == 14 && dt.Rows.Count > 0))
                {
                    grdtransferdet.DataSource = null;
                    grdtransferdet.DataBind();

                    grdvTopSheet.DataSource = null;
                    grdvTopSheet.DataBind();
                    grdvForItemcodevsSpecificPoint.DataSource = null;
                    grdvForItemcodevsSpecificPoint.DataBind();

                    grdvTransportvsPoint.DataSource = null;
                    grdvTransportvsPoint.DataBind();
                    grdvDRSummerySpecificPoint.DataSource = null;
                    grdvDRSummerySpecificPoint.DataBind();

                    grdvDRSummeryDetaills.DataSource = dt;
                    grdvDRSummeryDetaills.DataBind();
                   
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data');", true);
                }



            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }
        }

#endregion
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drdltoshippoint_DataBound(object sender, EventArgs e)
        {

        }

      

   

        protected void grdvTopSheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvTopSheet.PageIndex = e.NewPageIndex;
            loadGrid();
        }

      

        protected void drdltoshippoint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            ddlShip.DataBind();
            drdltoshippoint.DataBind();
        }

        protected void grdvGhatDelvtopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void ddlrpttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rpttype = int.Parse(ddlrpttype.SelectedValue.ToString());
            //if (rpttype == 13 )
            //{
            //    grdvDRSummeryDetaills.Columns[1].Visible = true;
            //    grdvDRSummeryDetaills.Columns[2].Visible = true;
            //}
            //if (rpttype == 14)
            //{
            //    grdvDRSummeryDetaills.Columns[1].Visible = false;
            //    grdvDRSummeryDetaills.Columns[2].Visible = false;
            //}
        }
}
   

   
}