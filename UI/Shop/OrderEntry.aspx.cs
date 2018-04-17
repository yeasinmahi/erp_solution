
using SAD_BLL.AEFPS;
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

namespace UI.Shop
{
    public partial class OrderEntry : BasePage
    {
        Shop_BLL obj = new Shop_BLL();
        DataTable dt = new DataTable();
        string filePathForXML; int enroll, intqty;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/Shop/Data/shop_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvOrder.DataSource = ""; dgvOrder.DataBind(); }
                catch { }

                dt = obj.ShopOrder();
                dgvOrder.DataSource = dt;
                dgvOrder.DataBind();
            }
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmits_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrder.Rows.Count > 0)
                {

                    for (int index = 0; index < dgvOrder.Rows.Count; index++)
                    {

                        string intItemID = ((Label)dgvOrder.Rows[index].FindControl("lblItemID")).Text.ToString();
                        try { intqty = int.Parse(((TextBox)dgvOrder.Rows[index].FindControl("txtQty")).Text.ToString()); } catch { intqty = 0; }
                       
                        enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                        if (intqty != 0)
                        {
                            CreateVoucherXml(intItemID, intqty.ToString(), enroll.ToString());
                        }

                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    //user SP ERP_ASSET Database  [dbo].[sprAsetACOAXML]//
                     enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    string message =obj.ShopOrderSubmit(1,xmlString, enroll);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    try { File.Delete(filePathForXML);dgvOrder.DataSource = "";dgvOrder.DataBind(); }
                    catch { }

                }



            }
            catch { }

        }

        private void CreateVoucherXml(string intItemID, string qty, string  enroll)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemID, qty, enroll);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, intItemID, qty, enroll);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string intItemID, string qty, string enroll)
        {
            XmlNode node = doc.CreateElement("voucherentry");

            XmlAttribute IntItemID = doc.CreateAttribute("intItemID");
            IntItemID.Value = intItemID;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Enroll = doc.CreateAttribute("enroll");
            Enroll.Value = enroll;

            node.Attributes.Append(IntItemID);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Enroll);
           
            return node;
        }
    }
}