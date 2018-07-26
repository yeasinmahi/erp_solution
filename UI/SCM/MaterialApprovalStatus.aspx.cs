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
    public partial class MaterialApprovalStatus : BasePage
    {
        MasterMaterialBLL bll = new MasterMaterialBLL(); DataTable dt;
        int intPart, intUOM, intLocationID, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intProcureType, intABC, intFSN, intVDE, intSelfLife, intSDE, intHML, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID;

        string strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strUOM, strOrigin, strHSCode, strGroupName, strCategoryName, strSubCategoryName, strMinorCategory,
            strPlantName, strProcureType, strABC, strFSN, strVDE, strOrderingLotSize, strSDE, strHML;
        decimal numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump;
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
                    intPart = 18;
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
            }
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItem.DataSource = "";
            dgvItem.DataBind();
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetMaterialStatus(intWHID);
                dgvItem.DataSource = dt;
                dgvItem.DataBind();
            }
            catch { }
        }

    }
}