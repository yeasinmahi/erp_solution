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
    public partial class rptDispatchApproveReject : BasePage
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll;
        string itemid, itemname, qty, remarks;

        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/HR/Dispatch/Data/AddDispatch_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();                
            }
        }

        #region ===== Gridview Report ====================================================
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                if(rdoPending.Checked == true)
                {
                    intPart = 2;
                    dgvReport.Columns[8].Visible = false; dgvReport.Columns[9].Visible = false;
                    dgvReport.Columns[11].Visible = true; dgvReport.Columns[12].Visible = true;
                }
                else if (rdoComplete.Checked == true)
                {
                    intPart = 3; dgvReport.Columns[11].Visible = false; dgvReport.Columns[12].Visible = false;
                    dgvReport.Columns[8].Visible = true; dgvReport.Columns[9].Visible = true;
                }
                else if (rdoReject.Checked == true)
                {
                    intPart = 4; dgvReport.Columns[11].Visible = false; dgvReport.Columns[12].Visible = false;
                    dgvReport.Columns[8].Visible = false; dgvReport.Columns[9].Visible = false;
                }

                intEnroll = int.Parse(hdnEnroll.Value); 
                dt = new DataTable();
                dt = obj.GetDispatchReport(intPart, intEnroll);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }
        #endregion =======================================================================

        #region ===== Selection Change ===================================================
        protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPending.Checked == true) { rdoComplete.Checked = false; rdoReject.Checked = false; }
            else { rdoPending.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoComplete.Checked == true) { rdoPending.Checked = false; rdoReject.Checked = false; }
            else { rdoComplete.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        protected void rdoReject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReject.Checked == true) { rdoPending.Checked = false; rdoComplete.Checked = false; }
            else { rdoReject.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        #endregion =======================================================================

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            char[] delimiterChars = { '^' };
            string value = (e.CommandArgument).ToString();
            string[] data = value.Split(delimiterChars);
            
            if (e.CommandName.Equals("DETAILS"))
            {
                if(rdoPending.Checked == true) { btnApproveDT.Visible = true;}
                else { btnApproveDT.Visible = false; }

                hdnDispatchID.Value = data[0].ToString();
                if (filePathForXML != null) { File.Delete(filePathForXML); }
                intPart = 10;
                intEnroll = int.Parse(data[0].ToString());
                dt = new DataTable();
                dt = obj.GetDispatchReport(intPart, intEnroll);
                if (dt.Rows.Count > 0)
                {
                    for (int index = 0; index < dt.Rows.Count; index++)
                    {
                        itemid = dt.Rows[index]["intItemID"].ToString();
                        itemname = dt.Rows[index]["strItemName"].ToString();
                        qty = dt.Rows[index]["numQty"].ToString();
                        remarks = dt.Rows[index]["strRemarks"].ToString();

                        CreateAddXml(itemid, itemname, qty, remarks);
                    }
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);               

            }
            else if (e.CommandName.Equals("APPROVE"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intDispatchID = int.Parse(data[0].ToString());
                        intWHID = 0;
                        strAddress = "";
                        strRemarks = "";
                        intCreateBy = 0;
                        intApproveBy = 0;
                        intVehicleNo = 0;
                        strVehicleNo = "";
                        strBearer = "";
                        strBearerContact = "";
                        monAmount = 0;
                        intDispatchBy = 0;
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        intPart = 2;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();
                    }
                    catch { }
                }
            }
            else if (e.CommandName.Equals("APPROVEDT"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intDispatchID = int.Parse(hdnDispatchID.Value);
                        intWHID = 0;
                        strAddress = "";
                        strRemarks = "";
                        intCreateBy = 0;
                        intApproveBy = 0;
                        intVehicleNo = 0;
                        strVehicleNo = "";
                        strBearer = "";
                        strBearerContact = "";
                        monAmount = 0;
                        intDispatchBy = 0;
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("Dispatch");
                            xmlString = dSftTm.InnerXml;
                            xmlString = "<Dispatch>" + xmlString + "</Dispatch>";
                            xml = xmlString;
                        }
                        catch { }
                        if (xml == "") { return; }
                        intPart = 3;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        hdnDispatchID.Value = "0";
                        if (filePathForXML != null)
                        { File.Delete(filePathForXML); }
                        dgvAdd.DataSource = ""; dgvAdd.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('" + 0 + "');", true);
                        LoadGrid();
                    }
                    catch { }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true); }
            }
            else if (e.CommandName.Equals("REJECT"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intDispatchID = int.Parse(data[0].ToString());
                        intWHID = 0;
                        strAddress = "";
                        strRemarks = "";
                        intCreateBy = 0;
                        intApproveBy = 0;
                        intVehicleNo = 0;
                        strVehicleNo = "";
                        strBearer = "";
                        strBearerContact = "";
                        monAmount = 0;
                        intDispatchBy = 0;
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        intPart = 4;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();
                    }
                    catch { }
                }
            }
        }

        #region ===== ADD Item =========================================================================
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
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);
        }
        #endregion ======================================================================================







    }
}