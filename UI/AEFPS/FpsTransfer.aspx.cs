using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using UI.ClassFiles;
using System.IO;
using System.Data;
using System.Xml;
using SAD_BLL.AEFPS;
using Flogging.Core;
using GLOBAL_BLL;

namespace UI.AEFPS
{
    public partial class FpsTransfer : BasePage
    {
        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        Receive_BLL objwh = new Receive_BLL();
        DataTable dt;

        int intID; int intWork;
        string filePathForXML, xmlString = "", xml;
        string reffid, qrcode, itemid, itemname, uom, qty, price, amount;
        int intPart, intWHID, intCount;
        string strSV, strQRCode, message, strVoucher, strQRCodeOld;
        int intToWHID, intEnroll, intInsertBy;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\FpsTransfer";
        string stop = "stopping AEFPS\\FpsTransfer";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/AEFPS/Data/Transfer_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML); dgvProductDTR.DataSource = ""; dgvProductDTR.DataBind();
                pnlUpperControl.DataBind();

                dt = objwh.DataView(1, "", 0, 0, DateTime.Now, int.Parse(hdnEnroll.Value));
                ddlFromWH.DataTextField = "strName";
                ddlFromWH.DataValueField = "Id";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();

                dt = objwh.DataView(1, "", 0, 0, DateTime.Now, int.Parse(hdnEnroll.Value));
                ddlToWHName.DataTextField = "strName";
                ddlToWHName.DataValueField = "Id";
                ddlToWHName.DataSource = dt;
                ddlToWHName.DataBind();

                LoadGrid();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
        }
        protected void ddlFromWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\FpsTransfer AEFPS Product Transfer", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                intPart = 2;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                strQRCode = "0";
                dt = new DataTable();
                dt = obj.GetReport(intPart, intWHID, strQRCode);
                dgvProductDT.DataSource = dt;
                dgvProductDT.DataBind();
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
        protected decimal totalamount = 0;
        protected void dgvProductDT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmount")).Text);
                }
            }
            catch { }
        }
        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            LoadGridForReturn();
        }
        private void LoadGridForReturn()
        {
            try
            {
                intPart = 1;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                
                char[] ch = { ',' };
                string[] temp = txtQRCode.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                strQRCode = temp[0].ToString();
                qty = temp[1].ToString();

                intCount = 0;

                if (dgvProductDTR.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvProductDTR.Rows.Count; index++)
                    {
                        strQRCodeOld = ((Label)dgvProductDTR.Rows[index].FindControl("lblQRCodeR")).Text.ToString();
                        if (strQRCode == strQRCodeOld)
                        {
                            intCount = 1;
                        }

                    }
                }

                if (intCount == 0)
                {
                    dt = new DataTable();
                    dt = obj.GetReport(intPart, intWHID, strQRCode);
                    
                    if (dt.Rows.Count > 0)
                    {
                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            qrcode = dt.Rows[index]["strQRCode"].ToString();
                            itemid = dt.Rows[index]["intItemID"].ToString();
                            itemname = dt.Rows[index]["strItemName"].ToString();
                            uom = dt.Rows[index]["strUOM"].ToString();
                            //qty = dt.Rows[index]["numQty"].ToString();
                            price = dt.Rows[index]["monPrice"].ToString();
                            amount = (decimal.Parse(qty) * decimal.Parse(price)).ToString();
                            totalamount1 = 0;

                            if (itemid != "" && itemname != "")
                            {
                                CreateVoucherXml(qrcode, itemid, itemname, uom, qty, price, amount);
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void CreateVoucherXml(string qrcode, string itemid, string itemname, string uom, string qty, string price, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SalesPR");
                XmlNode addItem = CreateItemNode(doc, qrcode, itemid, itemname, uom, qty, price, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalesPR");
                XmlNode addItem = CreateItemNode(doc, qrcode, itemid, itemname, uom, qty, price, amount); ;
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
            XmlNode dSftTm = doc.SelectSingleNode("SalesPR");
            xmlString = dSftTm.InnerXml;
            xmlString = "<SalesPR>" + xmlString + "</SalesPR>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvProductDTR.DataSource = ds; }
            else { dgvProductDTR.DataSource = ""; }
            dgvProductDTR.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string qrcode, string itemid, string itemname, string uom, string qty, string price, string amount)
        {
            XmlNode node = doc.CreateElement("SalesPR");

            XmlAttribute Qrcode = doc.CreateAttribute("qrcode");
            Qrcode.Value = qrcode;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Price = doc.CreateAttribute("price");
            Price.Value = price;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Qrcode);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Price);
            node.Attributes.Append(Amount);
            return node;
        }
        protected void dgvProductDTR_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SalesPR");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SalesPR>" + xmlString + "</SalesPR>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvProductDTR.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvProductDTR.DataSource;
                dsGrid.Tables[0].Rows[dgvProductDTR.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvProductDTR.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvProductDTR.DataSource = ""; dgvProductDTR.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal totalamount1 = 0;
        protected void dgvProductDTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamount1 += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAmountR")).Text);
                }
            }
            catch { }
        }
        
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                var fd = log.GetFlogDetail(start, location, "Submit", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on AEFPS\\FpsTransfer AEFPS Product Transfer", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {

                intPart = 1;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                intEnroll = int.Parse(hdnEnroll.Value);
                strVoucher = txtQRCode.Text;
                intInsertBy = int.Parse(hdnEnroll.Value);

                if (dgvProductDTR.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("SalesPR");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<SalesPR>" + xmlString + "</SalesPR>";
                        xml = xmlString;

                    }
                    catch { }
                    if (xml == "") { return; }
                }

                //Final In Insert                        
                message = obj.InsertUpdate(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                hdnconfirm.Value = "0";
                File.Delete(filePathForXML); dgvProductDTR.DataSource = ""; dgvProductDTR.DataBind();
                dgvProductDT.DataSource = "";
                dgvProductDT.DataBind();
                txtQRCode.Text = "";
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
        }























    }
}