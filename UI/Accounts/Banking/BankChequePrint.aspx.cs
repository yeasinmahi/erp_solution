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
using BLL.Accounts.Banking;
using UI.ClassFiles;

namespace UI.Accounts.Banking
{
    public partial class BankChequePrint : BasePage
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
                case "true":
                    ColumnShowHide(false);
                    break;
                case "false":
                    ColumnShowHide(true);
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
        /* protected void btnChange_Click(object sender, EventArgs e)
         {
             BankVoucher bv = new BankVoucher();
             bv.ChangeChequeNo(((Button)sender).CommandArgument, Session["sesUserID"].ToString());
             GridView1.DataBind();
         }*/
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            string str = ((Button)sender).CommandArgument;
            string id = str.Substring(0, str.IndexOf('#'));
            string code = str.Substring(str.IndexOf('#') + 1);

            VoucherForChqPrint vp = new VoucherForChqPrint();
            if (code.ToLower().StartsWith("b")) vp.MakePrinted(Session[SessionParams.USER_ID].ToString(), id);
            else vp.MakePrintedContra(Session[SessionParams.USER_ID].ToString(), id);
            GridView1.DataBind();

            BankContraChqBearerST.ReloadCustomer(ddlUnit.SelectedValue);
        }

        protected void rdoByDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pre = CommonClass.GetMonthNameByValue(DateTime.Now.Month) + DateTime.Now.Year.ToString().Substring(2, 2);
            txtCode.Text = "BP-" + pre + "-";
        }

        private void ColumnShowHide(bool show)
        {
            GridView1.Columns[9].Visible = show;
            GridView1.Columns[11].Visible = show;
            GridView1.Columns[12].Visible = show;
        }

        protected string LinkString(object id, object code, string JSfunc, string link, string text)
        {
            string str = "";
            str = "<a href=\"#\" onclick=\"" + JSfunc + "('" + link + "?id=" + id;
            if (code.ToString().ToLower().StartsWith("c")) str += "&type=cn";
            else str += "&type=bn&isDr=true";
            str += "')\" class=\"link\">" + text + "</a>";
            return str;
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            VoucherRollback vr = new VoucherRollback();
            lblStatus.Text = vr.ChequeNoInterchange(ddlUnit.SelectedValue, txtCode1.Text, txtCode2.Text, Session[SessionParams.USER_ID].ToString());
            GridView1.DataBind();
        }
    }
}
