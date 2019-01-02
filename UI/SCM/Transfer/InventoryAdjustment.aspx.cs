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

//using MySql.Data.MySqlClient;

namespace UI.SCM.Transfer
{
    public partial class InventoryAdjustment : BasePage
    {
        //string connectString = @"server=10.17.110.5, databasse=test-ag, Uid=root;Pwd=vicidialnow";

        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private Location_BLL objOperation = new Location_BLL();
        private StoreIssue_BLL objWH = new StoreIssue_BLL();
        private DataTable dt = new DataTable(); private string xmlString, filePathForXML; private int Id;
        private int enroll, intvehicleId, intWh; private string[] arrayKey, arrayKeyV; private char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1; private decimal values;
        private string connectString;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/adj__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

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

                //try
                //{
                //    using (MySqlConnection sqlcon = new MySqlConnection(connectString))
                //    {
                //        sqlcon.Open();
                //        MySqlCommand sqlcmd = new MySqlCommand("akij", sqlcon);
                //        sqlcmd.CommandType = CommandType.TableDirect;
                //        sqlcmd.Parameters.AddWithValue("name", "0");
                //        sqlcmd.Parameters.AddWithValue("mobile", "0");
                //        sqlcmd.ExecuteNonQuery();
                //    }
                //}
                //catch { }
            }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                txtItem.Text = ""; txtRemarks.Text = "";
                ddlLcation.DataSource = "";
                ddlLcation.DataBind();

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

                dt = objOperation.WhDataView(8, "", intWh, Id, 1);
                ddlLcation.DataSource = dt;
                ddlLcation.DataValueField = "intLocation";
                ddlLcation.DataTextField = "strLocationName";
                ddlLcation.DataBind();
            }
            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[3].ToString(); itemid = arrayKey[1].ToString(); }

                string locationId = ddlLcation.SelectedValue.ToString();
                string locationName = ddlLcation.SelectedValue.ToString();
                string transType = ddlType.SelectedItem.ToString();
                string transTypeId = ddlType.SelectedValue.ToString();
                uom = hdnUom.Value.ToString();
                string qty = txtQty.Text.ToString();
                string rate = txtRate.Text.ToString();
                string remarks = txtRemarks.Text.ToString();
                decimal monValue = decimal.Parse(qty) * decimal.Parse(rate);
                string enroll = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                if (decimal.Parse(qty) > 0 || decimal.Parse(rate) > 0)
                {
                    checkXmlItemData(itemid);
                    if (CheckItem == 1)
                    {
                        CreateXml(item, itemid, qty, rate, monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
                        txtItem.Text = ""; txtQty.Text = "0"; txtRate.Text = "0";
                        ddlLcation.DataSource = "";
                        ddlLcation.DataBind();
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input Valid Quantity and Rate');", true); }
            }
            catch { }
        }

        private void CreateXml(string item, string itemid, string qty, string rate, string monValue, string locationId, string locationName, string transType, string transTypeId, string uom, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, qty, rate, monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, qty, rate, monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
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

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string qty, string rate, string monValue, string locationId, string locationName, string transType, string transTypeId, string uom, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;

            XmlAttribute MonValue = doc.CreateAttribute("monValue");
            MonValue.Value = monValue;

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

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(LocationId);

            node.Attributes.Append(LocationName);
            node.Attributes.Append(TransType);
            node.Attributes.Append(TransTypeId);
            node.Attributes.Append(Uom);
            node.Attributes.Append(MonValue);
            node.Attributes.Append(Remarks);

            return node;
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStore.DataSource = "";
            dgvStore.DataBind();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWh.SelectedValue);

                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        //string msg = objTransfer.PostTransfer(8, xmlString, intWh, intToWh, DateTime.Now, enroll);
                        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        //dgvStore.DataSource = "";
                        //dgvStore.DataBind();

                        //txtItem.Text = ""; txTransferQty.Text = ""; txtRemarks.Text = ""; txtVehicle.Text = ""; lblDetalis.Text = ""; lblValue.Text = "";
                        //ddlLcation.DataSource = dt;
                        //ddlLcation.DataBind();
                        //ddlLcation.Items.Insert(0, new ListItem("Select", "0"));
                        //hdnStockQty.Value = "0";
                    }
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
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

        #endregion====================Close======================================
    }
}