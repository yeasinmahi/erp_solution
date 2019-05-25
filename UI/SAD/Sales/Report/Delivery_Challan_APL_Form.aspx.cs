using SAD_BLL.Customer;
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
    public partial class Delivery_Challan_APL_Form : BasePage
    {
        DataTable dt = new DataTable();
        ShipPoint shipPointObj = new ShipPoint();
        CustomerInfo custObj = new CustomerInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //int tripID = Convert.ToInt32(txtTripID.Text);
                //LoadCustomer(tripID);
                LoadDepot(90);
            }
        }
        private void LoadDepot(int unitId)
        {
            dt = shipPointObj.GetShippointByUnit(unitId);
            ddlDepot.Loads(dt, "intId", "strName");
        }
        protected void txtTripID_TextChanged(object sender, EventArgs e)
        {
            int tripID = Convert.ToInt32(txtTripID.Text);
            LoadCustomer(tripID);

        }
        private void LoadCustomer(int tripID)
        {
            dt = custObj.CustomerBYTripId(tripID);
            ddlCustomer.Loads(dt, "intCusID", "CustName");
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            string tripID = txtTripID.Text;
            string custID = ddlCustomer.SelectedItem.Value;
            string depot = ddlDepot.SelectedItem.Text;

            LoadReport(tripID,custID,depot);
        }
        private void LoadReport(string tripID,string custID,string depot)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/Delivery_Challan_APL_Form" + "&TripID=" + tripID + "&CustID=" + custID + "&UnitName=" + "Akij Plastics Ltd" + "&DepotName=" + depot + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        
    }
}