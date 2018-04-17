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
using BLL.Accounts.Banking;
using UI.ClassFiles;

namespace UI.Accounts.Banking
{
    public partial class BankForceReconcile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["sesUserID"] = "1";
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }

        }

        protected void ddlBranch_DataBound(object sender, EventArgs e)
        {
            ddlAccount.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
            GridView2.DataBind();
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            char[] ch = { '#' };
            string[] str = ((Button)sender).CommandArgument.Split(ch);

            Reconcile rc = new Reconcile();

            if (str[0].ToLower() == "b")
            {
                if (RadioButtonList1.SelectedValue == "false") rc.ManualBankReconcile(str[1], true, txtTo.Text);
                else rc.ManualBankReconcile(str[1], false, txtTo.Text);
            }
            else if (str[0].ToLower() == "c")
            {
                if (RadioButtonList1.SelectedValue == "false") rc.ManualContraReconcile(str[1], true, txtTo.Text);
                else rc.ManualContraReconcile(str[1], false, txtTo.Text);

            }
            else if (str[0].ToLower() == "s")
            {
                if (RadioButtonList1.SelectedValue == "false") rc.ManualStatementReconcile(str[1], true, txtTo.Text);
                else rc.ManualStatementReconcile(str[1], false, txtTo.Text);
            }
            else if (str[0].ToLower() == "d")
            {
                if (RadioButtonList1.SelectedValue == "false") rc.ManualContraDetailsReconcile(str[1], true, txtTo.Text);
                else rc.ManualContraDetailsReconcile(str[1], false, txtTo.Text);
            }
            else if (str[0].ToLower() == "o")
            {
                if (RadioButtonList1.SelectedValue == "false") rc.ManualOpeningReconcile(str[1], true, txtTo.Text);
                else rc.ManualOpeningReconcile(str[1], false, txtTo.Text);
            }

            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridView1.Caption = DropDownList1.SelectedItem.Text;
        }
        protected void GridView2_DataBound(object sender, EventArgs e)
        {
            Reconcile rc = new Reconcile();
            GridView2.Caption = rc.GetReconcileTypeMatched(DropDownList1.SelectedValue);
        }

        protected string GetTotal1(int col)
        {

            return GetTotal(col, GridView1);
        }

        protected string GetTotal2(int col)
        {
            return GetTotal(col, GridView2);
        }

        protected string GetTotal(int col, GridView grid)
        {
            decimal tot = 0;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    tot += decimal.Parse(((Label)grid.Rows[i].Cells[col].Controls[1]).Text);

                }
            }

            return CommonClass.GetFormettingNumber(tot);
        }
    }
}

