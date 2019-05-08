using BLL.Accounts.ChartOfAccount;
using LOGIS_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Global;
using SAD_BLL.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_DAL.Customer;
using UI.ClassFiles;
using Utility;
using SAD_BLL.Sales;

namespace UI.SAD.Delivery
{
    public partial class DeliveryEntry : BasePage
    {
        HR_BLL.Global.Unit unt = new HR_BLL.Global.Unit();
        ShipPoint shipPoint = new ShipPoint();
        SalesOffice salesOffice = new SalesOffice();
        CustomerType customerType = new CustomerType();
        ExtraCharge extraCharge = new ExtraCharge();
        Incentive incentive = new Incentive();
        CustomerInfo customerInfo = new CustomerInfo();
        ItemUnitOfMeasurement objUom = new ItemUnitOfMeasurement();
        SalesConfig salesConfig=new SalesConfig();
        Currency currency = new Currency(); 
         DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DefaultPageLoad();
            }

        }
        
        private void DefaultPageLoad()
        {
            try
            {
                dt = unt.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                ddlUnit.Loads(dt, "intUnitID", "strUnit"); 
                UnitSelectionChange();
            }
            catch { }
        }

        private void UnitSelectionChange()
        {
            try
            {
                dt = shipPoint.GetShipPoint(HttpContext.Current.Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue().ToString());
                ddlShipPoint.Loads(dt, "intShipPointId", "strName");
                dt = salesOffice.GetSalesOfficeByShipPoint(ddlShipPoint.SelectedValue().ToString());
                ddlSalesOffice.Loads(dt, "intSalesOfficeId", "strName");

                dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
                ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");

                dt = extraCharge.GetExtraChargeList(ddlUnit.SelectedValue().ToString());
                ddlVehicleCharge.Loads(dt, "intID", "strText");

                dt = incentive.GetIncentiveList(ddlUnit.SelectedValue().ToString());
                ddlVehicleIncentive.Loads(dt, "intID", "strText");

                dt = salesConfig.GetSalesTypeForDO(ddlUnit.SelectedValue().ToString());
                rdoSalesType.RadioLoad(dt, "intTypeID", "strTypeName");
                
                rdoSalesType.SelectedIndex= 0;
 
               dt = currency.GetCurrencyInfo();
                ddlCurrency.Loads(dt, "intID", "strCurrency");

                SessionDataSet();
            }
            catch { }
        }

        private void SessionDataSet()
        {
            try
            {
                Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue().ToString();
                Session[SessionParams.CURRENT_SO] = ddlSalesOffice.SelectedValue().ToString();
                Session[SessionParams.CURRENT_CUS_TYPE] = ddlCustomerType.SelectedValue().ToString();

            }
            catch { }
        }
        #region WebMethod

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
           
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetDisPointList(string prefixText, int count)
        {
            return DistributionPointSt.GetDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session["sesCurrentCus"].ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleList(string prefixText, int count)
        {
            if (("" + HttpContext.Current.Session["sesCurVhlCom"]).ToLower() == "true" || HttpContext.Current.Session["sesCurVhlCom"] == null)
            {
                return VehicleSt.GetVehicleDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (("" + HttpContext.Current.Session["sesCurVhlCom"]).ToLower() == "false")
            {
                return VehicleSt.GetVehicleDataForAutoFillParty(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else return null;
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierList(string prefixText, int count)
        {
            if ("" + HttpContext.Current.Session["sesSupplierParent"] != "")
            {
                return ChartOfAccStaticDataProvider.GetCOADataForAutoFillByParent(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session["sesSupplierParent"].ToString(), prefixText);
            }
            else
            {
                return null;
            }
        }

        #endregion
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UnitSelectionChange();
            }
            catch { }
        }

        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = salesOffice.GetSalesOfficeByShipPoint(ddlShipPoint.SelectedValue().ToString());
                ddlSalesOffice.Loads(dt, "intSalesOfficeId", "strName");

                dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
                ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");
                SessionDataSet();
            }
            catch { }
        }

        protected void ddlSalesOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
                ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");
                SessionDataSet();

            }
            catch { }
        }


        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomer.Text.Trim() != "")
                {
                    char[] ch = {'[', ']'};
                    string[] temp = txtCustomer.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdnCustomer.Value = temp[temp.Length - 1];
                    hdnCustomerText.Value = temp[0]; 
                    CustomerTDS.TblCustomerShortDataTable tbl = customerInfo.GetCustomerShortInfoById(hdnCustomer.Value);

                    if (tbl.Rows.Count > 0)
                    {
                        txtCustomerAddress.Text = tbl[0].strAddress;
                    }
                }
                

            }
            catch
            {
            }
        }

        protected void txtShipToParty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtShipToParty.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
                    string[] temp = txtShipToParty.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdnShipToPartyId.Value = temp[temp.Length - 1];
                    hdnShipToPartyText.Value = temp[0];
                    CustomerTDS.TblCustomerShortDataTable tbl = customerInfo.GetCustomerShortInfoById(hdnShipToPartyId.Value); 
                    if (tbl.Rows.Count > 0)
                    {
                        txtShipToPartyAddress.Text = tbl[0].strAddress;
                    }
                    
                }
            }
            catch { }
        }

        protected void ddlVehicleCharge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVehicleIncentive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdoNeedVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoNeedVehicle.SelectedValue.ToString() == "1")
                {
                    pnlVehicle3rd.Visible = false;
                    pnlVehicleCustomer.Visible = false;
                    pnlVehicle3rd.Visible = true;
                }
                else if (rdoNeedVehicle.SelectedValue.ToString() == "2")
                {
                    pnlVehicle3rd.Visible = true;
                    pnlVehicleCustomer.Visible = false;
                }
            }
            catch { }
        }

        protected void rdoVehicleCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoVehicleCompany.SelectedValue.ToString() == "1")
                {
                    pnlVehicle3rd.Visible = false;
                    pnlVehicleCustomer.Visible = false;
                }
                else if (rdoVehicleCompany.SelectedValue.ToString() == "2")
                {
                    pnlVehicle3rd.Visible = true;
                    pnlVehicleCustomer.Visible = false;
                }
                else if (rdoVehicleCompany.SelectedValue.ToString() == "3")
                {
                    pnlVehicle3rd.Visible = false;
                    pnlVehicleCustomer.Visible = true;
                }


            }
            catch (Exception exception)
            {

                throw;
            }
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        { 
            try
            {
                if (txtProduct.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
                    string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdnProduct.Value = temp[temp.Length - 1];
                    hdnProductText.Value = temp[0];
                    //dt = objUom.GetUOMRelationByPrice(hdnProduct.Value,hdnCustomer.Value,'',)
                    txtQun.Focus();
                }
                else
                {
                    hdnProduct.Value = "";
                } 
            }
            catch{ }
        }

        protected void btnProductAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnProductAddAll_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SessionDataSet();
        }
    }
}