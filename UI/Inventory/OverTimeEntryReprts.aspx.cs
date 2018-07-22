using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        char[] delimiterChars = { '[', ']' }; string[] arrayKey;

        DataTable dt = new DataTable();
        TourPlanning bll = new TourPlanning();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();

            txtFullName.Attributes.Add("onkeyUp", "SearchText();");
            hdnAction.Value = "0";
            if (!IsPostBack)
            {
                LoadUnitDropDown(Int32.Parse(Session[SessionParams.USER_ID].ToString()));
                LoadJobStationDropDown(GetUnitID(Int32.Parse(Session[SessionParams.USER_ID].ToString())));
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
                    arrayKey = strSearchKey.Split(delimiterChars);
                    string code = arrayKey[1].ToString();
                    string strCustname = strSearchKey;
                    int enrol = int.Parse(code);
                    dt = bll.getRptOverTime(1, enrol, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    gdvJstopsheet.DataSource = null;
                    gdvJstopsheet.DataBind();
                    grdvOverTimeReports.DataSource = dt;
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
                    dt = bll.getRptOverTime(2, 0, "", 0, dteFromDate, dteToDate, jobstationid, unitid);
                }

                catch { }

                if (dt.Rows.Count > 0)
                {
                    grdvOverTimeReports.DataSource = null;
                    grdvOverTimeReports.DataBind();
                    gdvJstopsheet.DataSource = dt;
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
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(//1399, 12, strSearchKey);
                int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), int.Parse(HttpContext.Current.Session["jobStationId"].ToString()), strSearchKey);
            return result;
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

        public int GetUnitID(int enrol)
        {
            return Int32.Parse(bll.GetUnitName(enrol).Rows[0]["intUnitID"].ToString());
        }
        public void LoadJobStationDropDown(int unitId)
        {
            ddlJobStation.DataSource = bll.GetJobStation(unitId);
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataBind();
        }
        public void LoadUnitDropDown(int enrol)
        {
            ddlUnit.DataSource = bll.GetUnitName(enrol);
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataTextField = "strUnit";
            ddlUnit.DataBind();
        }

        protected void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
       

        protected void ddlJobStation_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Session["jobStationId"] = (sender as DropDownList).SelectedValue;
        }

        protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int unitId = Convert.ToInt32((sender as DropDownList).SelectedValue);
            LoadJobStationDropDown(unitId);
            ddlJobStation_OnSelectedIndexChanged(ddlJobStation, null);
        }
    }
}