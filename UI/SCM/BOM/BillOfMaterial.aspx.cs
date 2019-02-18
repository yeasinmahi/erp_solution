using SCM_BLL;
using System;
using System.Collections;
using System.Collections.Generic;
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

namespace UI.SCM.BOM
{
    public partial class BillOfMaterial : BasePage
    {
        private readonly Bom_BLL _bll = new Bom_BLL();
        private DataTable _dt = new DataTable();
        private int _intwh;
        private int _bomId;
        private int _checkItem = 1;
        private int _intWh;
        private string _xmlData, _filePathForXml, _xmlString = "";
        private string[] _arrayKey;
        private readonly char[] _delimiterChars = { '[', ']' };
        private readonly object _locker = new object();
        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SCM/Data/BomMat__" + Enroll + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(_filePathForXml);
                    dgvRecive.UnLoad();
                }
                catch { }

                _dt = _bll.GetBomData(1, _xmlData, _intwh, _bomId, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    ddlWH.Loads(_dt, "Id", "strName");
                }
                _intwh = ddlWH.SelectedValue();
                _dt = _bll.GetBomData(15, _xmlData, _intwh, _bomId, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0)
                {
                    hdnUnit.Value = _dt.Rows[0]["intunit"].ToString();
                    try
                    {
                        Session["Unit"] = hdnUnit.Value;
                    }
                    catch (Exception ex)
                    {
                        Toaster(ex.Message, Common.TosterType.Error);
                    }
                }
            }
        }

        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _arrayKey = txtItem.Text.Split(_delimiterChars);
                _intWh = ddlWH.SelectedValue();
                string item = "";
                string itemid = "";
                string uom = "";
                if (_arrayKey.Length > 0)
                {
                    item = _arrayKey[0];
                    uom = _arrayKey[2];
                    itemid = _arrayKey[3];
                }
                CheckXmlItemData(itemid);
                if (_checkItem == 1)
                {
                    string qty = txtQuantity.Text;
                    string wastage = txtWastage.Text;
                    string bomname = txtBomName.Text;
                    string strCode = txtCode.Text;
                    CreateXml(itemid, item, uom, qty, wastage, bomname, strCode);
                    txtItem.Text = "";
                }
                else
                {
                    LoadGridwithXml();
                    Toaster("Item already added", Common.TosterType.Warning);
                }


            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        private void CreateXml(string itemid, string item, string uom, string qty, string wastage, string bomname, string strCode)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(_filePathForXml))
            {
                doc.Load(_filePathForXml);
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
            doc.Save(_filePathForXml);
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
                btnSubmit.Enabled = false;
                lock (_locker)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_filePathForXml);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    _xmlString = dSftTm.InnerXml;
                    _xmlString = "<voucher>" + _xmlString + "</voucher>";

                    _arrayKey = txtBomItem.Text.Split(_delimiterChars);
                    _intWh = ddlWH.SelectedValue();
                    string item = "";
                    string itemid = "";
                    string uom = "";
                    bool proceed = false;
                    itemid = _arrayKey[_arrayKey.Length - 2];
                    int bomid = int.Parse(itemid);

                    try
                    {
                        File.Delete(_filePathForXml);
                    }
                    catch
                    {
                    }
                    if (_xmlString.Length > 5)
                    {
                        string msg = _bll.BomPostData(4, _xmlString, _intWh, bomid, DateTime.Now, Enroll);
                        Toaster(msg,
                            msg.ToLower().Contains("success") ? Common.TosterType.Success : Common.TosterType.Error);
                        dgvRecive.UnLoad();

                        txtCode.Text = "";
                        txtBomName.Text = "";
                        txtQuantity.Text = "0";
                        txtWastage.Text = "0";
                        txtItem.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {

                Toaster(ex.Message, Common.TosterType.Error);

                try
                {
                    File.Delete(_filePathForXml);
                }
                catch
                {
                }
            }
            finally
            {
                btnSubmit.Enabled = true;
            }
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_filePathForXml);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                _xmlString = dSftTm.InnerXml;
                _xmlString = "<voucher>" + _xmlString + "</voucher>";
                StringReader sr = new StringReader(_xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvRecive.DataSource = ds;
                }
                else
                {
                    dgvRecive.DataSource = "";
                }
                dgvRecive.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            _intwh = ddlWH.SelectedValue();
            txtBomItem.Text = "";
            txtItem.Text = "";
            txtBomName.Text = "";
            txtQuantity.Text = "0";
            txtWastage.Text = "0";
            txtCode.Text = "0";
            dgvRecive.UnLoad();
            _filePathForXml.DeleteFile();

            _dt = _bll.GetBomData(15, _xmlData, _intwh, _bomId, DateTime.Now, Enroll);
            if (_dt.Rows.Count > 0)
            {
                hdnUnit.Value = _dt.Rows[0]["intunit"].ToString();
                try
                {
                    Session["Unit"] = hdnUnit.Value;
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }
        }

        private void CheckXmlItemData(string itemid)
        {
            try
            {
                DataSet ds = new DataSet();
                if (_filePathForXml.IsExist())
                {
                    ds.ReadXml(_filePathForXml);
                    int i = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                        {
                            _checkItem = 0;
                            break;
                        }
                        else
                        {
                            _checkItem = 1;
                        }
                    }
                }
                else
                {
                    // file not found
                }

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void txtBomItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _arrayKey = txtBomItem.Text.Split(_delimiterChars);
                _intWh = int.Parse(ddlWH.SelectedValue);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                itemid = _arrayKey[_arrayKey.Length - 2];
                //if (arrayKey.Length > 0)
                //{
                //    item = arrayKey[0].ToString();
                //    uom = arrayKey[2].ToString();
                //    itemid = arrayKey[5].ToString();
                //}
                _dt = _bll.GetBomData(2, _xmlData, _intwh, int.Parse(itemid), DateTime.Now, Enroll);
                ListDatas.DataSource = _dt;
                ListDatas.DataTextField = "strName";
                ListDatas.DataValueField = "Id";
                ListDatas.DataBind();
                txtBomName.Text = "";
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void ListDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    File.Delete(_filePathForXml);
                    dgvRecive.UnLoad();
                }
                catch { }

                txtBomName.Text = "";
                _bomId = int.Parse(ListDatas.SelectedValue);
                _dt = _bll.GetBomData(3, _xmlData, _intwh, _bomId, DateTime.Now, Enroll);
                lblBomName.Text = ListDatas.SelectedItem.Text;
                if (_dt.Rows.Count > 0)
                {

                    for (int i = 0; i < _dt.Rows.Count; i++)
                    {
                        string qty = _dt.Rows[i]["numQty"].ToString();
                        string wastage = _dt.Rows[i]["numWastagePercent"].ToString();
                        string bomname = "0";//dt.Rows[i]["strBoMName"].ToString();
                        string strCode = "0"; //dt.Rows[i]["strBoMCode"].ToString();

                        string itemid = _dt.Rows[i]["intItemID"].ToString();
                        string item = _dt.Rows[i]["strItem"].ToString();
                        string uom = _dt.Rows[i]["strUoM"].ToString();
                        txtCode.Text = strCode;
                        CreateXml(itemid, item, uom, qty, wastage, bomname, strCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvRecive.DataSource;
                dsGrid.Tables[0].Rows[dgvRecive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(_filePathForXml);
                DataSet dsGridAfterDelete = (DataSet)dgvRecive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(_filePathForXml);
                    dgvRecive.UnLoad();
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        #region========================Auto Search============================

        private static readonly Bom_BLL BomBll = new Bom_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            return BomBll.AutoSearchFG(HttpContext.Current.Session["Unit"].ToString(), prefixText, 1);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemBomSerach(string prefixText, int count)
        {
            return BomBll.AutoSearchFG(HttpContext.Current.Session["Unit"].ToString(), prefixText, 2);
        }

        #endregion====================Close======================================
    }
}