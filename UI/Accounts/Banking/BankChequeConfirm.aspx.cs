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
using BLL.Accounts.Voucher;
using BLL.Accounts.SubLedger;
using UI.ClassFiles;

namespace UI.Accounts.Banking
{
    public partial class BankChequeConfirm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ColumnShowHide(true);

                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "BP-" + pre + "-";
            }
        }
        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoType.SelectedValue)
            {
                case "act":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "true";
                    GridView1.Columns[8].Visible = true;
                    ColumnShowHide(true);
                    break;
                case "com":
                    hdnCompleted.Value = "true";
                    hdnEnable.Value = "true";
                    GridView1.Columns[8].Visible = true;
                    ColumnShowHide(false);
                    break;
                case "cnd":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "false";
                    ColumnShowHide(false);
                    GridView1.Columns[8].Visible = false;
                    break;
            }
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length > 9) hdnIsByCode.Value = "true";
            else hdnIsByCode.Value = "false";

            hdnFrm.Value = txtFrom.Text;
            hdnTo.Value = txtTo.Text;
            GridView1.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BankVoucher bv = new BankVoucher();
            bv.VoucherCancel(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            BankVoucher bv = new BankVoucher();
            bv.ChangeChequeNo(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            BankVoucher bv = new BankVoucher();
            bv.VoucherFinished(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());


            if (ddlDrCr.SelectedIndex == 0)
            {
                //bv.SaveDr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session["sesUserID"].ToString());
            }
            else
            {
                //bv.SaveCr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session["sesUserID"].ToString());
            }


            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() != "")
            {
                if (GridView1.Rows.Count > 0)
                {
                    if (
                        ((CheckBox)GridView1.Rows[0].Cells[14].Controls[0]).Checked//ysnEnabled
                        &&
                        ((CheckBox)GridView1.Rows[0].Cells[15].Controls[0]).Checked//ysnCompleted
                        )
                    {
                        rdoType.SelectedIndex = 1;
                        ColumnShowHide(false);
                    }
                    else if (
                        !((CheckBox)GridView1.Rows[0].Cells[14].Controls[0]).Checked//ysnEnabled
                        )
                    {
                        rdoType.SelectedIndex = 2;
                        ColumnShowHide(false);
                    }
                    else
                    {
                        rdoType.SelectedIndex = 0;
                        ColumnShowHide(true);
                    }
                }
            }
        }

        protected void rdoByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            if (ddlDrCr.SelectedIndex == 0)
            {
                txtCode.Text = "BP-" + pre + "-";
            }
            else
            {
                txtCode.Text = "BR-" + pre + "-";
            }
        }
        protected void ddlDrCr_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoType.SelectedValue)
            {
                case "act":
                    ColumnShowHide(true);
                    GridView1.Columns[8].Visible = true;
                    break;
                case "com":
                    ColumnShowHide(false);
                    GridView1.Columns[8].Visible = true;
                    break;
                case "cnd":
                    ColumnShowHide(false);
                    GridView1.Columns[8].Visible = false;
                    break;
            }

            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            if (ddlDrCr.SelectedIndex == 0)
            {
                txtCode.Text = "BP-" + pre + "-";
            }
            else
            {
                txtCode.Text = "BR-" + pre + "-";
            }
        }
        private void ColumnShowHide(bool show)
        {
            if (show)
            {
                if (ddlDrCr.SelectedIndex == 0)
                {
                    GridView1.Columns[11].Visible = true;
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[16].Visible = true;
                }
                else
                {
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = true;
                    GridView1.Columns[16].Visible = false;
                }
            }
            else
            {
                GridView1.Columns[11].Visible = show;
                GridView1.Columns[12].Visible = show;
                GridView1.Columns[16].Visible = show;
            }

            GridView1.Columns[13].Visible = show;
            GridView1.Columns[17].Visible = show;
            GridView1.Columns[10].Visible = show;
        }
        protected string GetEditLink(object voucherID)
        {
            string str = "";

            switch (rdoType.SelectedValue)
            {
                case "act":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntry.aspx?id=" + voucherID + "&type=bn&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
                case "com":
                    str = "<a href=\"#\" onclick=\"ShowPopUp('VoucherEdit.aspx?id=" + voucherID + "&type=bn&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
            }

            return str;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool isVisible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DateTime dt = CommonClass.GetDateAtSQLDateFormat(((Label)e.Row.Cells[3].Controls[1]).Text);
                    if (dt.Date > DateTime.Now.Date)
                    {
                        isVisible = false;
                    }
                }
                catch
                {

                }
            }

            e.Row.Cells[17].Enabled = isVisible;
        }
    }
}
