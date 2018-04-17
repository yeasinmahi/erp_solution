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
    public partial class RemoteRptDistributorCoverage : BasePage
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
            gridDistCoverage();
        }

        public void gridDistCoverage()
        {
            try
            {

                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;                

                String strEamilTSO = Session[SessionParams.EMAIL].ToString();

                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC stbll = new SAD_BLL.Customer.Report.StatementC();

                dt = stbll.GetDistributorCoverage(dtFromDate, dtToDate, strEamilTSO);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch
            {

            }

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValue = Convert.ToDecimal(e.Row.Cells[10].Text);

                e.Row.Attributes.Add("onmouseover",
       "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValue > 100)
                {
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Green;
                }
                else if (CellValue > 1)
                {
                    e.Row.Cells[10].BackColor = System.Drawing.Color.GreenYellow;

                }
                else
                    e.Row.Cells[10].BackColor = System.Drawing.Color.Red;

            }


        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}