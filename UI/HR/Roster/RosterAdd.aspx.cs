using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Roster;
using HR_BLL.TourPlan;
using Utility;

namespace UI.HR.Roster
{
    public partial class RosterAdd : Page
    {
        private readonly TourPlanning _tourPlanning = new TourPlanning();
        private readonly RosterBll _bll = new RosterBll();
        private int _enroll=369116;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadSequenceDropDown();
                LoadUnitDropDown(_enroll);
                ddlUnit_OnSelectedIndexChanged(null, null);
                ddlJobStation_OnSelectedIndexChanged(null,null);
                ddlTeam_OnSelectedIndexChanged(null, null);
                ddlShift_OnSelectedIndexChanged(null,null);
            }
        }

        public void LoadUnitDropDown(int enrol)
        {
            DataTable dt = _tourPlanning.GetUnitName(enrol);
            Common.BindDropDown(ddlUnit, dt, "intUnitID", "strUnit");
        }
        public void LoadJobStationDropDown(int unitId)
        {
            DataTable dt = _tourPlanning.GetJobStation(unitId);
            Common.BindDropDown(ddlJobStation, dt, "intEmployeeJobStationId", "strJobStationName");
        }
        public void LoadTeamDropDown(int jobStationId)
        {
            DataTable dt = _bll.GetTeamByJobstation(jobStationId);
            Common.BindDropDown(ddlTeam, dt, "intTeamId", "strTeamName");
        }
        public void LoadShiftDropDown(int teamId)
        {
            DataTable dt = _bll.GetShiftByShiftId(teamId);
            Common.BindDropDown(ddlShift, dt, "intShiftId", "strShiftName");
        }
        public void LoadShiftValue(int shiftId)
        {
            DataTable dt = _bll.GetShiftByShiftId(shiftId);
            if (dt.Rows.Count > 0)
            {
                txtShiftStart.Text = dt.Rows[0]["tmShiftStart"].ToString();
                txtShiftEnd.Text = dt.Rows[0]["tmShiftEnd"].ToString();
                txtPunchLastTime.Text = dt.Rows[0]["tmLastPunch"].ToString();
                txtDutyTime.Text = dt.Rows[0]["tmDuty"].ToString();
            }
        }
        public void LoadSequenceDropDown()
        {
            DataTable dt = _bll.GetSequence();
            Common.BindDropDown(ddlSequence, dt, "intSequenceId", "strSequenceName");
        }

        protected void GridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["obj"] != null)
            {
                List<object> objects = (List<object>)Session["obj"];
                objects.RemoveAt(e.RowIndex);
                if (objects.Count > 0)
                {
                    string xmlString = XmlParser.GetXml("RosterEntry", "items", objects, out string message);
                    LoadGridwithXml(xmlString, GridView);
                }
                else
                {
                    GridViewUtil.UnLoadGridView(GridView);
                }
            }
            else
            {
                GridViewUtil.UnLoadGridView(GridView);
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            List<object> objects = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            
            if (objects.Count > 0)
            {
                string xmlString = XmlParser.GetXml("RosterEntry", "items", objects, out string message);
                message = _bll.RosterEntry(1, xmlString, _enroll);

                if (message.Contains("Sucessfully"))
                {
                    Session["obj"] = null;
                    GridViewUtil.UnLoadGridView(GridView);
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                        "ShowNotification(\"" + message + "\",'Roster','success')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                        "ShowNotification(\"" + message + "\",'Roster','error')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('No Data Found to Insert','Roster','warning')", true);
            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string empEnroll = txtEnroll.Text;
            string date = txtDutyDate.Text;
            int shiftId = Common.GetDdlSelectedValue(ddlShift);
            int jobstationId = Common.GetDdlSelectedValue(ddlJobStation);
            int sequenceId = Common.GetDdlSelectedValue(ddlSequence);
            if (jobstationId < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('Select Jobstation first','Roster','warning')", true);
                return;
            }
            if (shiftId<1)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('Select Shift first','Roster','warning')", true);
                return;
            }
            dynamic obj = new
            {
                empEnroll,
                date,
                shiftId,
                jobstationId,
                sequenceId
            };
            List<object> objects = new List<object>();
            if (Session["obj"] != null)
            {
                objects = (List<object>)Session["obj"];
            }
            foreach (GridViewRow row in GridView.Rows)
            {
                if (((Label)row.FindControl("lblEmpEnroll")).Text.Contains(empEnroll) && ((Label)row.FindControl("lblDate")).Text.Contains(date))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                        "ShowNotification('Can not add same enroll " + empEnroll + " and date " + date + " dublicate','Roster','error')", true);
                    return;
                }
                //row.Cells["chat1"].Style.ForeColor = Color.CadetBlue;
            }
            objects.Add(obj);
            Session["obj"] = objects;

            string xmlString = XmlParser.GetXml("RosterEntry", "items", objects, out string message);

            LoadGridwithXml(xmlString, GridView);

        }
        private void LoadGridwithXml(string xmlString, GridView gridView)
        {
            if (!GridViewUtil.LoadGridwithXml(xmlString, gridView, out string message))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "ShowNotification(\"" + message + "\",'Roster','error')", true);
            }
        }
        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationDropDown(Common.GetDdlSelectedValue(ddlUnit));
            ddlJobStation_OnSelectedIndexChanged(null, null);
           
        }

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeamDropDown(Common.GetDdlSelectedValue(ddlJobStation));
            ddlTeam_OnSelectedIndexChanged(null, null);
            
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void ddlTeam_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShiftDropDown(Common.GetDdlSelectedValue(ddlTeam));
            ddlShift_OnSelectedIndexChanged(null, null);
        }

        protected void ddlSequenceId_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlShift_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShiftValue(Common.GetDdlSelectedValue(ddlShift));
        }
    }
}