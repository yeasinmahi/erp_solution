using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class OverTimeEntryReprts : BasePage
    {
        readonly char[] _delimiterChars = { '[', ']' };
        string[] _arrayKey;

        private DataTable _dt = new DataTable();
        readonly TourPlanning _bll = new TourPlanning();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            SetJobStationId();
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

            txtFullName.Attributes.Add("onkeyUp", "SearchText();");
            hdnAction.Value = "0";
            if (!IsPostBack)
            {
                LoadUnitDropDown(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadJobStationDropDown(GetUnitId(Int32.Parse(Session[SessionParams.USER_ID].ToString())));
            }
            
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private void Loadgrid()
        {
            int jobstationid= int.Parse(ddlJobStation.SelectedValue.ToString());
            int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
          
            
            if (rptTypeid == 1)               //Over time for individual user
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string strSearchKey = txtFullName.Text;
                    _arrayKey = strSearchKey.Split(_delimiterChars);
                    string code = _arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enrol = int.Parse(code);
                    _dt = _bll.getRptOverTime(1, enrol, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (_dt.Rows.Count > 0)
                {
                    gdvJstopsheet.DataSource = null;
                    gdvJstopsheet.DataBind();
                    grdvOverTimeReports.DataSource = _dt;
                    grdvOverTimeReports.DataBind();

                 }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


           else if (rptTypeid == 2)               //Over time for Jobstation base top sheet
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    _dt = _bll.getRptOverTime(2, 0, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (_dt.Rows.Count > 0)
                {
                    grdvOverTimeReports.DataSource = null;
                    grdvOverTimeReports.DataBind();
                    gdvJstopsheet.DataSource = _dt;
                    gdvJstopsheet.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }
        }
        [WebMethod]
        public static List<string> GetAutoCompleteDataForTADA(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int jobStationId = 0;
            if (HttpContext.Current.Session["jobStationId"]!=null)
            {
                int.Parse(HttpContext.Current.Session["jobStationId"].ToString());
                var result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
                    int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), jobStationId, strSearchKey);
                return result;
            }
                return new List<string>();
        }
        protected void grdvOverTimeReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOverTimeReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvOverTimeReports.PageIndex = e.NewPageIndex;
            Loadgrid();
        }

        protected void gdvJstopsheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdvJstopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvJstopsheet.PageIndex = e.NewPageIndex;
            Loadgrid();
        }

        public int GetUnitId(int enrol)
        {
            return Int32.Parse(_bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
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

        protected void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
       

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetJobStationId();
        }

        private void SetJobStationId()
        {
            if (ddlJobStation.SelectedItem != null)
            {
                Session["jobStationId"] = ddlJobStation.SelectedItem.Value;
            }
            
        }
        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int unitId = Convert.ToInt32((sender as DropDownList).SelectedValue);
            LoadJobStationDropDown(unitId);
            ddlJobStation_OnSelectedIndexChanged(ddlJobStation, null);
        }
    }
}