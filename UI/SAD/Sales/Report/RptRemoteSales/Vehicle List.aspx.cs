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
    public partial class Vehicle_List : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadGridVehicleListweightbridge();
        }

        private void loadGridVehicleListweightbridge()
        {

            try
            {
                DataTable dt = new DataTable();
                SAD_BLL.Customer.Report.StatementC st = new SAD_BLL.Customer.Report.StatementC();

                String strEmail = Session[UI.ClassFiles.SessionParams.EMAIL].ToString();
                dt = st.bllRmtVehicleListWeightBridge();

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

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);


            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}