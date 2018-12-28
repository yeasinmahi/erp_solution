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

namespace UI.SCM.BOM
{
    public partial class ProductionOrder : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, enroll, BomId; private string xmlData;
        private int CheckItem = 1, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Pro__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvBom.DataSource = ""; dgvBom.DataBind(); }
                catch { }

                DefaultDataBind();
            }
            else { }
        }

        private void DefaultDataBind()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();
                }

                intwh = int.Parse(ddlWH.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }
            }
            catch { }
        }

        #region========================Auto Search============================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();
            return objBoms.AutoSearchBomId(HttpContext.Current.Session["unit"].ToString(), prefixText, 1);
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
                if (hdnPreConfirm.Value == "1")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWH.SelectedValue);
                    string item = ""; string itemid = ""; string uom = "";
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString(); }
                    string fromtime = ddlFromTime.SelectedItem.ToString();

                    string toTime = ddlFromToTime.SelectedItem.ToString();

                    DateTime dteFrom = DateTime.Parse(txtdteDate.Text);
                    string a = dteFrom.ToString("yyyy-MM-dd") + " " + fromtime;
                    DateTime startTime = DateTime.Parse(a.ToString());

                    DateTime dteTo = DateTime.Parse(txtdteDate.Text);
                    string b = dteFrom.ToString("yyyy-MM-dd") + " " + toTime;
                    DateTime endTime = DateTime.Parse(b.ToString());
                    var hours = (endTime - startTime).TotalHours;
                    if (hours <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('End time cannot be equal to or less than start time.');", true);
                    }
                    else if (hours > 24)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Production time cannot be greater than 24 hours.');", true);
                    }
                    else
                    {
                        checkXmlItemData(itemid);
                        if (CheckItem == 1)
                        {
                            string bomid = ddlBom.SelectedValue.ToString();
                            string bomName = ddlBom.SelectedItem.ToString();
                            string quantity = txtQty.Text.ToString();
                            string lineprocess = ddlLine.SelectedValue.ToString();
                            string invoice = txtInvoice.Text.ToString();
                            string batch = txtBatchNo.Text.ToString();
                            fromtime = startTime.ToString();
                            toTime = endTime.ToString();
                            CreateXml(item, itemid, fromtime, toTime, bomid, bomName, quantity, lineprocess, invoice, batch);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                    }
                }
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

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intwh = int.Parse(ddlWH.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }
                txtItem.Text = string.Empty;
                txtBatchNo.Text = string.Empty;
                txtInvoice.Text = string.Empty;
                txtQty.Text = @"0";
                txtdteDate.Text = string.Empty;
                Utility.Common.UnLoadDropDown(ddlBom);
                Utility.Common.UnLoadDropDown(ddlLine);
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

                //dt = objBom.GetBomData(14, xmlData, intWh, int.Parse(itemid), DateTime.Now, enroll);
                //ddlStation.DataSource = dt;
                //ddlStation.DataTextField = "strName";
                //ddlStation.DataValueField = "Id";
                //ddlStation.DataBind();
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
                        dgvBom.DataSource = "";
                        dgvBom.DataBind();
                        txtBatchNo.Text = ""; txtQty.Text = "0"; txtItem.Text = ""; txtInvoice.Text = "";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
        }

        private void CreateXml(string item, string itemid, string fromtime, string toTime, string bomid, string bomName, string quantity, string lineprocess, string invoice, string batch)
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

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string fromtime, string toTime, string bomid, string bomName, string quantity, string lineprocess, string invoice, string batch)
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