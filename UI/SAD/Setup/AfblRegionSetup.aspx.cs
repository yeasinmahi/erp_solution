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
    public partial class AfblRegionSetup : System.Web.UI.Page
    {
        #region INITIALIZE

        String errMsg = string.Empty;
        AfblDistributionBll objAfblDistributionBll = new AfblDistributionBll();

        #endregion

        #region Event_Base
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
                if (string.IsNullOrEmpty(txtRegion.Text))
                    vMsg = "Provide New Region Name";
                else if (string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                    vMsg = "Select Line";
                if (string.IsNullOrEmpty(vMsg))
                    SaveAFBLRegionInfo();
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
                    vMsg = "Select Exist Line";
                else if (string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                    vMsg = "Select Exist Region";
                else if (string.IsNullOrEmpty(txtRegion.Text))
                    vMsg = "Provide New Region Name";

                if (string.IsNullOrEmpty(vMsg))
                    UpdateAFBLRegionInfo();
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
                int parentId = 2;
                int part = 8;
                dt = objAfblDistributionBll.GetAFBLGeoList(parentId, part);
                ddlExRegion.DataTextField = "strDiscription";
                ddlExRegion.DataValueField = "intID";
                ddlExRegion.DataSource = dt;
                ddlExRegion.DataBind();
                // To make it the first element at the list, use 0 index : 
                ddlExRegion.Items.Insert(0, new ListItem("Select", string.Empty));
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
            string phoneNo = string.Empty;
            int lineId = 0;
            try
            {
                if (!string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                {
                    int part = 14;
                    lineId = Convert.ToInt32(ddlExRegion.SelectedValue.ToString());
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                        phoneNo = dt.Rows[0].Field<string>(3);

                    btnCreate.Visible = false;
                }
                else
                    btnCreate.Visible = true;
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

        private void SaveAFBLRegionInfo()
        {
            try
            {
                int lvlId = 2, part = 1, activeEnroll = 0;
                string officePhone = "0";
                int parentId = Convert.ToInt32(ddlExRegion.SelectedValue.ToString());
                string desc = txtRegion.Text.Trim();

                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.SaveAFBLGeoInfo(desc, officePhone, parentId, lvlId, part, activeEnroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('New Line Created Successfully.');", true);
                clearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void UpdateAFBLRegionInfo()
        {
            try
            {
                int part = 9;
                string officePhone = "0";
                int lineId = Convert.ToInt32(ddlExRegion.SelectedValue.ToString());
                string desc = txtRegion.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.UpdateAFBLGeoInfo(desc, officePhone, lineId, part);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Update Line Successfully.');", true);
                clearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }


        private void clearAll()
        {
            txtRegion.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            ddlExRegion.Items.Clear();
            ddlExLineName.Items.Clear();
            BindCombo();
            btnCreate.Visible = true;
        }


        #endregion


    }
}