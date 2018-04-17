using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.OfficialMovement;
using UI.ClassFiles;

namespace UI.HR.OfficialMovement
{
    public partial class ApproveOfficialMovementApplication : BasePage
    {
        #region Declare Object
        HR_BLL.OfficialMovement.OfficialMovement objOfficialMovement = new HR_BLL.OfficialMovement.OfficialMovement();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  hdnUserID.Value = Session["sesUserId"].ToString();
                hdnUserID.Value = Session[SessionParams.USER_ID].ToString();
            }
        }
        protected void btnApprove_OnCommand(object sender, CommandEventArgs e)
        {
            //Summary    :   This Event will be fired when processes button click 
            //Created    :   Md. Yeasir Arafat / FEB-16-2012
            //Modified   :   
            //Parameters :

            if (e.CommandName.Equals("Approve"))
            {
                int intApplicationId = Convert.ToInt32(e.CommandArgument);
                string approveStatus = objOfficialMovement.SprApproveOfficialMovementApplication(intApplicationId, int.Parse(hdnUserID.Value.ToString()), true, false);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + approveStatus + "');", true);
                dgvApproveOfficialMovementApplication.DataBind();
            }
        }
    }
}