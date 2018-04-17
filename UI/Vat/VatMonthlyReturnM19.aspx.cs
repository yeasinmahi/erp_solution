using BLL.Accounts.PartyPayment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class VatMonthlyReturnM19 : BasePage
    {
        string msgStatus = ""; PartyBill vat = new PartyBill();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();//HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                decimal OtherAdjustment = decimal.Parse(monOtherAdjustment.Text);
                decimal OtherRebateForExport = decimal.Parse(monOtherRebateForExport.Text);
                decimal ExemptedPurchase = decimal.Parse(monExemptedPurchase.Text);
                decimal OtherRebateAdjustment = decimal.Parse(monOtherRebateAdjustment.Text);
                decimal DEDO = decimal.Parse(monDEDO.Text);
                DateTime Date_ = DateTime.Parse(txtDate.Text);
                int userid = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                msgStatus = vat.InsertMonthlyVatReturn(OtherAdjustment, OtherRebateForExport, ExemptedPurchase, OtherRebateAdjustment, DEDO, Date_, int.Parse(ddlVatAcc.SelectedValue.ToString()), userid);
                if (msgStatus != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    ClearControls();
                    
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit.');", true); }

            }
        }

        private void ClearControls()
        {
            monOtherAdjustment.Text = "0.00"; monOtherRebateForExport.Text = "0.00"; monExemptedPurchase.Text = "0.00"; monOtherRebateAdjustment.Text = "0.00";
            monDEDO.Text = "0.00"; txtDate.Text = "";
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (hdnreport.Value=="1")
            {
                DataTable objDT = new DataTable();
                objDT = vat.GetMonthlyVatReturn(int.Parse(ddlVatAcc.SelectedValue.ToString()), DateTime.Parse(txtDate.Text));
                if (objDT.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReport('" + ddlVatAcc.SelectedValue.ToString() + "','" + txtDate.Text + "');", true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReport('" + hdnunit.Value + "','" + txtDate.Text + "');", true);
                }
                hdnreport.Value = "0";
            }
        }

        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }

        protected void btnBackside_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PrintBackSide();", true);
        }


    }
}