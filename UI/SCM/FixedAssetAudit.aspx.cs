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
    public partial class FixedAssetAudit : BasePage
    {
        Billing_BLL objBillApp = new Billing_BLL();
        InventoryTransfer_BLL objInventorybll = new InventoryTransfer_BLL();
        int enroll;
        string filePathForXML, msg, strJobStation;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/ITEM_LIST_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
           
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            strJobStation = ddlJobstation.SelectedItem.Text;
            DateTime Fdate = DateTime.ParseExact("2017-07-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime Tdate = DateTime.Now;
            dt = objInventorybll.FixedAssetData("",2, strJobStation);
            GvAuditList.DataSource = dt;
            GvAuditList.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DateTime Auditdate = DateTime.ParseExact(txtAuditDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string dteAuditedDate = Auditdate.ToString("yyyy/MM/dd");
            string intAuditBy = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            string strJobstationID = ddlJobstation.SelectedItem.Text;
            if (GvAuditList.Rows.Count > 0)
            {
                for (int index = 0; index < GvAuditList.Rows.Count; index++)
                {
                    CheckBox check = (CheckBox)GvAuditList.Rows[index].FindControl("chkRow");
                    if (check.Checked == true)
                    {
                        Label Assetid = GvAuditList.Rows[index].FindControl("lblstrAssetID") as Label;
                        string strAssetID = Assetid.Text;
                        string dteInsertDate = DateTime.Now.ToString("yyyy/MM/dd");
                        TextBox remarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        string strRemarks = remarks.Text;
                        CreateXml(strAssetID, dteAuditedDate, intAuditBy, strRemarks);
                        TextBox sremarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        sremarks.Text = "";
                        check.Checked = false;

                    }
                    else if (check.Checked == false)
                    {

                        TextBox remarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                        string strRemarks = remarks.Text;
                        if (strRemarks != "")
                        {
                            Label Assetid = GvAuditList.Rows[index].FindControl("lblstrAssetID") as Label;
                            string strAssetID = Assetid.Text;
                            string dteInsertDate = DateTime.Now.ToString("yyyy/MM/dd");
                            CreateXml(strAssetID, dteAuditedDate, intAuditBy, strRemarks);
                            TextBox sremarks = GvAuditList.Rows[index].FindControl("txtRemarks") as TextBox;
                            sremarks.Text = "";
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Plz click the checkbox to submit the data.');", true);
                        }


                    }

                }

                if (hdnConfirm.Value == "1")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode node = doc.SelectSingleNode("ItemList");
                    string xmlString = node.InnerXml;
                    xmlString = "<ItemList>" + xmlString + "</ItemList>";
                    objInventorybll.FixedAssetData(xmlString,1,strJobstationID);
                    try { File.Delete(filePathForXML); }

                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true);
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Inserted Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Inserted.');", true);
                }

              
            }
        }

        #region========checkbox check changed=============
        protected void chkRow_CheckedChanged(object sender, EventArgs e)
        {

            //CheckBox CheckBox1 = (CheckBox)sender;
            //GridViewRow row = (GridViewRow)CheckBox1.NamingContainer;
            //Label clsqty = (Label)row.FindControl("lblclsQty");
            //TextBox auditqty = (TextBox)row.FindControl("txtAuditedQty");
            //if (CheckBox1.Checked == true)
            //{
            //    auditqty.Text = clsqty.Text;
            //    auditqty.Enabled = false;
            //}
            //else
            //{
            //    auditqty.Text = "";
            //    auditqty.Enabled = true;
            //}
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {

            //if (GvAuditList.Rows.Count > 0)
            //{
            //    for (int index = 0; index < GvAuditList.Rows.Count; index++)
            //    {

            //        if (((CheckBox)GvAuditList.Rows[index].FindControl("chkRow")).Checked == true)
            //        {

            //            Label clsqty = GvAuditList.Rows[index].FindControl("lblclsQty") as Label;
            //            string monClosingQuantity = clsqty.Text;
            //            TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
            //            auditqty.Text = clsqty.Text;
            //            auditqty.Enabled = false;

            //        }
            //        else
            //        {
            //            TextBox auditqty = GvAuditList.Rows[index].FindControl("txtAuditedQty") as TextBox;
            //            auditqty.Text = "";
            //            auditqty.Enabled = true;
            //        }

            //    }

            //}
        }
        #endregion========checkbox check changed end=============
        #region==== create xml==========
        private void CreateXml(string strAssetID, string dteAuditDate, string intAuditBy, string strRemarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemList");
                XmlNode addItem = CreateItemNode(doc, strAssetID, dteAuditDate, intAuditBy, strRemarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemList");
                XmlNode addItem = CreateItemNode(doc, strAssetID, dteAuditDate, intAuditBy, strRemarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string strAssetID, string dteAuditDate, string intAuditBy, string strRemarks)
        {

            XmlNode node = doc.CreateElement("Item");
            XmlAttribute AssetID = doc.CreateAttribute("strAssetID");
            AssetID.Value = strAssetID;

            XmlAttribute AuditDate = doc.CreateAttribute("dteAuditDate");
            AuditDate.Value = dteAuditDate;

            XmlAttribute AuditBy = doc.CreateAttribute("intAuditBy");
            AuditBy.Value = intAuditBy;

            XmlAttribute Remarks = doc.CreateAttribute("strRemarks");
            Remarks.Value = strRemarks;

            node.Attributes.Append(AssetID);
            node.Attributes.Append(AuditDate);
            node.Attributes.Append(AuditBy);
            node.Attributes.Append(Remarks);

            return node;
        }
        #endregion ======= end xml ========
    }
}