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
using System.Xml;
using System.IO;

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
        ItemPrice itemPrice= new ItemPrice();
        ItemPromotion itemPromotion = new ItemPromotion();
        SAD_BLL.Item.Item item = new SAD_BLL.Item.Item();
     

        DataTable dt = new DataTable();
        Vehicle vehicle=new Vehicle();
        XmlManager xm = new XmlManager();

        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());
                DefaultPageLoad();
               
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Session[SessionParams.SalesProcess] = ddlUnit.SelectedValue().ToString();
                Session["RowObj"] = null;
                Session["HeadObj"] = null;

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
                dt = vehicle.GetVhlType(ddlUnit.SelectedValue().ToString());
                //ddlVehicleType.Loads(dt, "intTypeId", "strType");

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
            if (HttpContext.Current.Session["sesLogisticType"].ToString() =="Company")
            {
                return VehicleSt.GetVehicleDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session["sesLogisticType"].ToString() == "Rent")
            {
                return VehicleSt.GetVehicleDataForAutoFillParty(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session["sesLogisticType"].ToString() == "Customer")
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
                        hdnPriceId.Value = tbl[0].intPriceCatagory.ToString();
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
                    pnlVehicleMain.Visible = true;


                }
                else if (rdoNeedVehicle.SelectedValue.ToString() == "2")
                {
                    pnlVehicle3rd.Visible = false;
                    pnlVehicleMain.Visible = false;

                }
                else
                {
                    pnlVehicle3rd.Visible = false;
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
                    dt = objUom.GetUOMRelationByPrice(hdnProduct.Value, hdnCustomer.Value,
                         hdnPriceId.Value, rdoSalesType.SelectedValue.ToString(), txtDate.Text.ToString());
                    ddlUOM.Loads(dt, "intID", "strUOM");
                    txtQun.Text ="0";

                    SetPrice();
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
            BLL.Accounts.Voucher.Budget bdg = new BLL.Accounts.Voucher.Budget(); DataTable strtdt = new DataTable();
            DateTime gdt = CommonClass.GetDateAtSQLDateFormat(txtDate.Text);
            strtdt = bdg.GetAccountsStartDate(int.Parse(ddlUnit.SelectedValue.ToString()));
            DateTime pdt = DateTime.Parse(strtdt.Rows[0]["StartDate"].ToString());
            int rest = DateTime.Compare(gdt, pdt);

            if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnCustomer.Value != "" && hdnProduct.Value != "" &&
            decimal.Parse(txtPrice.Text) > 0 && txtQun.Text.Trim() != "" && rest >= 0) 
            {

                string coaId = "";
                string coaName = "";
                decimal lm = 0, bl = 0;
                customerInfo.GetCustomerCreditLimitCreditBalance(hdnCustomer.Value, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);

                item.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, rdoSalesType.SelectedValue, ref coaId, ref coaName);

                if (int.Parse(coaId)>0)
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
                    string promItem = "";
                    string promUom = ""; 

                    decimal promPrice = itemPromotion.GetPromotion(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                        , txtQun.Text, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);

                  
                    string productId = hdnProduct.Value;
                    string productName = hdnProductText.Value;
                    string quantity = txtQun.Text.ToString();
                    string rate = txtPrice.Text;
                    string uomId = ddlUOM.SelectedValue().ToString();
                    string uomName = ddlUOM.SelectedItem.ToString();
                    string naration = "";
                    string currency = ddlCurrency.SelectedValue().ToString();
                    string commision = lblComm.Text.ToString();
                    string commisionTotal = lblComm.Text.ToString();
                    string discount = "0";
                    string discountTotal = "0";
                    string priceTotal = "0";
                    string supplierTax = hdnSuppTax.Value;
                    string vat = hdnVat.Value;
                    string vatPrice = hdnVatPrice.Value;
                    string promtionItemId = promItemId.ToString();
                    string promtionItem = promItem.ToString();
                    string promtionUom = promUom;
                    string promPrices = promPrice.ToString();
                    string promtionItemCoaId = promItemCOAId.ToString();
                    string promtionQnty = promQnty.ToString();
                    string promtionItemUom = promUom.ToString();

                    foreach (GridViewRow row in dgvSales.Rows)
                    {
                        if (((Label)row.FindControl("lblProdutId")).Text == productId)
                        {
                            Toaster("Can not add same product Name " + productName + " dublicate.", "", Common.TosterType.Error);

                            return;
                        }

                    }

                    RowLavelXmlCreate(productId, productName, quantity, rate, uomId, uomName,
                        naration, currency, commision, commisionTotal, discount, discountTotal,
                        priceTotal, supplierTax, vat, vatPrice, narr, promtionItemId, promtionItem,
                        promtionUom, promtionItemCoaId, promtionQnty, promtionItemUom);
                         
                    txtQun.Text = ""; 
                    hdnProduct.Value = "";
                    txtPrice.Visible = true;
                    txtProduct.Text = "";
                    txtProduct.Focus(); 
                }
            }


        }

        private void RowLavelXmlCreate(string productId, string productName, string quantity, string rate, string uomId,
            string uomName,string naration, string currency, string commision, string commisionTotal, string discount,
            string discountTotal,string priceTotal, string supplierTax, string vat, string vatPrice, string narr, string promtionItemId,
            string promtionItem,  string promtionUom, string promtionItemCoaId,     string promtionQnty, string promtionItemUom)
        {
           

            dynamic obj = new
            {
                productId,
                productName,
                quantity,
                rate,
                uomId,
                uomName,
                naration,
                currency,
                commision,
                commisionTotal,
                discount,
                discountTotal,
                priceTotal,
                supplierTax,
                vat,
                vatPrice,
                narr,
                promtionItemId,
                promtionItem,
                promtionUom,
                promtionItemCoaId,
                promtionQnty,
                promtionItemUom,

            };

            List<object> objects = new List<object>();
            if (Session["RowObj"] != null)
            {
                objects = (List<object>)Session["rowObj"];
            }
            objects.Add(obj);
            Session["rowObj"] = objects;

            string xmlString = XmlParser.GetXml("Entry", "items", objects, out message);
            LoadGridwithXml(xmlString, dgvSales);
        }
        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (Session["rowObj"] != null)
                {
                    List<object> objects = (List<object>)Session["rowObj"];
                    objects.RemoveAt(e.RowIndex);
                    if (objects.Count > 0)
                    {
                        string xmlString = XmlParser.GetXml("Entry", "items", objects, out string message);
                        LoadGridwithXml(xmlString, dgvSales);
                    }
                    else
                    {
                        dgvSales.UnLoad();
                    }
                }
                else
                {
                    dgvSales.UnLoad();
                }

            }
            catch { }
        }

        private void ListObjectUpdate(object data ,decimal newValue)
        {
            List<object> objects = (List<object>)Session["rowObj"];
            
          
        }
        private void LoadGridwithXml(string xmlString, GridView gridView)
        {
            GridViewUtil.LoadGridwithXml(xmlString, gridView, out string message);
        }

        private void GetChallanNo()
        {
            string startNo, endNo = "", leftPart = "", tmp = "";
            int lastUsedNum;

            if (txtReffNo.Text != "")
            {
                if ("" + Session["sesChlnNo"] == "" && txtReffNo.Text != "")
                {
                    Session["sesChlnNo"] = txtReffNo.Text;
                }

                startNo = Session["sesChlnNo"].ToString();

                for (int i = startNo.Length - 1; i >= 0; i--)
                {
                    if (startNo[i] >= 48 && startNo[i] <= 57)
                    {
                        tmp += startNo[i].ToString();
                    }
                    else
                    {
                        break;
                    }
                }

                if (tmp.Length > 0)
                {
                    for (int i = tmp.Length - 1; i >= 0; i--)
                    {
                        endNo += tmp[i].ToString();
                    }


                    leftPart = startNo.Substring(0, startNo.IndexOf(endNo));

                    lastUsedNum = int.Parse(endNo) + 1;

                    Session["sesChlnNo"] = leftPart + lastUsedNum.ToString();
                    txtReffNo.Text = Session["sesChlnNo"].ToString();
                }
            }
        }
         
        protected void btnProductAddAll_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SessionDataSet();
        }

        private void SetPrice()
        {
            if (hdnProduct.Value != "")
            { 
                decimal commission = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;
                decimal convRate = 0;

                decimal productRate = itemPrice.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);
                   
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
                lblComm.Text = CommonClass.GetFormettingNumber(commission);
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
            lblComm.Text = "0.0";
            hdnSuppTax.Value = "0.0";
            hdnVat.Value = "0.0";
            hdnVatPrice.Value = "0.0";
        }
        private string GetXmlFilePath()
        {
            string unit = "";
            unit = "" + hdnUnit.Value;
            if (unit == "") unit = ddlUnit.SelectedValue;

            return Server.MapPath("") + "/Data/" + Session[SessionParams.USER_ID] + "_" + unit + "_item.xml";
        }
        protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                // ddlUnit.SelectedValue,ddlShipPoint.SelectedValue,ddlSalesOffice.SelectedValue,ddlCustomerType.SelectedValue(),hdnCustomer,hdnShipToPartyId,hdnVehicle.Value,rdoVehicleCompany,rd
            }
            catch
            {
            }
        }
    }
}