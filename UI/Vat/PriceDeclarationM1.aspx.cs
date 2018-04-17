using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class PriceDeclarationM1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind(); hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();//HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
        }

        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }
    }
}