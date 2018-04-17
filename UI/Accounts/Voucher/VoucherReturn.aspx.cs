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
using BLL.Accounts.Voucher;
using DAL.Accounts.Voucher;
using HR_BLL.User;
using UserSecurity;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using UI.ClassFiles;

namespace UI.Accounts.Voucher
{
    public partial class VoucherReturn : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //Session["sesUserID"] = "1";
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.StartsWith("bp", true, System.Globalization.CultureInfo.CurrentCulture) || txtCode.Text.StartsWith("br", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
                BankVoucherTDS.QryAccountsVoucherBankDataTable tbl = bv.GetBankVoucherByCode(txtCode.Text, ddlUnit.SelectedValue);
                hdnType.Value = "BP";
                if (tbl.Rows.Count > 0)
                {
                    SetInfo(tbl[0].intBankVoucherID.ToString(), true);
                }
                else
                {
                    SetInfo("", false);
                }
            }
            else if (txtCode.Text.StartsWith("cn", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
                ContraVoucherTDS.QryAccountsVoucherContraDataTable tbl = cv.GetContraVoucherByCode(txtCode.Text, ddlUnit.SelectedValue);
                hdnType.Value = "CN";
                if (tbl.Rows.Count > 0)
                {
                    SetInfo(tbl[0].intContraVoucherID.ToString(), true);
                }
                else
                {
                    SetInfo("", false);
                }
            }
            else if (txtCode.Text.StartsWith("cp", true, System.Globalization.CultureInfo.CurrentCulture) || txtCode.Text.StartsWith("cr", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
                CashVoucherTDS.TblAccountsVoucherCashDataTable tbl = cv.GetCashVoucherByCode(txtCode.Text, ddlUnit.SelectedValue);
                hdnType.Value = "CP";
                if (tbl.Rows.Count > 0)
                {
                    SetInfo(tbl[0].intCashVoucherID.ToString(), true);
                }
                else
                {
                    SetInfo("", false);
                }
            }
            else if (txtCode.Text.StartsWith("jv", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
                JournalVoucherTDS.TblAccountsVoucherJournalDataTable tbl = jv.GetJournalVoucherByCode(txtCode.Text, ddlUnit.SelectedValue);
                hdnType.Value = "JR";
                if (tbl.Rows.Count > 0)
                {
                    SetInfo(tbl[0].intJournalVoucherID.ToString(), true);
                }
                else
                {
                    SetInfo("", false);
                }
            }
            else/* if ((txtCode.Text.StartsWith("sv", true, System.Globalization.CultureInfo.CurrentCulture))
            || (txtCode.Text.StartsWith("fv", true, System.Globalization.CultureInfo.CurrentCulture))
            )*/
            {
                SalesView sv = new SalesView();
                SalesEntryTDS.QrySalesEntryCustomerDataTable tbl = sv.GetDataByCode(txtCode.Text, ddlUnit.SelectedValue);

                hdnType.Value = "SV";
                if (tbl.Rows.Count > 0)
                {
                    SetInfo(tbl[0].intId.ToString(), true);
                }
                else
                {
                    SetInfo("", false);
                }
            }

        }
        protected void btnAction_Click(object sender, EventArgs e)
        {
            UserSecurityService us = new UserSecurityService();

            if (us.ValidatePassword(Session[SessionParams.EMAIL].ToString(), txtPass.Text))
            {
                VoucherRollback vr = new VoucherRollback();
                if (vr.Rollback(txtCode.Text, hdnID.Value, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, hdnType.Value, txtRemark.Text.Trim()))
                {
                    lblResult.Text = "Successfully rollback";
                }
                else
                {
                    lblResult.Text = "Rollback not possible. Please check auto / manual reconcile";
                }
                txtRemark.Text = "";
            }
            else
            {
                lblResult.Text = "Invalid User";
            }

            hdnID.Value = "";
            btnAction.Enabled = false;
            txtPass.Enabled = false;

        }

        private void SetInfo(string id, bool isEnable)
        {
            hdnID.Value = id;
            if (isEnable)
            {
                lblResult.Text = "Voucher Found. You can rollback this.";
            }
            else
            {
                lblResult.Text = "Voucher Not Found";
            }
            btnAction.Enabled = isEnable;
            txtPass.Enabled = isEnable;
        }
    }
}
