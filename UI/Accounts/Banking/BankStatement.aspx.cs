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
using BLL.Accounts.Banking;
using UI.ClassFiles;


namespace UI.Accounts.Banking
{
    public partial class BankStatement : BasePage
    {
        //ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "7";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
            else
            {

            }
        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Banking.BankStatement bs = new BLL.Accounts.Banking.BankStatement();
            bs.CancelAutoReconcile(((Button)sender).CommandArgument);
            GridView1.DataBind();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
        }

        protected string GetValue(object val, bool isDr)
        {
            decimal val_ = decimal.Parse(val.ToString());

            if (isDr && val_ < 0) return CommonClass.GetFormettingNumber(Math.Abs(val_));
            if (isDr && val_ > 0) return "";
            if (!isDr && val_ < 0) return "";
            if (!isDr && val_ > 0) return CommonClass.GetFormettingNumber(Math.Abs(val_));
            else return "";
        }
    }

}