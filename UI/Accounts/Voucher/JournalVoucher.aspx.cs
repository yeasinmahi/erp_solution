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
    public partial class JournalVoucher : BasePage
    {
        protected double totAmountDr = 0, totAmountCr = 0;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Voucher\\JournalVoucher";
        string stop = "stopping Accounts\\Voucher\\JournalVoucher";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
                txtCode.Text = "JV-" + pre + "-";
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
                    btnCheckAll.Enabled = true;
                    btnCompleteAll.Enabled = true;
                    //ColumnShowHide(true);
                    //GridView1.Columns[6].Visible = true;
                    break;
                case "com":
                    hdnCompleted.Value = "true";
                    hdnEnable.Value = "true";
                    btnCheckAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[6].Visible = true;
                    break;
                case "cnd":
                    hdnCompleted.Value = "false";
                    hdnEnable.Value = "false";
                    btnCheckAll.Enabled = false;
                    btnCompleteAll.Enabled = false;
                    //ColumnShowHide(false);
                    //GridView1.Columns[6].Visible = false;
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
            }
            else
            {
                rdoType.Enabled = true;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Cancel", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\JournalVoucher   Cancel ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
            jv.CancelVoucher(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);
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
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\JournalVoucher   Completed ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
            int ret = jv.CompleteVoucher(Session[SessionParams.USER_ID].ToString(), ((Button)sender).CommandArgument);
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            if (ret >= 1)
            {
                jv.Save(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
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

        private void ColumnShowHide(bool show)
        {
            //GridView1.Columns[8].Visible = show;
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
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('VoucherEntryEdit.aspx?id=" + voucherID + "&type=jr&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
                case "com":
                    //str = "<a href=\"#\" onclick=\"ShowPopUp('VoucherEdit.aspx?id=" + voucherID + "&type=jr&unit=" + ddlUnit.SelectedValue + "') \"class=\"link\">Edit</a>";
                    str = "";
                    break;
            }

            return str;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                totAmountDr += double.Parse(((Label)e.Row.Cells[4].Controls[1]).Text);
            }
            catch { }

            try
            {
                totAmountCr += double.Parse(((Label)e.Row.Cells[5].Controls[1]).Text);
            }
            catch { }
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
            var fd = log.GetFlogDetail(start, location, "Completed", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\JournalVoucher   Completed All ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                int gridRowCount;
            string jvID;
            BLL.Accounts.Voucher.JournalVoucher jv = new BLL.Accounts.Voucher.JournalVoucher();
            //string CompleteDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            string CompleteDate = txtCompleteDate.Text;
            int ret;
            gridRowCount = GridView1.Rows.Count;
            for (int i = 0; i < gridRowCount; i++)
            {
                if (((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked)
                {
                    jvID = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value;
                    ret = jv.CompleteVoucher(Session[SessionParams.USER_ID].ToString(), jvID);
                    if (ret >= 1)
                    {
                        jv.Save(jvID, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CompleteDate + " 09:00 AM");
                    }

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
