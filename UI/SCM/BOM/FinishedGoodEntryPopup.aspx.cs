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
using BLL.HR;
using UI.ClassFiles;
using Utility;

namespace UI.SCM.BOM
{
    public partial class FinishedGoodEntryPopup : BasePage
    {
        #region INIT
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId, intBomStandard;
        private string xmlData;
        private int CheckItem = 1, intWh;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "", orderId = "0";
        decimal qty, actualQty, qcHoldQty, storeQty, totalSentToStore, totalExtraStore;
        private string productionID, productName, bomName, batchName, startTime, endTime, invoice, srNo, quantity, whid;
        #endregion

        #region Constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMatf__" + Enroll + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    filePathForXML.DeleteFile();
                }
                catch { }
                claenderDte.SelectedDate = DateTime.Now;
                CalendarExtenderExp.SelectedDate = DateTime.Now;
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
                dt = objBom.GetItemNameByProductionId(Convert.ToInt32(productionID));
                if (dt.Rows.Count > 0)
                {
                    productName = dt.Rows[0]["strItemName"].ToString();
                }
                lblItemName.Text = productName;
                lblItemId.Text = Request.QueryString["itemId"].ToString();

                lblProductionId.Text = productionID;
                lblDate.Text = startTime.ToString("yyyy-MM-dd") + " TO " + endTime.ToString("yyyy-MM-dd");
                txtTime.Text = startTime.ToString("HH:ss");
                txtProductQty.Text = quantity.ToString();
                lblOrderQty.Text = quantity.ToString();

                txtItem.Text = productName + "[" + lblItemId.Text + "]";
                txtProductQty.Visible = true;
                // dt = objBom.GetProductionOrderTransferItemDetails(int.Parse(productionID));

                intWh = int.Parse(Request.QueryString["whid"].ToString());
                dt = objBom.GetBomData(18, xmlString, intWh, int.Parse(lblItemId.Text.ToString()), DateTime.Now, Enroll);
                if (dt.Rows.Count > 0)
                {
                    string ast = dt.Rows[0]["ysnStandardCost"].ToString();
                    if (bool.Parse(dt.Rows[0]["ysnStandardCost"].ToString()))
                    {
                        lblOrder.Visible = false;
                        ddlOrderId.Visible = false;
                    }
                    else
                    {
                        lblOrder.Visible = true;
                        ddlOrderId.Visible = true;
                    }
                }
                ddlOrderId.LoadWithSelect(dt, "intSalesOrderID", "intSalesOrderID");
                LoadWastageTpe();
                LoadWastageItem();
                LoadGrid();


            }
        }
        #endregion

        #region Event
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
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
                    uom = arrayKey[1].ToString();
                    itemid = arrayKey[3].ToString();
                }
                string[] searchKey = Regex.Split(uom, ":");
                lblUom1.Text = searchKey[1].ToString();
                lblUom2.Text = searchKey[1].ToString();
                lblItemId.Text = itemid;
                lblItemName.Text = item;

            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void btnAdd_Click_old(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    orderId = ddlOrderId.SelectedValue().ToString();
                }
                catch
                {
                    orderId = "0";
                }


                arrayKey = txtItem.Text.Split(delimiterChars);

                string item = lblItemName.Text;
                string itemid = lblItemId.Text;
                string uom = "";
                bool proceed = false;
                //if (arrayKey.Length > 0)
                //{
                //    item = arrayKey[0].ToString();
                //    uom = arrayKey[1].ToString();
                //    itemid = arrayKey[3].ToString();
                //}

                checkXmlItemData(itemid);
                if (CheckItem == 1)
                {
                    decimal.TryParse(txtProductQty.Text, out qty);
                    //decimal.TryParse(txtActualQty.Text, out actualQty);
                    //decimal.TryParse(txtQc.Text, out qcHoldQty);
                    //decimal.TryParse(txtSendToStore.Text, out storeQty);
                    if (Session["TotalStoreQuantity"] != null)
                    {
                        if (!decimal.TryParse(Session["TotalStoreQuantity"].ToString(), out totalSentToStore))
                        {
                            Toaster("Can not get total store quantity. please contact with developper.", Common.TosterType.Warning);
                            return;
                        }
                    }
                    if (qty > 0 && storeQty > 0 && actualQty > 0)
                    {
                        decimal avaialableQuantity = actualQty - totalSentToStore;

                        if (avaialableQuantity - qcHoldQty < 0)
                        {
                            Toaster("QC quantity can not be grater than available quantity " + avaialableQuantity, Common.TosterType.Warning);
                            return;
                        }
                        if (avaialableQuantity - storeQty < 0)
                        {
                            Toaster("Store quantity can not be grater than available quantity " + avaialableQuantity, Common.TosterType.Warning);
                            return;
                        }
                        if (avaialableQuantity < qcHoldQty + storeQty)
                        {
                            Toaster("Sum of store Quantity and QC quantity can not be grater than available quantity " + avaialableQuantity, Common.TosterType.Warning);
                            return;
                        }
                        string struom = lblUom1.Text.ToString();

                        string jobno = txtJob.Text.ToString();
                        string times = txtTime.Text.ToString();
                        string expDate = txtExpDate.Text.ToString();


                        CreateXml(item, itemid, struom, qty.ToString(), storeQty.ToString(), jobno, times,
                            actualQty.ToString(), qcHoldQty.ToString(), expDate, orderId);
                    }
                    else
                    {
                        Toaster("Production,Actual and send to store Quantity should be grater than 0", Common.TosterType.Warning);
                    }
                }
                else
                {
                    Toaster(Message.AlreadyAdded.ToFriendlyString(), Common.TosterType.Warning);
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
                LoadGridwithXml2();
                DataSet dsGrid = (DataSet)gridViewWastage.DataSource;
                dsGrid.Tables[0].Rows[gridViewWastage.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)gridViewWastage.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    filePathForXML.DeleteFile();
                    gridViewWastage.UnLoad();
                }
                else
                {
                    LoadGridwithXml2();
                }
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void btnSaves_Click_old(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(Request.QueryString["whid"].ToString());
                    int productionId = int.Parse(Request.QueryString["productID"].ToString());
                    DateTime dteDate = DateTime.Parse(txtDate.Text.ToString());
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
                    if (xmlString.Length > 5)
                    {
                        string msg = objBom.BomPostData(9, xmlString, intWh, productionId, dteDate, Enroll);

                        gridViewWastage.UnLoad();

                        txtProductQty.Text = "0";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                            "alert('" + msg + "');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                    }
                }
            }
            catch
            {
                try
                {
                    File.Delete(filePathForXML);
                }
                catch { }
            }
        }
        protected void dgvProductionEntry_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (e.Row.FindControl("lblTotalStore") is Label label)
                {
                    if (Session["TotalStoreQuantity"] != null)
                    {
                        label.Text = Session["TotalStoreQuantity"].ToString();
                    }
                }
            }
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            int transectionId = Convert.ToInt32(txtTransectionId.Text);
            decimal.TryParse(txtActualQtyUpdate.Text, out actualQty);
            decimal.TryParse(txtQcUpdate.Text, out qcHoldQty);
            decimal.TryParse(txtSendToStorePrv.Text, out decimal prvStoreQty);
            decimal.TryParse(txtSendToStoreUpdate.Text, out storeQty);
            if (Session["TotalStoreQuantity"] != null)
            {
                if (!decimal.TryParse(Session["TotalStoreQuantity"].ToString(), out totalSentToStore))
                {
                    Toaster("Can not get total store quantity. please contact with developper.", Common.TosterType.Warning);
                    SetVisibilityModal(true);
                    return;
                }
            }
            if (storeQty > 0)
            {
                decimal avaialableQuantity = actualQty - totalSentToStore + prvStoreQty;
                if (avaialableQuantity - storeQty < 0)
                {
                    Toaster("Store quantity can not be grater than available quantity " + avaialableQuantity, Common.TosterType.Warning);
                    SetVisibilityModal(true);
                    return;
                }
                if (avaialableQuantity < qcHoldQty + storeQty)
                {
                    Toaster("Sum of store Quantity and QC quantity can not be grater than available quantity " + avaialableQuantity, Common.TosterType.Warning);
                    SetVisibilityModal(true);
                    return;
                }
            }
            else
            {
                Toaster("Send to store Quantity should be grater than 0", Common.TosterType.Warning);
                SetVisibilityModal(true);
                return;
            }
            objBom.UpdateProductionTransfer(1, storeQty, transectionId, Enroll, out string msg);
            if (msg.ToLower().Contains("success"))
            {
                Toaster(msg, Common.TosterType.Success);
                LoadGrid();
            }
            else
            {
                Toaster(msg, Common.TosterType.Error);
                SetVisibilityModal(true);
            }


        }
        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnButtonClick(sender);
            string receiveQuantity = (row.FindControl("lblStoreReceivedQty") as Label)?.Text;
            if (string.IsNullOrWhiteSpace(receiveQuantity))
            {
                txtTransectionId.Text = (row.FindControl("lblAutoId") as Label)?.Text;
                txtProductNameUpdate.Text = (row.FindControl("lblProductName") as Label)?.Text;
                txtActualQtyUpdate.Text = (row.FindControl("lblActualQty") as Label)?.Text;
                txtQcUpdate.Text = (row.FindControl("lblQCQty") as Label)?.Text;
                txtSendToStorePrv.Text = (row.FindControl("lblStore") as Label)?.Text;
                SetVisibilityModal(true);

            }
            else
            {
                Toaster("This Item Already Received", Common.TosterType.Warning);
            }

        }
        #endregion

        #region Method
        
        public void LoadGrid()
        {
            dt = objBom.GetProductionOrderTransferItemDetails(int.Parse(lblProductionId.Text));
            if (dt.Rows.Count > 0)
            {
                //txtItem.Text = dt.Rows[0]["strName"].ToString();
                txtProductQty.Text = dt.Rows[0]["numProdQty"].ToString();
                //txtActualQty.Text = dt.Rows[0]["numActualQty"].ToString();
                //if (string.IsNullOrWhiteSpace(txtActualQty.Text))
                //{
                //    txtActualQty.Text = lblPlanQty.Text;
                //}
                //txtActualQty.Enabled = false;

                Session["TotalStoreQuantity"] = dt.Rows[0]["totalSentToStore"].ToString();

                gridViewProductionEntry.Loads(dt);
            }
            else
            {
                Session["TotalStoreQuantity"] = null;
            }
        }
        private void CreateXml(string item, string itemid, string struom, string qty, string storeQty, string jobno, string times, string actualQty, 
            string qcHoldQty, string expDate, string orderId)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, struom, qty, storeQty, jobno, times, actualQty, qcHoldQty, expDate, orderId);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, item, itemid, struom, qty, storeQty, jobno, times, actualQty, qcHoldQty, expDate, orderId);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string item, string itemid, string struom, string qty, string storeQty, string jobno, string times,
            string actualQty, string qcHoldQty, string expDate, string orderId)
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

            XmlAttribute ActualQty = doc.CreateAttribute("actualQty");
            ActualQty.Value = actualQty;

            XmlAttribute QcHoldQty = doc.CreateAttribute("qcHoldQty");
            QcHoldQty.Value = qcHoldQty;

            XmlAttribute ExpDate = doc.CreateAttribute("expDate");
            ExpDate.Value = expDate;

            XmlAttribute OrderId = doc.CreateAttribute("orderId");
            OrderId.Value = orderId;



            node.Attributes.Append(Item);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Struom);
            node.Attributes.Append(Qty);

            node.Attributes.Append(StoreQty);
            node.Attributes.Append(Jobno);
            node.Attributes.Append(Times);

            node.Attributes.Append(ActualQty);

            node.Attributes.Append(QcHoldQty);

            node.Attributes.Append(ExpDate);
            node.Attributes.Append(OrderId);

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
                {
                    //dgvStore.DataSource = ds;
                    gridViewProductionEntry.DataSource = ds;
                }
                else
                {
                    //dgvStore.DataSource = "";
                    gridViewProductionEntry.DataSource = "";
                }
                //dgvStore.DataBind();
                gridViewProductionEntry.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
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
            catch (Exception ex)
            {
                //Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        #endregion

        #region Service
        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();
            return objBoms.AutoSearchBomId(HttpContext.Current.Session["Unit"].ToString(), prefixText, 1);
        }
        #endregion

        #region new Task 
        /*
         * Author : Muktadir
         * Date : 28-May-2019
         * For : Product Transfer
         */
        public void LoadWastageTpe()
        {
            ddlWastageType.Items.Insert(0, new ListItem("Select", "0"));
            ddlWastageType.Items.Insert(1, new ListItem("Good Production", "1"));
            ddlWastageType.Items.Insert(1, new ListItem("Scrap Output", "2"));
            ddlWastageType.Items.Insert(2, new ListItem("Wastage Output", "3"));
        }

        public void LoadWastageItem()
        {
            int unitId = new UnitBll().GetUnitIdByWhId(int.Parse(whid));
            DataTable dt = objBom.GetWastageItem(unitId);
            ddlWastageItem.LoadWithSelect(dt, "intItemID", "strItemFullName");
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string item = string.Empty;
            string uom = string.Empty;
            int ProductionId = 0;
            int itemid = 0;
            decimal OrderQnt = 0;
            decimal ProductQnt = 0;
            decimal GoodORwastageQnt = 0;

            try
            {
                OrderQnt = decimal.Parse(lblOrderQty.Text.Trim());
                ProductQnt = decimal.Parse(txtProductQty.Text.Trim());
                ProductionId = int.Parse(lblProductionId.Text);
                if (ddlWastageItem.SelectedValue == "0")
                {
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    if (arrayKey.Length > 0)
                    {
                        item = arrayKey[0].ToString();
                        uom = arrayKey[1].ToString();
                        //itemid = int.Parse(arrayKey[3].ToString());
                        itemid = int.Parse(lblItemId.Text.Trim());
                    }
                    GoodORwastageQnt = decimal.Parse(txtGoodsProductionQty.Text.Trim());
                    if(GoodORwastageQnt > ProductQnt)
                    {
                        Toaster("Production,Goods Quantity should not be grater than Product Quantity", Common.TosterType.Warning);
                        return;
                    }

                    if(GoodORwastageQnt <= 0)
                    {
                        Toaster("Good Quantity is : "+ GoodORwastageQnt+". Please Enter Valid Quantity.", Common.TosterType.Warning);
                        return;
                    }
                }
                else
                {
                    item = ddlWastageItem.SelectedItem.ToString();
                    itemid = int.Parse(ddlWastageItem.SelectedValue);
                    GoodORwastageQnt = decimal.Parse(txtWastageQuantity.Text.Trim());
                }
                string wastageType = Convert.ToInt32(ddlWastageType.SelectedValue) > 0 ?
                        ddlWastageType.SelectedItem.ToString() : string.Empty;
                string wastageTypeId = ddlWastageType.SelectedValue;
                if(ddlWastageType.SelectedValue == "0")
                {
                    Toaster("Please Select Type", Common.TosterType.Warning);
                    ddlWastageType.Focus();
                    return;
                }

                checkXmlItemData(itemid.ToString());
                if (CheckItem == 1)
                {
                    string Date = txtDate.Text;
                    string Time = txtTime.Text;
                    string JobNo = !string.IsNullOrEmpty(txtJob.Text) ? txtJob.Text : string.Empty;
                    
                    //totalExtraStore += Convert.ToDecimal(wastageQuantity);
                    CreateXml2(ProductionId.ToString(), OrderQnt.ToString(), ProductQnt.ToString(), item, itemid.ToString(), GoodORwastageQnt.ToString(), wastageType,
                        wastageTypeId, UnitId.ToString(), Date, Time, JobNo, Enroll.ToString(), totalExtraStore.ToString());
                    
                }
                else
                {
                    Toaster(Message.AlreadyAdded.ToFriendlyString(), Common.TosterType.Warning);
                }

                LoadGridwithXml2();
                Clear();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        protected void btnSaves_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value.ToString() == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("production");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<production>" + xmlString + "</production>";


                    intWh = int.Parse(Request.QueryString["whid"].ToString());
                    int productionId = int.Parse(Request.QueryString["productID"].ToString());
                    int FItemId = Convert.ToInt32(lblItemId.Text);
                    decimal ProductionQty = Convert.ToDecimal(txtProductQty.Text);
                    decimal GoodQty = Convert.ToDecimal(txtGoodsProductionQty.Text);
                    DateTime dteDate = DateTime.Parse(txtDate.Text.ToString());

                    try
                    {
                        File.Delete(filePathForXML);
                        string msg = objBom.InsertFinishProductProduction(3, xmlString, productionId, FItemId, intWh, ProductionQty, GoodQty);
                        if(msg == "sucess")
                        {
                            Clear2();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript","alert('Finish Product Production Insert Successfully');", true);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        }
                    }
                    catch
                    {
                    }
                   
                }
            }
            catch
            {
                try
                {
                    File.Delete(filePathForXML);
                }
                catch { }
            }
        }
        private void CreateXml2(string ProductionId,string OrderQty, string ProductQty, string FProductItem, string FProductItemId, string FProductQty, string FProductType, string FProductTypeId, string UnitId, string Date, string Time,
           string JobNo, string UserId, string totalExtraStore)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("production");
                XmlNode addItem = CreateItemNode2(doc, ProductionId, OrderQty, ProductQty, FProductItem, FProductItemId, FProductQty, FProductType, FProductTypeId, UnitId, Date, Time, JobNo, UserId, totalExtraStore);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("production");
                XmlNode addItem = CreateItemNode2(doc, ProductionId, OrderQty, ProductQty, FProductItem, FProductItemId, FProductQty, FProductType, FProductTypeId, UnitId, Date, Time, JobNo, UserId, totalExtraStore);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml2();
        }
        //private void CreateXml2(string ProductionId, string FProductItem, string FProductItemId, string FProductQty, string FProductType, string FProductTypeId, string UnitId, string Date, string Time,
        //   string JobNo,string UserId, string totalExtraStore)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    if (File.Exists(filePathForXML))
        //    {
        //        doc.Load(filePathForXML);
        //        XmlNode rootNode = doc.SelectSingleNode("production");
        //        XmlNode addItem = CreateItemNode2(doc, ProductionId, FProductItem, FProductItemId, FProductQty, FProductType, FProductTypeId, UnitId, Date, Time, JobNo, UserId, totalExtraStore);
        //        rootNode.AppendChild(addItem);
        //    }
        //    else
        //    {
        //        XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
        //        doc.AppendChild(xmldeclerationNode);
        //        XmlNode rootNode = doc.CreateElement("production");
        //        XmlNode addItem = CreateItemNode2(doc, ProductionId, FProductItem, FProductItemId, FProductQty, FProductType, FProductTypeId, UnitId, Date, Time, JobNo, UserId, totalExtraStore);
        //        rootNode.AppendChild(addItem);
        //        doc.AppendChild(rootNode);
        //    }
        //    doc.Save(filePathForXML);
        //    LoadGridwithXml2();
        //}
        private XmlNode CreateItemNode2(XmlDocument doc,string ProductionId, string OrderQty, string ProductQty, string FProductItem, string FProductItemId, string FProductQty, string FProductType, string FProductTypeId, string UnitId, string Date,
            string Time, string JobNo,string UserId, string totalExtraStore)
        {
            XmlNode node = doc.CreateElement("productionEntry");

            XmlAttribute productionId = doc.CreateAttribute("ProductionId");
            productionId.Value = ProductionId;
            XmlAttribute orderQty = doc.CreateAttribute("OrderQty");
            orderQty.Value = OrderQty;
            XmlAttribute productQty = doc.CreateAttribute("ProductQty");
            productQty.Value = ProductQty;
            XmlAttribute FPItem = doc.CreateAttribute("FProductItem");
            FPItem.Value = FProductItem;
            XmlAttribute FPItemId = doc.CreateAttribute("FProductItemId");
            FPItemId.Value = FProductItemId;
            XmlAttribute FPQty = doc.CreateAttribute("FProductQty");
            FPQty.Value = FProductQty;
            XmlAttribute FPType = doc.CreateAttribute("FProductType");
            FPType.Value = FProductType;
            XmlAttribute FPTypeId = doc.CreateAttribute("FProductTypeId");
            FPTypeId.Value = FProductTypeId;
            XmlAttribute Unitid = doc.CreateAttribute("UnitId");
            Unitid.Value = UnitId;
            XmlAttribute date = doc.CreateAttribute("Date");
            date.Value = Date;
            XmlAttribute time = doc.CreateAttribute("Time");
            time.Value = Time;
            XmlAttribute jobNo = doc.CreateAttribute("JobNo");
            jobNo.Value = JobNo;
            XmlAttribute userId = doc.CreateAttribute("UserId");
            userId.Value = UserId;
            XmlAttribute TotalExtraStore = doc.CreateAttribute("totalExtraStore");
            TotalExtraStore.Value = totalExtraStore;

            node.Attributes.Append(productionId);
            node.Attributes.Append(orderQty);
            node.Attributes.Append(productQty);
            node.Attributes.Append(FPItem);
            node.Attributes.Append(FPItemId);
            node.Attributes.Append(FPQty);
            node.Attributes.Append(FPType);
            node.Attributes.Append(FPTypeId);
            node.Attributes.Append(Unitid);
            node.Attributes.Append(date);
            node.Attributes.Append(time);
            node.Attributes.Append(jobNo);
            node.Attributes.Append(userId);
            node.Attributes.Append(TotalExtraStore);

            return node;
        }
        private void LoadGridwithXml2()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("production");
                xmlString = dSftTm.InnerXml;
                xmlString = "<production>" + xmlString + "</production>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // dgvStore.DataSource = ds;
                    gridViewProductionEntryAdd.DataSource = ds;
                }
                else
                {
                    //dgvStore.DataSource = "";
                    gridViewProductionEntryAdd.DataSource = "";
                }
                //dgvStore.DataBind();
                gridViewProductionEntryAdd.DataBind();
            }
            catch (Exception ex)
            {
                Toaster(ex.Message, Common.TosterType.Error);
            }
        }
        private void Clear()
        {
            ddlWastageItem.SelectedValue = "-1";
            txtWastageQuantity.Text = string.Empty;
            ddlWastageType.SelectedValue = "-1";
        }
        private void Clear2()
        {
            gridViewProductionEntry.DataSource = "";
            gridViewProductionEntry.DataBind();
            txtGoodsProductionQty.Text = "0";
            txtProductQty.Text = "0";
            txtJob.Text = string.Empty;
        }
        #endregion
        
    }
}