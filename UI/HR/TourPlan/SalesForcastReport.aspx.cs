using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.TourPlan
{
    public partial class SalesForcastReport : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
        private void loadgrid()
        {
            int intDeptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());

            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());

            int jobstation = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            if (rptTypeid == 1)               //Detaills report 
            {
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnemail = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
                    string email = hdnemail;
                    string hdnunit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    int unit = int.Parse(hdnunit);
                    dt = bll.GetSalesforacast(dteFromDate, dteToDate, email);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0) { grdvSalesForCast.DataSource = dt; grdvSalesForCast.DataBind(); }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }
            }
        }



        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void grdvSalesForCast_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvSalesForCast.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvSalesForCast_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i <= grdvSalesForCast.Rows.Count - 1; i++)
            {
                Label lblterritoryid = (Label)grdvSalesForCast.Rows[i].FindControl("Labelterritoryid");
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                if (lblterritoryid.Text == "0")
                {
                    grdvSalesForCast.Rows[i].BackColor = Color.DarkKhaki;
                }
                
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Decimal CellValueDelv = Convert.ToDecimal(e.Row.Cells[2].Text);
                Decimal CellValueTarget = Convert.ToDecimal(e.Row.Cells[3].Text);
                Decimal CellValue100P = Convert.ToDecimal(e.Row.Cells[4].Text);
                if (CellValueDelv > CellValueTarget)
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                }

                else
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
                }

                if (CellValue100P > 100)
                {
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightGreen;
                }


            }
        }
    }
}