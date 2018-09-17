using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;
using System.IO;
using System.Data;
using System.Xml;
using SAD_BLL.AEFPS;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.AEFPS
{
    public partial class TransferOutN : BasePage
    {
        #region ===== Variable Decliaration =======================================================
        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        DataTable dt;

        int intPart, intWHID, intEnroll, intItemID, intToWHID, intInsertBy;
        decimal numQuantity, numStockQty;
        string itemid, itemcode, itemname, uom, qty, filePathForXML, xmlString = "", xml, strVoucher;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;

        #endregion ================================================================================
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\TransferOutN";
        string stop = "stopping AEFPS\\TransferOutN";

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/AEFPS/Data/Transfer_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXML); dgvProduct.DataSource = ""; dgvProduct.DataBind();
                pnlUpperControl.DataBind();

                intPart = 1;
                intWHID = 0;
                intEnroll = int.Parse(hdnEnroll.Value);
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlFromWH.DataTextField = "strWH";
                ddlFromWH.DataValueField = "intInventoryWHID";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();

                intPart = 2;
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlToWHName.DataTextField = "strWH";
                ddlToWHName.DataValueField = "intInventoryWHID";
                ddlToWHName.DataSource = dt;
                ddlToWHName.DataBind();
            }
        }

        #region ===== Product Search Web Method ===================================================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
            return obj.GetItemName(1, prefixText);
        }               
        #endregion ================================================================================

        #region ===== Selection Change Event ======================================================
        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {            
            try
            {
                char[] ch = { '[', ']' };
                string[] temp = txtItem.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                intItemID = int.Parse(temp[5].ToString());
            }
            catch { }

            StockQty();
        }
        private void StockQty()
        {
            try
            {
                intPart = 3;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                numQuantity = 0;

                dt = new DataTable();
                dt = obj.GetProductStockAndPrice(intPart, intWHID, intItemID, numQuantity);
                if (dt.Rows.Count > 0)
                {
                    txtStockQty.Text = dt.Rows[0]["numStockQty"].ToString();
                }
                else { txtStockQty.Text = "0"; }
            }
            catch { }
        }
        #endregion ================================================================================

        #region ===== Add Product =================================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ProductAdd();
        }
        private void ProductAdd()
        {
            try
            {
                char[] ch = { '[', ']' };
                string[] temp = txtItem.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                
                itemname = temp[0].ToString();
                uom = temp[1].ToString();                
                itemcode = temp[3].ToString();
                itemid = temp[5].ToString();
            }
            catch { }

            qty = txtQty.Text;
            numStockQty = decimal.Parse(txtStockQty.Text);
            if(decimal.Parse(qty) > numStockQty)
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock Not Available.');", true); return; }

            #region ===== Product Qty Update ==================================================
            int intCount = 0;

            if (dgvProduct.Rows.Count > 0)
            {
                for (int index = 0; index < dgvProduct.Rows.Count; index++)
                {
                    string olditemid = ((Label)dgvProduct.Rows[index].FindControl("lblItemID")).Text.ToString();
                    string oldqty = ((Label)dgvProduct.Rows[index].FindControl("lblQuantity")).Text.ToString();

                    if (olditemid == itemid)
                    {
                        decimal decNewQty = (decimal.Parse(qty) + decimal.Parse(oldqty));
                        if (decNewQty > numStockQty)
                        { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Stock Not Available.');", true); return; }
                        
                        ((Label)dgvProduct.Rows[index].FindControl("lblQuantity")).Text = decNewQty.ToString();                       
                        intCount = intCount + 1;
                    }
                }
            }

            if (intCount < 1)
            {
                if (itemid != "" && itemcode != "" && itemname != "" && uom != "" && qty != "")
                {
                    CreateVoucherXml(itemid, itemcode, itemname, uom, qty);                    
                }
            }

            txtQRCode.Text = "";
            txtItem.Text = "";
            txtStockQty.Text = "";
            txtQty.Text = "";
            
            #endregion ========================================================================
        }
        private void CreateVoucherXml(string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Product");
                XmlNode addItem = CreateItemNode(doc, itemid, itemcode, itemname, uom, qty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Product");
                XmlNode addItem = CreateItemNode(doc, itemid, itemcode, itemname, uom, qty); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("Product");
            xmlString = dSftTm.InnerXml;
            xmlString = "<Product>" + xmlString + "</Product>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvProduct.DataSource = ds; }
            else { dgvProduct.DataSource = ""; }
            dgvProduct.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlNode node = doc.CreateElement("Product");

            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Itemcode = doc.CreateAttribute("itemcode");
            Itemcode.Value = itemcode;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemcode);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            return node;
        }
        protected void dgvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Product");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Product>" + xmlString + "</Product>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvProduct.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvProduct.DataSource;
                dsGrid.Tables[0].Rows[dgvProduct.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvProduct.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvProduct.DataSource = ""; dgvProduct.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected decimal totalqty = 0;
        #endregion ================================================================================

        #region ===== Final Submit ================================================================        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on AEFPS\\TransferOutN Transfer Out Save", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                    File.Delete(filePathForXML);
                if (dgvProduct.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvProduct.Rows.Count; index++)
                    {
                        itemname = ((Label)dgvProduct.Rows[index].FindControl("lblProductName")).Text.ToString();
                        uom = ((Label)dgvProduct.Rows[index].FindControl("lblUOM")).Text.ToString();
                        itemcode = ((Label)dgvProduct.Rows[index].FindControl("lblProductCode")).Text.ToString();
                        itemid = ((Label)dgvProduct.Rows[index].FindControl("lblItemID")).Text.ToString();
                        qty = ((Label)dgvProduct.Rows[index].FindControl("lblQuantity")).Text.ToString();

                        if (itemid != "" && itemcode != "" && itemname != "" && uom != "" && qty != "")
                        {
                            CreateVoucherXmlSubmit(itemid, itemcode, itemname, uom, qty);
                        }
                    }
                }

                intPart = 1;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                intEnroll = int.Parse(hdnEnroll.Value);
                strVoucher = txtQRCode.Text;
                intInsertBy = int.Parse(hdnEnroll.Value);
                
                if (dgvProduct.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("Product");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<Product>" + xmlString + "</Product>";
                        xml = xmlString;
                    }
                    catch { }
                    if (xml == "") { return; }
                }

                //Final In Insert                        
                string message = obj.TransferFinalInsert(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                hdnconfirm.Value = "0";
                File.Delete(filePathForXML); dgvProduct.DataSource = ""; dgvProduct.DataBind();
                txtQRCode.Text = ""; txtItem.Text = ""; txtQty.Text = "";
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
        }
        private void CreateVoucherXmlSubmit(string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Product");
                XmlNode addItem = CreateItemNodeSubmit(doc, itemid, itemcode, itemname, uom, qty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Product");
                XmlNode addItem = CreateItemNodeSubmit(doc, itemid, itemcode, itemname, uom, qty); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNodeSubmit(XmlDocument doc, string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlNode node = doc.CreateElement("Product");

            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Itemcode = doc.CreateAttribute("itemcode");
            Itemcode.Value = itemcode;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemcode);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            return node;
        }
        #endregion ================================================================================









    }
}