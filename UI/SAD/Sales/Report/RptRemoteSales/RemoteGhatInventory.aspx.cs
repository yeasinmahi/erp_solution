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
    public partial class RemoteGhatInventory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = HttpContext.Current.Session[SessionParams.EMAIL].ToString();
            }
            else
            {

            }
        }

        protected void btnGhatInventory_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
            DateTime dtFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            DateTime dtToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            int productid = int.Parse(drdlProductName.SelectedValue.ToString());
            int Shipingpointid = int.Parse(drdlGhat.SelectedValue.ToString());

            try
            {
                dt = bll.getACCLGhatStock(dtFromDate, dtToDate, Shipingpointid, productid);
            }

            catch{}

            if (dt.Rows.Count > 0)
            {
                grdvGhatInventorySingleProduct.DataSource = dt;
                grdvGhatInventorySingleProduct.DataBind();
            }


            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
            }


        }

        protected void grdvGhatInventorySingleProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}