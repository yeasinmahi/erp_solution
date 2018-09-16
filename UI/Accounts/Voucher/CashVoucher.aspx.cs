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
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.Accounts.Voucher
{
    public partial class CashVoucher : BasePage
    {
        protected double totAmount = 0;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Voucher\\CashVoucher";
        string stop = "stopping Accounts\\Voucher\\CashVoucher";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                GridView1.Columns[9].Visible = false;
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "CP-" + pre + "-";
            }
        }

        protected void rdoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoType.SelectedValue)
            {
                case "act":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "true";
                    btnCheckAll.Enabled = true;
                    btnCompleteAll.Enabled = true;
                    //ColumnShowHide(true);
                    //GridView1.Columns[4].Visible = true;
                    break;
                case "com":
                    hdnCompleted.Value = "true";
                    hdnEnable.Value = "true";
                    btnCheckAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[4].Visible = true;
                    break;
                case "cnd":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "false";
                    btnCheckAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[4].Visible = false;
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
            var fd = log.GetFlogDetail(start, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\CashVoucher   Cancel ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
            cv.CancelVoucher(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);
            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Cancel", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Completed", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\CashVoucher   Completed ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
            int ret = cv.FinishedVoucher(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);

            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            if (ret >= 1)
            {
                if (ddlDrCr.SelectedIndex == 0)
                {
                    cv.SaveDr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                }
                else
                {
                    cv.SaveCr(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                }
            }

            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Completed", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Completed", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                if (
                    ((CheckBox)GridView1.Rows[0].Cells[11].Controls[0]).Checked//ysnEnabled
                    &&
                    ((CheckBox)GridView1.Rows[0].Cells[12].Controls[0]).Checked//ysnCompleted
                    )
                {
                    rdoType.SelectedIndex = 1;
                    ColumnShowHide(false);
                }
                else if (
                    !((CheckBox)GridView1.Rows[0].Cells[11].Controls[0]).Checked//ysnEnabled
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

        protected void ddlDrCr_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoType.SelectedValue)
            {
                case "act":
                    ColumnShowHide(true);
                    GridView1.Columns[6].Visible = true;
                    break;
                case "com":
                    ColumnShowHide(false);
                    GridView1.Columns[6].Visible = true;
                    break;
                case "cnd":
                    ColumnShowHide(false);
                    GridView1.Columns[6].Visible = false;
                    break;
            }

            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            if (ddlDrCr.SelectedIndex == 0)
            {
                txtCode.Text = "CP-" + pre + "-";
            }
            else
            {
                txtCode.Text = "CR-" + pre + "-";
            }
        }

        private void ColumnShowHide(bool show)
        {
            if (show)
            {
                if (ddlDrCr.SelectedIndex == 0)
                {
                    //GridView1.Columns[6].Visible = true;
                    GridView1.Columns[9].Visible = false;
                }
                else
                {
                    //GridView1.Columns[6].Visible = false;
                    GridView1.Columns[9].Visible = true;
                }
            }
            else
            {
                //GridView1.Columns[6].Visible = show;
                GridView1.Columns[9].Visible = show;
            }

            GridView1.Columns[10].Visible = show;
            GridView1.Columns[13].Visible = show;
            GridView1.Columns[0].Visible = show;

        }

        protected string GetEditLink(object voucherID)
        {
            string str = "";

            switch (rdoType.SelectedValue)
            {
                case "act":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntryEdit.aspx?id=" + voucherID + "&type=ch&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
                case "com":
                    //str = "<a href=\"#\" onclick=\"ShowPopUpVr('VoucherEdit.aspx?id=" + voucherID + "&type=ch&isDr=" + ddlDrCr.SelectedValue + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    str = "";
                    break;
            }

            return str;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totAmount += double.Parse(((Label)e.Row.Cells[3].Controls[1]).Text);
                }
                catch { }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                if (ddlDrCr.SelectedIndex == 0)
                {
                    e.Row.Cells[4].Text = "Pay To";
                }

                else
                {
                    e.Row.Cells[4].Text = "Receive From";
                }
            }

        }
        protected void btnCheckAll_Click(object sender, EventArgs e)
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

            var fd = log.GetFlogDetail(start, location, "CompleteAll", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\CashVoucher   CompleteAll ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int gridRowCount;
            string cvID;
            BLL.Accounts.Voucher.CashVoucher cv = new BLL.Accounts.Voucher.CashVoucher();
            int ret;
            gridRowCount = GridView1.Rows.Count;
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            for (int i = 0; i < gridRowCount; i++)
            {
                if (((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked)
                {
                    cvID = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value;
                    ret = cv.FinishedVoucher(Session[SessionParams.USER_ID].ToString(), cvID);
                    if (ret >= 1)
                    {


                        if (ddlDrCr.SelectedIndex == 0)
                        {
                            cv.SaveDr(cvID, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                        }
                        else
                        {
                            cv.SaveCr(cvID, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                        }
                    }
                }
            }

            GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "CompleteAll", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "CompleteAll", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public string GetPayToReceiveFromString(string payTo, string receiveFrom)
        {
            if (payTo == null || payTo == "")
            {
                return receiveFrom;
            }
            else
            {
                return payTo;
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
            try
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
            catch { }

        }

    }
}
