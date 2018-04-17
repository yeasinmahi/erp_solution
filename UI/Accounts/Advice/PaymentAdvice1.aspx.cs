using BLL.Accounts.Advice;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class PaymentAdvice : System.Web.UI.Page
    {
        DataTable dt; AdviceBLL bll = new AdviceBLL();
        int intUnitID, intWork, ysnCompleted, intAdviceType, intBankType, intAutoID;
        string strAccountMandatory, strBankName; DateTime dteDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;
                    
                    HideControl();
                }
                catch
                { }
            }
        }

        protected void ddlAdviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intAdviceType = int.Parse(ddlAdviceType.SelectedValue.ToString());
                if (intAdviceType == 3)
                {
                    ddlChillingCenter.Visible = true;
                    lblChillingCenter.Visible = true;
                }
                else
                {
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;
                }
            }
            catch { }
        }

        protected void ddlBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetAccountDetails(intAutoID);
                lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
                lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our CD Account No. "+ dt.Rows[0]["strAccountNo"].ToString();
            }
            catch { }
        }

        protected void ddlFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                LoadAccountList();
            }
            catch { }
        }

        private void LoadAccountList()
        {
            intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            if (intBankType == 1)
            {
                dt = new DataTable();
                dt = bll.GetIBBLBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();
            }
            else if(intBankType != 0)
            {
                dt = new DataTable();
                dt = bll.GetOtherBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitAddress(intUnitID);
                lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                LoadAccountList();
            }
            catch { }
        }

        private void HideControl()
        {
            lblUnitName.Visible = false;
            lblUnitAddress.Visible = false;
            lblTo.Visible = false;
            lblManager.Visible = false;
            lblBankName.Visible = false;
            lblBankAddress.Visible = false;
            lblSubject.Visible = false;
            lblDearSir.Visible = false;
            lblMailBody.Visible = false;
            lblDetails.Visible = false;
            lblWord.Visible = false;
            lblForUnit.Visible = false;
            lblAuth1.Visible = false;
            lblAuth2.Visible = false;
            lblAuth3.Visible = false;
            dgvAdvice.DataSource = dt;
            dgvAdvice.DataBind();
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitAddress(intUnitID);
                lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                //dteDate = DateTime.ParseExact(((TextBox)dgvPLInfo.Rows[index].FindControl("txtApproveFrom")).Text.ToString(), "dd-MM-yyyy", null);
                dteDate = DateTime.Parse(txtDate.Text.ToString());
                intWork = 0;
                strAccountMandatory = ddlMandatory.SelectedItem.ToString();
                strBankName = ddlFormat.SelectedItem.ToString();
                ysnCompleted = int.Parse(ddlVoucher.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetPartyAdvice(intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted);
                dgvAdvice.DataSource = dt;
                dgvAdvice.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblUnitAddress.Visible = true;
                    lblTo.Visible = true;
                    lblManager.Visible = true;
                    lblBankName.Visible = true;
                    lblBankAddress.Visible = true;
                    lblSubject.Visible = true;
                    lblDearSir.Visible = true;
                    lblMailBody.Visible = true;
                    lblDetails.Visible = true;
                    lblWord.Visible = true;
                    lblForUnit.Visible = true;
                    lblAuth1.Visible = true;
                    lblAuth2.Visible = true;
                    lblAuth3.Visible = true;

                    intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetAccountDetails(intAutoID);
                    lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                    lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
                    lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our" + "<br/>" + "CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();
                    
                    AmountFormat formatAmount = new AmountFormat();
                    string   totalAmountInWord = formatAmount.GetTakaInWords(totalamount, "", "Only");
                    lblWord.Text = "In Word: "+totalAmountInWord.ToString();
                }
            }
            catch { }
        }
        protected decimal totalamount = 0;
        protected void dgvAdvice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmount")).Text);
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lbl = (Label)(e.Row.FindControl("lblTTTotal"));
                    lbl.Text = String.Format("{0:n}", totalamount);
                }
            }
            catch { }
        }

    }
}