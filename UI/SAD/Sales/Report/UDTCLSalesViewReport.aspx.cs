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
        protected void Page_Load(object sender, EventArgs e)
        {
            GvSalesReport.Visible = false;
            GvSalesReportAnother.Visible = false;
        }

       
        protected void btnShow_Click(object sender, EventArgs e)
        {


            //int reportType = int.Parse(DdlReport.SelectedItem.Value);
            GvSalesReportAnother.Visible = false;
            //if(reportType == 4 || reportType == 5)
            //{
            //    GvSalesReportAnother.Visible = true;
            //}
            //else
            //{
                GvSalesReport.Visible = true;

            //}
          

        }

        decimal total = 0;
        protected void GvSalesReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "pdqnt"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label totalLabel = e.Row.FindControl("lblTotal") as Label;
                if (totalLabel != null)
                {
                    totalLabel.Text = total.ToString();                   
                }
                               
            }
        }









    }
}