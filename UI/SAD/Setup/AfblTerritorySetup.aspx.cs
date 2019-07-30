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
    public partial class AfblTerritorySetup : System.Web.UI.Page
    {
        #region INITIALIZE
        String errMsg = string.Empty;
        AfblDistributionBll objAfblDistributionBll = new AfblDistributionBll();

        #endregion


        #region EventMethod
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombo();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string vMsg = string.Empty;
            if (hdnconfirm.Value == "1")
            {
                if (string.IsNullOrEmpty(txtTerritory.Text))
                    vMsg = "Provide New Territory Name";
                else if (string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                    vMsg = "Select Line";
                else if (string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                    vMsg = "Select Region";
                else if (string.IsNullOrEmpty(ddlExArea.SelectedValue))
                    vMsg = "Select Area";
                if (string.IsNullOrEmpty(vMsg))
                    SaveAFBLTerritoryInfo();
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + vMsg + "');", true);
            }
        }
               
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string vMsg = string.Empty;
            if (hdnconfirm.Value == "1")
            {
                if (string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                    vMsg = "Select Line";
                else if (string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                    vMsg = "Select Region";
                else if (string.IsNullOrEmpty(ddlExArea.SelectedValue))
                    vMsg = "Select  Area";
                else if (string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                    vMsg = "Select Exist Territory";
                else if (string.IsNullOrEmpty(txtTerritory.Text))
                    vMsg = "Provide New Territory Name";

                if (string.IsNullOrEmpty(vMsg))
                    UpdateAFBLTerritoryInfo();
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + vMsg + "');", true);
            }
        }        

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        protected void ddlExLineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {               
                ddlExRegion.Items.Clear();               
                ddlExArea.Items.Clear();
                ddlExTerritory.Items.Clear();

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
            string phoneNo = string.Empty;
            string desc = string.Empty;
            int lineId = 0;
            try
            {
                if (!string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                {
                    int part = 14;
                    lineId = Convert.ToInt32(ddlExTerritory.SelectedValue.ToString());
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                    {
                        phoneNo = dt.Rows[0].Field<string>(3);
                        desc = dt.Rows[0].Field<string>(4);
                    }
                    btnCreate.Visible = false;
                }
                else
                    btnCreate.Visible = true;

                txtTerritory.Text = desc;
                txtPhoneNo.Text = phoneNo;
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }
        
        #endregion
        
        #region UserMethod
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
                
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void clearAll()
        {
            txtTerritory.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            ddlExRegion.Items.Clear();
            ddlExLineName.Items.Clear();
            ddlExArea.Items.Clear();
            ddlExTerritory.Items.Clear();
            BindCombo();
            btnCreate.Visible = true;
        }

        private void SaveAFBLTerritoryInfo()
        {
            try
            {
                int lvlId = 4, part = 1, activeEnroll = 0;
                string officePhone = "0";
                int parentId = Convert.ToInt32(ddlExArea.SelectedValue.ToString());
                string desc = txtTerritory.Text.Trim();

                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.SaveAFBLGeoInfo(desc, officePhone, parentId, lvlId, part, activeEnroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Create Successfully.');", true);
                clearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void UpdateAFBLTerritoryInfo()
        {
            try
            {
                int part = 9;
                string officePhone = "0";
                int lineId = Convert.ToInt32(ddlExTerritory.SelectedValue.ToString());
                string desc = txtTerritory.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.UpdateAFBLGeoInfo(desc, officePhone, lineId, part);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully.');", true);
                clearAll();
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