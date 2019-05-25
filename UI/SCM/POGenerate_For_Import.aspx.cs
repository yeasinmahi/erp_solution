using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class POGenerate_For_Import : BasePage
    {
        private DataTable dt = new DataTable();
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private int intWh;
        private string filePathForXML, filePathForXMLPrepare, filePathForXMLPo, othersTrems, warrentyperiod; private string xmlString = "";
        private int indentNo, whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem; private string payDate, paymentTrems, destDelivery, paymentSchedule; private DateTime dtePo, dtelastShipment; private decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;
        private string[] arrayKey; private string strType; private char[] delimiterChars = { '[', ']' };

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/In__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLPrepare = Server.MapPath("~/SCM/Data/InPre__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLPo = Server.MapPath("~/SCM/Data/Po__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                try { File.Delete(filePathForXMLPrepare); } catch { }
                try { File.Delete(filePathForXMLPo); } catch { }
                DateTime dte = DateTime.Now;
                txtdtePo.Text = dte.ToString("yyyy-MM-dd");
                dte = DateTime.Parse(txtdtePo.Text);
                //txtIndentNoDet.Enabled = false;
                DefaltPageLoad();
                LoadDropDownList();
            }
            else
            {
            }
        }
        private void LoadDropDownList()
        {
            dt=objPo.ImportLCType();
            ddlLCType.Loads(dt, "intLcType", "strLcType");
            dt = objPo.MaterialType();
            ddlMaterialType.Loads(dt, "intAutoID", "strReqItemCategory");
            dt = objPo.ImportLcIncoTerms();
            ddlIncoTerm.Loads(dt, "intLcIncoTerms", "strIncoTerms");
            dt=objPo.BankInfoForImportPayment();
            ddlBank.Loads(dt, "intBankID", "strBankCode");


            hdnWHName.Value = "ACCL Central";
            hdnWHId.Value ="4";
            hdnUnitId.Value = "4";
            Session["unitId"] = hdnUnitId.Value;
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(hdnWHName.Value.ToString(), hdnWHId.Value.ToString()));
            ddlWHPrepare.Items.AddRange(items.ToArray());
            intWh = int.Parse(ddlWHPrepare.SelectedValue);
            dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, Enroll);//get Currency Name
            try { txtDestinationDelivery.Text = dt.Rows[0]["whaddress"].ToString(); } catch { }

            ddlCurrency.DataSource = dt;
            ddlCurrency.DataTextField = "strName";
            ddlCurrency.DataValueField = "Id";
            ddlCurrency.DataBind();

            dt = objPo.GetPoData(7, "", intWh, int.Parse(hdnUnitId.Value), DateTime.Now, Enroll);// Pay Date
            ddlDtePay.DataSource = dt;
            ddlDtePay.DataTextField = "strName";
            ddlDtePay.DataValueField = "dteDate";
            ddlDtePay.DataBind();

            dt = objPo.GetPoData(8, "", intWh, int.Parse(hdnUnitId.Value), DateTime.Now, Enroll);// Get Costcenter
            ddlCostCenter.DataSource = dt;
            ddlCostCenter.DataTextField = "strName";
            ddlCostCenter.DataValueField = "Id";
            ddlCostCenter.DataBind();
        }
        private void DefaltPageLoad()
        {
            
        }
        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, "", HttpContext.Current.Session["unitId"].ToString());
        }

        #endregion====================Close===============================
        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string strSupp = "";
                int supplierid = 0;
                if (arrayKey.Length > 0)
                {
                    strSupp = arrayKey[0].ToString();
                    supplierid = int.Parse(arrayKey[1].ToString());
                }

                dt = objPo.GetPoData(22, "", 0, supplierid, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSuppAddress.Text = dt.Rows[0]["strName"].ToString();
                }
            }
            catch { }
        }

        protected void dgvIndentPrepare_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXmlPrepare();
                DataSet dsGrid = (DataSet)dgvIndentPrepare.DataSource;
                dsGrid.Tables[0].Rows[dgvIndentPrepare.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLPrepare);
                DataSet dsGridAfterDelete = (DataSet)dgvIndentPrepare.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLPrepare);
                    dgvIndentPrepare.DataSource = "";
                    dgvIndentPrepare.DataBind();
                }
                else {
                    LoadGridwithXmlPrepare();
                }
            }
            catch { }
        }
        private void LoadGridwithXmlPrepare()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLPrepare);
                XmlNode dSftTm = doc.SelectSingleNode("issue");
                xmlString = dSftTm.InnerXml;
                xmlString = "<issue>" + xmlString + "</issue>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvIndentPrepare.DataSource = ds; }
                else { dgvIndentPrepare.DataSource = ""; }
                dgvIndentPrepare.DataBind();
            }
            catch { }
        }
        protected void btnGeneratePO_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXMLPo); } catch { }
                try
                {
                    arrayKey = txtSupplier.Text.Split(delimiterChars);
                    string strSupp = ""; supplierId = 0;
                    if (arrayKey.Length > 0)
                    {
                        strSupp = arrayKey[0].ToString();
                        supplierId = int.Parse(arrayKey[1].ToString());
                    }
                }
                catch { supplierId = 0; }

                try { whid = int.Parse(ddlWHPrepare.SelectedValue); } catch { whid = 0; }
                try { unitid = int.Parse(hdnUnitId.Value); } catch { }

                try { currencyId = int.Parse(ddlCurrency.SelectedValue); } catch { currencyId = 0; }
                try { costId = int.Parse(ddlCostCenter.SelectedValue); } catch { }
                try { payDate = ddlDtePay.SelectedValue.ToString(); } catch { payDate = "0"; }
                try { dtePo = DateTime.Parse(txtdtePo.Text); } catch { dtePo = DateTime.Now; }
                try { others = decimal.Parse(txtOthers.Text); } catch { }
                try { tansport = decimal.Parse(txtTransport.Text); } catch { }
                try { grosDiscount = decimal.Parse(txtGrossDiscount.Text); } catch { }
                try { commision = decimal.Parse(txtCommosion.Text); } catch { commision = 0; }

                try { partialShipment = int.Parse(ddlPartialShip.SelectedValue); } catch { partialShipment = 0; }
                try { noOfShifment = int.Parse(txtNoOfShipment.Text); } catch { noOfShifment = 0; }
                try { afterMrrDay = int.Parse(txtAfterMrrDay.Text); } catch { afterMrrDay = 0; }
                try { paymentTrems = ddlPaymentTrams.SelectedItem.ToString(); } catch { }
                try { noOfInstallment = int.Parse(txtNoOfInstall.Text.ToString()); } catch { noOfInstallment = 0; }
                try { intervalInstallment = int.Parse(txtIntervel.Text.ToString()); } catch { intervalInstallment = 0; }
                try { noPayment = int.Parse(txtNoOfPayment.Text); } catch { noPayment = 0; }
                try { destDelivery = txtDestinationDelivery.Text.ToString(); } catch { destDelivery = ""; }
                try { paymentSchedule = txtPaymentSchedule.Text.ToString(); } catch { paymentSchedule = "0"; }
                try { dtelastShipment = DateTime.Parse(txtLastShipmentDate.Text); } catch { }
                othersTrems = txtOthersTerms.Text.ToString();
                warrentyperiod = txtWarrenty.Text.ToString();
                string strPoFor = "Import";//ddlDepts.SelectedItem.ToString();

                if (dgvIndentPrepare.Rows.Count > 0 && hdnPreConfirm.Value.ToString() == "1")
                {
                    for (int index = 0; index < dgvIndentPrepare.Rows.Count; index++)
                    {
                        string indentId = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblIndentId")).Text.ToString();
                        string itemId = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string strItem = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemName")).Text.ToString();
                        string strUom = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblUom")).Text.ToString();
                        string strDesc = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblDescription")).Text.ToString();
                        string numIndentQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblIndentQty")).Text.ToString();
                        string numPoQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblQty")).Text.ToString();
                        string monRate = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtRate")).Text.ToString();
                        string monVat = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtVAT")).Text.ToString();
                        string monAIT = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtAIT")).Text.ToString();
                        string monTotal = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblTotalVal")).Text.ToString();

                        //*********For Devlopment Requirment Change********************

                        // string strHsCode = ((Label)dgvIndentDet.Rows[index].FindControl("lblHsCode")).Text.ToString();
                        // string numCurStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblCurrentStock")).Text.ToString();
                        // string numSafetyStock = ((Label)dgvIndentDet.Rows[index].FindControl("lblSaftyStock")).Text.ToString();
                        // string numPoIssued = ((Label)dgvIndentDet.Rows[index].FindControl("lblPoIssue")).Text.ToString();
                        // string numRemain = ((Label)dgvIndentDet.Rows[index].FindControl("lblRemaining")).Text.ToString();
                        //  string strSpecification = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblSpecification")).Text.ToString();
                        //  string monPreviousRate = ((Label)dgvIndentDet.Rows[index].FindControl("lblPreviousAvg")).Text.ToString();

                        if (decimal.Parse(monRate) > 0 && int.Parse(itemId) > 0 && supplierId > 0)
                        {
                            CreateXmlPO(indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal,
                            whid.ToString(), unitid.ToString(), supplierId.ToString(), currencyId.ToString(), costId.ToString(), payDate.ToString(), dtePo.ToString(), others.ToString(), tansport.ToString(), grosDiscount.ToString(), commision.ToString(), partialShipment.ToString(), noOfShifment.ToString(),
                            afterMrrDay.ToString(), paymentTrems.ToString(), noOfInstallment.ToString(), intervalInstallment.ToString(), noPayment.ToString(), destDelivery.ToString(), paymentSchedule.ToString(), dtelastShipment.ToString(), othersTrems, warrentyperiod, numIndentQty, strPoFor);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input valid rate');", true);
                            try { File.Delete(filePathForXMLPo); } catch { }
                            break;
                        }
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLPo);
                    XmlNode dSftTm = doc.SelectSingleNode("issue");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<issue>" + xmlString + "</issue>";

                    try { File.Delete(filePathForXMLPrepare); } catch { }
                    try { File.Delete(filePathForXMLPo); } catch { }

                    string msg = "";
                    //string msg = objPo.PoApprove(9, xmlString, whid, 0, DateTime.Now, Enroll);
                    string[] searchKey = Regex.Split(msg, ":");
                    lblPoNo.Text = "Po Number: " + searchKey[1].ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    //txtIndentNoDet.Enabled = false;
                    txtGrossDiscount.Text = "0"; txtOthers.Text = "0"; txtTransport.Text = "0"; txtAit.Text = "0";
                    txtSupplier.Text = "";
                    //txtIndentNoDet.Text = "";
                    //txtIndentNo.Text = "";
                    if (searchKey[1].ToString().Length > 2)
                    {

                        dgvIndentPrepare.DataSource = "";
                        dgvIndentPrepare.DataBind();
                      
                    }
                }
            }
            catch { }
        }
        private void CreateXmlPO(string indentId, string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment, string othersTrems, string warrentyperiod, string numIndentQty, string strPoFor)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXMLPo))
            {
                doc.Load(filePathForXMLPo);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNodePo(doc, indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, numIndentQty, strPoFor);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNodePo(doc, indentId, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, numIndentQty, strPoFor);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLPo);
        }

        private XmlNode CreateItemNodePo(XmlDocument doc, string indentId, string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment, string othersTrems, string warrentyperiod, string numIndentQty, string strPoFor)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute IndentId = doc.CreateAttribute("indentId");
            IndentId.Value = indentId;
            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute StrItem = doc.CreateAttribute("strItem");
            StrItem.Value = strItem;
            XmlAttribute StrUom = doc.CreateAttribute("strUom");
            StrUom.Value = strUom;

            XmlAttribute StrDesc = doc.CreateAttribute("strDesc");
            StrDesc.Value = strDesc;
            XmlAttribute NumPoQty = doc.CreateAttribute("numPoQty");
            NumPoQty.Value = numPoQty;
            XmlAttribute MonRate = doc.CreateAttribute("monRate");
            MonRate.Value = monRate;
            XmlAttribute MonVat = doc.CreateAttribute("monVat");
            MonVat.Value = monVat;
            XmlAttribute MonAIT = doc.CreateAttribute("monAIT");
            MonAIT.Value = monAIT;
            XmlAttribute MonTotal = doc.CreateAttribute("monTotal");
            MonTotal.Value = monTotal;
            XmlAttribute Whid = doc.CreateAttribute("whid");
            Whid.Value = whid;
            XmlAttribute Unitid = doc.CreateAttribute("unitid");
            Unitid.Value = unitid;
            XmlAttribute SupplierId = doc.CreateAttribute("supplierId");
            SupplierId.Value = supplierId;
            XmlAttribute CurrencyId = doc.CreateAttribute("currencyId");
            CurrencyId.Value = currencyId;
            XmlAttribute CostId = doc.CreateAttribute("costId");
            CostId.Value = costId;
            XmlAttribute PayDate = doc.CreateAttribute("payDate");
            PayDate.Value = payDate;

            XmlAttribute DtePo = doc.CreateAttribute("dtePo");
            DtePo.Value = dtePo;
            XmlAttribute Others = doc.CreateAttribute("others");
            Others.Value = others;
            XmlAttribute Tansport = doc.CreateAttribute("tansport");
            Tansport.Value = tansport;
            XmlAttribute GrosDiscount = doc.CreateAttribute("grosDiscount");
            GrosDiscount.Value = grosDiscount;
            XmlAttribute Commision = doc.CreateAttribute("commision");
            Commision.Value = commision;
            XmlAttribute PartialShipment = doc.CreateAttribute("partialShipment");
            PartialShipment.Value = partialShipment;
            XmlAttribute NoOfShifment = doc.CreateAttribute("noOfShifment");
            NoOfShifment.Value = noOfShifment;
            XmlAttribute AfterMrrDay = doc.CreateAttribute("afterMrrDay");
            AfterMrrDay.Value = afterMrrDay;
            XmlAttribute PaymentTrems = doc.CreateAttribute("paymentTrems");
            PaymentTrems.Value = paymentTrems;
            XmlAttribute NoOfInstallment = doc.CreateAttribute("noOfInstallment");
            NoOfInstallment.Value = noOfInstallment;
            XmlAttribute IntervalInstallment = doc.CreateAttribute("intervalInstallment");
            IntervalInstallment.Value = intervalInstallment;
            XmlAttribute NoPayment = doc.CreateAttribute("noPayment");
            NoPayment.Value = noPayment;
            XmlAttribute DestDelivery = doc.CreateAttribute("destDelivery");
            DestDelivery.Value = destDelivery;
            XmlAttribute PaymentSchedule = doc.CreateAttribute("paymentSchedule");
            PaymentSchedule.Value = paymentSchedule;
            XmlAttribute DtelastShipment = doc.CreateAttribute("dtelastShipment");
            DtelastShipment.Value = dtelastShipment;

            XmlAttribute OthersTrems = doc.CreateAttribute("othersTrems");
            OthersTrems.Value = othersTrems;
            XmlAttribute Warrentyperiod = doc.CreateAttribute("warrentyperiod");
            Warrentyperiod.Value = warrentyperiod;

            XmlAttribute NumIndentQty = doc.CreateAttribute("numIndentQty");
            NumIndentQty.Value = numIndentQty;

            XmlAttribute StrPoFor = doc.CreateAttribute("strPoFor");
            StrPoFor.Value = strPoFor;

            node.Attributes.Append(IndentId);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(StrItem);
            node.Attributes.Append(StrUom);

            node.Attributes.Append(StrDesc);
            node.Attributes.Append(NumPoQty);
            node.Attributes.Append(MonRate);
            node.Attributes.Append(MonVat);
            node.Attributes.Append(MonAIT);
            node.Attributes.Append(MonTotal);

            node.Attributes.Append(Whid);
            node.Attributes.Append(Unitid);
            node.Attributes.Append(SupplierId);
            node.Attributes.Append(CurrencyId);
            node.Attributes.Append(CostId);

            node.Attributes.Append(PayDate);
            node.Attributes.Append(DtePo);
            node.Attributes.Append(Others);
            node.Attributes.Append(Tansport);
            node.Attributes.Append(GrosDiscount);

            node.Attributes.Append(Commision);
            node.Attributes.Append(PartialShipment);
            node.Attributes.Append(NoOfShifment);
            node.Attributes.Append(AfterMrrDay);
            node.Attributes.Append(PaymentTrems);

            node.Attributes.Append(NoOfInstallment);
            node.Attributes.Append(IntervalInstallment);
            node.Attributes.Append(NoPayment);
            node.Attributes.Append(DestDelivery);
            node.Attributes.Append(PaymentSchedule);

            node.Attributes.Append(DtelastShipment);

            node.Attributes.Append(OthersTrems);
            node.Attributes.Append(Warrentyperiod);
            node.Attributes.Append(NumIndentQty);
            node.Attributes.Append(StrPoFor);
            return node;
        }


















    }
}