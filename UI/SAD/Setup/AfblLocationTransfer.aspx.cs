using SAD_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.SAD.Setup
{
    public partial class AfblLocationTransfer : System.Web.UI.Page
    {
        #region INITIALIZE
        String errMsg = string.Empty;
        AfblDistributionBll objAfblDistributionBll = new AfblDistributionBll();

        #endregion

        #region EventBase
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombo();
            }
        }

        protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCatagory.SelectedValue))
                ShowHide();
        }
        protected void ddlExLineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlExRegion.Items.Clear();
                ddlExArea.Items.Clear();
                ddlExTerritory.Items.Clear();
                ddlExPointName.Items.Clear();
                ddlExSectionName.Items.Clear();

                if (!string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlExLineName.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlExRegion.DataTextField = "strDiscription";
                    ddlExRegion.DataValueField = "intID";
                    ddlExRegion.DataSource = dt;
                    ddlExRegion.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlExRegion.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlExRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlExArea.Items.Clear();
                ddlExTerritory.Items.Clear();
                ddlExPointName.Items.Clear();
                ddlExSectionName.Items.Clear();

                if (!string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlExRegion.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlExArea.DataTextField = "strDiscription";
                    ddlExArea.DataValueField = "intID";
                    ddlExArea.DataSource = dt;
                    ddlExArea.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlExArea.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlExArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlExTerritory.Items.Clear();
                ddlExPointName.Items.Clear();
                ddlExSectionName.Items.Clear();

                if (!string.IsNullOrEmpty(ddlExArea.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlExArea.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlExTerritory.DataTextField = "strDiscription";
                    ddlExTerritory.DataValueField = "intID";
                    ddlExTerritory.DataSource = dt;
                    ddlExTerritory.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlExTerritory.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlExTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlExPointName.Items.Clear();
                ddlExSectionName.Items.Clear();

                if (!string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlExTerritory.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlExPointName.DataTextField = "strDiscription";
                    ddlExPointName.DataValueField = "intID";
                    ddlExPointName.DataSource = dt;
                    ddlExPointName.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlExPointName.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlExPointName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlExSectionName.Items.Clear();

                if (!string.IsNullOrEmpty(ddlExPointName.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlExPointName.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlExSectionName.DataTextField = "strDiscription";
                    ddlExSectionName.DataValueField = "intID";
                    ddlExSectionName.DataSource = dt;
                    ddlExSectionName.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlExSectionName.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }



        //--- New LOC

        protected void ddlNLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlNRegion.Items.Clear();
                ddlNArea.Items.Clear();
                ddlNTerritory.Items.Clear();
                ddlNPointName.Items.Clear();
                ddlNSection.Items.Clear();

                if (!string.IsNullOrEmpty(ddlNLine.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlNLine.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlNRegion.DataTextField = "strDiscription";
                    ddlNRegion.DataValueField = "intID";
                    ddlNRegion.DataSource = dt;
                    ddlNRegion.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlNRegion.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlNRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlNArea.Items.Clear();
                ddlNTerritory.Items.Clear();
                ddlNPointName.Items.Clear();
                ddlNSection.Items.Clear();

                if (!string.IsNullOrEmpty(ddlNRegion.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlNRegion.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlNArea.DataTextField = "strDiscription";
                    ddlNArea.DataValueField = "intID";
                    ddlNArea.DataSource = dt;
                    ddlNArea.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlNArea.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlNArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlNTerritory.Items.Clear();
                ddlNPointName.Items.Clear();
                ddlNSection.Items.Clear();

                if (!string.IsNullOrEmpty(ddlNArea.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlNArea.SelectedValue.ToString());
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlNTerritory.DataTextField = "strDiscription";
                    ddlNTerritory.DataValueField = "intID";
                    ddlNTerritory.DataSource = dt;
                    ddlNTerritory.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlNTerritory.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlNTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlNPointName.Items.Clear();
                ddlNSection.Items.Clear();

                if (!string.IsNullOrEmpty(ddlNTerritory.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlNTerritory.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlNPointName.DataTextField = "strDiscription";
                    ddlNPointName.DataValueField = "intID";
                    ddlNPointName.DataSource = dt;
                    ddlNPointName.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlNPointName.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void ddlNPointName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                ddlNSection.Items.Clear();

                if (!string.IsNullOrEmpty(ddlNPointName.SelectedValue))
                {
                    int parentId = Convert.ToInt32(ddlNPointName.SelectedValue.ToString()); ;
                    int part = 8;
                    dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                    ddlNSection.DataTextField = "strDiscription";
                    ddlNSection.DataValueField = "intID";
                    ddlNSection.DataSource = dt;
                    ddlNSection.DataBind();
                    // To make it the first element at the list, use 0 index : 
                    ddlNSection.Items.Insert(0, new ListItem("Select", string.Empty));
                }
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }


        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            int catagory =Convert.ToInt32(ddlCatagory.SelectedValue.ToString());
            if (catagory > 0)
                TransferLoc(catagory);
            else
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Transfer Catagory.');", true);
        }

        #endregion

        #region USRMethod             

        private void BindCombo()
        {
            DataTable dt = new DataTable();
            try
            {
                int parentId = 0;
                int part = 8;
                dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);

                ddlExLineName.DataTextField = "strDiscription";
                ddlExLineName.DataValueField = "intID";
                ddlExLineName.DataSource = dt;
                ddlExLineName.DataBind();
                // To make it the first element at the list, use 0 index : 
                ddlExLineName.Items.Insert(0, new ListItem("Select", string.Empty));

                ddlNLine.DataTextField = "strDiscription";
                ddlNLine.DataValueField = "intID";
                ddlNLine.DataSource = dt;
                ddlNLine.DataBind();
                // To make it the first element at the list, use 0 index : 
                ddlNLine.Items.Insert(0, new ListItem("Select", string.Empty));
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void ClearAll()
        {
            ddlExLineName.Items.Clear();
            ddlExRegion.Items.Clear();
            ddlExArea.Items.Clear();
            ddlExTerritory.Items.Clear();
            ddlExPointName.Items.Clear();
            ddlExSectionName.Items.Clear();

            ddlNLine.Items.Clear();
            ddlNRegion.Items.Clear();
            ddlNArea.Items.Clear();
            ddlNTerritory.Items.Clear();
            ddlNPointName.Items.Clear();
            ddlNSection.Items.Clear();

            BindCombo();
            ShowHide();
        }

        private void ShowHide()
        {
            string tValue = ddlCatagory.SelectedValue.ToString();

            lblExAreaName.Visible = false;
            ddlExArea.Visible = false;
            lblExTerritory.Visible = false;
            ddlExTerritory.Visible = false;
            lblExPoint.Visible = false;
            ddlExPointName.Visible = false;
            lblExSection.Visible = false;
            ddlExSectionName.Visible = false;

            lblNArea.Visible = false;
            ddlNArea.Visible = false;
            lblNTerritory.Visible = false;
            ddlNTerritory.Visible = false;
            lblNPoint.Visible = false;
            ddlNPointName.Visible = false;

            if (tValue=="1")
            {
                lblExAreaName.Visible = true;
                ddlExArea.Visible = true;
            }
            else if (tValue == "2")
            {
                lblExAreaName.Visible = true;
                ddlExArea.Visible = true;
                lblExTerritory.Visible = true;
                ddlExTerritory.Visible = true;

                lblNArea.Visible = true;
                ddlNArea.Visible = true;
            }
            else if (tValue == "3")
            {
                lblExAreaName.Visible = true;
                ddlExArea.Visible = true;
                lblExTerritory.Visible = true;
                ddlExTerritory.Visible = true;
                lblExPoint.Visible = true;
                ddlExPointName.Visible = true;

                lblNArea.Visible = true;
                ddlNArea.Visible = true;
                lblNTerritory.Visible = true;
                ddlNTerritory.Visible = true;
            }
            else if (tValue == "4")
            {
                lblExAreaName.Visible = true;
                ddlExArea.Visible = true;
                lblExTerritory.Visible = true;
                ddlExTerritory.Visible = true;
                lblExPoint.Visible = true;
                ddlExPointName.Visible = true;
                lblExSection.Visible = true;
                ddlExSectionName.Visible = true;

                lblNArea.Visible = true;
                ddlNArea.Visible = true;
                lblNTerritory.Visible = true;
                ddlNTerritory.Visible = true;
                lblNPoint.Visible = true;
                ddlNPointName.Visible = true;
            }            
        }

        private void TransferLoc(int tCatg)
        {
            string vMsg = string.Empty;
            int parentID=-1;
            int childId=-1;    //intID
            int partId = 12;

            try
            {
                //Area
                if (tCatg == 1)
                {
                    if (!string.IsNullOrEmpty(ddlNRegion.SelectedValue))
                        parentID = Convert.ToInt32(ddlNRegion.SelectedValue.ToString());
                    else
                        vMsg = "Select New Region Name";
                    if (!string.IsNullOrEmpty(ddlExArea.SelectedValue))
                        childId = Convert.ToInt32(ddlExArea.SelectedValue.ToString());
                    else
                        vMsg = "Select Existing Area";
                }
                //Territory
                if (tCatg == 2)
                {
                    if (!string.IsNullOrEmpty(ddlNArea.SelectedValue))
                        parentID = Convert.ToInt32(ddlNArea.SelectedValue.ToString());
                    else
                        vMsg = "Select New Area ";
                    if (!string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                        childId = Convert.ToInt32(ddlExTerritory.SelectedValue.ToString());
                    else
                        vMsg = "Select Existing Territory";
                }
                //Point
                if (tCatg == 3)
                {
                    if (!string.IsNullOrEmpty(ddlNTerritory.SelectedValue))
                        parentID = Convert.ToInt32(ddlNTerritory.SelectedValue.ToString());
                    else
                        vMsg = "Select New Territory ";
                    if (!string.IsNullOrEmpty(ddlExPointName.SelectedValue))
                        childId = Convert.ToInt32(ddlExPointName.SelectedValue.ToString());
                    else
                        vMsg = "Select Existing Point";
                }
                //Section
                if (tCatg == 3)
                {
                    if (!string.IsNullOrEmpty(ddlNPointName.SelectedValue))
                        parentID = Convert.ToInt32(ddlNPointName.SelectedValue.ToString());
                    else
                        vMsg = "Select New Point ";
                    if (!string.IsNullOrEmpty(ddlExSectionName.SelectedValue))
                        childId = Convert.ToInt32(ddlExSectionName.SelectedValue.ToString());
                    else
                        vMsg = "Select Existing Section";
                }

                if (string.IsNullOrEmpty(vMsg))
                {
                    objAfblDistributionBll.SaveAFBLDistributionInfo(null, null, parentID, null, partId, null, null, childId, null, null, null);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Transfer Successfully');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + vMsg + "');", true);
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        #endregion


    }
}