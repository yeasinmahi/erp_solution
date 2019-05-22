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
using System.Reflection;

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
        private bool _isProcess = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //_filePathForXml = Server.MapPath("~/SAD/Delivery/Data/Sales__" + Enroll + ".xml");
            if (!IsPostBack)
            {

                //GetURLMenu();
                try { File.Delete(GetXmlFilePath()); } catch { }
                DefaultPageLoad();

                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Session["CustomerId"] = null;
                Session["DoId"] = null;
                RequestPopUp(); 

                WorkType(rdoDeliveryType.SelectedItem.Text.ToString());

                //int Id = Convert.ToInt32(txtDoNumber.Text);
               // int userUnit = 53; //Convert.ToInt32( Session[SessionParams.UNIT_ID]); 
                //PickingPageloadDataBind(Id, userUnit);

            }

        }

        private void RequestPopUp()
        {
            try
            {
                Session[SessionParams.SalesProcess] = "Picking";
                Session[SessionParams.SalesProcess] = Request.QueryString["PopupType"];
                Session["DoId"] = Request.QueryString["DoId"];
                Session["CustomerId"] = Request.QueryString["CustomerId"];
                Session["ShipId"] = Request.QueryString["ShipId"];
                Session["PickingId"] = Request.QueryString["PickingId"];
                Session["ReportType"] = Request.QueryString["ReportType"];

                
                if (Request.QueryString["PopupType"] == null)
                {
                    Session[SessionParams.SalesProcess] = "DO";
                }
                else
                {
                    PickingPageloadDataBind(55, 55);
                }

              
                

            }
            catch { }
        }
        private void PickingPageloadDataBind(int id, int unit)
        {

            if (HttpContext.Current.Session["ReportType"].ToString() == "DoBase")
            {
                dt = deliveryBLL.DeliveryHeaderDataByDo(id, unit);
            }
            else if (HttpContext.Current.Session["ReportType"].ToString() == "CustomerBase")
            {
                dt = deliveryBLL.DeliveryHeaderDataByCustomer(id, unit);
            }
            if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking_Edit")
            {
                PickingGridDataBind();
            }
            if (dt.Rows.Count > 0)
            {
                ddlUnit.SelectedItem.Text = dt.Rows[0]["strUnit"].ToString();
                ddlUnit.SelectedValue= dt.Rows[0]["intUnitId"].ToString();

                ShipPointSelectionChange(); 
                ddlShipPoint.SelectedItem.Text = dt.Rows[0]["strShipPointName"].ToString();
                ddlShipPoint.SelectedValue = dt.Rows[0]["intShipPointId"].ToString();

                SalesOfficeSelectionChange();

                ddlSalesOffice.SelectedItem.Text = dt.Rows[0]["strSalesOfficeName"].ToString();
                ddlSalesOffice.SelectedValue = dt.Rows[0]["intSalesOffId"].ToString();

                ddlCustomerType.SelectedValue = dt.Rows[0]["intCustTypeId"].ToString();
                ddlCustomerType.SelectedItem.Text = dt.Rows[0]["strCustType"].ToString();

                txtDate.Text = dt.Rows[0]["dteDate"].ToString();
                txtDueDate.Text = dt.Rows[0]["dteReqDelivaryDate"].ToString();
                txtCustomer.Text = dt.Rows[0]["strCustNameId"].ToString();
                txtCustomerAddress.Text = dt.Rows[0]["strAddress"].ToString();
                rdoSalesType.SelectedItem.Text = dt.Rows[0]["strSalesType"].ToString();
                try
                {
                    txtShipToParty.Text = dt.Rows[0]["strShipToPartyNameId"].ToString();
                    txtShipToPartyAddress.Text = dt.Rows[0]["strShipAddress"].ToString();
                }
                catch
                {
                    txtShipToParty.Text = "";
                    txtShipToPartyAddress.Text = "";
                }

                Session[SessionParams.CURRENT_SHIP] = ddlShipPoint.SelectedItem.Value;
            }
            else
            {
                Toaster("There is no data against your query", "Delivery Entry", Common.TosterType.Warning);
            }

            
        }

        private void PickingGridDataBind()
        {
            throw new NotImplementedException();
        }

        private void GetURLMenu()
        {
            string type = Request.QueryString["type"];

            foreach (ListItem item in rdoDeliveryType.Items)
            {
                rdoDeliveryType.Enabled = true;

                if (item.Value.Contains(type.ToString()))
                {
                    item.Selected = true;

                    break;
                }

            }
        }

        private void WorkType(string Type)
        {
            try
            {
                if (Type == "DO")
                { 
                    pnlVehicleMain.Visible = false;  
                    txtPrice.Visible = true;
                    btnSubmit.Text = "DO";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer Id";
                    dgvSales.Visible = true;
                    dgvSalesPicking.Visible = false;
                    ddlLocation.Visible = false;
                    location.Visible = false;

                }
                else if (Type == "Picking")
                {
                    pnlVehicleMain.Visible = true;
                    btnSubmit.Text = "Picking";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer";
                    dgvSales.Visible = false;
                    dgvSalesPicking.Visible = true;
                    ddlLocation.Visible = true;
                    location.Visible = true;

                }
                else if (Type == "Delivery")
                {
                    pnlLogistic.Visible = true;
                    btnSubmit.Text = "Delivery";
                    lblDoCustId.Visible = true;
                    txtDoNumber.Visible = true;
                    lblDoCustId.Text = "DO/Customer/Picking Id";
                }
                else if (Type == "Return")
                {
                    pnlLogistic.Visible = false;
                    btnSubmit.Text = "Return";
                    lblDoCustId.Visible = false;
                    txtDoNumber.Visible = false;
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

                dt = salesConfig.GetSalesTypeForDO(ddlUnit.SelectedValue().ToString());
                rdoSalesType.RadioLoad(dt, "intTypeID", "strTypeName");

                rdoSalesType.SelectedIndex = 0;

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
            return DistributionPointSt.GetDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session["sesCurrentCus"].ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "DO")
            {
                return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking" && int.Parse(HttpContext.Current.Session["DoId"].ToString())>0)
            {
                return SalesSearch_BLL.GetDoPendingItemByDo(HttpContext.Current.Session["DoId"].ToString(),HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
            }
            else if (HttpContext.Current.Session[SessionParams.SalesProcess].ToString() == "Picking" && int.Parse(HttpContext.Current.Session["CustomerId"].ToString()) > 0)
            {
                return SalesSearch_BLL.GetDoPendingItemByCustomer(HttpContext.Current.Session["CustomerId"].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText);
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
           

            dt = deliveryBLL.WareHouseByShipPoint(int.Parse(ddlShipPoint.SelectedValue().ToString()));
            if (dt.Rows.Count > 0)
            {
                hdnWHId.Value = dt.Rows[0]["intWHID"].ToString();
                hdnWHName.Value = dt.Rows[0]["strWareHoseName"].ToString();
            }

            dt = deliveryBLL.FgWarehouseLocation(Convert.ToInt32(hdnWHId.Value));
            ddlLocation.Loads(dt, "intStoreLocationID", "strLocationName");
            SessionDataSet();
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
            try
            {
                if (txtCustomer.Text.Trim() != "")
                {
                    char[] ch = { '[', ']' };
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

            Label lblqty = dgvSales.Rows[e.RowIndex].FindControl("lblqty") as Label;
            Label lblProdutId = dgvSales.Rows[e.RowIndex].FindControl("lblProdutId") as Label;
            Label lblProductName = dgvSales.Rows[e.RowIndex].FindControl("lblProductName") as Label;

            TextBox txtQtyEdit = dgvSales.Rows[e.RowIndex].FindControl("txtQtyEdit") as TextBox;
            Label lblUoM = dgvSales.Rows[e.RowIndex].FindControl("lblUoM") as Label;
            Label lblUomId = dgvSales.Rows[e.RowIndex].FindControl("lblUomId") as Label;
            Label lblCommision = dgvSales.Rows[e.RowIndex].FindControl("lblCommision") as Label; 

            dgvSales.EditIndex = -1;

            LoadGridwithXml();

            DataSet ds = dgvSales.DataSource as DataSet; 
          
            UpdateXml(id,ds, lblProdutId.Text, lblProductName.Text,lblPrice.Text,   txtQtyEdit.Text, lblUoM.Text, lblUomId.Text, lblCommision.Text);
        }

        private void UpdateXml(int id,DataSet ds,string ProductId,string ProductName,string price ,string editQty,string uom,string UomId,string Commision)
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

                decimal promPrice = itemPromotion.GetPromotion(ProductId, hdnCustomer.Value, hdnPriceId.Value, UomId, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , editQty, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId); 
                string quantity = editQty;
                 
               
                decimal discountTotal = decimal.Parse(Commision) * decimal.Parse(editQty);
                decimal priceTotal = decimal.Parse(price) * decimal.Parse(editQty);
                ds.Tables[0].Rows[id]["discountTotal"] = discountTotal;
                ds.Tables[0].Rows[id]["priceTotal"] = priceTotal;

                ds.Tables[0].Rows[id]["quantity"] = editQty;

                ds.Tables[0].Rows[id]["promtionItemId"] = promItemId;
                ds.Tables[0].Rows[id]["promtionItem"] = promItem;
                ds.Tables[0].Rows[id]["promtionUom"] = promUom;

                ds.Tables[0].Rows[id]["promtionItemCoaId"] = promItemCOAId;
                ds.Tables[0].Rows[id]["promtionQnty"] = promQnty;
                ds.Tables[0].Rows[id]["promtionItemUom"] = promItemUOM;
                ds.Tables[0].Rows[id]["promPrices"] = promPrice;
                ds.Tables[0].Rows[id]["editStatus"] = "1";


                ds.WriteXml(GetXmlFilePath());


                LoadGridwithXml();

            }
            catch { }
        }

        protected void rdoNeedVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WorkType(rdoDeliveryType.SelectedItem.Text.ToString());
                if (rdoNeedVehicle.SelectedValue.ToString() == "1" && rdoDeliveryType.SelectedItem.Text=="DO")
                { 
                    pnlVehicleMain.Visible = false;
                    rdoVehicleCompany.Visible = true;

                }
                else if (rdoNeedVehicle.SelectedValue.ToString() == "1")
                {
                    pnlVehicleMain.Visible = true;
                    rdoVehicleCompany.Visible = true;

                    
                }
                else 
                {
                    pnlVehicleMain.Visible = false;
                    rdoVehicleCompany.Visible = false;
                }
                 
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
                if (txtProduct.Text.Trim() != "")
                {
                    //char[] ch = { '[', ']' };
                    //string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    //hdnProduct.Value = temp[temp.Length - 1];
                    //hdnProductText.Value = temp[0];
                    GetProduct(rdoDeliveryType.SelectedItem.Text);

                    dt = objUom.GetUOMRelationByPrice(hdnProduct.Value, hdnCustomer.Value,
                        hdnPriceId.Value, rdoSalesType.SelectedValue.ToString(), txtDate.Text.ToString());
                    ddlUOM.Loads(dt, "intID", "strUOM");
                    dt = deliveryBLL.InvenotoryStockByItem(hdnProduct.Value, hdnWHId.Value);
                    if (dt.Rows.Count > 0)
                    {
                        hdnInvItemId.Value = dt.Rows[0]["intItemId"].ToString();
                        hdnInventoryStock.Value = dt.Rows[0]["numQuantity"].ToString();
                    }
                  

                    txtQun.Text = "0";
                    txtPrice.Text = "0";

                    SetPrice(rdoDeliveryType.SelectedItem.Text);
                    txtQun.Focus();
                }
                else
                {
                    hdnProduct.Value = "";
                }
            }
            catch { }
        }

        protected void btnProductAdd_Click(object sender, EventArgs e)
        {
            ProductAdd(); 
        }

        private void ProductAdd()
        {
            try
            {
                 
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
                        string naration = narr;
                        string currency = ddlCurrency.SelectedValue().ToString();
                        string commision = lblComm.Text.ToString();
                        string commisionTotal = lblComm.Text.ToString();
                        string discount = "0";
                        decimal discountTotal = decimal.Parse(lblComm.Text.ToString()) * decimal.Parse(txtQun.Text.ToString());
                        decimal priceTotal = decimal.Parse(txtPrice.Text.ToString()) * decimal.Parse(txtQun.Text.ToString());
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
                        string location = "0";
                        string intInvItemId = hdnInvItemId.Value;
                        string editStatus ="0";
                        string vehicleProvider = rdoVehicleCompany.SelectedItem.Text;
                        string vehicleProviderId = rdoVehicleCompany.SelectedValue;
                        try { location = ddlLocation.SelectedItem.Value; }
                        catch { location = "0"; }
                         

                        if (rdoDeliveryType.SelectedItem.ToString() == "Picking")
                        {
                            for (var i = 0; i < dgvSalesPicking.Rows.Count; i++)
                            {
                                Label lblproductID = dgvSalesPicking.Rows[i].FindControl("lblProdutId") as Label;
                                if (lblproductID.Text == productId)
                                {
                                    Toaster("Can not add same product Name " + productName + " duplicate.", "", Common.TosterType.Error);

                                    return;
                                }
                            }
                        
                           

                        }
                        else if (rdoDeliveryType.SelectedItem.ToString() == "DO")
                        {
                            for (var i = 0; i < dgvSales.Rows.Count; i++)
                            {
                                Label lblproductID = dgvSales.Rows[i].FindControl("lblProdutId") as Label;
                                if (lblproductID.Text == productId)
                                {
                                    Toaster("Can not add same product Name " + productName + " duplicate.", "", Common.TosterType.Error);

                                    return;
                                }
                            }
                          
                        }
                         
                        RowLavelXmlCreate(productId, productName, quantity, rate, uomId, uomName,
                          naration, currency, commision, commisionTotal, discount, discountTotal.ToString(),
                          priceTotal.ToString(), supplierTax, vat, vatPrice, promtionItemId, promtionItem, promPrices,
                          promtionUom, coaId, coaName, promtionItemCoaId, promtionQnty, promtionItemUom, vehicleProvider, vehicleProviderId, location, intInvItemId, editStatus);

                        txtQun.Text = "";
                        hdnProduct.Value = "";
                        txtPrice.Visible = true;
                        txtProduct.Text = "";
                        txtPrice.Text = "0";
                        ddlUOM.SelectedItem.Text = "";
                        txtProduct.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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
            string uomName, string naration, string currency, string commision, string commisionTotal, string discount,
            string discountTotal, string priceTotal, string supplierTax, string vat, string vatPrice,  string promtionItemId,
            string promtionItem, string promPrices,string promtionUom,string coaId,string coaName, string promtionItemCoaId, string promtionQnty, string promtionItemUom,
            string vehicleProvider, string vehicleProviderId, string location ,string intInvItemId,string editStatus)
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
                promtionItemId,
                promtionItem,
                promPrices,
                promtionUom,
                coaId,
                coaName,
                promtionItemCoaId,
                promtionQnty,
                promtionItemUom,
                vehicleProvider,
                vehicleProviderId,
                location,
                intInvItemId,
                editStatus
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
            //try
            //{


            //    if (Session["rowObj"] != null)
            //    {
            //        List<object> objects = (List<object>)Session["rowObj"];

            //        objects.RemoveAt(e.RowIndex);
            //        if (objects.Count > 0)
            //        {
            //            string xmlString = XmlParser.GetXml("Entry", "items", objects, out string message);
            //            LoadGridwithXml(xmlString);
            //        }
            //        else
            //        {
            //            dgvSales.UnLoad();
            //        }
            //    }
            //    else
            //    {
            //        dgvSales.UnLoad();
            //    }

            //}
            //catch { }
        }

       

        private void LoadGridwithXml()
        {
            string itemXML = XmlParser.GetXml(GetXmlFilePath());
            if (rdoDeliveryType.SelectedItem.ToString() == "Picking")
            {
                GridViewUtil.LoadGridwithXml(itemXML, dgvSalesPicking, out string message);
            }
            else if(rdoDeliveryType.SelectedItem.ToString() == "DO")
            {
                GridViewUtil.LoadGridwithXml(itemXML, dgvSales, out string message);
            }
           
        }


        private void GetProduct(string type)
        {
            if (type == "DO")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnProduct.Value = temp[temp.Length - 1];
                hdnProductText.Value = temp[0];
            }
            else if (type == "Picking")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnDoId.Value = temp[temp.Length - 1];
                hdnProductText.Value = temp[1];
                hdnProduct.Value = temp[1];
            }
            else if (type == "Delivery")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnCustomer.Value = temp[temp.Length - 1];
                hdnCustomerText.Value = temp[1];
                hdnDoId.Value = temp[0];
            }

        }
        protected void btnProductAddAll_Click(object sender, EventArgs e)
        {

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
                if (type == "DO")
                {
                    productRate = itemPrice.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                  , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);
                }
                else if (type=="Picking")
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
                       
                       
                    }
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
            _filePathForXml = Server.MapPath("~/SAD/Delivery/Data/Sales__" + Enroll + ".xml");
            return _filePathForXml;
        }
        protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice(rdoDeliveryType.SelectedItem.Text);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_isProcess) return;
            _isProcess = true;
              
            try
                {

                    string unit = ddlUnit.SelectedItem.Value;
                    string shipPoint = ddlShipPoint.SelectedItem.Value;
                    string salesOffice = ddlSalesOffice.SelectedItem.Value;
                    string customerType = ddlCustomerType.SelectedItem.Value;
                    string date = txtDate.Text;
                    string dueDate = txtDueDate.Text;
                    string customerId = hdnCustomer.Value;
                    string shipPartyId = hdnShipToPartyId.Value;
                    string salesType = rdoSalesType.SelectedItem.Value;
                    string reffNo = txtReffNo.Text;
                    string customerAddress = txtCustomerAddress.Text;
                    string shipToPartyAddress = txtShipToPartyAddress.Text;
                    string currency = ddlCurrency.SelectedItem.Value;
                    string conversionRate = txtConvRate.Text;
                    string vehicleCompany = "", vehicleId = "", vehicleText = "", driver = "", driverContact = "", supplierId = "", supplierText = "";
                    string rowXml = XmlParser.GetXml(GetXmlFilePath());
                    string orderID = "", Code = "", msg = "";
                    if (hdnConfirm.Value == "1")
                    {
                        if (rdoDeliveryType.SelectedItem.Text.ToString() == "DO")
                        {
                            BindDOHeaderXML(Enroll.ToString(), unit, shipPoint, salesOffice, customerType, date, dueDate, customerId, shipPartyId, salesType, reffNo, customerAddress, shipToPartyAddress, hdnnarration.Value, currency, conversionRate);
                            msg = deliveryBLL.DeliveryOrderCreate(xmlHeaderString, rowXml, ref orderID, ref Code);
                        }
                        else if (rdoDeliveryType.SelectedItem.Text.ToString() == "Picking")
                        {
                            if (rdoNeedVehicle.SelectedItem.Text.ToString() == "Yes")
                            {
                                driver = txtDriver.Text;
                                driverContact = txtDriverContact.Text;
                                vehicleCompany = rdoVehicleCompany.SelectedItem.Text;

                                if (txtVehicle.Text.Trim() != "")
                                {
                                    char[] ch = { '[', ']' };
                                    string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                                    vehicleId = temp[temp.Length - 1];
                                    vehicleText = temp[0];
                                }

                                if (rdoVehicleCompany.SelectedItem.Text.ToString() == "Rent")
                                {

                                    if (txtSupplier.Text.Trim() != "")
                                    {
                                        char[] ch = { '[', ']' };
                                        string[] temp = txtSupplier.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                                        supplierId = temp[temp.Length - 1];
                                        supplierText = temp[0];
                                    }
                                }
                            }
                            else { }
                            BindPickingHeaderXML(Enroll.ToString(), unit, shipPoint, salesOffice, customerType, date, dueDate, customerId, shipPartyId, salesType, reffNo, customerAddress,
                            shipToPartyAddress, currency, conversionRate, vehicleCompany, vehicleId, vehicleText, driver, driverContact, supplierId, supplierText);

                        } 

                        msg = deliveryBLL.PickingCreate(xmlHeaderString, rowXml, customerAddress, ref orderID, ref Code);
                        lblCodeText.Visible = true;
                        lblCode.Text = Code;
                        lblOrderIDText.Visible = true;
                        lblOrderId.Text = orderID;
                        if (File.Exists(GetXmlFilePath()))
                        {
                            File.Delete(GetXmlFilePath());
                        }

                        Toaster(msg, Common.TosterType.Success);
                    }
                    else
                    { 
                        Toaster("Data not submitted", Common.TosterType.Warning);
                    }
                    _isProcess = false; 
                }
                catch
                {
                    _isProcess = false;
                }
            
            
        }

       
        private string BindPickingHeaderXML(string userId,string unitId, string shipPointId, string salesOfficeId, string customerType, string date, string dueDate, string customerId, string shipPartyId, string salesType, 
            string reffNo, string customerAddress, string shipToPartyAddress, string currencyId, string conversionRate, string vehicleCompany, string vehicleId,string vehicleName, string driver,
            string driverContact, string supplierId,string supplierName)
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
                currencyId,
                conversionRate,
                vehicleCompany,
                vehicleId,
                vehicleName,
                driver,
                driverContact,
                supplierId,
                supplierName,

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
            ProductAdd();
             
        }

        protected void txtDoNumber_TextChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtDoNumber.Text);
            int userUnit = 53; //Convert.ToInt32( Session[SessionParams.UNIT_ID]);

           

        }

       
        protected void rdoDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkType(rdoDeliveryType.SelectedItem.ToString());
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

            TextBox txtQtyEdit = dgvSalesPicking.Rows[e.RowIndex].FindControl("txtQtyEdit") as TextBox;
            Label lblUoM = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblUoM") as Label;
            Label lblUomId = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblUomId") as Label;
            Label lblCommision = dgvSalesPicking.Rows[e.RowIndex].FindControl("lblcommision") as Label;


            dgvSalesPicking.EditIndex = -1;

            LoadGridwithXml();

            DataSet ds = dgvSalesPicking.DataSource as DataSet;

            UpdateXml(id, ds, lblProdutId.Text, lblProductName.Text, lblPrice.Text, txtQtyEdit.Text, lblUoM.Text, lblUomId.Text, lblCommision.Text);
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