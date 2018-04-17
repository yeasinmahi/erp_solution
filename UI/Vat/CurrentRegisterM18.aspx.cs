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
    public partial class CurrentRegisterM18 : BasePage
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
                DateTime frmdte = DateTime.Parse(txtFromDte.Text);
                DateTime todte = DateTime.Parse(txtDteTo.Text);
                int type = int.Parse(ddlType.SelectedValue.ToString());
                DataTable ds = new DataTable();
                PartyBill vat = new PartyBill();
                ds = vat.GetCurrentRegister(int.Parse(ddlVatAcc.SelectedValue.ToString()), frmdte, todte, type);
                //if (ds.Rows.Count > 0)
                {
                    dgvcurrentregister.DataSource = ds;
                    dgvcurrentregister.DataBind();
                }
            }
        }

        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowReport('" + ddlVatAcc.SelectedValue.ToString() + "','" + txtFromDte.Text + "','" + txtDteTo.Text + "','" + ddlType.SelectedValue.ToString() + "');", true);
            }
        }
    }
}