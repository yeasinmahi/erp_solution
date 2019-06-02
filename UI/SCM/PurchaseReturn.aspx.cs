using SCM_BLL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Inventory;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class PurchaseReturn : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly PoGenerate_BLL _bll = new PoGenerate_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _dt = _bll.GetPoData(36, "", 0, 0, DateTime.Now, Enroll);
                ddlWH.Loads(_dt, "Id", "strName");
            }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                int mrrNo = int.Parse(txtMrrNo.Text);
                hdnMrrNo.Value = mrrNo.ToString();
                _dt = _bll.GetPoData(33, "", ddlWH.SelectedValue(), mrrNo, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    lblSupp.Text = _dt.Rows[0]["strSupplierName"].ToString();
                    hdnSupplierId.Value = _dt.Rows[0]["intSupplierID"].ToString();
                    dgvDelivery.Loads(_dt);
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                int mrrNo = int.Parse(hdnMrrNo.Value);
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                TextBox txtReturnQty = row.FindControl("txtReturnQty") as TextBox;
                TextBox txtReson = row.FindControl("txtReson") as TextBox;
                Label lblitemId = row.FindControl("lblitemId") as Label;
                Label lblItemName = row.FindControl("lblItemName") as Label;
                Label lblPoQty = row.FindControl("lblPoQty") as Label;
                Label lblLocation = row.FindControl("lblLocation") as Label;
                Label lblReceive = row.FindControl("lblReceve") as Label;
                Label lblrate = row.FindControl("lblReceve") as Label;


                string location = lblLocation.Text;
                int supplierId = Convert.ToInt32(hdnSupplierId.Value);

                if (decimal.TryParse(txtReturnQty.Text, out decimal returnQty))
                {
                    string remarks = txtReson.Text;
                    int itemId = Convert.ToInt32(lblitemId.Text);
                    string itemName = lblItemName.Text;
                    decimal poQuantity = Convert.ToDecimal(lblPoQty.Text);
                    decimal receiveQuantity = Convert.ToDecimal(lblReceive.Text);
                    int locationId = Convert.ToInt32(lblLocation.Text);
                    string supplierName = lblSupp.Text;
                    decimal rate = Convert.ToDecimal(lblrate.Text);

                    string xmlData = "<voucher><voucherentry returnQty=" + '"' + returnQty + '"' + " remarks=" + '"' +
                                     remarks + '"' + " itemId=" + '"' + itemId + '"' + " poQty=" + '"' +
                                     poQuantity + '"' + " location=" + '"' + location + '"' + "/></voucher>";
                    if (returnQty > 0 && returnQty <= decimal.Parse(lblReceive.Text))
                    {
                        int whId = ddlWH.SelectedValue();
                        // ***********NEW process***********
                        FactoryPurchaseReturnBll bll = new FactoryPurchaseReturnBll();
                        int returnId = bll.PurchaseReturn(whId, mrrNo, itemId, itemName, poQuantity, receiveQuantity, returnQty,
                            rate*returnQty, locationId, remarks, supplierId, supplierName, Enroll);
                        if (returnId > 0)
                        {
                            Toaster("Successfully purchase returned with ID: "+returnId,Common.TosterType.Success);
                        }
                        else
                        {
                            Toaster("Purchase returned Failed", Common.TosterType.Success);
                        }
                        // ***********OLD process***********
                        //string msg = _bll.PoApprove(37, xmlData, whId, mrrNo, DateTime.Now, Enroll);
                        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        //    "alert('" + msg + "');", true);
                    }
                    else
                    {
                        Toaster("Return quantity can not be greater than receive quantity",Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("Please Input Return quantity properly",Common.TosterType.Warning);
                }
                

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
    }
}