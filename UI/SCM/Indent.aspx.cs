using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class Indent : BasePage
    {
        private readonly Indents_BLL _objIndent = new Indents_BLL();
        private DataTable _dt = new DataTable();
        private readonly string xmlunit = "";
        private int _checkItem = 1;
        private string[] _arrayKey;
        private string _filePathForXml, _xmlString = "", _indentQty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _filePathForXml = Server.MapPath("~/SCM/Data/Inden__" + Enroll + ".xml");

            if (!IsPostBack)
            {
                _ast = new AutoSearch_BLL();
                try
                {
                    File.Delete(_filePathForXml);
                    dgvIndent.UnLoad();
                }
                catch
                {
                    // ignored
                }
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
        }

        private void DefaltLoad()
        {
            try
            {
                _dt = _objIndent.DataView(1, xmlunit, 0, 0, DateTime.Now, Enroll);
                ddlWH.Loads(_dt, "Id", "strName");

                _dt = _objIndent.DataView(2, xmlunit, int.Parse(ddlWH.SelectedValue), 0, DateTime.Now, Enroll);
                ddlQcPersonal.Loads(_dt, "Id", "strName");

                _dt = _objIndent.GetDepartment();
                ddlDepartment.LoadWithSelect(_dt, "intdepartmentID", "strDepatrment");

                _dt = _objIndent.DataView(3, xmlunit, 0, 0, DateTime.Now, Enroll);
                ddlReqId.Loads(_dt, "Id", "strName");

                _dt = _objIndent.DataView(11, "", 0, 0, DateTime.Now, Enroll);
                ddlType.Loads(_dt, "Id", "strName");

                try
                {
                    Session["WareID"] = ddlWH.SelectedValue;
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }

        }

        #region========================Action==================================

        protected void btnReq_Click(object sender, EventArgs e)
        {
            try
            {
                int reqId = int.Parse(ddlReqId.SelectedValue);
                string indentType = ddlType.SelectedItem.ToString();
                string purpose = txtPurpose.Text;
                string qcby = ddlQcPersonal.SelectedValue;
                _dt = _objIndent.DataView(5, xmlunit, ddlWH.SelectedValue(), reqId, DateTime.Now, Enroll);
                if (_dt.Rows.Count > 0 && int.Parse(ddlType.SelectedValue) > 0)
                {
                    for (int i = 0; _dt.Rows.Count > i; i++)
                    {
                        string itemId = _dt.Rows[i]["intItemID"].ToString();
                        string itemName = _dt.Rows[i]["strName"].ToString();
                        _indentQty = _dt.Rows[i]["numApproveQty"].ToString();
                        string reqCode = _dt.Rows[i]["reqCode"].ToString();
                        CheckXmlItemReqData(itemId, reqCode);
                        if (_checkItem == 1)
                        {
                            string uom = _dt.Rows[i]["strUom"].ToString();
                            string stock = _dt.Rows[i]["stockQty"].ToString();
                            string sftyStock = _dt.Rows[i]["numSafetyStock"].ToString();
                            string rate = _dt.Rows[i]["rate"].ToString();
                            _indentQty = _dt.Rows[i]["numApproveQty"].ToString();
                            int intDepartment = ddlDepartment.SelectedValue();
                            CreateXml(itemId, itemName, uom, stock, sftyStock, rate, _indentQty, reqCode, reqId.ToString(), indentType, purpose, qcby, intDepartment);
                        }
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
                DataSet dsGrid = (DataSet)dgvIndent.DataSource;
                dsGrid.Tables[0].Rows[dgvIndent.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(_filePathForXml);
                DataSet dsGridAfterDelete = (DataSet)dgvIndent.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(_filePathForXml);
                    dgvIndent.DataSource = "";
                    dgvIndent.DataBind();
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

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtItem.Text = "";
                try
                {
                    File.Delete(_filePathForXml);
                    dgvIndent.UnLoad();
                }
                catch
                {
                    // ignored
                }
                Session["WareID"] = ddlWH.SelectedValue;
                _dt = _objIndent.DataView(2, xmlunit, ddlWH.SelectedValue(), 0, DateTime.Now, Enroll);
                ddlQcPersonal.Loads(_dt, "Id", "strName");
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _arrayKey = txtItem.Text.Split(Variables.GetInstance().DelimiterChars);
                string itemid;
                if (_arrayKey.Length > 1)
                {
                    itemid = _arrayKey[1];
                }
                else
                {
                    Toaster("Please add Item name properly", Common.TosterType.Warning);
                    return;
                }
                string reqCode = "0";
                string reqId = "0";
                string indentType = ddlType.SelectedItem.ToString();
                string purpose = txtPurpose.Text;
                string qcby = ddlQcPersonal.SelectedValue;
                CheckXmlItemReqData(itemid, reqCode);
                if (_checkItem == 1)
                {
                    if (indentType.ToLower().Equals("select"))
                    {
                        Toaster("Please select type", Common.TosterType.Warning);
                        return;
                    }

                    // This code stop by alamin@akij.net
                    //dt = objIndent.DataView(4, xmlunit, intWh, int.Parse(itemid), DateTime.Now, Enroll);
                    if (decimal.TryParse(txtQty.Text, out decimal quantity))
                    {
                        if (quantity > 0)
                        {
                            _dt = new DataTable();
                            _dt = _objIndent.GetItemStockAndPrice(4, int.Parse(itemid), ddlWH.SelectedValue());
                            if (_dt.Rows.Count > 0 && decimal.Parse(txtQty.Text) > 0)
                            {
                                string itemId = _dt.Rows[0]["intItemID"].ToString();
                                string itemName = _dt.Rows[0]["strName"].ToString();
                                string uom = _dt.Rows[0]["strUom"].ToString();
                                string stock = _dt.Rows[0]["stockQty"].ToString();
                                string sftyStock = _dt.Rows[0]["numSafetyStock"].ToString();
                                string rate = _dt.Rows[0]["rate"].ToString();
                                int intDepartment = ddlDepartment.SelectedValue();

                                CreateXml(itemId, itemName, uom, stock, sftyStock, rate, quantity.ToString(CultureInfo.CurrentCulture), reqCode, reqId, indentType,
                                    purpose, qcby, intDepartment);
                            }
                            else
                            {
                                Toaster("Can not get items information", Common.TosterType.Warning);
                            }
                        }
                        else
                        {
                            Toaster("Quantity should be greater than 0", Common.TosterType.Warning);
                        }
                    }
                    else
                    {
                        Toaster("Input Quantity properly", Common.TosterType.Warning);
                    }

                }
                else
                {
                    Toaster(Message.AlreadyAdded.ToFriendlyString(), Common.TosterType.Warning);
                }
                txtItem.Text = "";
                txtQty.Text = @"0";
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }

            // string xmlunit = "<voucher><voucherentry itemId=" + '"' + ItemId + '"' + " SalesPrice=" + '"' + SalesPrice + '"' + " IssueQty=" + '"' + IssueQty + '"' + " rackId=" + '"' + RackId + '"' + " MrrId=" + '"' + MrrId + '"' + "/></voucher>".ToString();
        }
        private void CheckXmlItemReqData(string itemid, string reqCode)
        {
            try
            {
                DataSet ds = new DataSet();
                if (_filePathForXml.IsExist())
                {
                    ds.ReadXml(_filePathForXml);
                    int i;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()) &&
                            reqCode == (ds.Tables[0].Rows[i].ItemArray[7].ToString()))
                        {
                            _checkItem = 0;
                            break;
                        }
                        _checkItem = 1;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        #endregion======================Close==================================

        #region========================Auto Search============================

        private static AutoSearch_BLL _ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {

            return _ast.AutoSearchItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion====================Close======================================

        #region ===========================XML Data Bind=======================

        private void CreateXml(string itemId, string itemName, string uom, string stock, string sftyStock, string rate, string indentQty, string reqCode, string reqId, string indentType, string purpose, string qcby, int intDepartment)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(_filePathForXml))
            {
                doc.Load(_filePathForXml);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId, indentType, purpose, qcby, intDepartment);
                rootNode?.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId, indentType, purpose, qcby, intDepartment);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(_filePathForXml);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string itemName, string uom, string stock, string sftyStock, string rate, string indentQty, string reqCode, string reqId, string indentType, string purpose, string qcby, int intDepartment)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Stock = doc.CreateAttribute("stock");
            Stock.Value = stock;
            XmlAttribute SftyStock = doc.CreateAttribute("sftyStock");
            SftyStock.Value = sftyStock;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute IndentQty = doc.CreateAttribute("indentQty");
            IndentQty.Value = indentQty;
            XmlAttribute ReqCode = doc.CreateAttribute("reqCode");
            ReqCode.Value = reqCode;
            XmlAttribute ReqId = doc.CreateAttribute("reqId");
            ReqId.Value = reqId;
            XmlAttribute IndentType = doc.CreateAttribute("indentType");
            IndentType.Value = indentType;
            XmlAttribute Purpose = doc.CreateAttribute("purpose");
            Purpose.Value = purpose;
            XmlAttribute Qcby = doc.CreateAttribute("qcby");
            Qcby.Value = qcby;
            XmlAttribute department = doc.CreateAttribute("intDepartment");
            department.Value = intDepartment.ToString();

            node.Attributes.Append(ItemId);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Stock);

            node.Attributes.Append(SftyStock);
            node.Attributes.Append(Rate);
            node.Attributes.Append(IndentQty);
            node.Attributes.Append(ReqCode);
            node.Attributes.Append(ReqId);
            node.Attributes.Append(IndentType);
            node.Attributes.Append(Purpose);
            node.Attributes.Append(Qcby);
            node.Attributes.Append(department);
            return node;
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_filePathForXml);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                _xmlString = dSftTm?.InnerXml;
                _xmlString = "<voucher>" + _xmlString + "</voucher>";
                StringReader sr = new StringReader(_xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvIndent.DataSource = ds;
                }
                else
                {
                    dgvIndent.DataSource = "";
                }
                dgvIndent.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        #endregion ===========================Close=======================

        #region========================Data Submit Action=====================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(ddlType.SelectedValue) > 0)
                {
                    if (ddlDepartment.SelectedValue() > 0)
                    {
                        if (_filePathForXml.IsExist())
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(_filePathForXml);
                            XmlNode dSftTm = doc.SelectSingleNode("voucher");
                            _xmlString = dSftTm?.InnerXml;
                            _xmlString = "<voucher>" + _xmlString + "</voucher>";
                            string dueDate = txtDueDate.Text;
                            if (string.IsNullOrWhiteSpace(dueDate))
                            {
                                Toaster("Due date can not be blank", Common.TosterType.Warning);
                                return;
                            }
                            DateTime dtedate;
                            try
                            {
                                dtedate = DateTime.Parse(txtDueDate.Text);
                                if (dtedate.Date < DateTime.Now.Date)
                                {
                                    Toaster("Due date can not be eralier of present date", Common.TosterType.Warning);
                                    return;
                                }
                            }
                            catch
                            {
                                Toaster("Due " + Message.DateFormatError.ToFriendlyString(), Common.TosterType.Warning);
                                return;
                            }

                            try
                            {
                                File.Delete(_filePathForXml);
                            }
                            catch
                            {
                                // ignored
                            }
                            if (_xmlString.Length > 5)
                            {
                                string mrtg = _objIndent.IndentEntry(6, _xmlString, ddlWH.SelectedValue(), 0, dtedate,
                                    Enroll);
                                string[] searchKey = Regex.Split(mrtg, ":");
                                lblIndentNo.Text = @"Indent Number: " + searchKey[1];
                                Toaster(mrtg,
                                    mrtg.ToLower().Contains("sucessfully")
                                        ? Common.TosterType.Success
                                        : Common.TosterType.Error);
                                dgvIndent.UnLoad();
                            }
                        }
                        else
                        {
                            Toaster("You have not enought item to input",Common.TosterType.Warning);
                        }
                        
                    }
                    else
                    {
                        Toaster("Please select Department", Common.TosterType.Warning);
                    }

                }
                else
                {
                    Toaster("Please Select Indent Type", Common.TosterType.Warning);
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        #endregion======================Close=================================
    }
}