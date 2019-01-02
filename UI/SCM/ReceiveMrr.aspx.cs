using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class ReceiveMrr : System.Web.UI.Page
    {
        private MrrReceive_BLL obj = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private string xmlString = "", filePathForXML, strMssingCost, challanNo, strVatChallan, poIssueBy, expireDate, manufactureDate;
        private int intWh, enroll, intPo, intShipment, intPOID, intSupplierID, intUnitID;
        private decimal monConverRate, monVatAmount, monProductCost, monOther, monDiscount, monBDTConversion, monRate, monTransport, monOtherTotal;
        private DateTime dteChallan;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\ReceiveMrr";
        private string stop = "stopping SCM\\ReceiveMrr";
        private string perform = "Performance on SCM\\ReceiveMrr";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Mr__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); } catch { }
                ddlInvoice.Enabled = false;
                DefaltBind();
            }
            else
            {
            }
        }

        protected void ddlPoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string poType = ddlPoType.SelectedItem.ToString();
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>".ToString();
                dt = obj.DataView(3, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPo.DataSource = dt;
                ddlPo.DataTextField = "strName";
                ddlPo.DataValueField = "Id";
                ddlPo.DataBind();
                DataClear();
            }
            catch { }
            txtPO.Text = "";
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string poType = ddlPoType.SelectedItem.ToString();
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>".ToString();
                dt = obj.DataView(3, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPo.DataSource = dt;
                ddlPo.DataTextField = "strName";
                ddlPo.DataValueField = "Id";
                ddlPo.DataBind();
                DataClear();
            }
            catch { }
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
            var fd = log.GetFlogDetail(start, location, "btnSaveMrr_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnSaveMrr_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                try { File.Delete(filePathForXML); } catch { }

                if (dgvMrr.Rows.Count > 0 && hdnConfirm.Value.ToString() == "1")
                {
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //  try { intPOID = int.Parse(ddlPo.SelectedValue); } catch { }
                    try { intSupplierID = int.Parse(lblSuppliuerID.Text); } catch { }
                    try { intShipment = int.Parse(hdnShipment.Value); } catch { }
                    try { dteChallan = DateTime.Parse(txtdteChallan.Text.ToString()); } catch { }
                    try { monVatAmount = decimal.Parse(txtVatAmount.Text); } catch { }
                    try { challanNo = txtChallan.Text.ToString(); } catch { }
                    try { strVatChallan = txtVatChallan.Text.ToString(); } catch { }
                    try { monProductCost = decimal.Parse(lblProductCost.Text.ToString()); } catch { }
                    try { monTransport = decimal.Parse(lblTransportCost.Text.ToString()); } catch { monTransport = 0; }
                    try { monOther = decimal.Parse(lblOtherCost.Text.ToString()); } catch { monOther = 0; }
                    try { monDiscount = decimal.Parse(lblDiscount.Text.ToString()); } catch { }
                    try { monBDTConversion = decimal.Parse(hdnConversion.Value); } catch { }
                    poIssueBy = lblPoIssueBy.Text.ToString();
                    monOtherTotal = monOther + monTransport;
                    for (int index = 0; index < dgvMrr.Rows.Count; index++)
                    {
                        intPOID = int.Parse(((Label)dgvMrr.Rows[index].FindControl("lblPoId")).Text.ToString());
                        string intItemID = ((Label)dgvMrr.Rows[index].FindControl("lblItemId")).Text.ToString();
                        string numPOQty = ((Label)dgvMrr.Rows[index].FindControl("lblPoQty")).Text.ToString();
                        string numPreRcvQty = ((Label)dgvMrr.Rows[index].FindControl("lblPreviousReceive")).Text.ToString();
                        string numRcvQty = ((TextBox)dgvMrr.Rows[index].FindControl("txtReceiveQty")).Text.ToString();
                        try { monRate = decimal.Parse(((Label)dgvMrr.Rows[index].FindControl("lblRate")).Text.ToString()); } catch { monRate = 0; }
                        string numRcvValue = (decimal.Parse(numPOQty.ToString()) * monRate).ToString();//((Label)dgvMrr.Rows[index].FindControl("lblMrrValue")).Text.ToString();
                        string numRcvVatValue = ((Label)dgvMrr.Rows[index].FindControl("lblVat")).Text.ToString();
                        string location = ((DropDownList)dgvMrr.Rows[index].FindControl("ddlStoreLocation")).SelectedValue.ToString();
                        string remarks = ((TextBox)dgvMrr.Rows[index].FindControl("txtRemarks")).Text.ToString();
                        string ysnQc = ((Label)dgvMrr.Rows[index].FindControl("lblYsnQc")).Text.ToString();
                        string numQcQty = ((Label)dgvMrr.Rows[index].FindControl("lblQcPassedQty")).Text.ToString();
                        string batchNo = ((TextBox)dgvMrr.Rows[index].FindControl("txtBatchNo")).Text.ToString();
                        try { DateTime dteExp = DateTime.Parse((((TextBox)dgvMrr.Rows[index].FindControl("txtExpireDate")).Text.ToString())); expireDate = dteExp.ToString(); } catch { expireDate = null; }
                        try { DateTime dteManuf = DateTime.Parse((((TextBox)dgvMrr.Rows[index].FindControl("txtManufacturingDate")).Text.ToString())); manufactureDate = dteManuf.ToString(); } catch { manufactureDate = null; }

                        if (decimal.Parse(numRcvQty) > 0 && int.Parse(location) > 0 && monRate > 0)
                        {
                            //if (ysnQc.ToString() == "0")
                            //{
                            //    if (Double.Parse(numPreRcvQty) + Double.Parse(numRcvQty) > (Double.Parse(numPOQty)) * 1.1)
                            //    {
                            //        try { File.Delete(filePathForXML); } catch { }
                            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Maximum receive quantity must be Less or equal than 10% more than PO quantity.');", true);
                            //        break;
                            //    }
                            //}
                            //else
                            //{
                            //    if (Double.Parse(numPreRcvQty) + Double.Parse(numRcvQty) > (Double.Parse(numQcQty)) * 1.1)
                            //    {
                            //        try { File.Delete(filePathForXML); } catch { }
                            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Maximum receive quantity must be Less or equal than QC Passed quantity.');", true);
                            //        break;
                            //    }
                            //}

                            CreateXml(intPOID.ToString(), intSupplierID.ToString(), intShipment.ToString(), dteChallan.ToString(), monVatAmount.ToString(), challanNo, strVatChallan, monProductCost.ToString(), monOtherTotal.ToString(), monDiscount.ToString(), monBDTConversion.ToString(), intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate.ToString(), poIssueBy, batchNo, expireDate, manufactureDate);
                        }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("mrr");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<mrr>" + xmlString + "</mrr>";
                    try { File.Delete(filePathForXML); } catch { }
                    string msg = obj.MrrReceive(11, xmlString, intWh, intPOID, DateTime.Now, enroll);

                    string[] searchKey = Regex.Split(msg, ":");
                    lblMrrNo.Text = searchKey[1].ToString();

                    dgvMrr.DataSource = "";
                    dgvMrr.DataBind();

                    #region====================Mrr Document Attachment===========================
                    try
                    {
                        string FileExtension = Path.GetExtension(docUpload.PostedFile.FileName).Substring(1);
                        string xmlData = "<voucher><voucherentry strFileName=" + '"' + "MRR Challan" + '"' + " FileExtension=" + '"' + FileExtension + '"' + "/></voucher>".ToString();

                        if (FileExtension.Length > 1)
                        {
                            msg = obj.MrrReceive(15, xmlData, intWh, int.Parse(lblMrrNo.Text.ToString()), DateTime.Now, enroll);

                            string[] searchKeyAt = Regex.Split(msg, ":");
                            string fileId = searchKeyAt[1].ToString();

                            string dfile = fileId.ToString() + "." + FileExtension;
                            docUpload.PostedFile.SaveAs(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
                            FileUploadFTP(Server.MapPath("~/SCM/Uploads/"), dfile.ToString(), "ftp://ftp.akij.net/ERP_FTP/", "erp@akij.net", "erp123");
                            File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
                        }
                    }
                    catch { }

                    #endregion===================Close============================================

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    //PoView(intPOID);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnShow_Click", ex);
                Flogger.WriteError(efd);
                try { File.Delete(filePathForXML); } catch { }
            }

            fd = log.GetFlogDetail(stop, location, "btnShow_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        private void CreateXml(string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks, string monRate, string poIssueBy, string batchNo, string expireDate, string manufactureDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy, batchNo, expireDate, manufactureDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("mrr");
                XmlNode addItem = CreateItemNode(doc, intPOID, intSupplierID, intShipment, dteChallan, monVatAmount, challanNo, strVatChallan, monProductCost, monOther, monDiscount, monBDTConversion, intItemID, numPOQty, numPreRcvQty, numRcvQty, numRcvValue, numRcvVatValue, location, remarks, monRate, poIssueBy, batchNo, expireDate, manufactureDate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string intPOID, string intSupplierID, string intShipment, string dteChallan, string monVatAmount, string challanNo, string strVatChallan, string monProductCost, string monOther, string monDiscount, string monBDTConversion, string intItemID, string numPOQty, string numPreRcvQty, string numRcvQty, string numRcvValue, string numRcvVatValue, string location, string remarks, string monRate, string poIssueBy, string batchNo, string expireDate, string manufactureDate)
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

            return node;
        }

        protected void ddlPo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataClear();
                string poType = ddlPoType.SelectedItem.ToString();
                intPo = int.Parse(ddlPo.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                if (poType == "Local")
                {
                    ddlInvoice.Enabled = false;
                    ddlInvoice.DataSource = "";
                    ddlInvoice.DataBind();
                }
                else if (poType == "Import")
                {
                    ddlInvoice.Enabled = true;
                    dt = obj.DataView(5, xmlString, intWh, intPo, DateTime.Now, enroll);
                    ddlInvoice.DataSource = dt;
                    ddlInvoice.DataTextField = "strName";
                    ddlInvoice.DataValueField = "Id";
                    ddlInvoice.DataBind();
                }
            }
            catch { }
            txtPO.Text = "";
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            dgvMrr.DataSource = dt;
            dgvMrr.DataBind();

            intWh = int.Parse(ddlWH.SelectedValue);
            if (txtPO.Text.Length > 3)
            {
                intPo = int.Parse(txtPO.Text);
                dt = obj.GetWHByPO(intPo, intWh);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["strPoFor"].ToString() == "Local")
                    {
                        ddlPoType.SelectedValue = "1";
                        ddlInvoice.Enabled = false;
                        ddlInvoice.DataSource = "";
                        ddlInvoice.DataBind();
                    }
                    else if (dt.Rows[0]["strPoFor"].ToString() == "Import")
                    {
                        ddlPoType.SelectedValue = "2";
                        ddlInvoice.Enabled = true;
                        dt = obj.DataView(5, xmlString, intWh, intPo, DateTime.Now, enroll);
                        ddlInvoice.DataSource = dt;
                        ddlInvoice.DataTextField = "strName";
                        ddlInvoice.DataValueField = "Id";
                        ddlInvoice.DataBind();
                    }
                    else if (dt.Rows[0]["strPoFor"].ToString() == "Fabrication")
                    {
                        ddlPoType.SelectedValue = "3";
                    }

                    string poType = ddlPoType.SelectedItem.ToString();
                    intWh = int.Parse(ddlWH.SelectedValue.ToString());
                    xmlString = "<voucher><voucherentry poType=" + '"' + poType + '"' + "/></voucher>".ToString();
                    dt = obj.DataView(3, xmlString, intWh, 0, DateTime.Now, enroll);
                    ddlPo.DataSource = dt;
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
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO is not approve');", true);
                }
            }
            else
            {
                intPo = int.Parse(ddlPo.SelectedValue);
                PoView(intPo);
            }
        }

        private void PoView(int intPo)
        {
            try
            {
                intWh = int.Parse(ddlWH.SelectedValue);

                try { intShipment = int.Parse(ddlInvoice.SelectedValue); hdnShipment.Value = intShipment.ToString(); } catch { intShipment = 0; hdnShipment.Value = "0".ToString(); }
                xmlString = "<voucher><voucherentry intShipment=" + '"' + intShipment + '"' + "/></voucher>".ToString();
                if (ddlInvoice.Enabled == true)
                {
                    dt = obj.DataView(6, xmlString, intWh, intPo, DateTime.Now, enroll);
                    strMssingCost = dt.Rows[0]["strMissingCost"].ToString();

                    if (strMssingCost != "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["strMissingCost"].ToString() + "');", true);
                    }
                    else
                    {
                        dt = obj.DataView(7, xmlString, intWh, intPo, DateTime.Now, enroll);
                        lblSuppliuerID.Text = dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + dt.Rows[0]["strSupplierName"].ToString();
                        lblCurrency.Text = " Currency: " + dt.Rows[0]["strCurrencyName"].ToString();
                        lblConversion.Text = " Conversion: " + dt.Rows[0]["monBDTConversion"].ToString();
                        monConverRate = decimal.Parse(dt.Rows[0]["monBDTConversion"].ToString());
                        lblPoIssueBy.Text = dt.Rows[0]["strEmployeeName"].ToString();

                        dt = obj.DataView(8, xmlString, intWh, intPo, DateTime.Now, enroll);
                        lblPoTotal.Text = "";
                        lblProductCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monTotal"].ToString()) * monConverRate);
                        lblTransportCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monFreight"].ToString()) * monConverRate);
                        lblOtherCost.Text = Convert.ToString(decimal.Parse(dt.Rows[0]["monPacking"].ToString()) * monConverRate);
                        lblDiscount.Text = "0";
                    }
                }
                else
                {
                    dt = obj.DataView(4, xmlString, intWh, intPo, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblSuppliuerID.Text = dt.Rows[0]["intSupplierID"].ToString();
                        lblSuppliyer.Text = "Supplier: " + dt.Rows[0]["strSupplierName"].ToString();
                        //lblMrrNo.Text = dt.Rows[0][""].ToString();
                        // lblMrrDate.Text= dt.Rows[0][""].ToString();
                        lblPoTotal.Text = dt.Rows[0]["monPOTotalVAT"].ToString();
                        lblProductCost.Text = dt.Rows[0]["monPOAmount"].ToString();
                        lblTransportCost.Text = dt.Rows[0]["monTransport"].ToString();
                        lblOtherCost.Text = dt.Rows[0]["monOther"].ToString();
                        lblDiscount.Text = dt.Rows[0]["monDiscount"].ToString();
                        lblCurrency.Text = "Currency: " + dt.Rows[0]["strCurrencyName"].ToString();
                        lblConversion.Text = "Conversion: " + dt.Rows[0]["monBDTConversion"].ToString();
                        hdnConversion.Value = dt.Rows[0]["monBDTConversion"].ToString();
                        lblPoIssueBy.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    }
                }

                dt = obj.DataView(9, xmlString, intWh, intPo, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    dgvMrr.DataSource = dt;
                    dgvMrr.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('PO approval not found');", true);
                }
            }
            catch { }
        }

        private void DefaltBind()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = obj.DataView(1, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                intWh = int.Parse(ddlWH.SelectedValue);
                dt = obj.DataView(2, xmlString, intWh, 0, DateTime.Now, enroll);
                ddlPoType.DataSource = dt;
                ddlPoType.DataTextField = "strName";
                ddlPoType.DataValueField = "Id";
                ddlPoType.DataBind();
            }
            catch { }
        }

        private void DataClear()
        {
            try
            {
                dgvMrr.DataSource = "";
                dgvMrr.DataBind();
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
            catch { }
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

            requestFTPUploader = null;
        }
    }
}