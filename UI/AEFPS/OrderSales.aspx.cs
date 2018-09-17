
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.AEFPS;
using System;
 
using System.Data; 
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class OrderSales : BasePage
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        int enroll, mrrId, intWh;
        string filePathForXML; string xmlString = "";
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\OrderSales";
        string stop = "stopping AEFPS\\OrderSales";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/AEFPS/Data/Br__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvOrder.DataSource = ""; dgvOrder.DataBind(); }
                catch { }
                DefaultBind();
            }
            else { }
        }

        private void DefaultBind()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objRec.DataView(1, "", 0, 0, DateTime.Now, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(13, "", intWh, 0, DateTime.Now, enroll);
                dgvOrder.DataSource = dt;
                dgvOrder.DataBind();
            }
            catch { }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\OrderSales Order Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (dgvDetalis.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());


                    for (int index = 0; index < dgvDetalis.Rows.Count; index++)
                    {
                       
                            string orderId = ((Label)dgvDetalis.Rows[index].FindControl("lblId")).Text.ToString();
                            string itemid = ((Label)dgvDetalis.Rows[index].FindControl("lblItemID")).Text.ToString();
                            string itemName= ((Label)dgvDetalis.Rows[index].FindControl("lblItemName")).Text.ToString();
                            string stockQty = ((Label)dgvDetalis.Rows[index].FindControl("lblStockQty")).Text.ToString();
                            string salesQty = ((TextBox)dgvDetalis.Rows[index].FindControl("txtSalesQty")).Text.ToString();
                            if(decimal.Parse(stockQty)>= decimal.Parse(salesQty))
                            {
                                CreateVoucherXml(orderId, itemName, itemid, salesQty);
                            } 
                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                string mrtg = objRec.MrrReceiveInsert(15, xmlString, intWh, mrrId, DateTime.Now, enroll);// use for Apps Order Sales Entry.

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                dgvDetalis.DataSource = ""; dgvDetalis.DataBind();
                dt = objRec.DataView(13, "", intWh, 0, DateTime.Now, enroll);
                dgvOrder.DataSource = dt;
                dgvOrder.DataBind();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void CreateVoucherXml(string orderId,string itemName, string itemid, string salesQty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, orderId, itemName, itemid, salesQty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, orderId, itemName, itemid, salesQty);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemNode(XmlDocument doc, string orderId,string itemName, string itemid, string salesQty)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute OrderId = doc.CreateAttribute("orderId");
            OrderId.Value = orderId;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute SalesQty = doc.CreateAttribute("salesQty");
            SalesQty.Value = salesQty; 

            node.Attributes.Append(OrderId);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(SalesQty); 
            return node;
        }

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWh = int.Parse(ddlWH.SelectedValue.ToString());
                dt = objRec.DataView(13, "", intWh, 0, DateTime.Now, enroll);
                dgvOrder.DataSource = dt;
                dgvOrder.DataBind();
            }
            catch { }
        }
        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\OrderSales Order Show Details", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
                Label lblOrderID = row.FindControl("lblOrderId") as Label;
                int OrderId = int.Parse(lblOrderID.Text.ToString());

                dt = objRec.DataView(14, "", intWh, OrderId, DateTime.Now, enroll);
                dgvDetalis.DataSource = dt;
                dgvDetalis.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {  
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true); 
            }
            catch { }
        }

    }
}