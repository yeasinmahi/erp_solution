using SAD_BLL.Vat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.Vat
{
    public partial class Vat_Print_Mushak : BasePage
    {
        VAT_BLL _vatObj = new VAT_BLL();
        DataTable dt = new DataTable();
        private string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadUnitList();
                LoadShipPoint();
                LoadChallanList();
            }
        }
        public void LoadUnitList()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            ddlUnit.Loads(dt, "intUnitID", "strVATAccountName");
        }
        

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadShipPoint();
        }

        protected void ddlShipPoint_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlType.SetSelectedValue("0");
        }

        public void LoadShipPoint()
        {
            int unitId = ddlUnit.SelectedValue();
            dt = _vatObj.GetShippingPoint(Enroll, unitId);
            ddlShipPoint.LoadWithSelect(dt, "intShipPointId", "strName");
        }


        public void LoadSalesCode()
        {
            int shippingPointId = ddlShipPoint.SelectedValue();
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int accountId = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetSalesCode(accountId, shippingPointId);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else
            {
                ddlChallan.UnLoad();
            }
            
        }
        public void LoadChallanList()
        {
            dt = _vatObj.GetVatUnitByUser(Enroll);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.GetRow<int>("intUnitID", ddlUnit.SelectedValue());
                int vatid = Convert.ToInt32(row["intVatPointID"].ToString());
                dt = _vatObj.GetChallanByVAT(vatid);
                ddlChallan.LoadWithSelect(dt, "intId", "strCode");
            }
            else
            {
                ddlChallan.UnLoad();
            }
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int typeId = ddlType.SelectedValue();
            if (typeId == 1) //Sales
            {
                LoadSalesCode();
            }
            else if (typeId == 2) //Transfer
            {
                LoadChallanList();
            }
            else
            {
                ddlChallan.UnLoad();
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            //string value1,value2,value3;
            //url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/Fuel_Reports/CNG_Report" + "&pUnitName=" + UnitID + "&pJobStation=" + JobStationID + "&pDateFrom=" + txtFromDate.Text + "&pDateTo=" + txtToDate.Text + "&pFuelCompany=" + FuelCompanyID + "&rc:LinkTarget=_self";
       
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);

        }
}
}