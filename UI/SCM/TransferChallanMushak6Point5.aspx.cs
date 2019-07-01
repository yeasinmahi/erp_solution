using SAD_BLL.Transport;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using GLOBAL_BLL;
using Flogging.Core;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace UI.SCM
{
    public partial class TransferChallanMushak6Point5 : BasePage
    {
        DataTable dt; InternalTransportBLL obj = new InternalTransportBLL();
        TransferBLLNew objTransfer = new TransferBLLNew();
        string filePathForXMLProcess1, filePathForXMLProcess2, xmlStringProcess1 = "", xmlStringProcess2 = "";
        string itemid, itemname, narration;
        int intFromVATAc, intToVATAc, intYear;
        DateTime dteTransferDate; string strVehicle, strGaNo;


        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXMLProcess1 = Server.MapPath("~/SCM/Data/TransferXML1_" + hdnEnroll.Value + ".xml");
            filePathForXMLProcess2 = Server.MapPath("~/SCM/Data/TransferXML2_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXMLProcess1); dgvItemList.DataSource = ""; dgvItemList.DataBind();
                File.Delete(filePathForXMLProcess2);

                dt = objTransfer.GetFromWH(int.Parse(hdnEnroll.Value));
                ddlFromWH.DataTextField = "strWareHoseName";
                ddlFromWH.DataValueField = "intWHID";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();

                dt = objTransfer.GetToWH(int.Parse(hdnEnroll.Value));
                ddlToWH.DataTextField = "strWareHoseName";
                ddlToWH.DataValueField = "intWHID";
                ddlToWH.DataSource = dt;
                ddlToWH.DataBind();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dt = objTransfer.GetProductDataForTransfer(int.Parse(ddlFromWH.SelectedValue), int.Parse(ddlToWH.SelectedValue), txtTransferDate.Text);
                ddlItemList.DataTextField = "strProduct";
                ddlItemList.DataValueField = "intTransferID";
                ddlItemList.DataSource = dt;
                ddlItemList.DataBind();
            }
            catch { }
        }

        /*
        protected void btnFuelCostAdd_Click(object sender, EventArgs e)
        {
            intPartyID = ddlFuelStation.SelectedValue.ToString();
            fuelstation = ddlFuelStation.SelectedItem.ToString();
            if (txtDieselCredit.Text == "") { dieselcredit = "0"; } else { dieselcredit = txtDieselCredit.Text; }
            if (txtCNGCredit.Text == "") { cngcredit = "0"; } else { cngcredit = txtCNGCredit.Text; }
            decimal dieselcrtk = decimal.Parse(dieselcredit.ToString());
            decimal cngcrtk = decimal.Parse(cngcredit.ToString());
            decimal ttk = dieselcrtk + cngcrtk;
            totalcredit = ttk.ToString();
            inttype = "0";

            try
            {
                if (txtFuelPurchaeDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return;
                }
                else { strFuelPurchaseDate = txtFuelPurchaeDate.Text; }
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            try
            {
                strFuelPurchaseDate = txtFuelPurchaeDate.Text;
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fuel Purchase Date Properly Input.');", true); return; }

            if (intPartyID != "" && fuelstation != "" && ttk != 0)
            {
                CreateVoucherXml(intPartyID, fuelstation, dieselcredit, cngcredit, totalcredit, inttype, strFuelPurchaseDate);
                txtDieselCredit.Text = "";
                txtCNGCredit.Text = "";
                ddlFuelStation.Text = "";
            }
            else
            { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Fuel Station.');", true); return; }

        }
        */

        #region==== Transfer Product Add =============================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CreateTransferXmlProcess1(itemid, itemname, narration);
            CreateTransferXmlProcess2(itemid, itemname, narration);
        }
        private void CreateTransferXmlProcess1(string intItemID, string strItemName, string strNarration)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLProcess1))
            {
                doc.Load(filePathForXMLProcess1);
                XmlNode rootNode = doc.SelectSingleNode("TransferProcess1");
                XmlNode addItem = CreateItemNode(doc, intItemID, strItemName, strNarration);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("TransferProcess1");
                XmlNode addItem = CreateItemNode(doc, intItemID, strItemName, strNarration);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLProcess1);
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string intItemID, string strItemName, string strNarration)
        {
            XmlNode node = doc.CreateElement("TransferProcess1");

            XmlAttribute IntItemID = doc.CreateAttribute("intItemID");
            IntItemID.Value = intItemID;
            XmlAttribute StrItemName = doc.CreateAttribute("strItemName");
            StrItemName.Value = strItemName;
            XmlAttribute StrNarration = doc.CreateAttribute("strNarration");
            StrNarration.Value = strNarration;

            node.Attributes.Append(IntItemID);
            node.Attributes.Append(StrItemName);
            node.Attributes.Append(StrNarration);
            return node;
        }



        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLProcess1);
            XmlNode dSftTm = doc.SelectSingleNode("TransferProcess1");
            xmlStringProcess1 = dSftTm.InnerXml;
            xmlStringProcess1 = "<TransferProcess1>" + xmlStringProcess1 + "</TransferProcess1>";
            StringReader sr = new StringReader(xmlStringProcess1);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvItemList.DataSource = ds; }
            else { dgvItemList.DataSource = ""; }
            dgvItemList.DataBind();
        }

        private void CreateTransferXmlProcess2(string intItemID, string strItemName, string strNarration)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLProcess2))
            {
                doc.Load(filePathForXMLProcess2);
                XmlNode rootNode = doc.SelectSingleNode("TransferProcess2");
                XmlNode addItem = CreateItemNode2(doc, intItemID, strItemName, strNarration);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("TransferProcess2");
                XmlNode addItem = CreateItemNode2(doc, intItemID, strItemName, strNarration);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLProcess2);
        }

        private XmlNode CreateItemNode2(XmlDocument doc, string intItemID, string strItemName, string strNarration)
        {
            XmlNode node = doc.CreateElement("TransferProcess2");

            XmlAttribute IntItemID = doc.CreateAttribute("intItemID");
            IntItemID.Value = intItemID;
            XmlAttribute StrItemName = doc.CreateAttribute("strItemName");
            StrItemName.Value = strItemName;
            XmlAttribute StrNarration = doc.CreateAttribute("strNarration");
            StrNarration.Value = strNarration;

            node.Attributes.Append(IntItemID);
            node.Attributes.Append(StrItemName);
            node.Attributes.Append(StrNarration);
            return node;
        }

        protected void dgvItemList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLProcess1);
                XmlNode dSftTm = doc.SelectSingleNode("TransferProcess1");
                xmlStringProcess1 = dSftTm.InnerXml;
                xmlStringProcess1 = "<TransferProcess1>" + xmlStringProcess1 + "</TransferProcess1>";
                StringReader sr = new StringReader(xmlStringProcess1);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvItemList.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvItemList.DataSource;
                string chek = dsGrid.Tables[0].Rows[e.RowIndex][5].ToString();

                dsGrid.Tables[0].Rows[dgvItemList.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLProcess1);
                DataSet dsGridAfterDelete = (DataSet)dgvItemList.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLProcess1); dgvItemList.DataSource = ""; dgvItemList.DataBind();
                }
                else { LoadGridwithXml(); }

            }
            catch { }

        }

        #endregion==== Transfer Product Add Ended ======================================================

        #region==== Transfer Action Start =============================================================
        protected void btnTransferAction_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intFromVATAc = int.Parse(ddlFromWH.SelectedValue);
                intToVATAc = int.Parse(ddlToWH.SelectedValue);
                strVehicle = txtVehicleNo.Text;
                dteTransferDate = DateTime.Parse(txtTransferDate.Text);

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLProcess1);
                    XmlNode dSftTm = doc.SelectSingleNode("TransferProcess1");
                    xmlStringProcess1 = dSftTm.InnerXml;
                    xmlStringProcess1 = "<TransferProcess1>" + xmlStringProcess1 + "</TransferProcess1>";
                }
                catch { }

                dt = new DataTable();
                dt = objTransfer.GetMushakGa6Point5PrintData(intFromVATAc, intToVATAc, strVehicle, dteTransferDate, int.Parse(hdnEnroll.Value), xmlStringProcess1);
                if (dt.Rows.Count > 0)
                {
                    intYear = int.Parse(dt.Rows[0]["intFromVatAc"].ToString());
                    intFromVATAc = int.Parse(dt.Rows[0]["intVatYear"].ToString());
                    strGaNo = dt.Rows[0]["M11GaNo"].ToString();
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DO_Edit('" + strGaNo + "', '" + intFromVATAc + "', '" + intYear + "');", true);


            }

        }
        #endregion==== Transfer Action Ended ===========================================================










    }
}