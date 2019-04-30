using System;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Data;
using Utility;
using BLL.Inventory;
namespace UI.SCM.Transfer
{
    public partial class InventoryAdjustmentApproval : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly InventoryAdjustmentBll _bll = new InventoryAdjustmentBll();
        private readonly InventoryAdjustmentAuthorityBll _bllApproval = new InventoryAdjustmentAuthorityBll();
        InventoryTransfer_BLL _bl = new InventoryTransfer_BLL();
        private readonly WareHouseBll _wareHouse = new WareHouseBll();
        private static int permission;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    LoadWareHouse();
                    permission = _bllApproval.GetInventoryAdjustmentApprovalLabel(Enroll, ddlWh.SelectedValue());
                    //dt = objbll.GetWH(Enroll);
                    _dt = new InventoryTransfer_BLL().GetTtransferDatas(1, "", 0, 0, DateTime.Now, Enroll);
                    //ddlWH.Loads(_dt, "Id", "strName");
                    //DateTime now = DateTime.Now;
                    //var dte = new DateTime(now.Year, now.Month, 1);
                    //txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    //txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            
            GridBind();
        }
        public void LoadWareHouse()
        {
            _dt = _wareHouse.GetAllWarehouseByEnroll(Enroll);
            ddlWh.Loads(_dt, "intWHID", "strWareHoseName");
            
        }

        private void GridBind()
        {
            int whid = ddlWh.SelectedValue();
            //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            //permission = _bllApproval.GetInventoryAdjustmentApprovalLabel(Enroll, ddlWh.SelectedValue());
            if (permission==1)
            {
                _dt = _bll.GetLabel1PendingInventoryAdjustmentByWh(whid);
            }
            else if (permission==2)
            {
                _dt = _bll.GetLabel2PendingInventoryAdjustmentByWh(whid);
            }
            else if (permission==3)
            {
                int level = ddlLevel.SelectedValue();
                if (level == 1)
                {
                    _dt = _bll.GetLabel1PendingInventoryAdjustmentByWh(whid);
                }
                else if (level == 2)
                {
                    _dt = _bll.GetLabel2PendingInventoryAdjustmentByWh(whid);
                }
            }

            //_dt = _objbll.FGReceive_Data(whid, fromDate, toDate, 1, 0, 0, DateTime.Now, 0, 0);


            if (_dt.Rows.Count > 0)
            {
                grid.Loads(_dt);
                SetVisibility("panel", true);
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            int autoid = Convert.ToInt32(((Label)row.FindControl("lblAutoID")).Text);
            int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            DateTime invDate = Convert.ToDateTime(((Label)row.FindControl("lblLastActionTime")).Text);
            decimal storeQty = Convert.ToDecimal(((TextBox)row.FindControl("txtSendStoreQty")).Text);
            int productionId = Convert.ToInt32(((Label)row.FindControl("lblintproductionid")).Text);
            //int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);

            /*_dt = _objbll.FGReceive_Data(whid, fromDate, toDate, 2, autoid, itemid, invDate, storeQty, productionId);*/ //insert into inventory

            if (_dt.Rows.Count > 0)
            {
                GridBind();
                Toaster("Successfully Updated", Common.TosterType.Success);
            }
            else
            {
                Toaster("Update Failed", Common.TosterType.Error);
            }

            //_dt = _objbll.FGReceive_Data(whid, FromDate, ToDate, 3, autoid, itemid, InvDate, StoreQty, productionId); // get outWHID
            //if (_dt.Rows.Count > 0)
            //{
            //    intOutWH = Convert.ToInt32(_dt.Rows[0]["intOutWHID"].ToString());
            //}
            //_dt = _objbll.DistributionData(whid, FromDate, ToDate, 2, 0); //get location
            //if (_dt.Rows.Count > 0)
            //{
            //    location = Convert.ToInt32(_dt.Rows[0]["intStoreLocationID"].ToString());
            //}
            //_dt = _objbll.InsertReceiveData(unitID, whid, intOutWH, 0, Enroll, 0, 0, 0, 0, "Transfer To Distribution", 0, 2, true); //get sales ID

            //if (_dt.Rows.Count > 0)
            //{
            //    intSalesID = Convert.ToInt32(_dt.Rows[0]["strOutput"].ToString());
            //}
            //_dt = _objbll.InsertTransferData(unitID, whid, intOutWH, location, Enroll, intSalesID, itemid, StoreQty, "Transfer To Distribution", 1, "Good Product");
            //string strChallan = "";
            //if (_dt.Rows.Count > 0)
            //{
            //    strChallan = _dt.Rows[0]["strChallan"].ToString();
            //}

            //if (Vehicle > 0)
            //{
            //    _dt = _objbll.GetTripEntry(strChallan, unitID, 0, 0);
            //}


        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            permission = _bllApproval.GetInventoryAdjustmentApprovalLabel(Enroll, ddlWh.SelectedValue());
            if (permission==3)
            {
                SetVisibility("levelPanel", true);
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            //DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            //int autoid = Convert.ToInt32(((Label)row.FindControl("lblAutoID")).Text);
            //int itemid = Convert.ToInt32(((Label)row.FindControl("lblintItemID")).Text);
            //DateTime invDate = Convert.ToDateTime(((Label)row.FindControl("lblLastActionTime")).Text);
            //decimal storeQty = Convert.ToDecimal(((TextBox)row.FindControl("txtSendStoreQty")).Text);
            //int productionId = Convert.ToInt32(((Label)row.FindControl("lblintproductionid")).Text);
            //int whid = Convert.ToInt32(ddlWH.SelectedItem.Value);

            //int unit = Convert.ToInt32();
            
            int id = Convert.ToInt32(((Label)row.FindControl("lblAutoID")).Text);
            int itemid  = Convert.ToInt32(((Label)row.FindControl("lblItmId")).Text);
            int  unitId = Convert.ToInt32(((Label)row.FindControl("lblUnitId")).Text);
            int  whid = Convert.ToInt32(((Label)row.FindControl("lblIntWHID")).Text);
            Decimal rcvQty = Convert.ToDecimal(((Label)row.FindControl("lblNumQty")).Text);
            Decimal monRate = Convert.ToDecimal(((Label)row.FindControl("lblMonRate")).Text);
            int location = Convert.ToInt32(((Label)row.FindControl("lblIntLocationID")).Text);
            string remark = (((Label)row.FindControl("lblstrReceiveRemarks")).Text);

            //permission = _bllApproval.GetInventoryAdjustmentApprovalLabel(Enroll, ddlWh.SelectedValue());
            if (permission == 3)
            {
                if (ddlLevel.SelectedValue() == 1) permission = 1;
                else if (ddlLevel.SelectedValue() == 2) permission = 2;

            }
            _dt = _bl.InventoryAdjustmentApproval(id, unitId, whid, Enroll, itemid, rcvQty, monRate, location, remark, permission);

            if (_dt.Rows.Count > 0)
            {
                GridBind();
                Toaster("Successfully Updated", Common.TosterType.Success);
            }
            else
            {
                Toaster("Update Failed", Common.TosterType.Error);
            }
        }

        //protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FG_Grid.DataSource = null;
        //    FG_Grid.DataBind();
        //}
    }
}