﻿using SCM_BLL;
using System;
using System.Collections.Generic;
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

namespace UI.SCM.BOM
{
    public partial class ProductionOrder : BasePage
    {
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Inden__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvBom.DataSource = ""; dgvBom.DataBind(); }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }
            }
            else { }
        }
        #region========================Auto Search============================ 
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL(); 
            return objBoms.AutoSearchBomId(HttpContext.Current.Session["Unit"].ToString(), prefixText);

        } 
        #endregion====================Close======================================

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvBom.DataSource;
                dsGrid.Tables[0].Rows[dgvBom.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvBom.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvBom.DataSource = ""; dgvBom.DataBind(); }
                else { LoadGridwithXml(); }


            }

            catch { }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString(); }
                string fromtime = ddlFromTime.SelectedItem.ToString();
                DateTime startTime = DateTime.Parse(fromtime.ToString());
                string toTime = ddlFromToTime.SelectedItem.ToString();
                DateTime endTime = DateTime.Parse(toTime.ToString());
                string bomid = ddlBom.SelectedValue.ToString();
                string bomName = ddlBom.SelectedItem.ToString();
                string quantity = txtQty.Text.ToString();
                string lineprocess = ddlLine.SelectedValue.ToString();
                string invoice = txtInvoice.Text.ToString();
                string batch = txtBatchNo.Text.ToString();
                fromtime = startTime.ToString();
                toTime = endTime.ToString();
                CreateXml(item, itemid, fromtime, toTime, bomid, bomName,quantity, lineprocess, invoice, batch);

            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                    
                }
            }
            catch { }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString(); }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(2, xmlData, intwh, int.Parse(itemid), DateTime.Now, enroll);
                ddlBom.DataSource = dt;
                ddlBom.DataTextField = "strName";
                ddlBom.DataValueField = "Id";
                ddlBom.DataBind();

            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                if (hdnConfirm.Value.ToString() == "1")
                {
                    try { File.Delete(filePathForXML); }
                    catch { }

                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWH.SelectedValue);
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    DateTime dteDate = DateTime.Parse(txtdteDate.Text.ToString());

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string msg = objBom.BomPostData(5, xmlString, intWh, BomId, dteDate, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvBom.DataSource = "";
                        dgvBom.DataBind();

                    }

                }

            }
            catch { try { File.Delete(filePathForXML); } catch { } }
        }

        private void CreateXml(string item, string itemid, string fromtime, string toTime, string bomid,string bomName, string quantity, string lineprocess, string invoice,string batch)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, fromtime, toTime, bomid, bomName, quantity, lineprocess, invoice, batch);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, fromtime, toTime, bomid, bomName, quantity, lineprocess, invoice, batch);
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
                { dgvBom.DataSource = ds; }

                else { dgvBom.DataSource = ""; }
                dgvBom.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string fromtime, string toTime, string bomid,string bomName, string quantity, string lineprocess, string invoice,string batch)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Fromtime = doc.CreateAttribute("fromtime");
            Fromtime.Value = fromtime;
            XmlAttribute ToTime = doc.CreateAttribute("toTime");
            ToTime.Value = toTime;
            XmlAttribute Bomid = doc.CreateAttribute("bomid");
            Bomid.Value = bomid;
            XmlAttribute BomName = doc.CreateAttribute("bomName");
            BomName.Value = bomName;
            
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Lineprocess = doc.CreateAttribute("lineprocess");
            Lineprocess.Value = lineprocess;
            XmlAttribute Invoice = doc.CreateAttribute("invoice");
            Invoice.Value = invoice;

            XmlAttribute Batch = doc.CreateAttribute("batch");
            Batch.Value = batch;



            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Fromtime);
            node.Attributes.Append(ToTime);

            node.Attributes.Append(Bomid);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Lineprocess);

            node.Attributes.Append(Invoice);
            node.Attributes.Append(Batch);

       
            node.Attributes.Append(BomName);

            
            return node;
        }
    }
}