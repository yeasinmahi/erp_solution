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
    public partial class MoneyReceiptStatus : BasePage
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        private void LoadMRGrid()
        {
            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bllMR = new SAD_BLL.Customer.Report.StatementC();
            try
            {
                String strEamilTSO = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;

                dt = bllMR.bllGetMRRListTerritoryBase(dtFromDate, dtToDate, strEamilTSO);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert ('Sorry there is no data for the selected date');", true);

                }


            }

            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }


        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadMRGrid();
        }

    }
}