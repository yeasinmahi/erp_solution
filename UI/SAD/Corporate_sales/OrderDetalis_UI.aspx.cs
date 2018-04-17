
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;


namespace UI.SAD.Corporate_sales
{
    public partial class OrderDetalis_UI : System.Web.UI.Page
    {
        OrderInput_BLL objOrder = new OrderInput_BLL();
        DataTable dt = new DataTable();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 order = Convert.ToInt32(Session["order"].ToString());
                dt = objOrder.Orderdetalis(order);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();

                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalAmount"));
                decimal totalqty = dt.AsEnumerable().Sum(row => row.Field<decimal>("numQuantity"));
                dgvReport.FooterRow.Cells[6].Text = "Ground Total";
                dgvReport.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                dgvReport.FooterRow.Cells[7].Text = total.ToString("N2");

                dgvReport.FooterRow.Cells[4].Text = "Ground Total";
                dgvReport.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                dgvReport.FooterRow.Cells[5].Text = totalqty.ToString("N2");

            }
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}