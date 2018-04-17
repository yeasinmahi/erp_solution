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

namespace UI.Accounts.Voucher
{
    public partial class ContraVoucher : BasePage
    {
        protected double totAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "CN-" + pre + "-";
            }
        }

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtCode.Text = "";
            switch (rdoType.SelectedValue)
            {
                case "act":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "true";
                    btnSelectAll.Enabled = true;
                    btnCompleteAll.Enabled = true;
                    //ColumnShowHide(true);
                    //GridView1.Columns[5].Visible = true;
                    break;
                case "com":
                    hdnCompleted.Value = "true";
                    hdnEnable.Value = "true";
                    btnSelectAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[5].Visible = true;
                    break;
                case "cnd":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "false";
                    btnSelectAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[5].Visible = false;
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
            BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
            cv.CancelContra(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);
            GridView1.DataBind();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            int ret = cv.CompleteContra(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);

            if (ret >= 1)
            {
                cv.Save(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
            }
            GridView1.DataBind();
        }

        private void ColumnShowHide(bool show)
        {
            GridView1.Columns[7].Visible = show;
            GridView1.Columns[11].Visible = show;
            GridView1.Columns[0].Visible = show;
            //GridView1.Columns[9].Visible = show;
        }

        protected string GetEditLink(object voucherID, object amount, object narration, object importFrom)
        {
            string str = "";

            switch (rdoType.SelectedValue)
            {
                case "act":
                    if (importFrom.ToString() == null || importFrom.ToString() == "")
                    {
                        str = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntryEdit.aspx?id=" + voucherID + "&type=cn&isDr=" + (ddlDrCr.SelectedValue == "" ? false : true) + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    }
                    else
                    {
                        str = "";
                    }

                    break;
                case "com":
                    //str = "<a href=\"#\" onclick=\"ShowPopUp('VoucherEdit.aspx?id=" + voucherID + "&type=cn&isDr=" + (ddlDrCr.SelectedValue == "" ? false : true) + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    str = "";
                    break;
            }

            return str;
        }



        protected string GetAdviceLink(object importFrom, object voucherID, object voucherCode)
        {
            string linkStr = "";
            if (importFrom == null || importFrom.ToString() == "")
            {
                linkStr = "";
            }
            else
            {
                linkStr = "<a href=\"#\" onclick=\"ShowPopUp('../Print/PrintAdvice.aspx?vCode=" + voucherCode + "&vID=" + voucherID + "&unitID=" + ddlUnit.SelectedValue + "')\" class=\"link\">Advice Print</a>";
            }
            return linkStr;
            //<a href="#" onclick="ShowPopUp('../Print/PrintAdvice.aspx?id=<%# Eval("intContraVoucherID") %>&type=cn')"
            //                                        class="link">Advice Print</a>
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ContraVoucher cn = new ContraVoucher();
            try
            {
                //cn.SaveAfterCompleteBB(
            }
            catch { }
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                totAmount += double.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
            }
            catch { }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {

            if (GridView1.Rows.Count > 0)
            {
                if (
                    ((CheckBox)GridView1.Rows[0].Cells[8].Controls[0]).Checked//ysnEnabled
                    &&
                    ((CheckBox)GridView1.Rows[0].Cells[9].Controls[0]).Checked//ysnCompleted
                    )
                {
                    rdoType.SelectedIndex = 1;
                    ColumnShowHide(false);
                }
                else if (
                    !((CheckBox)GridView1.Rows[0].Cells[8].Controls[0]).Checked//ysnEnabled
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
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            int gridRowCount = 0;
            gridRowCount = GridView1.Rows.Count;
            for (int i = 0; i < gridRowCount; i++)
            {
                ((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked = true;
            }
        }
        protected void btnCompleteAll_Click(object sender, EventArgs e)
        {
            int gridRowCount;
            string cvID;
            BLL.Accounts.Voucher.ContraVoucher cv = new BLL.Accounts.Voucher.ContraVoucher();
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            int ret;
            gridRowCount = GridView1.Rows.Count;
            for (int i = 0; i < gridRowCount; i++)
            {
                if (((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked)
                {
                    cvID = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value;
                    ret = cv.CompleteContra(Session[SessionParams.USER_ID].ToString(), cvID);
                    if (ret >= 1)
                    {
                        cv.Save(cvID, ddlUnit.SelectedValue, Session["sesUserID"].ToString(), CompleteDate + " 09:00 AM");
                    }
                }
            }

            GridView1.DataBind();
        }

        public string GetCompleteDate(object date)
        {
            if (date == null)
            {
                return "";
            }
            else
            {
                return String.Format("{0:dd/MM/yyyy}", date);
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
