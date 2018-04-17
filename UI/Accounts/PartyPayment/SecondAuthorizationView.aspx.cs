using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class SecondAuthorizationView : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher(); string alertmsg = "";
        string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdngobycode.Value = ""; btnCompleteAll.Enabled = false; hdnprinted.Value = "True"; //Value=True Means printed.
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "BP-" + pre + "-";
            }
        }

        #region  ------------------ DataBound and IndexChange Event Handaler ---------

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                int rowCount = dgvAuthorizedPartyCheque.Rows.Count;
                if (rowCount > 0)
                {
                    btnCompleteAll.Enabled = true;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true); }
            }

            else
            {
                int rowCount = dgvAuthorizedPartyCheque.Rows.Count;
                if (rowCount > 0)
                {
                    btnCompleteAll.Enabled = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }

        }
        public string GetJSShowBillVATPOMRR(object intBillID, object intPOID, object intShipmentID, object viewtype)
        { return "ShowBillVatPOMRR('" + intBillID.ToString() + "','" + intPOID.ToString() + "','" + intShipmentID.ToString() + "','" + viewtype.ToString() + "')"; }
        public string GetJSShowVoucher(object voucher, object type, object debit)
        { return "ShowVoucher('" + voucher.ToString() + "','" + type.ToString() + "','" + debit.ToString() + "')"; }
        
        #endregion

        #region  ------------------ Click Event Handaler ---------

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 9) hdngobycode.Value = txtCode.Text;
            else hdngobycode.Value = "";
            dgvAuthorizedPartyCheque.DataBind();
        }
        protected void Complete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                    int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                    int selectedvoucherid = int.Parse(((Button)sender).CommandArgument.ToString());
                    alertmsg = objPartyBill.GetVoucherAuthorization(usrid, unitid, selectedvoucherid);
                    if (alertmsg != "0")
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true); }
                    else
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true); }
                    dgvAuthorizedPartyCheque.DataBind();
                }
                catch { }
            }

        }
        protected void btnCompleteAll_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    int rowCount = dgvAuthorizedPartyCheque.Rows.Count; bool ysnChecked;
                    for (int i = 0; i < rowCount; i++)
                    {
                        ysnChecked = ((CheckBox)dgvAuthorizedPartyCheque.Rows[i].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                            int selectedvoucherid = int.Parse(((HiddenField)dgvAuthorizedPartyCheque.Rows[i].FindControl("hdnvoucherid")).Value.ToString());
                            alertmsg = objPartyBill.GetVoucherAuthorization(usrid, unitid, selectedvoucherid);
                        }
                    }
                    dgvAuthorizedPartyCheque.DataBind();
                }
                catch
                { alertmsg = "Sorry to submit !!!."; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + alertmsg + "');", true); }
            }
        }

        #endregion


    }
}