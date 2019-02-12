﻿using Flogging.Core;
using GLOBAL_BLL;
using Purchase_BLL.Asset;
using SCM_BLL;
using System;
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

namespace UI.SCM.Transfer
{
    public partial class InventoryTransferOut : BasePage
    {
        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private StoreIssue_BLL objWH = new StoreIssue_BLL();
        private DataTable dt = new DataTable();
        private string xmlString, filePathForXML;
        private int Id;
        private int intvehicleId, intWh;
        private string[] arrayKey, arrayKeyV;
        private char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1;
        private decimal values;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\Transfer\\InventoryTransferOut";
        private string stop = "stopping SCM\\Transfer\\InventoryTransferOut";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMat__" +Enroll + ".xml");
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (!IsPostBack)
                {
                    ast = new AutoSearch_BLL();
                    try { File.Delete(filePathForXML); dgvStore.DataSource = ""; dgvStore.DataBind(); }
                    catch { }

                    dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, Enroll);
                    Common.LoadDropDownWithSelect(ddlWh, dt, "Id", "strName");
                    Session["WareID"] = ddlWh.SelectedValue.ToString();

                    //dt = objWH.GetWH(Enroll,Common.GetDdlSelectedValue(ddlWh));
                    Common.LoadDropDownWithSelect(ddlToWh, new DataTable(), "Id", "strName");

                    dt = objTransfer.GetTtransferDatas(7, xmlString, intWh, Id, DateTime.Now, Enroll);
                    Common.LoadDropDownWithSelect(ddlTransType, dt, "Id", "strName");
                    dt.Clear();

                    ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

                Toaster(ex.Message,Common.TosterType.Error);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                txtItem.Text = ""; txTransferQty.Text = ""; txtRemarks.Text = ""; txtVehicle.Text = ""; lblDetalis.Text = ""; lblValue.Text = "";
                
                Common.UnLoadDropDownWithSelect(ddlLcation);
                Common.UnLoadDropDownWithSelect(ddlToWh);
                hdnStockQty.Value = "0";
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

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    uom = arrayKey[3].ToString();
                    itemid = arrayKey[1].ToString();
                }
                Id = int.Parse(itemid.ToString());
                intWh = int.Parse(ddlWh.SelectedValue.ToString());

                dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    Common.LoadDropDownWithSelect(ddlLcation, dt, "Id", "strName");
                    dt.Clear();
                }
                dt = objWH.GetWH(Enroll, Common.GetDdlSelectedValue(ddlWh));
                if (dt.Rows.Count>0)
                {
                    Common.LoadDropDownWithSelect(ddlToWh, dt, "Id", "strName");
                    dt.Clear();
                }
                
                //else { lblDetalis.Text = ""; lblValue.Text = ""; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock is not avaiable!');", true); }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnPreConfirm.Value == "1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = "";
                    string itemid = "";
                    string uom = "";
                    bool proceed = false;
                    if (arrayKey.Length > 0)
                    {
                        item = arrayKey[0].ToString();
                        uom = arrayKey[3].ToString();
                        itemid = arrayKey[1].ToString();
                    }

                    arrayKeyV = txtItem.Text.Split(delimiterChars);
                    string vehicle = "";
                    if (arrayKeyV.Length > 0)
                    {
                        vehicle = arrayKeyV[1].ToString();
                    }

                    if (int.Parse(vehicle) > 0)
                    {
                    }
                    else
                    {
                        vehicle = "0";
                    }
                    string locationId = ddlLcation.SelectedValue.ToString();
                    string locationName = ddlLcation.SelectedValue.ToString();
                    string transType = ddlTransType.SelectedItem.ToString();
                    string transTypeId = ddlTransType.SelectedValue.ToString();
                    uom = hdnUom.Value.ToString();
                    string qty = txTransferQty.Text.ToString();
                    string remarks = txtRemarks.Text.ToString();

                    try
                    {
                        decimal values =
                            (decimal.Parse(hdnValue.Value.ToString()) / decimal.Parse(hdnStockQty.Value.ToString())) *
                            decimal.Parse(qty.ToString());
                    }
                    catch
                    {
                        values = 0;
                    }
                    string monValue = values.ToString();
                    checkXmlItemData(itemid);
                    if (decimal.Parse(qty) > 0 && CheckItem == 1)
                    {
                        CreateXml(item, itemid, qty, locationId, locationName, transType, transTypeId, uom, monValue,
                            remarks, vehicle);
                        txtItem.Text = "";
                        txTransferQty.Text = "";
                        lblValue.Text = "";
                        ddlLcation.DataSource = "";
                        ddlLcation.DataBind();
                        ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Item already added');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please set Vehicle No');", true);
                }
            }
            catch { }
        }

        private void CreateXml(string item, string itemid, string qty, string locationId, string locationName, string transType, string transTypeId, string uom, string monValue, string remarks, string vehicle)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, qty, locationId, locationName, transType, transTypeId, uom, monValue, remarks, vehicle);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, qty, locationId, locationName, transType, transTypeId, uom, monValue, remarks, vehicle);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string qty, string locationId, string locationName, string transType, string transTypeId, string uom, string monValue, string remarks, string vehicle)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;
            XmlAttribute LocationName = doc.CreateAttribute("locationName");
            LocationName.Value = locationName;
            XmlAttribute TransType = doc.CreateAttribute("transType");
            TransType.Value = transType;
            XmlAttribute TransTypeId = doc.CreateAttribute("transTypeId");
            TransTypeId.Value = transTypeId;

            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute MonValue = doc.CreateAttribute("monValue");
            MonValue.Value = monValue;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Vehicle = doc.CreateAttribute("vehicle");
            Vehicle.Value = vehicle;

            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Qty);
            node.Attributes.Append(LocationId);

            node.Attributes.Append(LocationName);
            node.Attributes.Append(TransType);
            node.Attributes.Append(TransTypeId);
            node.Attributes.Append(Uom);
            node.Attributes.Append(MonValue);

            node.Attributes.Append(Remarks);
            node.Attributes.Append(Vehicle);

            return node;
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvStore.DataSource = ds; }
                else { dgvStore.DataSource = ""; }
                dgvStore.DataBind();
            }
            catch { }
        }

        private void checkXmlItemData(string itemid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (itemid == (ds.Tables[0].Rows[i].ItemArray[1].ToString()))
                    {
                        CheckItem = 0;
                        break;
                    }
                    else
                    {
                        CheckItem = 1;
                    }
                }
            }
            catch { }
        }

        protected void ddlLcation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    uom = arrayKey[3].ToString();
                    itemid = arrayKey[1].ToString();
                }
                Id = int.Parse(itemid.ToString());
                intWh = int.Parse(ddlWh.SelectedValue);
                int locationId = int.Parse(ddlLcation.SelectedValue);
                dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, locationId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Select("intLocation = " + locationId).FirstOrDefault();
                    if (row != null)
                    {
                        string strItems = row["strItem"].ToString();
                        string intItem = row["intItem"].ToString();
                        string strUom = row["strUom"].ToString();
                        string intLocation = row["intLocation"].ToString();
                        string strLocation = row["strLocation"].ToString();
                        string monStock = row["monStock"].ToString();
                        string monValues = row["monValue"].ToString();
                        hdnStockQty.Value = row["monStock"].ToString();
                        hdnUom.Value = row["strUom"].ToString();
                        hdnValue.Value = row["monValue"].ToString();
                        string detaliss = "  Stock: " + monStock + " " + strUom + " Id: " + intItem;
                        lblDetalis.Text = detaliss;
                        lblValue.Text = "Value: " + monValues.ToString();
                    }
                    else
                    {
                        Toaster("No stock under this location",Common.TosterType.Warning);
                    }
                    //string strItems = dt.Rows[0]["strItem"].ToString();
                    //string intItem = dt.Rows[0]["intItem"].ToString();
                    //string strUom = dt.Rows[0]["strUom"].ToString();
                    //string intLocation = dt.Rows[0]["intLocation"].ToString();
                    //string strLocation = dt.Rows[0]["strLocation"].ToString();
                    //string monStock = dt.Rows[0]["monStock"].ToString();
                    //string monValues = dt.Rows[0]["monValue"].ToString();
                    //hdnStockQty.Value = dt.Rows[0]["monStock"].ToString();
                    //hdnUom.Value = dt.Rows[0]["strUom"].ToString();
                    //hdnValue.Value = dt.Rows[0]["monValue"].ToString();
                    //string detaliss = "  Stock: " + monStock + " " + strUom + " Id: " + intItem;
                    //lblDetalis.Text = detaliss;
                    //lblValue.Text = "Value: " + monValues.ToString();
                    dt.Clear();
                }
                else { lblDetalis.Text = ""; lblValue.Text = ""; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock is not avaiable!');", true); }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            var tracker = new PerfTracker("Performance on SCM\\Transfer\\InventoryTransferOut Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWh.SelectedValue);
                    int intToWh = int.Parse(ddlToWh.SelectedValue);

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string msg = objTransfer.PostTransfer(8, xmlString, intWh, intToWh, DateTime.Now, Enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvStore.DataSource = "";
                        dgvStore.DataBind();

                        txtItem.Text = ""; txTransferQty.Text = ""; txtRemarks.Text = ""; txtVehicle.Text = ""; lblDetalis.Text = ""; lblValue.Text = "";
                        ddlLcation.DataSource = dt;
                        ddlLcation.DataBind();
                        ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                        hdnStockQty.Value = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
                try { File.Delete(filePathForXML); } catch { }
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvStore.DataSource;
                dsGrid.Tables[0].Rows[dgvStore.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvStore.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvStore.DataSource = ""; dgvStore.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        #region========================Auto Search============================
        static AutoSearch_BLL ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {

            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            //return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleSerach(string prefixText, int count)
        {
            InventoryTransfer_BLL objserch = new InventoryTransfer_BLL();
            return objserch.AutoSearchVehicle(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString(), prefixText);
        }

        #endregion====================Close======================================
    }
}