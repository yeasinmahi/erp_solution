using System;
using System.Web.UI;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PurchaseOrder : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "tabs", string.Format("changetabs({0});", "1"), true);
        }
    }
}