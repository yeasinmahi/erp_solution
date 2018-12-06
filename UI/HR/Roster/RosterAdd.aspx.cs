using System;
using System.Web.UI.WebControls;
using HR_BLL.Roster;
using HR_BLL.TourPlan;
using UI.ClassFiles;

namespace UI.HR.Roster
{
    public partial class RosterAdd : System.Web.UI.Page
    {
        private readonly TourPlanning _tourPlanning = new TourPlanning();
        private readonly RosterBll _bll = new RosterBll();
        private int _enroll;
        protected void Page_Load(object sender, EventArgs e)
        {
            _enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnitDropDown(_enroll);
                
                ddlUnit_OnSelectedIndexChanged(null, null);
            }
        }

        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = _tourPlanning.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = _tourPlanning.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        //public void LoadJobStationDropDown(int unitId)
        //{
        //    ddlJobStation.DataSource = _bll.GetTeamByJobstation(jobStationId);
        //    ddlJobStation.DataValueField = "intEmployeeJobStationId";
        //    ddlJobStation.DataTextField = "strJobStationName";
        //    ddlJobStation.DataBind();
        //}
        public int GetUnitId()
        {
            return Convert.ToInt32(ddlUnit.SelectedItem.Value);
            //return int.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }

        protected void GridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationDropDown(GetUnitId());
        }

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void ddlTeam_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlSequenceId_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
    }
}