using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Inventory
{
    public partial class GoodReceiveNote : System.Web.UI.Page
    {
        InventoryTransfer_BLL _bll = new InventoryTransfer_BLL();
        DataTable _dt = new DataTable();
        private int enroll = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            enroll =  Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
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
                DataTable dataTable = _bll.GetItemInfoByPoId(poNumber, shipmentSl, false);
                gridView.DataSource = dataTable;
                gridView.DataBind();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "showButtonClick()');", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
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
            DateTime challanDate = txtChallanDate.Text.ToDateTime("dd/MM/yyyy");
            string shipmentNo = txtShipmentNo.Text;
            string challanNo =txtChallanNo.Text;
            string vehicleNo = txtVehicleNo.Text;
            string driverName = txtDriverName.Text;
            string driverContact = txtDriverContact.Text;
            //string meterialDes = txtMeterialDes.Text;
            string meterialDes = "";

            int counter = 0;
            int? gnid = 0;
            List<int> ids = new List<int>();
            foreach (GridViewRow row in gridView.Rows)
            {
                
                string receiveQuantityText = ((TextBox)row.FindControl("receiveQuantity")).Text;
                if (!string.IsNullOrWhiteSpace(receiveQuantityText))
                {
                    Decimal.TryParse(receiveQuantityText,out var receiveQuantity);
                    if (receiveQuantity>0)
                    {
                        if (gnid==0)
                        {
                            _bll.InsertFactoryGoodReceive(poNumber, supplierId, challanNo,challanDate, driverName, driverContact,
                                vehicleNo, meterialDes, 2, 2, shipmentNo, enroll, ref gnid);
                        }
                        int? grnDetailsId = 0;
                        
                        if (gnid>0)
                        {
                            

                            int itemId = Convert.ToInt32(((Label)row.FindControl("iblItem")).Text);
                            string itemName = ((Label)row.FindControl("lblItemName")).Text;
                            string desc = ((Label)row.FindControl("lblDsc")).Text;
                            string uom = ((Label)row.FindControl("lblUoM")).Text;
                            decimal poQnt = Convert.ToDecimal(((Label)row.FindControl("lblPoQnt")).Text);
                            string prePoQnt = ((Label)row.FindControl("lblPreRcvQnt")).Text;
                            string remainingQnt = ((Label)row.FindControl("lblRemainingQnt")).Text;
                            string remarks = ((TextBox)row.FindControl("receiveRemarks")).Text;
                            string message = "";
                            _bll.InsertFactoryGoodsReceiveDetail((int) gnid, itemId,poNumber ,poQnt, receiveQuantity, remarks,ref grnDetailsId);
                            if (grnDetailsId != null && grnDetailsId == 0)
                            {
                                _bll.UpdateFactoryGoodReceiveInActiveByGrnIdTableAdapter((int)gnid);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+itemId+" "+itemName+" exiding the quantity limit.');", true);
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                                return;
                            }
                            counter++;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('A problem occerred when inserting');", true);
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Specify quantity value properly');", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                        return;
                    }
                }
            }
            if (counter>0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Inserted. Your GRN no is "+ gnid + "');", true);
                lblGrn.Text = @"Your previous GRN number is "+gnid+".";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "hidePanel();", true);
                ClearControl();
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have to receive at least 1 item with challan.');", true);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
        }

        private void ClearControl()
        {
            txtPoNumber.Text = string.Empty;
            hdnSupplerId.Value = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtChallanNo.Text = string.Empty;
            txtChallanDate.Text = string.Empty;
            txtShipmentNo.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
            txtDriverName.Text = string.Empty;
            txtDriverContact.Text = string.Empty;
            //txtMeterialDes.Text = string.Empty;

            gridView.DataSource = null;
            gridView.DataBind();
        }
    }
}