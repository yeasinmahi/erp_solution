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
    public partial class BillOfMaterial : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, enroll, BomId, intBomStandard; private string xmlData;
        private int CheckItem = 1, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMat__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvRecive.DataSource = ""; dgvRecive.DataBind(); }
                catch { }

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
                dt = objBom.GetBomData(15, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    try { Session["Unit"] = hdnUnit.Value; } catch { }
                }
            }
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
                    checkXmlItemData(itemid);
                    if (CheckItem == 1)
                    {
                        string qty = txtQuantity.Text.ToString();
                        string wastage = txtWastage.Text.ToString();
                        string bomname = txtBomName.Text.ToString();
                        string strCode = txtCode.Text.ToString();
                        CreateXml(itemid, item, uom, qty, wastage, bomname, strCode);
                        txtItem.Text = "";
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                }
            }
            catch { }
        }

        private void CreateXml(string itemid, string item, string uom, string qty, string wastage, string bomname, string strCode)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemid, item, uom, qty, wastage, bomname, strCode);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemid, item, uom, qty, wastage, bomname, strCode);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string item, string uom, string qty, string wastage, string bomname, string strCode)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Wastage = doc.CreateAttribute("wastage");
            Wastage.Value = wastage;
            XmlAttribute Bomname = doc.CreateAttribute("bomname");
            Bomname.Value = bomname;
            XmlAttribute StrCode = doc.CreateAttribute("strCode");
            StrCode.Value = strCode;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Item);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);

            node.Attributes.Append(Wastage);
            node.Attributes.Append(Bomname);
            node.Attributes.Append(StrCode);

            return node;
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

                    arrayKey = txtBomItem.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWH.SelectedValue);
                    string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString(); }
                    int bomid = int.Parse(itemid.ToString());

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string msg = objBom.BomPostData(4, xmlString, intWh, bomid, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvRecive.DataSource = "";
                        dgvRecive.DataBind();
                        txtCode.Text = "";
                        txtBomName.Text = "";
                        txtQuantity.Text = "0";
                        txtWastage.Text = "0";
                        txtItem.Text = "";
                    }
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
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

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            intwh = int.Parse(ddlWH.SelectedValue);
            txtBomItem.Text = "";
            txtItem.Text = "";
            txtBomName.Text = "";
            dt = objBom.GetBomData(15, xmlData, intwh, BomId, DateTime.Now, enroll);
            if (dt.Rows.Count > 0)
            {
                hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                try { Session["Unit"] = hdnUnit.Value; } catch { }
            }
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

        protected void txtBomItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtBomItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString(); }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(2, xmlData, intwh, int.Parse(itemid), DateTime.Now, enroll);
                ListDatas.DataSource = dt;
                ListDatas.DataTextField = "strName";
                ListDatas.DataValueField = "Id";
                ListDatas.DataBind();
                txtBomName.Text = "";
            }
            catch { }
        }

        protected void ListDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML); dgvRecive.DataSource = ""; dgvRecive.DataBind(); }
                catch { }

                txtBomName.Text = "";
                BomId = int.Parse(ListDatas.SelectedValue.ToString());
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(3, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string qty = dt.Rows[i]["numQty"].ToString();
                        string wastage = dt.Rows[i]["numWastagePercent"].ToString();
                        string bomname = dt.Rows[i]["strBoMName"].ToString();
                        string strCode = dt.Rows[i]["strBoMCode"].ToString();

                        string itemid = dt.Rows[i]["intItemID"].ToString();
                        string item = dt.Rows[i]["strItem"].ToString();
                        string uom = dt.Rows[i]["strUoM"].ToString();
                        txtBomName.Text = bomname; txtCode.Text = strCode;
                        CreateXml(itemid, item, uom, qty, wastage, bomname, strCode);
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

        #region========================Auto Search============================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();

            return objBoms.AutoSearchBomId(HttpContext.Current.Session["Unit"].ToString(), prefixText, 1);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemBomSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();

            return objBoms.AutoSearchBomId(HttpContext.Current.Session["Unit"].ToString(), prefixText, 2);
        }

        #endregion====================Close======================================
    }
}