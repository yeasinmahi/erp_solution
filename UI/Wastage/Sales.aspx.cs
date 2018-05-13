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
    public partial class Sales : System.Web.UI.Page
    {
        #region ===== Variable Decliaration ===================================================================
        Project_Class objDairy = new Project_Class();
        DataTable dt;
        int enroll;
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
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }


        #region ===== Item Add & Load Grid Action ===========================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            

            CreateAddXml(itemid, itemname, uom, qty, rate, value, remarks);
          
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

































    }
}