using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SCM
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "tabs", string.Format("changetabs({0});", "1"), true);
        }
    }
}