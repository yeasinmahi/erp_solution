using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.PartyPayment
{
    public partial class AccountsVoucherStatusReport : BasePage
    {
        BLL.Accounts.PartyPayment.PartyBill objPartyBill = new BLL.Accounts.PartyPayment.PartyBill();
        DataTable dtble = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdngobycode.Value = "";  hdncompleteded.Value = "False"; //Value=False Means not completed and Value=True Means completed.
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "BP-" + pre + "-";
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        protected void rdocompletestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdocompletestatus.SelectedValue == "false")//Value=False Means not completed
                hdncompleteded.Value = "False";
            else
                hdncompleteded.Value = "True"; //Value=True Means completed
        }
        public string GetJSShowBillVATPOMRR(object intBillID, object intPOID, object intShipmentID, object viewtype)
        { return "ShowBillVatPOMRR('" + intBillID.ToString() + "','" + intPOID.ToString() + "','" + intShipmentID.ToString() + "','" + viewtype.ToString() + "')"; }
        public string GetJSShowVoucher(object voucher, object type, object debit)
        {
            return "ShowVoucher('" + voucher.ToString() + "','" + type.ToString() + "','" + debit.ToString() + "')";
        }

        #endregion

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
            //    DateTime fromdate = DateTime.Parse(txtFromDate.Text);
            //    DateTime todate = DateTime.Parse(txtToDate.Text);
            //    bool ysnCompleted = bool.Parse(hdncompleteded.Value);
            //    dtble = objPartyBill.GetVoucherStatusReport(hdngobycode.Value, unitid, fromdate, todate, ysnCompleted);
            //    dgvViewVoucher.DataSource = dtble;
            //    dgvViewVoucher.DataBind();
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 9) hdngobycode.Value = txtCode.Text;
                else hdngobycode.Value = "";
                dgvViewVoucher.DataBind();

        }

    }
}