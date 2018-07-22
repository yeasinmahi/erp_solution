using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using UI.ClassFiles;
using Purchase_BLL.WoodPurchase;
using System.Data;

namespace UI.WoodPurchase
{
    public partial class WoodReceive : BasePage
    {
        DataTable dt; Purchase_BLL.WoodPurchase.WoodPurchaseBLL obj = new Purchase_BLL.WoodPurchase.WoodPurchaseBLL();
        int intEnroll, intWH, intPOID, intItemID, intLocationID, intSupplierID, intWoodTypeID, intZoneID, intJobStationID, intMouisture, intUnitID;
        decimal numPOQty, NetQty, monReceRate, numTotalWeight, numDeduction;
        string strChallan, strVatChallan, strRemarks, strGateEntryNo, strVehicleNo, strWeightID, message;
        DateTime dteReceiveDate, dteChallanDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Session["Enroll"] = Session[SessionParams.USER_ID].ToString();
                    pnlUpperControl.DataBind();

                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();//"11601"; //

                    //Wear House Bind
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = obj.GetWHList(intEnroll);
                    ddlWHList.DataSource = dt;
                    ddlWHList.DataTextField = "strWareHoseName";
                    ddlWHList.DataValueField = "intWHID";
                    ddlWHList.DataBind();

                    intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = obj.GetUnitJobStation(intWH);
                    hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                    hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                    LoadDropDown();
                }
            }
            catch { }
        }

        protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemDetails();
        }

        protected void ddlWHList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = obj.GetUnitJobStation(intWH);
                hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
                hdnJobStaion.Value = dt.Rows[0]["intJobStationId"].ToString();
                LoadDropDown();
            }
            catch { }
        }

        protected void ddlPOList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemList();
            LoadItemDetails();
        }

        private void LoadDropDown()
        {
            try
            {
                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());

                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                dt = new DataTable();
                dt = obj.GetPOList(intWH);
                ddlPOList.DataSource = dt;
                ddlPOList.DataValueField = "intPOID";
                ddlPOList.DataTextField = "strSupplierName";
                ddlPOList.DataBind();
                //hdnSupplierID.Value = dt.Rows[0]["intSupplierID"].ToString();

                dt = new DataTable();
                dt = obj.GetWoodType(intUnitID);
                ddlWoodType.DataSource = dt;
                ddlWoodType.DataTextField = "strWoodType";
                ddlWoodType.DataValueField = "intWoodTypeID";
                ddlWoodType.DataBind();

                dt = new DataTable();
                dt = obj.GetZone(intUnitID, intJobStationID);
                ddlZone.DataSource = dt;
                ddlZone.DataTextField = "strZoneName";
                ddlZone.DataValueField = "intZoneID";
                ddlZone.DataBind();

                dt = new DataTable();
                dt = obj.GetLocation(intWH);
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataValueField = "intStoreLocationID";
                ddlLocation.DataBind();

                LoadItemList();
                LoadItemDetails();
            }
            catch { }
        }

        private void LoadItemDetails()
        {
            try
            {
                txtPOQty.Text = "";
                hdnPOAmount.Value = "";
                txtRate.Text = "";
                txtPrereceive.Text = "";
                txtVatChallan.Text = "";
                txtMoisture.Text = "";
                txtChallanNo.Text = "";
                txtGateEntry.Text = "";
                txtVehicleNo.Text = "";
                txtWeightID.Text = "";
                txtTotalWeight.Text = "";
                txtDeduction.Text = "";

                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                intItemID = int.Parse(ddlItemList.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetItemDetails(intPOID, intItemID);
                txtPOQty.Text = dt.Rows[0]["numQty"].ToString();
                hdnPOAmount.Value = dt.Rows[0]["monAmount"].ToString();
                txtRate.Text = dt.Rows[0]["monRate"].ToString();
                txtPrereceive.Text = dt.Rows[0]["numReceiveQty"].ToString();
                txtVatChallan.Text = "0";
                txtMoisture.Text = "0";
                txtDeduction.Text = "0";
                
            }
            catch { }
        }

        private void LoadItemList()
        {
            try
            {
                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                dt = new DataTable();
                dt = obj.GetItemByPO(intPOID);
                ddlItemList.DataSource = dt;
                ddlItemList.DataTextField = "ItemName";
                ddlItemList.DataValueField = "intItemID";
                ddlItemList.DataBind();

                dt = new DataTable();
                dt = obj.GetSuppID(intPOID);
                if (dt.Rows.Count > 0)
                {
                    hdnSupplierID.Value = dt.Rows[0]["intSupplierID"].ToString();
                }
                
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPOQty.Text == "" || txtTotalWeight.Text == "" || txtRate.Text == "" || txtPOQty.Text == "0" || txtTotalWeight.Text == "0" || txtRate.Text == "0" || txtReceiveDate.Text == "" || txtChallanDate.Text == "" || txtGateEntry.Text == "" || txtChallanNo.Text == "" || txtVehicleNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input correct infromation.');", true);
                    return;
                }

                intPOID = int.Parse(ddlPOList.SelectedValue.ToString());
                intItemID = int.Parse(ddlItemList.SelectedValue.ToString());
                numPOQty = decimal.Parse(txtPOQty.Text);
                NetQty = decimal.Parse(txtNetWeight.Text);
                monReceRate = decimal.Parse(txtRate.Text);
                numTotalWeight = decimal.Parse(txtTotalWeight.Text);
                intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());
                intSupplierID = int.Parse(hdnSupplierID.Value.ToString());
                intEnroll = int.Parse(hdnEnroll.Value.ToString());
                dteReceiveDate = DateTime.Parse(txtReceiveDate.Text.ToString());
                strChallan = txtChallanNo.Text;
                dteChallanDate = DateTime.Parse(txtChallanDate.Text.ToString());
                intWH = int.Parse(ddlWHList.SelectedValue.ToString());
                strVatChallan = txtVatChallan.Text;
                numDeduction = decimal.Parse(txtDeduction.Text);
                intWoodTypeID = int.Parse(ddlWoodType.SelectedValue.ToString());
                intZoneID = int.Parse(ddlZone.SelectedValue.ToString());
                strRemarks = txtRemarks.Text;
                strGateEntryNo = txtGateEntry.Text;
                strVehicleNo = txtVehicleNo.Text;
                strWeightID = txtWeightID.Text;
                intJobStationID = int.Parse(hdnJobStaion.Value.ToString());
                intMouisture = int.Parse(txtMoisture.Text);
                obj.InsertMRR(intPOID, intItemID, numPOQty, NetQty, monReceRate, numTotalWeight, intLocationID, intSupplierID, intEnroll, dteReceiveDate, strChallan, dteChallanDate, intWH, strVatChallan, numDeduction, intWoodTypeID, intZoneID, strRemarks, strGateEntryNo, strVehicleNo, strWeightID, intJobStationID, intMouisture);

                if (numDeduction > 0)
                {
                    try
                    {
                        intUnitID = int.Parse(hdnUnit.Value.ToString());
                        dt = new DataTable();
                        dt = obj.InsertWOPO(intUnitID, intWH, intEnroll, intItemID, numDeduction, monReceRate, intLocationID, strRemarks, dteReceiveDate);

                        message = dt.Rows[0]["strMessage"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    }
                    catch { }
                }
                LoadItemDetails();
                
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please check inserted infromation.');", true); }
        }

    }
}