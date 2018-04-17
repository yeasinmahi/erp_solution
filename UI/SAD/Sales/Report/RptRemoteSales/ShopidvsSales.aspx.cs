using SAD_BLL.Sales;
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
    public partial class ShopidvsSales : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); }
        }

        protected void btnShowReportsHOPVSsALES_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dteFromDate = DateTime.Parse(txtFDate.Text);
                DateTime dteToDate = DateTime.Parse(txtTo.Text);

                int intShopid = int.Parse(txtShopid.Text);
                SalesConfig rmt = new SalesConfig(); DataTable dtShopidsales = new DataTable();
                dtShopidsales = rmt.GetShopvsSalesbll(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), dteFromDate, dteToDate, intShopid);
                if (dtShopidsales.Rows.Count > 0)
                {
                    dgvshpvdsls.DataSource = dtShopidsales;
                    dgvshpvdsls.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }


            }
            catch (Exception ex) 
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
    }
}