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
    public partial class ItemManagerAccounts : BasePage
    {
        MasterMaterialBLL bll = new MasterMaterialBLL(); DataTable dt;
        int intPart, intWHID, intUOM, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intInsertBy, intLocationID, intPurchaseType, intPOProcessingTime, intShipmentTime,
            intProcessTime, intTotalLeadTime, intEOQ, intMOQ, intSDEClassification, intHMLClassification, intAutoID;
        string strItemName, strDescription, strPart, strModel, strSerial, strUOM, strGroupName, strCategoryName, strSubCategoryName, strBrand, strMinorCategory, strPlantName, strABCClassification, strFSNClassification,
            strVDEClassification, strLotSize, strPurchaseType, strSDEClassification, strHMLClassification;
        decimal numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock;
        bool ysnVATApplicable;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            intInsertBy = int.Parse(hdnEnroll.Value);

            if (!IsPostBack)
            {
                try
                {
                    LoadGrid();
                }
                catch { }
            }

        }

        private void LoadGrid()
        {
            dt = new DataTable();
            dt = bll.GetItemListForAccounts();
            dgvItem.DataSource = dt; dgvItem.DataBind();
        }
        protected void dgvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Y")
            {
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvItem.Rows[rowIndex];

                //txtBaseName.Text = (row.FindControl("lblProductName") as Label).Text;
                //txtDescription.Text = (row.FindControl("lblDescription") as Label).Text;
                //txtPartModel.Text = (row.FindControl("lblPart") as Label).Text;
                //txtBrand.Text = (row.FindControl("lblBrand") as Label).Text;
                //txtReOrder.Text = (row.FindControl("lblReOrder") as Label).Text;
                //txtMinimum.Text = (row.FindControl("lblMinimum") as Label).Text;
                //txtMaximum.Text = (row.FindControl("lblMaximum") as Label).Text;
                //txtSafety.Text = (row.FindControl("lblSafety") as Label).Text;
                //txtUOM.Text = (row.FindControl("lblUOM") as Label).Text;
                //txtGroup.Text = (row.FindControl("lblGroupName") as Label).Text;
                //txtCategory.Text = (row.FindControl("lblCategory") as Label).Text;
                //txtSubCategory.Text = (row.FindControl("lblSubCategory") as Label).Text;
                //txtMinorCategory.Text = (row.FindControl("lblMinorCategory") as Label).Text;
                //txtPlant.Text = (row.FindControl("lblPlant") as Label).Text;
                //txtPurchaseType.Text = (row.FindControl("lblPurchase") as Label).Text;
                //txtPOTime.Text = (row.FindControl("lblPOTime") as Label).Text;
                //txtDeliveryTime.Text = (row.FindControl("lblShipmentTime") as Label).Text;
                //txtProcessingTime.Text = (row.FindControl("lblProcessTime") as Label).Text;
                //txtTotalLeadTime.Text = (row.FindControl("lblTotalTime") as Label).Text;
                //txtLotSize.Text = (row.FindControl("lblLotSize") as Label).Text;
                //txtEOQ.Text = (row.FindControl("lblEOQ") as Label).Text;
                //txtMOQ.Text = (row.FindControl("lblMOQ") as Label).Text;
                //txtSDE.Text = (row.FindControl("lblSDE") as Label).Text;

                hdnItemID.Value = (row.FindControl("lblAutoID") as Label).Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDispatchPopup('" + hdnItemID.Value + "');", true);
            }
            else if (e.CommandName == "R")
            {
                if (hdnconfirm.Value == "1")
                {
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);

                    //Determine the RowIndex of the Row whose Button was clicked.
                    int rowIndex = Convert.ToInt32(e.CommandArgument);

                    //Reference the GridView Row.
                    GridViewRow row = dgvItem.Rows[rowIndex];

                    hdnItemID.Value = (row.FindControl("lblAutoID") as Label).Text;
                    intAutoID = int.Parse(hdnItemID.Value.ToString());
                    intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                    intPart = 12;
                    dt = new DataTable();
                    dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                            intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                            strABCClassification, strFSNClassification, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                            intTotalLeadTime, strLotSize, intEOQ, intMOQ, intSDEClassification, strSDEClassification, intHMLClassification, strHMLClassification, ysnVATApplicable, intAutoID);
                    LoadGrid();
                }
            }
        }
        #region ===== Submit Action =========================================================
        //protected void btnApprove_Click(object sender, EventArgs e)
        //{
        //    if (hdnconfirm.Value == "1")
        //    {
        //        intPart = 10;
        //        intAutoID = int.Parse(hdnItemID.Value.ToString());
        //        intInsertBy = int.Parse(hdnEnroll.Value.ToString());
        //        intHMLClassification = int.Parse(ddlHML.SelectedValue.ToString());
        //        strHMLClassification = ddlHML.SelectedItem.ToString();
        //        try { ysnVATApplicable = bool.Parse(txtPOTime.Text); } catch { intPOProcessingTime = 0; }

        //        if (hdnItemID.Value == "" || hdnItemID.Value == "0")
        //        {
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
        //            return;
        //        }

        //        dt = new DataTable();
        //        dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
        //                intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
        //                strABCClassification, strFSNClassification, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
        //                intTotalLeadTime, strLotSize, intEOQ, intMOQ, intSDEClassification, strSDEClassification, intHMLClassification, strHMLClassification, ysnVATApplicable, intAutoID);

        //        if (dt.Rows.Count > 0)
        //        {
        //            string msg = dt.Rows[0]["msg"].ToString();
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
        //            LoadGrid();
        //            hdnconfirm.Value = "0";
        //            hdnItemID.Value = "0";
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('1');", true);
        //            LoadGrid();
        //        }
        //    }
        //}

        #endregion ==========================================================================
    }
}