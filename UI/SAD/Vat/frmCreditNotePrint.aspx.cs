using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using SAD_BLL.Vat;
using UI.ClassFiles;

namespace UI.SAD.Vat
{
    public partial class frmCreditNotePrint : BasePage
    {
        DataTable dt;
        DateTime dtedate;
        char[] delimiterChars = { '[', ']' };
        Mushok11 objMush = new Mushok11();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel0.DataBind();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                dt = objMush.getVatAccountS(int.Parse(Session[SessionParams.USER_ID].ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnAccno.Value = dt.Rows[0]["intVatPointID"].ToString();
                    hdnVatAccount.Value = dt.Rows[0]["strVATAccountName"].ToString();
                    Session["VatAccid"] = dt.Rows[0]["intVatPointID"].ToString();
                    hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                }

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnprepare_Click(object sender, EventArgs e)
        {

        }

        protected void btnshow_Click1(object sender, EventArgs e)
        {
            if ((txtYear.Text != "") && (txtMNo.Text != ""))
            {
                dt = objMush.getMinfo(int.Parse(txtYear.Text), int.Parse(hdnAccno.Value), int.Parse(txtMNo.Text));
                lblorgName.Text= dt.Rows[0]["strVatAccountName"].ToString();
                lblOrgadd.Text = dt.Rows[0]["strAddress"].ToString();
                lblVatregnoorg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                lblCustname.Text = dt.Rows[0]["strCusName"].ToString();
                LBLCustAddress.Text = dt.Rows[0]["strCusAddress"].ToString();
                lblVatRegno.Text = dt.Rows[0]["strCusVatReg"].ToString();
                Vehicletypeno.Text = dt.Rows[0]["strVehicleNo"].ToString();
                dt = objMush.getCreditnotedetails(int.Parse(hdnAccno.Value), int.Parse(txtMNo.Text), int.Parse(txtYear.Text));
                dgvRpt.DataSource = dt;
                dgvRpt.DataBind();
            }
        }
    }
}