using SAD_BLL.Global;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Setup
{
    public partial class DistributionRegionSetup : BasePage
    {

        #region Declaration

        InternalTransportBLL obj = new InternalTransportBLL();
        SetupBLL objSetupBill = new SetupBLL();
        DataTable dt;
        string msgErr = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                    dt = obj.GetAllUnit();
                    ddlUserUnit.DataTextField = "strUnit";
                    ddlUserUnit.DataValueField = "intUnitID";
                    ddlUserUnit.DataSource = dt;
                    ddlUserUnit.DataBind();
                }
                catch (Exception ex)
                {
                    msgErr = ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
                }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {                
                saveRegion();
            }
        }

        private void saveRegion()
        {
            Int32 unitID, regionEnroll, userID;
            string department, mobileNo, region;

            try
            {
                unitID = Convert.ToInt16(ddlUserUnit.SelectedValue.ToString());
                department = ddlUserUnit.SelectedItem.ToString();
                regionEnroll = Convert.ToInt32(txtEnroll.Text.ToString());
                mobileNo = txtMobileNumber.Text.ToString();
                region = txtRegion.Text.ToString();
                userID = Convert.ToInt32(hdnEnroll.Value);

                objSetupBill.saveRegion(unitID, region, regionEnroll, mobileNo, department, userID);
                clearAll();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Saved Successfully');", true);
            }
            catch (Exception ex)
            {
                msgErr = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgErr + "');", true);
            }
        }

        private void clearAll()
        {
            txtEnroll.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtRegion.Text = string.Empty;
        }
    }
}