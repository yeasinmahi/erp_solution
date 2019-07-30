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
    public partial class AfblSectionSetup : System.Web.UI.Page
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string vMsg = string.Empty;
            if (hdnconfirm.Value == "1")
            {
                if (string.IsNullOrEmpty(txtSectionName.Text))
                    vMsg = "Provide New Section Name";
                else if (string.IsNullOrEmpty(txtCode.Text))
                    vMsg = "Provide Code";
                else if (string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                    vMsg = "Select Line";
                else if (string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                    vMsg = "Select Region";
                else if (string.IsNullOrEmpty(ddlExArea.SelectedValue))
                    vMsg = "Select Area";
                else if (string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                    vMsg = "Select Territory";
                else if (string.IsNullOrEmpty(ddlExPointName.SelectedValue))
                    vMsg = "Select Point.";
                if (string.IsNullOrEmpty(vMsg))
                    SaveAFBLSectionInfo();
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
                    vMsg = "Select Territory";
                else if (string.IsNullOrEmpty(ddlExPointName.SelectedValue))
                    vMsg = "Select Point.";
                else if (string.IsNullOrEmpty(ddlExSectionName.SelectedValue))
                    vMsg = "Select Exist Section.";
                else if (string.IsNullOrEmpty(txtSectionName.Text))
                    vMsg = "Provide New Section Name";
                else if (string.IsNullOrEmpty(txtCode.Text))
                    vMsg = "Provide Code.";

                if (string.IsNullOrEmpty(vMsg))
                    UpdateAFBLSectionInfo();
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + vMsg + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
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
                txtExistCode.Text = string.Empty;

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
                txtExistCode.Text = string.Empty;

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
                txtExistCode.Text = string.Empty;

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
                txtExistCode.Text = string.Empty;
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
                txtExistCode.Text = string.Empty;
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
        protected void ddlExSectionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string codeNo = string.Empty;
            string phoneNO = string.Empty;
            string desc = string.Empty;
            int lineId = 0;
            try
            {
                if (!string.IsNullOrEmpty(ddlExSectionName.SelectedValue))
                {
                    int part = 14;
                    lineId = Convert.ToInt32(ddlExSectionName.SelectedValue.ToString());
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                    {
                        phoneNO = dt.Rows[0].Field<string>(3);
                        desc = dt.Rows[0].Field<string>(4);
                    }
                    part = 13;
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                        codeNo = dt.Rows[0].Field<string>(3);

                    btnCreate.Visible = false;
                }
                else
                    btnCreate.Visible = true;

                txtSectionName.Text = desc;
                txtExistCode.Text = codeNo;
                txtPhoneNo.Text = phoneNO;
                txtCode.Text = codeNo;
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        #endregion

        #region UsrMethod
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
        private void ClearAll()
        {
            txtExistCode.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtCode.Text = string.Empty;

            ddlExRegion.Items.Clear();
            ddlExLineName.Items.Clear();
            ddlExArea.Items.Clear();
            ddlExTerritory.Items.Clear();
            ddlExPointName.Items.Clear();
            ddlExSectionName.Items.Clear();

            BindCombo();
            btnCreate.Visible = true;
        }

        private void SaveAFBLSectionInfo()
        {
            try
            {
                //bool? computerFlag = null;
                int lvlId = 6, part = 1, activeEnroll = 0;
                string officePhone = "0";
                int parentId = Convert.ToInt32(ddlExPointName.SelectedValue.ToString());
                string code = txtCode.Text.Trim();
                string desc = txtSectionName.Text.Trim();

                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.SaveAFBLDistributionInfo(desc, officePhone, parentId, lvlId, part, activeEnroll, null, null, null, code, null);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Create Successfully.');", true);
                ClearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void UpdateAFBLSectionInfo()
        {
            try
            {
                int part = 9;
                string officePhone = "0";
                int lineId = Convert.ToInt32(ddlExSectionName.SelectedValue.ToString());
                string desc = txtSectionName.Text.Trim();
                string code = txtCode.Text.Trim();

                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.UpdateAFBLDistributionInfo(desc, officePhone, lineId, part, null, null, null, null, null, code, null);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Successfully.');", true);
                ClearAll();
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