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

namespace UI.SAD.DisPoint
{
    public partial class DisPoint : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
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
        [WebMethod]
        [ScriptMethod]
        public static string[] GetDisPointList(string prefixText, int count)
        {
            return DistributionPointSt.GetDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString());
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            ddlCusType.DataBind();
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            if (txtCus.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnCustomer.Value = temp[temp.Length - 1];
            }
            else
            {
                hdnCustomer.Value = "";
            }

            if (hdnCustomer.Value != "")
            {
                GridView1.DataBind();
            }
        }
        protected void btnSearchID_Click(object sender, EventArgs e)
        {
            hdnCustomer.Value = "";
            txtCus.Text = "";

            if (txtId.Text == "")
            {
                if (txtDis.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
                    string[] temp = txtDis.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdnDisPoint.Value = temp[temp.Length - 1];
                }
                else
                {
                    hdnDisPoint.Value = "";
                }
            }
            else
            {
                hdnDisPoint.Value = txtId.Text;
            }

            if (hdnDisPoint.Value != "")
            {
                GridView1.DataBind();
            }
        }
    }
}