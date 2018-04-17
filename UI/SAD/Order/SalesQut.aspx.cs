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

namespace UI.SAD.Order
{
    public partial class SalesQut : BasePage
    {
        XmlManagerSO xm = new XmlManagerSO();
        SalesOrderTDS.QrySalesOrderCustomerDataTable table;

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
                //Session["sesUserID"] = "53";

                if (Request.QueryString["id"] != null)
                {
                    SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                    table = se.GetSalesOrder(Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        hdnUnit.Value = table[0].intUnitId.ToString();
                        txtConvRate.Text = table[0].numConversionRate.ToString();
                        if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());

                        SalesOrderTDS.QrySalesOrderDetailsDataTable tbl = se.GetSalesOrderDetails(table[0].intId.ToString());

                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            string[][] items = xm.CreateItems(tbl[i].intProductId.ToString()
                                , tbl[i].strProductName
                                , tbl[i].numQuantity.ToString()
                                , tbl[i].numApprQuantity.ToString()
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
                                , tbl[i].IsnumPromotionNull() ? "" : tbl[i].numPromotion.ToString()
                                , tbl[i].IsmonCommissionNull() ? "" : tbl[i].monCommission.ToString()
                                , tbl[i].IsintIncentiveIdNull() ? "" : tbl[i].intIncentiveId.ToString()
                                , tbl[i].IsnumIncentiveNull() ? "" : tbl[i].numIncentive.ToString()
                                , tbl[i].IsmonSuppTaxNull() ? "" : tbl[i].monSuppTax.ToString()
                                , tbl[i].IsmonVATNull() ? "" : tbl[i].monVAT.ToString()
                                , tbl[i].IsmonVatPriceNull() ? "" : tbl[i].monVatPrice.ToString()
                                , tbl[i].IsintPromItemIdNull() ? "" : tbl[i].intPromItemId.ToString()
                                , tbl[i].IsstrPromItemNameNull() ? "" : tbl[i].strPromItemName
                                , tbl[i].IsintPromUOMNull() ? "" : tbl[i].intPromUOM.ToString()
                                , tbl[i].IsstrPromUomNull() ? "" : tbl[i].strPromUom
                                , tbl[i].IsmonPromPriceNull() ? "0" : tbl[i].monPromPrice.ToString()
                                , tbl[i].IsintPromItemCOAIdNull() ? "0" : tbl[i].intPromItemCOAId.ToString()
                                , tbl[i].intId.ToString()
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
                    txtDelDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));
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
                        txtDelDate.Text = CommonClass.GetShortDateAtLocalDateFormat(table[0].dteReqDelivaryDate);

                        txtQun.Text = "";
                        txtOther.Text = table[0].strOtherInfo;
                        txtContact.Text = table[0].strContactAt;
                        txtPhone.Text = table[0].strContactPhone;

                        txtCus.Text = table[0].strName + " [" + table[0].intCustomerId + "]";
                        hdnCustomer.Value = table[0].intCustomerId.ToString();

                        if (!table[0].IsintDisPointIdNull())
                        {
                            txtDis.Text = table[0].strDisPointName + " [" + table[0].intDisPointId + "]";
                            DisPointChange();
                        }
                        else
                        {
                            txtCus.Text = table[0].strName + " [" + table[0].intCustomerId + "]";
                            CustomerChange();
                        }

                        txtAddress.Text = table[0].strAddress;

                        if (table[0].ysnLogistic)
                        {
                            rdoNeedVehicle.SelectedIndex = 0;
                        }
                        else
                        {
                            rdoNeedVehicle.SelectedIndex = 1;
                        }

                        hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceVarIdNull() ? "" : table[0].intPriceVarId.ToString();
                        hdnDDLChangedSelectedIndexV.Value = table[0].IsintVehicleVarIdNull() ? "" : table[0].intVehicleVarId.ToString();

                        btnSubmit.Text = "Update Sales";
                    }
                }

                lblPrice.Attributes.Add("onkeyup", "SetPrice()");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                hdnPrice.Value = lblPrice.Text;

                if (hdnCustomer.Value != "") BuildTree();
            }
            else
            {
                pnlMarque.DataBind();
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
            return DistributionPointSt.GetDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString());
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetProductList(string prefixText, int count)
        {
            return ItemSt.GetProductDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText);
        }

        #endregion

        #region GridView

        protected string GetTotal(string pr, string qnt)
        {
            decimal tot = (decimal.Parse(pr) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);
        }

        protected string GetTotal(string pr, string qnt, string inc)
        {
            decimal tot = (decimal.Parse(pr) - decimal.Parse(inc));
            tot = tot * decimal.Parse(qnt);
            return CommonClass.GetFormettingNumber(tot);
        }
        protected string GetFullTotal(string pr, string qnt, string ext, string inc)
        {
            decimal tot = (decimal.Parse(pr) + decimal.Parse(ext) - decimal.Parse(inc));
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
                if (hdnCharBasedOnUom.Value != "true")
                {
                    tot += decimal.Parse(lblExtPr.Text);
                }
                if (hdnIncenBasedOnUom.Value != "true")
                {
                    tot -= decimal.Parse(txtIncPr.Text);
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
            if (GridView1.Rows.Count <= 0 && ("" + hdnCustomer.Value) == "")
            {
                EnabeDisable(false, true, false);
            }
            else if (GridView1.Rows.Count <= 0 && hdnCustomer.Value != "")
            {
                EnabeDisable(false, true, true);
            }
            else
            {
                EnabeDisable(true, false, true);
            }
        }

        #endregion

        #region Button
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnCustomer.Value != "" && hdnProduct.Value != "" && txtQun.Text.Trim() != "")
            {
                string coaId = "", coaName = "";
                SAD_BLL.Item.Item it = new SAD_BLL.Item.Item();

                it.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, rdoSalesType.SelectedValue, ref coaId, ref coaName);

                if (coaId != "" && coaId != "0" && coaName != "")
                {
                    string narr = txtQun.Text.Trim() + " " + ddlUOM.SelectedItem.Text + " " + hdnProductText.Value + " Sold";

                    narr += " To " + hdnCustomerText.Value;

                    string chrPr = "0.0", incPr = "0.0";

                    if (hdnXFactoryChr.Value == "true" && rdoNeedVehicle.SelectedIndex == 0)
                    {
                        if (hdnCharBasedOnUom.Value == "true") chrPr = lblExtPr.Text;
                    }
                    else if (hdnXFactoryChr.Value != "true")
                    {
                        if (hdnCharBasedOnUom.Value == "true") chrPr = lblExtPr.Text;
                    }

                    if (hdnIncenBasedOnUom.Value == "true") incPr = txtIncPr.Text;


                    decimal promQnty = 0;
                    int promItemId = 0;
                    int promItemCOAId = 0;
                    int promItemUOM = 0;
                    string promItem = "";
                    string promUom = "";

                    ItemPromotion ip = new ItemPromotion();
                    decimal promPrice = ip.GetPromotion(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue
                        , ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                        , txtQun.Text, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);


                    if (promItemId.ToString() == hdnProduct.Value)
                    {
                        promPrice = decimal.Parse(hdnPrice.Value);
                        promItemCOAId = int.Parse(coaId);
                    }

                    string[][] items = xm.CreateNewItems(hdnProduct.Value, hdnProductText.Value
                        , txtQun.Text, txtQun.Text, hdnPrice.Value, coaId, coaName, ddlExtra.SelectedValue
                        , ddlExtra.SelectedItem.Text, chrPr, ddlUOM.SelectedValue, ddlUOM.SelectedItem.Text
                        , ddlCurrency.SelectedValue, narr, rdoSalesType.SelectedValue.ToString()
                        , hdnDDLChangedSelectedIndexV.Value, promQnty.ToString(), lblComm.Text
                        , ddlIncentive.SelectedValue, incPr, hdnSuppTax.Value, hdnVat.Value, hdnVatPrice.Value
                        , promItemId.ToString(), promItem, promItemUOM.ToString(), promUom
                        , promPrice.ToString(), promItemCOAId.ToString());


                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                    selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    xmlDoc.Save(GetXmlFilePath());

                    txtQun.Text = "";

                    BindGrid(GetXmlFilePath());

                    hdnProduct.Value = "";
                    txtProduct.Text = "";
                    txtProduct.Focus();
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RemoveGrid();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string id = "", code = "";
            char[] ch = { '[', ']' };

            XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
            XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);
            string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

            if (Request.QueryString["id"] != null || Request.QueryString["id"] != "")
            {
                id = Request.QueryString["id"];
            }

            decimal ext = 0, charge = 0, incentive = 0;

            try { charge = decimal.Parse(lblExtPr.Text); }
            catch { }
            try { incentive = decimal.Parse(txtIncPr.Text); }
            catch { }


            string narrTop = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " " + GridView1.Rows[i].Cells[12].Text + " " + GridView1.Rows[i].Cells[1].Text + "]";
                }
            }


            SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
            se.AddUpdateSalesOrder(xml, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                 , CommonClass.GetDateAtSQLDateFormat(txtDate.Text), CommonClass.GetDateAtSQLDateFormat(txtDelDate.Text)
                 , hdnCustomer.Value, ddlCusType.SelectedValue, narrTop, txtAddress.Text.Trim(), hdnDis.Value, hdnPriceId.Value, hdnPriceIdV.Value
                 , bool.Parse(rdoNeedVehicle.SelectedValue)
                 , ddlExtra.SelectedValue, charge, ddlIncentive.SelectedValue, incentive
                 , ddlCurrency.SelectedValue, decimal.Parse(txtConvRate.Text), rdoSalesType.SelectedValue, ext, "", ""
                 , txtContact.Text.Trim(), txtPhone.Text.Trim(), ddlSo.SelectedValue
                 , ddlShip.SelectedValue, ref code, ref id);

            RemoveGrid();

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                Response.Redirect("../../Accounts/Voucher/Exit.aspx");
            }

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

            if (hdnCustomer.Value != "") BuildTree();
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
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
            Reset();
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            if (table != null)
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

            txtCus.Text = "";
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
            Reset();
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
        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
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

        protected void ddlIncentive_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncentivePr();
            ResetMain();
        }
        protected void ddlIncentive_DataBound(object sender, EventArgs e)
        {
            if (table != null)
            {
                for (int i = 0; i < ddlIncentive.Items.Count; i++)
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

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            CustomerChange();
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
            }
            else
            {
                hdnProduct.Value = "";
            }

            ddlUOM.DataBind();

            txtQun.Focus();
        }

        #endregion

        #region EventHandler RadioButton

        protected void rdoSalesType_DataBound(object sender, EventArgs e)
        {
            rdoSalesType.SelectedIndex = 0;

            if (table != null && rdoSalesType.Items.Count > 0)
            {
                for (int i = 0; i < rdoSalesType.Items.Count; i++)
                {
                    if (rdoSalesType.Items[i].Value == table[0].intSalesTypeId.ToString())
                    {
                        rdoSalesType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        protected void rdoSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPrice();
        }

        #endregion


        #region Private

        private void EnabeDisable(bool ysn, bool cus, bool product)
        {
            btnCancel.Visible = ysn;
            btnSubmit.Visible = ysn;

            ddlCurrency.Enabled = ysn;
            txtConvRate.Enabled = ysn;
            ddlCusType.Enabled = ysn;
            ddlUnit.Enabled = ysn;
            pnlMain.Enabled = ysn;
            pnlVehicle.Enabled = ysn;
            rdoNeedVehicle.Enabled = ysn;
            imgCal_1.Disabled = ysn;

            txtProduct.Enabled = product;
            txtQun.Enabled = product;
            lblPrice.Enabled = product;

            lblExtPr.Enabled = cus;
            txtIncPr.Enabled = cus;
            txtCus.Enabled = cus;
            txtDis.Enabled = cus;
            pnlMain.Enabled = cus;
            pnlVehicle.Enabled = cus;

            rdoSalesType.Enabled = cus;
            rdoNeedVehicle.Enabled = cus;

            ddlCurrency.Enabled = cus;
            ddlUnit.Enabled = cus;
            ddlShip.Enabled = cus;
            ddlSo.Enabled = cus;
            ddlCusType.Enabled = cus;
            ddlExtra.Enabled = cus;
            ddlIncentive.Enabled = cus;
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

            return Server.MapPath("") + "/Data/OR/" + Session["sesUserID"] + "_" + unit + "_item.xml";
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
            //IncentivePr();
            //ExtraPr();        

            if (hdnProduct.Value != "")
            {
                ItemPrice it = new ItemPrice();
                decimal commission = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;
                decimal convRate = 0;

                decimal pr = it.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);


                if (pr > 0)
                {
                    decimal chrPr = 0, inc = 0;

                    if (hdnCharBasedOnUom.Value.ToLower() == "true")
                    {
                        try { chrPr = decimal.Parse(lblExtPr.Text); }
                        catch { }
                    }
                    if (hdnIncenBasedOnUom.Value.ToLower() == "true")
                    {
                        try { inc = decimal.Parse(txtIncPr.Text); }
                        catch { }
                    }

                    if (hdnXFactoryChr.Value == "true")
                    {
                        pr -= chrPr;
                    }
                }

                lblPrice.Text = CommonClass.GetFormettingNumber(pr);

                lblComm.Text = CommonClass.GetFormettingNumber(commission);
                hdnSuppTax.Value = CommonClass.GetFormettingNumber(suppTax);
                hdnVat.Value = CommonClass.GetFormettingNumber(vat);
                hdnVatPrice.Value = CommonClass.GetFormettingNumber(vatPrice);
                txtConvRate.Text = convRate.ToString();
            }
            else
            {
                lblPrice.Text = "0.0";
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
            txtIncPr.Text = CommonClass.GetFormettingNumber(ex.GetIncentive(ddlIncentive.SelectedValue, ddlUOM.SelectedValue, hdnProduct.Value, ddlCurrency.SelectedValue));

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
                    DistributionPointTDS.SprGetDisPointInfoForSalesOrderDataTable table = dp.GetDisPointInfoForSalesOrder(hdnDis.Value, Session["sesUserID"].ToString(), ddlUnit.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text));
                    if (table.Rows.Count > 0)
                    {
                        hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceCatagoryNull() ? "" : table[0].intPriceCatagory.ToString();
                        hdnDDLChangedSelectedIndexV.Value = table[0].IsintLogisticCatagoryNull() ? "" : table[0].intLogisticCatagory.ToString();

                        hdnCustomer.Value = table[0].intCusID.ToString();
                        hdnCustomerText.Value = table[0].strCusName;
                        lblCust.Text = table[0].strCusName;
                        txtAddress.Text = table[0].strAddress;
                        txtContact.Text = table[0].strContactPerson;
                        txtPhone.Text = table[0].strContactNo;

                        lblLM.Text = CommonClass.GetFormettingNumber(table[0].monCreditLimit);
                        lblBl.Text = CommonClass.GetFormettingNumber(table[0].monOutstanding);
                        lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                        lblGroup.Text = table[0].strGroup;

                        if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                        {
                            if (hdnCustomer.Value != "") BuildTree();
                        }

                    }

                    if (GridView1.Rows.Count > 0) EnabeDisable(true, false, true);
                    else EnabeDisable(true, true, true);
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
                CustomerTDS.SprGetCustomerInfoForSalesOrderDataTable table = ci.GetCustomerInfoForSalesOrder(hdnCustomer.Value, Session["sesUserID"].ToString(), ddlUnit.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text));

                if (table.Rows.Count > 0)
                {
                    hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceCatagoryNull() ? "" : table[0].intPriceCatagory.ToString();
                    hdnDDLChangedSelectedIndexV.Value = table[0].IsintLogisticCatagoryNull() ? "" : table[0].intLogisticCatagory.ToString();

                    txtAddress.Text = table[0].strAddress;
                    txtContact.Text = table[0].strContactPerson;
                    txtPhone.Text = table[0].strContactNo;

                    lblLM.Text = CommonClass.GetFormettingNumber(table[0].monCreditLimit);
                    lblBl.Text = CommonClass.GetFormettingNumber(table[0].monOutstanding);
                    lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                    hdnLm.Value = lblLM.Text;
                    hdnBl.Value = lblBl.Text;
                    hdnPN.Value = lblPN.Text;

                    lblGroup.Text = table[0].strGroup;

                    if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                    {
                        if (hdnCustomer.Value != "") BuildTree();
                    }

                    btnAdd.Enabled = CheckLimitBalance(0);

                    if (GridView1.Rows.Count > 0) EnabeDisable(true, false, true);
                    else EnabeDisable(true, true, true);
                }
            }
        }
        private bool CheckLimitBalance(decimal currentAmount)
        {
            decimal lm = decimal.Parse(hdnLm.Value);
            decimal bl = decimal.Parse(hdnBl.Value);
            decimal pn = decimal.Parse(hdnPN.Value);
            decimal cur = 0;

            if (hdnCreditSales.Value == "true")
            {
                cur = lm + bl - (currentAmount + pn);

                if (lm > 0 && cur >= 0)
                {
                    return true;
                }
                else if (lm > 0 && cur < 0)
                {
                    return false;
                }

                return true;
            }
            else
            {
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
                hdnEditPr.Value = t[0].ysnEditPriceInDO2.ToString().ToLower();
                bool editPr = Convert.ToBoolean(hdnEditPr.Value);

                bool viewPr = t[0].ysnViewPriceInDO2;
                bool chln = t[0].ysnChallanNoDO2;
                bool dis = t[0].ysnDisPointEnable;
                hdnCharBasedOnUom.Value = t[0].ysnCharBasedOnUOM.ToString().ToLower();
                hdnIncenBasedOnUom.Value = t[0].ysnIncentiveBasedOnUOM.ToString().ToLower();
                hdnCreditSales.Value = t[0].ysnCreditSales.ToString().ToLower();
                hdnXFactoryVhl.Value = t[0].ysnXFactoryPriceFixedForLogis.ToString().ToLower();
                hdnXFactoryChr.Value = t[0].ysnXFactoryPriceFixedForCharge.ToString().ToLower();
                hdnChrgMerge.Value = t[0].ysnChargeAccountMerge.ToString().ToLower();

                pnlDis.Visible = dis;
                txtCus.Visible = !dis;
                lblCust.Visible = dis;

                lblPrice.ReadOnly = !editPr;
                txtIncPr.ReadOnly = !editPr;
                lblExtPr.ReadOnly = !editPr;

                txtIncPr.ReadOnly = !editPr;
                lblExtPr.ReadOnly = !editPr;

                if (viewPr)
                {
                    lblPrice.CssClass = "";
                    lblTotal.CssClass = "";
                    lblExtPr.CssClass = "";
                    txtIncPr.CssClass = "";
                    lblExtPr.CssClass = "";

                    GridView1.Columns[4].Visible = true;
                    GridView1.Columns[5].Visible = true;
                    GridView1.Columns[6].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                }
                else
                {
                    lblPrice.CssClass = "hide";
                    lblTotal.CssClass = "hide";
                    lblExtPr.CssClass = "hide";
                    txtIncPr.CssClass = "hide";
                    lblExtPr.CssClass = "hide";

                    GridView1.Columns[4].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                }

                if (t[0].ysnDefaultLogis)
                {
                    rdoNeedVehicle.SelectedIndex = 0;
                }
                else
                {
                    rdoNeedVehicle.SelectedIndex = 1;
                }

                pnlClCb.Visible = t[0].ysnCrInfoInDO2;

            }
        }
        private void Reset()
        {
            //txtCus.Text = "";
            txtDis.Text = "";
            txtAddress.Text = "";
            lblBl.Text = "0.0";
            lblLM.Text = "0.0";
            lblPN.Text = "0.0";
            lblGroup.Text = "";
            lblCust.Text = "";
            txtContact.Text = "";
            txtPhone.Text = "";

            hdnCustomer.Value = "";
            hdnDis.Value = "";
        }
        private void ResetMain()
        {
            hdnProduct.Value = "";
            txtProduct.Text = "";
            ddlUOM.Items.Clear();
            txtQun.Text = "";
            lblPrice.Text = "0.0";
            //lblLogisGain.Text = "0.0";
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