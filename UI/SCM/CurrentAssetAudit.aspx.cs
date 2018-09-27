using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class CurrentAssetAudit : BasePage
    {
        Billing_BLL objBillApp = new Billing_BLL();
        InventoryTransfer_BLL objInventorybll = new InventoryTransfer_BLL();
        int enroll, intWH;
        string filePathForXML, msg;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/ITEM_LIST_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }

            //dt = objBillApp.GetWHList();
            //ddlWH.DataSource = dt;
            //ddlWH.DataTextField = "strWareHoseName";
            //ddlWH.DataValueField = "intWHID";
            //ddlWH.DataBind();
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            intWH = int.Parse(ddlWH.SelectedItem.Value);
            DateTime Fdate = DateTime.ParseExact("2017-07-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime Tdate = DateTime.Now;           
            dt = objInventorybll.GetAssetData(intWH, Fdate, Tdate, 4, "");
            GvAuditList.DataSource = dt;
            GvAuditList.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DateTime Auditdate = DateTime.ParseExact(txtAuditDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string dteAuditedDate = Auditdate.ToString("yyyy/MM/dd");
            if (GvAuditList.Rows.Count > 0)
            {
                for (int index = 0; index < GvAuditList.Rows.Count; index++)
                {
                    CheckBox check = (CheckBox)GvAuditList.Rows[index].FindControl("chkRow");
                    if (check.Checked == true)
                    {
                        Label intitemid = GvAuditList.Rows[index].FindControl("lblItemId") as Label;
                        string intItemID = intitemid.Text;
                        Label itemname = GvAuditList.Rows[index].FindControl("lblstrItem") as Label;
                        string strItemName = itemname.Text;
                        string intWHID = Convert.ToString(ddlWH.SelectedItem.Value);
                        
                        string dteInsertDate = DateTime.Now.ToString("yyyy/MM/dd");
                        Label clsqty = GvAuditList.Rows[index].FindControl("lblclsQty") as Label;
                        string monClosingQuantity = clsqty.Text;
                        TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
                        auditqty.Text= clsqty.Text;

                        string monAuditedQuantity = auditqty.Text;
                        string intAuditedBy = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                        TextBox remarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        string strRemarks = remarks.Text;
                        CreateXml(intItemID, strItemName, intWHID, dteInsertDate, dteAuditedDate, monClosingQuantity, monAuditedQuantity, intAuditedBy, strRemarks);
                        TextBox sremarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        sremarks.Text="";
                        auditqty.Text = "";
                        check.Checked = false;

                    }
                    else if(check.Checked == false)
                    {
                        TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
                        string audity = auditqty.Text;
                        TextBox remarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        string strRemarkss = remarks.Text;
                        if (audity != "" || strRemarkss != "")
                        {
                            Label intitemid = GvAuditList.Rows[index].FindControl("lblItemId") as Label;
                            string intItemID = intitemid.Text;
                            Label itemname = GvAuditList.Rows[index].FindControl("lblstrItem") as Label;
                            string strItemName = itemname.Text;
                            string intWHID = Convert.ToString(ddlWH.SelectedItem.Value);

                            string dteInsertDate = DateTime.Now.ToString("yyyy/MM/dd");
                            Label clsqty = GvAuditList.Rows[index].FindControl("lblclsQty") as Label;
                            string monClosingQuantity = clsqty.Text;
                            auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
                            string audit = auditqty.Text;
                            remarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                            string strRemarks = remarks.Text;
                            //string monAuditedQuantity = clsqty.Text;
                            string intAuditedBy = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                            CreateXml(intItemID, strItemName, intWHID, dteInsertDate, dteAuditedDate, monClosingQuantity, audit, intAuditedBy, strRemarks);
                            remarks.Text = "";
                            auditqty.Text = "";
                        }
                    }

                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode node = doc.SelectSingleNode("ItemList");
                string xmlString = node.InnerXml;
                xmlString = "<ItemList>" + xmlString + "</ItemList>";

                if(hdnConfirm.Value=="1")
                {
                    objInventorybll.InsertCurrentAssetAudit(xmlString);
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Inserted Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Inserted.');", true);
                }
                //CheckBox CheckBox1 = (CheckBox)sender;
                //CheckBox1.Checked = false;
                try { File.Delete(filePathForXML); }              
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                }

            }
        }

        #region========checkbox check changed=============
        protected void chkRow_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox CheckBox1 = (CheckBox)sender;
            GridViewRow row = (GridViewRow)CheckBox1.NamingContainer;
            Label clsqty = (Label)row.FindControl("lblclsQty");
            TextBox auditqty = (TextBox)row.FindControl("txtAuditedQty");
            if (CheckBox1.Checked == true)
            {
                auditqty.Text = clsqty.Text;
                auditqty.Enabled = false;
            }
            else
            {
                auditqty.Text = "";
                auditqty.Enabled = true;
            }
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            
            if (GvAuditList.Rows.Count > 0)
            {
                for (int index = 0; index < GvAuditList.Rows.Count; index++)
                {

                    if (((CheckBox)GvAuditList.Rows[index].FindControl("chkRow")).Checked == true)
                    {

                        Label clsqty = GvAuditList.Rows[index].FindControl("lblclsQty") as Label;
                        string monClosingQuantity = clsqty.Text;
                        TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
                        auditqty.Text = clsqty.Text;
                        auditqty.Enabled = false;

                    }
                    else
                    {
                        TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
                        auditqty.Text = "";
                        auditqty.Enabled = true;
                    }

                }

            }
        }
        #endregion========checkbox check changed end=============
        #region==== create xml==========
        private void CreateXml(string intItemID, string strItemName, string intWHID, string dteInsertDate, string dteAuditedDate, string monClosingQuantity, string monAuditedQuantity, string intAuditedBy, string strRemarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemList");
                XmlNode addItem = CreateItemNode(doc, intItemID, strItemName, intWHID, dteInsertDate, dteAuditedDate, monClosingQuantity, monAuditedQuantity, intAuditedBy, strRemarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemList");
                XmlNode addItem = CreateItemNode(doc, intItemID, strItemName, intWHID, dteInsertDate, dteAuditedDate, monClosingQuantity, monAuditedQuantity, intAuditedBy, strRemarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string intItemID, string strItemName, string intWHID, string dteInsertDate, string dteAuditedDate, string monClosingQuantity, string monAuditedQuantity, string intAuditedBy, string strRemarks)
        {

            XmlNode node = doc.CreateElement("Item");
            XmlAttribute ItemID = doc.CreateAttribute("intItemID");
            ItemID.Value = intItemID;

            XmlAttribute ItemName = doc.CreateAttribute("strItemName");
            ItemName.Value = strItemName;

            XmlAttribute WHID = doc.CreateAttribute("intWHID");
            WHID.Value = intWHID;

            XmlAttribute InsertDate = doc.CreateAttribute("dteInsertDate");
            InsertDate.Value = dteInsertDate;

            XmlAttribute AuditedDate = doc.CreateAttribute("dteAuditedDate");
            AuditedDate.Value = dteAuditedDate;

            XmlAttribute ClosingQuantity = doc.CreateAttribute("monClosingQuantity");
            ClosingQuantity.Value = monClosingQuantity;

            XmlAttribute AuditedQuantity = doc.CreateAttribute("monAuditedQuantity");
            AuditedQuantity.Value = monAuditedQuantity;

            XmlAttribute AuditedBy = doc.CreateAttribute("intAuditedBy");
            AuditedBy.Value = intAuditedBy;

            XmlAttribute Remarks = doc.CreateAttribute("strRemarks");
            Remarks.Value = strRemarks;

            node.Attributes.Append(ItemID);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(WHID);
            node.Attributes.Append(InsertDate);
            node.Attributes.Append(AuditedDate);
            node.Attributes.Append(ClosingQuantity);
            node.Attributes.Append(AuditedQuantity);
            node.Attributes.Append(AuditedBy);
            node.Attributes.Append(Remarks);
            
            return node;
        }
        #endregion ======= end xml ========

    }
}