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
    public partial class Customer_Pending_List_Report : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        ShipPoint shipPointObj = new ShipPoint();
        int unitId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //LoadUnit();
                //unitId = Convert.ToInt32(ddlUnit.SelectedItem.Value);
                LoadDepot(90);
            }
        }

        private void LoadUnit()
        {
            //dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            //ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //unitId = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            LoadDepot(90);
        }
        private void LoadDepot(int unitId)
        {
            dt = shipPointObj.GetShippointByUnit(unitId);
            ddlDepot.Loads(dt, "intId", "strName");
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            //string unit = ddlUnit.SelectedItem.Value;
            string depot = ddlDepot.SelectedItem.Text;
           
            LoadReport(depot);
        }

        private void LoadReport(string depot)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/Customer_Pending_List" + "&DepotName=" + depot +  "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        
    }
}