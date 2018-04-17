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
    public partial class FinishGoodsStock : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        int whid, unitid, rpttype, whtype, stockstatusfor; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
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

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        #region =============== Click Event Here ===================== 
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {


                unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                whid = int.Parse(ddlUnit.SelectedValue);
                stockstatusfor = int.Parse(drdlrpt.SelectedValue);
                whtype = int.Parse(ddltypeofrPT.SelectedValue);
                dt = bll.FinishGoodsstock(unitid, stockstatusfor, rpttype);
                if (dt.Rows.Count > 0)
                {
                    grdvStock.DataSource = dt;
                    grdvStock.DataBind();

                    //decimal txtopening= dt.AsEnumerable().Sum(row => row.Field<decimal>("openingqnt"));
                    //decimal txtclosing = dt.AsEnumerable().Sum(row => row.Field<decimal>("closingqnt"));
                    //decimal totalsoldshop = dt.AsEnumerable().Sum(row => row.Field<decimal>("intSoldShopf1"));





                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
            catch { }
        }

           


            protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdvStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSo_DataBound(object sender, EventArgs e)
        {

        }
        protected void grdvStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            whtype = int.Parse(ddltypeofrPT.SelectedValue);
            e.Row.Attributes.Add("onmouseover",
               "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            if (whtype == 1 )
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
        #endregion
    }
}