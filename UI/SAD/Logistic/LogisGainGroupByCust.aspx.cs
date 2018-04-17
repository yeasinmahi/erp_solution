using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SAD_BLL.Customer;
using System.Web.Services;
using System.Web.Script.Services;
using LOGIS_BLL;
using UI.ClassFiles;

namespace UI.SAD.Logistic
{
    public partial class LogisGainGroupByCust : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";
                pnlUpperControl.DataBind();
            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VehicleVarLogisGainGroup vl = new VehicleVarLogisGainGroup();
            vl.GetCustomerByGroup(hdnCustomer.Value, ddlUnit.SelectedValue, ddlSo.SelectedValue, ddlCusType.SelectedValue, ddlGroup.SelectedValue, true, false);
            GridView1.DataBind();
        }
        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 0)
            {
                hdnCustomer.Value = temp[temp.Length - 1];
            }
            else
            {
                hdnCustomer.Value = "";
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            VehicleVarLogisGainGroup vl = new VehicleVarLogisGainGroup();
            vl.GetCustomerByGroup(hdnCustomer.Value, ddlUnit.SelectedValue, ddlSo.SelectedValue, ddlCusType.SelectedValue, ddlGroup.SelectedValue, false, true);
            GridView1.DataBind();
        }
    }
}
