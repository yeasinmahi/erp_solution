using GLOBAL_BLL;
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
    public partial class RetaillerYearlySales : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                txtFrom.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadRetaillerYearSales();
        }

        private void loadRetaillerYearSales()
        {

            try
            {

               
                String strEamilTSO = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                DateTime dtFromJanu = DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
             
                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();


                

                dt = bll.bllGetRetaillerYearlysales(strEamilTSO, dtFromJanu);



                if (dt.Rows.Count > 0)
                {


                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }


                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data. for the selected date');", true);
                }


                //GridView1.DataSource = dt;
                //  GridView1.DataBind();




            }


            catch (Exception ex)
            { 
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            
            
            }



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValue = Convert.ToDecimal(e.Row.Cells[17].Text);

               


                if (CellValue > 11999)
                {
                   
                    e.Row.BackColor = System.Drawing.Color.Green;
                }
                else if (CellValue > 5999)
                {
                    e.Row.BackColor = System.Drawing.Color.GreenYellow;

                }
                else
                    e.Row.BackColor = System.Drawing.Color.Red;

            }












        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadRetaillerYearSales();

        }

    }
}