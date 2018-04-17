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

namespace UI.SAD.Transfer
{
    public partial class FGTransferView : BasePage
    {
        protected decimal //totAmount = 0, totPieces = 0, 
            aprPieces = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "55";
                pnlMarque.DataBind();

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
            DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
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

        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            char[] ch = { '#' };
            string[] str = ((Button)sender).CommandArgument.Split(ch);
            string id = str[0];
            DateTime dt = DateTime.Parse(str[1]);

            SalesOrderView sv = new SalesOrderView();
            sv.CompleteSO(id, Session[SessionParams.USER_ID].ToString());

            GridView1.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SalesOrderView sv = new SalesOrderView();
            sv.CancelSO(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";

            switch (completed.ToString().ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('FGTransfer.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    //str = "";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //totPieces += decimal.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
                aprPieces += decimal.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
                //totAmount += decimal.Parse(((Label)e.Row.Cells[7].Controls[1]).Text);
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //totAmount = 0;
            //totPieces = 0;
            aprPieces = 0;
            EnableDisable();
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
                            if (((CheckBox)GridView1.Rows[0].Cells[10].Controls[0]).Checked)
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

            if (rdoComplete.SelectedIndex == 0)
            {
                GridView1.Columns[6].Visible = true;
                GridView1.Columns[7].Visible = true;
                GridView1.Columns[8].Visible = true;
            }
            else
            {
                GridView1.Columns[6].Visible = false;
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
            }
        }

        /*protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session["sesCurrentSO"] = ddlSo.SelectedValue;
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sesCurrentSO"] = ddlSo.SelectedValue;
        }*/


        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        /*private void GetCode()
        {
            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            ShipPoint sp = new ShipPoint();
            string str = sp.GetPrefix(ddlShip.SelectedValue);
            if (str == "")
            {
                txtCode.Text = "";
            }
            else
            {
                txtCode.Text = str + "-" + pre + "-";
            }
        }*/

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            //GetCode();
        }

    }
}