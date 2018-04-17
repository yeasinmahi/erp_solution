using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RptLastTransactionDateAndDelv : BasePage
    {

        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
             
            }
        }

         private void loadgrid()
        {
            int intDeptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
            int unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            int salesofficeid = int.Parse(drdlSalesoffice.SelectedValue.ToString());
            int limitdays = int.Parse(drdlLimitDays.SelectedItem.Text.ToString());
          
           
             //DateTime dtFromDate, int limitday, int salesofficeid, int unit
            //try
            //{
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                dt = bll.getRptLastTransactionDateAndLastDelvDate(dteFromDate, limitdays, salesofficeid, unitid);


                if (dt.Rows.Count > 0)
                {
                    grdvLastTransactionDate.DataSource = dt;

                    grdvLastTransactionDate.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            //}

            //catch { }
            
        }
        protected void btnLastTransaction_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvLastTransactionDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvLastTransactionDate.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvLastTransactionDate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValuLimitDay = Convert.ToDecimal(e.Row.Cells[3].Text);
                Decimal CellValueGapTransactionDate = Convert.ToDecimal(e.Row.Cells[8].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


               if (CellValuLimitDay < CellValueGapTransactionDate)
                {
                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;

                }
                else
                    e.Row.Cells[8].BackColor = System.Drawing.Color.GreenYellow;

            }
        }

        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {

            grdvLastTransactionDate.AllowPaging = false;
            SAD_BLL.Customer.Report.ExportClass.Export("Exceed.xls", grdvLastTransactionDate);

        }
    }
}