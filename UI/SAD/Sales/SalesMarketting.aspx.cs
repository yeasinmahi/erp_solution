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
using SAD_BLL.Sales;
using SAD_BLL.Customer;
using SAD_DAL.Customer;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Global;
using UI.ClassFiles;

namespace UI.SAD.Sales
{
    public partial class SalesMarketting : BasePage
    {
        protected decimal totAmount = 0, totPieces = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlUpperControl.DataBind();

                //txtCompleteDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            DateTime fromDate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            GridView1.DataBind();

            if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
            }
            else
            {
                rdoComplete.Enabled = true;
            }
        }

        protected string GetEditLink(object voucherID)
        {
            string str = "<a href=\"#\" onclick=\"ShowPopUpE('SalesEntry.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";

            return str;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totAmount += decimal.Parse(((Label)e.Row.Cells[6].Controls[1]).Text);
                    totPieces += decimal.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
                }
                catch { }
            }
        }

        private void EnableDisable()
        {
            if (GridView1.Rows.Count > 0)
            {
                if (GridView1.Rows.Count == 1 && txtCode.Text.Length > 9)
                {
                    if (GridView1.Rows[0].RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            if (((CheckBox)GridView1.Rows[0].Cells[8].Controls[0]).Checked)
                            {
                                rdoComplete.SelectedIndex = 1;
                            }
                            else
                            {
                                rdoComplete.SelectedIndex = 0;
                            }
                        }
                        catch { }
                    }
                }
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            EnableDisable();
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
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
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
        private void GetCode()
        {
            /*string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            ShipPoint sp = new ShipPoint();
            string str = sp.GetPrefix(ddlShip.SelectedValue);
            if (str == "")
            {
                txtCode.Text = "";
            }
            else
            {
                txtCode.Text = str + "-" + pre + "-";
            }*/
        }

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            hdnCustomer.Value = temp[temp.Length - 1];
        }
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            GetCode();
        }
    }
}
