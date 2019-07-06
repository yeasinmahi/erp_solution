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
using BLL.HR;
using BLL.Inventory;
using UI.ClassFiles;
using Utility;

namespace UI.SCM
{
    public partial class ReceiveWithoutPO : BasePage
    {
        private MrrReceive_BLL objRecive = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private Location_BLL objOperation = new Location_BLL();
        private ItemListBll itemList = new ItemListBll();

        private string xmlunit = "";
        private int CheckItem = 1, intWh;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Rcv__" + Enroll + ".xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                ast = new AutoSearch_BLL();
                try
                {
                    File.Delete(filePathForXML);
                    dgvRecive.UnLoad();
                }
                catch { }
                DefaultLoad();

            }
            else { }
        }

        private void DefaultLoad()
        {
            try
            {
                dt = objRecive.DataView(1, xmlunit, 0, 0, DateTime.Now, Enroll);
                ddlWH.Loads(dt, "Id", "strName");

                Session["WareID"] = ddlWH.SelectedValue;

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
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
                string item = "";
                string itemid = "";
                bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0];
                    itemid = arrayKey[1];
                }

                CheckXmlItemData(itemid);
                if (CheckItem == 1 && double.Parse(txtQty.Text) > 0)
                {
                    int itemsId = Convert.ToInt32(itemid);
                    dt = itemList.GetItem(itemsId);
                    if (dt.Rows.Count > 0)
                    {
                        string itemId = itemid;
                        string itemName = item;
                        string qty = txtQty.Text;
                        string rate = txtRate.Text;
                        string locationId = ddlLocation.SelectedValue;
                        string location = ddlLocation.SelectedItem.ToString();
                        string remarks = txtPurpose.Text;

                        int categoryId = Convert.ToInt32(dt.Rows[0]["intMasterCategory"].ToString());
                        int masterCombGroup = Convert.ToInt32(dt.Rows[0]["intMasterComGroup"].ToString());
                        if (categoryId == 45 || masterCombGroup == 37)
                        {
                            int unitId = new UnitBll().GetUnitIdByWhId(intWh);
                            decimal Rate = new InventoryTransfer_BLL().GetItemRate(itemsId, unitId);
                            if (Rate > 0)
                            {
                                rate = Rate.ToString();
                            }
                            else
                            {
                                Toaster("Item COGS price missing", Common.TosterType.Warning);
                                return;
                            }
                        }

                        CreateXml(itemId, itemName, qty, rate, locationId, location, remarks);
                    }
                    else
                    {
                        Toaster("Item information getting error", Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster("Item already added", Common.TosterType.Warning);
                }

                txtItem.Text = "";
                txtQty.Text = "0";
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        private void CreateXml(string itemId, string itemName, string qty, string rate, string locationId, string location, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, qty, rate, locationId, location, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemId, itemName, qty, rate, locationId, location, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridWithXml();
        }

        #region========================Data Submit Action=====================

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWH.SelectedValue);
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";

                    if (filePathForXML.IsExist())
                    {
                        File.Delete(filePathForXML);
                    }

                    if (xmlString.Length > 5)
                    {
                        string mrtg = objRecive.MrrReceive(18, xmlString, intWh, 0, DateTime.Now, Enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('" + mrtg + "');", true);
                        dgvRecive.UnLoad();
                    }
                }
            }
            catch
            {
                if (filePathForXML.IsExist())
                {
                    File.Delete(filePathForXML);
                }
            }
        }

        #endregion======================Close=================================

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridWithXml();
                DataSet dsGrid = (DataSet)dgvRecive.DataSource;
                dsGrid.Tables[0].Rows[dgvRecive.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvRecive.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvRecive.DataSource = ""; dgvRecive.DataBind(); }
                else { LoadGridWithXml(); }
            }
            catch { }
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWH.SelectedValue;
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWH.SelectedValue);
                string item = "";
                string itemid = "";
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0];
                    itemid = arrayKey[1];
                }

                dt = objOperation.WhDataView(8, "", intWh, int.Parse(itemid), 1);
                ddlLocation.Loads(dt, "intLocation", "strLocationName");
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        private XmlNode CreateItemNode(XmlDocument doc, string itemId, string itemName, string qty, string rate, string locationId, string location, string remarks)
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
            Locationid.Value = locationId;
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

        private void LoadGridWithXml()
        {
            try
            {
                if (filePathForXML.IsExist())
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
                    {
                        dgvRecive.DataSource = ds;
                    }
                    else
                    {
                        dgvRecive.DataSource = "";
                    }
                    dgvRecive.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }

        private void CheckXmlItemData(string itemId)
        {
            try
            {
                DataSet ds = new DataSet();
                if (filePathForXML.IsExist())
                {
                    ds.ReadXml(filePathForXML);
                    int i = 0;
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        if (itemId == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
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
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }
    }
}