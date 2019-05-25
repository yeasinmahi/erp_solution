using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.SAD.Sales
{
    public partial class Sales_Info_Report : BasePage
    {
        DataTable dt = new DataTable();
        HR_BLL.Global.Unit unitObj = new HR_BLL.Global.Unit();
        SAD_BLL.Global.SalesOffice salesOffice = new SAD_BLL.Global.SalesOffice();
        SAD_BLL.Global.ShipPoint shipPointObj = new SAD_BLL.Global.ShipPoint();
        SAD_BLL.Customer.CustomerType customerTypeObj = new SAD_BLL.Customer.CustomerType();
        string unitid,userid, shipPointId,salesOfficeId, CustomerTypeId, fromDate, toDate, code;
        bool ysnEnable, ysnDo, ysnChallanCompleted;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadUnit();
                unitid = ddlUnit.SelectedItem.Value;
                userid= HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                LoadShipPoint(unitid,userid);
                shipPointId = ddlshippoint.SelectedItem.Value;
                LoadSalesOffice(shipPointId);
                salesOfficeId = ddlSalesOffice.SelectedItem.Value;
                LoadCustomerType(salesOfficeId);
            }
        }
        private void LoadUnit()
        {
            dt = unitObj.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            ddlUnit.Loads(dt, "intUnitID", "strUnit");
        }
        private void LoadShipPoint(string unitid,string userid)
        {
            dt = shipPointObj.GetShipPoint(userid,unitid);
            ddlshippoint.Loads(dt, "intShipPointId", "strName");

        }
        private void LoadSalesOffice(string shipid)
        {
            dt = salesOffice.GetSalesOfficeByShipPoint(shipid);
            ddlSalesOffice.Loads(dt, "intSalesOfficeId", "strName");

        }
        private void LoadCustomerType( string salesOfficeId)
        {
            dt = customerTypeObj.GetCustomerTypeBySO(salesOfficeId); 
            ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");
           
        }
        protected void ddlshippoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            shipPointId = ddlshippoint.SelectedItem.Value;
            LoadSalesOffice(shipPointId);
            
        }
        protected void ddlSalesOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            salesOfficeId = ddlSalesOffice.SelectedItem.Value;
            LoadCustomerType(salesOfficeId);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
             unitid = ddlUnit.SelectedItem.Value;
             fromDate = txtFromDate.Text;
             toDate = txtToDate.Text;
            shipPointId = ddlshippoint.SelectedItem.Value;
            CustomerTypeId = ddlCustomerType.SelectedItem.Value;
            code = txtCode.Text;
            if(rdoEnable.SelectedItem.Text=="Yes")
            {
                ysnEnable = true;
            }
            else
            {
                ysnEnable = false;
            }
            if (rdoComplete.SelectedItem.Text == "Yes")
            {
                ysnChallanCompleted = true;
            }
            else
            {
                ysnChallanCompleted = false;
            }
            if (rdoDO.SelectedItem.Text == "Yes")
            {
                ysnDo = true;
            }
            else
            {
                ysnDo = false;
            }

            LoadReport(unitid,fromDate,toDate,CustomerTypeId,shipPointId,ysnEnable,ysnDo,ysnChallanCompleted,code);
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitid = ddlUnit.SelectedItem.Value;
            userid = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            LoadShipPoint(unitid, userid);
        }

        private void LoadReport(string unitid, string fromDate,string toDate,string CustomerTypeId,string ShipPointId, bool ysnEnable, bool ysnDo, bool ysnChallanCompleted, string code)
        {
            string url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Sales_And_Distribution/Sales_Info" + "&intUnitID=" + unitid + "&fromdate=" + fromDate + "&todate=" + toDate + "&intCustomerType=" + CustomerTypeId + "&intShipPointId=" + ShipPointId + "&ysnEnable=" + ysnEnable + "&ysnDO2=" + ysnDo + "&ysnChallanCompleted=" + ysnChallanCompleted + "&code=" + code + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }


    }
}