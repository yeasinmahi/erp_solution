using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Sales;
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

namespace UI.SAD.Sales.Return
{
    public partial class SalesReturn : BasePage
    {
        DataTable dt = new DataTable(); SalesEntry se = new SalesEntry(); string msg = ""; string xmlpath="";
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\SalesReturn";
        string stop = "stopping SAD\\Sales\\Report\\SalesReturn";

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/SAD/Sales/Data/Rtn_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try { File.Delete(xmlpath); } catch { }
            }            
        }
        protected void btnShow_Click(object sender, EventArgs e) { LoadGrid(); }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\SalesReturn Sales Return", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (txtSearch.Text.Length > 0)
                {
                    string code = txtSearch.Text; txtCustomer.Text = ""; txtChallan.Text = ""; lblcdt.Text = "";
                    int unit = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                    dt = se.GetSalesEntryInfo(code, unit); dgvrtn.DataSource = "";
                    if (dt.Rows.Count > 0)
                    {
                        txtCustomer.Text = dt.Rows[0]["strName"].ToString();
                        txtChallan.Text = dt.Rows[0]["strCode"].ToString();
                        lblcdt.Text = DateTime.Parse(dt.Rows[0]["dteDate"].ToString()).ToString("yyyy-MM-dd");
                        dgvrtn.DataSource = dt;
                    }
                    dgvrtn.DataBind(); txtChallan.Text = "";
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
    
        protected void btvSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\SalesReturn Sales Return Entry", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                if (hdnconfirm.Value == "1" && dt.Rows.Count > 0)
                {
                    string subtotal = "0.00"; string slsid = ""; string cust = ""; string itmid = ""; string uomid = "";
                    string rate = ""; string quantity = "0";
                    for (int index = 0; index < dgvrtn.Rows.Count; index++)
                    {   
                        subtotal="0.00";
                        slsid = ((HiddenField)dgvrtn.Rows[index].FindControl("hdnid")).Value.ToString();
                        cust = ((HiddenField)dgvrtn.Rows[index].FindControl("hdncust")).Value.ToString();
                        itmid = ((HiddenField)dgvrtn.Rows[index].FindControl("itmid")).Value.ToString();
                        uomid = ((HiddenField)dgvrtn.Rows[index].FindControl("hdnuom")).Value.ToString();
                        rate = ((HiddenField)dgvrtn.Rows[index].FindControl("hdnrate")).Value.ToString();
                        quantity = ((TextBox)dgvrtn.Rows[index].FindControl("txtRtnqnt")).Text.ToString();
                        if (quantity == "") { quantity = "0"; }
                        subtotal = (int.Parse(quantity) * decimal.Parse(rate)).ToString(); }
                        if (decimal.Parse(subtotal) > 0) { CreateReturnXml(slsid, cust, itmid, uomid, rate, quantity, subtotal); }
                    }
                #region ------------ Insert into dataBase -----------
                int actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode dSftTm = doc.SelectSingleNode("Return");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<Return>" + xmlString + "</Return>";
                msg = se.SubmitReturn(xmlString, actionby); File.Delete(xmlpath);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                LoadGrid();
                #endregion ------------ Insertion End ----------------
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
                File.Delete(xmlpath); ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input validate data.');", true);
            }

            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
            
        }
        private void CreateReturnXml(string slsid, string cust, string itmid, string uomid, string rate, string quantity, string subtotal)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Return");
                XmlNode addItem = CreateItemNode(doc, slsid, cust, itmid, uomid, rate, quantity, subtotal);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Return");
                XmlNode addItem = CreateItemNode(doc, slsid, cust, itmid, uomid, rate, quantity, subtotal);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string slsid, string cust, string itmid, string uomid, string rate, string quantity, string subtotal)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Slsid = doc.CreateAttribute("slsid");
            Slsid.Value = slsid;
            XmlAttribute Cust = doc.CreateAttribute("cust");
            Cust.Value = cust;
            XmlAttribute Itmid = doc.CreateAttribute("itmid");
            Itmid.Value = itmid;
            XmlAttribute Uomid = doc.CreateAttribute("uomid");
            Uomid.Value = uomid;
            XmlAttribute Rate = doc.CreateAttribute("rate");
            Rate.Value = rate;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute Subtotal = doc.CreateAttribute("subtotal");
            Subtotal.Value = subtotal;

            node.Attributes.Append(Slsid);
            node.Attributes.Append(Cust);
            node.Attributes.Append(Itmid);
            node.Attributes.Append(Uomid);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(Subtotal);
            return node;
        }
        







    }
}