using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.TourPlan;

namespace UI.HR.Overtime
{
    public partial class OvertimeEntryNew : Page
    {
        private readonly TourPlanning _bll = new TourPlanning();
        private int enroll = 369116;
        protected void Page_Load(object sender, EventArgs e)
        {
            //enroll = Int32.Parse(Session[SessionParams.USER_ID].ToString());
            
            if (!IsPostBack)
            {
                LoadPurpose();
                LoadUnitDropDown(enroll);
                LoadJobStationDropDown(GetUnitId());
            }
        }

        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationDropDown(GetUnitId());
        }

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void OvertimeEntryGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void btnActive_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            
        }

        private void LoadPurpose()
        {
            ddlPurpose.DataSource = _bll.getOvertimePurpouse();
            ddlPurpose.DataValueField = "intID";
            ddlPurpose.DataTextField = "strPurpouse";
            ddlPurpose.DataBind();
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = _bll.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = _bll.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }
        public int GetUnitId()
        {
            return Convert.ToInt32(ddlUnit.SelectedItem.Value);
            //return int.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }
    }
}