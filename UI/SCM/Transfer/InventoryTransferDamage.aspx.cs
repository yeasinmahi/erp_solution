using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM.Transfer
{
    public partial class InventoryTransferDamage : BasePage
    {
        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private StoreIssue_BLL objWH = new StoreIssue_BLL();
        private DataTable dt = new DataTable(); private string xmlString, filePathForXML; private int Id;
        private int enroll, intvehicleId, intWh; private string[] arrayKey, arrayKeyV; private char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1; private decimal values;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMat__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvStore.DataSource = ""; dgvStore.DataBind(); }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id";
                ddlWh.DataBind();
                ddlWh.Items.Insert(0, new ListItem("Select", "0"));
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                dt = objWH.GetWH();
                ddlToWh.DataSource = dt;
                ddlToWh.DataTextField = "strName";
                ddlToWh.DataValueField = "Id";
                ddlToWh.DataBind();
                ddlToWh.Items.Insert(0, new ListItem("Select", "0"));
                dt.Clear();

                //dt = objTransfer.GetTtransferDatas(7, xmlString, intWh, Id, DateTime.Now, enroll);
                //ddlTransType.DataSource = dt;
                //ddlTransType.DataTextField = "strName";
                //ddlTransType.DataValueField = "Id";
                //ddlTransType.DataBind();
                //ddlTransType.Items.Insert(0, new ListItem("Select", "0"));
                ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                txtItem.Text = ""; txTransferQty.Text = ""; txtRemarks.Text = ""; txtVehicle.Text = ""; lblDetalis.Text = ""; lblValue.Text = "";
                ddlLcation.DataSource = "";
                ddlLcation.DataBind();
                ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                hdnStockQty.Value = "0";
            }
            catch { }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }
                Id = int.Parse(itemid.ToString());
                intWh = int.Parse(ddlWh.SelectedValue);

                dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    string strItems = dt.Rows[0]["strItem"].ToString();
                    string intItem = dt.Rows[0]["intItem"].ToString();
                    string strUom = dt.Rows[0]["strUom"].ToString();
                    string intLocation = dt.Rows[0]["intLocation"].ToString();
                    string strLocation = dt.Rows[0]["strLocation"].ToString();
                    string monStock = dt.Rows[0]["monStock"].ToString();
                    string monValues = dt.Rows[0]["monValue"].ToString();
                    hdnStockQty.Value = dt.Rows[0]["monStock"].ToString();
                    hdnUom.Value = dt.Rows[0]["strUom"].ToString();
                    hdnValue.Value = dt.Rows[0]["monValue"].ToString();
                    string detaliss = "  Stock: " + monStock + " " + strUom + " Id: " + intItem;
                    lblDetalis.Text = detaliss;
                    lblValue.Text = "Value: " + monValues.ToString();
                    ddlLcation.DataSource = dt;
                    ddlLcation.DataTextField = "strLocation";
                    ddlLcation.DataValueField = "intLocation";
                    ddlLcation.DataBind();
                    ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                    dt.Clear();
                }
                else { lblDetalis.Text = ""; lblValue.Text = ""; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock is not avaiable!');", true); }
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnPreConfirm.Value == "1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }

                    arrayKeyV = txtItem.Text.Split(delimiterChars);
                    string vehicle = "";
                    if (arrayKeyV.Length > 0)
                    { vehicle = arrayKeyV[1].ToString(); }

                    if (int.Parse(vehicle) > 0)
                    {
                    }
                    else { vehicle = "0"; }
                    string locationId = ddlLcation.SelectedValue.ToString();
                    string locationName = ddlLcation.SelectedValue.ToString();
                    string transType = ddlTransType.SelectedItem.ToString();
                    string transTypeId = ddlTransType.SelectedValue.ToString();
                    uom = hdnUom.Value.ToString();
                    string qty = txTransferQty.Text.ToString();
                    string remarks = txtRemarks.Text.ToString();

                    try { decimal values = (decimal.Parse(hdnValue.Value.ToString()) / decimal.Parse(hdnStockQty.Value.ToString())) * decimal.Parse(qty.ToString()); } catch { values = 0; }
                    string monValue = values.ToString();
                    string strenroll = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    checkXmlItemData(itemid);
                    if (decimal.Parse(qty) > 0 && CheckItem == 1)
                    {
                        CreateXml(item, itemid, qty, locationId, locationName, transType, transTypeId, uom, monValue, remarks, vehicle);
                        txtItem.Text = ""; txTransferQty.Text = ""; lblValue.Text = "";
                        ddlLcation.DataSource = "";
                        ddlLcation.DataBind();
                        ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please set Vehicle No');", true); }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
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
                        string msg = objTransfer.PostTransferDamage(8, xmlString, intWh, intToWh, DateTime.Now, enroll);
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
            catch { try { File.Delete(filePathForXML); } catch { } }
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

        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            AutoSearch_BLL ast = new AutoSearch_BLL();
            return ast.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
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