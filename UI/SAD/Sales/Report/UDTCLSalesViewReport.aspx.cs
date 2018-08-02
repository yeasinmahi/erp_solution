using SAD_BLL.Sales.Report;
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
    public partial class UDTCLSalesViewReport : BasePage
    {
        DataTable dt = new DataTable();
        UDTCLSalesBLL obj = new UDTCLSalesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //pnlUpperControl.DataBind();
            }
             
           
        }

       
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                 
                DateTime dteFrom = DateTime.Parse(txtFormDate.Text);
                DateTime dteTo = DateTime.Parse(txtToDate.Text);
                int unitId = int.Parse(ddlUnit.SelectedValue.ToString());
                int intType = int.Parse(DdlReport.SelectedValue.ToString());

                dt = obj.getSalesData(dteFrom, dteTo, unitId, intType);
                if (dt.Rows.Count > 0)
                {
                    GvSalesReport.DataSource = dt;
                    GvSalesReport.DataBind();
                }
                else
                {
                    GvSalesReport.DataSource = dt;
                    GvSalesReport.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
                }
            }
            catch { }
           
            
        }

        decimal totalquantity = 0, totalamount = 0, totalprice = 0;

        protected void btnDownloads_Click(object sender, EventArgs e)
        {
            try
            {
                
                GvSalesReport.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("UDTCL_Sales.xls", GvSalesReport);
            }
            catch { }
           
           
        }
       
         

        protected void GvSalesReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int reportType = int.Parse(DdlReport.SelectedItem.Value);
            //if (reportType==4)
            //{
            //    e.Row.Cells[1].Visible = false;
            //    e.Row.Cells[6].Visible = false;
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalquantity += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                totalamount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Totalamout"));
                totalprice += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rate"));
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