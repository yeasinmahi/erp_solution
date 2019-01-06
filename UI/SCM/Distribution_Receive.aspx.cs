using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class Distribution_Receive : System.Web.UI.Page
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
            int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            dt = objbll.DistributionData(whid, FromDate, ToDate,1,0);

            if (dt.Rows.Count > 0)
            {
                Distribution_Grid.DataSource = dt;
                Distribution_Grid.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;

            int intTransferID = Convert.ToInt32(((Label)row.FindControl("lblintTransferID")).Text);
            int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            DateTime TransactionDate = Convert.ToDateTime(((Label)row.FindControl("lbldteTransactionDate")).Text);
            int Qty = Convert.ToInt32(((TextBox)row.FindControl("txtQty")).Text);
            int productid = Convert.ToInt32(((Label)row.FindControl("lblintproductionid")).Text);
            int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);

            int intInWHID = 603;
            int intOutWH = 527;
            decimal monValue = Convert.ToDecimal(((Label)row.FindControl("lblmonValue")).Text); ;
            string strRemarks = "Received From APL Central Store";

            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            dt = objbll.DistributionData(whid, FromDate, ToDate, 2, intTransferID); //get location
            int location = Convert.ToInt32(dt.Rows[0]["intStoreLocationID"].ToString());

            //dt = objbll.DistributionData(whid, FromDate, ToDate, 3, intTransferID); //get transfer list

            //int monTransQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
            //itemid = Convert.ToInt32(dt.Rows[0]["intitemid"].ToString());
            //monValue = Convert.ToDecimal(dt.Rows[0]["monValue"].ToString());
            monValue = monValue * -1;

        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Distribution_Grid.DataSource = null;
            Distribution_Grid.DataBind();
        }
    }
}