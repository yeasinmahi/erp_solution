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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.AEFPS
{
    public partial class TransferOut : System.Web.UI.Page
    {

        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        Receive_BLL objwh = new Receive_BLL();
        DataTable dt;

        int intID; int intWork;
        string filePathForXML, xmlString = "", xml;
        string masterid, mrrid, code, itemname, uom, sqty, price, tqty, amount;
        int intPart, intWHID, intCount;
        string strSV, strQRCode, message, strVoucher, strQRCodeOld, strItemID, strItemIDOld, strBarcode;        
        int intToWHID, intEnroll, intInsertBy;
        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;
        SeriLog log = new SeriLog();
        string location = "AEFPS";
        string start = "starting AEFPS\\TransferOut";
        string stop = "stopping AEFPS\\TransferOut";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/AEFPS/Data/Transfer_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                File.Delete(filePathForXML); dgvTransferItem.DataSource = ""; dgvTransferItem.DataBind();
                pnlUpperControl.DataBind();

                intPart = 1;
                intWHID = 0;
                intEnroll = int.Parse(hdnEnroll.Value);
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlFromWH.DataTextField = "strWH";
                ddlFromWH.DataValueField = "intInventoryWHID";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();

                intPart = 2;
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlToWHName.DataTextField = "strWH";
                ddlToWHName.DataValueField = "intInventoryWHID";
                ddlToWHName.DataSource = dt;
                ddlToWHName.DataBind();                
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetFPSItemSerach(string prefixText, int count)
        {
            Receive_BLL objItem = new Receive_BLL();
            return objItem.GetFairPriceItem(1, prefixText);
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            LoadGridItem();
        }
        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGridItem()
        {
            try
            {
                char[] ch = { '[', ']' };
                string[] temp = txtItem.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                strItemID = temp[1].ToString();
            }
            catch { }
            try
            {
                //strBarcode = txtQRCode.Text;
                //dt = new DataTable();
                //dt = obj.GetMasterIDByBarcode(strBarcode);
                //if (dt.Rows.Count > 0)
                //{
                //    strItemID = dt.Rows[0]["intMasterId"].ToString();
                //}
                //else { strItemID = ""; }
                if (strItemID != "")
                {
                    dgvItem.DataSource = "";
                    dgvItem.DataBind();

                    intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                    intEnroll = int.Parse(strItemID);
                    dt = new DataTable();
                    dt = obj.GetDataForTransfer(intEnroll, intWHID);
                    if (dt.Rows.Count > 0)
                    {
                        dgvItem.DataSource = dt;
                        dgvItem.DataBind();
                    }
                }
            }
            catch { }
        }

        private void LoadGrid()
        {
            //char[] ch = { '[', ']' };
            //string[] temp = txtItem.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            //strItemID = temp[1].ToString();
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\TransferOut Transfer Out Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                strBarcode = txtQRCode.Text;
                dt = new DataTable();
                dt = obj.GetMasterIDByBarcode(strBarcode);
                if (dt.Rows.Count > 0)
                {
                    strItemID = dt.Rows[0]["intMasterId"].ToString();
                }
                else { strItemID = ""; }
                if (strItemID != "")
                {
                    dgvItem.DataSource = "";
                    dgvItem.DataBind();
                    
                    intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                    intEnroll = int.Parse(strItemID);
                    dt = new DataTable();
                    dt = obj.GetDataForTransfer(intEnroll, intWHID);
                    if (dt.Rows.Count > 0)
                    {
                        dgvItem.DataSource = dt;
                        dgvItem.DataBind();
                    }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvItem.Rows.Count > 0)
            {
                for (int index = 0; index < dgvItem.Rows.Count; index++)
                {
                    masterid = ((Label)dgvItem.Rows[index].FindControl("lblItemMasterID")).Text.ToString();
                    mrrid = ((Label)dgvItem.Rows[index].FindControl("lblMRRID")).Text.ToString();
                    code = ((Label)dgvItem.Rows[index].FindControl("lblCode")).Text.ToString();
                    itemname = ((Label)dgvItem.Rows[index].FindControl("lblItemName")).Text.ToString();
                    uom = ((Label)dgvItem.Rows[index].FindControl("lblUOM")).Text.ToString();
                    sqty = ((Label)dgvItem.Rows[index].FindControl("lblStockQty")).Text.ToString();
                    price = ((Label)dgvItem.Rows[index].FindControl("lblRate")).Text.ToString();
                    tqty = ((TextBox)dgvItem.Rows[index].FindControl("txtQty")).Text.ToString();
                    amount = (decimal.Parse(price) * decimal.Parse(tqty)).ToString();
                    
                    totalqty = 0;
                    totalval = 0;
                    totalstockqty = 0;

                    if (masterid != "" && itemname != "" && amount != "" && tqty != "" && tqty != "0")
                    {
                        CreateVoucherXml(masterid, mrrid, code, itemname, uom, sqty, price, tqty, amount);
                    }
                }
                dgvItem.DataSource = "";
                dgvItem.DataBind();               
            }
        }
        private void CreateVoucherXml(string masterid, string mrrid, string code, string itemname, string uom, string sqty, string price, string tqty, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SalesPR");
                XmlNode addItem = CreateItemNode(doc, masterid, mrrid, code, itemname, uom, sqty, price, tqty, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SalesPR");
                XmlNode addItem = CreateItemNode(doc, masterid, mrrid, code, itemname, uom, sqty, price, tqty, amount); ;
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
            if (ds.Tables[0].Rows.Count > 0) { dgvTransferItem.DataSource = ds; }
            else { dgvTransferItem.DataSource = ""; }
            dgvTransferItem.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string masterid, string mrrid, string code, string itemname, string uom, string sqty, string price, string tqty, string amount)
        {
            XmlNode node = doc.CreateElement("SalesPR");

            XmlAttribute Masterid = doc.CreateAttribute("masterid");
            Masterid.Value = masterid;
            XmlAttribute Mrrid = doc.CreateAttribute("mrrid");
            Mrrid.Value = mrrid;
            XmlAttribute Code = doc.CreateAttribute("code");
            Code.Value = code;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Sqty = doc.CreateAttribute("sqty");
            Sqty.Value = sqty;
            XmlAttribute Price = doc.CreateAttribute("price");
            Price.Value = price;
            XmlAttribute Tqty = doc.CreateAttribute("tqty");
            Tqty.Value = tqty;            
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;

            node.Attributes.Append(Masterid);
            node.Attributes.Append(Mrrid);
            node.Attributes.Append(Code);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Sqty);
            node.Attributes.Append(Price);
            node.Attributes.Append(Tqty);
            node.Attributes.Append(Amount);
            return node;
        }

        protected decimal totalqty = 0;
        protected decimal totalval = 0;
        protected decimal totalstockqty = 0;
        protected void dgvItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalstockqty += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblStockQty")).Text);
                totalqty += decimal.Parse(((TextBox)e.Row.Cells[8].FindControl("txtQty")).Text);               
                totalval += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblTotalVal")).Text);
            }
        }

        protected decimal totalqty1 = 0;
        protected decimal totalval1 = 0;
        protected decimal totalstockqty1 = 0;
        protected void dgvTransferItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalstockqty1 += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblStockQty1")).Text);
                totalqty1 += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblTQty1")).Text);
                totalval1 += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblTotalVal1")).Text);
            }
        }
        protected void dgvTransferItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                dgvTransferItem.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvTransferItem.DataSource;
                dsGrid.Tables[0].Rows[dgvTransferItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvTransferItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvTransferItem.DataSource = ""; dgvTransferItem.DataBind();                    
                }
                else { LoadGridwithXml(); }
            }
            catch { }            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on AEFPS\\TransferOut Transfer Out Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                if (hdnconfirm.Value == "1")
            {
                intPart = 1;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = int.Parse(ddlToWHName.SelectedValue.ToString());
                intEnroll = int.Parse(hdnEnroll.Value);
                strVoucher = txtQRCode.Text;
                intInsertBy = int.Parse(hdnEnroll.Value);

                if (dgvTransferItem.Rows.Count > 0)
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
                message = obj.InsertUpdateST(intPart, intWHID, intToWHID, intEnroll, strVoucher, intInsertBy, xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                hdnconfirm.Value = "0";
                File.Delete(filePathForXML); dgvTransferItem.DataSource = ""; dgvTransferItem.DataBind();                
                txtQRCode.Text = "";

            }
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