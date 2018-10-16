using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.CreativeSupportModule
{
    public partial class AggrementPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (ckbAgree.Checked == true)
            {
                ckbAgree.Checked = false;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewCustomerView('" + 0 + "');", true);
            }
        }





















    }
}