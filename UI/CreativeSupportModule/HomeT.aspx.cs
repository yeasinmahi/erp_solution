using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Task_Module
{
    public partial class HomeT : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnGo.Visible = false;
            }
        }
        

        protected void btnSupport_Click(object sender, EventArgs e)
        {
            //Server.Transfer("DashboardReport.aspx", true);
            Response.Redirect("DashboardReport.aspx", false);
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            ckbAgree.Checked = false;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirmAgrementPage('" + 0 + "');", true);
           
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirmAgrement('" + 0 + "');", true);          
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (ckbAgree.Checked == true)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewCustomerView('" + 0 + "');", true);
            }            
        }
        







    }
}