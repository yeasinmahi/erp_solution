using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Globalization;

namespace UI.SCM.BOM
{
    public partial class ProductionOrderNew : System.Web.UI.Page
    {
        #region INIT
        private ProductionOrderBLL objPOBLL = new ProductionOrderBLL();
        private Bom_BLL objBom = new Bom_BLL();
        private DataTable dt = new DataTable();
        private int intwh, BomId, Enroll;
        private string xmlData;
        private int CheckItem = 1, intWh;
        private string[] arrayKey;
        private char[] delimiterChars = { '[', ']' };
        private string filePathForXML;
        private string xmlString = "";
        #endregion

        #region Const
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/ProductionOrder__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML);
                    dgvBom.DataSource = "";
                    dgvBom.DataBind();
                    FillDropdown();
                    LoadTime();
                }
                catch
                {
                }
            }
        }
        #endregion

        #region Event
        protected void ddlWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intwh = int.Parse(ddlWareHouse.SelectedValue);

                LoadUnit();
                LoadLine();

                txtItem.Text = string.Empty;
                txtBatchNo.Text = string.Empty;
                txtInvoice.Text = string.Empty;
                txtQuantity.Text = @"0";
                txtDate.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Ware House Event Problem');", true);
            }
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtItem.Text.Split(delimiterChars);
                intWh = int.Parse(ddlWareHouse.SelectedValue);
                string item = "";
                string itemid = "";
                string uom = "";
                bool proceed = false;
                if (arrayKey.Length > 0)
                {
                    item = arrayKey[0].ToString();
                    uom = arrayKey[2].ToString(); itemid = arrayKey[3].ToString();
                }
                dt = objBom.GetBomData(2, xmlData, intwh, int.Parse(itemid), DateTime.Now, Enroll);
                ddlBOM.DataSource = dt;
                ddlBOM.DataTextField = "strName";
                ddlBOM.DataValueField = "Id";
                ddlBOM.DataBind();

                //dt = objBom.GetBomData(14, xmlData, intWh, int.Parse(itemid), DateTime.Now, Enroll);
                //ddlStation.DataSource = dt;
                //ddlStation.DataTextField = "strName";
                //ddlStation.DataValueField = "Id";
                //ddlStation.DataBind();
            }
            catch { }
        }
        protected void btnSubmitProductionOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(hfConfirm.Value.ToString() == "1")
                {
                    Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intWh = int.Parse(ddlWareHouse.SelectedValue);
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("POrder");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<POrder>" + xmlString + "</POrder>";
                    DateTime dteDate = DateTime.ParseExact(txtDate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    try
                    {
                        File.Delete(filePathForXML);
                    }
                    catch
                    {
                    }
                    if (xmlString.Length > 5)
                    {
                        string msg = objPOBLL.InsertProductionOrder(5, xmlString, intWh, BomId, dteDate, Enroll);
                        if (msg.Equals("Production Order Submit Successfully."))
                        {
                            MClear();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        }

                    }
                }
                else
                {
                    MClear();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You Cancel To Submit This Data.');", true);
                }
                

            }
            catch (Exception ex)
            {
                File.Delete(filePathForXML);
                string sms = "Submit Button : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void btnAddProductionOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(Validation() == true)
                {
                    string strFUoM = string.Empty, strsUoM = string.Empty;
                    arrayKey = txtItem.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWareHouse.SelectedValue);
                    string itemName = "";
                    int itemID = 0;
                    string uom = "";
                    if (arrayKey.Length > 0)
                    {
                        itemName = arrayKey[0].ToString();
                        uom = arrayKey[2].ToString();
                        if (string.IsNullOrEmpty(uom))
                        {
                            strFUoM = arrayKey[1].ToString().Trim();
                            if(!string.IsNullOrEmpty(strFUoM))
                                uom = strFUoM.Substring(4);
                        }
                        itemID = Convert.ToInt32(arrayKey[3].ToString());
                    }
                    string fromTime = ddlFromTime.SelectedItem.ToString();
                    string toTime = ddlToTime.SelectedItem.ToString();
                    DateTime FromDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string fromDateTime = FromDate.ToString("dd/MM/yyyy") + " " + fromTime;
                    DateTime startTime = DateTime.Parse(fromDateTime.ToString());
                    DateTime ToDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string toDateTime = ToDate.ToString("dd/MM/yyyy") + " " + toTime;
                    DateTime endTime = DateTime.Parse(toDateTime.ToString());
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
                        checkXmlItemData(itemID.ToString());
                        if (CheckItem == 1)
                        {
                            int bomId = Convert.ToInt32(ddlBOM.SelectedValue);
                            string bomName = ddlBOM.SelectedItem.ToString();
                            decimal quantity = Convert.ToDecimal(txtQuantity.Text);
                            int lineID = Convert.ToInt32(ddlLineNo.SelectedValue);
                            string lineName = ddlLineNo.SelectedItem.ToString();
                            string invoice = txtInvoice.Text.ToString();
                            string batch = txtBatchNo.Text.ToString();
                            fromTime = startTime.ToString();
                            toTime = endTime.ToString();
                            CreateXml(itemID, itemName, uom, fromTime, toTime, bomId, bomName, quantity, lineID, lineName, invoice, batch);
                           
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true);
                        }
                    }
                    Clear();
                }
                

            }
            catch(Exception ex)
            {
                string sms = "Add Button : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        protected void dgvBom_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvBom.DataSource;
                dsGrid.Tables[0].Rows[dgvBom.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvBom.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvBom.DataSource = "";
                    dgvBom.DataBind();
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Method
        private void LoadWarehouse()
        {
            DataTable dtWareHouse = new DataTable();
            try
            {
                Enroll = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dtWareHouse = objPOBLL.GetWareHouse(2, xmlData, intwh, BomId, DateTime.Now, Enroll);
                if (dtWareHouse.Rows.Count > 0)
                {
                    ddlWareHouse.DataSource = dtWareHouse;
                    ddlWareHouse.DataTextField = "strName";
                    ddlWareHouse.DataValueField = "Id";
                    ddlWareHouse.DataBind();
                }
                ddlWareHouse.Items.Insert(0, new ListItem("--- Select Ware House ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Ware House Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadUnit()
        {
            try
            {
                DataTable dtUnit = new DataTable();
                dtUnit = objPOBLL.GetUnitByWH(4, xmlString, intwh, 0, DateTime.Now, Enroll);
                if (dtUnit.Rows.Count > 0)
                {
                    hfUnitID.Value = dtUnit.Rows[0]["intunit"].ToString();
                    Session["unit"] = hfUnitID.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                string sms = "Unit Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadLine()
        {
            DataTable dtLine = new DataTable();
            try
            {
                dtLine = objPOBLL.GetLineOrPlant(3, xmlData, intwh, BomId, DateTime.Now, Enroll);
                if (dtLine.Rows.Count > 0)
                {
                    ddlLineNo.DataSource = dtLine;
                    ddlLineNo.DataTextField = "strName";
                    ddlLineNo.DataValueField = "Id";
                    ddlLineNo.DataBind();
                }
                ddlLineNo.Items.Insert(0, new ListItem("--- Select Line ---", "-1"));
            }
            catch (Exception ex)
            {
                string sms = "Line Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void FillDropdown()
        {
            try
            {
                LoadWarehouse();
                intwh = Convert.ToInt32(ddlWareHouse.SelectedValue) > 0 ? Convert.ToInt32(ddlWareHouse.SelectedValue) : 0;

                LoadUnit();
                LoadLine();
            }
            catch (Exception ex)
            {
                string sms = "DropDown Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private void LoadTime()
        {
            try
            {
                object _objk = new {ID = 1,Name ="" };
                Dictionary<string, string> timeList = new Dictionary<string, string>();
                timeList.Add("-1", "---Select Time---");
                timeList.Add("12:00 AM", "12:00 AM");
                timeList.Add("1:00 AM", "1:00 AM");
                timeList.Add("2:00 AM", "2:00 AM");
                timeList.Add("3:00 AM", "3:00 AM");
                timeList.Add("4:00 AM", "4:00 AM");
                timeList.Add("5:00 AM", "5:00 AM");
                timeList.Add("6:00 AM", "6:00 AM");
                timeList.Add("7:00 AM", "7:00 AM");
                timeList.Add("8:00 AM", "8:00 AM");
                timeList.Add("9:00 AM", "9:00 AM");
                timeList.Add("10:00 AM", "10:00 AM");
                timeList.Add("11:00 AM", "11:00 AM");
                timeList.Add("12:00 PM", "12:00 PM");
                timeList.Add("1:00 PM", "1:00 PM");
                timeList.Add("2:00 PM", "2:00 PM");
                timeList.Add("3:00 PM", "3:00 PM");
                timeList.Add("4:00 PM", "4:00 PM");
                timeList.Add("5:00 PM", "5:00 PM");
                timeList.Add("6:00 PM", "6:00 PM");
                timeList.Add("7:00 PM", "7:00 PM");
                timeList.Add("8:00 PM", "8:00 PM");
                timeList.Add("9:00 PM", "9:00 PM");
                timeList.Add("10:00 PM", "10:00 PM");
                timeList.Add("11:59 PM", "11:59 PM");

                ddlFromTime.DataSource = timeList;
                ddlFromTime.DataTextField = "Value";
                ddlFromTime.DataValueField = "Key";
                ddlFromTime.DataBind();
                ddlToTime.DataSource = timeList;
                ddlToTime.DataTextField = "Value";
                ddlToTime.DataValueField = "Key";
                ddlToTime.DataBind();
            }
            catch (Exception)
            {
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
        private void CreateXml(int itemID, string itemName,string UoM, string fromTime, string toTime, int bomId, string bomName, 
            decimal quantity, int lineID,string lineName, string invoice, string batch)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("POrder");
                XmlNode addItem = CreateItemNode(doc, itemID.ToString(), itemName, UoM, fromTime, toTime, bomId.ToString(), bomName, quantity.ToString(), lineID.ToString(), lineName, invoice, batch);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("POrder");
                XmlNode addItem = CreateItemNode(doc, itemID.ToString(), itemName, UoM, fromTime, toTime, bomId.ToString(), bomName, quantity.ToString(), lineID.ToString(), lineName, invoice, batch);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemID, string itemName,string uom, string fromTime, string toTime, string bomId, 
            string bomName, string quantity, string lineID,string lineName, string invoice, string batch)
        {
            XmlNode node = doc.CreateElement("POrder");

            XmlAttribute ItemID = doc.CreateAttribute("itemID");
            ItemID.Value = itemID;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;
            XmlAttribute UoM = doc.CreateAttribute("uom");
            UoM.Value = uom;
            XmlAttribute FromTime = doc.CreateAttribute("fromTime");
            FromTime.Value = fromTime;
            XmlAttribute ToTime = doc.CreateAttribute("toTime");
            ToTime.Value = toTime;
            XmlAttribute BomId = doc.CreateAttribute("bomId");
            BomId.Value = bomId;
            XmlAttribute BomName = doc.CreateAttribute("bomName");
            BomName.Value = bomName;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute LineID = doc.CreateAttribute("lineID");
            LineID.Value = lineID;
            XmlAttribute LineName = doc.CreateAttribute("lineName");
            LineName.Value = lineName;
            XmlAttribute Invoice = doc.CreateAttribute("invoice");
            Invoice.Value = invoice;
            XmlAttribute Batch = doc.CreateAttribute("batch");
            Batch.Value = batch;

            node.Attributes.Append(ItemID);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(UoM);
            node.Attributes.Append(FromTime);
            node.Attributes.Append(ToTime);

            node.Attributes.Append(BomId);
            node.Attributes.Append(BomName);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(LineID);
            node.Attributes.Append(LineName);

            node.Attributes.Append(Invoice);
            node.Attributes.Append(Batch);
            

            return node;
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("POrder");
                xmlString = dSftTm.InnerXml;
                xmlString = "<POrder>" + xmlString + "</POrder>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvBom.DataSource = ds;
                }
                else
                {
                    dgvBom.DataSource = "";
                }
                dgvBom.DataBind();
            }
            catch(Exception ex)
            {
                string sms = "Gridview Load : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + sms + "');", true);
            }
        }
        private bool Validation()
        {
            if(ddlWareHouse.SelectedValue == "-1")
            {
                ddlWareHouse.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Warehouse.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtItem.Text))
            {
                txtItem.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Product.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtBatchNo.Text))
            {
                txtBatchNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Batch Number.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Product Quantity.');", true);
                return false;
            }
            if (Convert.ToDecimal(txtQuantity.Text) <= 0)
            {
                txtQuantity.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Valid Product Quantity.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(ddlBOM.Text))
            {
                ddlBOM.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('BOM Dropdown Not Load');", true);
                return false;
            }
            if (ddlBOM.SelectedValue == "-1")
            {
                ddlBOM.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select BOM.');", true);
                return false;
            }
            if (ddlLineNo.SelectedValue == "-1")
            {
                ddlLineNo.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Line.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtDate.Text))
            {
                txtDate.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date');", true);
                return false;
            }
            if (ddlFromTime.SelectedValue == "-1")
            {
                ddlFromTime.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select From Time.');", true);
                return false;
            }
            if (ddlFromTime.SelectedValue == "-1")
            {
                ddlFromTime.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select To Time.');", true);
                return false;
            }
            if (string.IsNullOrEmpty(txtInvoice.Text))
            {
                txtInvoice.Focus();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Enter Invoice No.');", true);
                return false;
            }
            return true;
        }
        private void Clear()
        {
            txtItem.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            txtQuantity.Text = "0";
            ddlLineNo.SelectedValue = "-1";
            ddlFromTime.SelectedValue = "-1";
            ddlToTime.SelectedValue = "-1";
            ddlBOM.Items.Clear();
        }
        private void MClear()
        {
            dgvBom.DataSource = "";
            dgvBom.DataBind();
            ddlWareHouse.SelectedValue = "-1";
            txtDate.Text = string.Empty;
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();
            return objBoms.AutoSearchBomId(HttpContext.Current.Session["unit"].ToString(), prefixText, 1);
        }
        #endregion
    }
}