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
        string filePathForXMLProcess1, xmlStringProcess1 = "";
        string transferid, itemname, narration, qty, uom;
        int intFromVATAc, intToVATAc, intYear;
        DateTime dteTransferDate; string strVehicle, strGaNo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXMLProcess1 = Server.MapPath("~/SCM/Data/TransferXML1_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXMLProcess1); dgvItemList.DataSource = ""; dgvItemList.DataBind();

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

        #region==== Transfer Product Add =============================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            transferid = ddlItemList.SelectedValue;
            itemname = ddlItemList.SelectedItem.ToString();

            dt = new DataTable();
            dt = objTransfer.GetProductInfoForTransfer(int.Parse(transferid));
            if (dt.Rows.Count > 0)
            {
                qty = dt.Rows[0]["numQty"].ToString();
                uom = dt.Rows[0]["strUoM"].ToString();
            }

            CreateTransferXmlProcess1(transferid, itemname, qty, uom);
        }
        private void CreateTransferXmlProcess1(string transferid, string itemname, string qty, string uom)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLProcess1))
            {
                doc.Load(filePathForXMLProcess1);
                XmlNode rootNode = doc.SelectSingleNode("TransferProcess1");
                XmlNode addItem = CreateItemNode(doc, transferid, itemname, qty, uom);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("TransferProcess1");
                XmlNode addItem = CreateItemNode(doc, transferid, itemname, qty, uom);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLProcess1);
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string transferid, string itemname, string qty, string uom)
        {
            XmlNode node = doc.CreateElement("TransferProcess1");

            XmlAttribute Transferid = doc.CreateAttribute("transferid");
            Transferid.Value = transferid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;

            node.Attributes.Append(Transferid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Uom);
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
                try
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

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "M6Point5Pint('" + strGaNo + "', '" + intFromVATAc + "', '" + intYear + "');", true);
                }
                catch { }
             }

        }
        #endregion==== Transfer Action Ended ===========================================================










    }
}