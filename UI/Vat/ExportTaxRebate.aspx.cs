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
    public partial class ExportTaxRebate : System.Web.UI.Page
    {
        string msgStatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                int vtacc = int.Parse(ddlVatAcc.SelectedValue.ToString());
                DateTime date = DateTime.Parse(txtboeDate.Text);
                decimal puramount = decimal.Parse(purAmount.Text);
                decimal rbtamount = decimal.Parse(rbtAmount.Text);
                string boeno = txtBOENo.Text;
                PartyBill vat = new PartyBill();
                string userid = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                msgStatus = vat.InsertOtherTaxRebateForExport(vtacc, date, puramount, rbtamount, boeno, int.Parse(userid));
                if (msgStatus != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to submit.');", true); }
                purAmount.Text = ""; rbtAmount.Text = "";
            }
        }
    }
}