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
using SAD_BLL.Global;
using UI.ClassFiles;

namespace UI.SAD.Sales
{
    public partial class SalesAccounts : BasePage
    {
        //protected decimal totAmount = 0, totPieces = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";            
                pnlUpperControl.DataBind();

                txtCompleteDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }

        }
        protected void btnGo_Click(object sender, EventArgs e)
        {

            SetDate();
            GridView1.DataBind();

            if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
                rdoEntryBy.Enabled = false;
            }
            else
            {
                rdoComplete.Enabled = true;
                rdoEntryBy.Enabled = true;
            }
        }
        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            SalesView sv = new SalesView();
            sv.SubLedgerEntry(((Button)sender).CommandArgument, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CommonClass.GetDateAtSQLDateFormat(txtCompleteDate.Text + " 09:00 AM"));
            GridView1.DataBind();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SalesView sv = new SalesView();
                sv.ChallanCancel(((Button)sender).CommandArgument, Session[SessionParams.USER_ID].ToString());
                GridView1.DataBind();
                ///======= Edited By Alamin For Internal Transport=======
                sv.TripCancel(((Button)sender).CommandArgument);
                ///======== End Edited ========================
            }
            catch { }
        }
        protected string GetEditLink(object voucherID, object completed)
        {
            string str = "";

            switch (completed.ToString().ToLower())
            {
                case "false":
                    str = "<a href=\"#\" onclick=\"ShowPopUpE('DOEntry2.aspx?id=" + voucherID + "&unit=" + ddlUnit.SelectedValue + "')\"class=\"link\">Edit</a>";
                    break;
                case "true":
                    str = "";
                    break;
            }

            return str;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected string GetGrandTotal(int col)
        {
            decimal tot = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        tot += decimal.Parse(((Label)GridView1.Rows[i].Cells[col].Controls[1]).Text);
                    }
                    catch { }

                }
            }

            return CommonClass.GetFormettingNumber(tot);
        }
        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDate();
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
                            if (!((CheckBox)GridView1.Rows[0].Cells[14].Controls[0]).Checked)
                            {
                                rdoComplete.SelectedIndex = 2;
                            }
                            else if (((CheckBox)GridView1.Rows[0].Cells[11].Controls[0]).Checked)
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

                if (rdoComplete.SelectedIndex == 0)
                {
                    GridView1.Columns[0].Visible = true;
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[12].Visible = true;
                    btnCompleteAll.Visible = true;
                    btnSelect.Visible = true;
                    btnUnSelect.Visible = true;
                }
                else
                {
                    GridView1.Columns[0].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[12].Visible = false;
                    btnCompleteAll.Visible = false;
                    btnSelect.Visible = false;
                    btnUnSelect.Visible = false;
                }
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void SetDate()
        {
            DateTime fromDate;
            DateTime toDate;
            if (txtFrom.Text != "")
            {
                fromDate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
            }
            else
            {
                fromDate = DateTime.Now.AddDays(-7).Date;
            }
            if (txtTo.Text != "")
            {
                toDate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            }
            else
            {
                toDate = DateTime.Now.AddDays(7).Date;
            }

            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    ((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked = true;
                }
            }
        }
        protected void btnUnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    ((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked = false;
                }
            }
        }
        protected void btnCompleteAll_Click(object sender, EventArgs e)
        {
            string idList = "";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)GridView1.Rows[i].Cells[0].Controls[1]).Checked)
                    {
                        idList += GridView1.Rows[i].Cells[13].Text + ",";
                    }
                }
            }

            if (idList.Length > 0)
            {
                idList = idList.Substring(0, idList.Length - 1);

                SalesEntry se = new SalesEntry();
                se.SubLedgerEntryFromIdList(idList, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), CommonClass.GetDateAtSQLDateFormat(txtCompleteDate.Text + " 09:00 AM"));
            }

            GridView1.DataBind();
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            ddlShip.DataBind();
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
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            GetCode();
        }
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCode();
        }
    }
}