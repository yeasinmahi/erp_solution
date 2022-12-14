using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report
{
    public partial class ShippingPointBaseCollectionAndDelv : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";
                pnlUpperControl.DataBind();
            }
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (txtCode.Text.Length > 9)
                {
                    try
                    {
                        if (((CheckBox)e.Row.Cells[7].Controls[0]).Checked)
                        {
                            if (txtCode.Text.Length > 9)
                            {
                                rdoComplete.SelectedIndex = 1;
                            }
                        }
                        else
                        {
                            if (txtCode.Text.Length > 9)
                            {
                                rdoComplete.SelectedIndex = 0;
                            }
                        }
                    }
                    catch { }
                }
            }
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
                            if (!((CheckBox)GridView1.Rows[0].Cells[10].Controls[0]).Checked)
                            {
                                rdoComplete.SelectedIndex = 2;
                            }
                            else if (((CheckBox)GridView1.Rows[0].Cells[7].Controls[0]).Checked)
                            {
                                rdoComplete.SelectedIndex = 1;
                            }
                            else
                            {
                                rdoComplete.SelectedIndex = 1111111;
                            }
                        }
                        catch { }
                        //if(rdoComplete.SelectedItem.Text== "Point") { rdoComplete.SelectedIndex = 1; }
                        //else if (rdoComplete.SelectedItem.Text == "Sales office") { rdoComplete.SelectedIndex = 2; }
                        //else if (rdoComplete.SelectedItem.Text == "Point vs Sales Office") { rdoComplete.SelectedIndex = 3; }
                        //else  { rdoComplete.SelectedIndex = 4; } 
                    }
                }

                //if (rdoComplete.SelectedIndex == 0)
                //{
                //    GridView1.Columns[5].Visible = true;
                //    GridView1.Columns[6].Visible = true;
                //    GridView1.Columns[9].Visible = true;
                //}
                //else
                //{
                //    GridView1.Columns[5].Visible = false;
                //    GridView1.Columns[6].Visible = false;
                //    GridView1.Columns[9].Visible = false;
                //}
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
        protected void btnGo_Click(object sender, EventArgs e)
        {
            SetDate();
            GridView1.DataBind();

            if (txtCode.Text.Length > 9)
            {
                rdoComplete.Enabled = false;
                //rdoSalesType.Enabled = false;            
            }
            else
            {
                rdoComplete.Enabled = true;
                //rdoSalesType.Enabled = true;            
            }
        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            ddlCusType.DataBind();
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
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
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCode();
        }
        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            GetCode();
        }

        protected void rdoComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDate();
            EnableDisable();
        }
    }
}