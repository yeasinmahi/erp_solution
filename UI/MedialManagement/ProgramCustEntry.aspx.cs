using Purchase_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.MedialManagement
{
    public partial class ProgramCustEntry : BasePage
    {
        DataTable dt; Media bll = new Media();
        int intProgTypeID, intSupplierMasterID;
        string strNewSupplierName, strNewSupplierShortName;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                LoadDropDown();
            }
            catch { }
        }

        private void LoadDropDown()
        {
            try
            {
                dt = new DataTable();
                dt = bll.GetProgramType();
                ddlProgramType.DataSource = dt;
                ddlProgramType.DataTextField = "strProgramType";
                ddlProgramType.DataValueField = "intID";
                ddlProgramType.DataBind();

                dt = new DataTable();
                dt = bll.GetMasterSupplier();
                ddlBridgeSupplier.DataSource = dt;
                ddlBridgeSupplier.DataTextField = "strSuppMasterName";
                ddlBridgeSupplier.DataValueField = "intSuppMasterID";
                ddlBridgeSupplier.DataBind();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intProgTypeID = int.Parse(ddlProgramType.SelectedValue.ToString());
                strNewSupplierName = txtSupplier.Text;
                strNewSupplierShortName = txtShortName.Text;
                intSupplierMasterID = int.Parse(ddlBridgeSupplier.SelectedValue.ToString());
                bll.InsertSupplier(intProgTypeID, strNewSupplierName, strNewSupplierShortName, intSupplierMasterID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('New Suplier Create & Bridge Completed.');", true);
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please check inputed data.');", true); }
        }
    }
}