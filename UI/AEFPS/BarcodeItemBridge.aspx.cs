
using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class BarcodeItemBridge : System.Web.UI.Page
    {
        Receive_BLL objRec = new Receive_BLL();
        DataTable dt = new DataTable();
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        int enroll, mrrId, intWh; string ImagePath = "";
        string item = ""; string itemid = "", uom;
        string filePathForXML; string xmlString = "";
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\BarcodeItemBridge";
        string stop = "stopping AEFPS\\BarcodeItemBridge";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/AEFPS/Data/Br__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvBridge.DataSource = ""; dgvBridge.DataBind(); }
                catch { }
                DefaltLoad();
            }
            else
            {

            }
        }
        private void DefaltLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()); 
                dt = objRec.DataView(9, "", 0, 0, DateTime.Now, enroll);
                dgvBridge.DataSource = dt;
                dgvBridge.DataBind();

            }
            catch { }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
           

            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\BarcodeItemBridge Barcode Item Bridge Save ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                
                dt = objRec.DataView(9, "", 0, 0, DateTime.Now, enroll);
                dgvBridge.DataSource = dt;
                dgvBridge.DataBind();
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

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\BarcodeItemBridge Barcode Item Save ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (dgvBridge.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());


                    for (int index = 0; index < dgvBridge.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvBridge.Rows[index].FindControl("chkRow")).Checked == true)
                        {

                            string itemid = ((Label)dgvBridge.Rows[index].FindControl("lblItemId")).Text.ToString();
                            string itemName = ((TextBox)dgvBridge.Rows[index].FindControl("txtItemName")).Text.ToString();
                            string itemCode = ((TextBox)dgvBridge.Rows[index].FindControl("lblItemCode")).Text.ToString();
                            string barcode = ((TextBox)dgvBridge.Rows[index].FindControl("txtBarcode")).Text.ToString();

                            CreateVoucherXml(itemid, itemName, itemCode, barcode);
                        }


                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }

                string mrtg = objRec.MrrReceiveInsert(10, xmlString, 0, mrrId, DateTime.Now, enroll);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                dgvBridge.DataSource = ""; dgvBridge.DataBind();
                dt = objRec.DataView(9, "", 0, 0, DateTime.Now, enroll);
                dgvBridge.DataSource = dt;
                dgvBridge.DataBind();
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

        private void CreateVoucherXml(string itemid, string itemName,string  itemCode, string barcode)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemBridge(doc, itemid, itemName, itemCode, barcode);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemBridge(doc, itemid, itemName, itemCode, barcode);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        private XmlNode CreateItemBridge(XmlDocument doc, string itemid,string itemName,string itemCode ,string barcode)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;
            XmlAttribute ItemCode = doc.CreateAttribute("itemCode");
            ItemCode.Value = itemCode;
            XmlAttribute Barcode = doc.CreateAttribute("barcode");
            Barcode.Value = barcode;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(ItemName);
            node.Attributes.Append(ItemCode);
            node.Attributes.Append(Barcode);
        
            return node;
        }
    }
}