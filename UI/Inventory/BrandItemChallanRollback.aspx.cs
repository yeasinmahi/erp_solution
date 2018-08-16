using HR_BLL.TourPlan;
using HR_DAL.TourPlan.TourPlanningTDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using UserSecurity;
using static HR_DAL.TourPlan.TourPlanningTDS;

namespace UI.Inventory
{
    public partial class BrandItemChallanRollback : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SetInfo(string id, bool isEnable)
        {
            hdnID.Value = id;
            if (isEnable)
            {
                lblResult.Text = "Challan Found. You can rollback this.";
            }
            else
            {
                lblResult.Text = "Challan Not Found";
            }
            btnAction.Enabled = isEnable;
            txtPass.Enabled = isEnable;
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            UserSecurityService us = new UserSecurityService();

            if (us.ValidatePassword(Session[SessionParams.EMAIL].ToString(), txtPass.Text))
            {
                TourPlanning vr = new TourPlanning();
                if (vr.BrandChallanRollback(txtCode.Text, hdnID.Value, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, txtRemark.Text.Trim()))
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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string date = "2018-07-01";

            if (txtCode.Text.StartsWith("Brand", true, System.Globalization.CultureInfo.CurrentCulture))
            {
                //BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
                //type, actionby, xml, id, fdate, tdate, unitid, challan
                SprBrandItemChallanRollbackDetTableAdapter bll = new SprBrandItemChallanRollbackDetTableAdapter();
                dt = bll.GetDataBrandItemChallanRollbackDet(1, 1272, "", 0, 13, txtCode.Text);
                hdnType.Value = "BP";
                if (dt.Rows.Count > 0)
                {
                    string pk = dt.Rows[0]["intPKID"].ToString();

                    SetInfo(pk, true);
                }
                else
                {
                    SetInfo("", false);
                }
            }
        }
    }
}