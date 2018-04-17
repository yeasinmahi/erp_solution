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
using SAD_DAL.Global;
using SAD_BLL.Transfer;
using UI.ClassFiles;

namespace UI.SAD.Transfer
{
    public partial class FGTransfer : BasePage
    {
        XmlManagerSO xm = new XmlManagerSO();
        SalesOrderTDS.QrySalesOrderCustomerDataTable table;

        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";

                if (Request.QueryString["id"] != null)
                {
                    SalesOrder se = new SalesOrder();
                    table = se.GetSalesOrder(Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        hdnUnit.Value = table[0].intUnitId.ToString();
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
                        txtAddress.Text = table[0].strAddress;

                        hdnDDLChangedSelectedIndexV.Value = table[0].IsintVehicleVarIdNull() ? "" : table[0].intVehicleVarId.ToString();

                        btnSubmit.Text = "Update Sales";
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlMarque.DataBind();
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
                    Type tp = GridView1.Rows[i].Cells[col].Controls[1].GetType();
                    if (tp.Name == "Label")
                    {
                        tot += decimal.Parse(((Label)GridView1.Rows[i].Cells[col].Controls[1]).Text);
                    }
                    else
                    {
                        tot += decimal.Parse(((TextBox)GridView1.Rows[i].Cells[col].Controls[1]).Text);
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

        #endregion

        #region Button

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnProduct.Value != "" && txtQun.Text.Trim() != "")
            {
                string coaId = "", coaName = "";
                SAD_BLL.Item.Item it = new SAD_BLL.Item.Item();

                it.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, rdoSalesType.SelectedValue, ref coaId, ref coaName);

                if (coaId != "" && coaId != "0" && coaName != "")
                {
                    string narr = txtQun.Text.Trim() + " " + ddlUOM.SelectedItem.Text + " " + hdnProductText.Value + " Transfer";

                    string[][] items = xm.CreateNewItems(hdnProduct.Value, hdnProductText.Value
                        , txtQun.Text, txtQun.Text, "0", coaId, coaName, "0"
                        , "", "0", ddlUOM.SelectedValue, ddlUOM.SelectedItem.Text
                        , ddlCurrency.SelectedValue, narr, rdoSalesType.SelectedValue
                        , hdnDDLChangedSelectedIndexV.Value, "0", ""
                        , "0", "0", "0", "0", "0"
                        , "0", "", "0", ""
                        , "0", "0");


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


            string narrTop = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[3].Controls[1])).Text + " "
                        + ((Label)GridView1.Rows[i].Cells[2].Controls[1]).Text + " "
                        + ((Label)(GridView1.Rows[i].Cells[1].Controls[1])).Text + "]";
                }
            }


            SAD_BLL.Transfer.Transfer tr = new SAD_BLL.Transfer.Transfer();

            tr.AddUpdateTransfer(xml, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                 , CommonClass.GetDateAtSQLDateFormat(txtDate.Text), CommonClass.GetDateAtSQLDateFormat(txtDelDate.Text)
                 , narrTop, txtAddress.Text.Trim(), hdnDDLChangedSelectedIndexV.Value, true
                 , ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, txtOther.Text
                 , txtContact.Text.Trim(), txtPhone.Text.Trim()
                 , ddlShip.SelectedValue, ddlShipOther.SelectedValue
                 , ref code, ref id);

            RemoveGrid();

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                Response.Redirect("../../Accounts/Voucher/Exit.aspx");
            }

        }

        #endregion

        #region EventHandler RadioButton

        protected void rdoSalesType_DataBound(object sender, EventArgs e)
        {
            if (rdoSalesType.Items.Count > 0) rdoSalesType.SelectedIndex = 0;
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

            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            Reset();
            BindGrid(GetXmlFilePath());
        }

        protected void ddlShipOther_DataBound(object sender, EventArgs e)
        {

            if (table != null)
            {
                for (int i = 0; i < ddlShipOther.Items.Count; i++)
                {
                    if (ddlShipOther.Items[i].Value == table[0].intSalesOffId.ToString())
                    {
                        ddlShipOther.SelectedIndex = i;
                        ddlShipOther.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                SetShipPoint();
            }

            if (ddlShipOther.Items.Count <= 0 && ddlUnit.Items.Count > 0)
            {
                Response.Redirect("~/NoView.aspx");
            }
        }
        protected void ddlShipOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetShipPoint();
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


        #endregion

        #region EventHandler TextBox

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

        #region Private

        private void EnabeDisable(bool ysn, bool cus, bool product)
        {
            btnCancel.Visible = ysn;
            btnSubmit.Visible = ysn;

            ddlCurrency.Enabled = ysn;
            ddlUnit.Enabled = ysn;
            imgCal_1.Disabled = ysn;

            txtProduct.Enabled = product;
            txtQun.Enabled = product;

            ddlCurrency.Enabled = cus;
            ddlUnit.Enabled = cus;
            ddlShip.Enabled = cus;
            ddlShipOther.Enabled = cus;
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
        private void SetShipPoint()
        {
            ShipPoint sp = new ShipPoint();
            ShipPointTDS.TblShippingPointDataTable tbl = sp.GetShipPointInfo(ddlShipOther.SelectedValue);
            if (tbl.Rows.Count > 0)
            {
                txtAddress.Text = "" + tbl[0].strAddress;
                txtContact.Text = "" + tbl[0].strContactPerson;
                txtPhone.Text = "" + tbl[0].strContactNo;
                hdnDDLChangedSelectedIndexV.Value = tbl[0].IsintLogisticCatagoryNull() ? "" : tbl[0].intLogisticCatagory.ToString();
            }
        }
        private void Reset()
        {
            txtContact.Text = "";
            txtPhone.Text = "";
        }
        private void ResetMain()
        {
            hdnProduct.Value = "";
            txtProduct.Text = "";
            ddlUOM.Items.Clear();
            txtQun.Text = "";
        }

        #endregion

    }
}