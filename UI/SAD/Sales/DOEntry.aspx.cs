using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Collections.Generic;
using SAD_BLL.Item;
using SAD_DAL.Item;
using BLL;
using System.Xml;
using System.IO;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using LOGIS_BLL;
using LOGIS_DAL;
using SAD_BLL.Global;
using SAD_DAL.Customer;
using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using UI.ClassFiles;

namespace UI.SAD.Sales
{
    public partial class DOEntry : BasePage
    {
        XmlManager xm = new XmlManager(); ItemPrice objbll = new ItemPrice(); bool ysnvisible;
        SalesEntryTDS.QrySalesEntryCustomerDataTable table;

        private string nextParentID = "";
        Table tbl = new Table();
        TableRow tr = new TableRow();
        TableCell td = new TableCell();
        TableCell tdLbl = new TableCell();
        TableCell tdCon = new TableCell();
        ItemPriceManagerTDS.SprItemPriceManagerGetAllUpperLevelDataTable tblUpperLevel;

        private string nextParentIDP = "";
        Table tblV = new Table();
        TableRow trV = new TableRow();
        TableCell tdV = new TableCell();
        TableCell tdLblV = new TableCell();
        TableCell tdConV = new TableCell();
        VehicleManagerTDS.SprVehiclePriceManagerGetAllUpperLevelDataTable tblUpperLevelV;

        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "1";

                if (Request.QueryString["id"] != null)
                {
                    SalesEntry se = new SalesEntry();
                    table = se.GetSalesEntry(Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        ///---------- Change By Konock ------------------
                        decimal lm = 0, bl = 0;
                        CustomerInfo ci = new CustomerInfo();
                        ci.GetCustomerCreditLimitCreditBalance(table[0].intCustomerId.ToString(), table[0].intUnitId.ToString(), Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);

                        lblLM.Text = CommonClass.GetFormettingNumber(lm);
                        lblBl.Text = CommonClass.GetFormettingNumber(bl);

                        hdnLm.Value = lblLM.Text;
                        hdnBl.Value = lblBl.Text;
                        ///--------- End Change By Konock ----------
                        hdnUnit.Value = table[0].intUnitId.ToString();
                        txtConvRate.Text = table[0].numConversionRate.ToString();
                        if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());

                        SalesEntryTDS.QrySalesEntryDetailsDataTable tbl = se.GetSalesEntryDetails(table[0].intId.ToString());

                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            string[][] items = xm.CreateItems(tbl[i].intProductId.ToString()
                                , tbl[i].strProductName
                                , tbl[i].numQuantity.ToString()
                                , tbl[i].monPrice.ToString()
                                , tbl[i].intCOAAccId.ToString()
                                , tbl[i].strCOAAccName
                                , tbl[i].IsintExtraIdNull() ? "" : tbl[i].intExtraId.ToString()
                                , tbl[i].IsstrExtraChargeNull() ? "" : tbl[i].strExtraCharge
                                , tbl[i].IsmonExtraPriceNull() ? "" : tbl[i].monExtraPrice.ToString()
                                , tbl[i].intUom.ToString()
                                , tbl[i].strUOM
                                , tbl[i].intCurrencyID.ToString()
                                , tbl[i].IsstrNarrationNull() ? "" : tbl[i].strNarration
                                , tbl[i].intSalesType.ToString()
                                , tbl[i].IsintVehicleVarIdNull() ? "" : tbl[i].intVehicleVarId.ToString()
                                , tbl[i].IsmonVehicleVarPriceNull() ? "" : tbl[i].monVehicleVarPrice.ToString()
                                , tbl[i].IsnumPromotionNull() ? "" : tbl[i].numPromotion.ToString()
                                , tbl[i].IsmonCommissionNull() ? "" : tbl[i].monCommission.ToString()
                                , tbl[i].IsintIncentiveIdNull() ? "" : tbl[i].intIncentiveId.ToString()
                                , tbl[i].IsnumIncentiveNull() ? "" : tbl[i].numIncentive.ToString()
                                , tbl[i].IsmonSuppTaxNull() ? "" : tbl[i].monSuppTax.ToString()
                                , tbl[i].IsmonVATNull() ? "" : tbl[i].monVAT.ToString()
                                , tbl[i].IsmonVATPriceNull() ? "" : tbl[i].monVATPrice.ToString()
                                , tbl[i].IsintPromItemIdNull() ? "" : tbl[i].intPromItemId.ToString()
                                , tbl[i].IsstrPromItemNameNull() ? "" : tbl[i].strPromItemName
                                , tbl[i].IsintPromUOMNull() ? "" : tbl[i].intPromUOM.ToString()
                                , tbl[i].IsstrPromUomNull() ? "" : tbl[i].strPromUom
                                , tbl[i].IsmonLogisGainNull() ? "0" : tbl[i].monLogisGain.ToString()
                                , tbl[i].IsmonPromPriceNull() ? "0" : tbl[i].monPromPrice.ToString()
                                , tbl[i].IsintPromItemCOAIdNull() ? "0" : tbl[i].intPromItemCOAId.ToString()
                                );

                            XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                            XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                            selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                            xmlDoc.Save(GetXmlFilePath());
                        }
                    }
                }
                else
                {
                    txtDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                }
            }

        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        txtDate.Text = CommonClass.GetShortDateAtLocalDateFormat(table[0].dteDate);
                        txtDriver.Text = table[0].IsstrDriverNull() ? "" : table[0].strDriver;
                        txtDriverContact.Text = table[0].IsstrDriverContactNull() ? "" : table[0].strDriverContact;
                        //txtNarration.Text = table[0].strNarration;

                        txtQun.Text = "";
                        //txtExtra.Text = table[0].IsmonExtraAmountNull() ? "" : CommonClass.GetFormettingNumber(table[0].monExtraAmount);
                        //txtCause.Text = table[0].strExtraCause;
                        txtChallan.Text = table[0].strChallanNo;
                        txtNarration.Text = table[0].strOtherInfo;


                        txtCus.Text = table[0].strName + " [" + table[0].intCustomerId + "]";
                        hdnCustomer.Value = table[0].intCustomerId.ToString();

                        if (!table[0].IsintDisPointIdNull() && int.Parse(table[0].intDisPointId.ToString()) > 0)
                        {
                            txtDis.Text = table[0].strDisPointName + " [" + table[0].intDisPointId.ToString() + "]";
                            DisPointChange();
                        }

                        txtAddress.Text = table[0].strAddress;

                        if (table[0].ysnLogistic)
                        {
                            rdoNeedVehicle.SelectedIndex = 0;
                            ChangeNeedVehicle();

                            if (table[0].ysnLogByCompany)
                            {
                                rdoVhlCompany.SelectedIndex = 0;
                                ChangeCompanyVehicle();
                            }
                            else
                            {
                                rdoVhlCompany.SelectedIndex = 1;
                                ChangeCompanyVehicle();

                                if (table[0].ysnChargeToSupplier) rdo3rdPartyCharge.SelectedIndex = 0;
                                else rdo3rdPartyCharge.SelectedIndex = 1;

                                ChartOfAcc coa = new ChartOfAcc();
                                ChartOfAccTDS.TblAccountsChartOfAccDataTable ttblCOA = coa.GetDataByAccountIDForEdit(table[0].intLogSuppCOAId);
                                if (ttblCOA.Rows.Count > 0) { txtSupplier.Text = ttblCOA[0].strAccName + " [" + ttblCOA[0].strCode + "]"; }

                            }

                            if (table[0].IsintVehicleIdNull())
                            {
                                txtVehicle.Text = table[0].strVehicleRegNo;
                                hdnVehicle.Value = "";
                                hdnVehicleText.Value = table[0].strVehicleRegNo;
                            }
                            else
                            {
                                txtVehicle.Text = table[0].strVehicleRegNo + " [" + table[0].intVehicleId + "]";
                                hdnVehicle.Value = table[0].intVehicleId.ToString();
                                hdnVehicleText.Value = table[0].strVehicleRegNo;
                            }

                            VehicleChange();
                        }
                        else
                        {
                            rdoNeedVehicle.SelectedIndex = 1;
                            ChangeNeedVehicle();
                        }

                        hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceVarIdNull() ? "" : table[0].intPriceVarId.ToString();
                        hdnDDLChangedSelectedIndexV.Value = table[0].IsintVehicleVarIdNull() ? "" : table[0].intVehicleVarId.ToString();

                        BuildTree();
                        CustomerChange();

                        btnSubmit.Text = "Update Sales";
                    }
                }
                else
                {
                    SalesConfigSet();
                }

                lblPrice.Attributes.Add("onkeyup", "SetPrice()");
                lblLogisGain.Attributes.Add("onkeyup", "SetPrice()");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                hdnPrice.Value = lblPrice.Text;
                hdnLogisGain.Value = lblLogisGain.Text;

                if (GridView1.Rows.Count <= 0)
                {
                    hdnVhlPrice.Value = lblVhkPr.Text;
                    hdnChrgPrice.Value = lblExtPr.Text;
                }
                BuildTree();
            }
            else
            {
                pnlUpperControl.DataBind();
                txtQun.Attributes.Add("onkeyup", "SetPrice()");
                BindGrid(GetXmlFilePath());
            }
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
            else if((""+HttpContext.Current.Session["sesCurVhlCom"]).ToLower() == "false")
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

        #region GridView

        protected string GetTotal(string pr, string qnt)
        {
            decimal tot = (decimal.Parse(pr) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetTotal(string pr, string logisGain, string qnt)
        {
            decimal tot = ((decimal.Parse(pr) + decimal.Parse(logisGain)) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetTotal(string pr, string pr2, string qnt, string inc)
        {
            decimal log = decimal.Parse(pr2);
            decimal tot = (decimal.Parse(pr) + log - decimal.Parse(inc));
            tot = tot * decimal.Parse(qnt);
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetFullTotal(string pr, string logisGain, string qnt, string ext, string log, string inc)
        {
            decimal log_ = decimal.Parse(log);
            decimal tot = (decimal.Parse(pr) + decimal.Parse(logisGain) + decimal.Parse(ext) + log_ - decimal.Parse(inc));
            tot = tot * decimal.Parse(qnt);
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetGrandTotal(int col)
        {
            decimal tot = 0;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    tot += decimal.Parse(((Label)GridView1.Rows[i].Cells[col].Controls[1]).Text);
                }
            }

            if (col == 8 || col == 11)
            {
                if (hdnLogisBasedOnUom.Value != "true")
                {
                    if (rdoNeedVehicle.SelectedIndex == 0) tot += decimal.Parse(hdnVhlPrice.Value);
                }
                if (hdnCharBasedOnUom.Value != "true")
                {
                    tot += decimal.Parse(hdnChrgPrice.Value);
                }
                if (hdnIncenBasedOnUom.Value != "true")
                {
                    tot -= decimal.Parse(lblIncPr.Text);
                }

                if (col == 11)
                {
                    btnSubmit.Enabled = CheckLimitBalance(tot);
                    if (!btnSubmit.Enabled)
                    {
                        lblError.Text = "Balance Exceed";
                    }
                }
            }

            if (col == 12)
            {
                btnSubmit.Enabled = CheckLimitBalance(tot);
                if (!btnSubmit.Enabled)
                {
                    lblError.Text = "Balance Exceed";
                }
            }
            return CommonClass.GetFormettingNumber(tot);
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            lblError.Text = "";
            DataSet ds = new DataSet();
            ds.ReadXml(GetXmlFilePath());

            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.WriteXml(GetXmlFilePath());
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count <= 0)
            {
                btnCancel.Visible = false;
                btnSubmit.Visible = false;

                ddlCurrency.Enabled = true;
                txtDate.Enabled = true;
                ddlCusType.Enabled = true;
                ddlUnit.Enabled = true;
                txtCus.Enabled = true;
                txtDis.Enabled = true;
                pnlMain.Enabled = true;
                pnlVehicle.Enabled = true;
                pnlVehicleMain.Enabled = true;
                pnlVehicle3rd.Enabled = true;
                rdoNeedVehicle.Enabled = true;
                RadioButtonList1.Enabled = true;
                ddlExtra.Enabled = true;
                ddlIncentive.Enabled = true;
            }
            else
            {
                btnCancel.Visible = true;
                btnSubmit.Visible = true;

                ddlCurrency.Enabled = false;
                txtDate.Enabled = false;
                ddlCusType.Enabled = false;
                ddlUnit.Enabled = false;
                txtCus.Enabled = false;
                txtDis.Enabled = false;
                pnlMain.Enabled = false;
                pnlVehicle.Enabled = false;
                pnlVehicleMain.Enabled = false;
                pnlVehicle3rd.Enabled = false;
                rdoNeedVehicle.Enabled = false;
                RadioButtonList1.Enabled = false;
                ddlExtra.Enabled = false;
                ddlIncentive.Enabled = false;
            }
        }
        #endregion

        #region Button
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BLL.Accounts.Voucher.Budget bdg = new BLL.Accounts.Voucher.Budget(); DataTable strtdt = new DataTable();
            DateTime gdt = CommonClass.GetDateAtSQLDateFormat(txtDate.Text);
            strtdt = bdg.GetAccountsStartDate(int.Parse(ddlUnit.SelectedValue.ToString()));
            DateTime pdt = DateTime.Parse(strtdt.Rows[0]["StartDate"].ToString());
            int rest = DateTime.Compare(gdt, pdt);

            if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnCustomer.Value != "" && hdnProduct.Value != "" &&
            decimal.Parse(hdnPrice.Value) > 0 && txtQun.Text.Trim() != "" && rest>= 0) // Change By konock @ 14052016
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

                    if (pnlChallan.Visible && txtChallan.Text.Trim() != "")
                    {
                        narr += " as per challan no " + txtChallan.Text.Trim();
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

                    if (hdnIncenBasedOnUom.Value == "true") incPr = lblIncPr.Text;


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
                        , txtQun.Text, hdnPrice.Value, coaId, coaName, ddlExtra.SelectedValue
                        , ddlExtra.SelectedItem.Text, chrPr, ddlUOM.SelectedValue, ddlUOM.SelectedItem.Text
                        , ddlCurrency.SelectedValue, narr, RadioButtonList1.SelectedValue.ToString()
                        , hdnDDLChangedSelectedIndexV.Value, vhlPr, promQnty.ToString(), lblComm.Text
                        , ddlIncentive.SelectedValue, incPr, hdnSuppTax.Value, hdnVat.Value, hdnVatPrice.Value
                        , promItemId.ToString(), promItem, promItemUOM.ToString(), promUom
                        , hdnLogisGain.Value, promPrice.ToString(), promItemCOAId.ToString());


                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                    selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    xmlDoc.Save(GetXmlFilePath());

                    txtQun.Text = "";

                    BindGrid(GetXmlFilePath());

                    hdnProduct.Value = "";
                    lblPrice.Visible = true;
                    txtProduct.Text = "";
                    txtProduct.Focus();

                    if (GridView1.Rows.Count > 0)
                    {
                        lblVhkPr.ReadOnly = true;
                        lblExtPr.ReadOnly = true;
                    }
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveGrid();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerInfo ci = new CustomerInfo();
                decimal lm = 0, bl = 0;
                ci.GetCustomerCreditLimitCreditBalance(hdnCustomer.Value, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);


                lblLM.Text = CommonClass.GetFormettingNumber(lm);
                lblBl.Text = CommonClass.GetFormettingNumber(bl);

                hdnLm.Value = lblLM.Text;
                hdnBl.Value = lblBl.Text;

                string id = "", code = "", supplier = "", supplierName = "";
                char[] ch = { '[', ']' };
                string[] temp = txtSupplier.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length > 1)
                {
                    supplierName = temp[0];
                    supplier = temp[temp.Length - 1];
                }
                else if (temp.Length > 0)
                {
                    supplierName = txtSupplier.Text;
                    supplier = "";
                }

                if (hdnVehicle.Value == "" && hdnVhlMerge.Value == "true" && rdoNeedVehicle.SelectedIndex == 0 && rdoVhlCompany.SelectedIndex == 0)
                {
                    return;
                }
                if (supplier == "" && hdnChrgMerge.Value == "true" && rdoNeedVehicle.SelectedIndex == 0 && rdoVhlCompany.SelectedIndex == 1)
                {
                    return;
                }

                XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);
                string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

                if (Request.QueryString["id"] != null || Request.QueryString["id"] != "")
                {
                    id = Request.QueryString["id"];
                }

                decimal ext = 0, logisCharge = 0, charge = 0, incentive = 0;
                try { logisCharge = decimal.Parse(hdnVhlPrice.Value); }
                catch { }
                try { charge = decimal.Parse(hdnChrgPrice.Value); }
                catch { }
                try { incentive = decimal.Parse(lblIncPr.Text); }
                catch { }


                string narrTop = "";
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " " + GridView1.Rows[i].Cells[14].Text + " " + GridView1.Rows[i].Cells[1].Text + "]";
                    }
                }

                SalesEntry se = new SalesEntry();
                se.AddUpdateSalesDO(xml, Session["sesUserID"].ToString(), ddlUnit.SelectedValue
                    , CommonClass.GetDateAtSQLDateFormat(txtDate.Text + " 09:00 AM"), txtChallan.Text.Trim(), hdnCustomer.Value
                    , ddlCusType.SelectedValue
                    , narrTop, txtAddress.Text.Trim(), hdnDis.Value, hdnPriceId.Value, hdnPriceIdV.Value, logisCharge
                    , bool.Parse(rdoNeedVehicle.SelectedValue), bool.Parse(rdoVhlCompany.SelectedValue)
                    , hdnVehicle.Value, hdnVehicleText.Value, ddlVhlType.SelectedValue
                    , ddlExtra.SelectedValue, charge, ddlIncentive.SelectedValue, incentive, supplier, supplierName, bool.Parse(rdo3rdPartyCharge.SelectedValue)
                    , ddlCurrency.SelectedValue, decimal.Parse(txtConvRate.Text), RadioButtonList1.SelectedValue, ext, "", txtNarration.Text.Trim(), txtDriver.Text.Trim(), txtDriverContact.Text.Trim(), ddlSo.SelectedValue, ddlShip.SelectedValue, ref code, ref id);

                RemoveGrid();

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    Response.Redirect("../../Accounts/Voucher/Exit.aspx");
                }
                else
                {
                    GetChallanNo();
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region EventHandler DropDownList

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlUnit.Items.Count; i++)
                {
                    if (ddlUnit.Items[i].Value == table[0].intUnitId.ToString())
                    {
                        ddlUnit.SelectedIndex = i;
                        ddlUnit.Enabled = false;
                        break;
                    }
                }
            }

            if ("" + hdnPriceId.Value == "") BuildTree();
            SalesConfigSet();
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalesConfigSet();
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            Reset();
            BindGrid(GetXmlFilePath());
        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
            Reset();
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            if (table != null && !table[0].IsintVehicleTypeIdNull())
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < ddlCusType.Items.Count; i++)
                    {
                        if (ddlCusType.Items[i].Value == table[0].intCustomerType.ToString())
                        {
                            ddlCusType.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }

            //txtCus.Text = "";
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
            //CustomerChange();
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;

            if (table != null)
            {
                for (int i = 0; i < ddlSo.Items.Count; i++)
                {
                    if (ddlSo.Items[i].Value == table[0].intSalesOffId.ToString())
                    {
                        ddlSo.SelectedIndex = i;
                        ddlSo.Enabled = false;
                        break;
                    }
                }
            }

            ddlCusType.DataBind();

            if (ddlSo.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlShip.Items.Count; i++)
                {
                    if (ddlShip.Items[i].Value == table[0].intShipPointId.ToString())
                    {
                        ddlShip.SelectedIndex = i;
                        ddlShip.Enabled = false;
                        break;
                    }
                }
            }
        }
        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        protected void ddlCurrency_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlCurrency.Items.Count; i++)
                {
                    if (ddlCurrency.Items[i].Value == table[0].intCurrencyId.ToString())
                    {
                        ddlCurrency.SelectedIndex = i;
                        ddlCurrency.Enabled = false;
                        break;
                    }
                }
            }

            SetPrice();
        }
        protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }
        protected void ddlUOM_DataBound(object sender, EventArgs e)
        {
            SetPrice();
        }

        protected void ddlExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExtraPr();
            ResetMain();
        }
        protected void ddlExtra_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlExtra.Items.Count; i++)
                {
                    if (ddlExtra.Items[i].Value == table[0].intChargeId.ToString())
                    {
                        ddlExtra.SelectedIndex = i;
                        break;
                    }
                }
            }

            ExtraPr();
            ResetMain();
        }

        protected void ddlVhlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VehiclePr();
        }

        protected void ddlVhlType_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlVhlType.Items.Count; i++)
                {
                    if (ddlVhlType.Items[i].Value == table[0].intVehicleTypeId.ToString())
                    {
                        ddlVhlType.SelectedIndex = i;
                        break;
                    }
                }
            }
            VehiclePr();
        }

        protected void ddlIncentive_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncentivePr();
            ResetMain();
        }
        protected void ddlIncentive_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlExtra.Items.Count; i++)
                {
                    if (ddlIncentive.Items[i].Value == table[0].intIncentiveId.ToString())
                    {
                        ddlIncentive.SelectedIndex = i;
                        break;
                    }
                }
            }

            IncentivePr();
            ResetMain();
        }

        #endregion

        #region EventHandler TextBox

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            SetPrice();
        }
        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            CustomerChange();
            SetPrice();
            txtVehicle.Focus();
            txtDis.Text = "";
        }
        protected void txtDis_TextChanged(object sender, EventArgs e)
        {
            DisPointChange();
        }
        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtProduct.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtProduct.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnProduct.Value = temp[temp.Length - 1];
                hdnProductText.Value = temp[0];
                //ysnvisible = objbll.GetVisibility(int.Parse(hdnProduct.Value));
                //if (!ysnvisible)
                //{
                //    lblPrice.Visible = false;
                //}
                //else
                //{
                //    lblPrice.Visible = true;
                //}
            }
            else
            {
                hdnProduct.Value = "";
            }

            ddlUOM.DataBind();

            txtQun.Focus();
        }
        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            VehicleChange();
            txtProduct.Focus();
        }

        #endregion

        #region EventHandler RadioButton

        protected void RadioButtonList1_DataBound(object sender, EventArgs e)
        {
            RadioButtonList1.SelectedIndex = 0;

            if (table != null && RadioButtonList1.Items.Count > 0)
            {
                for (int i = 0; i < RadioButtonList1.Items.Count; i++)
                {
                    if (RadioButtonList1.Items[i].Value == table[0].intSalesTypeId.ToString())
                    {
                        RadioButtonList1.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        protected void rdoNeedVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hdnXFactoryVhl.Value.ToLower() != "true")
            {
                if (rdoNeedVehicle.SelectedIndex == 0)
                {
                    pnlVehicle.Visible = true;
                }
                else
                {
                    pnlVehicle.Visible = false;
                }
            }

            ChangeNeedVehicle();
            VehiclePr();
        }
        protected void rdoVhlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCompanyVehicle();
        }

        #endregion

        #region Private

        private void ChangeNeedVehicle()
        {
            if (rdoNeedVehicle.SelectedValue.ToLower() == "true")
            {
                pnlVehicleMain.Visible = true;
                rdoVhlCompany.SelectedIndex = 0;
            }
            else
            {
                pnlVehicleMain.Visible = false;
                pnlVehicle3rd.Visible = false;
                ddlExtra.SelectedIndex = 0;
                ExtraPr();
            }
        }
        private void ChangeCompanyVehicle()
        {
            if (rdoVhlCompany.SelectedValue.ToLower() == "true")
            {
                pnlVehicle3rd.Visible = false;
                Session["sesCurVhlCom"] = true;
            }
            else
            {
                pnlVehicle3rd.Visible = true;
                Session["sesCurVhlCom"] = false;
                txtSupplier.Text = "";
            }

            txtVehicle.Text = "";
        }
        private void RemoveGrid()
        {
            if (File.Exists(GetXmlFilePath()))
            {
                File.Delete(GetXmlFilePath());
                BindGrid(GetXmlFilePath());
            }
        }
        private string GetXmlFilePath()
        {
            string unit = "";
            unit = "" + hdnUnit.Value;
            if (unit == "") unit = ddlUnit.SelectedValue;

            return Server.MapPath("") + "/Data/" + Session[SessionParams.USER_ID] + "_" + unit + "_item.xml";
        }
        private void BindGrid(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath)) xm.LoadXmlFile(xmlFilePath);

            XmlDataSource1.Dispose();
            XmlDataSource1.DataFile = xmlFilePath;
            GridView1.DataBind();

        }

        private void SetPrice()
        {
            IncentivePr();
            ExtraPr();
            VehiclePr();

            if (hdnProduct.Value != "")
            {
                ItemPrice it = new ItemPrice();
                decimal commission = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;
                decimal convRate = 0;

                decimal pr = it.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, RadioButtonList1.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);


                if (pr > 0)
                {
                    decimal vhlPr = 0, chrPr = 0, inc = 0;

                    if (hdnLogisBasedOnUom.Value.ToLower() == "true")
                    {
                        try { vhlPr = decimal.Parse(lblVhkPr.Text); }
                        catch { }
                    }
                    if (hdnCharBasedOnUom.Value.ToLower() == "true")
                    {
                        try { chrPr = decimal.Parse(lblExtPr.Text); }
                        catch { }
                    }
                    if (hdnIncenBasedOnUom.Value.ToLower() == "true")
                    {
                        try { inc = decimal.Parse(lblIncPr.Text); }
                        catch { }
                    }

                    if (hdnXFactoryVhl.Value == "true")
                    {
                        pr -= vhlPr;
                    }
                    /*else
                    {
                        pr += vhlPr;
                    }*/


                    if (hdnXFactoryChr.Value == "true")
                    {
                        pr -= chrPr;
                    }
                    /*else
                    {
                        pr += chrPr;
                    }

                    pr -= inc;*/
                }
                //============== Edited By konock on 26th May2014 =============
                hdnsalestype.Value = RadioButtonList1.SelectedItem.ToString();
                hdnvisibility.Value = objbll.GetVisibility(int.Parse(hdnProduct.Value)).ToString();
                //================== End edited ==============
                // lblPrice.Text = CommonClass.GetFormettingNumber(pr);
                lblPrice.Text = pr.ToString();
                lblComm.Text = CommonClass.GetFormettingNumber(commission);
                hdnSuppTax.Value = CommonClass.GetFormettingNumber(suppTax);
                hdnVat.Value = CommonClass.GetFormettingNumber(vat);
                hdnVatPrice.Value = CommonClass.GetFormettingNumber(vatPrice);
                txtConvRate.Text = convRate.ToString();
                if (pr <= 0 && (hdnUnit.Value != "3" && int.Parse(ddlUnit.SelectedValue.ToString()) != 3) &&
                    (hdnUnit.Value != "21" && int.Parse(ddlUnit.SelectedValue.ToString()) != 21) &&
                    (hdnUnit.Value != "55" && int.Parse(ddlUnit.SelectedValue.ToString()) != 55) &&
                    (hdnUnit.Value != "56" && int.Parse(ddlUnit.SelectedValue.ToString()) != 56) &&
                    (hdnUnit.Value != "15" && int.Parse(ddlUnit.SelectedValue.ToString()) != 15)) 
                { btnAdd.Enabled = false; }
                else { btnAdd.Enabled = true; }
                if ((hdnsalestype.Value == "Local Sales" || hdnsalestype.Value == "Ready Mix") && hdnvisibility.Value == "False")
                { lblPrice.Visible = false; }
                else { lblPrice.Visible = true; }
            }
            else
            {
                lblPrice.Text = "0.0";
                lblLogisGain.Text = "0.0";
                lblComm.Text = "0.0";
                hdnSuppTax.Value = "0.0";
                hdnVat.Value = "0.0";
                hdnVatPrice.Value = "0.0";
            }
        }
        private void ExtraPr()
        {
            ExtraCharge ex = new ExtraCharge();
            lblExtPr.Text = CommonClass.GetFormettingNumber(ex.GetExtraCharg(ddlExtra.SelectedValue, ddlUOM.SelectedValue, hdnProduct.Value, ddlCurrency.SelectedValue));

        }
        private void IncentivePr()
        {
            Incentive ex = new Incentive();
            lblIncPr.Text = CommonClass.GetFormettingNumber(ex.GetIncentive(ddlIncentive.SelectedValue, ddlUOM.SelectedValue, hdnProduct.Value, ddlCurrency.SelectedValue));

        }
        private void VehiclePr()
        {
            bool enableLogis, logisBy3rdParty;
            decimal logisGain = 0;

            if (rdoNeedVehicle.SelectedValue.ToLower() == "true") enableLogis = true;
            else enableLogis = false;

            if (rdoVhlCompany.SelectedValue.ToLower() == "true") logisBy3rdParty = false;
            else logisBy3rdParty = true;



            if (hdnXFactoryVhl.Value.ToLower() == "true")
            {
                VehicleVarPrice vp = new VehicleVarPrice();
                lblVhkPr.Text = CommonClass.GetFormettingNumber(vp.GetPrice(ddlShip.SelectedValue, hdnProduct.Value, hdnVehicle.Value, ddlVhlType.SelectedValue, hdnCustomer.Value, hdnPriceIdV.Value, ddlCurrency.SelectedValue, ddlUOM.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text), enableLogis, logisBy3rdParty, ref logisGain));
            }
            else
            {
                if (rdoNeedVehicle.SelectedValue.ToLower() == "true")
                {
                    VehicleVarPrice vp = new VehicleVarPrice();
                    lblVhkPr.Text = CommonClass.GetFormettingNumber(vp.GetPrice(ddlShip.SelectedValue, hdnProduct.Value, hdnVehicle.Value, ddlVhlType.SelectedValue, hdnCustomer.Value, hdnPriceIdV.Value, ddlCurrency.SelectedValue, ddlUOM.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text), enableLogis, logisBy3rdParty, ref logisGain));
                }
                else
                {
                    lblVhkPr.Text = "0.0";
                }
            }

            lblLogisGain.Text = CommonClass.GetFormettingNumber(logisGain);
        }
        private void VehicleChange()
        {
            string dName = "";
            string dContact = "";
            if (txtVehicle.Text.Trim() != "")// && rdoVhlCompany.SelectedValue == "true")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (temp.Length <= 1) hdnVehicle.Value = "";
                    else
                    {
                        hdnVehicle.Value = temp[temp.Length - 1];

                        Vehicle n = new Vehicle();
                        n.GetVehicleInfoById(hdnVehicle.Value, ref dName, ref dContact);
                        txtDriver.Text = dName;
                        txtDriverContact.Text = dContact;                        
                    }
                }
                catch (Exception e)
                {
                    hdnVehicle.Value = "";
                }

                hdnVehicleText.Value = temp[0];
            }
            else
            {
                hdnVehicleText.Value = txtVehicle.Text.Trim();
                hdnVehicle.Value = "";
            }
        }

        private void DisPointChange()
        {
            DistributionPoint dp = new DistributionPoint();

            if (txtDis.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtDis.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnDis.Value = temp[temp.Length - 1];
                hdnDisText.Value = temp[0];

                if (hdnDis.Value != "")
                {
                    DistributionPointTDS.QryDisPointDataTable table = dp.GetDataById(hdnDis.Value);
                    if (table.Rows.Count > 0)
                    {
                        txtAddress.Text = table[0].strAddress;

                        hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceCatagoryNull() ? "" : table[0].intPriceCatagory.ToString();
                        hdnDDLChangedSelectedIndexV.Value = table[0].IsintLogisticCatagoryNull() ? "" : table[0].intLogisticCatagory.ToString();

                        if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                        {
                            BuildTree();
                        }
                    }
                }
            }
        }
        private void CustomerChange()
        {
            if (txtCus.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnCustomer.Value = temp[temp.Length - 1];
                hdnCustomerText.Value = temp[0];
            }

            if (hdnCustomer.Value == "") { txtProduct.ReadOnly = true; }
            else
            {
                CustomerInfo ci = new CustomerInfo();
                CustomerTDS.TblCustomerShortDataTable tbl = ci.GetCustomerShortInfoById(hdnCustomer.Value);

                if (tbl.Rows.Count > 0)
                {
                    if (!pnlDis.Visible)
                    {
                        txtAddress.Text = tbl[0].strAddress;
                        hdnDDLChangedSelectedIndex.Value = tbl[0].IsintPriceCatagoryNull() ? "" : tbl[0].intPriceCatagory.ToString();
                        hdnDDLChangedSelectedIndexV.Value = tbl[0].IsintLogisticCatagoryNull() ? "" : tbl[0].intLogisticCatagory.ToString();


                        if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                        {
                            BuildTree();
                        }
                    }
                    txtProduct.ReadOnly = false;
                    txtDis.ReadOnly = false;
                    txtAddress.ReadOnly = false;
                    Session["sesCurrentCus"] = hdnCustomer.Value;

                    decimal lm = 0, bl = 0;
                    ci.GetCustomerCreditLimitCreditBalance(hdnCustomer.Value, ddlUnit.SelectedValue, Session[SessionParams.USER_ID].ToString(), ref lm, ref bl);

                    lblLM.Text = CommonClass.GetFormettingNumber(lm);
                    lblBl.Text = CommonClass.GetFormettingNumber(bl);

                    hdnLm.Value = lblLM.Text;
                    hdnBl.Value = lblBl.Text;

                    btnAdd.Enabled = CheckLimitBalance(0);
                }
            }
        }

        private bool CheckLimitBalance(decimal currentAmount)
        {
            decimal lm = decimal.Parse(hdnLm.Value);
            decimal bl = decimal.Parse(hdnBl.Value);
            decimal cur = 0;//lm + bl - currentAmount;

            if (hdnCreditSales.Value == "true")
            {
                cur = lm + (bl*-1) - currentAmount;  //cur = lm + bl - currentAmount;
                //hdnRest.Value = cur.ToString();
                if (lm > 0 && cur >= 0)
                {
                    return true;
                }
                //else if (lm >= 0 && cur < 0 && (hdnUnit.Value == "2" || int.Parse(ddlUnit.SelectedValue.ToString()) == 2)) //else if (lm > 0 && cur < 0)
                else if (lm >= 0 && cur < 0 && (hdnUnit.Value == "2" || int.Parse(ddlUnit.SelectedValue.ToString()) == 2 || hdnUnit.Value == "6" || int.Parse(ddlUnit.SelectedValue.ToString()) == 6 || hdnUnit.Value == "1" || int.Parse(ddlUnit.SelectedValue.ToString()) == 1)) //else if (lm > 0 && cur < 0)
                {
                    return false;
                }

                return true;
            }
            else
            {
                //hdnRest.Value = bl.ToString();

                if (bl >= currentAmount)
                {
                    return true;
                }

                return false;
            }
        }
        private void SalesConfigSet()
        {
            SalesConfig sc = new SalesConfig();
            SalesConfigTDS.TblSalesConfigDataTable t = sc.GetInfoForDO(ddlUnit.SelectedValue);

            if (t.Rows.Count > 0)
            {
                bool editPr = t[0].ysnEditPriceInDO;
                bool viewPr = t[0].ysnViewPriceInDO;
                bool chln = t[0].ysnChallanNoDO;
                bool dis = false;//t[0].ysnDisPointEnable;
                hdnLogisBasedOnUom.Value = t[0].ysnLogisBasedOnUOM.ToString().ToLower();
                hdnCharBasedOnUom.Value = t[0].ysnCharBasedOnUOM.ToString().ToLower();
                hdnIncenBasedOnUom.Value = t[0].ysnIncentiveBasedOnUOM.ToString().ToLower();
                hdnCreditSales.Value = t[0].ysnCreditSales.ToString().ToLower();
                hdnXFactoryVhl.Value = t[0].ysnXFactoryPriceFixedForLogis.ToString().ToLower();
                hdnXFactoryChr.Value = t[0].ysnXFactoryPriceFixedForCharge.ToString().ToLower();
                hdnVhlMerge.Value = t[0].ysnVehicleAccountMerge.ToString().ToLower();
                hdnChrgMerge.Value = t[0].ysnChargeAccountMerge.ToString().ToLower();

                Session["sesSupplierParent"] = t[0].IsintSupplierCOAParentNull() ? "" : t[0].intSupplierCOAParent.ToString();

                pnlDis.Visible = dis;
                lblPrice.ReadOnly = !editPr;
                lblLogisGain.ReadOnly = !editPr;
                lblVhkPr.ReadOnly = !editPr;
                lblExtPr.ReadOnly = !editPr;

                if (viewPr)
                {
                    lblPrice.CssClass = "";
                    lblLogisGain.CssClass = "";
                    lblTotal.CssClass = "";
                    //lblGT.CssClass = "";
                    lblExtPr.CssClass = "";
                    lblVhkPr.CssClass = "";
                    lblExtPr.CssClass = "";

                    GridView1.Columns[4].Visible = true;
                    GridView1.Columns[5].Visible = true;
                    GridView1.Columns[6].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                    GridView1.Columns[11].Visible = true;
                    GridView1.Columns[12].Visible = true;
                }
                else
                {
                    lblPrice.CssClass = "hide";
                    lblLogisGain.CssClass = "hide";
                    lblTotal.CssClass = "hide";
                    //lblGT.CssClass = "hide";
                    lblExtPr.CssClass = "hide";
                    lblVhkPr.CssClass = "hide";
                    lblExtPr.CssClass = "hide";

                    GridView1.Columns[4].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;
                }


                pnlChallan.Visible = chln;

                if (t[0].ysnDefaultLogis)
                {
                    rdoNeedVehicle.SelectedIndex = 0;
                    pnlVehicleMain.Visible = true;
                }
                else
                {
                    rdoNeedVehicle.SelectedIndex = 1;
                    pnlVehicleMain.Visible = false;
                }

                if (t[0].ysnVehicleAccountMerge)
                {
                    rdo3rdPartyCharge.Enabled = true;
                }
                else
                {
                    rdo3rdPartyCharge.Enabled = false;
                }

                pnlClCb.Visible = t[0].ysnCrInfoInDO;

            }
        }
        private void Reset()
        {

            string custype = ddlCusType.SelectedItem.ToString();
            //txtCus.Text = "";
            //if (custype == "Local")
            //{
            //    lblPrice.Visible = true;
            //}
            //else
            //{
            //    lblPrice.Visible = true;
            //}
            RadioButtonList1.SelectedIndex = 1;
            txtDis.Text = "";
            txtAddress.Text = "";
            lblBl.Text = "0.0";
            lblLM.Text = "0.0";
        }
        private void ResetMain()
        {
            hdnProduct.Value = "";
            txtProduct.Text = "";
            ddlUOM.Items.Clear();
            txtQun.Text = "";
            lblPrice.Text = "0.0";
            lblLogisGain.Text = "0.0";
            ysnvisible = false;
        }

        private void GetChallanNo()
        {
            string startNo, endNo = "", leftPart = "", tmp = "";
            int lastUsedNum;

            if (txtChallan.Text != "")
            {
                if ("" + Session["sesChlnNo"] == "" && txtChallan.Text != "")
                {
                    Session["sesChlnNo"] = txtChallan.Text;
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
                    txtChallan.Text = Session["sesChlnNo"].ToString();
                }
            }
        }

        #endregion

        #region Dynamin
        private void BuildTree()
        {
            tbl.Controls.Clear();
            tblV.Controls.Clear();

            if (IsPostBack || table != null)
            {
                ItemPriceManager im = new ItemPriceManager();
                tblUpperLevel = im.GetAllUpperLevel(hdnDDLChangedSelectedIndex.Value);

                VehicleManager itemV = new VehicleManager();
                tblUpperLevelV = itemV.GetAllUpperLevel(hdnDDLChangedSelectedIndexV.Value);
            }

            GetItemInfo("");
            GetItemInfoP("");
            pnlMain.Controls.Add(tbl);
            pnlVehicle.Controls.Add(tblV);

            SetPrice();
        }
        private void GetItemInfo(string parentID)
        {
            int level;
            td = new TableCell();
            tdLbl = new TableCell();
            tdCon = new TableCell();

            ItemPriceManager item = new ItemPriceManager();
            ItemPriceManagerTDS.TblItemPriceManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, ddlUnit.SelectedValue);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddl" + level + "_" + 1;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevel != null && tblUpperLevel.Rows.Count > 0)
                {
                    DataRow[] row = tblUpperLevel.Select("intLevel=" + level);
                    if (row.Length > 0) id = row[0][0].ToString();
                }

                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dataTable[i].strText, dataTable[i].intID.ToString()));
                    if (dataTable[i].intID.ToString() == id)
                    {
                        ddl.SelectedIndex = i;
                    }
                }

                Label lbl = new Label();
                lbl.Text = item.GetLabel(level.ToString(), ddlUnit.SelectedValue, parentID) + " ";
                tdLbl.Controls.Add(lbl);
                td.Controls.Add(ddl);

                //tdCon.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChange('" + ddl.ID + "');");

                nextParentID = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnPriceId.Value = ddl.SelectedValue;
                    //tdCon.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                //tdCon.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                tr.Cells.Add(tdLbl);
                tr.Cells.Add(td);
                tdCon.Style.Add("padding-left", "10px");
                tdCon.Style.Add("padding-right", "20px");
                tr.Controls.Add(tdCon);

                tbl.Rows.Add(tr);
                tr = new TableRow();

                GetItemInfo(ddl.SelectedValue);
            }
            /*else
            {
                if (nextParentID == "")
                {
                    td.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                    tr.Cells.Add(td);
                    tbl.Rows.Add(tr);
                    hdnPriceId.Value = "";
                }
            }*/
        }
        private void GetItemInfoP(string parentID)
        {
            int level;
            tdV = new TableCell();
            tdLblV = new TableCell();
            tdConV = new TableCell();

            VehicleManager item = new VehicleManager();
            VehicleManagerTDS.TblVehiclePriceManagerDataTable dataTable;

            dataTable = item.GetDataByParent(parentID, ddlUnit.SelectedValue);
            if (dataTable.Rows.Count > 0)
            {
                DropDownList ddl = new DropDownList();

                level = dataTable[0].intLevel;
                ddl.ID = "ddlP" + level + "_" + 1;
                ddl.Items.Add(new ListItem(dataTable[0].strText, dataTable[0].intID.ToString()));

                string id = "";

                if (tblUpperLevelV != null && tblUpperLevelV.Rows.Count > 0)
                {
                    DataRow[] row = tblUpperLevelV.Select("intLevel=" + level);
                    if (row.Length > 0) id = row[0][0].ToString();
                }

                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    ddl.Items.Add(new ListItem(dataTable[i].strText, dataTable[i].intID.ToString()));
                    if (dataTable[i].intID.ToString() == id)
                    {
                        ddl.SelectedIndex = i;
                    }
                }

                Label lbl = new Label();
                lbl.Text = item.GetLabel(level.ToString(), ddlUnit.SelectedValue, parentID) + " ";
                tdLblV.Controls.Add(lbl);
                tdV.Controls.Add(ddl);

                //tdConP.Controls.Add(BuildAnchor(" AD", "ShowDivWithoutLabel(" + level + "," + 1 + ");"));

                ddl.AutoPostBack = true;
                ddl.Attributes.Add("onChange", "DDLChangeV('" + ddl.ID + "');");

                nextParentIDP = ddl.SelectedValue;

                //just only have not any child
                if (item.GetChildCount(ddl.SelectedValue) <= 0)
                {
                    hdnPriceIdV.Value = ddl.SelectedValue;
                    //tdConP.Controls.Add(BuildAnchor(" SB", "ShowDiv(" + (level + 1) + "," + 1 + ");"));
                }


                //tdConP.Controls.Add(BuildAnchor(" LB", "ShowDivWithoutText(" + level + "," + /*subLevel*/1 + ");"));
                trV.Cells.Add(tdLblV);
                trV.Cells.Add(tdV);
                tdConV.Style.Add("padding-left", "10px");
                tdConV.Style.Add("padding-right", "20px");
                trV.Controls.Add(tdConV);

                tblV.Rows.Add(trV);
                trV = new TableRow();

                GetItemInfoP(ddl.SelectedValue);
            }
            else
            {
                if (nextParentIDP == "")
                {
                    //tdP.Controls.Add(BuildAnchor("Add", "ShowDiv(1,1);"));
                    trV.Cells.Add(tdV);
                    tblV.Rows.Add(trV);
                    hdnPriceIdV.Value = "";
                }
            }
        }
        private HtmlAnchor BuildAnchor(string text, string attrMethod)
        {
            HtmlAnchor htA = new HtmlAnchor();
            htA.InnerText = text;
            htA.HRef = "#";
            htA.Attributes.Add("onclick", attrMethod);
            return htA;
        }
        #endregion

    }
}