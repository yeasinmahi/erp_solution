using BLL.Accounts.MDSlip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.MDSlip
{
    public partial class MDSlipCustomization : System.Web.UI.Page
    {
        #region INIT
        MDSlipC objMDSlipC = new MDSlipC();
        private int Enroll, UnitID, MDSlipCustomGroupTypeID, intAccountId, intChildID;
        private string strAccountCode, strAccoutName;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAccountName.Visible = false;
                FillDropdown();
            }
        }
        #endregion

        #region Event
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                HiddenField hfAccountID = row.FindControl("hfAccountID") as HiddenField;
                intAccountId = Convert.ToInt32(hfAccountID.Value);
                if (intAccountId == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Chart of Account Selected.');", true);
                    return;
                }
                int AccCount = objMDSlipC.CheckMDSlipAccount(intAccountId);
                if (AccCount == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account is not added.');", true);
                    return;
                }
                result = objMDSlipC.DeleteMDSlipAccount(intAccountId);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account Deleted successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account Deletion Failed.');", true);
                }

            }
            catch (Exception ex)
            {
                string sms = "Remove Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnShowChild_Click(object sender, EventArgs e)
        {
            DataTable dtChilds = new DataTable();
            try
            {
                dgvMDSlipData.DataSource = null;
                dgvMDSlipData.DataBind();
                lblAccountName.Visible = true;

                int unitID = int.Parse(ddlUnit.SelectedValue);
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                HiddenField hfAccountID = row.FindControl("hfAccountID") as HiddenField;
                HiddenField hfParentID = row.FindControl("hfParentID") as HiddenField;
                Label lblgvAccountName = row.FindControl("lblgvAccountName") as Label;
                Label lblgvCode = row.FindControl("lblgvCode") as Label;

                int accountID = int.Parse(hfAccountID.Value);
                int parentId = int.Parse(hfParentID.Value);
                dtChilds = objMDSlipC.GetChieldMDSlipCustomData(unitID, accountID);
                if (dtChilds != null && dtChilds.Rows.Count > 0)
                {
                    lblAccountName.Text = "[" + lblgvCode.Text.ToString() + "] " + lblgvAccountName.Text.ToString();
                    dgvMDSlipData.DataSource = dtChilds;
                    dgvMDSlipData.DataBind();
                }
                else
                {
                    lblAccountName.Text = "There is No child under this Account Head";
                }


            }
            catch (Exception ex)
            {
                string sms = "Show Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }

        protected void ddlGroupingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCustomGroupName = new DataTable();
            try
            {
                if (ddlUnit.SelectedValue != "-1")
                {
                    UnitID = Convert.ToInt32(ddlUnit.SelectedValue);
                }
                else
                {
                    ddlUnit.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Unit');", true);
                    return;
                }
                if (ddlGroupingType.SelectedValue != "-1")
                {
                    MDSlipCustomGroupTypeID = Convert.ToInt32(ddlGroupingType.SelectedValue);
                }
                else
                {
                    ddlGroupingType.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select MD Slip Custom Group Type');", true);
                    return;
                }
                dtCustomGroupName = objMDSlipC.GetMDSlipCustomName(UnitID, MDSlipCustomGroupTypeID);
                if (dtCustomGroupName != null && dtCustomGroupName.Rows.Count > 0)
                {
                    ddlCustomName.DataSource = dtCustomGroupName;
                    ddlCustomName.DataTextField = "strCustomGroupName";
                    ddlCustomName.DataValueField = "intMDSlipCustomGroup";
                    ddlCustomName.DataBind();
                }
                ddlCustomName.Items.Insert(0, new ListItem("--- Select Custom Name ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Grouping Type : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtMDSD = new DataTable();
            try
            {
                lblAccountName.Text = string.Empty;
                lblAccountName.Visible = false;

                dgvMDSlipData.DataSource = null;
                dgvMDSlipData.DataBind();

                if (ddlUnit.SelectedValue != "-1")
                {
                    UnitID = Convert.ToInt32(ddlUnit.SelectedValue);
                }
                else
                {
                    ddlUnit.Focus();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Select Unit');", true);
                    return;
                }

                dtMDSD = objMDSlipC.GetMDSlipCustomData(UnitID);
                dgvMDSlipData.DataSource = dtMDSD;
                dgvMDSlipData.DataBind();
            }
            catch (Exception ex)
            {
                string sms = "MD Slip Data : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int unitID = int.Parse(ddlUnit.SelectedValue);
                int groupID = int.Parse(ddlCustomName.SelectedValue);
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                HiddenField hfAccountID = row.FindControl("hfAccountID") as HiddenField;
                Label lblgvAccountName = row.FindControl("lblgvAccountName") as Label;
                Label lblgvCode = row.FindControl("lblgvCode") as Label;
                Label lblgvstrChilds = row.FindControl("lblgvstrChilds") as Label;
                intAccountId = Convert.ToInt32(hfAccountID.Value);
                strAccoutName = lblgvAccountName.Text.ToString();
                strAccountCode = lblgvCode.Text.ToString();
                intChildID = Convert.ToInt32(lblgvstrChilds.Text);

                if (Validation(intAccountId, intChildID) == true)
                {
                    int AccCount = objMDSlipC.CheckMDSlipAccount(intAccountId);
                    if (AccCount > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account is already added.');", true);
                    }
                    else
                    {
                        result = objMDSlipC.InsertMDSlipCustomData(unitID, groupID, intAccountId, strAccountCode, strAccoutName, Enroll);
                        if (result == true)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account Added for MDSlipCustomization successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Account Added Failed for MDSlipCustomization.');", true);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                string sms = "Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        #endregion

        #region Method
        private void FillDropdown()
        {
            DataTable dtUnit = new DataTable();
            DataTable dtMDSCT = new DataTable();
            try
            {
                Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dtUnit = objMDSlipC.GetUnit(Enroll);
                if (dtUnit != null && dtUnit.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dtUnit;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();
                }
                ddlUnit.Items.Insert(0, new ListItem("--- Select An Unit ---", "-1"));

                dtMDSCT = objMDSlipC.GetMDSlipCGType();

                if (dtMDSCT != null && dtMDSCT.Rows.Count > 0)
                {
                    ddlGroupingType.DataSource = dtMDSCT;
                    ddlGroupingType.DataTextField = "strGroupTypeName";
                    ddlGroupingType.DataValueField = "intMDSlipGroupType";
                    ddlGroupingType.DataBind();
                }

                ddlGroupingType.Items.Insert(0, new ListItem("--- Select Group Type ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private bool Validation(int intAccountId, int intChildID)
        {
            if (ddlGroupingType.SelectedValue == "-1")
            {
                ddlGroupingType.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a Group Type.');", true);
                return false;
            }
            if (ddlCustomName.SelectedValue == "-1")
            {
                ddlCustomName.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select a Group name.');", true);
                return false;
            }
            if (intAccountId == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Chart of Account Selected.');", true);
                return false;
            }
            if (intChildID > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Control Head cannot be added. Only sub-ledgers can be added.');", true);
                return false;
            }

            return true;
        }
        #endregion





    }
}