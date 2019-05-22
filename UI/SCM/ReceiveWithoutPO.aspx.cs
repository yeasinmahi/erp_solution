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

namespace UI.SCM
{
    public partial class ReceiveWithoutPO : BasePage
    {
        private MrrReceive_BLL objRecive = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private Location_BLL objOperation = new Location_BLL();

        private string xmlunit = ""; private int enroll, CheckItem = 1, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Inden__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                ast = new AutoSearch_BLL();
                try { File.Delete(filePathForXML); dgvRecive.DataSource = ""; dgvRecive.DataBind(); }
                catch { }
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
            else { }
        }

        private void DefaltLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objRecive.DataView(1, xmlunit, 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                try
                {
                    Session["WareID"] = ddlWH.SelectedValue;
                }
                catch { }
            }
            catch { }
        }

        #region========================Auto Search============================

        static AutoSearch_BLL ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {
            
            return ast.AutoSearchItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            //return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion====================Close======================================

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                checkXmlItemData(itemid);
                if (CheckItem == 1 && double.Parse(txtQty.Text.ToString()) > 0 && txtRate.Text.Length > 0)
                {
                    string itemId = itemid;
                    string itemName = item;
                    string qty = txtQty.Text.ToString();
                    string rate = txtRate.Text.ToString();
                    string locationid = ddlLocation.SelectedValue.ToString();
                    string location = ddlLocation.SelectedItem.ToString();
                    string remarks = txtPurpose.Text.ToString();

                    CreateXml(itemId, itemName, qty, rate, locationid, location, remarks);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                txtItem.Text = ""; txtQty.Text = "0";
            }
            catch { }
        }

        private void CreateXml(string itemId, string itemName, string qty, string rate, string locationid, string location, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, qty, rate, locationid, location, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, qty, rate, locationid, location, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        #region========================Data Submit Action=====================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWH.SelectedValue);
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string mrtg = objRecive.MrrReceive(18, xmlString, intWh, 0, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                        dgvRecive.DataSource = "";
                        dgvRecive.DataBind();
                    }
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
        }

        #endregion======================Close=================================

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvRecive.DataSource;
                dsGrid.Tables[0].Rows[dgvRecive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvRecive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvRecive.DataSource = ""; dgvRecive.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWH.SelectedValue;
            }
            catch { }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = "";
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }
                dt = objOperation.WhDataView(8, "", intWh, int.Parse(itemid), 1);
                ddlLocation.DataSource = dt;
                ddlLocation.DataValueField = "intLocation";
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string itemName, string qty, string rate, string locationid, string location, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute Locationid = doc.CreateAttribute("locationid");
            Locationid.Value = locationid;
            XmlAttribute Location = doc.CreateAttribute("location");
            Location.Value = location;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            node.Attributes.Append(ItemId);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);

            node.Attributes.Append(Locationid);
            node.Attributes.Append(Location);

            node.Attributes.Append(Remarks);

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
                { dgvRecive.DataSource = ds; }
                else { dgvRecive.DataSource = ""; }
                dgvRecive.DataBind();
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
            }
            catch { }
        }
    }
}