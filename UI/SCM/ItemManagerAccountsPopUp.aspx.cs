using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using SCM_DAL.ItemManagerStoreTDSTableAdapters;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Web.Script.Services;
using System.Web.Services;

namespace UI.SCM
{
    public partial class ItemManagerAccountsPopUp : BasePage
    {
        #region INIT
        CommonTableAdapter commonTableAdapter = new CommonTableAdapter();
        ItemAddtoMasterFromTempTableAdapter itemAddtoMasterFromTempTableAdapter = new ItemAddtoMasterFromTempTableAdapter();
        private MasterMaterialBLL bll = new MasterMaterialBLL();
        GetCOAChildByUnitTableAdapter getCOAChildByUnitTableAdapter = new GetCOAChildByUnitTableAdapter();
        CostCenterTableAdapter costCenterTableAdapter = new CostCenterTableAdapter();
        private DataTable dt;
        private int intItemId, intUnitID, intPart, intWHID, intAutoID, intInsertBy,intSallingUoM, intProductHeirarcy, intGLCode,
            intCostCenter,intProfitCenter,intUoM;

        private string strSallingUoM, strGLCode, strCostCenter, strProfitCenter,strItemName,strUoM, strPartNumber,strModelNumber,
            strBrand,strItemFullName;

        private decimal numMinOrdQty, numMinDelvQty;
        private bool ysnPurchase, ysnAll;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ItemManagerAccountsPopUp";
        private string stop = "stopping SCM\\ItemManagerAccountsPopUp";
        private string perform = "Performance on SCM\\ItemManagerAccountsPopUp";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                intInsertBy = int.Parse(hdnEnroll.Value);

                hdnItemID.Value = Request.QueryString["Id"];
                intAutoID = int.Parse(hdnItemID.Value);
                FillDropdown();
                LoadPopUp();
            }
        }
        #endregion

        #region Event
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnApprove_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if(Validation() == true)
                {
                    FillSalesnAccountDeptData();
                    if (hdnconfirm.Value == "1")
                    {
                        intAutoID = int.Parse(hdnItemID.Value.ToString());
                        intInsertBy = int.Parse(hdnEnroll.Value.ToString());

                        if (hdnItemID.Value == "" || hdnItemID.Value == "0")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
                            return;
                        }

                        dt = new DataTable();
                        dt = itemAddtoMasterFromTempTableAdapter.InsertItemAddtoMasterTempTable(intItemId, intPart, intWHID,
                            strItemName, strPartNumber, strModelNumber, strBrand, null, null, null, null, null, null, null, null,
                            intUoM, strUoM, null, null, null, null, null, intInsertBy, null, intInsertBy, null, null, null,intInsertBy,
                            null, null, null, null, strItemFullName, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, strSallingUoM, numMinOrdQty, numMinDelvQty, intCostCenter,
                            intGLCode, intProductHeirarcy, intProfitCenter, null);

                        if (dt.Rows.Count > 0)
                        {
                            string msg = dt.Rows[0]["msg"].ToString();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                            hdnconfirm.Value = "0";
                            hdnItemID.Value = "0";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        }
                        
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnApprove_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void btnApprove_Click_old(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnApprove_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 10;
                    intAutoID = int.Parse(hdnItemID.Value.ToString());
                    intInsertBy = int.Parse(hdnEnroll.Value.ToString());
                    //intHML = int.Parse(ddlHML.SelectedValue.ToString());
                  //  strHML = ddlHML.SelectedItem.ToString();
                  //  try { ysnVATApplicable = bool.Parse(ddlVAT.SelectedValue.ToString()); } catch { ysnVATApplicable = false; }

                    if (hdnItemID.Value == "" || hdnItemID.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
                        return;
                    }

                    dt = new DataTable();
                    //dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                    //        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                    //        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                    //        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

                    if (dt.Rows.Count > 0)
                    {
                        string msg = dt.Rows[0]["msg"].ToString();

                        if (msg == "Updated")
                        {
                            intPart = 13;
                            dt = new DataTable();
                            //dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                            //intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                            //numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                            //numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

                            msg = dt.Rows[0]["msg"].ToString();
                        }
                        else
                        {
                            intPart = 14;
                            dt = new DataTable();
                            //dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                            //intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                            //numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                            //numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

                            msg = dt.Rows[0]["msg"].ToString();
                        }

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        //LoadGrid();
                        hdnconfirm.Value = "0";
                        hdnItemID.Value = "0";
                        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('1');", true);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnApprove_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnApprove_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion

        #region Method
        private void FillDropdown()
        {
            DataTable dtItemUoM = new DataTable();
            DataTable dtOthersUoM = new DataTable();
            DataTable dtPalnt = new DataTable();
            DataTable dtGLCode = new DataTable();
            ysnAll = true;
            intUnitID = int.Parse(hdnUnit.Value);
            try
            {
                dtItemUoM = commonTableAdapter.GetItemUoMData();
                dtOthersUoM = commonTableAdapter.GetOthersUoM();
                dtPalnt = commonTableAdapter.GetPlant(Convert.ToInt32(hdnUnit.Value));
                dtGLCode = getCOAChildByUnitTableAdapter.GetCOAList(intUnitID, null, null, null, ysnAll, null, null);

                ddlUoMN.DataSource = dtItemUoM;
                ddlUoMN.DataTextField = "strUoM";
                ddlUoMN.DataValueField = "intUoM";
                ddlUoMN.DataBind();

                ddlAlterUoM.DataSource = dtItemUoM;
                ddlAlterUoM.DataTextField = "strUoM";
                ddlAlterUoM.DataValueField = "intUoM";
                ddlAlterUoM.DataBind();

                ddlIsMRP.Items.Insert(0, new ListItem("---Select Is MRP---", "-1"));
                ddlIsMRP.Items.Insert(1, new ListItem("Yes", "1"));
                ddlIsMRP.Items.Insert(2, new ListItem("No", "0"));

                ddlLengthUom.DataSource = dtOthersUoM;
                ddlLengthUom.DataTextField = "strUoM";
                ddlLengthUom.DataValueField = "intUoM";
                ddlLengthUom.DataBind();

                ddlWidthUom.DataSource = dtOthersUoM;
                ddlWidthUom.DataTextField = "strUoM";
                ddlWidthUom.DataValueField = "intUoM";
                ddlWidthUom.DataBind();

                ddlHeightUoM.DataSource = dtOthersUoM;
                ddlHeightUoM.DataTextField = "strUoM";
                ddlHeightUoM.DataValueField = "intUoM";
                ddlHeightUoM.DataBind();

                ddlIdUom.DataSource = dtOthersUoM;
                ddlIdUom.DataTextField = "strUoM";
                ddlIdUom.DataValueField = "intUoM";
                ddlIdUom.DataBind();

                ddlOdUom.DataSource = dtOthersUoM;
                ddlOdUom.DataTextField = "strUoM";
                ddlOdUom.DataValueField = "intUoM";
                ddlOdUom.DataBind();

                ddlPlant.DataSource = dtPalnt;
                ddlPlant.DataTextField = "strPlantName";
                ddlPlant.DataValueField = "intPlantID";
                ddlPlant.DataBind();

                ddlGLCode.DataSource = dtGLCode;
                ddlGLCode.DataTextField = "strAccName";
                ddlGLCode.DataValueField = "intAccID";
                ddlGLCode.DataBind();
                ddlGLCode.Items.Insert(0, new ListItem("---Select GL Code---", "-1"));

                ddlLengthUom.Items.Insert(0, new ListItem("---Select Length UoM---", "-1"));
                ddlHeightUoM.Items.Insert(0, new ListItem("---Select Height UoM---", "-1"));
                ddlWidthUom.Items.Insert(0, new ListItem("---Select ddlWidth UoM---", "-1"));
                ddlIdUom.Items.Insert(0, new ListItem("---Select ID UoM---", "-1"));
                ddlOdUom.Items.Insert(0, new ListItem("---Select OD UoM---", "-1"));
                ddlPlant.Items.Insert(0, new ListItem("---Select Plant---", "-1"));
                
            }
            catch { }
        }
        private void LoadPopUp()
        {
            DataTable dta = new DataTable();
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                
                intUnitID = int.Parse(hdnUnit.Value); 
                intAutoID = int.Parse(hdnItemID.Value);
                dta = itemAddtoMasterFromTempTableAdapter.GetItemDataForAccountsApprover(intAutoID);

                if (dta != null)
                {
                    if (dta.Rows.Count > 0)
                    {
                        hdnWHID.Value = dta.Rows[0]["intWHId"].ToString();
                        hfStoreMasterId.Value = dta.Rows[0]["intMasterID"].ToString();
                        txtItemName.Text = dta.Rows[0]["strItemName"].ToString();
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intUOM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intUOM"]) > 0)
                        {
                            ddlUoMN.SelectedValue = dta.Rows[0]["intUOM"].ToString();
                        }
                        else
                        {
                            ddlUoMN.SelectedValue = "0";
                        }
                        txtColour.Text = !string.IsNullOrEmpty(dta.Rows[0]["strColour"].ToString()) ? dta.Rows[0]["strColour"].ToString() : string.Empty;
                        txtOriginn.Text = !string.IsNullOrEmpty(dta.Rows[0]["strOrigin"].ToString()) ? dta.Rows[0]["strOrigin"].ToString() : string.Empty;
                        txtPartNo.Text = !string.IsNullOrEmpty(dta.Rows[0]["strPart"].ToString()) ? dta.Rows[0]["strPart"].ToString() : string.Empty;
                        txtOtherSpec.Text = !string.IsNullOrEmpty(dta.Rows[0]["strOtherSpec"].ToString()) ? dta.Rows[0]["strOtherSpec"].ToString() : string.Empty;
                        txtModelNo.Text = !string.IsNullOrEmpty(dta.Rows[0]["strModel"].ToString()) ? dta.Rows[0]["strModel"].ToString() : string.Empty;
                        txtBrand.Text = !string.IsNullOrEmpty(dta.Rows[0]["strBrand"].ToString()) ? dta.Rows[0]["strBrand"].ToString() : string.Empty;
                        //txtLength.Text = !string.IsNullOrEmpty(dt.Rows[0]["numLength"].ToString()) ? dt.Rows[0]["numLength"].ToString() : string.Empty;
                        txtLength.Text = Convert.ToDecimal(dta.Rows[0]["numLength"].ToString()) > 0 ? dta.Rows[0]["numLength"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intlengthUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intlengthUoM"]) > 0)
                        {
                            ddlLengthUom.SelectedValue = dta.Rows[0]["intlengthUoM"].ToString();
                        }
                        else
                        {
                            ddlLengthUom.SelectedValue = "-1";
                        }
                        // txtWidth.Text = !string.IsNullOrEmpty(dt.Rows[0]["numWidth"].ToString()) ? dt.Rows[0]["numWidth"].ToString() : string.Empty;
                        txtWidth.Text = Convert.ToDecimal(dta.Rows[0]["numWidth"].ToString()) > 0 ? dta.Rows[0]["numWidth"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intWidthUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intWidthUoM"]) > 0)
                        {
                            ddlWidthUom.SelectedValue = dta.Rows[0]["intWidthUoM"].ToString();
                        }
                        else
                        {
                            ddlWidthUom.SelectedValue = "-1";
                        }
                        //txtHight.Text = !string.IsNullOrEmpty(dt.Rows[0]["numHight"].ToString()) ? dt.Rows[0]["numHight"].ToString() : string.Empty;
                        txtHight.Text = Convert.ToDecimal(dta.Rows[0]["numHight"].ToString()) > 0 ? dta.Rows[0]["numHight"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intHightUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intHightUoM"]) > 0)
                        {
                            ddlHeightUoM.SelectedValue = dta.Rows[0]["intHightUoM"].ToString();
                        }
                        else
                        {
                            ddlHeightUoM.SelectedValue = "-1";
                        }
                        //TextInnerDia.Text = !string.IsNullOrEmpty(dt.Rows[0]["numInnerDia"].ToString()) ? dt.Rows[0]["numInnerDia"].ToString() : string.Empty;
                        TextInnerDia.Text = Convert.ToDecimal(dta.Rows[0]["numInnerDia"].ToString()) > 0 ? dta.Rows[0]["numInnerDia"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intIDUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intIDUoM"]) > 0)
                        {
                            ddlIdUom.SelectedValue = dta.Rows[0]["intIDUoM"].ToString();
                        }
                        else
                        {
                            ddlIdUom.SelectedValue = "-1";
                        }
                        //TextOuterDia.Text = !string.IsNullOrEmpty(dt.Rows[0]["numOuterDia"].ToString()) ? dt.Rows[0]["numOuterDia"].ToString() : string.Empty;
                        TextOuterDia.Text = Convert.ToDecimal(dta.Rows[0]["numOuterDia"].ToString()) > 0 ? dta.Rows[0]["numOuterDia"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intODUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intODUoM"]) > 0)
                        {
                            ddlOdUom.SelectedValue = dta.Rows[0]["intODUoM"].ToString();
                        }
                        else
                        {
                            ddlOdUom.SelectedValue = "-1";
                        }
                        //TextGrossWt.Text = !string.IsNullOrEmpty(dt.Rows[0]["numGrossWt"].ToString()) ? dt.Rows[0]["numGrossWt"].ToString() : string.Empty;
                        //TextNetWt.Text = !string.IsNullOrEmpty(dt.Rows[0]["numNetWt"].ToString()) ? dt.Rows[0]["numNetWt"].ToString() : string.Empty;
                        TextGrossWt.Text = Convert.ToDecimal(dta.Rows[0]["numGrossWt"].ToString()) > 0 ? dta.Rows[0]["numGrossWt"].ToString() : string.Empty;
                        TextNetWt.Text = Convert.ToDecimal(dta.Rows[0]["numNetWt"].ToString()) > 0 ? dta.Rows[0]["numNetWt"].ToString() : string.Empty;
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intAlterUoM"].ToString()) && Convert.ToInt32(dta.Rows[0]["intAlterUoM"]) > 0)
                        {
                            ddlAlterUoM.SelectedValue = dta.Rows[0]["intAlterUoM"].ToString();
                        }
                        else
                        {
                            ddlAlterUoM.SelectedValue = "-1";
                        }
                        if (!string.IsNullOrEmpty(dta.Rows[0]["intPlantID"].ToString()) && Convert.ToInt32(dta.Rows[0]["intPlantID"]) > 0)
                        {
                            ddlPlant.SelectedValue = dta.Rows[0]["intPlantID"].ToString();
                        }
                        else
                        {
                            ddlPlant.SelectedValue = "-1";
                        }
                        if (!string.IsNullOrEmpty(dta.Rows[0]["isMRP"].ToString()) && Convert.ToInt32(dta.Rows[0]["isMRP"]) > -1)
                        {
                            ddlIsMRP.SelectedValue = dta.Rows[0]["isMRP"].ToString();
                        }
                        else
                        {
                            ddlIsMRP.SelectedValue = "-1";
                        }
                        //txtReOrderPoint.Text = !string.IsNullOrEmpty(dt.Rows[0]["numReorderPoint"].ToString()) ? dt.Rows[0]["numReorderPoint"].ToString() : string.Empty;
                        txtReOrderPoint.Text = Convert.ToInt32(dta.Rows[0]["numReorderPoint"]) > 0 ? dta.Rows[0]["numReorderPoint"].ToString() : string.Empty;
                        txtMinStock.Text = Convert.ToInt32(dta.Rows[0]["numMinimumStock"]) > 0 ? dta.Rows[0]["numMinimumStock"].ToString() : string.Empty;
                        txtMaxStock.Text = Convert.ToInt32(dta.Rows[0]["numMaximumStock"]) > 0 ? dta.Rows[0]["numMaximumStock"].ToString() : string.Empty;
                        txtSaftyStock.Text = Convert.ToInt32(dta.Rows[0]["numSafetyStock"]) > 0 ? dta.Rows[0]["numSafetyStock"].ToString() : string.Empty;
                        txtCode.Text = !string.IsNullOrEmpty(dta.Rows[0]["strHSCode"].ToString()) ? dta.Rows[0]["strHSCode"].ToString() : string.Empty;
                        txtPOrigin.Text = !string.IsNullOrEmpty(dta.Rows[0]["strPOrigin"].ToString()) ? dta.Rows[0]["strPOrigin"].ToString() : string.Empty;
                        txtMinOrderQty.Text = !string.IsNullOrEmpty(dta.Rows[0]["numMinOrderQty"].ToString()) ? dta.Rows[0]["numMinOrderQty"].ToString() : string.Empty;
                        txtLeadTime.Text = !string.IsNullOrEmpty(dta.Rows[0]["intLeadTime"].ToString()) ? dta.Rows[0]["intLeadTime"].ToString() : string.Empty;
                        txtPurchaseDescription.Text = !string.IsNullOrEmpty(dta.Rows[0]["strPurchaseDescription"].ToString()) ? dta.Rows[0]["strPurchaseDescription"].ToString() : string.Empty;
                    }
                }

                //ysnPurchase = true;
                //ysnAll = true;
                //dt = new DataTable();
                FillDropdown2();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void LoadPopUp_old()
        {
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                dt = new DataTable();
                dt = bll.GetItemInfoForAccounts(intAutoID);

                //txtBaseName.Text = dt.Rows[0]["strItemName"].ToString();
                //txtDescription.Text = dt.Rows[0]["strDescription"].ToString();
                //txtPart.Text = dt.Rows[0]["strPart"].ToString();
                //txtModel.Text = dt.Rows[0]["strModel"].ToString();
                //txtSerial.Text = dt.Rows[0]["strSerial"].ToString();
                //txtBrand.Text = dt.Rows[0]["strBrand"].ToString();
                //txtSpecification.Text = dt.Rows[0]["strSpecifiaction"].ToString();
                //txtOrigin.Text = dt.Rows[0]["strOrigin"].ToString();
                //txtHSCode.Text = dt.Rows[0]["strHSCode"].ToString();
                //txtReOrderQty.Text = dt.Rows[0]["numReOrderQty"].ToString();
                //txtReOrder.Text = dt.Rows[0]["numReOrderLevel"].ToString();
                //txtMinimum.Text = dt.Rows[0]["numMinimumStock"].ToString();
                //txtMaximum.Text = dt.Rows[0]["numMaximumStock"].ToString();
                //txtSafety.Text = dt.Rows[0]["numSafetyStock"].ToString();
                //txtSelfTime.Text = dt.Rows[0]["intSelfTime"].ToString();
                //txtUOM.Text = dt.Rows[0]["strUOM"].ToString();
                //txtGroup.Text = dt.Rows[0]["strGroupName"].ToString();
                //txtCategory.Text = dt.Rows[0]["strCategoryName"].ToString();
                //txtSubCategory.Text = dt.Rows[0]["strSubCategoryName"].ToString();
                //txtMinorCategory.Text = dt.Rows[0]["strMinorCategory"].ToString();
                //txtPlant.Text = dt.Rows[0]["strPlantName"].ToString();
                //txtPurchaseType.Text = dt.Rows[0]["strPurchaseType"].ToString();
                //txtMaxLeadTime.Text = dt.Rows[0]["numMaxLeadTime"].ToString();
                //txtMinLeadTime.Text = dt.Rows[0]["numMinLeadTime"].ToString();
                //txtAvgLeadTime.Text = dt.Rows[0]["numAvgLeadTime"].ToString();
                //txtLotSize.Text = dt.Rows[0]["strOrderingLotSize"].ToString();
                //txtEOQ.Text = dt.Rows[0]["numEconomicOrderQty"].ToString();
                //txtMOQ.Text = dt.Rows[0]["numMinimumOrderQty"].ToString();
                //txtSDE.Text = dt.Rows[0]["strSDEClassification"].ToString();

                intPart = 17;
                intWHID = int.Parse(dt.Rows[0]["intWHID"].ToString());
                dt = new DataTable();
                //dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                //        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                //        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                //        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

                intUnitID = int.Parse(dt.Rows[0]["intUnitID"].ToString());

                ysnPurchase = true;
                dt = new DataTable();
                //dt = bll.GetCOAList(intUnitID, ysnAdvance, ysnPurchase, ysnCreditors, ysnAll, ysnBillReg);

                ddlGLCode.DataTextField = "strAccName";
                ddlGLCode.DataValueField = "intAccID";
                ddlGLCode.DataSource = dt;
                ddlGLCode.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void FillDropdown2()
        {
            DataTable dtCostCenter = new DataTable();
            DataTable dtSalUoM = new DataTable();
            intUnitID = int.Parse(hdnUnit.Value);
            try
            {
                dtCostCenter = costCenterTableAdapter.GetAllCostCenterByWH(Convert.ToInt32(hdnWHID.Value));
                dtSalUoM = commonTableAdapter.GetSallingUoM(intUnitID);

                ddlSACostCenter.DataSource = dtCostCenter;
                ddlSACostCenter.DataTextField = "strName";
                ddlSACostCenter.DataValueField = "Id";
                ddlSACostCenter.DataBind();
                ddlSACostCenter.Items.Insert(0, new ListItem("---Select Cost Center---", "-1"));

                ddlSASallingUoM.DataSource = dtSalUoM;
                ddlSASallingUoM.DataTextField = "strUoM";
                ddlSASallingUoM.DataValueField = "intID";
                ddlSASallingUoM.DataBind();
                ddlSASallingUoM.Items.Insert(0, new ListItem("---Select Salling UoM---", "-1"));

                ddlSAProfitCenter.Items.Insert(0, new ListItem("---Select Profit Center---", "-1"));


            }
            catch (Exception ex)
            {
            }
        }
        private void FillSalesnAccountDeptData()
        {
            try
            {
                intPart = 4;
                intAutoID = Convert.ToInt32(hdnItemID.Value);
                numMinOrdQty = !string.IsNullOrEmpty(txtSAMinOrderQty.Text) ? Convert.ToDecimal(txtSAMinOrderQty.Text) : 0;
                numMinDelvQty = !string.IsNullOrEmpty(txtSAMinDelvQty.Text) ? Convert.ToDecimal(txtSAMinDelvQty.Text) : 0;
                intProductHeirarcy = !string.IsNullOrEmpty(txtSAProductHeirarchy.Text) ? Convert.ToInt32(txtSAProductHeirarchy.Text) : 0;
                intCostCenter = Convert.ToInt32(ddlSACostCenter.SelectedValue) > 0 ? Convert.ToInt32(ddlSACostCenter.SelectedValue) : 0;
                strCostCenter = Convert.ToInt32(ddlSACostCenter.SelectedValue) > 0 ? ddlSACostCenter.SelectedItem.ToString() : string.Empty;
                intSallingUoM = Convert.ToInt32(ddlSASallingUoM.SelectedValue) > 0 ? Convert.ToInt32(ddlSASallingUoM.SelectedValue) : 0;
                strSallingUoM = Convert.ToInt32(ddlSASallingUoM.SelectedValue) > 0 ? ddlSASallingUoM.SelectedItem.ToString() : string.Empty;
                intGLCode = Convert.ToInt32(ddlGLCode.SelectedValue) > 0 ? Convert.ToInt32(ddlGLCode.SelectedValue) : 0;
                strGLCode = Convert.ToInt32(ddlGLCode.SelectedValue) > 0 ? ddlGLCode.SelectedItem.ToString() : string.Empty;
                intProfitCenter = Convert.ToInt32(ddlSAProfitCenter.SelectedValue) > 0 ? Convert.ToInt32(ddlSAProfitCenter.SelectedValue) : 0;
                strProfitCenter = Convert.ToInt32(ddlSAProfitCenter.SelectedValue) > 0 ? ddlSAProfitCenter.SelectedItem.ToString() : string.Empty;
                intItemId = Convert.ToInt32(hdnItemID.Value);
                strItemName = commonTableAdapter.GetItemName(intItemId);
                strItemFullName = commonTableAdapter.GetItemFullName(intItemId);
                strUoM = Convert.ToInt32(ddlUoMN.SelectedValue) > 0 ? ddlUoMN.SelectedItem.ToString() : string.Empty;
                intUoM = Convert.ToInt32(ddlUoMN.SelectedValue) > 0 ? Convert.ToInt32(ddlUoMN.SelectedValue) : 0;
                strPartNumber = !string.IsNullOrEmpty(txtPartNo.Text) ? txtPartNo.Text : string.Empty;
                strModelNumber = !string.IsNullOrEmpty(txtModelNo.Text) ? txtModelNo.Text : string.Empty;
                strBrand = !string.IsNullOrEmpty(txtBrand.Text) ? txtBrand.Text : string.Empty;
                intInsertBy = int.Parse(hdnEnroll.Value.ToString());
            }
            catch (Exception ex)
            {

            }
        }
        private bool Validation()
        {
            if (ddlGLCode.SelectedValue == "-1")
            {
                ddlGLCode.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select GL Code!');", true);
                return false;
            }
            
            return true;
        }
        private void Clear()
        {
            txtItemName.Text = string.Empty;
            txtColour.Text = string.Empty;
            txtPartNo.Text = string.Empty;
            txtOriginn.Text = string.Empty;
            txtOtherSpec.Text = string.Empty;
            txtModelNo.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtWidth.Text = string.Empty;
            txtHight.Text = string.Empty;
            TextInnerDia.Text = string.Empty;
            TextOuterDia.Text = string.Empty;
            TextGrossWt.Text = string.Empty;
            TextNetWt.Text = string.Empty;
            txtReOrderPoint.Text = string.Empty;
            txtMinStock.Text = string.Empty;
            txtSaftyStock.Text = string.Empty;
            txtMaxStock.Text = string.Empty;
            ddlUoMN.SelectedValue = "0";
            ddlLengthUom.SelectedValue = "-1";
            ddlWidthUom.SelectedValue = "-1";
            ddlHeightUoM.SelectedValue = "-1";
            ddlIdUom.SelectedValue = "-1";
            ddlOdUom.SelectedValue = "-1";
            ddlAlterUoM.SelectedValue = "0";
            ddlPlant.SelectedValue = "-1";
            ddlIsMRP.SelectedValue = "-1";
            txtCode.Text = string.Empty;
            txtPOrigin.Text = string.Empty;
            txtMinOrderQty.Text = string.Empty;
            txtLeadTime.Text = string.Empty;
            txtPurchaseDescription.Text = string.Empty;
            txtSAMinOrderQty.Text = string.Empty;
            txtSAMinDelvQty.Text = string.Empty;
            txtSAProductHeirarchy.Text = string.Empty;
            ddlSASallingUoM.SelectedValue = "-1";
            ddlGLCode.SelectedValue = "-1";
            ddlSAProfitCenter.SelectedValue = "-1";
            ddlSACostCenter.SelectedValue = "-1";
        }
        #endregion
    }
}