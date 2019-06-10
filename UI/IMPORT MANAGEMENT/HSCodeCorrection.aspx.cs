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

            }
            catch (Exception ex)
            {
                string sms = "Show Button : " + ex.ToString();
                Toaster(sms, Utility.Common.TosterType.Error);
            }
        }

        protected void btnHSCodeUpdate_Click(object sender, EventArgs e)
        {
            try
            {

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
            try
            {
                //if(ddlUnit.SelectedValue)
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion




    }
}