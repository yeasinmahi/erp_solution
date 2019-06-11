using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.IMPORT_MANAGEMENT
{
    public partial class HSCodeCorrection : BasePage
    {
        #region INIT
        private InventoryTransfer_BLL _BLL = new InventoryTransfer_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intWh;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
            }
        }
        #endregion

        #region Event
        protected void btnShowItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowItemDetails();
            }
            catch (Exception ex)
            {
                string sms = "Show Button : " + ex.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }

        protected void btnHSCodeUpdate_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if(hfHSCode.Value != txtHSCode.Text)
                {
                    if (hdnconfirm.Value == "1")
                    {
                        result = UpdateHSCode();
                        if (result)
                        {
                            Toaster("HS Code Update Successfully!", Utility.Common.TosterType.Success);
                            Clear();
                        }
                        else
                        {
                            Toaster("HS Code Update Failed!", Utility.Common.TosterType.Success);
                        }
                    }
                }
                else
                {
                    Toaster("You Don't Change HS Code for "+txtItemName.Text+" This Item Till Now.", Utility.Common.TosterType.Warning);
                }
                
            }
            catch (Exception ex)
            {
                string sms = "Update Button : " + ex.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }
        #endregion

        #region Method
        private void FillDropDown()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = _BLL.GetAllUnit();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, new ListItem("---Select Unit---", "-1"));
            }
            catch (Exception ex)
            {
            }
        }
        private void ShowItemDetails()
        {
            int UnitId = 0;
            int ItemId = 0;
            DataTable dt = new DataTable();
            try
            {
                if (Convert.ToInt32(ddlUnit.SelectedValue) > 0)
                {
                    UnitId = Convert.ToInt32(ddlUnit.SelectedValue);
                }
                else
                {
                    ddlUnit.Focus();
                    Toaster("Please Select Unit First", Utility.Common.TosterType.Warning);
                    return;
                }
                if (!string.IsNullOrEmpty(txtItemId.Text))
                {
                    ItemId = Convert.ToInt32(txtItemId.Text);
                }
                else
                {
                    txtItemId.Focus();
                    Toaster("Please Entered Item Id", Utility.Common.TosterType.Warning);
                    return;
                }
                hfUnitId.Value = UnitId.ToString();
                hfItemId.Value = ItemId.ToString();
                dt = _BLL.GetItemDetails(ItemId, UnitId);
                if(dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        txtItemName.Text = dt.Rows[0]["strItemName"].ToString(); txtItemName.Enabled = false;
                        txtItemDescription.Text = dt.Rows[0]["strItemFullName"].ToString(); txtItemDescription.Enabled = false;
                        txtItemUoM.Text = dt.Rows[0]["strUoM"].ToString(); txtItemUoM.Enabled = false;
                        txtHSCode.Text = dt.Rows[0]["strHSCode"].ToString();
                        hfHSCode.Value = dt.Rows[0]["strHSCode"].ToString();
                    }
                    else
                    {
                        Toaster("Data Not Found! ", Utility.Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("Data Not Found! ", Utility.Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        private bool UpdateHSCode()
        {
            int ItemId = 0;
            int UnitId = 0;
            string HsCode = string.Empty;
            bool result = false;
            try
            {
                ItemId = !string.IsNullOrEmpty(hfItemId.Value) ? Convert.ToInt32(hfItemId.Value) : 0;
                UnitId = !string.IsNullOrEmpty(hfUnitId.Value) ? Convert.ToInt32(hfUnitId.Value) : 0;
                HsCode = txtHSCode.Text;
                if (ItemId > 0 && UnitId > 0)
                {
                    result = _BLL.UpdateHSCode(HsCode, ItemId, UnitId);
                }
                else
                {
                    Toaster("Item ID or Unit ID Not Found!", Utility.Common.TosterType.Warning);
                }
                
            }
            catch (Exception)
            {
            }
            return result;
        }
        private void Clear()
        {
            ddlUnit.SelectedValue = "-1";
            txtItemId.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtItemDescription.Text = string.Empty;
            txtItemUoM.Text = string.Empty;
            txtHSCode.Text = string.Empty;
        }
        #endregion
        
    }
}