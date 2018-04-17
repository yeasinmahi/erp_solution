using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class DeliveryRequestAccess : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int shippingpointid, unitid, rpttype, whtype, stockstatusfor; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        SalesView bll = new SalesView();

        decimal totalcom, comrate, selectedtotalcom = 0;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {


                unitid = int.Parse(ddlUnit.SelectedValue.ToString());
               
                stockstatusfor = int.Parse(drdlrpt.SelectedValue);
                rpttype = int.Parse(ddltypeofrPT.SelectedValue.ToString());
                rpttype = 2;
                shippingpointid = int.Parse(ddlShip.SelectedValue);
                dt = bll.FinishGoodsstock(unitid, 1, shippingpointid);
                if (dt.Rows.Count > 0)
                {
                    grdvStock.DataSource = dt;
                    grdvStock.DataBind();

                    decimal totopening = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingorderqnt"));
                    decimal totalpendingqntpricevalue = dt.AsEnumerable().Sum(row => row.Field<decimal>("pendingqntpricevalue"));
                    decimal totalclosingqnt = dt.AsEnumerable().Sum(row => row.Field<decimal>("closingqnt"));
                    decimal totalshortage = dt.AsEnumerable().Sum(row => row.Field<decimal>("shortage"));
                    grdvStock.FooterRow.Cells[2].Text = "Total";
                    grdvStock.FooterRow.Cells[4].Text = totopening.ToString("N2");
                    grdvStock.FooterRow.Cells[5].Text = totalpendingqntpricevalue.ToString("N2");
                    grdvStock.FooterRow.Cells[8].Text = totalclosingqnt.ToString("N2");
                    grdvStock.FooterRow.Cells[9].Text = totalshortage.ToString("N2");


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }
        }

        protected void grdvStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            whtype = int.Parse(ddltypeofrPT.SelectedValue);
            e.Row.Attributes.Add("onmouseover",
               "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            if (rpttype == 1)
            {
                grdvStock.Columns[6].Visible = true;
                grdvStock.Columns[7].Visible = true;
                e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                e.Row.Cells[7].BackColor = System.Drawing.Color.Green;

              
            }
            else
            {
                grdvStock.Columns[6].Visible = false;
                grdvStock.Columns[7].Visible = false;
               
            }
        }
    }
}