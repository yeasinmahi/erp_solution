using MessagingToolkit.QRCode.Codec;
using QRCoder;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class ReceiveStockInput : System.Web.UI.Page
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        int enroll, mrrId, intWh, rack = 1, godown = 2, rackType; string ImagePath = "", rackId;
        string item = ""; string itemid = "", uom;
        string filePathForXML; string xmlString = "",naration,transferId;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/AEFPS/Data/Stok__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind(); }
                catch { }
                DefaltLoad();
            }
            else
            {

            }
        }
        private void DefaltLoad()
        {
            try
            { 
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();
                

            }
            catch { }

        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetFPSItemSerach(string prefixText, int count)
        {

            Receive_BLL objItem = new Receive_BLL();
            return objItem.GetFairPriceItem(1, prefixText);

        }

         

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                rackId = ddlRack.SelectedValue.ToString();
                if(raRack.Checked == true || ragodwon.Checked == true)
                {
                    if (rackId != "" && decimal.Parse(txtSalesQty.Text) > 0 && decimal.Parse(txtMrrRate.Text) > 0 && decimal.Parse(txtReceQty.Text) > 0 && txtItem.Text.Length >3 && txtNaration.Text.Length>2 && txtTransferID.Text.Length>1)
                    {
                        arrayKey = txtItem.Text.Split(delimiterChars);
                        intWh = int.Parse(ddlWH.SelectedValue.ToString());
                        if (arrayKey.Length > 0)
                        { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); uom = arrayKey[3].ToString(); }
                        string whid = ddlWH.SelectedValue.ToString();
                        string whname = ddlWH.SelectedItem.ToString();
                        string mrrRate = txtMrrRate.Text.ToString();
                        string salesPrice = txtSalesQty.Text.ToString();
                        string receiveQty = txtReceQty.Text.ToString();
                        string rackName = ddlRack.SelectedItem.ToString();
                        string naration = txtNaration.Text.ToString();
                        string transferId = txtTransferID.Text.ToString();
                        CreateXml(itemid, item, uom, whid, whname, mrrRate, salesPrice, receiveQty, rackId, rackName, naration, transferId);
                        txtMrrRate.Text = ""; txtSalesQty.Text = ""; txtReceQty.Text = ""; txtItem.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please fill-up MrrRate,Sales Price and Receive Qty');", true);

                    }
                }
                else { }
                   
              

            }
            catch { }
        }

        private void CreateXml(string itemid, string item, string uom, string whid, string whname, string mrrRate, string salesPrice, string receiveQty,string rackId,string rackName,string naration,string transferId)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("issue");
                XmlNode addItem = CreateItemNode(doc, itemid, item, uom, whid, whname, mrrRate, salesPrice, receiveQty, rackId, rackName, naration, transferId);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("issue");
                XmlNode addItem = CreateItemNode(doc, itemid, item, uom, whid, whname, mrrRate, salesPrice, receiveQty, rackId, rackName, naration, transferId);
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
                XmlNode dSftTm = doc.SelectSingleNode("issue");
                xmlString = dSftTm.InnerXml;
                xmlString = "<issue>" + xmlString + "</issue>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvReceive.DataSource = ds; }

                else { dgvReceive.DataSource = ""; }
                dgvReceive.DataBind();
            }
            catch { }

        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (raRack.Checked == true) { rackType = 1; }
                if( ragodwon.Checked == true) { rackType = 2; }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());               
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                ddlRack.DataSource = dt;
                ddlRack.DataTextField = "strName";
                ddlRack.DataValueField = "Id";
                ddlRack.DataBind();

                dgvReceive.DataSource = ""; dgvReceive.DataBind();
                txtMrrRate.Text = "0"; txtSalesQty.Text = "0"; txtReceQty.Text = "0";
                try { File.Delete(filePathForXML); } catch { }
            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string item, string uom, string whid, string whname, string mrrRate, string salesPrice, string receiveQty,string rackId,string rackName,string naration, string transferId)
        {
            XmlNode node = doc.CreateElement("issueEntry");

            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Whid = doc.CreateAttribute("whid");
            Whid.Value = whid;
            XmlAttribute Whname = doc.CreateAttribute("whname");
            Whname.Value = whname;
            XmlAttribute MrrRate = doc.CreateAttribute("mrrRate");
            MrrRate.Value = mrrRate;
            XmlAttribute SalesPrice = doc.CreateAttribute("salesPrice");
            SalesPrice.Value = salesPrice;
            XmlAttribute ReceiveQty = doc.CreateAttribute("receiveQty");
            ReceiveQty.Value = receiveQty;
            XmlAttribute RackId = doc.CreateAttribute("rackId");
            RackId.Value = rackId;
            XmlAttribute RackName = doc.CreateAttribute("rackName");
            RackName.Value = rackName;

            XmlAttribute Naration = doc.CreateAttribute("naration");
            Naration.Value = naration;
            XmlAttribute TransferId = doc.CreateAttribute("transferId");
            TransferId.Value = transferId;
 
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Item);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Whid);

            node.Attributes.Append(Whname);
            node.Attributes.Append(MrrRate);
            node.Attributes.Append(SalesPrice);
            node.Attributes.Append(ReceiveQty);
            node.Attributes.Append(RackId);
            node.Attributes.Append(RackName);
            node.Attributes.Append(Naration);
            node.Attributes.Append(TransferId);

            return node;
        }

        protected void raRack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                rackType = 1;
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                ddlRack.DataSource = dt;
                ddlRack.DataTextField = "strName";
                ddlRack.DataValueField = "Id";
                ddlRack.DataBind();
            }
            catch { }
        }

        protected void ragodwon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                rackType = 2;
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(7, "", intWh, rackType, DateTime.Now, enroll);
                ddlRack.DataSource = dt;
                ddlRack.DataTextField = "strName";
                ddlRack.DataValueField = "Id";
                ddlRack.DataBind();

            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(hdnConfirm.Value) > 0)
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intWh = int.Parse(ddlWH.SelectedValue);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("issue");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<issue>" + xmlString + "</issue>";
                    try { File.Delete(filePathForXML); } catch { }

                    string mrtg = objRec.MrrReceiveInsert(6, xmlString, intWh, mrrId, DateTime.Now, enroll);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                    dgvReceive.DataSource = ""; dgvReceive.DataBind();
                    txtMrrRate.Text = "0"; txtSalesQty.Text = "0"; txtReceQty.Text = "0";
                    txtNaration.Text = ""; txtTransferID.Text = "";
                }
                else
                { }
            }
            catch { }
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvReceive.DataSource;
                dsGrid.Tables[0].Rows[dgvReceive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvReceive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvReceive.DataSource = ""; dgvReceive.DataBind(); }
                else { LoadGridwithXml(); }


            }

            catch { }
        }
         

        
    }
}