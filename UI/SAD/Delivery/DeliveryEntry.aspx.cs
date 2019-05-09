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
        DataTable dt = new DataTable();
        XmlManager xm = new XmlManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());
                DefaultPageLoad();
               
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

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
                    dt = objUom.GetUOMRelationByPrice(hdnProduct.Value, hdnCustomer.Value,
                         hdnPriceId.Value, rdoSalesType.SelectedValue.ToString(), txtDate.Text.ToString());
                    ddlUOM.Loads(dt, "intID", "strUOM");
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
            decimal.Parse(hdnPrice.Value) > 0 && txtQun.Text.Trim() != "" && rest >= 0) // Change By konock @ 14052016
            {
                string coaId = "", coaName = "";
                SAD_BLL.Item.Item it = new SAD_BLL.Item.Item();
                CustomerInfo ci = new CustomerInfo();
                decimal lm = 0, bl = 0;
                ci.GetCustomerCreditLimitCreditBalance(hdnCustomer.Value, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);

                it.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, RadioButtonList1.SelectedValue, ref coaId, ref coaName);

                if (coaId != "" && coaId != "0" && coaName != "")
                {
                    string narr = txtQun.Text.Trim() + " " + ddlUOM.SelectedItem.Text + " " + hdnProductText.Value + " Sold";

                    if (txtReffNo.Text.Trim() != "")
                    {
                        narr += " as per challan no " + txtReffNo.Text.Trim();
                    }

                    narr += " To " + hdnCustomerText.Value;

                    string vhlPr = "0.0", chrPr = "0.0", incPr = "0.0";

                    if (rdoNeedVehicle.SelectedIndex == 0)
                    {
                        if (hdnLogisBasedOnUom.Value == "true") vhlPr = hdnVhlPrice.Value;
                    }

                    if (hdnXFactoryChr.Value == "true" && rdoNeedVehicle.SelectedIndex == 0)
                    {
                        if (hdnCharBasedOnUom.Value == "true") chrPr = hdnChrgPrice.Value;
                    }
                    else if (hdnXFactoryChr.Value != "true")
                    {
                        if (hdnCharBasedOnUom.Value == "true") chrPr = hdnChrgPrice.Value;
                    }

                 

                    decimal promQnty = 0;
                    int promItemId = 0;
                    int promItemCOAId = 0;
                    int promItemUOM = 0;
                    string promItem = "";
                    string promUom = "";

                    ItemPromotion ip = new ItemPromotion();
                    decimal promPrice = ip.GetPromotion(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                        , txtQun.Text, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);

                    if (promItemId.ToString() == hdnProduct.Value)
                    {
                        promPrice = decimal.Parse(hdnPrice.Value);
                        promItemCOAId = int.Parse(coaId);
                    }

                    string[][] items = xm.CreateItems(hdnProduct.Value, hdnProductText.Value
                        , txtQun.Text, hdnPrice.Value, coaId, coaName, ddlVehicleCharge.SelectedValue
                        , ddlVehicleCharge.SelectedItem.Text, chrPr, ddlUOM.SelectedValue, ddlUOM.SelectedItem.Text
                        , ddlCurrency.SelectedValue, narr, RadioButtonList1.SelectedValue.ToString()
                        , hdnVehicle.Value, vhlPr, promQnty.ToString(), lblComm.Text
                        , ddlVehicleIncentive.SelectedValue, incPr, hdnSuppTax.Value, hdnVat.Value, hdnVatPrice.Value
                        , promItemId.ToString(), promItem, promItemUOM.ToString(), promUom
                        , hdnLogisGain.Value, promPrice.ToString(), promItemCOAId.ToString());


                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                    selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    xmlDoc.Save(GetXmlFilePath());

                    txtQun.Text = "";

                     

                    hdnProduct.Value = "";
                    lblPrice.Visible = true;
                    txtProduct.Text = "";
                    txtProduct.Focus(); 
                }
            }
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
        
       
         
        //#region GridView

        //protected string GetTotal(string pr, string qnt)
        //{
        //    decimal tot = (decimal.Parse(pr) * decimal.Parse(qnt));
        //    return CommonClass.GetFormettingNumber(tot);
        //}
        //protected string GetTotal(string pr, string logisGain, string qnt)
        //{
        //    decimal tot = ((decimal.Parse(pr) + decimal.Parse(logisGain)) * decimal.Parse(qnt));
        //    return CommonClass.GetFormettingNumber(tot);
        //}
        //protected string GetTotal(string pr, string pr2, string qnt, string inc)
        //{
        //    decimal log = decimal.Parse(pr2);
        //    decimal tot = (decimal.Parse(pr) + log - decimal.Parse(inc));
        //    tot = tot * decimal.Parse(qnt);
        //    return CommonClass.GetFormettingNumber(tot);
        //}
        //protected string GetFullTotal(string pr, string logisGain, string qnt, string ext, string log, string inc)
        //{
        //    decimal log_ = decimal.Parse(log);
        //    decimal tot = (decimal.Parse(pr) + decimal.Parse(logisGain) + decimal.Parse(ext) + log_ - decimal.Parse(inc));
        //    tot = tot * decimal.Parse(qnt);
        //    return CommonClass.GetFormettingNumber(tot);
        //}
        //protected string GetGrandTotal(int col)
        //{
        //    decimal tot = 0;

        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
        //        {
        //            tot += decimal.Parse(((Label)GridView1.Rows[i].Cells[col].Controls[1]).Text);
        //        }
        //    }

        //    if (col == 8 || col == 11)
        //    {
        //        if (hdnLogisBasedOnUom.Value != "true")
        //        {
        //            if (rdoNeedVehicle.SelectedIndex == 0) tot += decimal.Parse(hdnVhlPrice.Value);
        //        }
        //        if (hdnCharBasedOnUom.Value != "true")
        //        {
        //            tot += decimal.Parse(hdnChrgPrice.Value);
        //        }

        //        if (col == 11)
        //        {

        //            if (!btnSubmit.Enabled)
        //            {
        //                lblError.Text = "Balance Exceed";
        //            }
        //        }
        //    }

        //    if (col == 12)
        //    {

        //        if (!btnSubmit.Enabled)
        //        {
        //            lblError.Text = "Balance Exceed";
        //        }
        //    }
        //    return CommonClass.GetFormettingNumber(tot);
        //}
        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    e.Cancel = true;
        //    lblError.Text = "";
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(GetXmlFilePath());

        //    ds.Tables[0].Rows[e.RowIndex].Delete();
        //    ds.WriteXml(GetXmlFilePath());
        //    BindGrid(GetXmlFilePath());
        //}
        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
        //    if (GridView1.Rows.Count <= 0)
        //    {
        //        btnCancel.Visible = false;
        //        btnSubmit.Visible = false;

        //        ddlCurrency.Enabled = true;
        //        txtDate.Enabled = true;

        //        ddlUnit.Enabled = true;

        //        pnlVehicleMain.Enabled = true;
        //        pnlVehicle3rd.Enabled = true;
        //        rdoNeedVehicle.Enabled = true;
        //        RadioButtonList1.Enabled = true;

        //    }
        //    else
        //    {
        //        btnCancel.Visible = true;
        //        btnSubmit.Visible = true;

        //        ddlCurrency.Enabled = false;
        //        txtDate.Enabled = false;

        //        ddlUnit.Enabled = false;
        //        txtCustomer.Enabled = false;

        //        pnlVehicleMain.Enabled = false;
        //        pnlVehicle3rd.Enabled = false;
        //        rdoNeedVehicle.Enabled = false;
        //        RadioButtonList1.Enabled = false;
        //        ddlVehicleCharge.Enabled = false;
        //        ddlVehicleCharge.Enabled = false;
        //    }
        //}
        //#endregion
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
                lblPrice.Text = CommonClass.GetFormettingNumber(productRate);
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
            lblPrice.Text = "0.0";
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
    }
}