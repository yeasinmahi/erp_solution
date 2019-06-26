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
using Utility;

namespace UI.SCM.Transfer
{
    public partial class InventoryFGTransferOut : BasePage
    {
        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private StoreIssue_BLL objWH = new StoreIssue_BLL();
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable(); private string xmlString, filePathForXML; private int Id;
        private int intWh; private string[] arrayKey, arrayKeyV; private char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1; private decimal values;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/FGTrans__" + Enroll + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);
                    dgvStore.UnLoad();
                }
                catch { }
                LoadWh();
                Session["WareID"] = ddlWh.SelectedValue();
                LoadToWh();

                LoadTransferType();

                intWh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getBomRouting(4, xmlString, "", intWh, 0, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value;
                }
            }
        }

        public void LoadWh()
        {
            int whId = ddlWh.SelectedValue();
            dt = objTransfer.GetTtransferDatas(1, xmlString, whId, Id, DateTime.Now, Enroll);
            ddlWh.LoadWithSelect(dt, "Id", "strName");
            dt.Clear();
        }

        public void LoadToWh()
        {
            int whId = ddlWh.SelectedValue();
            dt = objWH.GetDataByWhId(whId);
            ddlToWh.LoadWithSelect(dt, "Id", "strName");
            dt.Clear();
        }

        public void LoadTransferType()
        {
            int whId = ddlWh.SelectedValue();
            dt = objTransfer.GetTtransferDatas(7, xmlString, whId, Id, DateTime.Now, Enroll);
            ddlTransType.LoadWithSelect(dt, "Id", "strName");
            ddlTransType.SelectedIndex = ddlTransType.Items.IndexOf(ddlTransType.Items.FindByText("Good Product"));
            dt.Clear();
        }

        public void LoadLocation(DataTable dt)
        {
            ddlLcation.LoadWithSelect(dt, "intLocation", "strLocation");
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWh.SelectedValue();
                txtItem.Text = "";
                txTransferQty.Text = "";
                txtRemarks.Text = "";
                txtVehicle.Text = "";
                lblDetalis.Text = "";
                lblValue.Text = "";
                ddlLcation.UnLoad();
                hdnStockQty.Value = "0";
                LoadToWh();
                LoadTransferType();
                intWh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getBomRouting(4, xmlString, "", intWh, 0, DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value;
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string itemid = "";
                if (arrayKey.Length > 0)
                {
                    itemid = arrayKey[1];
                }
                Id = int.Parse(itemid);
                intWh = int.Parse(ddlWh.SelectedValue);

                dt = objTransfer.GetTtransferDatas(5, xmlString, intWh, Id, DateTime.Now, Enroll);
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
                    lblValue.Text = "Value: " + monValues;
                    LoadLocation(dt);
                    dt.Clear();
                }
                else
                {
                    lblDetalis.Text = "";
                    lblValue.Text = "";
                    Toaster("Stock is not avaiable!",Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnPreConfirm.Value == "1")
                {
                    if (dgvStore.Rows.Count > 7)
                    {
                        Toaster("Maximum limit is 7.", Common.TosterType.Warning);
                    }
                    else
                    {
                        arrayKey = txtItem.Text.Split(delimiterChars);
                        string item = "";
                        string itemid = "";
                        if (arrayKey.Length > 0)
                        {
                            item = arrayKey[0];
                            itemid = arrayKey[1];
                        }

                        arrayKeyV = txtVehicle.Text.Split(delimiterChars);
                        string vehicle = "0";
                        if (arrayKeyV.Length > 0)
                        {
                            vehicle = arrayKeyV[1];
                        }

                        try
                        {
                            if (int.Parse(vehicle) > 0)
                            {
                            }
                            else
                            {
                                vehicle = "0";
                            }
                        }
                        catch
                        {
                            vehicle = "0";
                        }

                        string locationId = ddlLcation.SelectedValue;
                        string locationName = ddlLcation.SelectedValue;
                        string transType = ddlTransType.SelectedItem.ToString();
                        string transTypeId = ddlTransType.SelectedValue;
                        var uom = hdnUom.Value;
                        string qty = txTransferQty.Text;
                        string remarks = txtRemarks.Text;

                        try
                        {
                            decimal values = (decimal.Parse(hdnValue.Value) / decimal.Parse(hdnStockQty.Value)) *
                                             decimal.Parse(qty);
                        }
                        catch
                        {
                            values = 0;
                        }
                        string monValue = values.ToString();
                        CheckXmlItemData(itemid);
                        if (decimal.Parse(qty) > 0 && CheckItem == 1)
                        {
                            CreateXml(item, itemid, qty, locationId, locationName, transType, transTypeId, uom,
                                monValue, remarks, vehicle);
                            txtItem.Text = "";
                            txTransferQty.Text = "";
                            lblValue.Text = "";
                            ddlLcation.UnLoad();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('Item already added');", true);
                        }

                        // else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please set Vehicle No');", true); }
                    }
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
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

        private void CheckXmlItemData(string itemid)
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
                if (hdnConfirm.Value == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWh.SelectedValue);
                    int intToWh = int.Parse(ddlToWh.SelectedValue);

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }
                    if (xmlString.Length > 5)
                    {
                        string msg = objTransfer.PostTransfer(16, xmlString, intWh, intToWh, DateTime.Now, Enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvStore.DataSource = "";
                        dgvStore.DataBind();

                        txtItem.Text = "";
                        txTransferQty.Text = "";
                        txtRemarks.Text = "";
                        txtVehicle.Text = "";
                        lblDetalis.Text = "";
                        lblValue.Text = "";
                        ddlLcation.DataSource = dt;
                        ddlLcation.DataBind();
                        ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                        hdnStockQty.Value = "0";
                    }
                }
            }
            catch(Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
                try { File.Delete(filePathForXML); } catch { }
            }
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet) dgvStore.DataSource;
                dsGrid.Tables[0].Rows[dgvStore.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet) dgvStore.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvStore.DataSource = "";
                    dgvStore.DataBind();
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        #region========================Auto Search============================

        private static readonly AutoSearch_BLL AutoSearchBll = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            return AutoSearchBll.AutoSearchFinishGoods(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        //[WebMethod]
        //[ScriptMethod]
        //public static string[] GetIndentItemSerachs(string prefixText, int count)
        //{
        //    return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);

        //}

        [WebMethod]
        [ScriptMethod]
        public static string[] GetVehicleSerach(string prefixText, int count)
        {
            InventoryTransfer_BLL objserch = new InventoryTransfer_BLL();
            return objserch.AutoSearchVehicle(HttpContext.Current.Session["unit"].ToString(), prefixText);
        }

        #endregion====================Close======================================
    }
}