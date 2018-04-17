using BLL.Accounts.PartyPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Vat
{
    public partial class TresaryEntry : BasePage
    {
        string msgStatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();//HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                hdncompleteded.Value = "False"; hdnconfirmcomplete.Value = "";
            }
            else
            {
                if (hdnconfirmcomplete.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "CompleteTreasury();", true);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string treasuryid = ddlTreasurylist.SelectedValue.ToString();
                decimal amount = decimal.Parse(monAmount.Text);
                PartyBill vat = new PartyBill();
                string userid = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                msgStatus = vat.InsertTreasuryDepositInformation(treasuryid, amount, int.Parse(ddlVatAcc.SelectedValue.ToString()), userid);
                if (msgStatus != "0")
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true); }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit.');", true); }
                monAmount.Text = ""; dgvViewtreasury.DataBind();
            }
        }
        protected void rdocompletestatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdocompletestatus.SelectedValue == "false")//Value=False Means not completed
            {
                hdncompleteded.Value = "False";
                dgvViewtreasury.Columns[8].Visible = true;
            }
            else
            {
                hdncompleteded.Value = "True"; //Value=True Means completed
                dgvViewtreasury.Columns[8].Visible = false;
            }

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string autoid = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "PrintTreasury('" + autoid + "','" + hdnvtacc.Value + "');", true);
        }
        protected void CompleteCompleteTreasury_Click(object sender, EventArgs e)
        {
           hdndepositidForcomplete.Value = ((Button)sender).CommandArgument.ToString();
           txtChallanno.Text = ""; txtChallanDate.Text = ""; txtInstrumentno.Text = ""; txtInstrumentDate.Text = "";
           ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "CompleteTreasury();", true);
        }
        protected void btnComplete_Click(object sender, EventArgs e)
        {
            if (hdnconfirmcomplete.Value == "1")
            {
                string treasuryid = hdndepositidForcomplete.Value;
                string challanno = txtChallanno.Text;
                DateTime challandt = DateTime.Parse(txtChallanDate.Text);
                string instrumentno = txtInstrumentno.Text;
                DateTime instrumentdt = DateTime.Parse(txtInstrumentDate.Text);
                PartyBill vat = new PartyBill();
                string userid = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                msgStatus = vat.UpdateTreasuryDepositInformation(treasuryid, challanno, challandt, instrumentno, instrumentdt, userid);
                if (msgStatus != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "HideCompleteDiv();", true);
                    dgvViewtreasury.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to complete.');", true); }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "HideCompleteDiv();", true);
            txtChallanno.Text = ""; txtChallanDate.Text = ""; txtInstrumentno.Text = ""; txtInstrumentDate.Text = "";
        }
        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }

    }
}