using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;

namespace UI.Wastage
{
    public partial class SO : System.Web.UI.Page
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;

        int intEnroll;
        string filePathForXML, xmlString, xml;
        string itemid, itemname, uom, qty, rate, value, remarks;
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Dairy/Data/MilkMRR_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                    dt = obj.GetUnitList(int.Parse(hdnEnroll.Value));
                    ddlUnitName.DataTextField = "strUnit";
                    ddlUnitName.DataValueField = "intUnitID";
                    ddlUnitName.DataSource = dt;
                    ddlUnitName.DataBind();

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }        
        #region ===== Item Add & Load Grid Action ===========================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            itemid = ddlItem.SelectedValue.ToString();
            itemname = ddlItem.SelectedItem.ToString();
            uom = txtUOM.Text;
            qty = txtQty.Text;
            rate = txtRate.Text;
            value = txtValue.Text;
            remarks = txtRemarks.Text;

            CreateAddXml(itemid, itemname, uom, qty, rate, value, remarks);

            txtUOM.Text = "";
            txtQty.Text = "";
            txtRate.Text = "";
            txtValue.Text = "";
            txtRemarks.Text = "";
        }   
        private void CreateAddXml(string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
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
                XmlNode xlnd = doc.SelectSingleNode("SOItem");
                xmlString = xlnd.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvSOItem.DataSource = ds; } else { dgvSOItem.DataSource = ""; }
                dgvSOItem.DataBind();
            }
            catch { dgvSOItem.DataSource = ""; dgvSOItem.DataBind(); }
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlNode node = doc.CreateElement("SOItem");

            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Value = doc.CreateAttribute("value"); Value.Value = value;
            XmlAttribute Remarks = doc.CreateAttribute("remarks"); Remarks.Value = remarks;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Value);
            node.Attributes.Append(Remarks);
            return node;
        }
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvSOItem.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvSOItem.DataSource;
                dsGrid.Tables[0].Rows[dgvSOItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvSOItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvSOItem.DataSource = ""; dgvSOItem.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal totalqty = 0;
        protected decimal totalvalue = 0;
        protected void dgvSOItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                }
            }
            catch { }
        }

        #endregion ==========================================================================================

        #region ===== Submit Action =========================================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (dgvSOItem.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<SOItem>" + xmlString + "</SOItem>";
                        xml = xmlString;
                    }
                    catch { }
                    if (xml == "") { return; }
                }

                //Final Update
                //string message = objDairy.InsertMilkMrrForFactory(dteMRRDate, intCCID, intVehicleID, decMRRFat, intInsertBy, xml);

                //if (filePathForXML != null) { File.Delete(filePathForXML); }
                //dgvSOItem.DataSource = ""; dgvSOItem.DataBind();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
        }

        #endregion ==========================================================================================




























    }
}