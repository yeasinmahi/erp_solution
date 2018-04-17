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

namespace UI.AEFPS
{
    public partial class SalesReturnN : BasePage
    {
        #region ===== Variable Decliaration =======================================================
        FPSSalesReturnAndTransferBLL obj = new FPSSalesReturnAndTransferBLL();
        DataTable dt;

        int intPart, intWHID, intEnroll, intItemID, intToWHID, intInsertBy;
        decimal numQuantity, numStockQty;
        string itemid, itemcode, itemname, uom, qty, filePathForXML, xmlString = "", strVoucher, xml;        
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.', ',' };
        string[] arrayKey;

        #endregion ================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/AEFPS/Data/SalesReturn_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXML); dgvProduct.DataSource = ""; dgvProduct.DataBind();
                pnlUpperControl.DataBind();

                intPart = 1;
                intWHID = 0;
                intEnroll = int.Parse(hdnEnroll.Value);
                dt = obj.GetDataForEntry(intPart, intWHID, intEnroll);
                ddlFromWH.DataTextField = "strWH";
                ddlFromWH.DataValueField = "intInventoryWHID";
                ddlFromWH.DataSource = dt;
                ddlFromWH.DataBind();                

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
       
        private void CreateVoucherXml(string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Product");
                XmlNode addItem = CreateItemNode(doc, itemid, itemcode, itemname, uom, qty);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Product");
                XmlNode addItem = CreateItemNode(doc, itemid, itemcode, itemname, uom, qty); ;
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
            XmlNode dSftTm = doc.SelectSingleNode("Product");
            xmlString = dSftTm.InnerXml;
            xmlString = "<Product>" + xmlString + "</Product>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvProduct.DataSource = ds; }
            else { dgvProduct.DataSource = ""; }
            dgvProduct.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemcode, string itemname, string uom, string qty)
        {
            XmlNode node = doc.CreateElement("Product");

            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Itemcode = doc.CreateAttribute("itemcode");
            Itemcode.Value = itemcode;
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemcode);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            return node;
        }

        protected void dgvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Y")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = dgvProduct.Rows[rowIndex];
                
                    
                //intItemID = int.Parse((row.FindControl("lblItemID") as Label).Text);
                //strSpecification = (row.FindControl("txtSpecification") as TextBox).Text;
                                      
                //Final Insert
                //string message = obj.UpdateItemInfoByPONew(intPOID, numPOQty, intItemID, strSpecification, monRate, monVAT, monAmount, updateby);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);                   
            }
        }
        #region===== Grid View Load For Report =========================================================
        private void LoadGrid()
        {
            try
            {
                intPart = 2;
                intWHID = int.Parse(ddlFromWH.SelectedValue.ToString());
                intToWHID = 0;
                strVoucher = txtSVCode.Text;
                dt = new DataTable();
                dt = obj.GetTransferOutInReport(intPart, intWHID, intToWHID, strVoucher);
                if (dt.Rows.Count > 0)
                {
                    dgvProduct.DataSource = dt;
                    dgvProduct.DataBind();
                }
                else
                {
                    dgvProduct.DataSource = "";
                    dgvProduct.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid();", true);
                }
            }
            catch { }
        }

        protected decimal totalval = 0;
        protected void dgvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalval += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblTotalVal")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion======================================================================================

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }


















    }
}