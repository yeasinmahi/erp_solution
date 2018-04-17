using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HR_BLL.TeamBuild;
using UI.ClassFiles;


namespace UI.HR.TeamBuild
{
    public partial class TeamShiftOnOff : BasePage
    {

        /*================Information==================
        Author:	  <Md. Golam Kibria Konock>
        Create date: <06-09-2012>
        Description: <Factory Shift and Team Information Update, Delete By TeamId and ShiftId>
        =============================================*/

        #region============Global Variables Are Here===================
        DataTable tblTeamInfo = new DataTable(); TeamAndShiftInformation objTeamInfo = new TeamAndShiftInformation();
        int intChkOnOff; string msgStatus = ""; int chkRosterEnable; int ysnActive;//int softwareLoginUserID;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); ddlTeam.DataBind(); ddlTeam_SelectedIndexChanged(sender, e);
            }

        }
        protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTeam.SelectedValue != "")
            {
                tblTeamInfo = objTeamInfo.GetTeamInformationByTeamId(int.Parse(ddlTeam.SelectedValue.ToString()));
                if (tblTeamInfo.Rows.Count > 0)
                {
                    txtUnit.Text = tblTeamInfo.Rows[0]["strUnit"].ToString(); txtStation.Text = tblTeamInfo.Rows[0]["strJobStationName"].ToString();
                    txtStatus.Text = tblTeamInfo.Rows[0]["ysnActive"].ToString();
                    if (txtStatus.Text.ToUpper() == "TRUE") { chkOnOff.Checked = true; hdnTeamStatus.Value = "1"; }
                    else { chkOnOff.Checked = false; hdnTeamStatus.Value = "0"; }
                    dgvShiftInfo.DataBind();
                }
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry, There is no team information.');", true); }
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (ddlTeam.SelectedValue != "")
            {
                if (chkOnOff.Checked == true) { intChkOnOff = 1; }
                else { intChkOnOff = 0; }
                msgStatus = objTeamInfo.UpdateTeamInformationByTeamId(int.Parse(ddlTeam.SelectedValue.ToString()), intChkOnOff);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                hdnTeamStatus.Value = intChkOnOff.ToString();
                ddlTeam.DataBind(); ddlTeam_SelectedIndexChanged(sender, e);
                dgvShiftInfo.DataBind();
            }

        }

        protected void dgvShiftInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label lblShift = (Label)dgvShiftInfo.Rows[e.RowIndex].Cells[0].FindControl("lblSft");
                int shiftId = int.Parse(lblShift.Text);
                msgStatus = objTeamInfo.DeleteTeamShiftInformationByShiftId(0, shiftId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                dgvShiftInfo.DataBind();
            }
            catch (Exception ex)
            { throw ex; }
        }
        protected void dgvShiftInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvShiftInfo.EditIndex = e.NewEditIndex;
            dgvShiftInfo.DataBind();
        }
        protected void dgvShiftInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblShift = (Label)dgvShiftInfo.Rows[e.RowIndex].Cells[0].FindControl("intShiftId");
                int intShiftId = int.Parse(lblShift.Text);
                string strShiftName = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[1].FindControl("txtShiftName")).Text;
                string startTime = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[2].FindControl("txtShiftStart")).Text;
                string endTime = ((TextBox)dgvShiftInfo.Rows[e.RowIndex].Cells[3].FindControl("txtShiftEnd")).Text;
                CheckBox chk = (CheckBox)dgvShiftInfo.Rows[e.RowIndex].Cells[4].FindControl("chkRosterEnable");
                if (chk.Checked == true) { chkRosterEnable = 1; }
                else { chkRosterEnable = 0; }
                CheckBox chkShift = (CheckBox)dgvShiftInfo.Rows[e.RowIndex].Cells[5].FindControl("chkActive");
                if (chkShift.Checked == true) { ysnActive = 1; }
                else { ysnActive = 0; }

                msgStatus = objTeamInfo.UpdateTeamShiftInformationByShiftId(strShiftName, startTime, endTime, chkRosterEnable, ysnActive, intShiftId);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                dgvShiftInfo.DataBind();
            }
            catch (Exception ex)
            { throw ex; }
        }
        protected void dgvShiftInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvShiftInfo.EditIndex = -1;
            dgvShiftInfo.DataBind();
        }



    }
}