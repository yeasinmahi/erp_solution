using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Data;
using Utility;

namespace UI.SCM
{
    public partial class FG_Receive : BasePage
    {
        DataTable dt = new DataTable();
        InventoryTransfer_BLL objbll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    int enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
                    dt = objbll.GetWH(enroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataBind();
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                catch { }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void GridBind()
        {
            int whid = 527;//Convert.ToInt32(ddlWH.SelectedItem.Value);
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            dt = objbll.FGReceive_Data(whid, FromDate, ToDate);

            if (dt.Rows.Count > 0)
            {
                FG_Grid.DataSource = dt;
                FG_Grid.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

            int autoid = Convert.ToInt32(((Label)row.FindControl("lblAutoID")).Text);
            int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            DateTime InvDate = Convert.ToDateTime(((Label)row.FindControl("lblLastActionTime")).Text);
            decimal StoreQty = Convert.ToDecimal(((TextBox)row.FindControl("txtSendStoreQty")).Text);
            int productid = Convert.ToInt32(((Label)row.FindControl("lblintproductionid")).Text);
            int whid = 527;//Convert.ToInt32(ddlWH.SelectedItem.Value);




        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            FG_Grid.DataSource = null;
            FG_Grid.DataBind();
        }
    }
}