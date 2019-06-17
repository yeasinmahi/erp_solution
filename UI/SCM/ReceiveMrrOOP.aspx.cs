using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BLL.AFBLSMSServer;
using BLL.HR;
using Model;
using SCM_DAL.MrrReceiveTDSTableAdapters;
using UI.ClassFiles;
using Utility;
using SupplierBll = BLL.Inventory.SupplierBll;

namespace UI.SCM
{
    public partial class ReceiveMrrOop : BasePage
    {
        #region INIT
        private readonly MrrReceive_BLL _obj = new MrrReceive_BLL();
        private readonly object _locker = new object();
        private DataTable _dt = new DataTable();
        private string xmlString = "", filePathForXML, strMssingCost, challanNo, strVatChallan, poIssueBy, expireDate, manufactureDate;
        private int intPo, intShipment, intPOID, intSupplierID, intUnitID, intShipmentID, ysnInventory;
        private decimal monConverRate, monVatAmount, monProductCost, monOther, monDiscount, monBDTConversion, monRate, monTransport, monOtherTotal;
        private DateTime dteChallan;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Mr__" + Enroll + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                    // ignored
                }
                ddlInvoice.Enabled = false;
                DefaultBind();
            }
        }
        #endregion

        #region Event
        protected void ddlPoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPo();
                DataClear();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            txtPO.Text = "";
        }
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string poType = ddlPoType.SelectedItem.ToString();
                xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>";
                _dt = _obj.DataView(3, xmlString, ddlWH.SelectedValue(), 0, DateTime.Now, Enroll);
                ddlPo.DataSource = _dt;
                ddlPo.DataTextField = "strName";
                ddlPo.DataValueField = "Id";
                ddlPo.DataBind();
                DataClear();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            txtPO.Text = "";
        }
        protected void Mrr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)e.Row;
            HiddenField hfLocationID = (HiddenField)gvRow.FindControl("hdnPreviLocationId");
            if (hfLocationID != null)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlLocation = (DropDownList)gvRow.FindControl("ddlStoreLocation");
                    ddlLocation.SelectedValue = hfLocationID.Value;
                }
            }
        }
        protected void btnSaveMrr_Click(object sender, EventArgs e)
        {
            lock (_locker)
            {

                try
                {
                    try
                    {

                        File.Delete(filePathForXML);

                    }
                    catch
                    {
                    }

                    string i = hfConfirm.Value;
                    if ((dgvMrr.Rows.Count > 0 && hdnConfirm.Value == "1") || (dgvMrr.Rows.Count > 0 && hfConfirm.Value == "1"))
                    {
                        //  try { intPOID = int.Parse(ddlPo.SelectedValue); } catch { }
                        try { intSupplierID = int.Parse(lblSuppliuerID.Text); } catch { }
                        try { intShipment = int.Parse(hdnShipment.Value); } catch { }
                        try { dteChallan = DateTime.Parse(txtdteChallan.Text); } catch { }
                        try { monVatAmount = decimal.Parse(txtVatAmount.Text); } catch { }
                        try { challanNo = txtChallan.Text; } catch { }
                        try { strVatChallan = txtVatChallan.Text; } catch { }
                        try { monProductCost = decimal.Parse(lblProductCost.Text); } catch { }
                        try { monTransport = decimal.Parse(lblTransportCost.Text); } catch { monTransport = 0; }
                        try { monOther = decimal.Parse(lblOtherCost.Text); } catch { monOther = 0; }
                        try { monDiscount = decimal.Parse(lblDiscount.Text); } catch { }
                        try { monBDTConversion = decimal.Parse(hdnConversion.Value); } catch { }
                        try
                        {
                            intShipmentID = !string.IsNullOrEmpty(ddlInvoice.SelectedItem.ToString()) ? Convert.ToInt32(ddlInvoice.SelectedValue) : 0;
                        }
                        catch
                        {
                        }
                        if (!string.IsNullOrEmpty(hfImportMissingCost.Value))
                        {
                            ysnInventory = 0;
                        }
                        else
                        {
                            ysnInventory = 1;
                        }

                        poIssueBy = lblPoIssueBy.Text;
                        monOtherTotal = monOther + monTransport;
                        for (int index = 0; index < dgvMrr.Rows.Count; index++)
                        {
                            intPOID = int.Parse(((Label)dgvMrr.Rows[index].FindControl("lblPoId")).Text);
                            string intItemID = ((Label)dgvMrr.Rows[index].FindControl("lblItemId")).Text;
                            string numPOQty = ((Label)dgvMrr.Rows[index].FindControl("lblPoQty")).Text;
                            string numPreRcvQty = ((Label)dgvMrr.Rows[index].FindControl("lblPreviousReceive")).Text;
                            string numRcvQty = ((TextBox)dgvMrr.Rows[index].FindControl("txtReceiveQty")).Text;
                            try { monRate = decimal.Parse(((Label)dgvMrr.Rows[index].FindControl("lblRate")).Text); } catch { monRate = 0; }
                            string numRcvValue = (decimal.Parse(numPOQty) * monRate).ToString();//((Label)dgvMrr.Rows[index].FindControl("lblMrrValue")).Text.ToString();
                            string numRcvVatValue = ((Label)dgvMrr.Rows[index].FindControl("lblVat")).Text;
                            string location = ((DropDownList)dgvMrr.Rows[index].FindControl("ddlStoreLocation")).SelectedValue;
                            string remarks = ((TextBox)dgvMrr.Rows[index].FindControl("txtRemarks")).Text;
                            string ysnQc = ((Label)dgvMrr.Rows[index].FindControl("lblYsnQc")).Text;
                            string numQcQty = ((Label)dgvMrr.Rows[index].FindControl("lblQcPassedQty")).Text;
                            string batchNo = ((TextBox)dgvMrr.Rows[index].FindControl("txtBatchNo")).Text;
                            try { DateTime dteExp = DateTime.Parse((((TextBox)dgvMrr.Rows[index].FindControl("txtExpireDate")).Text)); expireDate = dteExp.ToString(); } catch { expireDate = null; }
                            try { DateTime dteManuf = DateTime.Parse((((TextBox)dgvMrr.Rows[index].FindControl("txtManufacturingDate")).Text)); manufactureDate = dteManuf.ToString(); } catch { manufactureDate = null; }

                            if (decimal.TryParse(numRcvQty, out decimal receiveQuantity))
                            {
                                if (receiveQuantity <= 0)
                                {
                                    continue;
                                }
                                if (int.TryParse(location, out int _))
                                {
                                    if (monRate > 0)
                                    {
                                        CreateXml(intPOID.ToString(), intSupplierID.ToString(), intShipment.ToString(),
                                            dteChallan.ToString(), monVatAmount.ToString(), challanNo, strVatChallan,
                                            monProductCost.ToString(), monOtherTotal.ToString(), monDiscount.ToString(),
                                            monBDTConversion.ToString(), intItemID, numPOQty, numPreRcvQty, numRcvQty,
                                            numRcvValue, numRcvVatValue, location, remarks, monRate.ToString(), poIssueBy,
                                            batchNo, expireDate, manufactureDate, ysnInventory, intShipmentID);
                                    }
                                    else
                                    {
                                        Toaster("Rate can not load", Common.TosterType.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    Toaster("Current location should be selected", Common.TosterType.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                Toaster("Input Receive Quantity Properly", Common.TosterType.Warning);
                                return;
                            }
                        }
                        txtChallan.Text = "";
                        txtVatAmount.Text = "0";

                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("mrr");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<mrr>" + xmlString + "</mrr>";

                        try { File.Delete(filePathForXML); } catch { }
                        dgvMrr.UnLoad();


                        string msg = _obj.MrrReceive(11, xmlString, ddlWH.SelectedValue(), intPOID, DateTime.Now, Enroll);

                        FactoryReceiveMrr factoryReceiveMrr = new FactoryReceiveMrr()
                        {
                            PoId = intPOID,
                            SupplierId = intSupplierID,
                            ShipmentSl = intShipment,
                            ChallanDate = dteChallan,
                            TotalVat = monVatAmount,
                            VatChallan = challanNo,

                            //ExternalRef = dteChallan,
                            //IsInventoryInserted = 0,
                            //ShipmentId = 0,

                            //WhId = 1,



                            //LastActionBy = 0,
                            //TotalAit = 0,

                            //UnitId = 0,
                            //MrrCode = 0,
                            //MrrId = 0,
                            //PvAmount = 0,
                        };
                        FactoryReceiveMRRItemDetail factoryReceiveMrrItemDetail = new FactoryReceiveMRRItemDetail()
                        {

                            //PoId = 0,
                            //MrrId = 0,
                            //AitAmount = 0,
                            //BdtTotal = 0,
                            //FcRate = 0,
                            //FcTotal = 0,
                            //ItemId = 0,
                            //LocationId = 0,
                            //PoQuantity = 0,
                            //ReceiveQuantity = 0,
                            //ReceiveRemarks = 0,
                            //VatAmount = 0
                        };

                        if (msg.ToLower().Contains("success"))
                        {
                            string message = msg;
                            string[] searchKey = Regex.Split(msg, ":");
                            lblMrrNo.Text = searchKey[1];
                            int whId = ddlWH.SelectedValue();
                            UnitBll unitBll = new UnitBll();
                            string unitName = unitBll.GetUnitFullNameByWhId(whId);
                            intUnitID = unitBll.GetUnitIdByWhId(whId);
                            if (!string.IsNullOrWhiteSpace(unitName))
                            {
                                string supplierContact = new SupplierBll().GetSupplierPhone(intSupplierID);
                                ApiSmsBll smsBll = new ApiSmsBll();
                                smsBll.InsertApiSms(intPOID, challanNo, unitName, supplierContact, intUnitID);
                            }


                            #region====================Mrr Document Attachment===========================

                            try
                            {
                                string fileExtension = Path.GetExtension(docUpload.PostedFile.FileName).Substring(1);
                                string xmlData = "<voucher><voucherentry strFileName=" + '"' + "MRR Challan" + '"' +
                                                 " FileExtension=" + '"' + fileExtension + '"' + "/></voucher>";

                                if (fileExtension.Length > 1)
                                {
                                    msg = _obj.MrrReceive(15, xmlData, ddlWH.SelectedValue(), int.Parse(lblMrrNo.Text),
                                        DateTime.Now,
                                        Enroll);
                                    if (msg.ToLower().Contains("success"))
                                    {
                                        string[] searchKeyAt = Regex.Split(msg, ":");
                                        string fileId = searchKeyAt[1];

                                        string dfile = fileId + "." + fileExtension;
                                        docUpload.PostedFile.SaveAs(Server.MapPath("~/SCM/Uploads/") + dfile);
                                        FileUploadFTP(Server.MapPath("~/SCM/Uploads/"), dfile,
                                            "ftp://ftp.akij.net/ERP_FTP/", "erp@akij.net", "erp123");
                                        File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile);
                                        Toaster(message, Common.TosterType.Success);
                                    }
                                    else
                                    {
                                        Toaster(msg, Common.TosterType.Error);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                Toaster(ex.Message, Common.TosterType.Error);
                            }
                        }
                        else
                        {
                            string message = msg;
                            string[] searchKey = Regex.Split(msg, ":");
                            lblMrrNo.Text = searchKey[1].ToString();
                            Toaster(msg, Common.TosterType.Error);
                        }

                        #endregion===================Close============================================

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        //PoView(intPOID);
                    }
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }

            }
        }
        protected void ddlPo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataClear();
                string poType = ddlPoType.SelectedItem.ToString();
                intPo = int.Parse(ddlPo.SelectedValue);

                if (poType == "Local")
                {
                    ddlInvoice.Enabled = false;
                    ddlInvoice.DataSource = "";
                    ddlInvoice.DataBind();
                }
                else if (poType == "Import")
                {
                    ddlInvoice.Enabled = true;
                    _dt = _obj.DataView(5, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                    if (_dt.Rows.Count > 0)
                    {
                        ddlInvoice.DataSource = _dt;
                        ddlInvoice.DataTextField = "strName";
                        ddlInvoice.DataValueField = "Id";
                        ddlInvoice.DataBind();
                    }
                    else
                    {
                        Toaster("Shipment has not yet been created", Common.TosterType.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            txtPO.Text = "";
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            dgvMrr.DataSource = _dt;
            dgvMrr.DataBind();
            lblSuppliuerID.Text = "";
            lblSuppliyer.Text = "";
            int intpoo = 0;
            int intShipmentID = 0;

            if (txtPO.Text.Length > 3)
            {
                intPo = int.Parse(txtPO.Text);
                _dt = _obj.GetWhByEnrollAndPo(Enroll, intPo);
                if (_dt.Rows.Count > 0)
                {
                    _dt = _obj.GetPoCompleteStatus(intPo);
                    if (_dt.Rows.Count > 0)
                    {
                        bool isComplete = Convert.ToBoolean(_dt.Rows[0]["ysnComplete"].ToString());
                        if (isComplete)
                        {
                            //po complete
                            Toaster("All Items of this PO has already been received.", Common.TosterType.Warning);
                            return;
                        }
                        _dt = _obj.GetWhbyPo(intPo);
                        if (_dt.Rows.Count > 0)
                        {
                            int intWh = int.Parse(_dt.Rows[0]["intWHID"].ToString());
                            ddlWH.SelectedValue = intWh.ToString();
                            if (_dt.Rows[0]["strPoFor"].ToString() == "Local")
                            {
                                ddlPoType.SelectedValue = "1";
                                ddlInvoice.Enabled = false;
                                ddlInvoice.DataSource = "";
                                ddlInvoice.DataBind();
                            }
                            else if (_dt.Rows[0]["strPoFor"].ToString() == "Import")
                            {
                                ddlPoType.SelectedValue = "2";

                                ddlInvoice.Enabled = true;
                                _dt = _obj.DataView(5, xmlString, intWh, intPo, DateTime.Now, Enroll);
                                if (_dt.Rows.Count > 0)
                                {
                                    ddlInvoice.DataSource = _dt;
                                    ddlInvoice.DataTextField = "strName";
                                    ddlInvoice.DataValueField = "Id";
                                    ddlInvoice.DataBind();
                                }
                                else
                                {
                                    Toaster("Shipment has not yet been created", Common.TosterType.Warning);
                                }

                            }

                            else if (_dt.Rows[0]["strPoFor"].ToString() == "Fabrication")
                            {
                                ddlPoType.SelectedValue = "3";
                            }
                            string poType = ddlPoType.SelectedItem.ToString();
                            xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>";
                            _dt = _obj.DataView(3, xmlString, intWh, 0, DateTime.Now, Enroll);
                            ddlPo.DataSource = _dt;
                            ddlPo.DataTextField = "strName";
                            ddlPo.DataValueField = "Id";
                            ddlPo.DataBind();
                            ddlPo.SelectedValue = intPo.ToString();

                            PoView(intPo);
                        }
                        else
                        {
                            ddlPo.DataSource = ""; ddlPo.DataBind(); ddlInvoice.DataSource = ""; ddlInvoice.DataBind();
                            intPo = 0;
                            Toaster("PO is not approve", Common.TosterType.Warning);
                        }
                    }
                    else
                    {
                        Toaster("PO not found", Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("You have not permission to see this PO", Common.TosterType.Warning);
                }
            }
            else
            {
                PoView(ddlPo.SelectedValue());

            }

            if (ddlPoType.SelectedValue == "2")
            {
                intpoo = !string.IsNullOrEmpty(ddlPo.SelectedItem.ToString()) ? Convert.ToInt32(ddlPo.SelectedValue) : 0;
                intShipmentID = !string.IsNullOrEmpty(ddlInvoice.SelectedItem.ToString()) ? Convert.ToInt32(ddlInvoice.SelectedValue) : 0;
                string sms = ImportMissingCost(intpoo, intShipmentID);
                hfImportMissingCost.Value = sms;
            }
        }
        protected void ddlInvoice_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            PoView(ddlPo.SelectedValue());
        }
        #endregion

        #region Method
        public void LoadPo()
        {
            hfddlPoType.Value = ddlPoType.SelectedValue.ToString();
            string poType = ddlPoType.SelectedItem.ToString();
            xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>";
            _dt = _obj.DataView(3, xmlString, ddlWH.SelectedValue(), 0, DateTime.Now, Enroll);
            ddlPo.Loads(_dt, "Id", "strName");

        }
        private void CreateXml(string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks, string monRate, string poIssueBy, string batchNo, string expireDate, string manufactureDate, int ysnInventory, int intShipmentID)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy, batchNo, expireDate, manufactureDate, ysnInventory, intShipmentID);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy, batchNo, expireDate, manufactureDate, ysnInventory, intShipmentID);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks, string monRate, string poIssueBy, string batchNo, string expireDate, string manufactureDate, int ysnInventory, int intShipmentId)
        {
            XmlNode node = doc.CreateElement("mrrEntry");

            XmlAttribute IntPOID = doc.CreateAttribute("intPOID");
            IntPOID.Value = intPOID;
            XmlAttribute IntSupplierID = doc.CreateAttribute("intSupplierID");
            IntSupplierID.Value = intSupplierID;
            XmlAttribute IntShipment = doc.CreateAttribute("intShipment");
            IntShipment.Value = intShipment;
            XmlAttribute DteChallan = doc.CreateAttribute("dteChallan");
            DteChallan.Value = dteChallan;
            XmlAttribute MonVatAmount = doc.CreateAttribute("monVatAmount");
            MonVatAmount.Value = monVatAmount;

            XmlAttribute ChallanNo = doc.CreateAttribute("challanNo");
            ChallanNo.Value = challanNo;
            XmlAttribute StrVatChallan = doc.CreateAttribute("strVatChallan");
            StrVatChallan.Value = strVatChallan;
            XmlAttribute MonProductCost = doc.CreateAttribute("monProductCost");
            MonProductCost.Value = monProductCost;
            XmlAttribute MonOther = doc.CreateAttribute("monOther");
            MonOther.Value = monOther;

            XmlAttribute MonDiscount = doc.CreateAttribute("monDiscount");
            MonDiscount.Value = monDiscount;
            XmlAttribute MonBDTConversion = doc.CreateAttribute("monBDTConversion");
            MonBDTConversion.Value = monBDTConversion;
            XmlAttribute IntItemID = doc.CreateAttribute("intItemID");
            IntItemID.Value = intItemID;
            XmlAttribute NumPOQty = doc.CreateAttribute("numPOQty");
            NumPOQty.Value = numPOQty;

            XmlAttribute NumPreRcvQty = doc.CreateAttribute("numPreRcvQty");
            NumPreRcvQty.Value = numPreRcvQty;
            XmlAttribute NumRcvQty = doc.CreateAttribute("numRcvQty");
            NumRcvQty.Value = numRcvQty;
            XmlAttribute NumRcvValue = doc.CreateAttribute("numRcvValue");
            NumRcvValue.Value = numRcvValue;
            XmlAttribute NumRcvVatValue = doc.CreateAttribute("numRcvVatValue");
            NumRcvVatValue.Value = numRcvVatValue;
            XmlAttribute Location = doc.CreateAttribute("location");
            Location.Value = location;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            XmlAttribute MonRate = doc.CreateAttribute("monRate");
            MonRate.Value = monRate;
            XmlAttribute PoIssueBy = doc.CreateAttribute("poIssueBy");
            PoIssueBy.Value = poIssueBy;

            XmlAttribute BatchNo = doc.CreateAttribute("batchNo");
            BatchNo.Value = batchNo;

            XmlAttribute ExpireDate = doc.CreateAttribute("expireDate");
            ExpireDate.Value = expireDate;
            XmlAttribute ManufactureDate = doc.CreateAttribute("manufactureDate");
            ManufactureDate.Value = manufactureDate;

            XmlAttribute YsnInventory = doc.CreateAttribute("ysnInventory");
            YsnInventory.Value = ysnInventory.ToString();

            XmlAttribute intShipmentID = doc.CreateAttribute("intShipmentId");
            intShipmentID.Value = intShipmentId.ToString();

            node.Attributes.Append(IntPOID);
            node.Attributes.Append(IntSupplierID);
            node.Attributes.Append(IntShipment);
            node.Attributes.Append(DteChallan);

            node.Attributes.Append(MonVatAmount);
            node.Attributes.Append(ChallanNo);
            node.Attributes.Append(StrVatChallan);
            node.Attributes.Append(MonProductCost);
            node.Attributes.Append(MonOther);
            node.Attributes.Append(MonDiscount);
            node.Attributes.Append(MonBDTConversion);

            node.Attributes.Append(IntItemID);
            node.Attributes.Append(NumPOQty);
            node.Attributes.Append(NumPreRcvQty);
            node.Attributes.Append(NumRcvQty);
            node.Attributes.Append(NumRcvValue);

            node.Attributes.Append(NumRcvVatValue);
            node.Attributes.Append(Location);
            node.Attributes.Append(Remarks);

            node.Attributes.Append(MonRate);
            node.Attributes.Append(PoIssueBy);

            node.Attributes.Append(BatchNo);
            node.Attributes.Append(ExpireDate);

            node.Attributes.Append(ManufactureDate);
            node.Attributes.Append(YsnInventory);
            node.Attributes.Append(intShipmentID);

            return node;
        }
        private void PoView(int intPo)
        {
            try
            {

                try { intShipment = int.Parse(ddlInvoice.SelectedValue); hdnShipment.Value = intShipment.ToString(); } catch { intShipment = 0; hdnShipment.Value = "0"; }
                xmlString = "<voucher><voucherentry intShipment=" + '"' + intShipment + '"' + "/></voucher>";
                if (ddlInvoice.Enabled == true)
                {
                    _dt = _obj.DataView(6, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                    strMssingCost = _dt.Rows[0]["strMissingCost"].ToString();

                    if (strMssingCost != "")
                    {
                        Toaster(_dt.Rows[0]["strMissingCost"].ToString(), Common.TosterType.Warning);
                    }
                    else
                    {
                        _dt = _obj.DataView(7, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                        lblSuppliuerID.Text = _dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + _dt.Rows[0]["strSupplierName"];
                        lblCurrency.Text = " Currency: " + _dt.Rows[0]["strCurrencyName"];

                        monConverRate = decimal.Parse(_dt.Rows[0]["monBDTConversion"].ToString());
                        lblConversion.Text = " Conversion: " + monConverRate;
                        hdnConversion.Value = monConverRate.ToString();
                        lblPoIssueBy.Text = _dt.Rows[0]["strEmployeeName"].ToString();

                        _dt = _obj.DataView(8, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                        lblPoTotal.Text = "";
                        lblProductCost.Text = Convert.ToString(decimal.Parse(_dt.Rows[0]["monTotal"].ToString()) * monConverRate);
                        lblTransportCost.Text = Convert.ToString(decimal.Parse(_dt.Rows[0]["monFreight"].ToString()) * monConverRate);
                        lblOtherCost.Text = Convert.ToString(decimal.Parse(_dt.Rows[0]["monPacking"].ToString()) * monConverRate);
                        lblDiscount.Text = "0";
                    }
                }
                else
                {
                    _dt = _obj.DataView(4, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                    if (_dt.Rows.Count > 0)
                    {
                        lblSuppliuerID.Text = _dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + _dt.Rows[0]["strSupplierName"];
                        //lblMrrNo.Text = dt.Rows[0][""].ToString();
                        // lblMrrDate.Text= dt.Rows[0][""].ToString();
                        lblPoTotal.Text = _dt.Rows[0]["monPOTotalVAT"].ToString();
                        lblProductCost.Text = _dt.Rows[0]["monPOAmount"].ToString();
                        lblTransportCost.Text = _dt.Rows[0]["monTransport"].ToString();
                        lblOtherCost.Text = _dt.Rows[0]["monOther"].ToString();
                        lblDiscount.Text = _dt.Rows[0]["monDiscount"].ToString();
                        lblCurrency.Text = "Currency: " + _dt.Rows[0]["strCurrencyName"];
                        lblConversion.Text = "Conversion: " + _dt.Rows[0]["monBDTConversion"];
                        hdnConversion.Value = _dt.Rows[0]["monBDTConversion"].ToString();
                        lblPoIssueBy.Text = _dt.Rows[0]["strEmployeeName"].ToString();
                    }
                }

                _dt = _obj.DataView(9, xmlString, ddlWH.SelectedValue(), intPo, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    dgvMrr.DataSource = _dt;
                    dgvMrr.DataBind();
                }
                else
                {
                    Toaster("PO approval not found", Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        private string ImportMissingCost(int intpo, int intShipment)
        {
            string sms = string.Empty;
            try
            {
                sprInventoryGetMissingCostTableAdapter cost = new sprInventoryGetMissingCostTableAdapter();
                DataTable dt = new DataTable();
                dt = cost.GetImportMissingCost(intpo, intShipment);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        sms = dt.Rows[0]["strMissingCost"].ToString();
                    }
                    else
                    {
                        sms = "Import Missing Cost Not Found!";
                    }
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
            return sms;


        }
        private void DefaultBind()
        {
            try
            {
                LoadWh();
                LoadPoType();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        private void LoadWh()
        {
            _dt = _obj.DataView(1, xmlString, ddlWH.SelectedValue(), 0, DateTime.Now, Enroll);
            ddlWH.Loads(_dt, "Id", "strName");
        }
        private void LoadPoType()
        {
            _dt = _obj.DataView(2, xmlString, ddlWH.SelectedValue(), 0, DateTime.Now, Enroll);
            ddlPoType.Loads(_dt, "Id", "strName");
        }
        private void DataClear()
        {
            try
            {
                dgvMrr.UnLoad();
                lblSuppliuerID.Text = "";
                lblSuppliyer.Text = "";
                lblPoTotal.Text = "";
                lblProductCost.Text = "";
                lblTransportCost.Text = "";
                lblOtherCost.Text = "";
                lblDiscount.Text = "";
                lblCurrency.Text = "";
                lblConversion.Text = "";
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            FileInfo fileInfo = new FileInfo(localPath + fileName);
            FileStream fileStream = fileInfo.OpenRead();

            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];

            Stream uploadStream = requestFTPUploader.GetRequestStream();
            int contentLength = fileStream.Read(buffer, 0, bufferLength);

            while (contentLength != 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = fileStream.Read(buffer, 0, bufferLength);
            }

            uploadStream.Close();
            fileStream.Close();
        }
        #endregion

    }
}