using Flogging.Core;
using GLOBAL_BLL;
using Purchase_BLL.Asset;
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

namespace UI.SCM
{
    public partial class Indent : BasePage
    {
        private Indents_BLL objIndent = new Indents_BLL();
        private DataTable dt = new DataTable();
        private AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
        private string xmlunit = ""; private int enroll, CheckItem = 1, intWh; private string[] arrayKey; private char[] delimiterChars = { '[', ']' };
        private string filePathForXML; private string xmlString = "", indentQty;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\Indent";
        private string stop = "stopping SCM\\Indent";
        private string perform = "Performance on SCM\\Indent";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Inden__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvIndent.DataSource = ""; dgvIndent.DataBind(); }
                catch { }
                DefaltLoad();
                pnlUpperControl.DataBind();
            }
            else { }
        }

        private void DefaltLoad()
        {
            var fd = log.GetFlogDetail(start, location, "DefaltLoad", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "DefaltLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objIndent.DataView(1, xmlunit, 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                dt = objIndent.DataView(2, xmlunit, int.Parse(ddlWH.SelectedValue), 0, DateTime.Now, enroll);
                ddlQcPersonal.DataSource = dt;
                ddlQcPersonal.DataTextField = "strName";
                ddlQcPersonal.DataValueField = "Id";
                ddlQcPersonal.DataBind();

                dt = objIndent.DataView(3, xmlunit, 0, 0, DateTime.Now, enroll);
                ddlReqId.DataSource = dt;
                ddlReqId.DataTextField = "strName";
                ddlReqId.DataValueField = "Id";
                ddlReqId.DataBind();

                dt = objIndent.DataView(11, "", 0, 0, DateTime.Now, enroll);
                ddlType.DataSource = dt;
                ddlType.DataTextField = "strName";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();
                try
                {
                    Session["WareID"] = ddlWH.SelectedValue;
                }
                catch { }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefaltLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "DefaltLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region========================Action==================================

        protected void btnReq_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnReq_Click Show", null);
            Flogger.WriteDiagnostic(fd);
            // starting performance tracker
            var tracker = new PerfTracker(perform + " " + "btnReq_Click Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                int reqId = int.Parse(ddlReqId.SelectedValue);
                string indentType = ddlType.SelectedItem.ToString();
                string purpose = txtPurpose.Text.ToString();
                string qcby = ddlQcPersonal.SelectedValue.ToString();
                dt = objIndent.DataView(5, xmlunit, intWh, reqId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0 && int.Parse(ddlType.SelectedValue) > 0)
                {
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        string itemId = dt.Rows[i]["intItemID"].ToString();
                        string itemName = dt.Rows[i]["strName"].ToString();
                        indentQty = dt.Rows[i]["numApproveQty"].ToString();
                        string reqCode = dt.Rows[i]["reqCode"].ToString();
                        CheckXmlItemReqData(itemId, reqCode);
                        if (CheckItem == 1)
                        {
                            string uom = dt.Rows[i]["strUom"].ToString();
                            string stock = dt.Rows[i]["stockQty"].ToString();
                            string sftyStock = dt.Rows[i]["numSafetyStock"].ToString();
                            string rate = dt.Rows[i]["rate"].ToString();
                            indentQty = dt.Rows[i]["numApproveQty"].ToString();
                            CreateXml(itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId.ToString(), indentType, purpose, qcby);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnReq_Click Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnReq_Click Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvIndent.DataSource;
                dsGrid.Tables[0].Rows[dgvIndent.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvIndent.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvIndent.DataSource = ""; dgvIndent.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "DefaltLoad", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "DefaltLoad", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                txtItem.Text = "";
                try { File.Delete(filePathForXML); dgvIndent.DataSource = ""; dgvIndent.DataBind(); }
                catch { }
                Session["WareID"] = ddlWH.SelectedValue;
                intWh = int.Parse(ddlWH.SelectedValue);
                dt = objIndent.DataView(2, xmlunit, intWh, 0, DateTime.Now, enroll);
                ddlQcPersonal.DataSource = dt;
                ddlQcPersonal.DataTextField = "strName";
                ddlQcPersonal.DataValueField = "Id";
                ddlQcPersonal.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "DefaltLoad", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "DefaltLoad", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = ""; string itemid = ""; bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString();
                }
                string reqCode = "0".ToString();
                string reqId = "0".ToString();
                string indentType = ddlType.SelectedItem.ToString();
                string purpose = txtPurpose.Text.ToString();
                string qcby = ddlQcPersonal.SelectedValue.ToString();
                CheckXmlItemReqData(itemid, reqCode);
                if (CheckItem == 1)
                {
                    if (indentType.ToLower().Equals("select"))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Please select type');", true);
                        return;
                    }
                    dt = objIndent.DataView(4, xmlunit, intWh, int.Parse(itemid), DateTime.Now, enroll);
                    if (dt.Rows.Count > 0 && decimal.Parse(txtQty.Text.ToString()) > 0)
                    {
                        string itemId = dt.Rows[0]["intItemID"].ToString();
                        string itemName = dt.Rows[0]["strName"].ToString();
                        string uom = dt.Rows[0]["strUom"].ToString();
                        string stock = dt.Rows[0]["stockQty"].ToString();
                        string sftyStock = dt.Rows[0]["numSafetyStock"].ToString();
                        string rate = dt.Rows[0]["rate"].ToString();
                        string indentQty = txtQty.Text.ToString();

                        CreateXml(itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId, indentType,
                            purpose, qcby);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('Qty is not found');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true);
                }
                txtItem.Text = ""; txtQty.Text = "0";
            }
            catch { }

            // string xmlunit = "<voucher><voucherentry itemId=" + '"' + ItemId + '"' + " SalesPrice=" + '"' + SalesPrice + '"' + " IssueQty=" + '"' + IssueQty + '"' + " rackId=" + '"' + RackId + '"' + " MrrId=" + '"' + MrrId + '"' + "/></voucher>".ToString();
        }

        private void CheckXmlItemData(string itemid)
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

        private void CheckXmlItemReqData(string itemid, string reqCode)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()) && reqCode == (ds.Tables[0].Rows[i].ItemArray[7].ToString()))
                    {
                        CheckItem = 0;
                        break;
                    }
                    CheckItem = 1;
                }
            }
            catch { }
        }

        #endregion======================Close==================================

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

        #region ===========================XML Data Bind=======================

        private void CreateXml(string itemId, string itemName, string uom, string stock, string sftyStock, string rate, string indentQty, string reqCode, string reqId, string indentType, string purpose, string qcby)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId, indentType, purpose, qcby);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, uom, stock, sftyStock, rate, indentQty, reqCode, reqId, indentType, purpose, qcby);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string itemName, string uom, string stock, string sftyStock, string rate, string indentQty, string reqCode, string reqId, string indentType, string purpose, string qcby)
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
                { dgvIndent.DataSource = ds; }
                else { dgvIndent.DataSource = ""; }
                dgvIndent.DataBind();
            }
            catch { }
        }

        #endregion ===========================Close=======================

        #region========================Data Submit Action=====================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnSubmit_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);

            try
            {
                if (int.Parse(ddlType.SelectedValue) > 0)
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWH.SelectedValue);
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    DateTime dtedate = DateTime.Parse(txtDueDate.Text.ToString());
                    try { File.Delete(filePathForXML); } catch { }
                    if (xmlString.Length > 5)
                    {
                        string mrtg = objIndent.IndentEntry(6, xmlString, intWh, 0, dtedate, enroll);
                        string[] searchKey = Regex.Split(mrtg, ":");
                        lblIndentNo.Text = "Indent Number: " + searchKey[1].ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                        dgvIndent.DataSource = "";
                        dgvIndent.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Indent Type');", true);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnSubmit_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        #endregion======================Close=================================
    }
}