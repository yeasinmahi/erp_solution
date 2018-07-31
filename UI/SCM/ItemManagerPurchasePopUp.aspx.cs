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
    public partial class ItemManagerPurchasePopUp : System.Web.UI.Page
    {
        #region===== Variable & Object Declaration =====================================================
        MasterMaterialBLL bll = new MasterMaterialBLL(); DataTable dt;
        int intPart, intUOM, intLocationID, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intProcureType, intABC, intFSN, intVDE, intSelfLife, intSDE, intHML, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID;

        string strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strUOM, strOrigin, strHSCode, strGroupName, strCategoryName, strSubCategoryName, strMinorCategory,
            strPlantName, strProcureType, strABC, strFSN, strVDE, strOrderingLotSize, strSDE, strHML;
        decimal numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump;
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
                dt = bll.GetItemInfoForPurchase(intAutoID);

                txtBaseName.Text = dt.Rows[0]["strItemName"].ToString();
                txtDescription.Text = dt.Rows[0]["strDescription"].ToString();
                txtPart.Text = dt.Rows[0]["strPart"].ToString();
                txtModel.Text = dt.Rows[0]["strModel"].ToString();
                txtSerial.Text = dt.Rows[0]["strSerial"].ToString();
                txtBrand.Text = dt.Rows[0]["strBrand"].ToString();
                txtSpecification.Text = dt.Rows[0]["strSpecifiaction"].ToString();
                txtOrigin.Text = dt.Rows[0]["strOrigin"].ToString();
                txtReorderQty.Text=dt.Rows[0]["numReOrderQty"].ToString();
                txtReOrder.Text = dt.Rows[0]["numReOrderLevel"].ToString();
                txtMinimum.Text = dt.Rows[0]["numMinimumStock"].ToString();
                txtMaximum.Text = dt.Rows[0]["numMaximumStock"].ToString();
                txtMaxDailyConsum.Text = dt.Rows[0]["numMaxDailyConsump"].ToString();
                txtMinDailyConsum.Text = dt.Rows[0]["numMinDailyConsump"].ToString();
                txtSafety.Text = dt.Rows[0]["numSafetyStock"].ToString();
                txtSelfTime.Text = dt.Rows[0]["intSelfTime"].ToString();
                txtUOM.Text = dt.Rows[0]["strUOM"].ToString();
                txtGroup.Text = dt.Rows[0]["strGroupName"].ToString();
                txtCategory.Text = dt.Rows[0]["strCategoryName"].ToString();
                txtSubCategory.Text = dt.Rows[0]["strSubCategoryName"].ToString();
                txtMinorCategory.Text = dt.Rows[0]["strMinorCategory"].ToString();
                txtPlant.Text = dt.Rows[0]["strPlantName"].ToString();
                txtProcumentType.Text = dt.Rows[0]["strPurchaseType"].ToString();

                if (dt.Rows[0]["strPurchaseType"].ToString() == "Import")
                {
                    txtHSCode.Attributes.Add("placeholder", "HS Code is mandatory for Import Items.");
                }
                else
                {
                    txtHSCode.Attributes.Add("placeholder", "");
                }
            }
            catch { }
        }
        #region ===== Submit Action =========================================================
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 9;
                intAutoID = int.Parse(hdnItemID.Value.ToString());
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                strHSCode = txtHSCode.Text;
                try { numMaxLeadTime = int.Parse(txtMaxLeadTime.Text); } catch { numMaxLeadTime = 0; }
                try { numMinLeadTime = int.Parse(txtMinLeadTime.Text); } catch { numMinLeadTime = 0; }
                strOrderingLotSize = txtLotSize.Text;
                try { numEOQ = decimal.Parse(txtEOQ.Text); } catch { numEOQ = 0; }
                try { numMOQ = decimal.Parse(txtMOQ.Text); } catch { numMOQ = 0; }
                intSDE = int.Parse(ddlSDE.SelectedValue.ToString());
                strSDE = ddlSDE.SelectedItem.ToString();

                if (hdnItemID.Value == "" || hdnItemID.Value == "0" || txtMaxLeadTime.Text == "" || txtMinLeadTime.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
                    return;
                }
                if (txtProcumentType.Text == "Import")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Must be fill HS Code for Import Items.....');", true);
                    return;
                }

                dt = new DataTable();
                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

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