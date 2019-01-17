using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoWithoutIndent : BasePage
    {
        private DataTable dt = new DataTable();
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private int enroll, intWh;
        private string filePathForXML, filePathForXMLPo, othersTrems, warrentyperiod; private string xmlString = ""; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private int indentNo, whid, unitid, supplierId, currencyId, costId, partialShipment, noOfShifment, afterMrrDay, noOfInstallment, intervalInstallment, noPayment, CheckItem; private string payDate, paymentTrems, destDelivery, paymentSchedule;

        private DateTime dtePo, dtelastShipment; private decimal others = 0, tansport = 0, grosDiscount = 0, commision, ait;

        

        private decimal poQty, numPoRate;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\PoWithoutIndent";
        private string stop = "stopping SCM\\PoWithoutIndent";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/In__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLPo = Server.MapPath("~/SCM/Data/Po__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!IsPostBack)
                {
                    try { File.Delete(filePathForXML); } catch { }
                    try { File.Delete(filePathForXMLPo); } catch { }
                    DefaltDataBound();
                }
                else
                { }
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


        protected void ddlDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { File.Delete(filePathForXML); } catch { }
            dgvIndentPrepare.DataSource = "";
            dgvIndentPrepare.DataBind();
            txtSupplier.Text = "";
            txtItem.Text = "";
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchSupplier(prefixText, "", HttpContext.Current.Session["untid"].ToString());
        }

        #endregion====================Close===============================
        #region==============PO Generate TAB-3 =============================

        protected void btnGeneratePO_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIndentPrepare.Rows.Count > 0 && hdnPreConfirm.Value.ToString() == "1")
                {
                    try { File.Delete(filePathForXML); } catch { }
                    try { whid = int.Parse(ddlWHPrepare.SelectedValue); } catch { }
                    try { unitid = int.Parse(hdnUnit.Value); } catch { }
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
                    string strPoFor = ddlDepts.SelectedItem.ToString();

                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    for (int index = 0; index < dgvIndentPrepare.Rows.Count; index++)
                    {
                        string itemId = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string strItem = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblItemName")).Text.ToString();
                        string strUom = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblUom")).Text.ToString();

                        string strDesc = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblDescription")).Text.ToString();
                        //  string numIndentQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblIndentQty")).Text.ToString();
                        string numPoQty = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblQty")).Text.ToString();
                        string monRate = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtRate")).Text.ToString();
                        string monVat = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtVAT")).Text.ToString();
                        string monAIT = ((TextBox)dgvIndentPrepare.Rows[index].FindControl("txtAIT")).Text.ToString();
                        string monTotal = ((Label)dgvIndentPrepare.Rows[index].FindControl("lblTotalVal")).Text.ToString();

                        if (decimal.Parse(monRate) > 0 && supplierId > 0)
                        {
                            CreateXmlPO(itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal,
                            whid.ToString(), unitid.ToString(), supplierId.ToString(), currencyId.ToString(), costId.ToString(), payDate.ToString(), dtePo.ToString(), others.ToString(), tansport.ToString(), grosDiscount.ToString(), commision.ToString(), partialShipment.ToString(), noOfShifment.ToString(),
                            afterMrrDay.ToString(), paymentTrems.ToString(), noOfInstallment.ToString(), intervalInstallment.ToString(), noPayment.ToString(), destDelivery.ToString(), paymentSchedule.ToString(), dtelastShipment.ToString(), othersTrems, warrentyperiod, strPoFor);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input valid rate');", true);
                            try { File.Delete(filePathForXML); } catch { }
                            break;
                        }
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLPo);
                    XmlNode dSftTm = doc.SelectSingleNode("issue");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<issue>" + xmlString + "</issue>";
                    try { File.Delete(filePathForXMLPo); } catch { }
                    dgvIndentPrepare.DataSource = "";
                    dgvIndentPrepare.DataBind();

                    string msg = objPo.PoApprove(9, xmlString, whid, 0, DateTime.Now, enroll);
                    string[] searchKey = Regex.Split(msg, ":");
                    lblPO.Text = "Po Number: " + searchKey[1].ToString();
                    if (msg.Length > 4)
                    {
                        try { File.Delete(filePathForXML); } catch { }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }
                   
                }
            }
            catch { }
        }

        private void CreateXmlPO(string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment, string othersTrems, string warrentyperiod, string strPoFor)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXMLPo))
            {
                doc.Load(filePathForXMLPo);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNodePo(doc, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, strPoFor);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNodePo(doc, itemId, strItem, strUom, strDesc, numPoQty, monRate, monVat, monAIT, monTotal, whid, unitid, supplierId, currencyId, costId, payDate,
                                dtePo, others, tansport, grosDiscount, commision, partialShipment, noOfShifment, afterMrrDay, paymentTrems, noOfInstallment, intervalInstallment,
                                noPayment, destDelivery, paymentSchedule, dtelastShipment, othersTrems, warrentyperiod, strPoFor);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLPo);
        }

        private XmlNode CreateItemNodePo(XmlDocument doc, string itemId, string strItem, string strUom, string strDesc, string numPoQty, string monRate, string monVat, string monAIT, string monTotal, string whid, string unitid, string supplierId, string currencyId, string costId, string payDate, string dtePo, string others, string tansport, string grosDiscount, string commision, string partialShipment, string noOfShifment, string afterMrrDay, string paymentTrems, string noOfInstallment, string intervalInstallment, string noPayment, string destDelivery, string paymentSchedule, string dtelastShipment, string othersTrems, string warrentyperiod, string strPoFor)
        {
            XmlNode node = doc.CreateElement("issueEntry");

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

            XmlAttribute StrPoFor = doc.CreateAttribute("strPoFor");
            StrPoFor.Value = strPoFor;

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
            node.Attributes.Append(StrPoFor);

            return node;
        }

        #endregion============Close======================================

        protected void btnViewPO_Click(object sender, EventArgs e)
        {
            if (txtPONo.Text.Length > 2)
            {
                Session["pono"] = txtPONo.Text.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PoDetalisView.aspx');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This is not a PO.');", true);
                return;
            }
        }

        protected void ddlWHPrepare_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWh = int.Parse(ddlWHPrepare.SelectedValue.ToString());
                
                dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, enroll);//get Currency Name
                ddlCurrency.DataSource = dt;
                ddlCurrency.DataTextField = "strName";
                ddlCurrency.DataValueField = "Id";
                ddlCurrency.DataBind();
                try { txtDestinationDelivery.Text = dt.Rows[0]["whaddress"].ToString(); } catch { }

                dt = objPo.GetUnitID(intWh);
                if (dt.Rows.Count > 0)
                {
                     
                    hdnUnit.Value = dt.Rows[0]["intUnitId"].ToString();
                    Session["untid"] = hdnUnit.Value.ToString();
                }
                else { Session["untid"] = "0"; }

                try { File.Delete(filePathForXML); } catch { }
                dgvIndentPrepare.DataSource = "";
                dgvIndentPrepare.DataBind();
                txtSupplier.Text = "";
                txtItem.Text = "";

                // dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, enroll);//get Currency Name
            }
            catch { Session["untid"] = "0"; }
        }

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtSupplier.Text.Split(delimiterChars);
                string strSupp = ""; int supplierid = 0;
                if (arrayKey.Length > 0)
                { strSupp = arrayKey[0].ToString(); supplierid = int.Parse(arrayKey[1].ToString()); }

                dt = objPo.GetPoData(22, "", 0, supplierid, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    lblSuppAddress.Text = dt.Rows[0]["strName"].ToString();
                }
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetPoItemSerach(string prefixText, int count)
        {
            PoGenerate_BLL objs = new PoGenerate_BLL();
            return objs.AutoSearchServiceItem(HttpContext.Current.Session["untid"].ToString(), prefixText);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = "";
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                string stringXml = "<voucher><voucherentry itemid=" + '"' + itemid + '"' + "/></voucher>".ToString();
                int CheckDuplicate = checkXmlItemData(itemid);
                try { poQty = decimal.Parse(txtQantity.Text.ToString()); } catch { }
                try { numPoRate = decimal.Parse(txtRate.Text.ToString()); } catch { }
                if (CheckDuplicate == 1 && poQty > 0 && numPoRate > 0 && itemid.Length > 3)
                {
                    dt = objPo.GetPoData(23, stringXml, intWh, int.Parse(itemid), DateTime.Now, enroll);// Indent Detalis

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string itemId = dt.Rows[i]["intItemID"].ToString();
                        string strItem = dt.Rows[i]["strName"].ToString();
                        string strUom = dt.Rows[i]["strUom"].ToString();
                        string strDesc = txtDescription.Text.ToString();

                        CreateXml(itemId, strItem, strUom, strDesc, poQty.ToString(), numPoRate.ToString());
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
            }
            catch { }
        }

        private void CreateXml(string itemId, string strItem, string strUom, string strDesc, string poQty, string numPoRate)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, strItem, strUom, strDesc, poQty, numPoRate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNode(doc, itemId, strItem, strUom, strDesc, poQty, numPoRate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string strItem, string strUom, string strDesc, string poQty, string numPoRate)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute StrItem = doc.CreateAttribute("strItem");
            StrItem.Value = strItem;
            XmlAttribute StrUom = doc.CreateAttribute("strUom");
            StrUom.Value = strUom;
            XmlAttribute StrDesc = doc.CreateAttribute("strDesc");
            StrDesc.Value = strDesc;
            XmlAttribute PoQty = doc.CreateAttribute("poQty");
            PoQty.Value = poQty;
            XmlAttribute NumPoRate = doc.CreateAttribute("numPoRate");
            NumPoRate.Value = numPoRate;

            node.Attributes.Append(ItemId);
            node.Attributes.Append(StrItem);
            node.Attributes.Append(StrUom);
            node.Attributes.Append(StrDesc);

            node.Attributes.Append(PoQty);
            node.Attributes.Append(StrDesc);
            node.Attributes.Append(NumPoRate);

            return node;
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
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

        private int checkXmlItemData(string itemid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                    {
                        CheckItem = 0;

                        break;
                    }
                    else
                    {
                        CheckItem = 1;
                    }
                }
                return CheckItem;
            }
            catch { CheckItem = 1; return CheckItem; }
        }

        protected void dgvIndentPrepare_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvIndentPrepare.DataSource;
                dsGrid.Tables[0].Rows[dgvIndentPrepare.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvIndentPrepare.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvIndentPrepare.DataSource = ""; dgvIndentPrepare.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        private void DefaltDataBound()
        {
            try
            {
                enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objPo.GetPoData(1, "", 0, 0, DateTime.Now, enroll);
                ddlWHPrepare.DataSource = dt;
                ddlWHPrepare.DataTextField = "strName";
                ddlWHPrepare.DataValueField = "Id";
                ddlWHPrepare.DataBind();
                dt = objPo.GetUnitID(int.Parse(ddlWHPrepare.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intUnitId"].ToString();
                    Session["untid"] = hdnUnit.Value.ToString();
                }
              

                dt.Clear();
                intWh = int.Parse(ddlWHPrepare.SelectedValue);
                dt = objPo.GetPoData(21, "", 0, 0, DateTime.Now, enroll);
                ddlDepts.DataSource = dt;
                ddlDepts.DataTextField = "strName";
                ddlDepts.DataValueField = "Id";
                ddlDepts.DataBind();
                dt.Clear();

                dt = objPo.GetPoData(5, "", intWh, 0, DateTime.Now, enroll);//get Currency Name
                ddlCurrency.DataSource = dt;
                ddlCurrency.DataTextField = "strName";
                ddlCurrency.DataValueField = "Id";
                ddlCurrency.DataBind();
                try { txtDestinationDelivery.Text = dt.Rows[0]["whaddress"].ToString(); } catch { }

                dt = objPo.GetPoData(7, "", intWh, 0, DateTime.Now, enroll);// Pay Date
                ddlDtePay.DataSource = dt;
                ddlDtePay.DataTextField = "strName";
                ddlDtePay.DataValueField = "dteDate";
                ddlDtePay.DataBind();

                dt = objPo.GetPoData(8, "", intWh, 0, DateTime.Now, enroll);// Get Costcenter
                ddlCostCenter.DataSource = dt;
                ddlCostCenter.DataTextField = "strName";
                ddlCostCenter.DataValueField = "Id";
                ddlCostCenter.DataBind();
            }
            catch { Session["untid"] ="0".ToString(); }
        }
    }
}