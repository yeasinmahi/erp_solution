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
    public partial class DONumberSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadSupportData();
        }

        private void loadSupportData()
        {
            try
            {
                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC st = new SAD_BLL.Customer.Report.StatementC();
                String strEmail = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                
                String strDONumb = txtDO.Text;


                dt = st.bllRmtDOSearch(strDONumb);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert ('Sorry there is no data ');", true);
                }

            }


            catch(Exception ex)
            {
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadSupportData();
        }
    }
}