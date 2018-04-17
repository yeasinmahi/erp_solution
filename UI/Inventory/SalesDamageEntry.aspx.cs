using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class SalesDamageEntry : System.Web.UI.Page
    {

        #region =========== Global Variable Declareation ==========
        DataTable dt = new DataTable(); SalesView bll = new SalesView();
        SalesOrder bllso = new SalesOrder();
        bool ysnChecked;
        int type, actionby, id, unitid,damgcatgid;  
       
        string xmlpath, chalan,
            PdId, PdName, Pdqnt, PdapprovedQnt, Pdpr, PdaccId
            , PdaccName, PdextId, PdextName, PdextPr, Pduom, PduomTxt
            , Pdcurrency, Pdnarration, PdsalesType, PdlogisicId
            , Pdpromotion, Pdcommission, PdincentiveId, Pdincentive
            , PdsuppTax, Pdvat, PdVatPr, PdpromItemId, PdpromItem
            , PdpromUom, PdpromUomText, PdpromPrice, PdpromItemCOAid;
        decimal damageqnt;
        DateTime fdate, tdate;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Order/Data/OR/" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    try { File.Delete(xmlpath); } catch { }
                    

                }
                catch { }
            }
        }
        private void loadgrid()
        {
           
           

                //try
                //{
                    type = int.Parse(drdlreportype.SelectedValue.ToString());
          
                    actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    damgcatgid= int.Parse(drdlReason.SelectedValue.ToString());
            //id = 0;
                    unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
                    fdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFDate.Text).Value;
                    tdate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;
                    chalan = txtchallan.Text.ToString();
            if (type != 4) { dt = bll.Getchalaninfoinfo(type, actionby, "", damgcatgid, fdate, tdate, unitid, chalan); }
            else { dt = bllso.GetDamageItemInfo(type, actionby, "", damgcatgid, fdate, tdate, unitid, chalan); }
                   
                    if (dt.Rows.Count > 0 && type==1)
                    {
                        dgvDamageReport.DataSource = null; dgvDamageReport.DataBind();
                        grdvDamageInputinfo.DataSource = null; grdvDamageInputinfo.DataBind();
                        dgvlist.DataSource = dt; dgvlist.DataBind();

                    }
                   else if (dt.Rows.Count > 0 && type == 3)
                    {
                        dgvlist.DataSource = null; dgvlist.DataBind();
                        grdvDamageInputinfo.DataSource = null; grdvDamageInputinfo.DataBind();
                        dgvDamageReport.DataSource = dt; dgvDamageReport.DataBind();
                  

                   }


            else if (dt.Rows.Count > 0 && type == 4)
            {
                        dgvlist.DataSource = null; dgvlist.DataBind();
                        dgvDamageReport.DataSource = null; dgvDamageReport.DataBind();
                        grdvDamageInputinfo.DataSource = dt; grdvDamageInputinfo.DataBind();

            }

            else { dgvlist.DataSource = ""; dgvlist.DataBind(); }
                //}
                //catch { }
                

        }
        protected void btnshow_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        #region =============== Insert Event Here =====================        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            type = int.Parse(drdlreportype.SelectedValue.ToString());

            if (hdnconfirm.Value == "1")
            {
                if (type == 2)
                {
                    try
                    {
                        if (dgvlist.Rows.Count > 0)
                        {
                            for (int index = 0; index < dgvlist.Rows.Count; index++)
                            {
                                //ysnChecked = ((CheckBox)dgvlist.Rows[index].Cells[0].Controls[0]).Checked;
                                // if (ysnChecked)
                                if (((CheckBox)dgvlist.Rows[index].FindControl("chkRow")).Checked == true)
                                {
                                    string custv = ((HiddenField)dgvlist.Rows[index].FindControl("hdncustid")).Value.ToString();
                                    string productid = ((HiddenField)dgvlist.Rows[index].FindControl("hdnproductid")).Value.ToString();
                                    string challan = ((HiddenField)dgvlist.Rows[index].FindControl("hdnchallan")).Value.ToString();

                                    string transactiondatev = ((Label)dgvlist.Rows[index].FindControl("lbcdate")).Text.ToString();
                                    string insertbyemployeev = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                                    string productuom = ((HiddenField)dgvlist.Rows[index].FindControl("hdncustid")).Value.ToString();
                                    try { damageqnt = decimal.Parse(((TextBox)dgvlist.Rows[index].FindControl("txtDamageQnt")).Text.ToString()); }
                                    catch { damageqnt = 0; }
                                    string productrate = ((HiddenField)dgvlist.Rows[index].FindControl("hdnProductRate")).Value.ToString();
                                    string damagepercantage = txtAdjustPercentage.Text.ToString();
                                    string damgv;
                                    decimal dp=0;
                                    if (damagepercantage=="" || damagepercantage.Length<0)
                                    {
                                        damagepercantage = "0";
                                    }
                                    else
                                    {
                                        damagepercantage = txtAdjustPercentage.Text.ToString();
                                         dp = Convert.ToDecimal(damagepercantage) / Convert.ToDecimal(100);
                                         damgv = dp.ToString();
                                    }
                                    decimal totproductvalue = (decimal.Parse(damageqnt.ToString()) * decimal.Parse(productrate.ToString()));
                                    decimal calcperc = (decimal.Parse(totproductvalue.ToString()) * (dp));
                                    decimal finalamount = totproductvalue - calcperc;
                                    Createxml(custv, productid, Convert.ToString(damageqnt), finalamount.ToString(), challan, transactiondatev);
                                }
                            }
                            #region ------------ Insert into dataBase -----------
                            int unit = int.Parse(drdlUnitName.SelectedValue.ToString());
                            int user = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                            type = int.Parse(drdlreportype.SelectedValue.ToString());
                            damgcatgid = int.Parse(drdlReason.SelectedValue.ToString());
                            XmlDocument doc = new XmlDocument();
                            doc.Load(xmlpath);
                            XmlNode dSftTm = doc.SelectSingleNode("SalesDamageQnt");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<SalesDamageQnt>" + xmlString + "</SalesDamageQnt>";
                            dt = bll.Getchalaninfoinfo(type, user, xmlString, damgcatgid, fdate, tdate, unit, "");
                            try { File.Delete(xmlpath); } catch { }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);

                            if (dt.Rows[0]["Messages"].ToString() == "Damage Item Information submitted successfully.")
                            {
                                dt = new DataTable(); dgvlist.DataSource = dt; dgvlist.DataBind();
                            }
                            #endregion ------------ Insertion End ----------------
                            dgvlist.DataSource = ""; dgvlist.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                        }
                    }
                    catch { File.Delete(xmlpath); }
                }

                if (type == 5)
                {
                    //try
                    //{
                        if (grdvDamageInputinfo.Rows.Count > 0)
                        {
                            for (int index = 0; index < grdvDamageInputinfo.Rows.Count; index++)
                            {

                                PdId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("hdnPId")).Value.ToString();
                                PdName = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPName")).Value.ToString();
                                Pdqnt = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("hdnQnt")).Value.ToString();

                                PdapprovedQnt = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("hdnApprovedQnt")).Value.ToString();
                                Pdpr = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("hdnPr")).Value.ToString();
                                PdaccId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenAccId")).Value.ToString();

                                PdaccName = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddeAccName")).Value.ToString();
                                PdextId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenExtId")).Value.ToString();

                                PdextName = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenExtName")).Value.ToString();
                                PdextPr = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenExtPr")).Value.ToString();
                                Pduom = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenUom")).Value.ToString();
                                PduomTxt = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenUomTxt")).Value.ToString();
                                Pdcurrency = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenCurrency")).Value.ToString();
                                Pdnarration = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenNarration")).Value.ToString();
                                PdsalesType = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenSalesType")).Value.ToString();
                                PdlogisicId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenLogisicId")).Value.ToString();
                                Pdpromotion = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromotion")).Value.ToString();
                                Pdcommission = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenCommission")).Value.ToString();
                                PdincentiveId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenIncentiveId")).Value.ToString();
                                Pdincentive = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenIncentive")).Value.ToString();
                                PdsuppTax = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenSuppTax")).Value.ToString();
                                Pdvat = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenVat")).Value.ToString();
                                PdVatPr = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenVatPr")).Value.ToString();
                                PdpromItemId = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromItemId")).Value.ToString();
                                PdpromItem = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromItem")).Value.ToString();
                                PdpromUom = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromUom")).Value.ToString();
                                PdpromUomText = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromUomText")).Value.ToString();
                                PdpromPrice = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromPrice")).Value.ToString();
                                PdpromItemCOAid = ((HiddenField)grdvDamageInputinfo.Rows[index].FindControl("HiddenPromItemCOAid")).Value.ToString();
                               
                                CreatexmlReturnDO(PdId, PdName, Pdqnt, PdapprovedQnt, Pdpr, PdaccId, PdaccName,PdextId,PdextName,PdextPr,Pduom,PduomTxt,Pdcurrency,Pdnarration,
                                PdsalesType,PdlogisicId,Pdpromotion,Pdcommission,PdincentiveId,Pdincentive,PdsuppTax,Pdvat,PdVatPr,PdpromItemId,PdpromItem,PdpromUom,PdpromUomText,
                                PdpromPrice,PdpromItemCOAid );
                                
                            }
                            #region ------------ Insert into dataBase -----------
                            int unit = int.Parse(drdlUnitName.SelectedValue.ToString());
                            int user = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                            type = int.Parse(drdlreportype.SelectedValue.ToString());
                            damgcatgid = int.Parse(drdlReason.SelectedValue.ToString());
                            string challan = txtchallan.Text;
                            XmlDocument doc = new XmlDocument();
                            doc.Load(xmlpath);
                            XmlNode dSftTm = doc.SelectSingleNode("SalesDamageQnt");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<SalesDamageQnt>" + xmlString + "</SalesDamageQnt>";
                            dt = bllso.GetDamageItemInfo(type, user, xmlString, damgcatgid, fdate, tdate, unit, challan);
                            try { File.Delete(xmlpath); } catch { }
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);
                           dt = new DataTable(); dgvlist.DataSource = dt; dgvlist.DataBind();
                        //if (dt.Rows[0]["Messages"].ToString() == "Damage Item Information submitted successfully.")
                        //{
                        //    dt = new DataTable(); dgvlist.DataSource = dt; dgvlist.DataBind();
                        //}
                        #endregion ------------ Insertion End ----------------
                        dgvlist.DataSource = ""; dgvlist.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry(:  Please Select Detaills option then click Approve');", true);
                        }
                    //}
                    //catch { File.Delete(xmlpath); }
                }


            }
        }
        #endregion


        #region ================ Generate XML and Others ==========        
        private void Createxml(string custmid,string productid, string damageqnt, string damagevalue, string challannumber, string challandate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("SalesDamageQnt");
                XmlNode addItem = CreateNode(doc, custmid, productid, damageqnt, damagevalue, challannumber, challandate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalesDamageQnt");
                XmlNode addItem = CreateNode(doc, custmid, productid,  damageqnt, damagevalue, challannumber, challandate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string custmid, string productid, string damageqnt, string damagevalue, string challannumber, string challandate)
        {
            XmlNode node = doc.CreateElement("req");

            XmlAttribute CUSTOMID = doc.CreateAttribute("custmid"); CUSTOMID.Value = custmid;
            XmlAttribute Productid = doc.CreateAttribute("productid"); Productid.Value = productid;
            XmlAttribute Damageqnt = doc.CreateAttribute("damageqnt"); Damageqnt.Value = damageqnt;
            XmlAttribute Damagevalue = doc.CreateAttribute("damagevalue"); Damagevalue.Value = damagevalue;
            XmlAttribute Challannumber = doc.CreateAttribute("challannumber"); Challannumber.Value = challannumber;
            XmlAttribute Challandate = doc.CreateAttribute("challandate"); Challandate.Value = challandate;
            

            node.Attributes.Append(CUSTOMID);
            node.Attributes.Append(Productid);
            node.Attributes.Append(Damageqnt);
            node.Attributes.Append(Damagevalue);
            node.Attributes.Append(Challannumber);
            node.Attributes.Append(Challandate);
            

            return node;
        }
        #endregion




        #region ================ Generate Return D.O  XML ==========        
        private void CreatexmlReturnDO(string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("SalesDamageQnt");
                XmlNode addItem = CreateNodeReturnDO(doc, pId, pName, qnt, approvedQnt, pr, accId
            , accName, extId, extName, extPr, uom, uomTxt
            , currency, narration, salesType, logisicId
            , promotion, commission, incentiveId, incentive
            , suppTax, vat, VatPr, promItemId, promItem
            , promUom, promUomText, promPrice, promItemCOAid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalesDamageQnt");
                XmlNode addItem = CreateNodeReturnDO(doc, pId, pName, qnt, approvedQnt, pr, accId
            , accName, extId, extName, extPr, uom, uomTxt
            , currency, narration, salesType, logisicId
            , promotion, commission, incentiveId, incentive
            , suppTax, vat, VatPr, promItemId, promItem
            , promUom, promUomText, promPrice, promItemCOAid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNodeReturnDO(XmlDocument doc, string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid)
        {
            XmlNode node = doc.CreateElement("req");

           
            XmlAttribute PId = doc.CreateAttribute("pId"); PId.Value = pId;
            XmlAttribute PName = doc.CreateAttribute("pName"); PName.Value = pName;
            XmlAttribute Qnt = doc.CreateAttribute("qnt"); Qnt.Value = qnt;
            XmlAttribute ApprovedQnt = doc.CreateAttribute("approvedQnt"); ApprovedQnt.Value = approvedQnt;
            XmlAttribute Pr = doc.CreateAttribute("pr"); Pr.Value = pr;
            XmlAttribute AccId = doc.CreateAttribute("accId"); AccId.Value = accId;

            XmlAttribute AccName = doc.CreateAttribute("accName"); AccName.Value = accName;
            XmlAttribute ExtId = doc.CreateAttribute("extId"); ExtId.Value = extId;
            XmlAttribute ExtName = doc.CreateAttribute("extName"); ExtName.Value = extName;
            XmlAttribute ExtPr = doc.CreateAttribute("extPr"); ExtPr.Value = extPr;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute UomTxt = doc.CreateAttribute("uomTxt"); UomTxt.Value = uomTxt;


            XmlAttribute Currency = doc.CreateAttribute("currency"); Currency.Value = currency;
            XmlAttribute Narration = doc.CreateAttribute("narration"); Narration.Value = narration;
            XmlAttribute SalesType = doc.CreateAttribute("salesType"); SalesType.Value = salesType;
            XmlAttribute LogisicId = doc.CreateAttribute("logisicId"); LogisicId.Value = logisicId;

            XmlAttribute Promotion = doc.CreateAttribute("promotion"); Promotion.Value = promotion;
            XmlAttribute Commission = doc.CreateAttribute("commission"); Commission.Value = commission;
            XmlAttribute IncentiveId = doc.CreateAttribute("incentiveId"); IncentiveId.Value = incentiveId;
            XmlAttribute INcentive = doc.CreateAttribute("Incentive"); INcentive.Value = incentive;

            XmlAttribute SuppTax = doc.CreateAttribute("suppTax"); SuppTax.Value = suppTax;
            XmlAttribute Vat = doc.CreateAttribute("vat"); Vat.Value = vat;
            XmlAttribute VAtPr = doc.CreateAttribute("VatPr"); VAtPr.Value = VatPr;
            XmlAttribute PromItemId = doc.CreateAttribute("promItemId"); PromItemId.Value = promItemId;

            XmlAttribute PromUom = doc.CreateAttribute("promUom"); PromUom.Value = promUom;
            XmlAttribute PromUomText = doc.CreateAttribute("promUomText"); PromUomText.Value = promUomText;
            XmlAttribute PromPrice = doc.CreateAttribute("promPrice"); PromPrice.Value = promPrice;
            XmlAttribute PromItemCOAid = doc.CreateAttribute("promItemCOAid"); PromItemCOAid.Value = promItemCOAid;
            

            node.Attributes.Append(PId);
            node.Attributes.Append(PName);
            node.Attributes.Append(Qnt);
            node.Attributes.Append(ApprovedQnt);
            node.Attributes.Append(Pr);
            node.Attributes.Append(AccId);

            node.Attributes.Append(AccName);
            node.Attributes.Append(ExtId);
            node.Attributes.Append(ExtName);
            node.Attributes.Append(ExtPr);
            node.Attributes.Append(Uom);
            node.Attributes.Append(UomTxt);

            node.Attributes.Append(Currency);
            node.Attributes.Append(Narration);
            node.Attributes.Append(SalesType);
            node.Attributes.Append(LogisicId);
            node.Attributes.Append(Promotion);
            node.Attributes.Append(Commission);
            node.Attributes.Append(IncentiveId);
            node.Attributes.Append(INcentive);

            node.Attributes.Append(SuppTax);
            node.Attributes.Append(Vat);
            node.Attributes.Append(VAtPr);
            node.Attributes.Append(PromItemId);
            node.Attributes.Append(PromUom);
            node.Attributes.Append(PromUomText);
            node.Attributes.Append(PromPrice);
            node.Attributes.Append(PromItemCOAid);

            return node;
        }
        #endregion













        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}