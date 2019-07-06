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
    public partial class AfblLineSetup : System.Web.UI.Page
    {

        #region INITIALIZE

        String errMsg = string.Empty;
        AfblDistributionBll objAfblDistributionBll = new AfblDistributionBll();

        #endregion

        #region Event_Generated

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
                if (string.IsNullOrEmpty(txtLineName.Text))
                    vMsg = "Provide New Line Name";

                if (string.IsNullOrEmpty(vMsg))
                    SaveAFBLLineInfo();
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
                else if (string.IsNullOrEmpty(txtLineName.Text))
                    vMsg = "Provide New Line Name";

                if (string.IsNullOrEmpty(vMsg))
                    UpdateAFBLLineInfo();
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + vMsg + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        #endregion

        #region userMethod
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

        protected void ddlExLineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string phoneNo = string.Empty;
            int lineId = 0;
            try
            {
                if (!string.IsNullOrEmpty(ddlExLineName.SelectedValue))
                {
                    int part = 14;
                    lineId = Convert.ToInt32(ddlExLineName.SelectedValue.ToString());
                    dt = objAfblDistributionBll.GetAFBLExistGeoInfo(lineId, part);
                    if (dt.Rows.Count > 0)
                        phoneNo = dt.Rows[0].Field<string>(3);

                    btnCreate.Visible = false;
                }
                txtPhoneNo.Text = phoneNo;
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void SaveAFBLLineInfo()
        {
            try
            {
                string officePhone = "0";
                string newLine = txtLineName.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.SaveAFBLLineInfo(newLine, officePhone);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('New Line Created Successfully.');", true);
                clearAll();
            }
            catch (Exception Ex)
            {
                errMsg = Ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + errMsg + "');", true);
            }
        }

        private void UpdateAFBLLineInfo()
        {
            try
            {
                string officePhone = "0";
                int lineId = Convert.ToInt32(ddlExLineName.SelectedValue.ToString());
                string newLine = txtLineName.Text.Trim();
                if (!string.IsNullOrEmpty(txtPhoneNo.Text))
                    officePhone = txtPhoneNo.Text.Trim();

                objAfblDistributionBll.UpdateAFBLLineInfo(newLine, officePhone, lineId);

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
            txtLineName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            ddlExLineName.Items.Clear();
            BindCombo();
            btnCreate.Visible = true;
        }

        #endregion

        
    }
}