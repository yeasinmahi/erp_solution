using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UI.ClassFiles;

namespace UI.Accounts.Banking
{
    public partial class BankReconsile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }

        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
