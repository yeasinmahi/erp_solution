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

        int intJobID, intJobStatusID;
        string strJobStatus, JobStatusID, strStatusRemarks, xmlDoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    LoadGrid();
                }
                catch (Exception ex) { throw ex; }
            }
        }

        private void LoadGrid()
        {
            dt = objcr.GetReportForDashboard();
            dgvDashboardReport.DataSource = dt;
            dgvDashboardReport.DataBind();
        }

        protected void dgvDashboardReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvDashboardReport.Rows[rowIndex];
            
            if (e.CommandName == "View")
            {
                intJobID = int.Parse((row.FindControl("lblJID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewJobDetails('" + intJobID.ToString() + "');", true);
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

        protected void ddlJStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlJStatus = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlJStatus.NamingContainer;//get the row where dropdown change
            Label lblJID = (Label)row.FindControl("lblJID");//get label of that row where dropdown change
            Label lblJobCode = (Label)row.FindControl("lblJobCode");//get label of that row where dropdown change
            
            DropDownList ddlJStat = (DropDownList)row.FindControl("ddlJStatus");
            intJobStatusID = int.Parse(ddlJStat.SelectedValue.ToString());
            JobStatusID = intJobStatusID.ToString();
            strJobStatus = ddlJStat.SelectedItem.ToString();
            intJobID = int.Parse(lblJID.Text);
            int intPart = 2;
            strStatusRemarks = "";
            xmlDoc = "";

            if (intJobStatusID == 1)
            {
                if (hdnconfirm.Value == "1")
                {
                    //Final In Insert
                    string message = objcr.UpdateJobStatus(intPart, intJobID, intJobStatusID, strJobStatus, strStatusRemarks, int.Parse(hdnEnroll.Value), xmlDoc);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    hdnconfirm.Value = "0";
                    LoadGrid();
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }
            else if (intJobStatusID == 3)
            {
                if (hdnconfirm.Value == "1")
                {
                    string message = objcr.UpdateJobStatus(intPart, intJobID, intJobStatusID, strJobStatus, strStatusRemarks, int.Parse(hdnEnroll.Value), xmlDoc);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    hdnconfirm.Value = "0";
                    LoadGrid();
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }
            else if (intJobStatusID == 2 || intJobStatusID == 4)
            {
                if (hdnconfirm.Value == "1")
                {
                    string JobCode = lblJobCode.Text;
                    string JobStatus = strJobStatus;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewHoldAndFeedback('" + intJobID.ToString() + "','" + JobCode + "','" + JobStatus + "','" + JobStatusID + "');", true);
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }

        }

















    }
}