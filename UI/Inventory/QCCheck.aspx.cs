using HR_BLL.Global;
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

namespace UI.Inventory
{
    public partial class QCCheck : BasePage
    {
        DaysOfWeek bllobj = new DaysOfWeek(); DataTable dt = new DataTable(); string xmlpath; 
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/INSBY_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_PO.xml");
            if (!IsPostBack){ hdnpoid.Value = "0";
            hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            try { File.Delete(xmlpath); } catch { } pnlUpperControl.DataBind();
            }
        }
        protected void Action_Click(object sender, EventArgs e)
        {
            try
            {
                string poid = ((Button)sender).CommandArgument.ToString();
                dt = bllobj.GetPODetails(int.Parse(poid), int.Parse(hdnenroll.Value));
                if (dt.Rows.Count > 0) { dgv.DataSource = dt; dgv.DataBind(); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ShowDetailsDiv('" + poid + "');", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {          
                    for (int index = 0; index < dgv.Rows.Count; index++)
                    {
                        bool ysnChecked = false; string proceed = "0";
                        string itemid = ((Label)dgv.Rows[index].FindControl("lblitmno")).Text.ToString();
                        string poqnty = ((Label)dgv.Rows[index].FindControl("lblpoqnty")).Text.ToString();
                        string quantity = ((TextBox)dgv.Rows[index].FindControl("txtChkQuantity")).Text.ToString();
                        string remarks = ((TextBox)dgv.Rows[index].FindControl("txtRemarks")).Text.ToString();
                        ysnChecked = ((CheckBox)dgv.Rows[index].Cells[7].Controls[0]).Checked;
                        if (ysnChecked) { proceed = "1"; } if (quantity.Length <= 0) { quantity = "0"; }
                        if (int.Parse(quantity) > 0) { CreateXml(hdnpoid.Value, itemid, poqnty, quantity, remarks, proceed); }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath); int actionby = int.Parse(hdnenroll.Value.ToString());
                    XmlNode nd = doc.SelectSingleNode("Inspection");
                    string xmlString = nd.InnerXml;
                    xmlString = "<Inspection>" + xmlString + "</Inspection>";
                    string msg = bllobj.SubmitPOInspection(xmlString, actionby);File.Delete(xmlpath); dgvlist.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "HideReasonDiv('" + msg + "');", true);
                    
                }
                catch { }
            }
        }
        private void CreateXml(string poid, string itemid, string poqnty, string quantity, string remarks, string proceed)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Inspection");
                XmlNode addItem = CreateNode(doc, poid, itemid, poqnty, quantity, remarks, proceed);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Inspection");
                XmlNode addItem = CreateNode(doc, poid, itemid, poqnty, quantity, remarks, proceed);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string poid, string itemid, string poqnty, string quantity, string remarks, string proceed)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute PO = doc.CreateAttribute("poid");
            PO.Value = poid;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute POqnty = doc.CreateAttribute("poqnty");
            POqnty.Value = poqnty;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Remarks = doc.CreateAttribute("remarks");
            Remarks.Value = remarks;
            XmlAttribute Proceed = doc.CreateAttribute("proceed");
            Proceed.Value = proceed;

            node.Attributes.Append(PO);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(POqnty);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Remarks);
            node.Attributes.Append(Proceed);
            return node;
        }





    }
}