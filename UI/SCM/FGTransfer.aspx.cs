using System;
using System.Data;
using System.Web.UI.WebControls;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class FgTransfer : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly InventoryTransfer_BLL _objbll = new InventoryTransfer_BLL();
        private StoreIssue_BLL objIssue = new StoreIssue_BLL();
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
            GridViewUtil.UnLoadGridView(FG_Grid);
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
                FG_Grid.DataSource = _dt;
                FG_Grid.DataBind();
            }
            else
            {
                Toaster("No Data Found", Common.TosterType.Warning);
            }
        }

        protected void btnTransfer_OnClick(object sender, EventArgs e)
        {
            Toaster("Under Maintainace", Common.TosterType.Warning);
            return;
            //GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);

            //int location = 0, vehicle = 0, intOutWh = 0, intSalesId = 0;
            //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            //int autoid = Convert.ToInt32(((Label)row.FindControl("lblAutoID")).Text);
            //int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            //DateTime invDate = Convert.ToDateTime(((Label)row.FindControl("lblLastActionTime")).Text);
            //decimal storeQty = Convert.ToDecimal(((TextBox)row.FindControl("txtSendStoreQty")).Text);
            //int productid = Convert.ToInt32(((Label)row.FindControl("lblintproductionid")).Text);
            //int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);
            //_dt = _objbll.GetUnitByWH(whid);
            //int unitId = Convert.ToInt32(_dt.Rows[0]["intUnitID"].ToString());

            //_dt = _objbll.FGReceive_Data(whid, fromDate, toDate, 2, autoid, itemid, invDate, storeQty, productid); //insert into inventory

            //_dt = _objbll.FGReceive_Data(whid, fromDate, toDate, 3, autoid, itemid, invDate, storeQty, productid); // get outWHID
            //if (_dt.Rows.Count > 0)
            //{
            //    intOutWh = Convert.ToInt32(_dt.Rows[0]["intOutWHID"].ToString());
            //}
            //_dt = _objbll.DistributionData(whid, fromDate, toDate, 2, 0); //get location
            //if (_dt.Rows.Count > 0)
            //{
            //    location = Convert.ToInt32(_dt.Rows[0]["intStoreLocationID"].ToString());
            //}
            //_dt = _objbll.InsertReceiveData(unitId, whid, intOutWh, 0, Enroll, 0, 0, 0, 0, "Transfer To Distribution", 0, 2, true); //get sales ID

            //if (_dt.Rows.Count > 0)
            //{
            //    intSalesId = Convert.ToInt32(_dt.Rows[0]["strOutput"].ToString());
            //}
            //_dt = _objbll.InsertTransferData(unitId, whid, intOutWh, location, Enroll, intSalesId, itemid, storeQty, "Transfer To Distribution", 1, "Good Product");
            //string strChallan = "";
            //if (_dt.Rows.Count > 0)
            //{
            //    strChallan = _dt.Rows[0]["strChallan"].ToString();
            //}

            //if (vehicle > 0)
            //{
            //    _dt = _objbll.GetTripEntry(strChallan, unitId, 0, 0);
            //}

            //GridBind();
        }

        protected void FG_Grid_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblItem = (Label)e.Row.FindControl("lblintItemID");
                int itemId = int.Parse(lblItem.Text);

                int intwh = Common.GetDdlSelectedValue(ddlWH);
                //dt = objOperation.WhDataView(8, "", intwh, Item, 1);

                _dt = objIssue.GetViewData(19, "", intwh, 0, DateTime.Now, itemId);
                if (_dt.Rows.Count > 0)
                {
                    DropDownList ddlLocation = (e.Row.FindControl("ddlLocation") as DropDownList);
                    Common.LoadDropDown(ddlLocation, _dt, "Id", "strName");

                    try
                    {
                        TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");

                        if (ddlLocation != null)
                            _dt = objIssue.GetViewData(18, "", intwh, int.Parse(ddlLocation?.SelectedValue),
                                DateTime.Now,
                                itemId);
                        txtQuantity.Text = _dt.Rows.Count > 0 ? _dt.Rows[0]["monStock"].ToString() : "0";
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        protected void ddlLocation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}