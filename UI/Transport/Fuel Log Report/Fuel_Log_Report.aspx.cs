using HR_BLL.Global;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Transport.Fuel_Log_Report
{
    public partial class Fuel_Log_Report : BasePage
    {
        DataTable dt = new DataTable();
        NewVehicleBLL fuelObj = new NewVehicleBLL();
        HR_BLL.Global.Unit unitObj =new HR_BLL.Global.Unit();
        JobStation jobStationObj = new JobStation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadUnitList();
                LoadJobStationList(Convert.ToInt32( ddlUnit.SelectedItem.Value));
                LoadVehicleList();
                LoadFuelCompanyList();
            }
        }
        public void LoadUnitList()
        {
            dt = unitObj.GetUnits();
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        public void LoadJobStationList(int unitid)
        {
            dt = jobStationObj.GetJobStationListByUnit(unitid);
            ddlJobStation.Loads(dt, "intEmployeeJobStationId", "strJobStationName");
        }
        public void LoadVehicleList()
        {
            dt = fuelObj.VehicleList();
            ddlVehicleNo.Loads(dt, "intVehicleID", "strVehicleNo");
        }
        public void LoadFuelCompanyList()
        {
            dt = fuelObj.FuelCompanyList();
            ddlFuelCompany.Loads(dt, "party_id", "party_name");
        }

        protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJobStationList(Convert.ToInt32(ddlUnit.SelectedItem.Value));
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int report = Convert.ToInt32(ddlReport.SelectedItem.Value);
            string UnitID="", JobStationID="", FuelCompanyID="", VehicleID = "";
            try
            {
                UnitID = ddlUnit.SelectedItem.Value;
            }
            catch
            {
                UnitID = "0";
            }
            try
            {
                JobStationID = ddlJobStation.SelectedItem.Value;
            }
            catch
            {
                JobStationID = "0";
            }
            try
            {
                FuelCompanyID = ddlFuelCompany.SelectedItem.Value;
            }
            catch
            {
                FuelCompanyID = "0";
            }
            try
            {
                VehicleID = ddlVehicleNo.SelectedItem.Value;
            }
            catch
            {
                VehicleID = "0";
            }


            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            string url="";
            if (report == 1)
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/MonthWiseTopSheet" + "&Vehicle=" + VehicleID + "&dteFromDate=" + txtFromDate.Text + "&dteToDate=" + txtToDate.Text + "&rc:LinkTarget=_self";
            }
            else if(report == 2)
            {
                dt = fuelObj.JobStationByVehicleID(Convert.ToInt32(VehicleID));
                JobStationID = dt.Rows[0]["intJobStationID"].ToString();
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/DateWiseTopSheet" + "&Vehicle=" + VehicleID + "&JobStation=" + JobStationID + "&dteFromDate=" + txtFromDate.Text + "&dteToDate=" + txtToDate.Text + "&rc:LinkTarget=_self";
            }
            else if (report == 3)
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/OilSummaryReport" + "&unitName=" + UnitID + "&jobStation=" + JobStationID + "&dateFrom=" + txtFromDate.Text + "&dateTo=" + txtToDate.Text + "&fuelCompany=" + FuelCompanyID + "&rc:LinkTarget=_self";
            }
            else if (report == 4)
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/SummaryReport" + "&Unit=" + UnitID + "&JobStation=" + JobStationID + "&dteFromDate=" + txtFromDate.Text + "&dteToDate=" + txtToDate.Text + "&rc:LinkTarget=_self";
            }
            else if (report == 5)
            {
                url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/CNG_Report" + "&pUnitName=" + UnitID + "&pJobStation=" + JobStationID + "&pDateFrom=" + txtFromDate.Text + "&pDateTo=" + txtToDate.Text + "&pFuelCompany=" + FuelCompanyID + "&rc:LinkTarget=_self";
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        
    }
}