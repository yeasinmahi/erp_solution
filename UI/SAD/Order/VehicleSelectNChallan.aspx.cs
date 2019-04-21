using BLL.Accounts.ChartOfAccount;
using DAL.Accounts.ChartOfAccount;
using Flogging.Core;
using GLOBAL_BLL;
using LOGIS_BLL;
using LOGIS_BLL.Trip;
using LOGIS_DAL.Trip;
using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales;
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
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class VehicleSelectNChallan :BasePage
    {
        XmlManagerCH xm = new XmlManagerCH();
        decimal prdouctvalue, outstandingv;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\VehicleSelectNChallan";
        string stop = "stopping SAD\\Order\\VehicleSelectNChallan";
        VehicleSelect bllsup = new VehicleSelect();
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "87";

                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\VehicleSelect  Vehcile Report Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    if (Request.QueryString["id"] != null)
                    {
                        Session[SessionParams.CURRENT_UNIT] = Request.QueryString["unit"];
                        Session[SessionParams.CURRENT_SHIP] = Request.QueryString["ship"];

                        SalesOrderTDS.QrySalesOrderCustomerDataTable table;

                        SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                        table = se.GetSalesOrder(Request.QueryString["id"]);
                      
                        if (table.Rows.Count > 0)
                        {
                            XmlDocument xmlDoc;
                            XmlNode selectNode;

                            hdnUnit.Value = table[0].intUnitId.ToString();
                            hdnCustomerText.Value = table[0].strName;
                            hdnCustomer.Value = table[0].intCustomerId.ToString();
                            hdnLogVar.Value = table[0].IsintVehicleVarIdNull() ? "" : table[0].intVehicleVarId.ToString();
                            hdnSOid.Value = table[0].intId.ToString();
                            hdnDate.Value = table[0].dteDate.ToString();
                            hdnCurrency.Value = table[0].intCurrencyId.ToString();
                            hdnShipPoint.Value = table[0].intShipPointId.ToString();
                            hdnCharge.Value = table[0].intChargeId.ToString();
                            hdnIncentive.Value = table[0].intIncentiveId.ToString();
                            hdnDoCode.Value = table[0].strCode;
                            hdnPriceVar.Value = table[0].IsintPriceVarIdNull() ? "" : table[0].intPriceVarId.ToString();
                            hdnSalesType.Value = table[0].intSalesTypeId.ToString();

                            //if (table[0].ysnLogistic) rdoVhlCompany.SelectedIndex = 0;
                            //else rdoVhlCompany.SelectedIndex = 2;

                            if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());

                            SalesOrderTDS.QrySalesOrderDetailsDataTable tbl = se.GetSalesOrderDetails(table[0].intId.ToString());

                            decimal promQnty = 0;
                            int promItemId = 0;
                            int promItemCOAId = 0;
                            int promItemUOM = 0;
                            string promItem = "";
                            string promUom = "";
                            decimal promPrice = 0;

                            for (int i = 0; i < tbl.Rows.Count; i++)
                            {
                                GetPromoNum(tbl[i].numApprQuantity.ToString()
                                    , tbl[i].numRestQuantity.ToString()
                                    , tbl[i].IsnumPromotionNull() ? "" : tbl[i].numPromotion.ToString()
                                    , tbl[i].intProductId.ToString()
                                    , tbl[i].intUom.ToString()
                                    , tbl[i].monPrice.ToString()
                                    , tbl[i].intCOAAccId.ToString()
                                    , hdnPriceVar.Value
                                    , hdnCurrency.Value
                                    , hdnSalesType.Value
                                    , ref promQnty
                                    , ref promItemId
                                    , ref promItemCOAId
                                    , ref promItemUOM
                                    , ref promItem
                                    , ref promUom
                                    , ref promPrice
                                    );

                                string[][] items = xm.CreateItems(tbl[i].intProductId.ToString()
                                    , tbl[i].strProductName
                                    , tbl[i].numRestQuantity.ToString()
                                    , tbl[i].numApprQuantity.ToString()
                                    , tbl[i].intUom.ToString()
                                    , tbl[i].strUOM
                                    , tbl[i].IsstrNarrationNull() ? "" : tbl[i].strNarration
                                    , promQnty.ToString()
                                    , tbl[i].IsnumPromotionNull() ? "" : tbl[i].numPromotion.ToString()
                                    , promItemId.ToString()
                                    , promItem
                                    , promItemUOM.ToString()
                                    , promUom
                                    , promPrice.ToString()
                                    , promItemCOAId.ToString()
                                    , tbl[i].intId.ToString()
                                    , tbl[i].monPrice.ToString()
                                    , tbl[i].intCOAAccId.ToString()
                                    );

                                xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                                selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                                selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                                xmlDoc.Save(GetXmlFilePath());
                            }

                            //GetVehicleList();

                        }
                    }

                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);

                }

                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["sesCurType"] = rdoVhlCompany.SelectedValue;

                BindGrid(GetXmlFilePath());

                //if (hdnDoCode.Value != "")
                //{
                //    TripCallTDS.QryTripByDoDataTable tbl = new TripCall().GetVehicleByDoCode(hdnDoCode.Value, hdnUnit.Value, hdnShipPoint.Value);
                //    if (tbl.Rows.Count > 0)
                //    {
                //        txtVehicle.Text = tbl[0].strRegNo + " [" + tbl[0].intVehicleId.ToString() + "]";
                //        if (tbl[0].ysnOwn) rdoVhlCompany.SelectedIndex = 0;
                //        else if (!tbl[0].Isint3rdPartyCOAidNull()) rdoVhlCompany.SelectedIndex = 1;
                //        else if (!tbl[0].IsintForThisCustomerNull()) rdoVhlCompany.SelectedIndex = 2;

                //        //VehicleChange();
                //    }
                //}


                //ChartOfAcc coa = new ChartOfAcc();
                //ChartOfAccTDS.TblAccountsChartOfAccDataTable ttblCOA = coa.GetDataByAccountIDForEdit(table[0].intLogSuppCOAId);

                //txtSupplier.Text = //ddlSupplierList.SelectedValue.ToString();
                //ttblCOA[0].strAccName + " [" + ttblCOA[0].strCode + "]";



            }
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

       


        #region GridView

        protected string GetTotal(string pr, string qnt)
        {
            decimal tot = (decimal.Parse(pr) * decimal.Parse(qnt));
            return CommonClass.GetFormettingNumber(tot);
            Session["tot"] = tot.ToString();
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
            string txt = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    Type tp = GridView1.Rows[i].Cells[col].Controls[1].GetType();
                    if (tp.Name == "Label")
                    {
                        txt = ((Label)GridView1.Rows[i].Cells[col].Controls[1]).Text;

                    }
                    else
                    {
                        txt = ((TextBox)GridView1.Rows[i].Cells[col].Controls[1]).Text;
                    }

                    if (txt != "") tot += decimal.Parse(txt);
                }
            }
            return CommonClass.GetFormettingNumber(tot);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            hdnEdit.Value = "E";
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            hdnEdit.Value = "";
            BindGrid(GetXmlFilePath());
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hdnEdit.Value = "";
            int index = e.RowIndex;
            string pName, apprQnt,
                restQnt
                , uomTxt
                , promotion, promotionMain;

            string newQnt = ((TextBox)(GridView1.Rows[index].Cells[2].FindControl("txtQnty"))).Text;
            Session["newQnt"] = newQnt;
            GridView1.EditIndex = -1;
            e.Cancel = true;

            DataSet s = new DataSet();
            s.ReadXml(GetXmlFilePath());

            pName = s.Tables[0].Rows[index][1].ToString();
            restQnt = s.Tables[0].Rows[index][2].ToString();
            apprQnt = s.Tables[0].Rows[index][3].ToString();
            uomTxt = s.Tables[0].Rows[index][8].ToString();
            promotion = s.Tables[0].Rows[index][6].ToString();
            promotionMain = s.Tables[0].Rows[index][7].ToString();

            if (decimal.Parse(restQnt) >= decimal.Parse(newQnt))
            {

                //string narr = newQnt + " " + uomTxt + " " + pName + " Sold To " + hdnCustomerText.Value;
                string narr = ((Label)(GridView1.Rows[index].Cells[4].FindControl("lblSpecifications"))).Text;
                decimal promQnty = 0;
                int promItemId = 0;
                int promItemCOAId = 0;
                int promItemUOM = 0;
                string promItem = "";
                string promUom = "";
                decimal promPrice = 0;

                GetPromoNum(apprQnt
                                , newQnt
                                , promotionMain
                                , s.Tables[0].Rows[index][0].ToString()
                                , s.Tables[0].Rows[index][4].ToString()
                                , s.Tables[0].Rows[index][16].ToString()
                                , s.Tables[0].Rows[index][17].ToString()
                                , hdnPriceVar.Value
                                , hdnCurrency.Value
                                , hdnSalesType.Value
                                , ref promQnty
                                , ref promItemId
                                , ref promItemCOAId
                                , ref promItemUOM
                                , ref promItem
                                , ref promUom
                                , ref promPrice
                                );

                //update the values
                s.Tables[0].Rows[index][2] = newQnt;
                s.Tables[0].Rows[index][5] = narr;
                s.Tables[0].Rows[index][6] = promQnty.ToString();
                s.Tables[0].Rows[index][9] = promItemId.ToString();
                s.Tables[0].Rows[index][14] = promItemCOAId.ToString();
                s.Tables[0].Rows[index][11] = promItemUOM.ToString();
                s.Tables[0].Rows[index][10] = promItem.ToString();
                s.Tables[0].Rows[index][12] = promUom.ToString();
                s.Tables[0].Rows[index][13] = promPrice.ToString();


                s.WriteXml(GetXmlFilePath());
            }

            BindGrid(GetXmlFilePath());
            //GetVehicleList();
        }
        private void GetPromoNum(string apprQnt, string qnt, string promo
            , string productId, string uom, string productPrice, string ProductCoaId
            , string priceVar, string currency, string salesType
            , ref decimal promQnty, ref int promItemId, ref int promItemCOAId
            , ref int promItemUOM, ref string promItem, ref string promUom, ref decimal promPrice)
        {

            /*decimal apq, qn, pro;
            apq = decimal.Parse(apprQnt);
            qn = decimal.Parse(qnt);
            pro = decimal.Parse(promo);

            return (Math.Ceiling((qn * pro) / apq)).ToString();*/

            ItemPromotion ip = new ItemPromotion();
            promPrice = ip.GetPromotion(productId, hdnCustomer.Value, priceVar
                , uom, currency
                , salesType, DateTime.Now.Date
                , qnt, ref promQnty, ref promItemId, ref promItem
                , ref promItemUOM, ref promUom, ref promItemCOAId);


            if (promItemId.ToString() == productId)
            {
                promPrice = decimal.Parse(productPrice);
                promItemCOAId = int.Parse(ProductCoaId);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            DataSet ds = new DataSet();
            ds.ReadXml(GetXmlFilePath());

            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.WriteXml(GetXmlFilePath());
            BindGrid(GetXmlFilePath());
            //GetVehicleList();
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count >= 0)
            {
                pnlMain.Enabled = true;
                pnlVehicle.Enabled = true;
              
                rdoNeedVehicle.Enabled = true;
               
            }
        }

        private void BindGrid(string xmlFilePath)
        {
            if (!File.Exists(xmlFilePath)) xm.LoadXmlFile(xmlFilePath);

            XmlDataSource1.Dispose();
            XmlDataSource1.DataFile = xmlFilePath;
            GridView1.DataBind();
        }
        private string GetXmlFilePath()
        {
            string unit = "";
            unit = "" + hdnUnit.Value;

            return Server.MapPath("") + "/Data/CH/" + Session["sesUserID"] + "_" + unit + "_item.xml";
        }
        #endregion
        private void VehiclePr()
        {
            bool enableLogis, logisBy3rdParty;
            decimal logisGain = 0;

            if (rdoNeedVehicle.SelectedValue.ToLower() == "true") enableLogis = true;
            else enableLogis = false;

            if (rdoVhlCompany.SelectedValue.ToLower() == "true") logisBy3rdParty = false;
            else logisBy3rdParty = true;



            //if (hdnXFactoryVhl.Value.ToLower() == "true")
            //{
            //    VehicleVarPrice vp = new VehicleVarPrice();
            //    lblVhkPr.Text = CommonClass.GetFormettingNumber(vp.GetPrice(ddlShip.SelectedValue, hdnProduct.Value, hdnVehicle.Value, ddlVhlType.SelectedValue, hdnCustomer.Value, hdnPriceIdV.Value, ddlCurrency.SelectedValue, ddlUOM.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text), enableLogis, logisBy3rdParty, ref logisGain));
            //}
            //else
            //{
            //    if (rdoNeedVehicle.SelectedValue.ToLower() == "true")
            //    {
            //        VehicleVarPrice vp = new VehicleVarPrice();
            //        lblVhkPr.Text = CommonClass.GetFormettingNumber(vp.GetPrice(ddlShip.SelectedValue, hdnProduct.Value, hdnVehicle.Value, ddlVhlType.SelectedValue, hdnCustomer.Value, hdnPriceIdV.Value, ddlCurrency.SelectedValue, ddlUOM.SelectedValue, CommonClass.GetDateAtSQLDateFormat(txtDate.Text), enableLogis, logisBy3rdParty, ref logisGain));
            //    }
            //    else
            //    {
            //        lblVhkPr.Text = "0.0";
            //    }
            //}

            //lblLogisGain.Text = CommonClass.GetFormettingNumber(logisGain);
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
                        hdnAmount.Value ="0";
                        hdnGain.Value = "0";
                        hdnUom.Value = "0";
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
        protected void rdoVhlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sesCurType"] = rdoVhlCompany.SelectedValue;
            ChangeCompanyVehicle();
        }
        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            VehicleChange();
        }

       
        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            txtVehicle.Text = ((LinkButton)sender).CommandArgument;
            //VehicleChange();
        }
        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\VehicleSelect  Vehcile Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            //try
            //{
                SalesOrderView bllsv = new SalesOrderView();

                StatementC bll = new StatementC(); XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                    XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);
                    string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

                    string narrTop = "";
                    string specification = "";
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[3].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[1].Controls[1])).Text + "] ";
                         
                        }
                    }
            //specification = ((HiddenField)GridView1.Rows[i].FindControl("hdnstrTermsNCondition")).Value.ToString();
            char[] ch = { '[', ']' };
            string[] array;
            string searchkey = txtVehicle.Text;
            array = searchkey.Split(ch);
            if (searchkey.Length <= 1) hdnVehicle.Value = "";
            else
            {
                hdnVehicle.Value = array[1].ToString();
                hdnVehicleText.Value = array[0].ToString();
            }

            string strsupplier = ddlSupllier.SelectedItem.Text.ToString();
            string suppliercoaid =ddlSupllier.SelectedValue.ToString();
          
            string id = "", code = "";
                SAD_BLL.Sales.VehicleSelect vs = new SAD_BLL.Sales.VehicleSelect();
                vs.VehicleAssignNChallan(xml, Session[SessionParams.USER_ID].ToString(), hdnUnit.Value, DateTime.Now
                    , hdnSOid.Value, hdnShipPoint.Value, hdnVehicle.Value
                    , (rdoVhlCompany.SelectedIndex == 2 ? false : true)
                    , (rdoVhlCompany.SelectedIndex == 0 ? true : false)
                    , false
                    , decimal.Parse(hdnAmount.Value), decimal.Parse(hdnGain.Value)
                    , hdnUom.Value, "0"
                    , "0", narrTop
                    , txtDriver.Text, txtDriverContact.Text, hdnVehicleText.Value, suppliercoaid, strsupplier, hdnCustomerText.Value
                    , ref code, ref id);
                lblchallanval.Text = code;

                //Response.Redirect("../../Accounts/Voucher/Exit.aspx");
                if (code.Length > 0)
                {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + code + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
            
                    
                }
                else {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Fail.....');", true);
                
                }
               




            //}
            //catch (Exception ex)
            //{
            //    var efd = log.GetFlogDetail(stop, location, "Submit", ex);
            //    Flogger.WriteError(efd);

            //}

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        private void ChangeCompanyVehicle()
        {
            if (rdoVhlCompany.SelectedValue.ToLower() == "true")
            {
               
                Session["sesCurVhlCom"] = true;
            }
            else
            {
               
                Session["sesCurVhlCom"] = false;
                //txtSupplier.Text = "";
            }

            txtVehicle.Text = "";
        }
        private void ChangeNeedVehicle()
        {
            if (rdoNeedVehicle.SelectedValue.ToLower() == "true")
            {
                
                rdoVhlCompany.SelectedIndex = 0;
            }
            else
            {
              
                //ddlExtra.SelectedIndex = 0;
                //ExtraPr();
            }
        }
        protected void rdoNeedVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hdnXFactoryVhl.Value.ToLower() != "true")
            {
                if (rdoNeedVehicle.SelectedIndex == 1)
                {

                    //txtSupplier.Visible = true;
                    RadioButtonList2.Visible = true;
                    lblSupplier.Visible = true;
                    lblchargeto.Visible = true;

                   
                   
                }
                else
                {
                    //txtSupplier.Visible = false;
                    RadioButtonList2.Visible = false;
                    lblSupplier.Visible = false;
                    lblchargeto.Visible = false;

                }
            }

            ChangeNeedVehicle();
            VehiclePr();
        }

        protected void ddlVhlType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVhlType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

        protected void ddlVhlType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
        }

    
    
    }
}