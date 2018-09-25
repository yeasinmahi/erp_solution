using SCM_BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Inventory
{
    public partial class GoodReceiveNote : System.Web.UI.Page
    {
        InventoryTransfer_BLL _bll = new InventoryTransfer_BLL();
        DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int.TryParse(txtPoNumber.Text, out int poNumber);
            _dt = _bll.GetSupplyInfoById(poNumber);
            if (_dt.Rows.Count>0)
            {
                hdnSupplerId.Value = _dt.Rows[0]["intSupplierID"].ToString();
                txtSupplierName.Text = _dt.Rows[0]["strSupplierName"].ToString();
                txtSupplierAddress.Text = _dt.Rows[0]["strOrgAddress"].ToString();
                int shipmentSl = Convert.ToInt32(_dt.Rows[0]["intShipmentSL"].ToString());
                hdnshipmentSn.Value = shipmentSl.ToString();
                DataTable dataTable = _bll.GetItemInfoByPoId(poNumber, shipmentSl, false);
                gridView.DataSource = dataTable;
                gridView.DataBind();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Supplier Found on this PO number "+poNumber+".');", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int poNumber = Convert.ToInt32(txtPoNumber.Text);
            int supplierId = Convert.ToInt32(hdnSupplerId.Value);
            string supplierName = txtSupplierName.Text;
            string supplierAddress = txtSupplierAddress.Text;
            string challanNo =txtChallanNo.Text;
            string vehicleNo = txtVehicleNo.Text;
            string driverName = txtDriverName.Text;
            string driverContact = txtDriverContact.Text;
            string meterialDes = txtMeterialDes.Text;
            int shipmentSn = Convert.ToInt32(hdnshipmentSn.Value);

            foreach (GridViewRow row in gridView.Rows)
            {
                string receiveQuantityText = ((TextBox)row.FindControl("receiveQuantity")).Text;
                if (!String.IsNullOrWhiteSpace(receiveQuantityText))
                {
                    Decimal receiveQuantity = 0;
                    Decimal.TryParse(receiveQuantityText,out receiveQuantity);
                    if (receiveQuantity>0)
                    {
                        int itemId = Convert.ToInt32(((Label)row.FindControl("iblItem")).Text);
                        string itemName = ((Label)row.FindControl("lblItemName")).Text;
                        string desc = ((Label)row.FindControl("lblDsc")).Text;
                        string uom = ((Label)row.FindControl("lblUoM")).Text;
                        decimal poQnt = Convert.ToDecimal(((Label)row.FindControl("lblPoQnt")).Text);
                        string prePoQnt = ((Label)row.FindControl("lblPreRcvQnt")).Text;
                        string remainingQnt = ((Label)row.FindControl("lblRemainingQnt")).Text;
                        string remarks = ((TextBox)row.FindControl("receiveRemarks")).Text;
                        int? gnid = 0;
                        _bll.InsertFactoryGoodReceive(poNumber, supplierId, challanNo, driverName, driverContact,
                            vehicleNo, meterialDes, 2, 2, shipmentSn, 369116, ref gnid);
                        string message = "";
                        if (gnid>0)
                        {
                            _bll.InsertFactoryGoodsReceiveDetail((int) gnid, itemId, poQnt, receiveQuantity,ref message);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('A problem occerred when inserted');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Specify quantity value properly');", true);
                        return;
                    }
                }
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Inserted');", true);
        }

       
    }
}