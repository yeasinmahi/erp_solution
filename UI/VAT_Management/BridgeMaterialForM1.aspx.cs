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
    public partial class BridgeMaterialForM1 : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intFGID, intVatItemID, intPart, intCount;
        string filePathForXML, xmlString = "", xml, rmid, rmname;

        #endregion =====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                filePathForXML = Server.MapPath("~/VAT_Management/Data/RMBridge_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvRM.DataSource = ""; dgvRM.DataBind();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = new DataTable();
                    dt = objvat.GetVATAccountListByEnroll(int.Parse(hdnEnroll.Value));
                    ddlVatAccount.DataTextField = "strVATAccountName";
                    ddlVatAccount.DataValueField = "intVatPointID";
                    ddlVatAccount.DataSource = dt;
                    ddlVatAccount.DataBind();
                    lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();

                    hdnVatAccID.Value = ddlVatAccount.SelectedValue.ToString();
                    hdnVatAccID.Value = "1";

                    dt = new DataTable();
                    dt = objvat.GetVATItemList(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value));
                    ddlVATMaterial.DataTextField = "strVatProductName";
                    ddlVATMaterial.DataValueField = "intID";
                    ddlVATMaterial.DataSource = dt;
                    ddlVATMaterial.DataBind();
                 
                    dt = new DataTable();
                    dt = objvat.GetRMList(int.Parse(hdnUnit.Value));
                    ddlRM.DataTextField = "strRawMaterial";
                    ddlRM.DataValueField = "intItemID";
                    ddlRM.DataSource = dt;
                    ddlRM.DataBind();
                }
            }
            catch { }
        }

        protected void btnUpdateBridge_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intPart = 2;
                    intFGID = 0;
                    intVatItemID = int.Parse(ddlVATMaterial.SelectedValue.ToString());

                    if (dgvRM.Rows.Count > 0)
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXML);
                            XmlNode dSftTm = doc.SelectSingleNode("VMBridge");
                            string xmlString = dSftTm.InnerXml;
                            xmlString = "<VMBridge>" + xmlString + "</VMBridge>";
                            xml = xmlString;
                        }
                        catch { }
                        if (xml == "") { return; }
                    }

                    string message = objvat.InsertVATItemAndMaterialBridge(intPart, intFGID, intVatItemID, int.Parse(hdnVatAccID.Value), int.Parse(hdnEnroll.Value), xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    File.Delete(filePathForXML); dgvRM.DataSource = ""; dgvRM.DataBind();
                }
            }
            catch { }
        }

        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();            
        }

        #region ===== Add Product =================================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            RMAddAdd();
        }
        private void RMAddAdd()
        {
            rmid = ddlRM.SelectedValue.ToString();
            rmname = ddlRM.SelectedItem.ToString();

            #region ===== Product Qty Update ==================================================
            intCount = 0;

            if (dgvRM.Rows.Count > 0)
            {
                for (int index = 0; index < dgvRM.Rows.Count; index++)
                {
                    string olditemid = ((Label)dgvRM.Rows[index].FindControl("lblRMID")).Text.ToString();

                    if (olditemid == rmid)
                    {                       
                        intCount = intCount + 1;
                    }
                }
            }

            if (intCount == 0)
            {
                CreateVoucherXml(rmid, rmname);              
            }
            else if(intCount > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This Raw Material is already added in this list.');", true);
                return;
            }
            #endregion ========================================================================
        }
        private void CreateVoucherXml(string rmid, string rmname)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("VMBridge");
                XmlNode addItem = CreateItemNode(doc, rmid, rmname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("VMBridge");
                XmlNode addItem = CreateItemNode(doc, rmid, rmname); ;
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
            XmlNode dSftTm = doc.SelectSingleNode("VMBridge");
            xmlString = dSftTm.InnerXml;
            xmlString = "<VMBridge>" + xmlString + "</VMBridge>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvRM.DataSource = ds; }
            else { dgvRM.DataSource = ""; }
            dgvRM.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string rmid, string rmname)
        {
            XmlNode node = doc.CreateElement("VMBridge");

            XmlAttribute Rmid = doc.CreateAttribute("rmid");
            Rmid.Value = rmid;
            XmlAttribute Rmname = doc.CreateAttribute("rmname");
            Rmname.Value = rmname;

            node.Attributes.Append(Rmid);
            node.Attributes.Append(Rmname);
            return node;
        }
        protected void dgvRM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("VMBridge");
                xmlString = dSftTm.InnerXml;
                xmlString = "<VMBridge>" + xmlString + "</VMBridge>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvRM.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvRM.DataSource;
                dsGrid.Tables[0].Rows[dgvRM.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvRM.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvRM.DataSource = ""; dgvRM.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        #endregion ================================================================================










    }
}