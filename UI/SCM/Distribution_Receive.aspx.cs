using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class DistributionReceive : BasePage
    {
        private DataTable dt = new DataTable();
        private readonly InventoryTransfer_BLL _objbll = new InventoryTransfer_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    dt = _objbll.GetWH(Enroll);
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

        private void GridBind()
        {
            int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            dt = _objbll.DistributionData(whid, FromDate, ToDate, 1, 0);

            if (dt.Rows.Count > 0)
            {
                Distribution_Grid.DataSource = dt;
                Distribution_Grid.DataBind();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int location = 0;
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            int Enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());

            int intTransferID = Convert.ToInt32(((Label)row.FindControl("lblintTransferID")).Text);
            int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            int intUnitID = Convert.ToInt32(((Label)row.FindControl("lblintUnitID")).Text);
            DateTime TransactionDate = Convert.ToDateTime(((Label)row.FindControl("lbldteTransactionDate")).Text);
            decimal Qty = Convert.ToDecimal(((TextBox)row.FindControl("txtQty")).Text);
            int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);
            decimal monValue = Convert.ToDecimal(((Label)row.FindControl("lblmonValue")).Text);
            string strRemarks = "Received From APL Central Store";

            int intInWHID = ddlWH.SelectedValue();
            monValue = monValue * -1;

            int intOutWH = Convert.ToInt32(((Label)row.FindControl("lblintOutWHID")).Text); ;
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

            dt = _objbll.DistributionData(intInWHID, FromDate, ToDate, 2, intTransferID); //get location
            if (dt.Rows.Count > 0)
            {
                location = Convert.ToInt32(dt.Rows[0]["intStoreLocationID"].ToString());
            }

            if (dt.Rows.Count > 0)
            {
                dt = _objbll.InsertReceiveData(intUnitID, intInWHID, intOutWH, location, Enroll, itemid, Qty, monValue, 0, strRemarks, intTransferID, 1, true);
                string msg = dt.Rows[0]["strOutput"].ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('" + msg + "')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Data Not Found')", true);
            }

            GridBind();
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Distribution_Grid.DataSource = null;
            Distribution_Grid.DataBind();
        }
    }
}