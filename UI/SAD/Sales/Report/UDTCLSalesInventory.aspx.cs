using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Sales.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Sales.Report
{
    public partial class UDTCLSalesInventory : System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\UDTCLSalesInventory";
        string stop = "stopping SAD\\Sales\\Report\\UDTCLSalesInventory";

        DataTable dt = new DataTable();
        UDTCLSalesBLL obj = new UDTCLSalesBLL();
        decimal totalquantity, totalamount, totalprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\UDTCLSalesInventory UDTCL Sales Inventory", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DateTime dteFroms = DateTime.Parse(txtFormDate.Text);
                DateTime dteTo = DateTime.Parse(txtToDate.Text);

                dt = obj.SalesInvtoryReport(dteFroms, dteTo, int.Parse(ddlUnit.SelectedValue.ToString()));
                dgvSales.DataSource = dt;
                dgvSales.DataBind();
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

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSales.DataSource = "";
                dgvSales.DataBind();
            }
            catch { }
        }

        protected void btnDownloads_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalis_Click (object sender, EventArgs e)
        {
            try
            {
            
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

                Label lblIntId = row.FindControl("lblId") as Label;
                
                string intId = lblIntId.Text;
                          
                string intunit = ddlUnit.SelectedValue.ToString();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + intId + "','" + intunit + "');", true);

            }
            catch { }
        }
        protected void GvSalesReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {          
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalquantity += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "numPieces"));
                totalamount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monTotalAmount"));
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label quantityLabel = e.Row.FindControl("lblquantity") as Label;
                Label priceLabel = e.Row.FindControl("lblprice") as Label;
                Label amountLabel = e.Row.FindControl("lblamount") as Label;
                if (quantityLabel != null)
                {
                    quantityLabel.Text = totalquantity.ToString();
                }
                if (priceLabel != null)
                {
                    priceLabel.Text = totalprice.ToString();
                }
                if (amountLabel != null)
                {
                    amountLabel.Text = totalamount.ToString();
                }

            }

        }
    }
}