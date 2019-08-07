using BLL.PetBottle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Factory.PetBottle
{
    public partial class PBReceiveForm : System.Web.UI.Page
    {
        #region INIT
        PBReceiveBLL pbrBLL = new PBReceiveBLL();
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropdown();
            }
        }
        
        #endregion

        #region Event
        protected void btnPBReceiveAdd_Click(object sender, EventArgs e)
        {

        }
        protected void btnPBDelete_Click(object sender, EventArgs e)
        {

        }
        protected void btnPBReceiveSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void ddlPONumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dts = new DataTable();
            DataTable dtI = new DataTable();
            try
            {
                if(ddlPONumber.SelectedValue != "-1")
                {
                    int supplierID = Convert.ToInt32(ddlPONumber.SelectedValue);
                    int POID = Convert.ToInt32(ddlPONumber.SelectedItem.ToString());
                    dts = pbrBLL.GetSupplier(supplierID);
                    hfSupplierID.Value = supplierID.ToString();
                    txtPartyName.Text = dts.Rows[0]["strSupplierName"].ToString();

                    dtI = pbrBLL.GetPOItem(POID);
                    if(dtI != null && dtI.Rows.Count > 0)
                    {
                        ddlPBItem.DataSource = dtI;
                        ddlPBItem.DataTextField = "ItemName";
                        ddlPBItem.DataValueField = "intItemID";
                        ddlPBItem.DataBind();
                    }
                }
                else
                {
                    txtPartyName.Text = string.Empty;
                }

                ddlPBItem.Items.Insert(0, new ListItem("--- Select PO Item ---", "-1"));
            }
            catch (Exception ex)
            {
            }
        }
        protected void ddlPBItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtqa = new DataTable();
            decimal RecvQty = 0;
            try
            {
                if (ddlPBItem.SelectedValue != "-1")
                {
                    int POID = Convert.ToInt32(ddlPONumber.SelectedItem.ToString());
                    int ItemID = Convert.ToInt32(ddlPBItem.SelectedValue);
                    dtqa = pbrBLL.GetPOQtyAmount(POID, ItemID);
                    if(dtqa != null && dtqa.Rows.Count > 0)
                    {
                        hfAmount.Value = dtqa.Rows[0]["POAmount"].ToString();
                        txtPOQuantity.Text = dtqa.Rows[0]["POQty"].ToString();
                    }
                    RecvQty = pbrBLL.GetPreReceivePOQty(POID, ItemID);
                    txtpreReceiveQty.Text = RecvQty.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Method
        private void FillDropdown()
        {
            DataTable podt = new DataTable();
            try
            {
                podt = pbrBLL.GetPetBottlePONo();
                if (podt != null && podt.Rows.Count > 0)
                {
                    ddlPONumber.DataSource = podt;
                    ddlPONumber.DataTextField = "intPOID";
                    ddlPONumber.DataValueField = "intSupplierID";
                    ddlPONumber.DataBind();
                }

                ddlPONumber.Items.Insert(0, new ListItem("--- Select PO Number ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion


    }
}