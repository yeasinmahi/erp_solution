﻿using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ItemManagerAccountsPopUp : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        MasterMaterialBLL bll = new MasterMaterialBLL(); DataTable dt;
        int intPart, intWHID, intUOM, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intInsertBy, intLocationID, intPurchaseType, intPOProcessingTime, intShipmentTime,
            intProcessTime, intTotalLeadTime, intEOQ, intMOQ, intSDEClassification, intHMLClassification, intAutoID;
        string strItemName, strDescription, strPart, strModel, strSerial, strUOM, strGroupName, strCategoryName, strSubCategoryName, strBrand, strMinorCategory, strPlantName, strABCClassification, strFSNClassification,
            strVDEClassification, strLotSize, strPurchaseType, strSDEClassification, strHMLClassification;
        decimal numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock;
        bool ysnVATApplicable;
        #endregion =====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                intInsertBy = int.Parse(hdnEnroll.Value);

                hdnItemID.Value = Request.QueryString["Id"];
                intAutoID = int.Parse(hdnItemID.Value);
                LoadPopUp();
            }
        }

        private void LoadPopUp()
        {
            try
            {
                dt = new DataTable();
                dt = bll.GetItemInfoForAccounts(intAutoID);

                txtBaseName.Text = dt.Rows[0]["strItemName"].ToString();
                txtDescription.Text = dt.Rows[0]["strDescription"].ToString();
                txtPart.Text = dt.Rows[0]["strPart"].ToString();
                txtModel.Text = dt.Rows[0]["strModel"].ToString();
                txtSerial.Text = dt.Rows[0]["strSerial"].ToString();
                txtBrand.Text = dt.Rows[0]["strBrand"].ToString();
                txtReOrder.Text = dt.Rows[0]["numReOrderLevel"].ToString();
                txtMinimum.Text = dt.Rows[0]["numMinimumStock"].ToString();
                txtMaximum.Text = dt.Rows[0]["numMaximumStock"].ToString();
                txtSafety.Text = dt.Rows[0]["numSafetyStock"].ToString();
                txtUOM.Text = dt.Rows[0]["strUOM"].ToString();
                txtGroup.Text = dt.Rows[0]["strGroupName"].ToString();
                txtCategory.Text = dt.Rows[0]["strCategoryName"].ToString();
                txtSubCategory.Text = dt.Rows[0]["strSubCategoryName"].ToString();
                txtMinorCategory.Text = dt.Rows[0]["strMinorCategory"].ToString();
                txtPlant.Text = dt.Rows[0]["strPlantName"].ToString();
                txtPurchaseType.Text = dt.Rows[0]["strPurchaseType"].ToString();
                txtPOTime.Text = dt.Rows[0]["intPOProcessTime"].ToString();
                txtDeliveryTime.Text = dt.Rows[0]["intShipmentDeliveryTime"].ToString();
                txtProcessingTime.Text = dt.Rows[0]["intProcessingTime"].ToString();
                txtTotalLeadTime.Text = dt.Rows[0]["intTotalLeadTime"].ToString();
                txtLotSize.Text = dt.Rows[0]["strOrderingLotSize"].ToString();
                txtEOQ.Text = dt.Rows[0]["intEconomicOrderQty"].ToString();
                txtMOQ.Text = dt.Rows[0]["intMinimumOrderQty"].ToString();
                txtSDE.Text = dt.Rows[0]["strSDEClassification"].ToString();
            }
            catch { }
        }
        #region ===== Submit Action =========================================================
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 10;
                intAutoID = int.Parse(hdnItemID.Value.ToString());
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                intHMLClassification = int.Parse(ddlHML.SelectedValue.ToString());
                strHMLClassification = ddlHML.SelectedItem.ToString();
                try { ysnVATApplicable = bool.Parse(txtPOTime.Text); } catch { intPOProcessingTime = 0; }

                if (hdnItemID.Value == "" || hdnItemID.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
                    return;
                }

                dt = new DataTable();
                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        strABCClassification, strFSNClassification, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, strLotSize, intEOQ, intMOQ, intSDEClassification, strSDEClassification, intHMLClassification, strHMLClassification, ysnVATApplicable, intAutoID);

                if (dt.Rows.Count > 0)
                {
                    string msg = dt.Rows[0]["msg"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    //LoadGrid();
                    hdnconfirm.Value = "0";
                    hdnItemID.Value = "0";
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('1');", true);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
            }
        }

        #endregion ==========================================================================
    }
}