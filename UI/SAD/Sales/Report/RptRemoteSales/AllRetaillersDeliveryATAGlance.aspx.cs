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
    public partial class AllRetaillersDeliveryATAGlance : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtTo.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadActiveInactiveRetailler();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValue = Convert.ToDecimal(e.Row.Cells[7].Text);

                e.Row.Attributes.Add("onmouseover",
       "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValue > 2999)
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                }
                else if (CellValue > 1)
                {
                    e.Row.Cells[7].BackColor = System.Drawing.Color.GreenYellow;

                }
                else
                    e.Row.Cells[7].BackColor = System.Drawing.Color.Red;

            }




        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadActiveInactiveRetailler();
        }

        private void LoadActiveInactiveRetailler()
        {

            try
            {
                String strEamilTSO = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;

                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC bllActiveinactive = new SAD_BLL.Customer.Report.StatementC();

                dt = bllActiveinactive.bllGetActiveInactiveRetailer(strEamilTSO, dtFromDate, dtToDate);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }

                //else
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data. for the selected date');", true);
                //}

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert ('Sorry there is no data for the selected date');", true);

                }



            }


            
             catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            
            
            }

        }

    }

}