using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using LOGIS_BLL;
using BLL.Accounts.ChartOfAccount;
using System.IO;
using SAD_BLL.Item;
using SAD_DAL.Sales;
using System.Data;
using SAD_BLL.Sales;
using System.Xml;
using LOGIS_BLL.Trip;
using LOGIS_DAL.Trip;
using UI.ClassFiles;
using SAD_BLL.Customer.Report;
using SAD_DAL.Customer.Report;

namespace UI.SAD.Order
{
    public partial class VehicleSelect : BasePage
    //public partial class SAD_Order_VehicleSelect : System.Web.UI.Page
    {
        XmlManagerCH xm = new XmlManagerCH();
        decimal prdouctvalue, outstandingv;
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["sesUserID"] = "87";


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

                        if (table[0].ysnLogistic) rdoVhlCompany.SelectedIndex = 0;
                        else rdoVhlCompany.SelectedIndex = 2;

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

                        GetVehicleList();

                    }
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["sesCurType"] = rdoVhlCompany.SelectedValue;

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
            }
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

            ds.Tables[0].Rows[e.RowIndex].Delete();
            ds.WriteXml(GetXmlFilePath());
            BindGrid(GetXmlFilePath());
            GetVehicleList();
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
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    XmlDocument xmlDoc = xm.LoadXmlFile(GetXmlFilePath());
        //    XmlNode node = xmlDoc.SelectSingleNode(xm.MainNode);
        //    string xml = ("<" + xm.MainNode + "> " + node.InnerXml + " </" + xm.MainNode + ">");

        //    string narrTop = "";
        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
        //        {
        //            narrTop += "[" + ((Label)(GridView1.Rows[i].Cells[2].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[3].Controls[1])).Text + " " + ((Label)(GridView1.Rows[i].Cells[1].Controls[1])).Text + "] ";
        //        }
        //    }

        //    string id = "", code = "";
        //    SAD_BLL.Sales.VehicleSelect vs = new SAD_BLL.Sales.VehicleSelect();
        //    vs.VehicleAssign(xml, Session[SessionParams.USER_ID].ToString(), hdnUnit.Value, DateTime.Now
        //        , hdnSOid.Value, hdnShipPoint.Value, hdnVehicle.Value
        //        , (rdoVhlCompany.SelectedIndex == 2 ? false : true)
        //        , (rdoVhlCompany.SelectedIndex == 0 ? true : false)
        //        , rdo3rdPartyCharge.SelectedIndex == 0 ? true : false
        //        , decimal.Parse(hdnAmount.Value), decimal.Parse(hdnGain.Value)
        //        , hdnUom.Value, ddlExtra.SelectedValue
        //        , ddlIncentive.SelectedValue, narrTop
        //        , ref code, ref id);

        //    Response.Redirect("../../Accounts/Voucher/Exit.aspx");
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         

            StatementC bll = new StatementC();
           
            StatementTDS.SprUnDelvQntBaseOutstandingAmountDataTable tabUndlvpv = bll.GetCustomerOutstandingbasedonUndelvQnt(hdnCustomer.Value);
            StatementTDS.SprUndelvQntRateDataTable tabUndlvproductRate = bll.GetCustomerProductRate(hdnSOid.Value);
        
            decimal newqnt = Convert.ToDecimal(GetGrandTotal(2));
            int soid = int.Parse(hdnSOid.Value);
            int unitid = int.Parse(hdnUnit.Value);
            if (unitid == 53)
            {
                if (tabUndlvpv.Rows.Count > 0)
                {
                    hdnoutstandingamount.Value = tabUndlvpv[0].monOutstanding.ToString();
                    lblundelvvalue.Text = hdnoutstandingamount.Value;
                }

                if (tabUndlvproductRate.Rows.Count > 0)
                {
                    hdnUndelvProductRate.Value = tabUndlvproductRate[0].rateofproduct.ToString();
                     prdouctvalue = decimal.Parse(hdnUndelvProductRate.Value) * newqnt;
                     outstandingv =Math.Abs( decimal.Parse(lblundelvvalue.Text));
                }



            }
            else
            {
                lblundelvvalue.Text = "0.0";
            }
            

            if (  unitid == 53 && prdouctvalue <= outstandingv )
            {


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

                Response.Redirect("../../Accounts/Voucher/Exit.aspx");
            }
            else if(unitid!= 53)
            {
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

                Response.Redirect("../../Accounts/Voucher/Exit.aspx");


            }
            else
            {
                lblmsg.Text = "Balance Exceed, Please contact with Credit Dept.";
                lblmsg.BackColor = System.Drawing.Color.FromArgb(255, 50, 50); // this should be pink-ish;
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