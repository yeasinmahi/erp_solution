using BLL.Accounts.ChartOfAccount;
using LOGIS_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Global;
using SAD_BLL.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using System.Xml;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

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
        SalesConfig salesConfig = new SalesConfig();
        Currency currency = new Currency();
        ItemPrice itemPrice = new ItemPrice();
        ItemPromotion itemPromotion = new ItemPromotion();
        SAD_BLL.Item.Item item = new SAD_BLL.Item.Item();
        Delivery_BLL deliveryBLL = new Delivery_BLL();
        SalesSearch_BLL salesSearch_obj = new SalesSearch_BLL();
        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();
        XmlManager xm = new XmlManager();

        private string message;
        private string _filePathForXml, _xmlString = "", xmlHeaderString = "";
        private bool _isProcess = false, _checkItem=false; int _isCount = 0, xmlSerial=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_filePathForXml = Server.MapPath("~/SAD/Delivery/Data/Sales__" + Enroll + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(GetXmlFilePath()); } catch { }

                if (Request.QueryString["PopupType"] != null)
                {
                    GetUrlData(Request.QueryString["PopupType"]); 
                }
                
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
              
                  
            }

        }
        private void GetUrlData(string type)
        {
            try
            {
                Session[SessionParams.SalesProcess] = type;
                hdnDelivery.Value = type;
                rdoDeliveryType.Items.Clear();
                rdoDeliveryType.Items.Add(new ListItem(type, "1"));
                rdoDeliveryType.SelectedValue = "1";
                Session[SessionParams.SalesProcess] = type;

                Session[SessionParams.SalesProcess] = Request.QueryString["PopupType"];
                if (!IsNullOrEmpty(Request.QueryString["intid"]))
                {
                    Session["DoId"] = Request.QueryString["intid"];
                    Session["PickingId"] = Request.QueryString["intid"];
                    hdnRequistId.Value = Request.QueryString["intid"];
                }
                else
                {
                    Session["DoId"] = "0";

                }
                if (!IsNullOrEmpty(Request.QueryString["intCusID"]))
                {
                    Session["CustomerId"] = Request.QueryString["intCusID"];
                    hdnRequistId.Value = Request.QueryString["intCusID"];

                }
                else
                {
                    Session["CustomerId"] = "0";
                    // hdnRequistId.Value = "0";
                }
                if (!IsNullOrEmpty(Request.QueryString["strReportType"]))
                {
                    Session["ReportType"] = Request.QueryString["strReportType"];
                }
                else
                {
                    Session["ReportType"] = "0";
                }
                if (!IsNullOrEmpty(Request.QueryString["ShipPointID"]))
                {
                    Session["ShipId"] = Request.QueryString["ShipPointID"];
                }
                else
                {
                    Session["ShipId"] = "0";
                }

                if (hdnRequistId.Value == "0")
                {
                    DefaultPageLoad();
                }
                else
                {

                    PickingPageloadDataBind();
                    txtCustomer.Enabled = false;
                    txtShipToParty.Enabled = false;
                    txtCustomerAddress.Enabled = false;
                    txtShipToPartyAddress.Enabled = false;
                }
                ControlHide(type);
            }
            catch { }
        }
        public static bool IsNullOrEmpty(String str)
        {
            return(str == null || str == String.Empty) ? true : false;
        }
        private void RequestPopUp()
        {
            try
            {
               // Session[SessionParams.SalesProcess] = "Picking";
                Session[SessionParams.SalesProcess] = Request.QueryString["PopupType"];
                if (IsNullOrEmpty(Request.QueryString["intid"]))
                {
                    Session["DoId"] = Request.QueryString["intid"];
                    Session["PickingId"] = Request.QueryString["intid"];
                    hdnRequistId.Value = Request.QueryString["intid"];
                }
                else
                {
                    Session["DoId"] ="0";
                    hdnRequistId.Value = "0";
                }
                if (IsNullOrEmpty(Request.QueryString["intCusID"]))
                {
                    Session["CustomerId"] = Request.QueryString["intCusID"];
                    hdnRequistId.Value= Request.QueryString["intCusID"];
                }
                else
                {
                    Session["CustomerId"] = "0";
                    hdnRequistId.Value = "0";
                }
                if (IsNullOrEmpty(Request.QueryString["strReportType"]))
                {
                    Session["strReportType"] = Request.QueryString["strReportType"];
                }
                else
                {
                    Session["strReportType"] = "0";
                }
                if (IsNullOrEmpty(Request.QueryString["ShipPointID"]))
                {
                    Session["ShipId"] = Request.QueryString["ShipPointID"]; 
                }
                else
                {
                    Session["ShipId"] = "0";
                }

                Session["DoId"] = Request.QueryString["intid"];
                Session["CustomerId"] = Request.QueryString["intCusID"];
                Session["ShipId"] = Request.QueryString["ShipPointID"];
                Session["PickingId"] = Request.QueryString["intid"];
                Session["ReportType"] = Request.QueryString["strReportType"];

               string DO = Request.QueryString["intid"];
               string custid = Request.QueryString["intCusID"];
                string shipid= Request.QueryString["ShipPointID"];
                string pickid= Request.QueryString["PickingId"];
               string rpttype = Request.QueryString["strReportType"];
                string popuptype = Request.QueryString["PopupType"];

                
                if (IsNullOrEmpty(hdnRequistId.Value))
                { 
                    DefaultPageLoad();
                }
                else
                {
                    
                    PickingPageloadDataBind();
                    txtCustomer.Enabled = false;
                    txtShipToParty.Enabled = false;
                    txtCustomerAddress.Enabled = false;
                    txtShipToPartyAddress.Enabled = false;
                }
                  
                 
                //Session["ReportType"] = "DoBase";
                //Session[SessionParams.SalesProcess] = "Picking";
                //Session["DoId"] = 2620642; 
                //Session["CustomerId"] = 305479;
                //Session["ShipId"] = 15;
              //  PickingPageloadDataBind();


            }
            catch { }
        }
        private void PickingPageloadDataBind()
        {

            if (HttpContext.Current.Session["ReportType"].ToString() == "DO_Base" && Request.QueryString["PopupType"] == "Picking")
            {
                hdnDoId.Value = Request.QueryString["intid"];
                txtDoNumber.Text= Request.QueryString["intid"];
                dt = deliveryBLL.DeliveryHeaderDataByDo(hdnDoId.Value.ToString(), Request.QueryString["ShipPointID"],true);
                if (dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["ysnCompleted"]) == false)
                {
                    btnSubmit.Visible = false;
                    btnProductAddAlls.Visible = false;
                    txtProduct.Enabled = false; 
                    lblDoCustId.ForeColor = Color.Red;
                    Toaster("Delivery order not apporve", hdnDelivery.Value, Common.TosterType.Warning);
                }


            }
            else if (Request.QueryString["strReportType"] == "Customer_Base" && Request.QueryString["PopupType"] == "Picking")
            {
                hdnCustomer.Value= Request.QueryString["intCusID"];
                txtDoNumber.Text = Request.QueryString["intCusID"];
                dt = deliveryBLL.DeliveryHeaderDataByCustomer(hdnCustomer.Value, Request.QueryString["ShipPointID"],true);
                if (dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["ysnCompleted"]) == false)
                {
                    
                    btnSubmit.Visible = false;
                    btnProductAddAlls.Visible = false;
                    txtProduct.Enabled = false; 
                    lblDoCustId.ForeColor = Color.Red;
                    Toaster("Delivery order not apporve", hdnDelivery.Value, Common.TosterType.Warning);
                }

            }
            else if ( Request.QueryString["PopupType"] == "Picking_Edit" || Request.QueryString["PopupType"] == "Delivery")
            {
                hdnPickingId.Value = Request.QueryString["intid"];
                txtDoNumber.Text = Request.QueryString["intid"]; 
                PickingGridDataBind(hdnPickingId.Value);
                dt = deliveryBLL.PickingSummary(hdnPickingId.Value);
               

            }
            else if (HttpContext.Current.Session["ReportType"].ToString() == "DO_Base" && Request.QueryString["PopupType"] == "DO_Edit")
            {
                hdnDoId.Value = Request.QueryString["intid"];
                txtDoNumber.Text = Request.QueryString["intid"];
                DoGridDataBind(hdnDoId.Value);
                dt = deliveryBLL.DeliveryHeaderDataByDo(hdnDoId.Value.ToString(), Request.QueryString["ShipPointID"],false);
                  

                if (dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["ysnCompleted"])==true)
                {
                    btnSubmit.Visible = false;
                    btnProductAddAlls.Visible = false;
                    txtProduct.Enabled = false; 
                    lblDoCustId.ForeColor=Color.Red;
                    Toaster("Delivery already order approved", hdnDelivery.Value, Common.TosterType.Warning); 
                }
                
            }
            if (dt.Rows.Count > 0)
            { 
                DropDownDataBindFromDoCustomer(dt);
                RadioButtonListBindFromDoCustomer(dt);
               
                SessionDataSet();
                ControlHide(rdoDeliveryType.SelectedItem.Text.ToString());
                CustometChange();
                WareHouseLocation();
            }
            else
            {
                Toaster("There is no data against your query", "Delivery Entry", Common.TosterType.Warning);
            }
            

           
        }

        private void DoGridDataBind(string Do)
        {
            try
            {
                dt = deliveryBLL.DoItemDetalis(Do);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string productId = dt.Rows[i]["intProductId"].ToString();
                    string productName = dt.Rows[i]["strProductName"].ToString();
                    string quantity = dt.Rows[i]["numRestQuantity"].ToString();
                    string coaId = dt.Rows[i]["intCOAAccId"].ToString();
                    string coaName = dt.Rows[i]["strCOAAccName"].ToString();

                    string invProductId = "0";
                    string productCogs = "0";
                    string rate = dt.Rows[i]["monPrice"].ToString();
                    string uomId = dt.Rows[i]["intUom"].ToString();
                    string uomName = dt.Rows[i]["strUOM"].ToString();
                    string narration = dt.Rows[i]["strNarration"].ToString();
                    string currency = dt.Rows[i]["intCurrencyID"].ToString();
                    string conversionRate = dt.Rows[i]["monConversionRate"].ToString();
                    string commision = dt.Rows[i]["monCommission"].ToString();

                    string commisionTotal = Convert.ToString(decimal.Parse(dt.Rows[i]["monCommission"].ToString()) * decimal.Parse(dt.Rows[i]["numRestQuantity"].ToString()));
                    string discountTotal = Convert.ToString(decimal.Parse(dt.Rows[i]["decDiscountRate"].ToString()) * decimal.Parse(dt.Rows[i]["numRestQuantity"].ToString()));

                    decimal priceTotal = decimal.Parse(dt.Rows[i]["monPrice"].ToString()) * decimal.Parse(dt.Rows[i]["numQuantity"].ToString());

                    string discount = dt.Rows[i]["decDiscountRate"].ToString();
                    string whId = hdnWHId.Value;
                    string whName = hdnWHName.Value; 

                    string supplierTax = dt.Rows[i]["monSuppTax"].ToString();
                    string vat = dt.Rows[i]["monVAT"].ToString();
                    string vatPrice = dt.Rows[i]["monVatPrice"].ToString(); ;
                    string promtionItemId = dt.Rows[i]["intPromItemId"].ToString();
                    string invPromoProductId = "0";
                    string promoProductCogs = "0";
                    string promtionItem = dt.Rows[i]["strPromItemName"].ToString();
                    string promtionUom = dt.Rows[i]["intPromUOM"].ToString();

                    string promPrices = dt.Rows[i]["monPromPrice"].ToString();
                    string promtionItemCoaId = dt.Rows[i]["intPromItemCOAId"].ToString();
                    string promtionQnty = dt.Rows[i]["numPromotion"].ToString();
                    string promtionItemUom = dt.Rows[i]["intPromUOM"].ToString();
                    string location = "0";
                    string locationName = "0";
                    string intInvItemId = "0";
                    string editStatus = "0";
                    string doId = dt.Rows[i]["intDoId"].ToString();
                    string doqty = dt.Rows[i]["numRestQuantity"].ToString();


                    RowLavelXmlCreate(productId, productName, quantity, rate, uomId, uomName,
                        narration, currency, commision, commisionTotal, discount, discountTotal.ToString(),
                        priceTotal.ToString(), supplierTax, vat, vatPrice, promtionItemId, promtionItem, promPrices,
                        promtionUom, coaId, coaName, promtionItemCoaId, promtionQnty, promtionItemUom, location,
                        intInvItemId, editStatus, invProductId, productCogs, invPromoProductId, promoProductCogs, conversionRate, whId, doId, locationName, doqty);

                }
                
            }
            catch { }
           

        }

        private void RadioButtonListBindFromDoCustomer(DataTable dt)
        {
            rdoDeliveryType.Items.Clear();
            rdoDeliveryType.Items.Add(new ListItem(HttpContext.Current.Session[SessionParams.SalesProcess].ToString(), "1"));
            rdoDeliveryType.SelectedValue = "1"; 

            rdoSalesType.Items.Clear();
            rdoSalesType.Items.Add(new ListItem(dt.Rows[0]["strSalesType"].ToString(), dt.Rows[0]["intSalesTypeId"].ToString()));
            rdoSalesType.SelectedValue = dt.Rows[0]["intSalesTypeId"].ToString();

            try
            {
                rdoVehicleCompany.SelectedValue = dt.Rows[0]["intLogisticProvider"].ToString(); 
                Session["sesLogisticType"] = rdoVehicleCompany.SelectedItem.Text; 
            }
            catch { Session["sesLogisticType"] = rdoVehicleCompany.SelectedItem.Text; }
        }

        private void DropDownDataBindFromDoCustomer(DataTable dt)
        {
            ddlUnit.UnLoad();
            ddlShipPoint.UnLoad();
            ddlSalesOffice.UnLoad();
            ddlCustomerType.UnLoad();
            ddlCurrency.UnLoad();
            ddlUnit.Items.Add(new ListItem(dt.Rows[0]["strUnit"].ToString(), dt.Rows[0]["intUnitId"].ToString()));
            ddlShipPoint.Items.Add(new ListItem(dt.Rows[0]["strShipPointName"].ToString(), dt.Rows[0]["intShipPointId"].ToString()));
            ddlSalesOffice.Items.Add(new ListItem(dt.Rows[0]["strSalesOfficeName"].ToString(), dt.Rows[0]["intSalesOffId"].ToString()));
            ddlCustomerType.Items.Add(new ListItem(dt.Rows[0]["strCustType"].ToString(), dt.Rows[0]["intCustTypeId"].ToString()));
            try{ddlCurrency.Items.Add(new ListItem(dt.Rows[0]["strCurrency"].ToString(), dt.Rows[0]["intCurrencyId"].ToString()));}
            catch { } 

            CalendarDate.SelectedDate = DateTime.Parse(dt.Rows[0]["dteDate"].ToString());
           try{ CalendarDueDate.SelectedDate = DateTime.Parse(dt.Rows[0]["dteReqDelivaryDate"].ToString()); }
            catch { CalendarDueDate.SelectedDate = DateTime.Parse(dt.Rows[0]["dteDate"].ToString()); }

            txtCustomer.Text = dt.Rows[0]["strCustNameId"].ToString();
            txtCustomerAddress.Text = dt.Rows[0]["strCustAddress"].ToString();
            hdnCustomer.Value = dt.Rows[0]["intCustomerId"].ToString();
            try { txtShipmentCost.Text = dt.Rows[0]["monShipmentCost"].ToString(); } catch { }

            if (hdnPickingId.Value== null)
            {
                try
                {
                    hdnShipToPartyId.Value= dt.Rows[0]["intShipToPartyId"].ToString(); 
                    txtShipToParty.Text = dt.Rows[0]["strShipToPartyNameId"].ToString();
                    txtShipToPartyAddress.Text = dt.Rows[0]["strShipAddress"].ToString();
                }
                catch
                {
                    txtShipToParty.Text = "";
                    txtShipToPartyAddress.Text = "";
                }
            }
            else
            {
                try
                {
                    txtShipToParty.Text = dt.Rows[0]["strShipToParty"].ToString();
                    txtShipToPartyAddress.Text = dt.Rows[0]["strShipAddress"].ToString();
                    hdnVehicle.Value= dt.Rows[0]["intVehicleRegId"].ToString();
                    txtVehicle.Text= dt.Rows[0]["strVehicleNameId"].ToString(); 
                    txtDriver.Text = dt.Rows[0]["strDriverName"].ToString();
                    txtDriverContact.Text = dt.Rows[0]["strDriverContactNo"].ToString();
                    txtSupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                }
                catch
                {
                    txtShipToParty.Text = "";
                    txtShipToPartyAddress.Text = "";
                }
            }
           
        }

        private void PickingGridDataBind(string pickingId)
        {
            dt = deliveryBLL.PickingDetalis(pickingId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                hdnPickingId.Value = pickingId;
                string productId = dt.Rows[i]["intProductId"].ToString();
                string productName = dt.Rows[i]["strProductName"].ToString();
                string quantity = dt.Rows[i]["numQty"].ToString();
                string coaId = dt.Rows[i]["intSalesCOAId"].ToString();
                string coaName = dt.Rows[i]["strCOAName"].ToString(); 

                string invProductId = dt.Rows[i]["intItemIdInventory"].ToString();
                string productCogs = "0";
                string rate = dt.Rows[i]["monPrice"].ToString();
                string uomId = dt.Rows[i]["intSalesUomId"].ToString();
                string uomName = dt.Rows[i]["strUOM"].ToString();
                string narration = dt.Rows[i]["strNarration"].ToString();
                string currency = dt.Rows[i]["intCurrencyId"].ToString();
                string conversionRate = dt.Rows[i]["monConversionRate"].ToString();
                string commision = dt.Rows[i]["monDiscount"].ToString();
                string commisionTotal = dt.Rows[i]["monTotalCashAdjustment"].ToString();
                string discountTotal = dt.Rows[i]["monTotalCashAdjustment"].ToString();
                decimal priceTotal = decimal.Parse(dt.Rows[i]["monPrice"].ToString()) * decimal.Parse(dt.Rows[i]["numQty"].ToString());

                string discount = dt.Rows[i]["monDiscount"].ToString();
                string whId = dt.Rows[i]["intWHId"].ToString();
                string whName = dt.Rows[i]["strWareHoseName"].ToString();
                hdnWHId.Value = dt.Rows[i]["intWHId"].ToString();
                hdnWHName.Value = dt.Rows[i]["strWareHoseName"].ToString();
                string supplierTax = "0";
                string vat = "0";
                string vatPrice = "0";
                string promtionItemId = dt.Rows[i]["intPromProductId"].ToString();
                string invPromoProductId = "0";
                string promoProductCogs = "0";
                string promtionItem = dt.Rows[i]["strPromItemName"].ToString();
                string promtionUom = dt.Rows[i]["intPromUomId"].ToString();

                string promPrices = dt.Rows[i]["monPromPrice"].ToString();
                string promtionItemCoaId = dt.Rows[i]["intPromCOAId"].ToString();
                string promtionQnty = dt.Rows[i]["numPromQty"].ToString();
                string promtionItemUom = dt.Rows[i]["intPromUomId"].ToString();
                string location = dt.Rows[i]["intLocationId"].ToString();
                string intInvItemId = dt.Rows[i]["intItemIdInventory"].ToString();
                string editStatus = "0";
                string doId = dt.Rows[i]["intDoId"].ToString();
                string doqty = "0";
                try
                {
                    location = dt.Rows[i]["intLocationId"].ToString();
                }
                catch { location = "0"; }
                string locationName = "";

                RowLavelXmlCreate(productId, productName, quantity, rate, uomId, uomName,
                    narration, currency, commision, commisionTotal, discount, discountTotal.ToString(),
                    priceTotal.ToString(), supplierTax, vat, vatPrice, promtionItemId, promtionItem, promPrices,
                    promtionUom, coaId, coaName, promtionItemCoaId, promtionQnty, promtionItemUom, location,
                    intInvItemId, editStatus, invProductId, productCogs, invPromoProductId, promoProductCogs, conversionRate, whId, doId, locationName,doqty);
            }

        }

       

        private void ControlHide(string Type)
        {
            try
            {
                if (Type == "DO" || Type == "DO_Edit")
                { 
                    pnlVehicleMain.Visible = false;  
                    txtPrice.Visible = true;
                    btnSubmit.Text = "Save Delivery Order";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer Id";
                    dgvSales.Visible = true;
                    dgvSalesPicking.Visible = false;
                    ddlLocation.Visible = false;
                   // lblFgLocation.Visible = false;

                }
                else if (Type == "Picking" || Type == "Picking_Edit")
                {
                    pnlVehicleMain.Visible = true;
                    btnSubmit.Text = "Save Picking";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer";
                    dgvSales.Visible = false;
                    dgvSalesPicking.Visible = true;
                    ddlLocation.Visible = true;
                    txtPrice.Visible = false;
                   // lblFgLocation.Visible = true;

                    txtShipmentCost.Enabled = false;

                }
                else if (Type == "Delivery")
                {
                    pnlLogistic.Visible = true;
                    btnSubmit.Text = "Save Delivery";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer/Picking Id";
                    btnProductAdd.Visible = false;
                    txtProduct.Enabled = false;
                    txtVehicle.Enabled = false;
                    pnlLogistic.Enabled = false;
                    ddlLocation.Visible = true;
                    txtPrice.Visible = false;
                    txtShipmentCost.Enabled = false;
                    // lblFgLocation.Visible = true;
                }
                else if (Type == "Return")
                {
                    pnlLogistic.Visible = false;
                    btnSubmit.Text = "Save Return";
                    lblDoCustId.Visible = false;
                    txtDoNumber.Visible = false;
                    ddlLocation.Visible = true;
                    txtShipmentCost.Enabled = false;
                    // lblFgLocation.Visible = true;
                }
            }
            catch { }

        }

        private void DefaultPageLoad()
        {
            try
            {
                dt = unt.GetUnits(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                ddlUnit.Loads(dt, "intUnitID", "strUnit");
                UnitSelectionChange();

                Session["sesLogisticType"] = rdoVehicleCompany.SelectedItem.ToString();
            }
            catch { }
        }

        private void UnitSelectionChange()
        {
            try
            {
                //dt = vehicle.GetVhlType(ddlUnit.SelectedValue().ToString());
                //ddlVehicleType.Loads(dt, "intTypeId", "strType");

                dt = shipPoint.GetShipPoint(HttpContext.Current.Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue().ToString());
                ddlShipPoint.Loads(dt, "intShipPointId", "strName");

                dt = salesOffice.GetSalesOfficeByShipPoint(ddlShipPoint.SelectedValue().ToString());
                ddlSalesOffice.Loads(dt, "intSalesOfficeId", "strName");

                dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
                ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");
                ddlCustomerType.Items.FindByText("Local").Selected = true;

                dt = salesConfig.GetSalesTypeForDO(ddlUnit.SelectedValue().ToString());
                rdoSalesType.RadioLoad(dt, "intTypeID", "strTypeName");

                rdoSalesType.SelectedIndex = 0;

                dt = currency.GetCurrencyInfo();
                ddlCurrency.Loads(dt, "intID", "strCurrency");
                WareHouseLocation();
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
                Session[SessionParams.CURRENT_SHIP] = ddlShipPoint.SelectedValue().ToString();
               
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
            return SalesSearch_BLL.GetShipToParty(HttpContext.Current.Session["CustomerId"].ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
           if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "DO")
            {
                return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "DO_Edit" )
            {
                return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking" && HttpContext.Current.Session["ReportType"].ToString() == "0")
            {
                return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText); 
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking" && HttpContext.Current.Session["ReportType"].ToString() == "DO_Base")
            {
                return SalesSearch_BLL.GetDoPendingItemByDo(HttpContext.Current.Session["DoId"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking" && HttpContext.Current.Session["ReportType"].ToString() == "Customer_Base")
            {
                return SalesSearch_BLL.GetDoPendingItemByCustomer(HttpContext.Current.Session["CustomerId"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
            }
           else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking_Edit" && int.Parse(HttpContext.Current.Session["CustomerId"].ToString()) > 0)
           {
               return SalesSearch_BLL.GetDoPendingItemByCustomer(HttpContext.Current.Session["CustomerId"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
           }
           else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking_Edit" && int.Parse(HttpContext.Current.Session["DoId"].ToString()) > 0)
           {
               return SalesSearch_BLL.GetDoPendingItemByDo(HttpContext.Current.Session["DoId"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleList(string prefixText, int count)
        {
            if (HttpContext.Current.Session["sesLogisticType"].ToString() == "Company")
            {
                return VehicleSt.GetVehicleDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session["sesLogisticType"].ToString() == "Rent")
            {
                return SalesSearch_BLL.GetRentVehicleList(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session["sesLogisticType"].ToString() == "Customer")
            {
                return SalesSearch_BLL.GetCustomerVehicleList(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
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
                ShipPointSelectionChange(); 
                
            }
            catch { }
        }

        private void SalesOfficeSelectionChange()
        {
            dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
            ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");
            SessionDataSet();
        }

        private void ShipPointSelectionChange()
        {
            dt = salesOffice.GetSalesOfficeByShipPoint(ddlShipPoint.SelectedValue().ToString());
            ddlSalesOffice.Loads(dt, "intSalesOfficeId", "strName");

            dt = customerType.GetCustomerTypeBySOForDO(ddlSalesOffice.SelectedValue().ToString());
            ddlCustomerType.Loads(dt, "intTypeID", "strTypeName");

            WareHouseLocation();
           
            SessionDataSet();
        }

        private void WareHouseLocation()
        {
            try
            {
                dt = deliveryBLL.WareHouseByShipPoint(int.Parse(ddlShipPoint.SelectedValue().ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnWHId.Value = dt.Rows[0]["intWHID"].ToString();
                    hdnWHName.Value = dt.Rows[0]["strWareHoseName"].ToString();
                }

                dt = deliveryBLL.FgWarehouseLocation(Convert.ToInt32(hdnWHId.Value));
                ddlLocation.Loads(dt, "intStoreLocationID", "strLocationName");
            }
            catch { }
        }

        protected void ddlSalesOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SalesOfficeSelectionChange();
                
            }
            catch { }
        }


        protected void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            CustometChange();
        }

        private void CustometChange()
        {
            try
            {
                if (txtCustomer.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
                    string[] temp = txtCustomer.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    hdnCustomer.Value = temp[temp.Length - 1];
                    hdnCustomerText.Value = temp[0];
                    Session["CustomerId"] = hdnCustomer.Value;
                    CustomerTDS.TblCustomerShortDataTable tbl = customerInfo.GetCustomerShortInfoById(hdnCustomer.Value);

                    if (tbl.Rows.Count > 0)
                    {
                        txtCustomerAddress.Text = tbl[0].strAddress;
                        try
                        {
                            hdnPriceId.Value = tbl[0].intPriceCatagory.ToString(); 
                            
                        }
                        catch { };
                    }
                    txtShipToParty.Text = txtCustomer.Text;
                    txtShipToPartyAddress.Text = txtCustomerAddress.Text;
                    hdnShipToPartyId.Value= temp[temp.Length - 1];
                }

               
            }
            catch
            {
            }
        }
        private bool InventoryStockCheck(string productId, string productName, decimal quantity, string promItemId, string promItem, decimal promQnty)
        {
            try
            { 
                decimal productStock = 0, promoStock = 0;

                DataSet ds = new DataSet();
                if (GetXmlFilePath().IsExist())
                {
                    ds.ReadXml(GetXmlFilePath());
                    int i;
                    if (hdnRequistId.Value != "0")
                    {
                        
                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        { 
                            if(productId == promItemId)
                            {
                                if (productId == ds.Tables[0].Rows[i].ItemArray[0].ToString())
                                {

                                    productStock = +decimal.Parse(ds.Tables[0].Rows[i].ItemArray[2].ToString());

                                }
                                if (productId == ds.Tables[0].Rows[i].ItemArray[16].ToString())
                                {
                                    productStock = +productStock + decimal.Parse(ds.Tables[0].Rows[i].ItemArray[23].ToString());
                                }
                            }

                            else
                            {
                                if (promItemId == ds.Tables[0].Rows[i].ItemArray[0].ToString())
                                {

                                    promoStock = +decimal.Parse(ds.Tables[0].Rows[i].ItemArray[2].ToString());
                                }
                                if (promItemId == ds.Tables[0].Rows[i].ItemArray[16].ToString())
                                {

                                    promoStock = +promoStock + decimal.Parse(ds.Tables[0].Rows[i].ItemArray[23].ToString());
                                }
                            }
                               
                        }

                        if (productId == promItemId)
                        {
                          decimal total= productStock +  quantity +  promQnty;
                            if (decimal.Parse(hdnInventoryStock.Value) > total)
                            {
                                _checkItem = true;
                            }
                            else
                            {
                                Toaster(productId + " stock is not avaiable", Common.TosterType.Error);
                                _checkItem = false;
                            }
                        }
                        else
                        {
                            productStock = +quantity;
                            promoStock = +promQnty;
                            if (decimal.Parse(hdnInventoryStock.Value) > productStock)
                            {
                                _checkItem = true;
                            }
                            else
                            {
                                Toaster(productName + " stock is not avaiable", Common.TosterType.Error);
                                _checkItem = false;
                            }
                            if (decimal.Parse(hdnPromoInvStock.Value) > promoStock)
                            {
                                _checkItem = true;
                            }
                            else
                            {
                                Toaster("Promotion Product "+ promItem + " stock is not avaiable", Common.TosterType.Error);
                                _checkItem = false;
                            }

                        }
                        
                    }

                     

                }
            }
            catch (Exception ex)
            {
                btnProductAdd.Visible = true;
                Toaster(ex.Message, Common.TosterType.Error);
                return _checkItem = false;
            }
            return _checkItem;
        }

        private bool CheckXmlItemReqData(string itemid, string doid,string type)
        {
            try
            {
                DataSet ds = new DataSet();
                if (GetXmlFilePath().IsExist())
                {
                    ds.ReadXml(GetXmlFilePath());
                    int i;
                    if (hdnRequistId.Value == "0" || type=="DO_Edit")
                    {
                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                            {
                                _checkItem = true;
                                break;

                            }
                            _checkItem = false;
                        }
                    }

                    else if (type == "Picking" && hdnRequistId.Value != "0")
                    {
                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                            {
                                _checkItem = true;
                                break;

                            }
                            _checkItem = false;
                        }
                    }
                    else if (type == "Picking_Edit" && hdnRequistId.Value != "0")
                    {
                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()) &&
                                doid == (ds.Tables[0].Rows[i].ItemArray[7].ToString()))
                            {
                                _checkItem = true;
                                break;

                            }
                            _checkItem = false;
                        }
                    }


                }
                else
                {
                    return _checkItem = false;
                }

            }
            catch (Exception ex)
            {
                btnProductAdd.Visible = true;
                Toaster(ex.Message, Common.TosterType.Error);
                return _checkItem = false;
            }
            return _checkItem;
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
                    dt = deliveryBLL.ShipToPartyAddress(hdnShipToPartyId.Value);
                    if (dt.Rows.Count > 0)
                    {
                        txtShipToPartyAddress.Text = dt.Rows[0]["strAddress"].ToString();
                    }

                }
            }
            catch { }
        }

        protected void dgvSales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvSales.EditIndex = e.NewEditIndex;

            LoadGridwithXml();

        }

         
        protected void dgvSales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvSales.EditIndex = -1; 
            LoadGridwithXml();
        }

        protected void dgvSales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = dgvSales.Rows[e.RowIndex].DataItemIndex;

            Label lblPrice = dgvSales.Rows[e.RowIndex].FindControl("lblPrice") as Label;

            Label lblqty = dgvSales.Rows[e.RowIndex].FindControl("lblQuantity") as Label;
            Label lblProdutId = dgvSales.Rows[e.RowIndex].FindControl("lblProdutId") as Label;
            Label lblProductName = dgvSales.Rows[e.RowIndex].FindControl("lblProductName") as Label;
             
            TextBox txtQtyEdit = dgvSales.Rows[e.RowIndex].FindControl("txtQtyEdit") as TextBox;
            Label lblUoM = dgvSales.Rows[e.RowIndex].FindControl("lblUoM") as Label;
            Label lblUomId = dgvSales.Rows[e.RowIndex].FindControl("lblUomId") as Label;
            Label lblCommision = dgvSales.Rows[e.RowIndex].FindControl("lblCommision") as Label;
            Label lblnarr = dgvSales.Rows[e.RowIndex].FindControl("lblnarr") as Label; 

            dgvSales.EditIndex = -1;

            LoadGridwithXml();

            DataSet ds = dgvSales.DataSource as DataSet;

            UpdateXml(id, ds, lblProdutId.Text, lblProductName.Text, lblPrice.Text, lblqty.Text, txtQtyEdit.Text, lblUoM.Text, lblUomId.Text, lblCommision.Text, lblnarr.Text, "0", "0", "0");
        }

        private void UpdateXml(int id, DataSet ds, string ProductId, string ProductName, string price,string actualQty, string editQty, string uom, string UomId, string Commision, string narration, string locationId, string locationName, string doId)
        {
            try
            {
                string narr = editQty + " " + uom + " " + ProductName + " Sold";

                if (txtReffNo.Text.Trim() != "")
                {
                    narr += " as per challan no " + txtReffNo.Text.Trim();
                }
                narr += " To " + hdnCustomerText.Value;


                decimal promQnty = 0;
                int promItemId = 0;
                int promItemCOAId = 0;
                int promItemUOM = 0;
                string promItem = "";
                string promUom = "";
                decimal promPrice = 0;
                decimal discount = 0;
                decimal doQuantity = 0;

                if (!PromotionWithDiscount(ProductId, actualQty, editQty, UomId, doId, ref promQnty, ref promItemId,
                    ref promItemCOAId, ref promItemUOM, ref promItem, ref promUom, ref promPrice, ref discount,
                    ref doQuantity))
                {
                    return;
                }
                 

                //if (InventoryFinishedGoodCogs(int.Parse(ProductId), ProductName, decimal.Parse(editQty), promItemId, promItem, promQnty))
                //{
                //    return;
                //}


                decimal discountTotal = discount * decimal.Parse(editQty);
                decimal priceTotal = decimal.Parse(price) * decimal.Parse(editQty);

                ds.Tables[0].Rows[id]["discountTotal"] = discountTotal;
                ds.Tables[0].Rows[id]["priceTotal"] = priceTotal;

                ds.Tables[0].Rows[id]["quantity"] = editQty;

                ds.Tables[0].Rows[id]["promtionItemId"] = promItemId;
                ds.Tables[0].Rows[id]["promtionItem"] = promItem;
                ds.Tables[0].Rows[id]["promtionUom"] = promUom;
                ds.Tables[0].Rows[id]["narration"] = narr;

                ds.Tables[0].Rows[id]["promtionItemCoaId"] = promItemCOAId;
                ds.Tables[0].Rows[id]["promtionQnty"] = promQnty;
                ds.Tables[0].Rows[id]["promtionItemUom"] = promItemUOM;
                ds.Tables[0].Rows[id]["promPrices"] = promPrice;
                ds.Tables[0].Rows[id]["location"] = locationId;
                ds.Tables[0].Rows[id]["locationName"] = locationName;
                ds.Tables[0].Rows[id]["editStatus"] = "1";


                ds.WriteXml(GetXmlFilePath());


                LoadGridwithXml();

            }
            catch { }
        }



        protected void rdoVehicleCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtVehicle.Text = "";
                txtSupplier.Text = "";
                txtDriver.Text = "";
                txtDriverContact.Text = "";
                if (rdoVehicleCompany.SelectedValue.ToString() == "1")
                {
                    pnlVehicle3rd.Visible = false;
                    Session["sesLogisticType"] = "Company";


                }
                else if (rdoVehicleCompany.SelectedValue.ToString() == "2")
                {
                    pnlVehicle3rd.Visible = true;
                    Session["sesLogisticType"] = "Rent";

                }
                else
                {
                    Session["sesLogisticType"] = "Company";
                    pnlVehicle3rd.Visible = false;

                }


            }
            catch (Exception exception)
            {

                throw;
            }
        }

        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            VehicleChange();
        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                InitilizeXmlAddControl(); 

                if (txtProduct.Text.Trim() != "")
                {
                     
                    GetProduct(rdoDeliveryType.SelectedItem.Text);

                    dt = objUom.GetUOMRelationByPrice(hdnProduct.Value, hdnCustomer.Value,
                        hdnPriceId.Value, rdoSalesType.SelectedValue.ToString(),  txtDate.Text.ToString());

                    ddlUOM.Loads(dt, "intID", "strUOM");
                     
                     
                    SetPrice(rdoDeliveryType.SelectedItem.Text);
                    txtQun.Focus();
                }
                else
                {
                    hdnProduct.Value = "";
                }
                
            }
            catch {  }
        }

        
        private void InitilizeXmlAddControl()
        {
            txtQun.Text = "0";
            txtPrice.Text = "0";
            lblTotal.Text = "0";
            lblDiscount.Text = "0";
            ddlUOM.UnLoad();
            hdnProduct.Value = "";
            hdnProductText.Value = "";
            hdnInventoryStock.Value = "0";
            hdnProductCOGS.Value = "0";
            hdnInvItemId.Value = "0";
        }

        private bool  InventoryFinishedGoodCogs(int productId, string productName,decimal quantity, int promItemId,string promItem, decimal promQnty)
        {
            try
            {
                dt = deliveryBLL.InvenotoryStockByItem(productId, promItemId, hdnWHId.Value);
                if (dt.Rows.Count > 0)
                {
                    DataRow[] drProduct = dt.Select("intSADItemID=" + productId);
                    DataRow[] drPromoProduct = dt.Select("intSADItemID=" + promItemId);

                    foreach (DataRow row in drProduct)
                    {

                        hdnInvItemId.Value = row["intItemId"].ToString();
                        hdnInventoryStock.Value = row["numQuantity"].ToString();
                        hdnProductCOGS.Value = row["monCOGS"].ToString();
                    }
                    foreach (DataRow row in drPromoProduct)
                    {

                        hdnPromoInvItemId.Value = row["intItemId"].ToString();
                        hdnPromoInvStock.Value = row["numQuantity"].ToString();
                        hdnPromoCogs.Value = row["monCOGS"].ToString();
                    }
                }
                else
                {
                    // Toaster(productName + " is not bridge", Common.TosterType.Error);
                    //return false;
                }

                hdnPromoInvItemId.Value = "300";
                hdnInventoryStock.Value = "300";
                if (!InventoryStockCheck(productId.ToString(), productName, quantity, promItemId.ToString(), promItem, promQnty))
                {
                    return false;
                }

              
            }
            catch { }
            return true;
            //if (decimal.Parse(hdnInventoryStock.Value)>quantity)
            //{ 
            //    Toaster(productName+" Stock is not avaiable", Common.TosterType.Error);
            //    return false ; 
            //}
            //else if(decimal.Parse(hdnProductCOGS.Value) > 0)
            //{
            //    Toaster(productName + " set COGS Value.", Common.TosterType.Error);
               
            //    return false;
            //}
            //else if (decimal.Parse(hdnPromoInvStock.Value) > promQnty)
            //{
            //    Toaster("Promotion Item "+ promItem + " Stock is not avaiable", Common.TosterType.Error);
               
            //    return false;

            //}
            //else if (decimal.Parse(hdnPromoCogs.Value) > 0)
            //{
            //    Toaster("Promotion Item "+ promItem + " set COGS.", Common.TosterType.Error);
            //    Toaster("", Common.TosterType.Error);
            //    return false;
            //}
            //else
            //{
                
            //    return true;
            //}
            
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && dgvSalesPicking.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlFGlocation = (DropDownList)e.Row.FindControl("ddlFGlocation");
                Label lblLocationId = (Label)e.Row.FindControl("lblLocationId");
                dt = deliveryBLL.FgWarehouseLocation(int.Parse(hdnWHId.Value));

                ddlFGlocation.DataSource = dt;
                ddlFGlocation.DataTextField = "strLocationName";
                ddlFGlocation.DataValueField = "intStoreLocationID";
                ddlFGlocation.DataBind();
                //string selectedCity = DataBinder.Eval(e.Row.DataItem, "City").ToString();
                ddlFGlocation.Items.FindByValue(lblLocationId.Text).Selected = true;
                         
                    
            }
        }

        protected void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (hdnButtonFire.Value =="true")
            {
                ProductAdd(rdoDeliveryType.SelectedItem.ToString());
            }
            
        }

        private void ProductAdd(string type)
        {
            try
            {
                btnProductAdd.Visible = false;

                if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnCustomer.Value != "" && hdnProduct.Value != "" &&
                decimal.Parse(txtPrice.Text) > 0 && decimal.Parse(txtQun.Text.ToString()) > 0)
                {

                    string coaId = "";
                    string coaName = "";
                    decimal lm = 0, bl = 0;
                    customerInfo.GetCustomerCreditLimitCreditBalance(hdnCustomer.Value, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);

                    item.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, rdoSalesType.SelectedValue, ref coaId, ref coaName);

                    if (int.Parse(coaId) > 0)
                    {
                        string narr = txtQun.Text.Trim() + " " + ddlUOM.SelectedItem.Text + " " + hdnProductText.Value + " Sold";

                        if (txtReffNo.Text.Trim() != "")
                        {
                            narr += " as per challan no " + txtReffNo.Text.Trim();
                        }
                        narr += " To " + hdnCustomerText.Value;


                        decimal promQnty = 0;
                        int promItemId = 0;
                        int promItemCOAId = 0;
                        int promItemUOM = 0;
                        string promItem = "0";
                        string promUom = "0";
                        decimal promPrice = 0;
                        decimal discounts = 0;
                        decimal doQuantity = 0;



                        string productId = hdnProduct.Value;
                        string productName = hdnProductText.Value;
                        string quantity = txtQun.Text.ToString();
                        string uomId = ddlUOM.SelectedValue().ToString();

                        PromotionWithDiscount(productId, quantity,"0", uomId,hdnDoId.Value, ref promQnty, ref promItemId, ref promItemCOAId, ref promItemUOM, ref promItem, ref promUom, ref promPrice, ref discounts,ref   doQuantity);

                        string invProductId = hdnInvItemId.Value;
                        string productCogs = hdnProductCOGS.Value;
                        string rate = txtPrice.Text;
                      
                        string uomName = ddlUOM.SelectedItem.ToString();
                        string narration = narr;
                        string currency = ddlCurrency.SelectedValue().ToString();
                        string commision = discounts.ToString();
                        string commisionTotal = (discounts * decimal.Parse(txtQun.Text.ToString())).ToString();
                        string conversionRate = txtConvRate.Text.ToString();
                        string discount = discounts.ToString();
                        decimal discountTotal = decimal.Parse(lblDiscount.Text.ToString()) * decimal.Parse(txtQun.Text.ToString());
                        decimal priceTotal = decimal.Parse(txtPrice.Text.ToString()) * decimal.Parse(txtQun.Text.ToString());
                        string supplierTax = hdnSuppTax.Value;
                        string vat = hdnVat.Value;
                        string vatPrice = hdnVatPrice.Value;
                        string promtionItemId = promItemId.ToString();
                        string invPromoProductId = hdnPromoInvItemId.Value;
                        string promoProductCogs = hdnPromoCogs.Value;
                        string promtionItem = promItem.ToString();
                        string promtionUom = promUom.ToString();
                        string promPrices = promPrice.ToString();
                        string promtionItemCoaId = promItemCOAId.ToString();
                        string promtionQnty = promQnty.ToString();
                        string promtionItemUom = promItemUOM.ToString();
                        string location = ddlLocation.SelectedValue().ToString();
                        string locationName = ddlLocation.SelectedItem.ToString();
                        string intInvItemId = hdnInvItemId.Value;
                        string editStatus = "0";
                        string doId = hdnDoId.Value;
                        string doqty= hdnDoQty.Value;


                        try { location = ddlLocation.SelectedItem.Value; }
                        catch { location = "0"; }
                        string whId = hdnWHId.Value;
                        string whName = hdnWHName.Value;


                        if (CheckXmlItemReqData(productId, doId, rdoDeliveryType.SelectedItem.ToString()))
                        {
                            Toaster("Can not add same product  duplicate.", hdnDelivery.Value, Common.TosterType.Error);
                            LoadGridwithXml();
                            btnProductAdd.Visible = true;
                            return;
                        }

                        //if (InventoryFinishedGoodCogs(int.Parse(hdnProduct.Value), hdnProductText.Value, decimal.Parse(quantity), promItemId, promItem, promQnty))
                        //{
                        //   return;
                        //}

                        RowLavelXmlCreate(productId, productName, quantity, rate, uomId, uomName,
                          narration, currency, commision, commisionTotal, discount, discountTotal.ToString(),
                          priceTotal.ToString(), supplierTax, vat, vatPrice, promtionItemId, promtionItem, promPrices,
                          promtionUom, coaId, coaName, promtionItemCoaId, promtionQnty, promtionItemUom, location,
                          intInvItemId, editStatus, invProductId, productCogs, invPromoProductId, promoProductCogs, conversionRate, whId, doId, locationName, doqty);
                        btnProductAdd.Visible = true;
                        txtProduct.Text = "";
                        InitilizeXmlAddControl();

                        txtProduct.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                btnProductAdd.Visible = true;
                ex.ToString();

            }
        }

        private bool GridViewDuplicatedDataCheck(GridView dgvGrid, string productId,string ProductName)
        {
            for (var i = 0; i < dgvGrid.Rows.Count; i++)
            {
                Label lblproductID = dgvGrid.Rows[i].FindControl("lblProdutId") as Label;
                Label lblqty = dgvGrid.Rows[i].FindControl("lblqty") as Label;
                Label lblpromtionQnty = dgvGrid.Rows[i].FindControl("lblpromtionQnty") as Label;

                if (lblproductID.Text == productId)
                {

                    Toaster("Can not add same product Name " + ProductName + " duplicate.", "", Common.TosterType.Error);

                    return true;
                }
            }
            return false;
        }

        protected string GetTotal(string priceTotal, string discountTotal)
        {
            decimal tot = (decimal.Parse(priceTotal) - decimal.Parse(discountTotal));
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetPriceTotal(string priceTotal, string discountTotal)
        {
            decimal tot = (decimal.Parse(priceTotal) * decimal.Parse(discountTotal));
            return CommonClass.GetFormettingNumber(tot);
        }
        
        private void RowLavelXmlCreate(string productId, string productName, string quantity, string rate, string uomId,
            string uomName, string narration, string currency, string commision, string commisionTotal, string discount,
            string discountTotal, string priceTotal, string supplierTax, string vat, string vatPrice,  string promtionItemId,
            string promtionItem, string promPrices,string promtionUom,string coaId,string coaName, string promtionItemCoaId, string promtionQnty,
            string promtionItemUom,   string location ,string intInvItemId,string editStatus, string invProductId,
            string productCogs, string invPromoProductId, string promoProductCogs,string conversionRate, string whId,string doId,string locationName,string doqty)
        {
            try
            {
                var xDoc = XDocument.Load(GetXmlFilePath());
                xmlSerial = xDoc.Descendants("items").Count();
            }
            catch
            {
                xmlSerial = 1;
                
            }
           
             
            dynamic obj = new
            {
                productId,
                productName,
                quantity,
                rate,
                uomId,
                uomName,
                narration,
                currency,
                commision,
                commisionTotal,
                discount,
                discountTotal,
                priceTotal,
                supplierTax,
                vat,
                vatPrice,
                promtionItemId,
                promtionItem,
                promPrices,
                promtionUom,
                coaId,
                coaName,
                promtionItemCoaId,
                promtionQnty,
                promtionItemUom, 
                location,
                intInvItemId,
                editStatus,
                invProductId,
                productCogs,
                invPromoProductId,
                promoProductCogs,
                conversionRate,
                whId,
                doId,
                serialId= xmlSerial + 1,
                locationName,
                doqty
            };
             
            XmlParser.CreateXml("Delivery", "items", obj, GetXmlFilePath(), out message);
          //  string xmlString = XmlParser.GetXml(GetXmlFilePath()); //"Entry", "items", objects, out message
          
            LoadGridwithXml();
        }

 
        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               
                 LoadGridwithXml();

                DataSet dsGrid = (DataSet)dgvSales.DataSource;
                dsGrid.Tables[0].Rows[dgvSales.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(GetXmlFilePath());
                DataSet dsGridAfterDelete = (DataSet)dgvSales.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(GetXmlFilePath());
                    dgvSales.UnLoad();
                }
                else
                {
                    
                    LoadGridwithXml();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            
        }

       

        private void LoadGridwithXml()
        {
            try
            {
                string itemXML = XmlParser.GetXml(GetXmlFilePath());
                if (rdoDeliveryType.SelectedItem.ToString() == "Picking" || rdoDeliveryType.SelectedItem.ToString() == "Picking_Edit" || rdoDeliveryType.SelectedItem.ToString() == "Delivery")
                {
                    GridViewUtil.LoadGridwithXml(itemXML, dgvSalesPicking, out string message);
                }
                else if (rdoDeliveryType.SelectedItem.ToString() == "DO" || rdoDeliveryType.SelectedItem.ToString() == "DO_Edit")
                {
                    GridViewUtil.LoadGridwithXml(itemXML, dgvSales, out string message);
                }
            }
            catch { }
           
           
        }


        private void GetProduct(string type)
        {
            if (hdnRequistId.Value=="0" || type == "DO_Edit")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnProduct.Value = temp[temp.Length - 1];
                hdnProductText.Value = temp[0];
            }
           
            else if (type == "Picking" || type == "Picking_Edit")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnDoId.Value = temp[1];
                hdnProductText.Value = temp[0];
                hdnProduct.Value = temp[3];
            }
           

        }
        protected void btnProductAddAll_Click(object sender, EventArgs e) 
        {
            if (hdnButtonFire.Value == "true")
            {
                try { File.Delete(GetXmlFilePath()); } catch { }
                DoGridDataBind(hdnDoId.Value);

            }
           
        }

        protected void ddlCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SessionDataSet();
        }

        private void SetPrice(string type)
        {
            if (hdnProduct.Value != "")
            {
                decimal commission = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;
                decimal convRate = 0;
                decimal productRate = 0;
              
 
                if (hdnRequistId.Value=="0" || type=="DO_Edit")
                {
                    productRate = itemPrice.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                  , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);
                    
                    dt = deliveryBLL.GetDiscount(hdnCustomer.Value, hdnProduct.Value);
                    if (dt.Rows.Count>0)
                    {
                        commission = decimal.Parse(dt.Rows[0]["Amount"].ToString());
                    }
                }
                else if (type=="Picking" || type == "Picking_Edit")
                {
                    dt=deliveryBLL.DeliveryOrderItemPriceByDo(int.Parse(hdnDoId.Value), int.Parse(hdnProduct.Value));
                    if (dt.Rows.Count > 0)
                    {
                        productRate= decimal.Parse(dt.Rows[0]["monPrice"].ToString());
                        commission =decimal.Parse(dt.Rows[0]["monCommission"].ToString());
                        convRate = decimal.Parse(dt.Rows[0]["monConversionRate"].ToString());
                        vat = decimal.Parse(dt.Rows[0]["monVAT"].ToString());
                        vatPrice = decimal.Parse(dt.Rows[0]["monVatPrice"].ToString());
                        suppTax = decimal.Parse(dt.Rows[0]["monSuppTax"].ToString());
                        txtQun.Text=dt.Rows[0]["numRestQuantity"].ToString();
                        lblTotal.Text = (decimal.Parse(dt.Rows[0]["numRestQuantity"].ToString()) * productRate).ToString("N2"); 
                        hdnDoQty.Value= dt.Rows[0]["numRestQuantity"].ToString();
                      
                    }
                    hdnPrice.Value = productRate.ToString();
                }
              

                // hdnvisibility.Value = objbll.GetVisibility(int.Parse(hdnProduct.Value)).ToString();
                PriceSetWithCommonFormat(productRate, commission, suppTax, vat, vatPrice, convRate);
                if (productRate <= 0)
                {
                    btnProductAdd.Enabled = false;
                }
                else
                {
                    btnProductAdd.Enabled = true;
                }

            }

            else
            {
                PriceInitialize();

            }
        }

        private void PriceSetWithCommonFormat(decimal productRate, decimal commission, decimal suppTax, decimal vat, decimal vatPrice, decimal convRate)
        {
            try
            {
                txtPrice.Text = CommonClass.GetFormettingNumber(productRate);
                lblDiscount.Text = CommonClass.GetFormettingNumber(commission);
                hdnSuppTax.Value = CommonClass.GetFormettingNumber(suppTax);
                hdnVat.Value = CommonClass.GetFormettingNumber(vat);
                hdnVatPrice.Value = CommonClass.GetFormettingNumber(vatPrice);
                txtConvRate.Text = CommonClass.GetFormettingNumber(convRate);
            }
            catch { }
        }

        private void PriceInitialize()
        {
            txtPrice.Text = "0.0";
            lblDiscount.Text = "0.0";
            hdnSuppTax.Value = "0.0";
            hdnVat.Value = "0.0";
            hdnVatPrice.Value = "0.0";
        }
        private string GetXmlFilePath()
        {
            string unit = "";
            unit = "" + hdnUnit.Value;
            if (unit == "") unit = ddlUnit.SelectedValue;
            _filePathForXml = Server.MapPath("~/SAD/Delivery/Data/Sales__" + Enroll + ".xml");
            return _filePathForXml;
        }
        protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice(rdoDeliveryType.SelectedItem.Text);
        }
        private bool PromotionWithDiscount(string productId, string productQty,string editQty,string uomId,string doId, ref decimal promQnty, ref int promItemId, ref int promItemCOAId, ref int promItemUOM, ref string promItem, ref string promUom, ref decimal promPrice, ref decimal discount,ref decimal doQuantity)
        {
            bool isCheck=true;
            if (hdnRequistId.Value == "0" || hdnDelivery.Value == "DO_Edit")
            {
                promPrice = itemPromotion.GetPromotion(productId, hdnCustomer.Value, hdnPriceId.Value, uomId, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
               , productQty, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);

                dt = deliveryBLL.GetDiscount(hdnCustomer.Value, productId);
                if (dt.Rows.Count > 0)
                {
                    discount = decimal.Parse(dt.Rows[0]["Amount"].ToString());
                }
                doQuantity = 0;
                isCheck = true;
            }
            else if (hdnDelivery.Value == "Picking" || hdnDelivery.Value == "Picking_Edit")
            {
                dt = deliveryBLL.DeliveryOrderItemPriceByDo(int.Parse(doId), int.Parse(productId));
                if (dt.Rows.Count > 0)
                {
                    promQnty = decimal.Parse(dt.Rows[0]["numPromotion"].ToString());
                    promItemId = int.Parse(dt.Rows[0]["intPromItemId"].ToString());
                    promItemCOAId = int.Parse(dt.Rows[0]["intPromItemCOAId"].ToString());
                    promItemUOM = int.Parse(dt.Rows[0]["intPromUOM"].ToString());
                    promItem = dt.Rows[0]["strPromItemName"].ToString();
                    promPrice = decimal.Parse(dt.Rows[0]["monPromPrice"].ToString());
                    promUom = dt.Rows[0]["intPromUOM"].ToString();
                    discount = decimal.Parse(dt.Rows[0]["decDiscountRate"].ToString());
                    doQuantity = decimal.Parse(dt.Rows[0]["monRemainQty"].ToString());

                    if (decimal.Parse(productQty) + doQuantity < decimal.Parse(editQty) && decimal.Parse(productQty)>0)
                    {
                        Toaster("Delivery Order quantiy and Picking quantity mismatch", hdnDelivery.Value, Common.TosterType.Error);
                        isCheck = false;
                    }
                    else if (doQuantity < decimal.Parse(productQty) && decimal.Parse(editQty) == 0)
                    {
                        Toaster("Delivery Order quantiy and Picking quantity mismatch", hdnDelivery.Value,
                            Common.TosterType.Error);
                        isCheck = false;
                    }
                    else
                    {
                        isCheck = true;
                    }
                   
                     
                }
                else
                {
                    isCheck = false;
                }
               
            }

         
            return isCheck;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = false; 
            try
            { 
                HeaderXmlCreate();
                string rowXml = XmlParser.GetXml(GetXmlFilePath());
                try { File.Delete(GetXmlFilePath()); } catch { }
                
                string strOrderId = "", Code = "", msg = "";

                if (hdnConfirm.Value == "1")
                {
                    if (rdoDeliveryType.SelectedItem.Text.ToString() == "DO")
                    {

                        msg = deliveryBLL.DeliveryOrderCreate(xmlHeaderString, rowXml, ref strOrderId, ref Code);
                        Toaster(msg + " Code:" + Code, "Delivery Order",Common.TosterType.Success);
                    }
                    else if (rdoDeliveryType.SelectedItem.Text.ToString() == "Picking")
                    {
                        msg = deliveryBLL.PickingCreate(xmlHeaderString, rowXml, txtCustomerAddress.Text,
                            ref strOrderId, ref Code);
                        Toaster(msg + " Code:" + Code, "Picking Create", Common.TosterType.Success);
                    }
                    else if (rdoDeliveryType.SelectedItem.Text.ToString() == "Picking_Edit")
                    {
                        msg = deliveryBLL.PickingUpdate(xmlHeaderString, rowXml,int.Parse(hdnPickingId.Value));
                        Toaster(msg + " Code:" + Code, "Picking Updater", Common.TosterType.Success);
                        btnSubmit.Visible = false;

                    }
                    else if (rdoDeliveryType.SelectedItem.Text.ToString() == "Delivery")
                    {
                        msg = deliveryBLL.DeliveryEntry(  hdnPickingId.Value, ref Code);
                        Toaster(msg + " Code:" + Code, "Delivery", Common.TosterType.Success);
                        btnSubmit.Visible = false;
                    }
                    else if (rdoDeliveryType.SelectedItem.Text.ToString() == "DO_Edit")
                    {
                        msg = deliveryBLL.UpdateDeliveryOrder(xmlHeaderString, rowXml, int.Parse(hdnDoId.Value));
                        Toaster(msg + " Code:" + Code, "Delivery Order Edit", Common.TosterType.Success);
                        btnSubmit.Visible = false;
                        btnProductAddAlls.Visible = false;
                        txtProduct.Visible = false;

                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "window.close()", true);
                    }

                  

                    lblCodeText.Visible = true;
                    lblCode.Text = Code;
                    lblOrderIDText.Visible = true;
                    lblOrderId.Text = strOrderId;
                    
                        dgvSales.DataSource = "";
                        dgvSales.DataBind();
                        dgvSalesPicking.DataSource = "";
                        dgvSalesPicking.DataBind();
                        txtCustomer.Text = "";
                        txtShipToParty.Text = "";
                        txtCustomerAddress.Text = "";
                        txtShipToPartyAddress.Text = "";
                        txtVehicle.Text = "";
                        txtDriver.Text = "";
                        txtSupplier.Text = "";
                   
                }
                else
                {
                    Toaster("Data not submitted", Common.TosterType.Warning);
                }
                btnSubmit.Visible = true;
            }
            catch
            {
                btnSubmit.Visible = false;
            }


        }

        private void HeaderXmlCreate()
        {
            string unit = ddlUnit.SelectedValue;
            string shipPoint = ddlShipPoint.SelectedValue;
            string salesOffice = ddlSalesOffice.SelectedValue;
            string customerType = ddlCustomerType.SelectedValue;
            string date = txtDate.Text;
            string dueDate = txtDueDate.Text;
            string customerId = hdnCustomer.Value;
            string shipPartyId = hdnShipToPartyId.Value;
            string salesType = rdoSalesType.SelectedItem.Value;
            string reffNo = txtReffNo.Text;
            string customerAddress = txtCustomerAddress.Text;
            string shipToPartyAddress = txtShipToPartyAddress.Text;
            string currency = ddlCurrency.SelectedValue;
            string
                vehicleId = hdnVehicle.Value,
                vehicleText = hdnVehicleText.Value,
                driver = txtDriver.Text,
                driverContact = txtDriverContact.Text,
                supplierId = hdnSupplierId.Value,
                supplierName = hdnSupplierName.Value,
                vehicleProviderName = rdoVehicleCompany.SelectedValue.ToString(),
                vehicleProviderId = rdoVehicleCompany.SelectedValue.ToString(),
                shipmentCost = txtShipmentCost.Text;
            

            BindHeaderXML(Enroll.ToString(), unit, shipPoint, salesOffice, customerType, date, dueDate, customerId, shipPartyId, salesType, reffNo, customerAddress, shipToPartyAddress, hdnnarration.Value, currency, vehicleId, vehicleText, driver, driverContact, supplierId, supplierName, vehicleProviderName, vehicleProviderId, shipmentCost);
        }

        private string BindHeaderXML(string userId,string unitId, string shipPointId, string salesOfficeId, string customerType, string date, string dueDate, string customerId, string shipPartyId, string salesType, 
            string reffNo, string customerAddress, string shipToPartyAddress,string narration, string currencyId,   string vehicleId,string vehicleName, string driver,
            string driverContact, string supplierId,string supplierName,string vehicleProviderName,string vehicleProviderId,string shipmentCost)
        {
            dynamic obj = new
            {
                userId,
                unitId,
                shipPointId,
                salesOfficeId,
                customerType,
                date,
                dueDate,
                customerId,
                shipPartyId,
                salesType,
                reffNo,
                customerAddress,
                shipToPartyAddress,
                narration,
                currencyId, 
                vehicleId,
                vehicleName,
                driver,
                driverContact,
                supplierId,
                supplierName,
                vehicleProviderName,
                vehicleProviderId,
                shipmentCost

            };
            List<object> objects = new List<object>();

            objects.Add(obj);

            xmlHeaderString = XmlParser.GetXml("DeliveryEntry", "items", objects, out message);

            return xmlHeaderString;

        }
        private string BindDOHeaderXML(string userId,string unit, string shipPoint, string salesOffice, string customerType, string date, string dueDate, string customerId, string shipPartyId, string salesType, string reffNo, string customerAddress, string shipToPartyAddress,string narration, string currency, string conversionRate)
        {
            dynamic obj = new
            {
                userId,
                unit,
                shipPoint,
                salesOffice,
                customerType,
                date,
                dueDate,
                customerId,
                shipPartyId,
                salesType,
                reffNo,
                customerAddress,
                shipToPartyAddress,
                narration,
                currency,
                conversionRate,
            };
            List<object> objects = new List<object>(); 
            objects.Add(obj);

            xmlHeaderString = XmlParser.GetXml("DeliveryEntry", "items", objects, out message);

            return xmlHeaderString;

        }

        protected void txtQun_TextChanged(object sender, EventArgs e)
        {
           if (hdnButtonFire.Value == "true")
            {
                ProductAdd(rdoDeliveryType.SelectedItem.Text);

            }
           
            hdnButtonFire.Value = "false";
        }
         
       
        protected void rdoDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlHide(rdoDeliveryType.SelectedItem.ToString());
        }

        protected void dgvSalesPicking_RowEditing(object sender, GridViewEditEventArgs e)
        {
             dgvSalesPicking.EditIndex= e.NewEditIndex;
            LoadGridwithXml();
        }

        protected void dgvSalesPicking_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvSalesPicking.EditIndex = -1;
            LoadGridwithXml();
        }

        protected void dgvSalesPicking_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = dgvSalesPicking.Rows[e.RowIndex].DataItemIndex;

            Label lblPrice = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblPrice") as Label;

            Label lblProdutId = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblProdutId") as Label;
            Label lblProductName = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblProductName") as Label;
            Label lblqty = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblQuantitys") as Label;
            TextBox txtQtyEdit = dgvSalesPicking.Rows[e.RowIndex].FindControl("txtQtyEdits") as TextBox;
            DropDownList ddlFGlocation = dgvSalesPicking.Rows[e.RowIndex].FindControl("ddlFGlocation") as DropDownList;
            Label lblUoM = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblUoM") as Label;
            Label lblUomId = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblUomId") as Label;
            Label lblCommision = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblcommision") as Label;
            Label lblnarr = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblnarr") as Label;
            Label lblDoId = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblDoId") as Label;


            dgvSalesPicking.EditIndex = -1;

            LoadGridwithXml();

            DataSet ds = dgvSalesPicking.DataSource as DataSet;

            UpdateXml(id, ds, lblProdutId.Text, lblProductName.Text, lblPrice.Text, lblqty.Text, txtQtyEdit.Text, lblUoM.Text, lblUomId.Text, lblCommision.Text, lblnarr.Text, ddlFGlocation.SelectedValue().ToString(), ddlFGlocation.SelectedItem.Text, lblDoId.Text);
        }

        protected void dgvSalesPicking_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LoadGridwithXml();

            DataSet dsGrid = (DataSet)dgvSalesPicking.DataSource;
            dsGrid.Tables[0].Rows[dgvSalesPicking.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(GetXmlFilePath());
            DataSet dsGridAfterDelete = (DataSet)dgvSalesPicking.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            {
                File.Delete(GetXmlFilePath());
                dgvSalesPicking.UnLoad();
            }
            else
            {

                LoadGridwithXml();
            }
        }

        protected void btnPickingUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            TextBox txtqty = row.FindControl("txtQtyEdit") as TextBox;
            string quantity = txtqty.Text;



        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplier.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtSupplier.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnSupplierId.Value = temp[temp.Length - 1];
                hdnSupplierName.Value = temp[0];
            }
        }

        protected void dgvSales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdoSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQun.Text = "0";
            hdnProduct.Value = "";
            txtPrice.Text = "0.00";
            txtProduct.Text = "";
            txtProduct.Focus();
            ddlUOM.SelectedItem.Text = "";
            dgvSales.DataSource = null;
            dgvSales.DataBind();
        }

        private void VehicleChange()
        {

            if (txtVehicle.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string dName = "";
                    string dContact = "";
                    hdnVehicle.Value = temp[temp.Length - 1];
                    vehicle.GetVehicleInfoById(hdnVehicle.Value, ref dName, ref dContact);
                    txtDriver.Text = dName;
                    txtDriverContact.Text = dContact;
                    hdnVehicleText.Value = temp[0];
                }
                catch
                {
                    hdnVehicle.Value = "";
                } 
            }
            else
            {
                hdnVehicleText.Value = ""; //txtVehicle.Text.Trim();
                hdnVehicle.Value = "";
            }
        }
    }
}