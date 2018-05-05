using HR_BLL.CreativeSupport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.CreativeSupportModule
{
    public partial class DashboardReport : System.Web.UI.Page
    {
        CreativeS_BLL objcr = new CreativeS_BLL();
        DataTable dt;

        int intJobID;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    dt = objcr.GetReportForDashboard();
                    dgvDashboardReport.DataSource = dt;
                    dgvDashboardReport.DataBind();
                }
                catch (Exception ex) { throw ex; }
            }
        }

        protected void dgvDashboardReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvDashboardReport.Rows[rowIndex];
            
            if (e.CommandName == "View")
            {
                intJobID = int.Parse((row.FindControl("lblJID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewCustomerView('" + 0 + "');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewApproveActionPopup('" + intJobID.ToString() + "');", true);
            }
        }
        protected void dgvDashboardReport_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvDashboardReport.Rows)
            {
                DropDownList ddlJStatus = gvRow.FindControl("ddlJStatus") as DropDownList;
                HiddenField hdnStatusID = gvRow.FindControl("hdnStatusID") as HiddenField;

                if (ddlJStatus != null && hdnStatusID != null)
                {
                    ddlJStatus.SelectedValue = hdnStatusID.Value;
                }
            }
        }



















    }
}