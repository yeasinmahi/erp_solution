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
using System.Web.Script.Services;
using SAD_BLL.Customer;
using SAD_DAL.Customer;
using SAD_BLL.Item;
using SAD_BLL.Customer.Report;
using SAD_DAL.Customer.Report;
using SAD_BLL.Sales;
using SAD_DAL.Sales;
using SAD_BLL.Global;
using System.IO;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Order
{
    public partial class SalesOrder : BasePage
    {
        XmlManagerSO xm = new XmlManagerSO();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\SalesOrder";
        string stop = "stopping SAD\\Order\\SalesOrder";
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "53";

                if (Request.QueryString["id"] != null)
                {
                }
                else
                {
                    txtDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                    txtDelDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                pnlMarque.DataBind();
                EnabeDisable(true, false, true, false, false);

                BindGrid(GetXmlFilePath());
            }
        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                txtPrice.Attributes.Add("onkeyup", "SetPriceJS()");
                txtQun.Attributes.Add("onkeyup", "SetPriceJS()");
            }
        }


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

        #region Drop Down List, Radio Button, Text Box

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            BindGrid(GetXmlFilePath());
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void ddlUOM_DataBound(object sender, EventArgs e)
        {
            if (ddlUOM.Items.Count > 0) SetPrice();
        }
        protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUOM.Items.Count > 0) SetPrice();
        }

        protected void rdoSalesType_DataBound(object sender, EventArgs e)
        {
            int tp = 0;
            if (rdoSalesType.Items.Count > 0) rdoSalesType.SelectedIndex = tp;
        }

        protected void txtDis_TextChanged(object sender, EventArgs e)
        {
            DisPointChange();
            EnabeDisable(true, true, true, true, true);
            txtProduct.Focus();
        }
        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            CustomerChange();
            EnabeDisable(true, true, true, true, true);
            txtProduct.Focus();
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
        }

        #endregion

        #region Button

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region GridView

        private void BindGrid(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath)) xm.LoadXmlFile(xmlFilePath);

            XmlDataSource1.Dispose();
            XmlDataSource1.DataFile = xmlFilePath;
            GridView1.DataBind();

        }
        private void RemoveGrid()
        {
            if (File.Exists(GetXmlFilePath()))
            {
                File.Delete(GetXmlFilePath());
                BindGrid(GetXmlFilePath());
            }
        }
        protected string GetTotal(string pr, string qnt)
        {
            /*decimal tot = (decimal.Parse(pr) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);*/
            return "0";
        }
        protected string GetTotal(string pr, string logisGain, string qnt)
        {
            /*decimal tot = ((decimal.Parse(pr) + decimal.Parse(logisGain)) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);*/
            return "0";
        }
        protected string GetTotal(string pr, string pr2, string qnt, string inc)
        {
            /*decimal log = decimal.Parse(pr2);
            decimal tot = (decimal.Parse(pr) + log - decimal.Parse(inc));
            tot = tot * decimal.Parse(qnt);
            return CommonClass.GetFormettingNumber(tot);*/
            return "0";
        }
        protected string GetFullTotal(string pr, string logisGain, string qnt, string ext, string log, string inc)
        {
            /*decimal log_ = decimal.Parse(log);
            decimal tot = (decimal.Parse(pr) + decimal.Parse(logisGain) + decimal.Parse(ext) + log_ - decimal.Parse(inc));
            tot = tot * decimal.Parse(qnt);
            return CommonClass.GetFormettingNumber(tot);*/
            return "0";
        }
        protected string GetGrandTotal(int col)
        {
            decimal tot = 0;

            /*for (int i = 0; i < GridView1.Rows.Count; i++)
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
            }*/

            return CommonClass.GetFormettingNumber(tot);
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /*e.Cancel = true;
            lblError.Text = "";
            DataSet ds = new DataSet();
            ds.ReadXml(GetXmlFilePath());

            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.WriteXml(GetXmlFilePath());      */
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            /*if (GridView1.Rows.Count <= 0)
            {
            
            }
            else
            {
            
            }*/
        }

        #endregion

        #region Private

        private string GetXmlFilePath()
        {
            return Server.MapPath("") + "/Data/OR/" + Session["sesUserID"] + "_" + ddlUnit.SelectedValue + "_item.xml";
        }
        private void SalesConfigSet()
        {
            SalesConfig sc = new SalesConfig();
            SalesConfigTDS.TblSalesConfigDataTable t = sc.GetInfoForDO(ddlUnit.SelectedValue);

            if (t.Rows.Count > 0)
            {
                bool editPr = t[0].ysnEditPriceInDO2;
                bool viewPr = t[0].ysnViewPriceInDO2;
                bool chln = t[0].ysnChallanNoDO2;
                bool dis = t[0].ysnDisPointEnable;
                //hdnLogisBasedOnUom.Value = t[0].ysnLogisBasedOnUOM.ToString().ToLower();
                hdnCharBasedOnUom.Value = t[0].ysnCharBasedOnUOM.ToString().ToLower();
                hdnIncenBasedOnUom.Value = t[0].ysnIncentiveBasedOnUOM.ToString().ToLower();
                hdnCreditSales.Value = t[0].ysnCreditSales.ToString().ToLower();
                //hdnXFactoryVhl.Value = t[0].ysnXFactoryPriceFixedForLogis.ToString().ToLower();
                hdnXFactoryChr.Value = t[0].ysnXFactoryPriceFixedForCharge.ToString().ToLower();
                //hdnVhlMerge.Value = t[0].ysnVehicleAccountMerge.ToString().ToLower();
                hdnChrgMerge.Value = t[0].ysnChargeAccountMerge.ToString().ToLower();

                Session["sesSupplierParent"] = t[0].IsintSupplierCOAParentNull() ? "" : t[0].intSupplierCOAParent.ToString();

                if (t[0].ysnDisPointEnable)
                {
                    pnlDisPoint.Visible = true;
                    txtCus.Visible = false;
                    lblCust.Visible = true;
                }
                else
                {
                    pnlDisPoint.Visible = false;
                    txtCus.Visible = true;
                    lblCust.Visible = false;
                }

                //pnlDis.Visible = dis;
                txtPrice.ReadOnly = !editPr;
                //lblLogisGain.ReadOnly = !editPr;
                //lblVhkPr.ReadOnly = !editPr;
                txtCharge.ReadOnly = !editPr;

                if (viewPr)
                {
                    txtPrice.CssClass = "";
                    //lblLogisGain.CssClass = "";
                    //lblTotal.CssClass = "";
                    //lblGT.CssClass = "";
                    txtCharge.CssClass = "";
                    //lblVhkPr.CssClass = "";


                    /*GridView1.Columns[4].Visible = true;
                    GridView1.Columns[5].Visible = true;
                    GridView1.Columns[6].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    GridView1.Columns[10].Visible = true;
                    GridView1.Columns[11].Visible = true;
                    GridView1.Columns[12].Visible = true;*/
                }
                else
                {
                    txtPrice.CssClass = "hide";
                    //lblLogisGain.CssClass = "hide";
                    //lblTotal.CssClass = "hide";
                    //lblGT.CssClass = "hide";
                    txtCharge.CssClass = "hide";
                    //lblVhkPr.CssClass = "hide";


                    /*GridView1.Columns[4].Visible = false;
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[6].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView1.Columns[11].Visible = false;
                    GridView1.Columns[12].Visible = false;*/
                }


                /*pnlChallan.Visible = chln;

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
                }*/

                pnlCr.Visible = t[0].ysnCrInfoInDO2;
                pnlCrGrp.Visible = t[0].ysnCrInfoInDO2;

            }
        }
        private void SetPrice()
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\SalesOrder set Price", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (hdnProduct.Value != "")
            {
                ItemPrice it = new ItemPrice();
                decimal commission = 0;
                decimal charge = 0;
                decimal incentive = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;

                decimal promQnty = 0;
                int promItemId = 0;
                string promItem = "";
                int promItemUOM = 0;
                string promUom = "";
                decimal convRate = 0;

                decimal pr = it.GetPriceWithCommPromoInc(hdnProduct.Value, ddlCharge.SelectedValue, ddlIncentive.SelectedValue, hdnCustomer.Value, hdnPriceVariable.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , ref charge, ref incentive, ref commission, ref suppTax, ref vat, ref vatPrice, ref promQnty, ref promItemId
                    , ref promItem, ref promItemUOM, ref promUom, ref convRate);


                if (pr > 0)
                {
                    /*decimal chrPr = 0, inc = 0;

                    if (hdnCharBasedOnUom.Value.ToLower() == "true")
                    {
                        try { chrPr = decimal.Parse(txtCharge.Text); }
                        catch { }
                    }
                    if (hdnIncenBasedOnUom.Value.ToLower() == "true")
                    {
                        try { inc = decimal.Parse(txtIncPr.Text); }
                        catch { }
                    }*/


                    /*if (hdnXFactoryChr.Value == "true")
                    {
                        pr -= chrPr;
                    }*/
                    /*else
                    {
                        pr += chrPr;
                    }

                    pr -= inc;*/
                }

                txtPrice.Text = CommonClass.GetFormettingNumber(pr);
                txtCharge.Text = CommonClass.GetFormettingNumber(charge);
                txtCommission.Text = CommonClass.GetFormettingNumber(commission);
                txtIncPr.Text = CommonClass.GetFormettingNumber(incentive);
                txtCommission.Text = CommonClass.GetFormettingNumber(commission);
                if (promQnty > 0)
                {
                    lblPromo.Text = promQnty + " " + promItemUOM + " " + promItem;
                }
                else
                {
                    lblPromo.Text = "No Promotion";
                }
                hdnSuppTax.Value = CommonClass.GetFormettingNumber(suppTax);
                hdnVat.Value = CommonClass.GetFormettingNumber(vat);
                hdnVatPrice.Value = CommonClass.GetFormettingNumber(vatPrice);
                txtConvRate.Text = convRate.ToString();
            }

            EnabeDisable(false, false, false, false, true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void EnabeDisable(bool dis, bool other, bool ddl, bool dte, bool add)
        {
            txtDis.Enabled = dis;

            //txtAddress.Enabled = other;
            //txtContact.Enabled = other;
            //txtPhone.Enabled = other;

            txtDate.Enabled = other;
            txtDelDate.Enabled = other;

            ddlCurrency.Enabled = other;
            txtConvRate.Enabled = other;
            ddlAP.Enabled = other;
            ddlHour.Enabled = other;
            ddlCharge.Enabled = other;
            ddlIncentive.Enabled = other;

            ddlUOM.Enabled = add;
            txtQun.Enabled = add;
            txtProduct.Enabled = add;
            btnAdd.Enabled = add;
            txtCharge.Enabled = add;
            txtIncPr.Enabled = add;
            txtPrice.Enabled = add;
            txtCommission.Enabled = add;

            ddlCusType.Enabled = ddl;
            ddlShip.Enabled = ddl;
            ddlSo.Enabled = ddl;
            ddlUnit.Enabled = ddl;

            rdoSalesType.Enabled = other;
            rdoNeedVehicle.Enabled = other;

            imgCal_1.Disabled = !dte;
            imgCal_2.Disabled = !dte;
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
                    DistributionPointTDS.SprGetDisPointInfoForSalesOrderDataTable table = dp.GetDisPointInfoForSalesOrder(hdnDis.Value, Session["sesUserID"].ToString(), ddlUnit.SelectedValue, DateTime.Now);
                    if (table.Rows.Count > 0)
                    {
                        hdnPriceVariable.Value = ("" + table[0].intPriceCatagory);
                        hdnCustomer.Value = table[0].intCusID.ToString();
                        lblCust.Text = table[0].strCusName;
                        txtAddress.Text = table[0].strAddress;
                        txtContact.Text = table[0].strContactPerson;
                        txtPhone.Text = table[0].strContactNo;

                        lblLM.Text = CommonClass.GetFormettingNumber(table[0].monCreditLimit);
                        lblBl.Text = CommonClass.GetFormettingNumber(table[0].monOutstanding);
                        lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                        lblGroup.Text = table[0].strGroup;
                        lblLocation.Text = table[0].strLocation;

                    }
                }
            }
        }
        private void CustomerChange()
        {




            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\SalesOrder Customer Change ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DistributionPoint dp = new DistributionPoint();

            if (txtCus.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                hdnCustomer.Value = temp[temp.Length - 1];
                hdnCustomerText.Value = temp[0];

                if (hdnDis.Value != "")
                {
                    DistributionPointTDS.SprGetDisPointInfoForSalesOrderDataTable table = dp.GetDisPointInfoForSalesOrder(hdnDis.Value, Session["sesUserID"].ToString(), ddlUnit.SelectedValue, DateTime.Now);
                    if (table.Rows.Count > 0)
                    {
                        hdnPriceVariable.Value = ("" + table[0].intPriceCatagory);
                        hdnCustomer.Value = table[0].intCusID.ToString();
                        lblCust.Text = table[0].strCusName;
                        txtAddress.Text = table[0].strAddress;
                        txtContact.Text = table[0].strContactPerson;
                        txtPhone.Text = table[0].strContactNo;

                        lblLM.Text = CommonClass.GetFormettingNumber(table[0].monCreditLimit);
                        lblBl.Text = CommonClass.GetFormettingNumber(table[0].monOutstanding);
                        lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                        lblGroup.Text = table[0].strGroup;
                        lblLocation.Text = table[0].strLocation;

                    }
                }
            }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private bool CheckLimitBalance(decimal currentAmount)
        {
            decimal lm = decimal.Parse(hdnLm.Value);
            decimal bl = decimal.Parse(hdnBl.Value);
            decimal cur = 0;//lm + bl - currentAmount;

            if (hdnCreditSales.Value == "true")
            {
                cur = lm + bl - currentAmount;
                //hdnRest.Value = cur.ToString();
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
                //hdnRest.Value = bl.ToString();

                if (bl >= currentAmount)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion

    }
}
