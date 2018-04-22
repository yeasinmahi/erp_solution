using BLL.Accounts.Advice;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Accounts.Advice
{
    public partial class PaymentAdvice : BasePage
    {
        DataTable dt; AdviceBLL bll = new AdviceBLL();
        int intUnitID, intWork, ysnCompleted, intAdviceType, intBankType, intAutoID, intActionBy;
        string strAccountMandatory, strBankName, xmlpath; DateTime dteDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    //pnlUpperControl.DataBind();
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;

                    HideControl();
                }
                catch
                { }
            }
        }

        protected void ddlAdviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intAdviceType = int.Parse(ddlAdviceType.SelectedValue.ToString());
                if (intAdviceType == 3)
                {
                    ddlChillingCenter.Visible = true;
                    lblChillingCenter.Visible = true;
                }
                else
                {
                    ddlChillingCenter.Visible = false;
                    lblChillingCenter.Visible = false;
                }
            }
            catch { }
        }

        protected void ddlBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetAccountDetails(intAutoID);
                lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
                lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();
            }
            catch { }
        }

        protected void ddlFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                LoadAccountList();
            }
            catch { }
        }

        private void LoadAccountList()
        {

            divExport.Visible = false;
            divExportIBBL.Visible = false;
            intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            if (intBankType == 1)
            {
                dt = new DataTable();
                dt = bll.GetIBBLBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();

                divExport.Visible = false;
                divExportIBBL.Visible = true;
            }
            else if (intBankType != 0)
            {
                dt = new DataTable();
                dt = bll.GetOtherBank(intUnitID);
                ddlBankAccount.DataSource = dt;
                ddlBankAccount.DataTextField = "BankName";
                ddlBankAccount.DataValueField = "intID";
                ddlBankAccount.DataBind();

                divExport.Visible = true;
                divExportIBBL.Visible = false;
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HideControl();
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetUnitAddress(intUnitID);
                lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                LoadAccountList();
            }
            catch { }
        }

        private void HideControl()
        {
            lblUnitName.Visible = false;
            lblUnitAddress.Visible = false;
            lblTo.Visible = false;
            lblManager.Visible = false;
            lblBankName.Visible = false;
            lblBankAddress.Visible = false;
            lblSubject.Visible = false;
            lblDearSir.Visible = false;
            lblMailBody.Visible = false;
            lblDetails.Visible = false;
            lblWord.Visible = false;
            lblForUnit.Visible = false;
            lblAuth1.Visible = false;
            lblAuth2.Visible = false;
            lblAuth3.Visible = false;
            dgvAdvice.DataSource = dt;
            dgvAdvice.DataBind();
        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
            LoadGridExport();
        }

        private void LoadGrid()
        {
            try
            {
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
                intActionBy = int.Parse(hdnEnroll.Value.ToString());

                if (intBankType == 0)
                {
                    return;
                }
                else if (intBankType == 1)
                {

                }
                else
                {

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitAddress(intUnitID);
                    lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                    lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                    lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                    dteDate = DateTime.Parse(txtDate.Text.ToString());
                    intWork = 0;
                    strAccountMandatory = ddlMandatory.SelectedItem.ToString();
                    strBankName = ddlFormat.SelectedItem.ToString();
                    ysnCompleted = int.Parse(ddlVoucher.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetPartyAdvice(intActionBy, intUnitID, dteDate, intWork, strAccountMandatory, strBankName, ysnCompleted);
                    //dgvReport.DataSource = dt;
                    //dgvReport.DataBind();

                }

            }
            catch { }
        }
        private void LoadGridExport()
        {
            try
            {
                intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                intBankType = int.Parse(ddlFormat.SelectedValue.ToString());
                intActionBy = int.Parse(hdnEnroll.Value.ToString());

                if (intBankType == 0)
                {
                    return;
                }
                else if (intBankType == 1)
                {

                }
                else
                {

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetUnitAddress(intUnitID);
                    lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                    lblForUnit.Text = "For " + dt.Rows[0]["strDescription"].ToString();
                    lblUnitAddress.Text = dt.Rows[0]["strAddress"].ToString();

                    dteDate = DateTime.Parse(txtDate.Text.ToString());
                    intWork = 0;
                    strAccountMandatory = ddlMandatory.SelectedItem.ToString();
                    strBankName = ddlFormat.SelectedItem.ToString();
                    ysnCompleted = int.Parse(ddlVoucher.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetAdviceData(intActionBy);
                    dgvAdvice.DataSource = dt;
                    dgvAdvice.DataBind();
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();

                }
                if (dgvAdvice.Rows.Count > 0)
                {
                    //LoadGridExport();

                    lblUnitName.Visible = true;
                    lblUnitAddress.Visible = true;
                    lblTo.Visible = true;
                    lblManager.Visible = true;
                    lblBankName.Visible = true;
                    lblBankAddress.Visible = true;
                    lblSubject.Visible = true;
                    lblDearSir.Visible = true;
                    lblMailBody.Visible = true;
                    lblDetails.Visible = true;
                    lblWord.Visible = true;
                    lblForUnit.Visible = true;
                    lblAuth1.Visible = true;
                    lblAuth2.Visible = true;
                    lblAuth3.Visible = true;

                    intAutoID = int.Parse(ddlBankAccount.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetAccountDetails(intAutoID);
                    lblBankName.Text = dt.Rows[0]["strBankDetailsName"].ToString();
                    lblBankAddress.Text = dt.Rows[0]["strBankAddress"].ToString();
                    lblMailBody.Text = "We do hereby requesting you to make payment by transferring the amount to the respective Account Holder as shown below in detailed by debiting our" + "<br/>" + "CD Account No. " + dt.Rows[0]["strAccountNo"].ToString();

                    AmountFormat formatAmount = new AmountFormat();
                    string totalAmountInWord = formatAmount.GetTakaInWords(totalamount, "", "Only");
                    lblWord.Text = "In Word: " + totalAmountInWord.ToString();
                    HdnValue.Value = "";

                }
            }
            catch { }
        }


        protected decimal totalamount = 0;

        protected string accounttext;
        protected string routingtext;
        protected void dgvAdvice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmount")).Text);
                    accounttext = ((Label)e.Row.Cells[5].FindControl("lblAccountNo")).Text;
                    Label lblNum = (Label)(e.Row.FindControl("lblAccountNo"));
                    lblNum.Text = "'" + accounttext;
                    routingtext = ((Label)e.Row.Cells[9].FindControl("lblRoutingNo")).Text;
                    Label lblNum2 = (Label)(e.Row.FindControl("lblRoutingNo"));
                    lblNum2.Text = "'" + routingtext;

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lbl = (Label)(e.Row.FindControl("lblTTTotal"));
                    lbl.Text = String.Format("{0:n}", totalamount);
                }
            }
            catch { }
        }
        protected decimal totalamountibbl = 0;

        protected string accounttextibbl;
        protected void dgvAdviceIBBL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamountibbl += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblAmount")).Text);
                    accounttextibbl = ((Label)e.Row.Cells[1].FindControl("lblAccountNo")).Text;
                    Label lblNumibbl = (Label)(e.Row.FindControl("lblAccountNo"));
                    lblNumibbl.Text = "'" + accounttextibbl;

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblibbl = (Label)(e.Row.FindControl("lblTTTotal"));
                    lblibbl.Text = String.Format("{0:n}", totalamountibbl);
                }
            }
            catch { }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = ddlAdviceType.SelectedItem.ToString() + " for " + ddlUnit.SelectedItem.ToString();
            string html = HdnValue.Value;
            ExportToExcel(ref html, fileName);

        }
        public void ExportToExcel(ref string html, string fileName)
        {
            html = html.Replace("&gt;", ">");
            html = html.Replace("&lt;", "<");
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".xls");
            HttpContext.Current.Response.ContentType = "application/xls";
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string senderdata = ((Button)sender).CommandArgument.ToString();
                //string[] data = senderdata.Split(delimiterChars);
                int intID = int.Parse(senderdata.ToString());

                bll.DeleteData(intID);
                LoadGridExport();

            }
            catch { }
        }
    }
}