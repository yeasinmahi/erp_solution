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
using BLL.Accounts.Bank;
using UI.ClassFiles;

namespace UI.Accounts.Bank
{
    public partial class LoanType : BasePage
    {
        string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            // Session["sesUserID"] = "1";
            userId = "" + Session[SessionParams.USER_ID];
            //pnlUpperControl.DataBind();
        }
        protected void btnLoanTypeAdd_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Bank.LoanType lt = new BLL.Accounts.Bank.LoanType();
            bool ysnSuccess = lt.InsertLoanType(userId, txtName.Text, decimal.Parse(txtLoanLimit.Text), int.Parse(ddlUnit.SelectedValue));
            ddlloanType.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GridLoanType.DataBind();
        }
        protected void ddlloanType_DataBound(object sender, EventArgs e)
        {
            GridLoanType.DataBind();
        }
        protected void ddlAccountType_DataBound(object sender, EventArgs e)
        {

        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        protected void btnAcctypeAdd_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            int bankID = int.Parse(ddlBank.SelectedValue);
            int acctypeID = int.Parse(ddlAccountType.SelectedValue);

            BLL.Accounts.Bank.LoanType lt = new BLL.Accounts.Bank.LoanType();
           
            bool ysnSuccess = lt.InsertLoanTypeDetails(userId, bankID, acctypeID, int.Parse(ddlloanType.SelectedValue), int.Parse(ddlUnit.SelectedValue));
            GridLoanTypeDetails.DataBind();


        }
    }
}
