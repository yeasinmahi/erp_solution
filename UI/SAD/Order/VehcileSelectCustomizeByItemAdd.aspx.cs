using Flogging.Core;
using LOGIS_BLL;
using LOGIS_BLL.Trip;
using LOGIS_DAL.Trip;
using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_DAL.Customer.Report;
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
using Utility;

namespace UI.SAD.Order
{
    public partial class VehcileSelectCustomizeByItemAdd : BasePage
    {
        XmlManagerCH xm = new XmlManagerCH();
        decimal prdouctvalue, outstandingv;
        private string[] arrayKey;
        private readonly char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1;
        string filePathForXML;
        string xmlStrings = "";
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
               
               
                try
                {
                     
                        if (Request.QueryString["id"] != null)
                        {
                            btnSubmit.Enabled = true;
                            try
                            {
                                string path = GetXmlFilePath();
                                File.Delete(path);
                            }
                            catch { }

                            Session[SessionParams.CURRENT_UNIT] = Request.QueryString["unit"];
                            Session[SessionParams.CURRENT_SHIP] = Request.QueryString["ship"];
                            //SprSalesOrderCustomerDOwithReturnDO
                            //SalesOrderTDS.QrySalesOrderCustomerDataTable table;
                            SalesOrderTDS.SprSalesOrderCustomerDOwithReturnDODataTable table;

                            SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                            //table = se.GetSalesOrder(Request.QueryString["id"]);
                            table = se.GetSalesOrderWithRetunDO(Request.QueryString["id"]);
                            if (table.Rows.Count > 0)
                            { 

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

                                if (table[0].ysnLogistic) rdoVhlCompany.SelectedIndex = 0;
                                else rdoVhlCompany.SelectedIndex = 2; 

                                GetVehicleList();
                              
                            }

                        }
                    
                    
                }
                catch (Exception ex)
                {
                  
                    btnSubmit.Enabled = true;
                }

              
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //filePathForXML = Server.MapPath(HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" + "vehicleSelectNItemadd.xml");
           // filePathForXML = Server.MapPath("") + "/Data/CH/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_"  + "vehicleSelectNItemadd.xml";

            if (!IsPostBack)
            {
                if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());
                Session["sesCurType"] = rdoVhlCompany.SelectedValue;
                btnSubmit.Enabled = true;
                BindGrid(GetXmlFilePath());
                if (hdnDoCode.Value != "")
                {
                    TripCallTDS.QryTripByDoDataTable tbl = new TripCall().GetVehicleByDoCode(hdnDoCode.Value, hdnUnit.Value, hdnShipPoint.Value);
                    if (tbl.Rows.Count > 0)
                    {
                        txtVehicle.Text = tbl[0].strRegNo + " [" + tbl[0].intVehicleId.ToString() + "]";
                        if (tbl[0].ysnOwn) rdoVhlCompany.SelectedIndex = 0;
                        else if (!tbl[0].Isint3rdPartyCOAidNull()) rdoVhlCompany.SelectedIndex = 1;
                        else if (!tbl[0].IsintForThisCustomerNull()) rdoVhlCompany.SelectedIndex = 2;

                        VehicleChange();
                       
                    }
                }
                DefaultPageLoadBind();
            }
        }

        private void DefaultPageLoadBind()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                     
                    SalesOrderTDS.SprSalesOrderCustomerDOwithReturnDODataTable table;

                    SAD_BLL.Sales.SalesOrder se = new SAD_BLL.Sales.SalesOrder();
                    //table = se.GetSalesOrder(Request.QueryString["id"]);
                    table = se.GetSalesOrderWithRetunDO(Request.QueryString["id"]);
                    if (table.Rows.Count > 0)
                    { 

                        SalesOrderTDS.SprSalesOrderDetaillsForTripAssignDataTable tbl = se.GetSalesOrderDetailsTrip(table[0].intId.ToString());
                        Session["SalesDoId"] = table[0].intId.ToString();
                        ddlPendingItem.LoadWithSelect(tbl, "intProductId", "strProductName"); 

                    }
                     
                }
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleList(string prefixText, int count)
        {
            if (HttpContext.Current.Session["sesCurType"].ToString() == "c")
            {
                return VehicleSt.GetVehicleDataForAutoFillCompany(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, false);
            }
            else if (HttpContext.Current.Session["sesCurType"].ToString() == "p")
            {
                return VehicleSt.GetVehicleDataForAutoFillParty(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, false);
            }
            else
            {
                return VehicleSt.GetVehicleDataForAutoFillCustomer(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SHIP].ToString(), prefixText, true, false);
            }
        }


        [WebMethod]
        [ScriptMethod] 
        public static string[] GetProductList(string prefixText, int count)
        {
            return SalesSearch_BLL.GetPendingProductAutoFill(HttpContext.Current.Session["SalesDoId"].ToString(), prefixText);
        }
        private void CheckXmlItemReqData(string itemids)
        {
            try
            {
                DataSet ds = new DataSet();
                if (File.Exists(GetXmlFilePath()))
                {
                    ds.ReadXml(GetXmlFilePath());
                    int i = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (itemids == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                        {
                            CheckItem = 0;
                            break;
                        }
                        CheckItem = 1;
                    }
                }
            }
            catch { }
            
             
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

                string narr = newQnt + " " + uomTxt + " " + pName + " Sold To " + hdnCustomerText.Value;

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
            GetVehicleList();
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
            string Id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblProductID")).Text;
            string ProductName = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblProductName")).Text; 
            ds.Tables[0].Rows[e.RowIndex].Delete();
           
            ddlPendingItem.Items.Insert(0, new ListItem( ProductName, Id));

            ds.WriteXml(GetXmlFilePath());
            BindGrid(GetXmlFilePath()); 

        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {

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
        protected void rdoVhlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sesCurType"] = rdoVhlCompany.SelectedValue;
            ChangeCompanyVehicle();
        }
        protected void txtVehicle_TextChanged(object sender, EventArgs e)
        {
            VehicleChange();
        }

        private void GetVehicleList()
        {
            XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
            XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
            //hdnXMLData.Value = ("<" + xm.MainNode + "> " + selectNode.InnerXml + " </" + xm.MainNode + ">").ToString();
            Session["sesXML"] = ("<" + xm.MainNode + "> " + selectNode.InnerXml + " </" + xm.MainNode + ">");
            if (IsPostBack) GridView2.DataBind();
        }
        private void ChangeCompanyVehicle()
        {
            if (rdoVhlCompany.SelectedIndex == 0 || rdoVhlCompany.SelectedIndex == 2)
            {
                pnlVehicle3rd.Visible = false;
            }
            else
            {
                pnlVehicle3rd.Visible = true;
            }

            txtVehicle.Text = "";
            lblWb.Text = "";
            lblL.Text = "";
            lblC.Text = "";
            lblChallan.Text = "";
        }

        private void VehicleChange()
        {
            if (txtVehicle.Text.Trim() != "")
            {
                bool isVehicleOk = false;
                decimal gain = 0;
                int uom = 0;
                char[] ch = { '[', ']' };
                string[] temp = txtVehicle.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                DateTime? wbIn = null;
                decimal capacity = 0, loaded = 0;
                string trip = "";

                if (temp.Length >= 1)
                {
                    hdnVehicleText.Value = temp[0];
                    hdnVehicle.Value = temp[temp.Length - 1];


                    VehicleVarPrice vp = new VehicleVarPrice();
                    decimal price = vp.GetPriceBySO(hdnSOid.Value, hdnShipPoint.Value, hdnUnit.Value, hdnCustomer.Value, hdnVehicle.Value
                        , hdnLogVar.Value, hdnCurrency.Value, DateTime.Parse(hdnDate.Value)
                        , (rdoVhlCompany.SelectedIndex == 2 ? false : true)
                        , bool.Parse(rdo3rdPartyCharge.SelectedValue)
                        , (rdoVhlCompany.SelectedIndex == 0 ? true : false)
                        , (rdoVhlCompany.SelectedIndex == 1 ? true : false)
                        , (rdoVhlCompany.SelectedIndex == 2 ? true : false)
                        , ref gain, ref uom, ref isVehicleOk
                        , ref capacity, ref loaded, ref wbIn, ref trip);

                    if (isVehicleOk)
                    {
                        hdnAmount.Value = price.ToString();
                        hdnGain.Value = gain.ToString();
                        hdnUom.Value = uom.ToString();
                        lblC.Text = CommonClass.GetFormettingNumber(capacity);
                        lblL.Text = CommonClass.GetFormettingNumber(loaded);
                        lblWb.Text = wbIn == null ? "No Entered" : ((CommonClass.GetLongDateAtLocalDateFormat((DateTime)wbIn)) + " " + (CommonClass.GetTimeAtLocalDateFormat((DateTime)wbIn)));
                        if (loaded > 0) lblChallan.Text = "<a href=\"#\" onclick=\"ShowPopUpE('ChallanOneGP.aspx?id=" + trip + "&unit=" + Request.QueryString["unit"] + "')\"class=\"link\">Click Here To View Challan</a>";
                        else lblChallan.Text = "";
                    }
                    else
                    {
                        hdnAmount.Value = "";
                        hdnGain.Value = "";
                        hdnUom.Value = "";
                        hdnVehicleText.Value = "";
                        hdnVehicle.Value = "";
                        txtVehicle.Text = "";
                        lblC.Text = "";
                        lblL.Text = "";
                        lblWb.Text = "";
                        lblChallan.Text = "";
                    }
                }
            }

        }
        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            txtVehicle.Text = ((LinkButton)sender).CommandArgument;
            VehicleChange();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
          
            try
            { 

                if (hdnconfirm.Value == "1")
                {
                    btnSubmit.Visible = false;
                    StatementC bll = new StatementC();

                    StatementTDS.SprUnDelvQntBaseOutstandingAmountDataTable tabUndlvpv = bll.GetCustomerOutstandingbasedonUndelvQnt(hdnCustomer.Value);
                    StatementTDS.SprUndelvQntRateDataTable tabUndlvproductRate = bll.GetCustomerProductRate(hdnSOid.Value);

                    decimal newqnt = Convert.ToDecimal(GetGrandTotal(2));
                    int soid = int.Parse(hdnSOid.Value);
                    int unitid = int.Parse(hdnUnit.Value);
                     
                    
                            XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                            XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);
                            string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

                            string narrTop = "";
                            for (int i = 0; i < GridView1.Rows.Count; i++)
                            {
                                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                                {
                                    narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[3].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[1].Controls[1])).Text + "] ";
                                }
                            }

                        try { File.Delete(GetXmlFilePath()); } catch { }
                        string id = "", code = "";
                            SAD_BLL.Sales.VehicleSelect vs = new SAD_BLL.Sales.VehicleSelect();
                            vs.VehicleAssign(xml, Session[SessionParams.USER_ID].ToString(), hdnUnit.Value, DateTime.Now
                                , hdnSOid.Value, hdnShipPoint.Value, hdnVehicle.Value
                                , (rdoVhlCompany.SelectedIndex == 2 ? false : true)
                                , (rdoVhlCompany.SelectedIndex == 0 ? true : false)
                                , rdo3rdPartyCharge.SelectedIndex == 0 ? true : false
                                , decimal.Parse(hdnAmount.Value), decimal.Parse(hdnGain.Value)
                                , hdnUom.Value, ddlExtra.SelectedValue
                                , ddlIncentive.SelectedValue, narrTop
                                , ref code, ref id);
                               try { File.Delete(GetXmlFilePath()); } catch { }

                            string tripid = "";
                            string challannumber = "";
                            string tripcodenumber = "";
                            string calcuwgt = "";
                            decimal totalwgt = 0;
                            SAD_BLL.Sales.SalesOrder bllso = new SAD_BLL.Sales.SalesOrder();
                            bllso.GetTripidfromSalesOrderID(hdnSOid.Value, ref tripid, ref challannumber);


                            Trip t = new Trip();
                            t.CompleteTripAssign(tripid, Session[SessionParams.USER_ID].ToString());

                            // For Empty vheicle weight
                            bllso.tripcodenumber(tripid, ref tripcodenumber);
                            t.SetEmptyWeight(tripid, Session[SessionParams.USER_ID].ToString(), decimal.Parse("3"), "1049");

                            // For Loaded Weight
                            //bllso.tripidvscalculatedweight(tripid, ref calcuwgt);

                            //totalwgt = decimal.Parse("3") + decimal.Parse(calcuwgt);

                            //t.SetLoadedWeight(tripid, Session[SessionParams.USER_ID].ToString(), totalwgt); 

                            Response.Redirect("../../Accounts/Voucher/Exit.aspx");
                         
                    }

                btnSubmit.Visible = true;

            }
            catch (Exception ex)
            {
                btnSubmit.Visible = true;

                try { File.Delete(GetXmlFilePath()); } catch { }
                BindGrid(GetXmlFilePath());
            }

          
        }

        

        protected void ddlExtra_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < ddlExtra.Items.Count; i++)
            {
                if (ddlExtra.Items[i].Value == hdnCharge.Value)
                {
                    ddlExtra.SelectedIndex = i;
                    break;
                }
            }
        }
        protected void ddlIncentive_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < ddlIncentive.Items.Count; i++)
            {
                if (ddlIncentive.Items[i].Value == hdnIncentive.Value)
                {
                    ddlIncentive.SelectedIndex = i;
                    break;
                }
            }
        }

        protected void ddlPendingItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                    txtItem.Text = "";
                    lblItemDet.Text = "";
                int itemId = int.Parse(ddlPendingItem.SelectedValue);
                    lblItemDet.Text = ddlPendingItem.SelectedItem.ToString();
                    DoItemInfo(itemId);
               
            }
            catch { }

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = "";
                string itemid = "";
                lblItemDet.Text = "";
                if (arrayKey.Length > 1)
                {
                    
                    item = arrayKey[0];
                    itemid = arrayKey[3];
                    lblItemDet.Text = item;
                    DoItemInfo(int.Parse(itemid));
                    txtItem.Focus(); 
                    //txtQnt.Text = hdnprdqnt.ToString();
                }
                else
                {
                   // Toaster("Please add Item name properly", Common.TosterType.Warning);
                    //return;
                }
            }
            catch { }

            
        }

        private void DoItemInfo(int ItemId)
        {
            try
            {
               int intOrderID = int.Parse(HttpContext.Current.Session["SalesDoId"].ToString());
                hdnprdctid.Value = "";
                hdnprdname.Value = "";
                hdnprdqnt.Value = "";

                hdnprduom.Value = "";
                hdnpromprdid.Value = "";
                hdnpromuom.Value = "";
                hdnpromPrdName.Value = "";

               DataTable dt = new DataTable();
                SalesSearch_BLL bll = new SalesSearch_BLL();
                dt = bll.getSONPrdIDBaseDet(intOrderID, ItemId);
                hdnprdctid.Value = dt.Rows[0]["intProductId"].ToString();
                //Session["intProductId"] = dt.Rows[0]["intProductId"].ToString();
                hdnprdname.Value = dt.Rows[0]["strProductName"].ToString();
                hdnprdrate.Value = dt.Rows[0]["monPrice"].ToString();
                //Session["strProductName"] = dt.Rows[0]["strProductName"].ToString();

                hdnprdqnt.Value = dt.Rows[0]["numQuantity"].ToString();

                txtQnt.Text = hdnprdqnt.Value.ToString();
                hdnprduom.Value = dt.Rows[0]["strUOM"].ToString();
                hdnpromPrdName.Value = dt.Rows[0]["strPromItemName"].ToString();
                hdnpromprdid.Value = dt.Rows[0]["intPromItemId"].ToString();
                hdnPromPrice.Value = dt.Rows[0]["monPromPrice"].ToString();
                hdnpromqnt.Value = dt.Rows[0]["numPromotion"].ToString();
                hdnpromuom.Value = dt.Rows[0]["intPromUOM"].ToString();
                hdnpromcoa.Value= dt.Rows[0]["intPromItemCOAId"].ToString();
            }
            catch { }
        }

       
      

       

        protected void btnAdds_Click(object sender, EventArgs e)
        {
            try
            {
                string Pid = hdnprdctid.Value.ToString();
                string PName = hdnprdname.Value.ToString();


                string Qnt = txtQnt.Text.ToString();
                string prdrate = hdnprdrate.Value.ToString();

                string Uom = hdnprduomid.Value.ToString();
                string Narr = "";
                string Prom = "0";
                string UomTxt = hdnprduom.Value.ToString();
                string PromItemId = hdnpromprdid.Value.ToString();
                string PromItem = hdnprdname.Value.ToString();
                string promprdqnt = hdnpromqnt.Value.ToString();
                string promotionprdRate = hdnPromPrice.Value;
                string PromUom = hdnpromuom.Value;
                string PromUomText = hdnprduom.Value.ToString();


                string PromPr = hdnPromPrice.Value;
                string PromItemCOA = hdnpromcoa.Value;
                string SoPkId = HttpContext.Current.Session["SalesDoId"].ToString();
               // CreateVoucherXml(Pid, PName, Qnt, Uom, Narr, Prom, UomTxt, PromItemId, PromItem, PromUom, PromUomText, PromPr, PromItemCOA, SoPkId);


          
                SalesSearch_BLL bll = new SalesSearch_BLL();  
             //   if (File.Exists(GetXmlFilePath())) File.Delete(GetXmlFilePath());
              
                SearchSales_TDS.SprSalesOrderDetaillsBySOIdNItmIDDataTable tbl = bll.GetSalesOrderDetailsTrip(int.Parse(HttpContext.Current.Session["SalesDoId"].ToString()), int.Parse(Pid)); 
                decimal promQnty = 0;
                int promItemId = 0;
                int promItemCOAId = 0;
                int promItemUOM = 0;
                string promItem = "";
                string promUom = "";
                decimal promPrice = 0;
                
                int i = 0;
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
                CheckXmlItemReqData(Pid);
                if (int.Parse(txtQnt.Text.ToString())<=int.Parse(tbl[i].numApprQuantity.ToString()) && txtQnt.Text.Length>0)
                {
                    if(CheckItem == 1)
                    {
                        string[][] items = xm.CreateItems(tbl[i].intProductId.ToString()
                       , tbl[i].strProductName
                       , txtQnt.Text.ToString()// tbl[i].numRestQuantity.ToString()
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
                        XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
                        XmlNode selectNode = xmlDoc.SelectSingleNode(xm.MainNode);
                        selectNode.AppendChild(xm.CreateNodeForItem(xmlDoc, items));
                        xmlDoc.Save(GetXmlFilePath());

                        BindGrid(GetXmlFilePath());
                        lblItemDet.Text = "";txtQnt.Text = "0";txtItem.Text = "";

                        ListItem removeItem = ddlPendingItem.Items.FindByValue(Pid);
                        ddlPendingItem.Items.Remove(removeItem);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('U can not add same item two times');", true);
                    }
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry-- wrong format data. plz check');", true);
                }
                    

            }
            catch { }
             
           
        }

       



        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "0")
                {
                    e.Row.BackColor = System.Drawing.Color.YellowGreen;
                }
                else if (e.Row.Cells[5].Text == "1")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                else if (e.Row.Cells[5].Text == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                }
                else if (e.Row.Cells[5].Text == "3")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}