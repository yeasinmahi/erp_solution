using System;
using System.Web.UI;

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