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
            intProcessTime, intTotalLeadTime, intAutoID, intABC, intFSN, intVDE, intSelfTime, intSDE, intHML;
        string strItemName, strDescription, strPart, strModel, strSerial, strUOM, strGroupName, strCategoryName, strSubCategoryName, strBrand, strMinorCategory, strPlantName, strABCClassification, strFSNClassification,
            strVDEClassification, strLotSize, strPurchaseType, strSDEClassification, strHMLClassification, strSpecification, strOrigin, strHSCode;
        decimal numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, numEOQ, numMOQ;
        bool ysnVATApplicable;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            intInsertBy = int.Parse(hdnEnroll.Value);

            if (!IsPostBack)
            {
                try //WH List for Purchase
                {
                    intPart = 15;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                    dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataSource = dt;
                    ddlWH.DataBind();
                }
                catch { }
            }
        }
        private void LoadGrid()
        {
            dt = new DataTable();
            dt = bll.GetItemListForPurchase(intWHID);
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
                    intPart = 11;
                    dt = new DataTable();
                    dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                    LoadGrid();
                }
            }
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvItem.DataSource = "";
                dgvItem.DataBind();
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                LoadGrid();
            }
            catch { }
        }

    }
}