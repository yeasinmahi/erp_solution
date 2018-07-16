using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;

namespace UI.SCM
{
    public partial class ItemManagerNew : BasePage
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
                try //WH List
                {
                    intPart = 1;
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

                hdnWHID.Value = ddlWH.SelectedValue.ToString();
                LoadUOM();
                LoadLocation();
                LoadGroup();
                hdnGroupID.Value = ddlGroup.SelectedValue.ToString();
                LoadCategory();
                hdnCategoryID.Value = ddlCategory.SelectedValue.ToString();
                LoadSubCategory();
                LoadMinorCategory();
                LoadPlant();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch;
            strSearch = txtSearch.Text;
            intWHID = int.Parse(ddlWH.SelectedValue.ToString());

            dt = new DataTable();
            dt = bll.GetItemListReport(intWHID, strSearch);

            if (dt.Rows.Count > 0)
            {
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strMaterialFullName";
                ListBox1.DataValueField = "intMaterialID";
                ListBox1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Item Found !!');", true);
                ListBox1.DataSource = "";
                ListBox1.DataBind();
            }
            

        }

        #region ====== Loading DropDownList =======================================================================================================================
        private void LoadUOM()
        {
            try //UOM List
            {
                intPart = 2;
                intInsertBy = int.Parse(hdnEnroll.Value);
                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlUOM.DataTextField = "strUoM";
                ddlUOM.DataValueField = "intUoM";
                ddlUOM.DataSource = dt;
                ddlUOM.DataBind();

                ddlUOM.Items[0].Attributes.Add("style", "Color:Red");
            }
            catch { }
        }
        private void LoadLocation()
        {
            try //Location List
            {
                intWHID = int.Parse(hdnWHID.Value.ToString());

                ddlLocation.DataSource = "";
                ddlLocation.DataBind();

                dt = bll.GetLocationByWH(intWHID);
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataValueField = "intStoreLocationID";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();

                ddlLocation.Items[0].Attributes.Add("style", "color:Red");
            }
            catch { }
        }
        private void LoadGroup()
        {
            try //Group List
            {
                intPart = 3;
                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlGroup.DataTextField = "strGroupName";
                ddlGroup.DataValueField = "intGroupID";
                ddlGroup.DataSource = dt;
                ddlGroup.DataBind();

                ddlGroup.Items[0].Attributes.Add("style", "color:Red");
            }
            catch { }
        }
        private void LoadCategory()
        {
            try //Category List
            {
                intPart = 4;
                intWHID = int.Parse(hdnWHID.Value.ToString());
                intGroupID = int.Parse(hdnGroupID.Value.ToString());

                ddlCategory.DataSource = "";
                ddlCategory.DataBind();
                ddlSubCategory.DataSource = "";
                ddlSubCategory.DataBind();

                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlCategory.DataTextField = "strCategoryName";
                ddlCategory.DataValueField = "intCategoryID";
                ddlCategory.DataSource = dt;
                ddlCategory.DataBind();

                ddlCategory.Items[0].Attributes.Add("style", "color:Red");
            }
            catch { }
        }
        private void LoadSubCategory()
        {
            try //Sub Category
            {
                intPart = 5;
                intCategoryID = int.Parse(hdnCategoryID.Value.ToString());

                ddlSubCategory.DataSource = "";
                ddlSubCategory.DataBind();

                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlSubCategory.DataTextField = "strSubCategoryName";
                ddlSubCategory.DataValueField = "intSubCategoryID";
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataBind();
            }
            catch { }
        }
        private void LoadMinorCategory()
        {
            try //Minor Category List
            {
                intPart = 6;
                intWHID = int.Parse(hdnWHID.Value.ToString());

                ddlMinorCategory.DataSource = "";
                ddlMinorCategory.DataBind();

                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlMinorCategory.DataTextField = "strMinorCategory";
                ddlMinorCategory.DataValueField = "intMinorCategory";
                ddlMinorCategory.DataSource = dt;
                ddlMinorCategory.DataBind();
            }
            catch { }
        }
        private void LoadPlant()
        {
            try //Plant List
            {
                intPart = 7;
                intWHID = int.Parse(hdnWHID.Value.ToString());

                ddlPlant.DataSource = "";
                ddlPlant.DataBind();

                dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);
                ddlPlant.DataTextField = "strPlantName";
                ddlPlant.DataValueField = "intPlantID";
                ddlPlant.DataSource = dt;
                ddlPlant.DataBind();
            }
            catch { }
        }
        #endregion ====== Loading DropDownList ===========================================================================================================

        #region ========= Selection Change =======================================================================================================================
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnWHID.Value = ddlWH.SelectedValue.ToString();
                LoadLocation();
                LoadCategory();
                LoadMinorCategory();
                LoadPlant();
            }
            catch { }
        }
        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnGroupID.Value = ddlGroup.SelectedValue.ToString();
                LoadCategory();
            }
            catch { }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnCategoryID.Value = ddlCategory.SelectedValue.ToString();
                LoadSubCategory();
            }
            catch { }
        }
        #endregion ====== Selection Change =======================================================================================================================

        #region ========= Final Submit ====================================================================================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intPart = 8;
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                strItemName = txtBaseName.Text;
                strDescription = txtDescription.Text;
                strPart = txtPart.Text;
                strModel = txtModel.Text;
                strSerial = txtSerial.Text;
                strBrand = txtBrand.Text;
                strSpecification = txtSpecification.Text;
                strOrigin = txtOrigin.Text;
                strHSCode = txtHSCode.Text;
                try { numReOrderLevel = decimal.Parse(txtReOrder.Text); } catch { numReOrderLevel = 0; }
                try { numMinimumStock = decimal.Parse(txtMinimum.Text); } catch { numMinimumStock = 0; }
                try { numMaximumStock = decimal.Parse(txtMaximum.Text); } catch { numMaximumStock = 0; }
                try { numSafetyStock = decimal.Parse(txtSafety.Text); } catch { numSafetyStock = 0; }
                intUOM = int.Parse(ddlUOM.SelectedValue.ToString());
                strUOM = ddlUOM.SelectedItem.ToString();
                intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());
                intGroupID = int.Parse(ddlGroup.SelectedValue.ToString());
                strGroupName = ddlGroup.SelectedItem.ToString();
                intCategoryID = int.Parse(ddlCategory.SelectedValue.ToString());
                strCategoryName = ddlCategory.SelectedItem.ToString();
                try { intSubCategoryID = int.Parse(ddlSubCategory.SelectedValue.ToString()); } catch { }
                try { strSubCategoryName = ddlSubCategory.SelectedItem.ToString(); } catch { }
                try { intMinorCategory = int.Parse(ddlMinorCategory.SelectedValue.ToString()); } catch { }
                try { strMinorCategory = ddlMinorCategory.SelectedItem.ToString(); } catch { }
                try { intPlantID = int.Parse(ddlPlant.SelectedValue.ToString()); } catch { }
                try { strPlantName = ddlPlant.SelectedItem.ToString(); } catch { }
                intABC = int.Parse(ddlABC.SelectedValue.ToString());
                strABCClassification = ddlABC.SelectedItem.ToString();
                intFSN = int.Parse(ddlFSN.SelectedValue.ToString());
                strFSNClassification = ddlFSN.SelectedItem.ToString();
                intVDE = int.Parse(ddlVDE.SelectedValue.ToString());
                strVDEClassification = ddlVDE.SelectedItem.ToString();
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                try { intSelfTime = int.Parse(txtSelfTime.Text.ToString()); } catch { }

                if(strItemName == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Base Name must be filled.');", true);
                    return;
                }
                else if(intUOM == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Unit of Measurement.');", true);
                    return;
                }
                else if (intLocationID == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select a valid Location.');", true);
                    return;
                }
                else if (intGroupID == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Product Group.');", true);
                    return;
                }
                else if (intGroupID == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Product Group.');", true);
                    return;
                }
                else if (intCategoryID == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Product Category.');", true);
                    return;
                }
                else if (intSubCategoryID == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Product Sub-Category.');", true);
                    return;
                }
                else if (intABC == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select ABC Classification.');", true);
                    return;
                }
                else if (intFSN == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select FSN Classification.');", true);
                    return;
                }
                else if (intVDE == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select VDE Classification.');", true);
                    return;
                }

                if (hdnconfirm.Value == "1")
                {
                    dt = bll.InsertUpdateSelectForItem(intPart, intWHID, strItemName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strOrigin, strHSCode, numReOrderLevel, numMinimumStock, numMaximumStock, numSafetyStock, intUOM, strUOM,
                        intLocationID, intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName,
                        intABC, strABCClassification, intFSN, strFSNClassification, intVDE, strVDEClassification, intInsertBy, intPurchaseType, strPurchaseType, intPOProcessingTime, intShipmentTime, intProcessTime,
                        intTotalLeadTime, intSelfTime, strLotSize, numEOQ, numMOQ, intSDE, strSDEClassification, intHML, strHMLClassification, ysnVATApplicable, intAutoID);

                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["msg"].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                        txtBaseName.Text = "";
                        txtDescription.Text = "";
                        txtPart.Text = "";
                        txtModel.Text = "";
                        txtSerial.Text = "";
                        txtBrand.Text = "";
                        txtSpecification.Text = "";
                        txtOrigin.Text = "";
                        txtHSCode.Text = "";
                        txtReOrder.Text = "";
                        txtMinimum.Text = "";
                        txtMaximum.Text = "";
                        txtSafety.Text = "";
                        txtSelfTime.Text = "";
                        ddlUOM.SelectedIndex = 0;
                        ddlLocation.SelectedIndex = 0;
                        ddlGroup.SelectedIndex = 0;
                        ddlCategory.SelectedIndex = 0;
                        ddlMinorCategory.SelectedIndex = 0;
                        ddlPlant.SelectedIndex = 0;
                        ddlABC.SelectedIndex = 0;
                        ddlFSN.SelectedIndex = 0;
                        ddlVDE.SelectedIndex = 0;
                        hdnconfirm.Value = "0";
                        ddlSubCategory.DataSource = "";
                        ddlSubCategory.DataBind();
                    }
                }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error!!!!!');", true); }
        }
        #endregion ====== Final Submit ======================================================================================================================
    }
}