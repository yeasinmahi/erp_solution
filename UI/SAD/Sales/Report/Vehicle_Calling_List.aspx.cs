using SAD_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Sales.Report
{
    public partial class Vehicle_Calling_List : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        ShipPoint shipPointObj = new ShipPoint();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnit();
                string unitId = ddlUnit.SelectedItem.Value;
                LoadShipPoint(unitId);

            }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unitId = ddlUnit.SelectedItem.Value;
            LoadShipPoint(unitId);
        }
        private void LoadUnit()
        {
            dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        private void LoadShipPoint(string unitId)
        {
            dt = shipPointObj.GetShipPoint(HttpContext.Current.Session[SessionParams.USER_ID].ToString(), unitId);
            ddlShipPoint.Loads(dt, "intShipPointId", "strName");
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string unitid = ddlUnit.SelectedItem.Value;
            string shipid = ddlShipPoint.SelectedItem.Value;
            LoadReport(unitid, shipid);
        }

        private void LoadReport(string unitid, string shipid)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/Vehicle_Calling_List" + "&UnitID=" + unitid + "&ShipPointID=" + shipid + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }



    }
}