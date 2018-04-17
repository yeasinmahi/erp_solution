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
    public partial class PoDocAttachment : BasePage
    {
        DataTable dt = new DataTable();
        PoGenerate_BLL objPo = new PoGenerate_BLL();
        int enroll, intWh;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                DefaltPageLoad();
            }
            else { }
        }

       

        private void DefaltPageLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                 
                dt = objPo.GetUnit();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "strUnit";
                ddlUnit.DataValueField = "intUnitId";
                ddlUnit.DataBind();
                dt.Clear();
                dt = objPo.GetPoData(21, "", 0, 0, DateTime.Now, enroll);
                ddlDept.DataSource = dt;
                ddlDept.DataTextField = "strName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
                dt.Clear();
                dt = objPo.GetPoData(14, "", 0, 0, DateTime.Now, enroll);
                ddlPoUser.DataSource = dt;
                ddlPoUser.DataTextField = "strName";
                ddlPoUser.DataValueField = "Id";
                ddlPoUser.DataBind();
                string dept = ddlDept.SelectedItem.ToString();
                if (dept == "Local") { dept = "Local Purchase"; }
                else if (dept == "Import") { dept = "Foreign Purchase"; }
                else { dept = "Fabrication"; }
                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"'  + "/></voucher>".ToString();
                dt = objPo.GetPoData(25, xmlData, int.Parse(ddlUnit.SelectedValue), 0, DateTime.Now, enroll);
                ddlSupplier.DataSource = dt;
                ddlSupplier.DataTextField = "strName";
                ddlSupplier.DataValueField = "Id";
                ddlSupplier.DataBind();
                dt.Clear();
            }
            catch { }

        }

      

        protected void btnPoUserShow_Click(object sender, EventArgs e)
        {
            try
            {
                int unitID = int.Parse(ddlUnit.SelectedValue);
                string dept = ddlDept.SelectedItem.ToString();
                string strSupp = ddlSupplier.SelectedValue.ToString();
                enroll = int.Parse(ddlSupplier.SelectedValue);
                DateTime dteTo = DateTime.Parse(txtdteTo.Text);
                DateTime dteFrom = DateTime.Parse(txtdteFrom.Text);

                string xmlData = "<voucher><voucherentry dept=" + '"' + dept + '"' + " strSupp=" + '"' + strSupp + '"' + " dteTo=" + '"' + dteTo + '"' + "/></voucher>".ToString();
                dt = objPo.GetPoData(26, xmlData, unitID, 0, dteFrom, enroll);
                dgvPO.DataSource = dt;
                dgvPO.DataBind();
            }
            catch { }
            
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                string unit = ddlUnit.SelectedItem.ToString();
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblPoId = row.FindControl("lblPoId") as Label;
                Label lblmonBillAmount = row.FindControl("lblmonBillAmount") as Label;
                Label lblBillId = row.FindControl("lblBillId") as Label;
                Label lblBillCode = row.FindControl("lblBillCode") as Label;

                string PoId = lblPoId.Text.ToString();
                string BillAmount = lblmonBillAmount.Text.ToString();
                string BillId = lblBillId.Text.ToString();
                string BillCode = lblBillCode.Text.ToString();
                

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + unit + "','" + PoId.ToString() + "','" + BillAmount + "','" + BillId + "','" + BillCode + "');", true);
            }
            catch { }

        }
    }
}