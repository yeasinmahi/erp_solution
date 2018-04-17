using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using UI.ClassFiles;

namespace UI.SAD.Customer
{
    public partial class DistributionPoint : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["sesUserID"] = "1";
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                hdnCustomer.Value = temp[temp.Length - 1];
            }
            catch { hdnCustomer.Value = ""; }
        }

    }
}