using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using HR_BLL.Global;
using Dairy_BLL;
using HR_BLL.Dispatch;

namespace UI.HR.Dispatch
{
    public partial class DispatchRequest : BasePage
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string filePathForXML, xmlString = "", xml;
        string categoryid, categoryname, itemid, itemname, qty, remarks, Unitid;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };

        int intEnroll, intPart, intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            filePathForXML = Server.MapPath("~/HR/Dispatch/Data/AddDispatch_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXML); dgvAdd.DataSource = ""; dgvAdd.DataBind();
                hdnpoint.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                if ((int.Parse(hdnpoint.Value) >= 1 && int.Parse(hdnpoint.Value) <= 22)) { if (hdnpoint.Value == "2") { hdntype.Value = "0"; } else { hdntype.Value = "1"; } }
                else { hdntype.Value = "0"; }

                dt = new DataTable();
                dt = obj.GetEmpInfo(int.Parse(hdnEnroll.Value));
                if (dt.Rows.Count > 0)
                {
                    txtFName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    txtSUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtSJobS.Text = dt.Rows[0]["strJobStationName"].ToString();
                    txtSPhone.Text = dt.Rows[0]["strContactNo1"].ToString();
                    txtSAddress.Text = dt.Rows[0]["strStationAddress"].ToString();
                    txtSMail.Text = dt.Rows[0]["strOfficeEmail"].ToString();

                    txtFName.Enabled = false;
                    txtSUnit.Enabled = false;
                    txtSJobS.Enabled = false;
                    txtSPhone.Enabled = false;
                    txtSAddress.Enabled = false;
                    txtSMail.Enabled = false;
                }

                lblAddress.Visible = false; txtAddress.Visible = false;
                lblUnit.Visible = true; txtUnit.Visible = true;
                lblJobS.Visible = true; txtJobS.Visible = true;
                lblDept.Visible = true; txtDept.Visible = true;
                lblDesig.Visible = true; txtDesig.Visible = true;
                txtReceiver.Visible = false;
                txtSearchAssignedTo.Visible = true;

                Unitid = Session[SessionParams.UNIT_ID].ToString();
                HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            try
            {
                intPart = 1; 
                intEnroll = int.Parse(hdnEnroll.Value);
                dt = new DataTable();
                dt = obj.GetDispatchReport(intPart, intEnroll);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }

        #region ===== Selection Change =================================================================
        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
            File.Delete(filePathForXML); LoadGridwithXml();
        }
        protected void ddlWH_DataBound(object sender, EventArgs e)
        {
            try
            {
                hdnwh.Value = ddlWH.SelectedValue.ToString();
                Session["WareID"] = hdnwh.Value;
            }
            catch { }
            File.Delete(filePathForXML); LoadGridwithXml();
        }
        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            dt = new DataTable();
            dt = obj.GetEmpInfo(intEnroll);
            if (dt.Rows.Count > 0)
            {
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtJobS.Text = dt.Rows[0]["strJobStationName"].ToString();
                txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                txtDesig.Text = dt.Rows[0]["strDesignation"].ToString();
            }
            else
            {
                txtUnit.Text = "";
                txtJobS.Text = "";
                txtDept.Text = "";
                txtDesig.Text = "";
            }

        }
        protected void ddlCertificateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDispatchType.SelectedValue.ToString() == "1")
            {
                lblAddress.Visible = false; txtAddress.Visible = false;
                lblUnit.Visible = true; txtUnit.Visible = true;
                lblJobS.Visible = true; txtJobS.Visible = true;
                lblDept.Visible = true; txtDept.Visible = true;
                lblDesig.Visible = true; txtDesig.Visible = true;
                txtReceiver.Visible = false;
                txtSearchAssignedTo.Visible = true;
                txtSearchAssignedTo.Text = "";
                txtReceiver.Text = "";
            }
            else
            {
                lblAddress.Visible = true; txtAddress.Visible = true;
                lblUnit.Visible = false; txtUnit.Visible = false;
                lblJobS.Visible = false; txtJobS.Visible = false;
                lblDept.Visible = false; txtDept.Visible = false;
                lblDesig.Visible = false; txtDesig.Visible = false;
                txtReceiver.Visible = true;
                txtSearchAssignedTo.Visible = false;
                txtSearchAssignedTo.Text = "";
                txtReceiver.Text = "";
            }
        }
        #endregion =====================================================================================
        
        #region ===== Search Item ======================================================================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetWearHouseRequesision(string prefixText, int count)
        {
            Int32 WHID = Convert.ToInt32(HttpContext.Current.Session["WareID"].ToString());
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();

            return objAutoSearch_BLL.GetItemLists(WHID.ToString(), prefixText);
        }
        #endregion =====================================================================================
        
        #region ===== Search Employee ==================================================================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }
        #endregion =====================================================================================
    
        #region ===== ADD Item =========================================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            arrayKey = txtItem.Text.Split(delimiterChars);
            itemname = ""; itemid = "";
            if (arrayKey.Length > 0)
            { itemname = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }
            qty = txtQty.Text;
            remarks = txtRemarks.Text;
            CreateAddXml(itemid, itemname, qty, remarks);
            txtItem.Text = "";
            txtRemarks.Text = "";
            txtQty.Text = "";
        }
        private void CreateAddXml(string itemid, string itemname, string qty, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Dispatch");
                XmlNode addItem = CreateItemNodeDocUpload(doc, itemid, itemname, qty, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Dispatch");
                XmlNode addItem = CreateItemNodeDocUpload(doc, itemid, itemname, qty, remarks);
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
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("Dispatch");
                xmlString = xlnd.InnerXml;
                xmlString = "<Dispatch>" + xmlString + "</Dispatch>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvAdd.DataSource = ds; } else { dgvAdd.DataSource = ""; }
                dgvAdd.DataBind();
            }
            catch { dgvAdd.DataSource = ""; dgvAdd.DataBind(); }
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string itemid, string itemname, string qty, string remarks)
        {
            XmlNode node = doc.CreateElement("Dispatch");
                        
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Remarks = doc.CreateAttribute("remarks"); Remarks.Value = remarks;
                        
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Remarks);
            return node;
        }      
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            { 
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Dispatch");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Dispatch>" + xmlString + "</Dispatch>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvAdd.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvAdd.DataSource;
                dsGrid.Tables[0].Rows[dgvAdd.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvAdd.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvAdd.DataSource = ""; dgvAdd.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        #endregion ======================================================================================

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 1;
                intDispatchID = 0;
                try { intWHID = int.Parse(ddlWH.SelectedValue.ToString()); } catch { return; }
                try { intDispatchType = int.Parse(ddlDispatchType.SelectedValue.ToString());} catch { }
                strDispatchType = ddlDispatchType.SelectedItem.ToString();

                if(intDispatchType == 1)
                {
                    try
                    {
                        char[] ch1 = { '[', ']' };
                        string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                        intReceiverEnroll = int.Parse(temp1[1].ToString());
                        strReceiver = temp1[0].ToString();
                    }
                    catch { intReceiverEnroll = 0; }

                    if (intReceiverEnroll == 0)
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Employee Properly.');", true); return; }
                }
                else
                {
                    intReceiverEnroll = 0;
                    strReceiver = txtReceiver.Text;
                }
                
                strAddress = txtAddress.Text;
                strRemarks = txtRemarksMain.Text;
                intCreateBy = int.Parse(hdnEnroll.Value);
                intApproveBy = 0;
                intVehicleNo = 0;
                strVehicleNo = "";
                strBearer = "";
                strBearerContact = "";
                monAmount = 0;
                intDispatchBy = 0;
                intReceiveBy = 0;

                try
                {  
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("Dispatch");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<Dispatch>" + xmlString + "</Dispatch>";
                    xml = xmlString;
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Item.');", true); return; }
                if (xml == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Item.');", true); return; }

                string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);

                txtDept.Text = "";
                txtDesig.Text = "";
                txtJobS.Text = "";
                txtUnit.Text = "";
                txtSearchAssignedTo.Text = "";
                txtAddress.Text = "";
                txtRemarksMain.Text = "";
                txtReceiver.Text = "";
                if (filePathForXML != null)
                { File.Delete(filePathForXML); }
                dgvAdd.DataSource = ""; dgvAdd.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                LoadGrid();
            }
        }












    }
}