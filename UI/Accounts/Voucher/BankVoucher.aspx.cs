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
using System.Net;
using System.IO;

namespace UI.Accounts.Voucher
{
    public partial class BankVoucher : BasePage
    {
        protected double totAmount = 0;
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
                    btnSelectAll.Enabled = true;
                    btnCompleteSelected.Enabled = true;
                    //GridView1.Columns[8].Visible = true;
                    //ColumnShowHide(true);
                    break;
                case "com":
                    hdnCompleted.Value = "true";
                    hdnEnable.Value = "true";
                    btnSelectAll.Enabled = false;
                    btnCompleteSelected.Enabled = false;
                    //GridView1.Columns[8].Visible = true;
                    //ColumnShowHide(false);
                    break;
                case "cnd":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "false";
                    btnSelectAll.Enabled = false;
                    btnCompleteSelected.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[8].Visible = false;
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

            if (txtCode.Text.Length > 9)
            {
                rdoType.Enabled = false;
                ddlDrCr.Enabled = false;
            }
            else
            {
                rdoType.Enabled = true;
                ddlDrCr.Enabled = true;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
            bv.VoucherCancel(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
            bv.ChangeChequeNo(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
            int ret = bv.VoucherFinished(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());


            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;

            if (ret >= 1)
            {
                if (ddlDrCr.SelectedIndex == 0)
                {
                    bv.SaveDr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                }
                else
                {
                    bv.SaveCr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                }
            }

            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                if (
                    ((CheckBox)GridView1.Rows[0].Cells[15].Controls[0]).Checked//ysnEnabled
                    &&
                    ((CheckBox)GridView1.Rows[0].Cells[16].Controls[0]).Checked//ysnCompleted
                    )
                {
                    rdoType.SelectedIndex = 1;
                    ColumnShowHide(false);
                }
                else if (
                    !((CheckBox)GridView1.Rows[0].Cells[15].Controls[0]).Checked//ysnEnabled
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
                    GridView1.Columns[9].Visible = true;

                    break;
                case "com":
                    ColumnShowHide(false);
                    GridView1.Columns[9].Visible = true;

                    break;
                case "cnd":
                    ColumnShowHide(false);
                    GridView1.Columns[9].Visible = false;

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
                    GridView1.Columns[12].Visible = true;
                    GridView1.Columns[13].Visible = false;
                    GridView1.Columns[17].Visible = true;

                }
                else
                {
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[13].Visible = true;
                    GridView1.Columns[17].Visible = false;

                }
            }
            else
            {
                GridView1.Columns[12].Visible = show;
                GridView1.Columns[13].Visible = show;
                GridView1.Columns[17].Visible = show;

            }

            GridView1.Columns[14].Visible = show;
            GridView1.Columns[18].Visible = show;
            GridView1.Columns[0].Visible = show;

        }
        protected string GetEditLink(object voucherID)
        {
            string str = "";

            switch (rdoType.SelectedValue)
            {
                case "act":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntryEdit.aspx?id=" + voucherID + "&type=bn&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
                case "com":
                    //str = "<a href=\"#\" onclick=\"ShowPopUpVr('VoucherEdit.aspx?id=" + voucherID + "&type=bn&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    str = "";
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
                    DateTime dt = CommonClass.GetDateAtSQLDateFormat(((Label)e.Row.Cells[4].Controls[1]).Text);
                    if (dt.Date > DateTime.Now.Date)
                    {
                        isVisible = false;
                    }
                }
                catch
                {

                }

                try
                {
                    totAmount += double.Parse(((Label)e.Row.Cells[6].Controls[1]).Text);
                }
                catch { }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[8].Text = "Pay to";
                if (ddlDrCr.SelectedIndex == 0)
                {
                    e.Row.Cells[8].Text = "Pay To";
                }

                else
                {
                    e.Row.Cells[8].Text = "Receive From";
                }
            }

            e.Row.Cells[18].Enabled = isVisible;
            e.Row.Cells[0].Enabled = isVisible;


        }

        protected void btnCompleteSelected_Click(object sender, EventArgs e)
        {
            int gridRowCount = GridView1.Rows.Count;
            bool ysnChecked;
            string bvID;
            BLL.Accounts.Voucher.BankVoucher bv = new BLL.Accounts.Voucher.BankVoucher();
            int ret;
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            for (int i = 0; i < gridRowCount; i++)
            {
                ysnChecked = ((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked;
                if (ysnChecked)
                {
                    bvID = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value;
                    ret = bv.VoucherFinished(bvID, Session[SessionParams.USER_ID].ToString());
                    if (ret >= 1)
                    {
                        if (ddlDrCr.SelectedIndex == 0)
                        {
                            bv.SaveDr(bvID, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                        }
                        else
                        {
                            bv.SaveCr(bvID, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                        }
                    }
                }

            }

            GridView1.DataBind();
        }
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            DateTime dt;


            int gridRowCount = GridView1.Rows.Count;
            for (int i = 0; i < gridRowCount; i++)
            {
                try
                {
                    dt = CommonClass.GetDateAtSQLDateFormat(((Label)GridView1.Rows[i].Cells[4].Controls[1]).Text);
                    if (dt.Date <= DateTime.Now.Date)
                    {
                        ((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked = true;
                    }

                }
                catch
                {
                }

            }
        }


        public string payToReceiveFromString(string payTo, string receiveFrom)
        {
            if (payTo == "" || payTo == null)
            {
                return receiveFrom;
            }

            else
            {
                return payTo;
            }

        }

        public string payToReceiveFromHeaderString()
        {
            if (ddlDrCr.SelectedIndex == 0)
            {
                return "Pay To";
            }

            else
            {
                return "Receive From";
            }

        }

        public string GetCompleteDateString(string comDate)
        {
            if (comDate == null || comDate == "")
            {

                return "";
            }
            else
            {
                return CommonClass.GetShortDateAtLocalDateFormat(DateTime.Parse(comDate));
            }
        }


        protected void BtnDetalisdownload_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string filePath = searchKey[0];
            
            if (filePath != "")
            {
                Session["strPath"] = filePath;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocViewData('DocVoucherView.aspx');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
            }


        }
    }
}
