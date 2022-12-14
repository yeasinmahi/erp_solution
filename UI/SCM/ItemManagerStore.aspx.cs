using System;
using System.Data;
using System.Web.UI;
using UI.ClassFiles;
using SCM_BLL;
using GLOBAL_BLL;

namespace UI.SCM
{
    public partial class ItemManagerNew : BasePage
    {
        private MasterMaterialBLL bll = new MasterMaterialBLL(); private DataTable dt;

        private int intPart, intUOM, intLocationID, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intProcureType, intABC, intFSN, intVDE, intSelfLife, intSDE, intHML, intWHID,
            intAutoID, intInsertBy, intCOAID, intUnitID, intMasterID;

        private string strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strUOM, strOrigin, strHSCode, strGroupName, strCategoryName, strSubCategoryName, strMinorCategory,
            strPlantName, strProcureType, strABC, strFSN, strVDE, strOrderingLotSize, strSDE, strHML;

        private decimal numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump;
        private bool ysnVATApplicable;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ItemManagerNew";
        private string stop = "stopping SCM\\ItemManagerNew";
        private string perform = "Performance on SCM\\ItemManagerNew";

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            intInsertBy = int.Parse(hdnEnroll.Value);

            if (!IsPostBack)
            {
                try //WH List
                {
                    intPart = 1;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                    dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
                    ddlWH.DataTextField = "strWareHoseName";
                    ddlWH.DataValueField = "intWHID";
                    ddlWH.DataSource = dt;
                    ddlWH.DataBind();
                }
                catch { }
                hdnMaterialId.Value = "0";
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
                LoadUnitID();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch;
            strSearch = txtSearch.Text;

            dt = new DataTable();
            dt = bll.GetItemListReport(strSearch);

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
                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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
                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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

                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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

                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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

                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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

                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
                ddlPlant.DataTextField = "strPlantName";
                ddlPlant.DataValueField = "intPlantID";
                ddlPlant.DataSource = dt;
                ddlPlant.DataBind();
            }
            catch { }
        }

        #endregion ====== Loading DropDownList =======================================================================================================================

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
                LoadUnitID();
                Reset();
            }
            catch { }
        }

        private void LoadUnitID()
        {
            intWHID = int.Parse(ddlWH.SelectedValue.ToString());
            dt = new DataTable();
            dt = bll.GetUnitID(intWHID);
            hdnUnit.Value = dt.Rows[0]["intUnitID"].ToString();
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

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(hdnUnit.Value.ToString());
                intMasterID = int.Parse(ListBox1.SelectedValue.ToString());

                dt = new DataTable();
                dt = bll.GetUnitCheck(intMasterID, intUnitID);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This item already included in this Unit.');", true);
                    return;
                }
                dt = new DataTable();
                dt = bll.GetMaterialDetails(intMasterID);

                if (dt.Rows.Count == 1)
                {
                    hdnMaterialId.Value = intMasterID.ToString();
                    txtBaseName.Text = dt.Rows[0]["strMaterialName"].ToString();
                    txtDescription.Text = dt.Rows[0]["strDescription"].ToString();
                    txtPart.Text = dt.Rows[0]["strPartNo"].ToString();
                    txtModel.Text = dt.Rows[0]["strModelNo"].ToString();
                    txtSerial.Text = dt.Rows[0]["strSerialNo"].ToString();
                    txtBrand.Text = dt.Rows[0]["strBrand"].ToString();
                    //ddlUOM.Text = dt.Rows[0]["strUoM"].ToString();

                    txtBaseName.Enabled = false;
                    txtDescription.Enabled = false;
                    txtPart.Enabled = false;
                    txtModel.Enabled = false;
                    txtSerial.Enabled = false;
                    txtBrand.Enabled = false;
                    ddlUOM.Enabled = false;
                }
                else
                {
                    hdnMaterialId.Value = "0";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something wrong.');", true);
                }
            }
            catch { }
        }

        #endregion ========= Selection Change =======================================================================================================================

        #region ========= Final Submit ====================================================================================================================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intPart = 8;
                intMasterID = int.Parse(hdnMaterialId.Value.ToString());
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                strMaterialName = txtBaseName.Text;
                strDescription = txtDescription.Text;
                strPart = txtPart.Text;
                strModel = txtModel.Text;
                strSerial = txtSerial.Text;
                strBrand = txtBrand.Text;
                strSpecification = txtSpecification.Text;
                intUOM = int.Parse(ddlUOM.SelectedValue.ToString());
                strUOM = ddlUOM.SelectedItem.ToString();
                strOrigin = txtOrigin.Text;
                intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());
                try { numReOrderQty = decimal.Parse(txtReOrder.Text); } catch { numReOrderQty = 0; }
                try { numReOrderPoint = decimal.Parse(txtReOrder.Text); } catch { numReOrderPoint = 0; }
                try { numMinimumStock = decimal.Parse(txtMinimum.Text); } catch { numMinimumStock = 0; }
                try { numMaximumStock = decimal.Parse(txtMaximum.Text); } catch { numMaximumStock = 0; }
                try { numSafetyStock = decimal.Parse(txtSafety.Text); } catch { numSafetyStock = 0; }
                try { numMaxDailyConsump = decimal.Parse(txtMaxConsum.Text); } catch { numMaxDailyConsump = 0; }
                try { numMinDailyConsump = decimal.Parse(txtMinConsum.Text); } catch { numMinDailyConsump = 0; }
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
                strABC = ddlABC.SelectedItem.ToString();
                intFSN = int.Parse(ddlFSN.SelectedValue.ToString());
                strFSN = ddlFSN.SelectedItem.ToString();
                intVDE = int.Parse(ddlVDE.SelectedValue.ToString());
                strVDE = ddlVDE.SelectedItem.ToString();
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                try { intSelfLife = int.Parse(txtSelfTime.Text.ToString()); } catch { }
                intProcureType = int.Parse(ddlProcurementType.SelectedValue.ToString());
                strProcureType = ddlProcurementType.SelectedItem.ToString();

                if (strMaterialName == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Product Base Name must be filled.');", true);
                    return;
                }
                else if (intUOM == 0 && hdnMaterialId.Value == "0")
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
                else if (intProcureType == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Procure Type.');", true);
                    return;
                }
                if (hdnconfirm.Value == "1")
                {
                    dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

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
                        txtReOrderQty.Text = "";
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
                        ddlProcurementType.SelectedIndex = 0;
                        hdnconfirm.Value = "0";
                        ddlSubCategory.DataSource = "";
                        ddlSubCategory.DataBind();
                        Reset();
                    }
                }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Error!!!!!');", true); }
        }

        #endregion ========= Final Submit ====================================================================================================================

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtBaseName.Enabled = true;
            txtDescription.Enabled = true;
            txtPart.Enabled = true;
            txtModel.Enabled = true;
            txtSerial.Enabled = true;
            txtBrand.Enabled = true;
            ddlUOM.Enabled = true;

            txtBaseName.Text = "";
            txtDescription.Text = "";
            txtPart.Text = "";
            txtModel.Text = "";
            txtSerial.Text = "";
            txtBrand.Text = "";

            txtSearch.Text = "";
            ListBox1.DataSource = "";
            ListBox1.DataBind();

            ddlUOM.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            ddlGroup.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlMinorCategory.SelectedIndex = 0;
            ddlPlant.SelectedIndex = 0;
            ddlABC.SelectedIndex = 0;
            ddlFSN.SelectedIndex = 0;
            ddlVDE.SelectedIndex = 0;
            ddlProcurementType.SelectedIndex = 0;

            hdnMaterialId.Value = "0";
        }
    }
}