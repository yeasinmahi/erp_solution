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
    public partial class DODetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); }
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private void Loadgrid()
        {
            try
            {
                DateTime dteFromDate = DateTime.Parse(txtFDate.Text);
                DateTime dteToDate = DateTime.Parse(txtTo.Text);
                int intTerritoryID = int.Parse(drdlTerritory.SelectedValue.ToString());
                SalesConfig rmt = new SalesConfig(); DataTable dtShopidsales = new DataTable();
                dtShopidsales = rmt.GetDeliveroderDetaillsinfo(int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString()), dteFromDate, dteToDate, intTerritoryID);
                if (dtShopidsales.Rows.Count > 0)
                {
                    dgvdodtls.DataSource = dtShopidsales;
                    dgvdodtls.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry there is no data.');", true); }


            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }

        protected void dgvdodtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (!String.IsNullOrEmpty(e.Row.Cells[13].Text))
                {
                    if (e.Row.Cells[13].Text == "True")
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                    else if (e.Row.Cells[13].Text == "False")
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                        e.Row.BackColor = System.Drawing.Color.Green;
                }

            }
           
        }

        protected void dgvdodtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvdodtls.PageIndex = e.NewPageIndex;
            Loadgrid();
        }











    }
}