using Flogging.Core;
using GLOBAL_BLL;
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

namespace UI.AEFPS
{
    public partial class StockReportForAudit : BasePage
    {
        int intWHID, intEnroll, intPayType; DataTable dt=new DataTable(); FPReportBLL bll = new FPReportBLL(); Receive_BLL objRec = new Receive_BLL();
        string strFrom, strTo;
        string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;
        string  xmlString, xml, whid, itemid, oldstock, auditstock, remarks;
         
        string xmlpath;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\StockReportForAudit";
        string stop = "stopping AEFPS\\StockReportForAudit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    xmlpath = Server.MapPath("~/AEFPS/Data/AppAudit_" + Session[SessionParams.USER_ID].ToString() + ".xml");
                    try
                    {
                        File.Delete(xmlpath);
                    }
                    catch { }

                    intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());

                    dt = objRec.DataView(1, "", 0, 0, DateTime.Now, intEnroll);
                    ddlWH.DataSource = dt;
                    ddlWH.DataTextField = "strName";
                    ddlWH.DataValueField = "Id";
                    ddlWH.DataBind();

                }
                catch { }
            }
        }
         
        protected void btnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\StockReportForAudit Stock Report For Audit Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                DataTable et = new DataTable();
                et = bll.GetReportForAudit(intWHID);
                dgvAuditStock.DataSource = et;
                dgvAuditStock.DataBind();

                // dt = objRec.DataView(1, "", 0, 0, DateTime.Now, 32897);
                //dgvReceive.DataSource = et;
                // dgvReceive.DataBind();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\StockReportForAudit Audit Submit", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                xmlpath = Server.MapPath("~/AEFPS/Data/AppAudit_" + Session[SessionParams.USER_ID].ToString() + ".xml");

            if (dgvAuditStock.Rows.Count > 0)
            {
                try
                {
                    File.Delete(xmlpath);
                }
                catch { }
                bool ysnChecked;
                for (int i = 0; i < dgvAuditStock.Rows.Count; i++)
                {
                    string statuscheck = ((TextBox)dgvAuditStock.Rows[i].FindControl("txtAuditStock")).Text.ToString();
                    ysnChecked = ((CheckBox)dgvAuditStock.Rows[i].FindControl("chkAudit")).Checked;
                    if (statuscheck != "")
                    {
                        if (ysnChecked)
                        {
                            itemid = ((Label)dgvAuditStock.Rows[i].FindControl("lblID")).Text.ToString();
                            oldstock = ((Label)dgvAuditStock.Rows[i].FindControl("lblStock")).Text.ToString();
                            auditstock = ((TextBox)dgvAuditStock.Rows[i].FindControl("txtAuditStock")).Text.ToString();
                            remarks = ((TextBox)dgvAuditStock.Rows[i].FindControl("txtRemarks")).Text.ToString();
                            
                            CreateXml(itemid, oldstock, auditstock, remarks);
                            
                        }
                    }
                }
                #region ============= Insert Into Database ======================

                try
                {
                    if (xml == "") { return; }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlNode dAssignInfo = doc.SelectSingleNode("Approve");
                    string xmlString = dAssignInfo.InnerXml;
                    xmlString = "<Approve>" + xmlString + "</Approve>";
                    xml = xmlString;
                }
                catch { }
                if (xml == "") { return; }

                intWHID = int.Parse(ddlWH.SelectedValue.ToString());
                intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (xml != null)
                {
                    string message = bll.InsertAuditStock(intWHID, intEnroll, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    File.Delete(xmlpath); //LoadGrid();
                }
                #endregion
            }
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

        private void CreateXml(string itemid, string oldstock, string auditstock, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Approve");
                XmlNode addItem = CreateItemNode(doc, itemid, oldstock, auditstock, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Approve");
                XmlNode addItem = CreateItemNode(doc, itemid, oldstock, auditstock, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string oldstock, string auditstock, string remarks)
        {
            XmlNode node = doc.CreateElement("Approve");

            XmlAttribute Item = doc.CreateAttribute("itemid"); Item.Value = itemid;
            XmlAttribute OldStock = doc.CreateAttribute("oldstock"); OldStock.Value = oldstock;
            XmlAttribute AuditStock = doc.CreateAttribute("auditstock"); AuditStock.Value = auditstock;
            XmlAttribute Remarks = doc.CreateAttribute("remarks"); Remarks.Value = remarks;

            node.Attributes.Append(Item);
            node.Attributes.Append(OldStock);
            node.Attributes.Append(AuditStock);
            node.Attributes.Append(Remarks);
            return node;
        }














    }
}