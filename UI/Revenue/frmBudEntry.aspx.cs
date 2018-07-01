using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.RevenueBLL;
namespace UI.Revenue
{
    public partial class frmBudEntry : System.Web.UI.Page
    {
        RevenueClsBLL objrev = new RevenueClsBLL();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ProductShow();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("Akij Food & Beverage Ltd.");
            lblHeading.Text = "Ok";
        }
        private void ProductShow()
        {
            dt = objrev.getPshow(int.Parse("2"));
            dgvPending.DataSource = dt;
            dgvPending.DataBind();
        }
    }
}