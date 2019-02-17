using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.Transfer
{
    public partial class ProductionTransferReport : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly FgTransferBll _bll = new FgTransferBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    _dt = new InventoryTransfer_BLL().GetTtransferDatas(1, "", 0, 0, DateTime.Now, Enroll);
                    ddlWH.Loads(_dt, "Id", "strName");
                    //ddlToWH.Loads(_dt, "Id", "strName");
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = now.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Warning);
                }
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid.UnLoad();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        private void GridBind()
        {
            int whid = ddlWH.SelectedValue();
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            _dt = _bll.GetFgProductionReport(whid, fromDate, toDate);

            if (_dt.Rows.Count > 0)
            {
                Grid.DataSource = _dt;
                Grid.DataBind();
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }

        private double _productionQuantity = 0;
        private double _sentQuantity = 0;
        private double _receiveQuantity = 0;
        protected void Grid_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _productionQuantity += !string.IsNullOrWhiteSpace((e.Row.FindControl("lblNumProdQty") as Label)?.Text) ?  Convert.ToDouble((e.Row.FindControl("lblNumProdQty") as Label)?.Text):0;
                _sentQuantity += !string.IsNullOrWhiteSpace((e.Row.FindControl("lblNumSendStoreQty") as Label)?.Text) ? Convert.ToDouble((e.Row.FindControl("lblNumSendStoreQty") as Label)?.Text):0;
                _receiveQuantity += !string.IsNullOrWhiteSpace((e.Row.FindControl("lblNumStoreReceiveQty") as Label)?.Text)? Convert.ToDouble((e.Row.FindControl("lblNumStoreReceiveQty") as Label)?.Text):0;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (e.Row.FindControl("lblNumProdQtyFooter") is Label s) s.Text = _productionQuantity.ToString(CultureInfo.InvariantCulture);
                if (e.Row.FindControl("lblNumSendStoreQtyFooter") is Label t) t.Text = _sentQuantity.ToString(CultureInfo.InvariantCulture);
                if (e.Row.FindControl("lblNumStoreReceiveQtyFooter") is Label u) u.Text = _receiveQuantity.ToString(CultureInfo.InvariantCulture);
            }
            
        }
    }
}