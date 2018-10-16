using HR_BLL.CreativeSupport;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.CreativeSupportModule
{
    public partial class DashboardReport : Page
    {
        readonly CreativeSBll _objcr = new CreativeSBll();
        DataTable _dt;

        int _intJobId, _intJobStatusId;
        string _strJobStatus, _jobStatusId, _strStatusRemarks, _xmlDoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            _dt = _objcr.GetReportForDashboard();
            dgvDashboardReport.DataSource = _dt;
            dgvDashboardReport.DataBind();
        }

        protected void dgvDashboardReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvDashboardReport.Rows[rowIndex];
            

            if (e.CommandName == "View")
            {
                string text = (row.FindControl("lblJID") as Label)?.Text;
                if (text != null)
                    _intJobId = int.Parse(text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewJobDetails('" + _intJobId + "');", true);
            }
            else if (e.CommandName == "JobDelete")
            {
                if (hdnEnroll.Value== "43086" || hdnEnroll.Value == "369116")
                {
                    int jobId = 0;
                    var text = (row.FindControl("lblJID") as Label)?.Text;
                    if (text != null)
                    {
                        jobId = int.Parse(text);
                    }
                    if (_objcr.DisableCreativeSupport(jobId))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Successfully deleted your job')", true);
                        LoadGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Can not delete')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "alert('You have not permission to delete this item')", true);
                }
                
                
            }
        }
        protected void dgvDashboardReport_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvDashboardReport.Rows)
            {
                if (gvRow.FindControl("ddlJStatus") is DropDownList ddlJStatus && gvRow.FindControl("hdnStatusID") is HiddenField hdnStatusId)
                { 
                    ddlJStatus.SelectedValue = hdnStatusId.Value;
                }
            }
        }

        protected void ddlJStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlJStatus = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlJStatus.NamingContainer;//get the row where dropdown change
            Label lblJid = (Label)row.FindControl("lblJID");//get label of that row where dropdown change
            Label lblJobCode = (Label)row.FindControl("lblJobCode");//get label of that row where dropdown change
            
            DropDownList ddlJStat = (DropDownList)row.FindControl("ddlJStatus");
            _intJobStatusId = int.Parse(ddlJStat.SelectedValue);
            _jobStatusId = _intJobStatusId.ToString();
            _strJobStatus = ddlJStat.SelectedItem.ToString();
            _intJobId = int.Parse(lblJid.Text);
            int intPart = 2;
            _strStatusRemarks = "";
            _xmlDoc = "";
            
            if (_intJobStatusId == 1)
            {
                if (hdnconfirm.Value == "1")
                {
                    //Final In Insert
                    string message = _objcr.UpdateJobStatus(intPart, _intJobId, _intJobStatusId, _strJobStatus, _strStatusRemarks, int.Parse(hdnEnroll.Value), _xmlDoc);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    hdnconfirm.Value = "0";
                    LoadGrid();
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }
            else if (_intJobStatusId == 3)
            {
                if (hdnconfirm.Value == "1")
                {
                    string message = _objcr.UpdateJobStatus(intPart, _intJobId, _intJobStatusId, _strJobStatus, _strStatusRemarks, int.Parse(hdnEnroll.Value), _xmlDoc);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    hdnconfirm.Value = "0";
                    LoadGrid();
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }
            else if (_intJobStatusId == 2 || _intJobStatusId == 4)
            {
                if (hdnconfirm.Value == "1")
                {
                    string jobCode = lblJobCode.Text;
                    string jobStatus = _strJobStatus;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewHoldAndFeedback('" + _intJobId + "','" + jobCode + "','" + jobStatus + "','" + _jobStatusId + "');", true);                    
                }
                else
                {
                    ddlJStat.SelectedValue = "0";
                }
            }            
        }

















    }
}