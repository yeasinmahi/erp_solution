using System;
using System.Data;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.Transfer
{
    public partial class FgTransferReport : BasePage
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
                    Common.LoadDropDown(ddlWH, _dt, "Id", "strName");
                    Common.LoadDropDown(ddlToWH, _dt, "Id", "strName");
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = now.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
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
            int whid = Common.GetDdlSelectedValue(ddlWH);
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            _dt = _bll.GetData(1, whid, fromDate, toDate);

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
    }
}