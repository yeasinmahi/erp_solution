using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PurchaseReturn : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());                
                dt = objPo.GetPoData(36, "", intWh, 0, DateTime.Now, enroll);                
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

            }
            else { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try{
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int mrrNo = int.Parse(txtMrrNo.Text.ToString());
                hdnMrrNo.Value =mrrNo.ToString();
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objPo.GetPoData(33, "", intWh, mrrNo, DateTime.Now, enroll);
                lblSupp.Text = dt.Rows[0]["strSupplierName"].ToString();
                dgvDelivery.DataSource = dt;
                dgvDelivery.DataBind();
            }
            catch{ }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value == "1")
                {

                    int mrrNo = int.Parse(hdnMrrNo.Value.ToString());
                    GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                    TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                    TextBox txtReson = row.FindControl("txtReson") as TextBox;
                    Label lblitemId = row.FindControl("lblitemId") as Label;
                    Label lblPoQty = row.FindControl("lblPoQty") as Label;
                    Label lblLocation = row.FindControl("lblLocation") as Label;
                    string location = lblLocation.Text.ToString(); 

                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    double returnQty = double.Parse(txtReturnQty.Text.ToString());
                    string remarks = txtReson.Text.ToString();
                    string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty.ToString() + '"' + " remarks=" + '"' + remarks + '"' + " itemId=" + '"' + lblitemId.Text.ToString() + '"' + " poQty=" + '"' + lblPoQty.Text.ToString() + '"' + " location=" + '"' + location  + '"' + "/></voucher>".ToString();
                    if (returnQty > 0)
                    {
                        string msg = objPo.PoApprove(37, xmlData, intWh, mrrNo, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                       
                    }
                }

            }
            catch { }

        }
    }
}