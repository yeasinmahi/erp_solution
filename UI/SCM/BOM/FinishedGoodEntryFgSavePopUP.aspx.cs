using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM.BOM
{
    public partial class FinishedGoodEntryFgSavePopUP : BasePage
    {
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, enroll, BomId, intBomStandard; private string xmlData;
        private int CheckItem = 1, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "";

        private string productionID, itemId, productName, bomName, batchName, startTime, endTime, invoice, srNo, quantity, whid;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMatf__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvStore.DataSource = ""; dgvStore.DataBind(); }
                catch { }
                claenderDte.SelectedDate = DateTime.Now;
                productionID = Request.QueryString["productID"].ToString();
                productName = Request.QueryString["productName"].ToString();
                bomName = Request.QueryString["bomName"].ToString();
                batchName = Request.QueryString["batchName"].ToString();
                DateTime startTime = DateTime.Parse(Request.QueryString["startTime"].ToString());
                DateTime endTime = DateTime.Parse(Request.QueryString["endTime"].ToString());
                invoice = Request.QueryString["invoice"].ToString();
                srNo = Request.QueryString["srNo"].ToString();
                quantity = Request.QueryString["quantity"].ToString();
                whid = Request.QueryString["whid"].ToString();
                itemId = Request.QueryString["itemId"].ToString();
                lblProductName.Text = productName;
                lblProductionId.Text = productionID;
                lblDate.Text = startTime.ToString("yyyy-MM-dd") + " TO " + endTime.ToString("yyyy-MM-dd");
                txtTime.Text = startTime.ToString("HH:ss");
                txtProductQty.Text = quantity.ToString();
                lblPlanQty.Text = quantity.ToString();

                txtItem.Text = productName + "[" + itemId + "]";
                txtProductQty.Visible = true;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(8, xmlData, intwh, int.Parse(productionID), DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    //txtItem.Text = dt.Rows[0]["strName"].ToString();
                    lblPlanQty.Text = dt.Rows[0]["numProdQty"].ToString();

                    dgvProductionEntry.DataSource = dt;
                    dgvProductionEntry.DataBind();
                }
            }
        }

        #region========================Auto Search============================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();
            return objBoms.AutoSearchBomId(HttpContext.Current.Session["Unit"].ToString(), prefixText, 1);
        }

        #endregion====================Close======================================

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);

                string item = ""; string itemid = ""; string uom = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); uom = arrayKey[1].ToString(); itemid = arrayKey[3].ToString(); }
                string[] searchKey = Regex.Split(uom, ":");
                lblUom1.Text = searchKey[1].ToString(); lblUom2.Text = searchKey[1].ToString();
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
                { item = arrayKey[0].ToString(); uom = arrayKey[1].ToString(); itemid = arrayKey[3].ToString(); }

                checkXmlItemData(itemid);
                if (CheckItem == 1)
                {
                    if (double.Parse(txtProductQty.Text.ToString()) > 0 || double.Parse(txtSendToStore.Text.ToString()) > 0)
                    {
                        string struom = lblUom1.Text.ToString();
                        string qty = txtProductQty.Text.ToString();
                        string storeQty = txtSendToStore.Text.ToString();
                        string jobno = txtJob.Text.ToString();
                        string times = txtTime.Text.ToString();
                        CreateXml(item, itemid, struom, qty, storeQty, jobno, times);
                    }
                    else { }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true);
                }
            }
            catch { }
        }

        private void CreateXml(string item, string itemid, string struom, string qty, string storeQty, string jobno, string times)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, struom, qty, storeQty, jobno, times);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, struom, qty, storeQty, jobno, times);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string struom, string qty, string storeQty, string jobno, string times)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Struom = doc.CreateAttribute("struom");
            Struom.Value = struom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute StoreQty = doc.CreateAttribute("storeQty");
            StoreQty.Value = storeQty;
            XmlAttribute Jobno = doc.CreateAttribute("jobno");
            Jobno.Value = jobno;
            XmlAttribute Times = doc.CreateAttribute("times");
            Times.Value = times;

            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Struom);
            node.Attributes.Append(Qty);

            node.Attributes.Append(StoreQty);
            node.Attributes.Append(Jobno);
            node.Attributes.Append(Times);

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

        protected void btnSaves_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(Request.QueryString["whid"].ToString());
                    int productionId = int.Parse(Request.QueryString["productID"].ToString());
                    DateTime dteDate = DateTime.Parse(txtDate.Text.ToString());
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string msg = objBom.BomPostData(9, xmlString, intWh, productionId, DateTime.Now, enroll);

                        dgvStore.DataSource = "";
                        dgvStore.DataBind();
                        txtProductQty.Text = "0";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                    }
                }
            }
            catch { try { File.Delete(filePathForXML); } catch { } }
        }
    }
}