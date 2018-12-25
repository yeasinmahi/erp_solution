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
using UI.ClassFiles;
using SAD_BLL.Vat;
using System.IO;
using System.Xml;

namespace UI.VAT_Management
{
    public partial class PurchaseEntry : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intPurTypeID; DateTime dtePurchaseDate;
        string filePathForXML, xmlString = "", xml, strMessage;
        string mid, mname, suppid, challan, chdate, qty, withsdvat, sd, vat, total, exempted;

        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                filePathForXML = Server.MapPath("~/VAT_Management/Data/PurchaseEntry_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvPurchaseEntry.DataSource = ""; dgvPurchaseEntry.DataBind();
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();

                    hdnysnFactory.Value = "0";
                    dt = new DataTable();
                    dt = objvat.GetUserInfoForVAT(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        hdnysnFactory.Value = dt.Rows[0]["ysnFactory"].ToString();
                    }
                }
            }
            catch { }
        }
        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }

        #region ===== Save Purchase Entry Action ==============================================       
        protected void btnSavePurchase_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPurTypeID = int.Parse(ddlType.SelectedValue.ToString());
                try { dtePurchaseDate = DateTime.Parse(txtPurDate.Text); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please put a purchase date');", true);
                    return;
                }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                    xml = xmlString;
                }
                catch { }

                if(xml == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Item to save');", true);
                    return;
                }

                string message = objvat.InsertPurchaseEntry(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value), int.Parse(hdnEnroll.Value), intPurTypeID, dtePurchaseDate, int.Parse(hdnysnFactory.Value), xml);                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                txtPurDate.Text = "";
                File.Delete(filePathForXML); dgvPurchaseEntry.DataSource = ""; dgvPurchaseEntry.DataBind();
            }
        }

        #endregion ============================================================================

        #region ===== Material Add Option =====================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            try
            {
                mid = ddlRM.SelectedValue.ToString();
                mname = ddlRM.SelectedItem.ToString();
                if(mname == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Material');", true);
                    return;
                }
                suppid = ddlSupplier.SelectedValue.ToString();
                if (ddlSupplier.SelectedItem.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Invalid Sepplier Selected');", true);
                    return;
                }
                challan = txtChallan.Text;
                if(challan == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please put the challan no');", true);
                    return;
                }

                chdate = txtClnDate.Text;
                try { DateTime cdate = DateTime.Parse(txtClnDate.Text); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please put the challan date');", true);
                    return;
                }
                if (chdate == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please put the challan date');", true);
                    return;
                }
                if (txtQuantity.Text == "") { qty = "0";} else { qty = txtQuantity.Text; }
                if (txtWithoutSDVAT.Text == "") { withsdvat = "0"; } else { withsdvat = txtWithoutSDVAT.Text; }
                if (txtSD.Text == "") { sd = "0"; } else { sd = txtSD.Text; }
                if (txtVAT.Text == "") { vat = "0"; } else { vat = txtVAT.Text; }
                try { total = (Math.Round(decimal.Parse(withsdvat) + decimal.Parse(sd) + decimal.Parse(vat), 2)).ToString(); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You cannot add any material without an amount');", true);
                    return;
                }
                if(total == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You cannot add any material without an amount');", true);
                    return;                    
                }

                exempted = ddlExempted.SelectedItem.ToString();
                if(exempted == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select whether this purchase is tax exempted or not.');", true);
                    return;                    
                }

                //Start Create XML
                CreateVoucherXml(mid, mname, suppid, challan, chdate, qty, withsdvat, sd, vat, total, exempted);
                txtChallan.Text = "";
                txtClnDate.Text = "";
                txtQuantity.Text = "";
                txtWithoutSDVAT.Text = "";
                txtSD.Text = "";
                txtVAT.Text = "";               
            }
            catch { }
        }
        private void CreateVoucherXml(string mid, string mname, string suppid, string challan, string chdate, string qty, string withsdvat, string sd, string vat, string total, string exempted)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, mname, suppid, challan, chdate, qty, withsdvat, sd, vat, total, exempted);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, mid, mname, suppid, challan, chdate, qty, withsdvat, sd, vat, total, exempted);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
            xmlString = dSftTm.InnerXml;
            xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvPurchaseEntry.DataSource = ds; }
            else { dgvPurchaseEntry.DataSource = ""; }
            dgvPurchaseEntry.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string mid, string mname, string suppid, string challan, string chdate, string qty, string withsdvat, string sd, string vat, string total, string exempted)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Mid = doc.CreateAttribute("mid"); Mid.Value = mid;
            XmlAttribute Mname = doc.CreateAttribute("mname"); Mname.Value = mname;
            XmlAttribute Suppid = doc.CreateAttribute("suppid"); Suppid.Value = suppid;
            XmlAttribute Challan = doc.CreateAttribute("challan"); Challan.Value = challan;
            XmlAttribute Chdate = doc.CreateAttribute("chdate"); Chdate.Value = chdate;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Withsdvat = doc.CreateAttribute("withsdvat"); Withsdvat.Value = withsdvat;
            XmlAttribute Sd = doc.CreateAttribute("sd"); Sd.Value = sd;
            XmlAttribute Vat = doc.CreateAttribute("vat"); Vat.Value = vat;
            XmlAttribute Total = doc.CreateAttribute("total"); Total.Value = total;
            XmlAttribute Exempted = doc.CreateAttribute("exempted"); Exempted.Value = exempted;

            node.Attributes.Append(Mid);
            node.Attributes.Append(Mname);
            node.Attributes.Append(Suppid);
            node.Attributes.Append(Challan);
            node.Attributes.Append(Chdate);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Withsdvat);
            node.Attributes.Append(Sd);
            node.Attributes.Append(Vat);
            node.Attributes.Append(Total);
            node.Attributes.Append(Exempted);
            return node;

        }
        protected void dgvPurchaseEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                xmlString = dSftTm.InnerXml;
                xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvPurchaseEntry.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvPurchaseEntry.DataSource;
                dsGrid.Tables[0].Rows[dgvPurchaseEntry.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvPurchaseEntry.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvPurchaseEntry.DataSource = ""; dgvPurchaseEntry.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        #endregion ============================================================================










    }
}