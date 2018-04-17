using BLL.Accounts.PartyPayment;
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

namespace UI.Vat
{
    public partial class ProductionEntry : BasePage
    {
        string xmlString = ""; string msgStatus = ""; string filePathForXML="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();//HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                btnSubmit.Visible = false;
            }
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("Production");
            xmlString = dSftTm.InnerXml;
            xmlString = "<Production>" + xmlString + "</Production>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            dgvViewproduction.DataSource = ds;
            dgvViewproduction.DataBind();
            if (dgvViewproduction.Rows.Count > 0)
            { btnSubmit.Visible = false; }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Production");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Production>" + xmlString + "</Production>";
                if (dgvViewproduction.Rows.Count > 0)
                {
                    PartyBill vat = new PartyBill();
                    DateTime date = DateTime.Parse(txtDate.Text);
                    //msgStatus = vat.In(xmlString);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + "');", true);
                    //File.Delete(filePathForXML); LoadGridwithXml();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please add atleast single production.');", true); }
            }
            catch { }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string itemid = ddlProduct.SelectedValue.ToString();
                    string product = ddlProduct.SelectedItem.ToString();
                    //double quantity = double.Parse(monQuantity.Text);
                    string quantity = monQuantity.Text;
                    string date = txtDate.Text;

                    //filePathForXML = Server.MapPath("/Vat/" + ddlVatAcc.SelectedValue.ToString() + "," + date + ".xml");
                    //CreateXml(product, quantity.ToString(), itemid, date);
                    PartyBill vat = new PartyBill();
                    string userid = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    msgStatus = vat.InsertProductionInformation(itemid, quantity.ToString(), date, ddlVatAcc.SelectedValue.ToString(), userid);
                    if (msgStatus != "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgStatus + " Product: "+
                        ddlProduct.SelectedItem.ToString() + "; Quantity: " + quantity + "; Date: " + date + "');", true);
                        //LoadGridwithXml();
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry to add production.');", true); }
                    monQuantity.Text = "";
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('"+ ex.ToString() +"');", true);
                }
            }
        }
        private void CreateXml(string product, string quantity, string itemid, string date)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Production");
                XmlNode addItem = CreateItemNode(doc, product, quantity, itemid, date);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Production");
                XmlNode addItem = CreateItemNode(doc, product, quantity, itemid, date);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string product, string quantity, string itemid, string date)
        {
            XmlNode node = doc.CreateElement("productionlist");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute ProductName = doc.CreateAttribute("product");
            ProductName.Value = product;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Date = doc.CreateAttribute("date");
            Date.Value = date;
            node.Attributes.Append(Itemid);
            node.Attributes.Append(ProductName);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Date);
            return node;
        }
        protected void ddlVatAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnvtacc.Value = ddlVatAcc.SelectedValue.ToString();
        }

    }
}