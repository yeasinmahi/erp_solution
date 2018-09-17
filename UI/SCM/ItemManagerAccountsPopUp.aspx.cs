using Flogging.Core;
using GLOBAL_BLL;
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
    public partial class ItemManagerAccountsPopUp : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        MasterMaterialBLL bll = new MasterMaterialBLL(); DataTable dt;
        int intUnitID, intPart, intUOM, intLocationID, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intProcureType, intABC, intFSN, intVDE, intSelfLife, intSDE, intHML, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID;
        string strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strUOM, strOrigin, strHSCode, strGroupName, strCategoryName, strSubCategoryName, strMinorCategory,
            strPlantName, strProcureType, strABC, strFSN, strVDE, strOrderingLotSize, strSDE, strHML;
        decimal numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump;
        bool ysnVATApplicable, ysnAdvance, ysnPurchase, ysnCreditors, ysnAll, ysnBillReg;

        SeriLog log = new SeriLog();
        string location = "SCM";
        string start = "starting SCM\\ItemManagerAccountsPopUp";
        string stop = "stopping SCM\\ItemManagerAccountsPopUp";
        string perform = "Performance on SCM\\ItemManagerAccountsPopUp";
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
            var fd = log.GetFlogDetail(start, location, "PageLoad", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
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
                txtSpecification.Text = dt.Rows[0]["strSpecifiaction"].ToString();
                txtOrigin.Text = dt.Rows[0]["strOrigin"].ToString();
                txtHSCode.Text = dt.Rows[0]["strHSCode"].ToString();
                txtReOrderQty.Text = dt.Rows[0]["numReOrderQty"].ToString();
                txtReOrder.Text = dt.Rows[0]["numReOrderLevel"].ToString();
                txtMinimum.Text = dt.Rows[0]["numMinimumStock"].ToString();
                txtMaximum.Text = dt.Rows[0]["numMaximumStock"].ToString();
                txtSafety.Text = dt.Rows[0]["numSafetyStock"].ToString();
                txtSelfTime.Text = dt.Rows[0]["intSelfTime"].ToString();
                txtUOM.Text = dt.Rows[0]["strUOM"].ToString();
                txtGroup.Text = dt.Rows[0]["strGroupName"].ToString();
                txtCategory.Text = dt.Rows[0]["strCategoryName"].ToString();
                txtSubCategory.Text = dt.Rows[0]["strSubCategoryName"].ToString();
                txtMinorCategory.Text = dt.Rows[0]["strMinorCategory"].ToString();
                txtPlant.Text = dt.Rows[0]["strPlantName"].ToString();
                txtPurchaseType.Text = dt.Rows[0]["strPurchaseType"].ToString();
                txtMaxLeadTime.Text = dt.Rows[0]["numMaxLeadTime"].ToString();
                txtMinLeadTime.Text = dt.Rows[0]["numMinLeadTime"].ToString();
                txtAvgLeadTime.Text = dt.Rows[0]["numAvgLeadTime"].ToString();
                txtLotSize.Text = dt.Rows[0]["strOrderingLotSize"].ToString();
                txtEOQ.Text = dt.Rows[0]["numEconomicOrderQty"].ToString();
                txtMOQ.Text = dt.Rows[0]["numMinimumOrderQty"].ToString();
                txtSDE.Text = dt.Rows[0]["strSDEClassification"].ToString();

                intPart = 17;
                intWHID = int.Parse(dt.Rows[0]["intWHID"].ToString());
                dt = new DataTable();
                dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);


                intUnitID = int.Parse(dt.Rows[0]["intUnitID"].ToString());

                ysnPurchase = true;
                dt = new DataTable();
                dt = bll.GetCOAList(intUnitID, ysnAdvance, ysnPurchase, ysnCreditors, ysnAll, ysnBillReg);

                ddlCOA.DataTextField = "strAccName";
                ddlCOA.DataValueField = "intAccID";
                ddlCOA.DataSource = dt;
                ddlCOA.DataBind();
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
        #region ===== Submit Action =========================================================
        protected void btnApprove_Click(object sender, EventArgs e)
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
                    intHML = int.Parse(ddlHML.SelectedValue.ToString());
                    strHML = ddlHML.SelectedItem.ToString();
                    try { ysnVATApplicable = bool.Parse(ddlVAT.SelectedValue.ToString()); } catch { ysnVATApplicable = false; }

                    if (hdnItemID.Value == "" || hdnItemID.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Information.....');", true);
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

                        if (msg == "Updated")
                        {
                            intPart = 13;
                            dt = new DataTable();
                            dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                            intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                            numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                            numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

                            msg = dt.Rows[0]["msg"].ToString();
                        }
                        else
                        {
                            intPart = 14;
                            dt = new DataTable();
                            dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                            intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                            numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                            numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);

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
         
        #endregion ==========================================================================
    }
}