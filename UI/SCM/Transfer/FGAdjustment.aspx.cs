using Purchase_BLL.Asset;
using SCM_BLL;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using BLL.HR;
using Utility;

namespace UI.SCM.Transfer
{
    public partial class FGAdjustment : BasePage
    {
        #region INIT
        private InventoryTransfer_BLL objTransfer = new InventoryTransfer_BLL();
        private Location_BLL objOperation = new Location_BLL();
        private StoreIssue_BLL objWH = new StoreIssue_BLL();
        private DataTable dt = new DataTable();
        private string xmlString, filePathForXML;
        private int Id;
        private int enroll, intvehicleId, intWh;
        private string[] arrayKey, arrayKeyV;
        private char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1;
        private decimal values;
        private string connectString;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {

            filePathForXML = Server.MapPath("~/SCM/Data/adj__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                ast = new AutoSearch_BLL();
                try
                {
                    File.Delete(filePathForXML);
                    dgvStore.DataSource = "";
                    dgvStore.DataBind();
                }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                dt = objTransfer.GetTtransferDatas(1, xmlString, intWh, Id, DateTime.Now, enroll);
                ddlWh.DataSource = dt;
                ddlWh.DataTextField = "strName";
                ddlWh.DataValueField = "Id";
                ddlWh.DataBind();
                ddlWh.Items.Insert(0, new ListItem("Select", "0"));
                Session["WareID"] = ddlWh.SelectedValue.ToString();
            }
        }
        #endregion

        #region Event
        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["WareID"] = ddlWh.SelectedValue.ToString();
                txtItem.Text = ""; txtRemarks.Text = "";
                ddlLcation.DataSource = "";
                ddlLcation.DataBind();

                hdnStockQty.Value = "0";
            }
            catch { }
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    uom = arrayKey[3].ToString();
                    itemid = arrayKey[1].ToString();
                }
                Id = int.Parse(itemid.ToString());
                intWh = int.Parse(ddlWh.SelectedValue);

                dt = objOperation.WhDataView(8, "", intWh, Id, 1);
                ddlLcation.DataSource = dt;
                ddlLcation.DataValueField = "intLocation";
                ddlLcation.DataTextField = "strLocationName";
                ddlLcation.DataBind();

                //int UnitId = objTransfer.GetSingleUnit(intWh);
                decimal Rate = objTransfer.GetItemRate(Id, UnitId);
                hfRate.Value = Rate.ToString();
                dt = objTransfer.GetItemDetailsData(Id, intWh);
                if(dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        hfCurrentStock.Value = dt.Rows[0]["current_stock"].ToString();
                        hfCurrentValue.Value = dt.Rows[0]["total_amount"].ToString();
                        //hfRate.Value = dt.Rows[0]["unit_price"].ToString();

                    }
                }

                txtCurrentStock.Text = !string.IsNullOrEmpty(hfCurrentStock.Value) ? hfCurrentStock.Value : "0";
            }
            catch
            {
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                string remarks = string.Empty;
                decimal monValue = 0;
                decimal newValue = 0;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    uom = arrayKey[3].ToString();
                    itemid = arrayKey[1].ToString();
                }

                string locationId = ddlLcation.SelectedValue.ToString();
                string locationName = ddlLcation.SelectedValue.ToString();
                decimal currentStock = !string.IsNullOrEmpty(hfCurrentStock.Value) ? decimal.Parse(hfCurrentStock.Value) : 0;
                decimal currentValue = !string.IsNullOrEmpty(hfCurrentValue.Value) ? decimal.Parse(hfCurrentValue.Value) : 0;
                uom = hdnUom.Value.ToString();
                remarks = txtRemarks.Text.ToString();
                decimal newQty = Convert.ToDecimal(txtQty.Text.ToString());
                decimal rate = Convert.ToDecimal(hfRate.Value);
                if (rate > 0)
                {
                    monValue = newQty * rate;
                    newValue = newQty * rate;

                    decimal adjustQty = newQty - currentStock;
                    decimal adjustValue = newValue - currentValue;
                    checkXmlItemData(itemid);
                    if (CheckItem == 1)
                    {
                        // CreateXml(item, itemid, qty.ToString(), rate.ToString(), monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
                        CreateXml(item, itemid, currentStock.ToString(), rate.ToString(), currentValue.ToString(), newQty.ToString(), newValue.ToString(), locationId, locationName,
                            adjustQty.ToString(), adjustValue.ToString(), uom, remarks);
                        txtItem.Text = "";
                        txtQty.Text = "0";
                        //txtRate.Text = "0";
                        hfRate.Value = "0";
                        ddlLcation.DataSource = "";
                        ddlLcation.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Costing for Selected Item is not set. Please Contact with your Accounts Department.');", true);
                    return;
                }
                
            }
            catch
            {
            }
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
                {
                    File.Delete(filePathForXML);
                    dgvStore.DataSource = "";
                    dgvStore.DataBind();
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                XmlDocument doc = new XmlDocument();
                intWh = int.Parse(ddlWh.SelectedValue);

                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try
                {
                    File.Delete(filePathForXML);
                }
                catch
                {
                }
                intWh = ddlWh.SelectedValue();
                int unitId = new UnitBll().GetUnitIdByWhId(intWh);
                if (unitId > 0)
                {
                    string Message = string.Empty;
                   objTransfer.InsertFGAdjustment(1, xmlString, intWh, unitId, Enroll, ref Message);

                    //if (dt != null)
                    //{
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        string message = dt.Rows[0]["Message"].ToString();
                    //    }
                    //}

                    if(Message == "success")
                    {
                        dgvStore.DataSource = null;
                        dgvStore.DataBind();
                        Toaster(Message, Common.TosterType.Success);
                    }
                    else
                    {
                        Toaster(Message, Common.TosterType.Success);
                    }

                    


                    
                }
                else
                {
                Toaster("Something error in getting unit Id", Common.TosterType.Error);
                }

            //foreach (GridViewRow row in dgvStore.Rows)
            //{
            //    int intItemId = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
            //    decimal quantity = Convert.ToDecimal(((Label)row.FindControl("lblQty")).Text);
            //    decimal rate = Convert.ToDecimal(((Label)row.FindControl("lblValue")).Text);
            //    int intLocation = Convert.ToInt32(((Label)row.FindControl("lblLocationId")).Text);
            //    string remarks = ((Label)row.FindControl("lblRemarks")).Text;

            //    int unitId = new UnitBll().GetUnitIdByWhId(intWh);
            //    if (unitId > 0)
            //    {
            //        // dt = objTransfer.InventoryAdjustment(unitId, intWh, enroll, intItemId, quantity, rate, intLocation,remarks);
            //        dt = objTransfer.InsertFGAdjustment(1, xmlString, intWh, unitId, Enroll);

            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0][0] + "');", true);
            //        dgvStore.UnLoad();
            //        try
            //        {
            //            File.Delete(filePathForXML);
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    else
            //    {
            //        Toaster("Something error in getting unit Id", Common.TosterType.Error);
            //    }

            //}
            txtItem.Text = String.Empty;
                txtRemarks.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
                try { File.Delete(filePathForXML); } catch { }
            }
        }

        #endregion

        #region Method
        private void CreateXml(string item, string itemid, string currentStock, string rate, string currentValue, string newQty,string newValue, string locationId, string locationName, 
            string adjustQty, string adjustValue, string uom, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, currentStock.ToString(), rate.ToString(), currentValue.ToString(), newQty.ToString(), newValue.ToString(), locationId, locationName,
                            adjustQty.ToString(), adjustValue.ToString(), uom, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, currentStock.ToString(), rate.ToString(), currentValue.ToString(), newQty.ToString(), newValue.ToString(), locationId, locationName,
                            adjustQty.ToString(), adjustValue.ToString(), uom, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void CreateXml_old(string item, string itemid, string qty, string rate, string monValue, string locationId, string locationName, string transType, string transTypeId, string uom, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                //XmlNode addItem = CreateItemNode(doc, item, itemid, qty, rate, monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
               // rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                //XmlNode addItem = CreateItemNode(doc, item, itemid, qty, rate, monValue.ToString(), locationId, locationName, transType, transTypeId, uom, remarks);
                //rootNode.AppendChild(addItem);
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
                {
                    dgvStore.DataSource = ds;
                }
                else
                {
                    dgvStore.DataSource = "";
                }
                dgvStore.DataBind();
            }
            catch { }
        }
        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string currentStock, string rate, string currentValue, string newQty, string newValue, string locationId, string locationName,
            string adjustQty, string adjustValue, string uom, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute CurrentStock = doc.CreateAttribute("currentStock");
            CurrentStock.Value = currentStock;

            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;

            XmlAttribute CurrentValue = doc.CreateAttribute("currentValue");
            CurrentValue.Value = currentValue;

            XmlAttribute NewQty = doc.CreateAttribute("newQty");
            NewQty.Value = newQty;

            XmlAttribute NewValue = doc.CreateAttribute("newValue");
            NewValue.Value = newValue;

            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;
            XmlAttribute LocationName = doc.CreateAttribute("locationName");
            LocationName.Value = locationName;

            XmlAttribute AdjustQty = doc.CreateAttribute("adjustQty");
            AdjustQty.Value = adjustQty;
            XmlAttribute AdjustValue = doc.CreateAttribute("adjustValue");
            AdjustValue.Value = adjustValue;

            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(CurrentStock);
            node.Attributes.Append(Rate);
            node.Attributes.Append(CurrentValue);
            node.Attributes.Append(NewQty);
            node.Attributes.Append(NewValue);
            node.Attributes.Append(LocationId);
            node.Attributes.Append(LocationName);
            node.Attributes.Append(AdjustQty);
            node.Attributes.Append(AdjustValue);
            node.Attributes.Append(Uom);
            //node.Attributes.Append(MonValue);
            node.Attributes.Append(Remarks);

            return node;
        }
        private XmlNode CreateItemNode_old(XmlDocument doc, string item, string itemid, string qty, string rate, string monValue, string locationId, string locationName, string transType, string transTypeId, string uom, string remarks)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;

            XmlAttribute MonValue = doc.CreateAttribute("monValue");
            MonValue.Value = monValue;

            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;
            XmlAttribute LocationName = doc.CreateAttribute("locationName");
            LocationName.Value = locationName;

            XmlAttribute TransType = doc.CreateAttribute("transType");
            TransType.Value = transType;
            XmlAttribute TransTypeId = doc.CreateAttribute("transTypeId");
            TransTypeId.Value = transTypeId;

            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;

            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;

            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(LocationId);

            node.Attributes.Append(LocationName);
            node.Attributes.Append(TransType);
            node.Attributes.Append(TransTypeId);
            node.Attributes.Append(Uom);
            node.Attributes.Append(MonValue);
            node.Attributes.Append(Remarks);

            return node;
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
        #endregion

        #region Auto Search
        static AutoSearch_BLL ast = new AutoSearch_BLL();
        [WebMethod]
        [ScriptMethod]
        public static string[] GetIndentItemSerach(string prefixText, int count)
        {

            return ast.AutoSearchItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
            // return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);
        }

        #endregion Close
    }
}