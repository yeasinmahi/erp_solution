using SCM_BLL;
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
    public partial class ItemMangerPurchase : BasePage
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
            dt = bll.GetItemListForPurchase();
            dgvItem.DataSource = dt; dgvItem.DataBind();
        }
        protected void dgvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Y")
            {
                txtPOTime.Text = "";
                txtDeliveryTime.Text = "";
                txtProcessingTime.Text = "";
                txtTotalLeadTime.Text = "";
                txtLotSize.Text = "";
                txtEOQ.Text = "";
                txtMOQ.Text = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvItem.Rows[rowIndex];

                txtBaseName.Text = (row.FindControl("lblProductName") as Label).Text;
                txtDescription.Text = (row.FindControl("lblDescription") as Label).Text;
                txtPart.Text = (row.FindControl("lblPart") as Label).Text;
                txtModel.Text = (row.FindControl("lblModel") as Label).Text;
                txtSerial.Text = (row.FindControl("lblSerial") as Label).Text;

                txtBrand.Text = (row.FindControl("lblBrand") as Label).Text;
                txtReOrder.Text = (row.FindControl("lblReOrder") as Label).Text;
                txtMinimum.Text = (row.FindControl("lblMinimum") as Label).Text;
                txtMaximum.Text = (row.FindControl("lblMaximum") as Label).Text;
                txtSafety.Text = (row.FindControl("lblSafety") as Label).Text;
                txtUOM.Text = (row.FindControl("lblUOM") as Label).Text;
                txtGroup.Text = (row.FindControl("lblGroupName") as Label).Text;
                txtCategory.Text = (row.FindControl("lblCategory") as Label).Text;
                txtSubCategory.Text = (row.FindControl("lblSubCategory") as Label).Text;
                txtMinorCategory.Text = (row.FindControl("lblMinorCategory") as Label).Text;
                txtPlant.Text = (row.FindControl("lblPlant") as Label).Text;
                hdnItemID.Value = (row.FindControl("lblAutoID") as Label).Text;

                txtPOTime.Text = "0";
                txtDeliveryTime.Text = "0";
                txtProcessingTime.Text = "0";
                txtTotalLeadTime.Text = "0";
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
                    intPart = 11;
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
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 9;
                intAutoID = int.Parse(hdnItemID.Value.ToString());
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                intPurchaseType = int.Parse(ddlProcurementType.SelectedValue.ToString());
                strPurchaseType = ddlProcurementType.SelectedItem.ToString();
                try { intPOProcessingTime = int.Parse(txtPOTime.Text); } catch { intPOProcessingTime = 0; }
                try { intShipmentTime = int.Parse(txtDeliveryTime.Text); } catch { intShipmentTime = 0; }
                try {intProcessTime = int.Parse(txtProcessingTime.Text);} catch { intProcessTime = 0; }
                try {intTotalLeadTime = int.Parse(txtTotalLeadTime.Text);}catch { intTotalLeadTime = 0; }
                strLotSize = txtLotSize.Text;
                try{intEOQ = int.Parse(txtEOQ.Text); } catch { intEOQ = 0; }
                try {intMOQ = int.Parse(txtMOQ.Text); } catch { intMOQ = 0; }
                intSDEClassification = int.Parse(ddlSDE.SelectedValue.ToString());
                strSDEClassification = ddlSDE.SelectedItem.ToString();

                if(hdnItemID.Value == "" || hdnItemID.Value == "0" || txtPOTime.Text == "" || txtDeliveryTime.Text == "" || txtProcessingTime.Text == "")
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
                    LoadGrid();
                    hdnconfirm.Value = "0";
                    hdnItemID.Value = "0";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('1');", true);
                    LoadGrid();
                }
            }
        }

        #endregion ==========================================================================
    }
}