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
    public partial class AfblPointSetup : System.Web.UI.Page
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
                if (string.IsNullOrEmpty(txtDisPointName.Text))
                    vMsg = "Provide New Point Name";
                else if (string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                    vMsg = "Select Line";
                else if (string.IsNullOrEmpty(ddlExRegion.SelectedValue))
                    vMsg = "Select Region";
                else if (string.IsNullOrEmpty(ddlExArea.SelectedValue))
                    vMsg = "Select Area";
                else if (string.IsNullOrEmpty(ddlExTerritory.SelectedValue))
                    vMsg = "Select Territory";
                else if (string.IsNullOrEmpty(ddlCust.SelectedValue))
                    vMsg = "Provide New Customer.";
                if (string.IsNullOrEmpty(vMsg))
                    SaveAFBLPointInfo();
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
                    vMsg = "Select Exist Point.";
                else if (string.IsNullOrEmpty(txtDisPointName.Text))
                    vMsg = "Provide New Point Name";
                else if (string.IsNullOrEmpty(ddlCust.SelectedValue))
                    vMsg = "Provide New Customer.";

                if (string.IsNullOrEmpty(vMsg))
                    UpdateAFBLPointInfo();
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
                txtExistCust.Text = string.Empty;

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
                txtExistCust.Text = string.Empty;

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
                txtExistCust.Text = string.Empty;

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
                txtExistCust.Text = string.Empty;
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
            string phoneNo = string.Empty;
            string custName = string.Empty;
            int custId = 0;
            string desc = string.Empty;

            int lineId = 0;
            try
            {
                if (!string.IsNullOrEmpty(ddlExPointName.SelectedValue))
                {
                    int part = 10;
                    lineId = Convert.ToInt32(ddlExPointName.SelectedValue.ToString());
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                    {
                        custName = dt.Rows[0].Field<string>(4);
                        custId = dt.Rows[0].Field<int>(5);
                    }

                    part = 14;
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

                txtDisPointName.Text = desc;
                txtExistCust.Text = custName;
                txtPhoneNo.Text = phoneNo;

                ddlCust.SelectedValue = custId.ToString();
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

                part = 2;
                dt = objAfblDistributionBll.GetAFBLCustomerInfo(part);
                ddlCust.DataTextField = "Column1";
                ddlCust.DataValueField = "intCusID";
                ddlCust.DataSource = dt;
                ddlCust.DataBind();
                // To make it the first element at the list, use 0 index : 
                ddlCust.Items.Insert(0, new ListItem("Select", string.Empty));
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void ClearAll()
        {
            txtExistCust.Text = string.Empty;
            txtDisPointName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            ddlExRegion.Items.Clear();
            ddlExLineName.Items.Clear();
            ddlExArea.Items.Clear();
            ddlExTerritory.Items.Clear();
            ddlExPointName.Items.Clear();
            ddlCust.Items.Clear();
            BindCombo();
            ddlComputer.SelectedValue = "False";
            btnCreate.Visible = true;
        }

        private void SaveAFBLPointInfo()
        {
            try
            {
                bool? computerFlag = null;
                int lvlId = 5, part = 1, activeEnroll = 0;
                string officePhone = "0";
                int parentId = Convert.ToInt32(ddlExTerritory.SelectedValue.ToString());
                int custID = Convert.ToInt32(ddlCust.SelectedValue.ToString());

                string desc = txtDisPointName.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                if (!string.IsNullOrEmpty(ddlComputer.SelectedValue))
                    computerFlag = Convert.ToBoolean(ddlComputer.SelectedValue.ToString());

                objAfblDistributionBll.SaveAFBLDistributionInfo(desc, officePhone, parentId, lvlId, part, activeEnroll, custID, null, null, null, computerFlag);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Create Successfully.');", true);
                ClearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void UpdateAFBLPointInfo()
        {
            try
            {
                bool? computerFlag = null;
                int part = 11;
                string officePhone = "0";
                int lineId = Convert.ToInt32(ddlExPointName.SelectedValue.ToString());
                int custID = Convert.ToInt32(ddlCust.SelectedValue.ToString());

                string desc = txtDisPointName.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();
                if (!string.IsNullOrEmpty(ddlComputer.SelectedValue))
                    computerFlag = Convert.ToBoolean(ddlComputer.SelectedValue.ToString());

                objAfblDistributionBll.UpdateAFBLDistributionInfo(desc, officePhone, lineId, part, null, null, null, custID, null, null, computerFlag);
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