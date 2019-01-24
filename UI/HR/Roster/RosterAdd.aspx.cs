using HR_BLL.Roster;
using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;
using System.Web.Services;
using System.Web.Script.Services;
using Purchase_BLL.Asset;
using System.Web;

namespace UI.HR.Roster
{
    public partial class RosterAdd : Page
    {
        private readonly TourPlanning _tourPlanning = new TourPlanning();
        private readonly RosterBll _bll = new RosterBll();
        AssetInOut objCheck = new AssetInOut();
        DataTable dt = new DataTable();
        private int _enroll;
        int  Anumber; string assetName = "";
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        protected void Page_Load(object sender, EventArgs e)
        {
            _enroll = int.Parse(Session[SessionParams.USER_ID].ToString());

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadSequenceDropDown();
                LoadUnitDropDown(_enroll);
                ddlUnit_OnSelectedIndexChanged(null, null);
                ddlJobStation_OnSelectedIndexChanged(null, null);
                ddlTeam_OnSelectedIndexChanged(null, null);
                ddlShift_OnSelectedIndexChanged(null, null);
            }
        }

        public void LoadUnitDropDown(int enrol)
        {
            DataTable dt = _tourPlanning.GetUnitName(enrol);
            Common.LoadDropDown(ddlUnit, dt, "intUnitID", "strUnit");
        }


        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetAutoSearch(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            
           
            return objAutoSearch_BLL.GetAssetItem(Active, prefixText);
           
        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    arrayKey = TxtAsset.Text.Split(delimiterChars);
                    string assetId = ""; string assetName = ""; string assetType = ""; int assetAutoId = 0;
                    if (arrayKey.Length > 0)
                    { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); Anumber = int.Parse((arrayKey[3].ToString())); assetType = arrayKey[5].ToString(); }

                
                dt = objCheck.ShowassetData(Anumber.ToString());
                if (dt.Rows.Count > 0)
                {
                    txtAssetLocation.Text = dt.Rows[0]["strNameOfAsset"].ToString()+" Unit:" + dt.Rows[0]["strUnit"].ToString()+" JobStation:"+ dt.Rows[0]["strJobStationName"].ToString();
                    
                    //TxtNarration.Text = dt.Rows[0]["Detalis"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
            catch { }
        }

        public void LoadJobStationDropDown(int unitId, int enroll)
        {
            DataTable dt = _tourPlanning.GetJobStationByPermission(unitId, enroll);
            Common.LoadDropDown(ddlJobStation, dt, "intEmployeeJobStationId", "strJobStationName");
        }

        public void LoadTeamDropDown(int jobStationId)
        {
            DataTable dt = _bll.GetTeamByJobstation(jobStationId);
            Common.LoadDropDown(ddlTeam, dt, "intTeamId", "strTeamName");
        }

        public void LoadShiftDropDown(int teamId)
        {
            DataTable dt = _bll.GetShiftByShiftId(teamId);
            Common.LoadDropDown(ddlShift, dt, "intShiftId", "strShiftName");
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
            Common.LoadDropDown(ddlSequence, dt, "intSequenceId", "strSequenceName");
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
            string shift = Common.GetDdlSelectedText(ddlShift);
            int jobstationId = Common.GetDdlSelectedValue(ddlJobStation);
            string jobstation = Common.GetDdlSelectedText(ddlJobStation);
            int sequenceId = Common.GetDdlSelectedValue(ddlSequence);
            string sequence = Common.GetDdlSelectedText(ddlSequence);
            try
            {
                arrayKey = TxtAsset.Text.Split(delimiterChars);
                string assetId = "";  string assetType = ""; int assetAutoId = 0;
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); Anumber = int.Parse((arrayKey[3].ToString())); assetType = arrayKey[5].ToString(); }
            }
            catch { Anumber = 0; }
            string number = Anumber.ToString();
            if (jobstationId < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('Select Jobstation first','Roster','warning')", true);
                return;
            }
            if (shiftId < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "ShowNotification('Select Shift first','Roster','warning')", true);
                return;
            }
            //if( number<1)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
            //    "ShowNotification('Set Asset Number first','Roster','warning')", true);
            //    return;
            //}
            dynamic obj = new
            {
                empEnroll,
                date,
                shiftId,
                shift,
                jobstationId,
                jobstation,
                sequenceId,
                sequence,
                number,
                assetName
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
            LoadJobStationDropDown(Common.GetDdlSelectedValue(ddlUnit), _enroll);
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