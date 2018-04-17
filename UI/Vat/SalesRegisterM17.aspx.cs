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
    public partial class SalesRegisterM17 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();//HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                DateTime frmdte = DateTime.Parse(txtDteFrom.Text);
                DateTime todte = DateTime.Parse(txtDteTo.Text);
                int vatitemid = int.Parse(ddlProduct.SelectedValue.ToString());
                DataTable ds = new DataTable();
                PartyBill vat = new PartyBill();
                ds = vat.GetSalesRegister(frmdte, todte, vatitemid, ddlVatAcc.SelectedValue.ToString());
                {
                    dgvsalseregister.DataSource = ds;
                    dgvsalseregister.DataBind();
                }
            }
        }
        
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReport('" + txtDteFrom.Text + "','" + txtDteTo.Text + "','" + ddlProduct.SelectedValue.ToString() + "','" + ddlVatAcc.SelectedValue.ToString() + "');", true);
            }
        }

        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }
    }
}