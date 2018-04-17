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
    public partial class PurchaseRegisterM16 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                DateTime frmdte = DateTime.Parse(txtDteFrom.Text);
                DateTime todte = DateTime.Parse(txtDteTo.Text);
                int matid = int.Parse(ddlMaterial.SelectedValue.ToString());
                DataTable ds = new DataTable();
                PartyBill vat = new PartyBill();
                ds = vat.GetPurchaseRegister(frmdte, todte, matid, ddlVatAcc.SelectedValue.ToString());
                //if (ds.Rows.Count > 0)
                {
                    dgvpurchaseregister.DataSource = ds;
                    dgvpurchaseregister.DataBind();
                }            
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReport('" + txtDteFrom.Text + "','" + txtDteTo.Text + "','" + ddlMaterial.SelectedValue.ToString() + "','" + ddlVatAcc.SelectedValue.ToString() + "');", true);
            }
        }





    }
}