using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using SCM_DAL.ItemManagerStoreTDSTableAdapters;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ItemManagerAccounts : BasePage
    {
        #region INIT
        private ItemAddtoMasterFromTempTableAdapter itemAddtoMasterFromTempTableAdapter = new ItemAddtoMasterFromTempTableAdapter();
        private MasterMaterialBLL bll = new MasterMaterialBLL();
        private DataTable dt;
        private int intPart, intUOM, intLocationID, intGroupID, intCategoryID, intSubCategoryID, intMinorCategory, intPlantID, intProcureType, intABC, intFSN, intVDE, intSelfLife, intSDE, intHML, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID;

        private string strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, strUOM, strOrigin, strHSCode, strGroupName, strCategoryName, strSubCategoryName, strMinorCategory,
            strPlantName, strProcureType, strABC, strFSN, strVDE, strOrderingLotSize, strSDE, strHML;

        private decimal numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump;
        private bool ysnVATApplicable;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ItemManagerAccounts";
        private string stop = "stopping SCM\\ItemManagerAccounts";
        private string perform = "Performance on SCM\\ItemManagerAccounts";
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            intInsertBy = int.Parse(hdnEnroll.Value);

            if (!IsPostBack)
            {
                LoadWareHouse();
                try //WH List for Accounts
                {
                    //intPart = 16;
                    //intInsertBy = int.Parse(hdnEnroll.Value);
                    //dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                    //    intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                    //    numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                    //    numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
                    //ddlWH.DataTextField = "strWareHoseName";
                    //ddlWH.DataValueField = "intWHID";
                    //ddlWH.DataSource = dt;
                    //ddlWH.DataBind();
                }
                catch { }
            }
        }
        #endregion

        #region Event
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
                    intPart = 12;
                    dt = new DataTable();
                    dt = bll.InsertUpdateSelectForItem(intPart, strMaterialName, strDescription, strPart, strModel, strSerial, strBrand, strSpecification, intUOM, strUOM, strOrigin, intLocationID, strHSCode,
                        intGroupID, strGroupName, intCategoryID, strCategoryName, intSubCategoryID, strSubCategoryName, intMinorCategory, strMinorCategory, intPlantID, strPlantName, intProcureType, strProcureType,
                        numMaxLeadTime, numMinLeadTime, numMinimumStock, numMaximumStock, numSafetyStock, numReOrderPoint, numReOrderQty, intABC, strABC, intFSN, strFSN, intVDE, strVDE, intSelfLife, strOrderingLotSize,
                        numEOQ, numMOQ, numMaxDailyConsump, numMinDailyConsump, intSDE, strSDE, intHML, strHML, ysnVATApplicable, intWHID, intAutoID, intInsertBy, intCOAID, intMasterID);
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
            var fd = log.GetFlogDetail(start, location, "btnAdd_Click", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker(perform + " " + "btnAdd_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                LoadGrid();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        #endregion

        #region Method
        private void LoadWareHouse()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = itemAddtoMasterFromTempTableAdapter.GetWHFromItemTempTable(Convert.ToInt32(hdnEnroll.Value));
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strWareHoseName";
                ddlWH.DataValueField = "intWHID";
                ddlWH.DataBind();

                ddlWH.Items.Insert(0, new ListItem("---Select Ware House---", "-1"));
            }
            catch (Exception ex)
            {
            }
        }
        private void LoadGrid()
        {
            dt = new DataTable();
            dt = itemAddtoMasterFromTempTableAdapter.GetAllItemTempDataForAccounts(intWHID);
            dgvItem.DataSource = dt;
            dgvItem.DataBind();
        }
        private void LoadGrid_old()
        {
            dt = new DataTable();
            dt = bll.GetItemListForAccounts(intWHID);
            dgvItem.DataSource = dt; dgvItem.DataBind();
        }
        #endregion




    }
}