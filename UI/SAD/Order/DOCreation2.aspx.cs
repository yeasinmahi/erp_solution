using LOGIS_BLL;
using LOGIS_DAL;
using SAD_BLL.Customer;
using SAD_BLL.Global;
using SAD_BLL.Item;
using SAD_BLL.Sales;
using SAD_DAL.Customer;
using SAD_DAL.Item;
using SAD_DAL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class DOCreation2 : System.Web.UI.Page
    {
        decimal promPrice = 0;
        SAD_BLL.Item.XmlManagerSO xm = new XmlManagerSO();
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
                // Session["sesUserID"] = "53";

                if (Request.QueryString["id"] != null)
                {
                    SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                    table = se.GetSalesOrder(Request.QueryString["id"]);

                    if (table.Rows.Count > 0)
                    {
                        hdnUnit.Value = table[0].intUnitId.ToString();
                        txtConvRate.Text = table[0].numConversionRate.ToString();
                        if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());

                        //SalesOrderTDS.QrySalesOrderDetailsDataTable tbl = se.GetSalesOrderDetails(table[0].intId.ToString());
                        SalesOrderTDS.QrySalesOrderDetailsTestDataTable tbl = se.GetSalesOrderDetailsTest(table[0].intId.ToString());
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            string[][] items = xm.CreateItemstest(tbl[i].intProductId.ToString()
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
                                //, tbl[i].IsmonCommissionNull() ? "" : tbl[i].monCommission.ToString()
                                , tbl[i].IsdecDiscountallowNull() ? "" : tbl[i].decDiscountallow.ToString()
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
                                , tbl[i].decDiscountallow.ToString()
                                , tbl[i].monDamage.ToString()
                                , tbl[i].monSpecial.ToString()
                                , tbl[i].monSRSubsidiary.ToString()
                                , tbl[i].monSupplierVheicle.ToString()
                                , tbl[i].monCustomerVheicle.ToString()
                                , tbl[i].monCompanyVheicle.ToString()
                                 , tbl[i].strHallogramNumber.ToString()
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

                        //if (table[0].ysnLogistic)
                        //{
                        //    rdoNeedVehicle.SelectedIndex = 0;
                        //}
                        //else
                        //{
                        //    rdoNeedVehicle.SelectedIndex = 1;
                        //}

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

        //protected string GetFullTotal(string pr, string qnt, string ext, string inc)
        //{
        //    decimal tot = (decimal.Parse(pr) + decimal.Parse(ext) - decimal.Parse(inc) );
        //    tot = tot * decimal.Parse(qnt);
        //    return CommonClass.GetFormettingNumber(tot);
        //}

        protected string GetFullTotal(string pr, string qnt, string ext, string inc, string discnt,string damage, string special,string srsubsidy,string supplyvheicle,string customervhcle,string companyvhc)
        {
            //int unitid = int.Parse(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString());
            int unitid = 53;
            if (unitid == 90) {
                decimal tot = (decimal.Parse(pr) + decimal.Parse(ext) - decimal.Parse(inc));
                tot = tot * decimal.Parse(qnt) - decimal.Parse(discnt);
                return CommonClass.GetFormettingNumber(tot);
            }

            else 
            {
                decimal tot = (decimal.Parse(pr) + decimal.Parse(ext) - decimal.Parse(inc));
                decimal gtotal = tot * decimal.Parse(qnt);
                decimal totaldiscount = ( decimal.Parse(discnt)+ decimal.Parse(damage) + decimal.Parse(special)+ decimal.Parse(srsubsidy)+ decimal.Parse(supplyvheicle) + decimal.Parse(customervhcle)- decimal.Parse(companyvhc));
                decimal calftotal = gtotal - totaldiscount;
                hdndiscount.Value = Convert.ToString(calftotal);
                return CommonClass.GetFormettingNumber(calftotal);
            }
            

            
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

            if (col == 7 || col == 10)
            {
                if (hdnCharBasedOnUom.Value != "true")
                {
                    tot += decimal.Parse(lblExtPr.Text);
                }
                if (hdnIncenBasedOnUom.Value != "true")
                {
                    tot -= decimal.Parse(txtIncPr.Text);
                }

                if (col == 10)
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            string pId, pName, //qnt, 
                approvedQnt, pr
                , accId
                , accName
                //, extId//, extName
                //, extPr
                , uom, uomTxt
                //, currency, narration, salesType
                //, logisicId
                //, promotion, commission, incentiveId
                //, incentive
                /*, suppTax, vat, VatPr, promItemId, promItem
                , promUom, promUomText, promPrice, promItemCOAid*/
                //, salesOrderPkId
                ;

            string newQnt = ((TextBox)(GridView1.Rows[index].Cells[2].FindControl("txtQnty"))).Text;

            GridView1.EditIndex = -1;
            e.Cancel = true;

            DataSet s = new DataSet();
            s.ReadXml(GetXmlFilePath());

            pId = s.Tables[0].Rows[index][0].ToString();
            pName = s.Tables[0].Rows[index][1].ToString();
            //qnt = s.Tables[0].Rows[index][2].ToString();            
            approvedQnt = s.Tables[0].Rows[index][2].ToString();
            pr = s.Tables[0].Rows[index][3].ToString();
            accId = s.Tables[0].Rows[index][4].ToString();
            accName = s.Tables[0].Rows[index][5].ToString();
            //extId = s.Tables[0].Rows[index][7].ToString();
            //extName = s.Tables[0].Rows[index][8].ToString();        
            //extPr = s.Tables[0].Rows[index][9].ToString();
            uom = s.Tables[0].Rows[index][9].ToString();
            uomTxt = s.Tables[0].Rows[index][21].ToString();
            //currency = s.Tables[0].Rows[index][12].ToString();      narration = s.Tables[0].Rows[index][13].ToString();
            //salesType = s.Tables[0].Rows[index][14].ToString();     
            //logisicId = s.Tables[0].Rows[index][15].ToString();
            //promotion = s.Tables[0].Rows[index][16].ToString();     commission = s.Tables[0].Rows[index][17].ToString();
            //incentiveId = s.Tables[0].Rows[index][18].ToString();   
            //incentive = s.Tables[0].Rows[index][19].ToString();
            //suppTax = s.Tables[0].Rows[index][20].ToString();       vat = s.Tables[0].Rows[index][21].ToString();
            //VatPr = s.Tables[0].Rows[index][22].ToString();        // promItemId = s.Tables[0].Rows[index][23].ToString();
            //promItem = s.Tables[0].Rows[index][24].ToString();      promUom = s.Tables[0].Rows[index][25].ToString();
            //promUomText = s.Tables[0].Rows[index][26].ToString();   promPrice = s.Tables[0].Rows[index][27].ToString();
            //promItemCOAid = s.Tables[0].Rows[index][28].ToString(); 
            //salesOrderPkId = s.Tables[0].Rows[index][29].ToString();


            if (decimal.Parse(approvedQnt) != decimal.Parse(newQnt))
            {

                string narr = newQnt + " " + uomTxt + " " + pName + " Sold";

                narr += " To " + hdnCustomerText.Value;

                /*string chrPr = "0.0", incPr = "0.0";

                if (hdnXFactoryChr.Value == "true" && rdoNeedVehicle.SelectedIndex == 0)
                {
                    if (hdnCharBasedOnUom.Value == "true") chrPr = extPr;
                }
                else if (hdnXFactoryChr.Value != "true")
                {
                    if (hdnCharBasedOnUom.Value == "true") chrPr = extPr;
                }

                if (hdnIncenBasedOnUom.Value == "true") incPr = incentive;
                */

                decimal promQnty = 0;
                int promItemId = 0;
                int promItemCOAId = 0;
                int promItemUOM = 0;
                string promItem = "";
                string promUom = "";

                ItemPromotion ip = new ItemPromotion();
                decimal promPrice = ip.GetPromotion(pId, hdnCustomer.Value, hdnPriceId.Value, uom
                    , ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , newQnt, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);

                //promPrice = ip.GetPromotiontest(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue
                //      , ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                //      , txtQun.Text, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId
                //      , ref discountamount
                //      );



                if (promItemId.ToString() == pId)
                {
                    promPrice = decimal.Parse(pr);
                    promItemCOAId = int.Parse(accId);
                    promUom = uomTxt;
                    promItemUOM = int.Parse(uom);
                }


                //update the values
                s.Tables[0].Rows[index][29] = newQnt;
                s.Tables[0].Rows[index][11] = narr;

                s.Tables[0].Rows[index][14] = promQnty.ToString();
                s.Tables[0].Rows[index][22] = promItemId.ToString();
                s.Tables[0].Rows[index][23] = promItem;
                s.Tables[0].Rows[index][24] = promItemUOM.ToString();
                s.Tables[0].Rows[index][25] = promUom;
                s.Tables[0].Rows[index][26] = promPrice.ToString();
                s.Tables[0].Rows[index][27] = promItemCOAId.ToString();

              

                s.WriteXml(GetXmlFilePath());
            }

            BindGrid(GetXmlFilePath());
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

            //File.Delete(GetXmlFilePath());
            //BindGrid(GetXmlFilePath());

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
            else if (GridView1.Rows.Count > 0 && hdnCustomer.Value == "")
            {
                EnabeDisable(false, false, false);
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

            //double decgrdvtotal = Convert.ToDouble(GetGrandTotal(10));
            double decgrdvtotal;
            decimal deccompareprice;
            decimal promQnty = 0;
            int promItemId = 0;
            int promItemCOAId = 0;
            int promItemUOM = 0;
            string promItem = "";
            string promUom = "";
            string coaId = "", coaName = "";
            string discntamnt = "";
            string mondamg = "";
            string monspecial = "";
            string monsubsidiary = "";
            string monsupplv = "";
            string moncustom = "";
            string moncompan = "";
            bool ysndiscntallow = false;
            ItemPromotion ip = new ItemPromotion();
            SAD_BLL.Item.Item it = new SAD_BLL.Item.Item();
            it.GetCOAByItemId(hdnProduct.Value, ddlUnit.SelectedValue, rdoSalesType.SelectedValue, ref coaId, ref coaName);
            it.GetDeductionalamountinfobyItemId(ddlUnit.SelectedValue, hdnProduct.Value, ref discntamnt, ref mondamg, ref monspecial, ref monsubsidiary, ref monsupplv, ref moncustom, ref moncompan);
            it.discountallowstatus(ddlUnit.SelectedValue, ddlSo.SelectedValue,ref ysndiscntallow);
            
            string monsuplv = "";
            string moncusv = "";
            string moncomp = "";
            string subsidyamnt; decimal tsubsidyamnt = 0; string damgeamnt; decimal tdamgeamnt = 0; string specialamnt; decimal tspecialamnt = 0;
            decimal tmonsuplv = 0; decimal tmoncusv = 0; decimal tmoncomp = 0;

            //double totalprdctprice = Math.Round((double.Parse(txtQun.Text) * double.Parse(hdnPrice.Value)));
            double totalprdctprice = double.Parse(txtQun.Text) * double.Parse(hdnPrice.Value);
            double discnttaka = 0.00;
            double calculteddiscount;

            if (ysndiscntallow == true) { discnttaka = Convert.ToDouble(discntamnt) * Convert.ToDouble(txtQun.Text); }
            else {  discnttaka = double.Parse("0.00"); }
           

         


            if (ddlUnit.SelectedValue == "90")
            {
                if (totalprdctprice > discnttaka)
                {
                    calculteddiscount = totalprdctprice * double.Parse("0.02");
                }

                else { calculteddiscount = double.Parse("0.00"); }
            }



            else { calculteddiscount = discnttaka; }

            if (mondamg == "" || mondamg.Length <= 0) { mondamg = "0"; }
            else
            {
                damgeamnt = mondamg.ToString();
                if (ddlSo.SelectedValue == "453" || ddlSo.SelectedValue == "455") { tdamgeamnt = decimal.Parse(txtQun.Text) * decimal.Parse(damgeamnt); }
                else { tdamgeamnt = 0; }

            }

            if (monspecial == "" || monspecial.Length <= 0) { monspecial = "0"; }
            else
            {
                specialamnt = monspecial.ToString();
                tspecialamnt = decimal.Parse(txtQun.Text) * decimal.Parse(specialamnt);
            }


            if (monsubsidiary == "" || monsubsidiary.Length <= 0) { monsubsidiary = "0"; }
            else
            {
                subsidyamnt = monsubsidiary.ToString();
                if (ddlSo.SelectedValue == "453")
                {
                    tsubsidyamnt = decimal.Parse(txtQun.Text) * decimal.Parse(subsidyamnt);
                    //tsubsidyamnt = 0;
                }

                else { tsubsidyamnt = 0; }

            }
            int salesoffid = int.Parse(ddlSo.SelectedValue.ToString());

            if (salesoffid == 453 || salesoffid == 455)
            {

                if (rdoNeedVehicle.SelectedItem.Text == "Yes")
                {

                    moncomp = txtcompanyvhcle.Text;
                    if (moncomp == "" || moncomp.Length <= 0) { moncomp = "0"; }
                    else
                    {
                        tmoncomp = Convert.ToDecimal(txtcompanyvhcle.Text);
                        monsuplv = "0";
                        moncusv = "0";
                    }
                }
                else if (rdoNeedVehicle.SelectedItem.Text == "No" && chkSupplier.Checked == false)
                {
                    moncusv = moncustom.ToString();
                    if (moncusv == "" || moncusv.Length <= 0) { moncusv = "0"; }
                    else
                    {
                        moncomp = "0";
                        monsuplv = "0";
                        tmoncusv = decimal.Parse(txtQun.Text) * decimal.Parse(moncusv);
                        txtcompanyvhcle.Text = "0";
                    }
                }
                else if (rdoNeedVehicle.SelectedItem.Text == "No" && chkSupplier.Checked == true)
                {

                    monsuplv = monsupplv.ToString();
                    if (monsuplv == "" || monsuplv.Length <= 0) { monsuplv = "0"; }
                    else
                    {
                        tmonsuplv = decimal.Parse(txtQun.Text) * decimal.Parse(monsuplv);
                        moncusv = "0";
                        moncomp = "0";
                        txtcompanyvhcle.Text = "0";
                    }

                }

                else
                {
                    moncomp = "0";
                    monsuplv = monsuplv.ToString();
                    tmonsuplv = 0;
                    moncusv = "0";
                    txtcompanyvhcle.Text = "0";

                }
            }
            else
            {
                if (rdoNeedVehicle.SelectedItem.Text == "Yes")
                {

                    moncomp = txtcompanyvhcle.Text;
                    if (moncomp == "" || moncomp.Length <= 0) { moncomp = "0"; }
                    else
                    {
                        tmoncomp = Convert.ToDecimal(txtcompanyvhcle.Text);
                        monsuplv = "0";
                        moncusv = "0";
                    }
                }
                else if (rdoNeedVehicle.SelectedItem.Text == "No" && chkSupplier.Checked == false)
                {
                    moncusv = moncustom.ToString();
                    if (moncusv == "" || moncusv.Length <= 0) { moncusv = "0"; }
                    else
                    {
                        moncomp = "0";
                        monsuplv = "0";
                        tmoncusv = 0;
                        txtcompanyvhcle.Text = "0";
                    }
                }
                else if (rdoNeedVehicle.SelectedItem.Text == "No" && chkSupplier.Checked == true)
                {

                    monsuplv = monsupplv.ToString();
                    if (monsuplv == "" || monsuplv.Length <= 0) { monsuplv = "0"; }
                    else
                    {
                        //tmonsuplv = decimal.Parse(txtQun.Text) * decimal.Parse(monsuplv);
                        tmonsuplv = 0;
                        moncusv = "0";
                        moncomp = "0";
                        txtcompanyvhcle.Text = "0";
                    }

                }

                else
                {
                    moncomp = "0";
                    monsuplv = monsuplv.ToString();
                    tmonsuplv = 0;
                    moncusv = "0";
                    txtcompanyvhcle.Text = "0";

                }


            }

            
            decimal undelvvalue = Convert.ToDecimal(hdnUndeliverqntpricevalue.Value);
            decimal actualprice;
            decimal ttdamageamount = Convert.ToDecimal(tdamgeamnt);
            decimal ttspecialamnt = Convert.ToDecimal(tspecialamnt);
            decimal ttsubsidyamnt = Convert.ToDecimal(tsubsidyamnt);
            decimal ttmoncomp = Convert.ToDecimal(tmoncomp);
            decimal ttmonsuplv = Convert.ToDecimal(tmonsuplv);
            decimal ttmoncusv = Convert.ToDecimal(tmoncusv);
            decimal ttcalculteddiscount = Convert.ToDecimal(calculteddiscount);
            actualprice =(decimal.Parse(txtQun.Text) * decimal.Parse(hdnPrice.Value));
            actualprice = actualprice - (ttdamageamount + ttspecialamnt + ttsubsidyamnt + ttmoncusv + ttmonsuplv+ ttcalculteddiscount - ttmoncomp);
            deccompareprice = actualprice;
            string actotal = actualprice.ToString();
            hdndiscount.Value = Convert.ToString(Convert.ToDouble(hdndiscount.Value));
            decimal hdnvalue = Convert.ToDecimal(hdndiscount.Value);
            decimal ghdnvalue = hdnvalue + Convert.ToDecimal(actotal);

            if (GridView1.Rows.Count == 0)
            {

                actualprice = (Convert.ToDecimal(txtQun.Text) * Convert.ToDecimal(hdnPrice.Value));
                actualprice = actualprice - ttcalculteddiscount;
                deccompareprice = actualprice;
            }


            else
            {
                deccompareprice = ghdnvalue;
            }
            //if (GridView1.Rows.Count == 0) { deccompareprice = Math.Round((double.Parse(txtQun.Text) * double.Parse(hdnPrice.Value))); }
            //else { deccompareprice = Convert.ToDouble(GetGrandTotal(10)); }
            if (Convert.ToDecimal(lblBl.Text)- undelvvalue <= deccompareprice) {
                btnAdd.Enabled = false;
                lblError.Text = "Balance exceed";

                
            }
            else
            { btnAdd.Enabled = true; 


            if (ddlUOM.Items.Count > 0 && ddlCurrency.Items.Count > 0 && hdnCustomer.Value != "" && hdnProduct.Value != "" && txtQun.Text.Trim() != "")
            {
                lblError.Text = "";
               
             
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
                    promPrice = ip.GetPromotion(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue
                    , ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , txtQun.Text, ref promQnty, ref promItemId, ref promItem, ref promItemUOM, ref promUom, ref promItemCOAId);

                        decimal promQnty1= promQnty;
                        string haln = textHallmark.Text.ToString();
                        if(haln.Length<=0 || haln == "")
                        {
                            haln = "0";
                        }
                        else
                        {
                            haln = textHallmark.Text.ToString();
                        }
                        if (promItemId.ToString() == hdnProduct.Value)
                    {
                        //sdv.Checked == true &&
                        /*28,23,29,24*/
                        //if (( "23"!= ddlSo.SelectedValue.ToString() || "24"!= ddlSo.SelectedValue.ToString()
                        //|| "28"!= ddlSo.SelectedValue.ToString() || "29"!= ddlSo.SelectedValue.ToString()
                        //|| "453"!= ddlSo.SelectedValue.ToString() || "455"!= ddlSo.SelectedValue.ToString()))
                        if(promQnty1<=0)

                            {
                            decimal tempprc =(decimal.Parse(txtQun.Text) * decimal.Parse(hdnPrice.Value)) /
                                              (decimal.Parse(txtQun.Text) + promQnty); //+ 1
                            hdnPrice.Value = tempprc.ToString("0.00");
                            promQnty = 0;
                        }
                        promPrice = decimal.Parse(hdnPrice.Value);
                        promItemCOAId = int.Parse(coaId);
                    }






                        string[][] items = xm.CreateNewItemstest(hdnProduct.Value, hdnProductText.Value
                           , txtQun.Text, txtQun.Text, hdnPrice.Value, coaId, coaName, ddlExtra.SelectedValue
                           , ddlExtra.SelectedItem.Text, chrPr, ddlUOM.SelectedValue, ddlUOM.SelectedItem.Text
                           , ddlCurrency.SelectedValue, narr, rdoSalesType.SelectedValue.ToString()
                           , hdnDDLChangedSelectedIndexV.Value, promQnty.ToString(), lblComm.Text
                           , ddlIncentive.SelectedValue, incPr, hdnSuppTax.Value, hdnVat.Value, hdnVatPrice.Value
                           , promItemId.ToString(), promItem, promItemUOM.ToString(), promUom
                           , promPrice.ToString(), promItemCOAId.ToString()
                           , calculteddiscount.ToString()
                           , tdamgeamnt.ToString()
                           , tspecialamnt.ToString()
                           , tsubsidyamnt.ToString()
                           , tmonsuplv.ToString()
                           , tmoncusv.ToString()
                           , tmoncomp.ToString()
                           , textHallmark.Text
                       
                       );



                    XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                    XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                    selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                    xmlDoc.Save(GetXmlFilePath());

                    txtQun.Text = "";

                    BindGrid(GetXmlFilePath());

                    hdnProduct.Value = "";
                    txtProduct.Text = "";
                    txtProduct.Focus();

                    //decimal discnt = Convert.ToDecimal(calculteddiscount);
                    //lblComm.Text = CommonClass.GetFormettingNumber(discnt);


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
                    narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " "
                        + GridView1.Rows[i].Cells[11].Text + " "
                        + ((Label)(GridView1.Rows[i].Cells[1].Controls[1])).Text + "]";
                }
            }
            //AddUpdateDelivaryOrderTEST
            //AddUpdateDelivaryOrder
          
            string codeadd = "DO No:";
            
            if (txtslot.Text=="") { txtslot.Text = "1"; }
            
            int sloatno=int.Parse(txtslot.Text);
           
            for (int i = 0; i < sloatno; i++)
            {
                
                SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                se.AddUpdateDelivaryOrderTEST(xml, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue
                     , CommonClass.GetDateAtSQLDateFormat(txtDate.Text), CommonClass.GetDateAtSQLDateFormat(txtDelDate.Text)
                     , hdnCustomer.Value, ddlCusType.SelectedValue, narrTop, txtAddress.Text.Trim(), hdnDis.Value, hdnPriceId.Value, hdnPriceIdV.Value
                     , bool.Parse(rdoNeedVehicle.SelectedValue)
                     , ddlExtra.SelectedValue, charge, ddlIncentive.SelectedValue, incentive
                     , ddlCurrency.SelectedValue, decimal.Parse(txtConvRate.Text), rdoSalesType.SelectedValue, ext, "", ""
                     , txtContact.Text.Trim(), txtPhone.Text.Trim(), ddlSo.SelectedValue
                     , ddlShip.SelectedValue, false, ref code, ref id);
                id = null;

                codeadd = codeadd + "," + code;
            }
            

            lblError.Text = codeadd;

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

            return Server.MapPath("") + "/Data/DO/" + Session[SessionParams.USER_ID] + "_" + unit + "_item.xml";
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
                SAD_BLL.Item.Item itemdisc = new SAD_BLL.Item.Item();
                decimal commission = 0;
                decimal suppTax = 0;
                decimal vat = 0;
                decimal vatPrice = 0;
                decimal convRate = 0;
                string dcamnt = "0";
                decimal pr = it.GetPrice(hdnProduct.Value, hdnCustomer.Value, hdnPriceId.Value, ddlUOM.SelectedValue, ddlCurrency.SelectedValue, rdoSalesType.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text).Date
                    , ref commission, ref suppTax, ref vat, ref vatPrice, ref convRate);

                decimal totalprdctprice = 4568;
                itemdisc.GetDiscountamountbyItemId(hdnProduct.Value, "53", ref dcamnt);


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



                //lblComm.Text = CommonClass.GetFormettingNumber(commission);
                hdnSuppTax.Value = CommonClass.GetFormettingNumber(suppTax);
                hdnVat.Value = CommonClass.GetFormettingNumber(vat);
                hdnVatPrice.Value = CommonClass.GetFormettingNumber(vatPrice);
                txtConvRate.Text = convRate.ToString();


                decimal discnt = Convert.ToDecimal(dcamnt);
                lblComm.Text = CommonClass.GetFormettingNumber(discnt);


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
            //hdnLm.Value = "";
            hdnBl.Value = "";
            hdnPN.Value = "";

            DistributionPoint dp = new DistributionPoint();

            if (txtDis.Text.Trim() != "")
            {
                char[] ch = { '[', ']' };
                string h = txtDis.Text;
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
                        lblBl.Text = CommonClass.GetFormettingNumber(-1 * table[0].monOutstanding);
                        lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                        //hdnLm.Value = lblLM.Text;
                        hdnBl.Value = table[0].monOutstanding.ToString();
                        hdnPN.Value = table[0].monPending.ToString();
                        hdnCredit.Value = table[0].ysnCreditEnable.ToString();
                        //hdnCrFixed.Value = table[0].ysnFixedCredit.ToString();
                        //hdnCrPeriod.Value = table[0].ysnPeriodicleCredit.ToString();

                        lblGroup.Text = table[0].strGroup;

                        if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                        {
                            if (hdnCustomer.Value != "") BuildTree();
                        }

                    }

                    DistributionPointTDS.SprUndeliverQntpricevalueDataTable tabUndlvpv = dp.GetUndeliverQntPriceValue(hdnCustomer.Value);
                    if (tabUndlvpv.Rows.Count > 0)
                    {
                        hdnUndeliverqntpricevalue.Value = tabUndlvpv[0].monrestamount.ToString();
                        lblundelvvalue.Text = hdnUndeliverqntpricevalue.Value;
                    }







                        //---------------- Change By Konock ----------------
                        //btnAdd.Enabled = CheckLimitBalance(0);
                        if (decimal.Parse(lblBl.Text) <= 0) { btnAdd.Enabled = false; }
                    else { btnAdd.Enabled = true; }
                    //---------------------------------------------------

                    if (GridView1.Rows.Count > 0) EnabeDisable(true, false, true);
                    else EnabeDisable(false, true, true);
                }
            }
        }
        private void CustomerChange()
        {
            //hdnLm.Value = "";
            hdnBl.Value = "";
            hdnPN.Value = "";

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
                CustomerTDS.SprGetCustomerInfoForSalesOrderDataTable table = ci.GetCustomerInfoForSalesOrder(hdnCustomer.Value, Session[SessionParams.USER_ID].ToString(), ddlUnit.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text));

                if (table.Rows.Count > 0)
                {
                    hdnDDLChangedSelectedIndex.Value = table[0].IsintPriceCatagoryNull() ? "" : table[0].intPriceCatagory.ToString();
                    hdnDDLChangedSelectedIndexV.Value = table[0].IsintLogisticCatagoryNull() ? "" : table[0].intLogisticCatagory.ToString();

                    txtAddress.Text = table[0].strAddress;
                    txtContact.Text = table[0].strContactPerson;
                    txtPhone.Text = table[0].strContactNo;

                    lblLM.Text = CommonClass.GetFormettingNumber(table[0].monCreditLimit);
                    lblBl.Text = CommonClass.GetFormettingNumber(-1 * table[0].monOutstanding);
                    lblPN.Text = CommonClass.GetFormettingNumber(table[0].monPending);

                    //hdnLm.Value = lblLM.Text;
                    hdnBl.Value = table[0].monOutstanding.ToString();
                    hdnPN.Value = table[0].monPending.ToString();
                    hdnCredit.Value = table[0].ysnCreditEnable.ToString();
                    //hdnCrFixed.Value = table[0].ysnFixedCredit.ToString();
                    //hdnCrPeriod.Value = table[0].ysnPeriodicleCredit.ToString();

                    lblGroup.Text = table[0].strGroup;

                    if (hdnDDLChangedSelectedIndex.Value != "" || hdnDDLChangedSelectedIndexV.Value != "")
                    {
                        if (hdnCustomer.Value != "") BuildTree();
                    }

                    //---------------- Change By Konock ----------------
                    //btnAdd.Enabled = CheckLimitBalance(0);
                    if (decimal.Parse(lblBl.Text) <= 0) { btnAdd.Enabled = false; }
                    else { btnAdd.Enabled = true; }
                    //---------------------------------------------------

                    if (GridView1.Rows.Count > 0) EnabeDisable(true, false, true);
                    else EnabeDisable(false, true, true);
                }
            }
        }
        private bool CheckLimitBalance(decimal currentAmount)
        {
            bool ret;
            decimal ot = decimal.Parse(hdnBl.Value);//outstanding
            decimal pn = decimal.Parse(hdnPN.Value);//pending

            decimal cur = 0;

            if (hdnCreditSales.Value == "true" && hdnCredit.Value.ToLower() == "true")
            {
                cur = ot + currentAmount + pn;

                if (cur > 0) ret = false;
                else ret = true;
            }
            else if (hdnCredit.Value.ToLower() == "true")
            {
                if (ot >= currentAmount)
                {
                    ret = true;
                }
                else ret = false;
            }
            else ret = true;

            return ret;
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
                //if (rdoNeedVehicle.SelectedItem.Text== "Yes")
                //{
                //    rdoNeedVehicle.SelectedIndex = 0;
                //}
                //else if (rdoNeedVehicle.SelectedItem.Text == "No")
                //{
                //    rdoNeedVehicle.SelectedIndex = 1;
                //}

                //else if (rdoNeedVehicle.SelectedItem.Text == "Supplier")
                //{
                //    rdoNeedVehicle.SelectedIndex = 2;
                //}

                //else 
                //{
                //    rdoNeedVehicle.SelectedIndex = 2;
                //}


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
            lblundelvvalue.Text = "0.0";
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
            txtConvRate.Text = "0.0";
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