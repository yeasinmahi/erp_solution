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
    public partial class PriceDeclarationM1 : BasePage
    {
        #region===== Variable & Object Declaration =====================================================
        VAT_BLL objvat = new VAT_BLL();
        DataTable dt;

        int intVatItemID, intMushokType;
        string filePathForXML, xmlString = "", xml, strMessage;
        string itemid, itemname, uom, qty, wastage, rate, amount;
        DateTime dteDate;

        #endregion =====================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                filePathForXML = Server.MapPath("~/VAT_Management/Data/PriceDeclaration_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvPriceDeclaration.DataSource = ""; dgvPriceDeclaration.DataBind();
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

                    dt = new DataTable();
                    dt = objvat.GetVMaterialList(int.Parse(hdnUnit.Value), int.Parse(hdnVatAccID.Value));
                    ddlMaterial.DataTextField = "strMaterialName";
                    ddlMaterial.DataValueField = "intMaterialID";
                    ddlMaterial.DataSource = dt;
                    ddlMaterial.DataBind();
                }
            }
            catch { }
        }
        protected void ddlVatAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVatAccount.Text = ddlVatAccount.SelectedItem.ToString();
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.Delete(filePathForXML); dgvPriceDeclaration.DataSource = ""; dgvPriceDeclaration.DataBind();
        }

        #region ===== Material Add Option =====================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                itemid = ddlMaterial.SelectedValue.ToString();
                itemname = ddlMaterial.SelectedItem.ToString();

                if (txtTotalQty.Text == "" || txtTotalQty.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Incorrect Qauntity');", true);
                    return;
                }
                try { decimal qtycheck = decimal.Parse(txtTotalQty.Text); }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Incorrect Qauntity');", true);
                    return;
                }

                try { decimal ratcheck = decimal.Parse(txtRate.Text); }
                catch
                {
                    rate = "0";
                }

                qty = txtTotalQty.Text;
                wastage = txtWastage.Text;
                rate = txtRate.Text;
                amount = Math.Round((decimal.Parse(qty) * decimal.Parse(rate)), 4).ToString();

                #region ********* Duplicate Material Check ****************************************                
                if (dgvPriceDeclaration.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvPriceDeclaration.Rows.Count; index++)
                    {
                        string olditemid = ((Label)dgvPriceDeclaration.Rows[index].FindControl("lblMaterialID")).Text.ToString();                        

                        if (olditemid == itemid)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You already added this material');", true);
                            return;
                        }
                    }
                }

                #endregion ************************************************************************

                dt = new DataTable();
                dt = objvat.GetUOMByItemID(int.Parse(itemid.ToString()));
                if (dt.Rows.Count > 0)
                {
                    uom = dt.Rows[0]["strUOM"].ToString();
                }

                CreateVoucherXml(itemid, itemname, uom, qty, wastage, rate, amount);
                txtTotalQty.Text = "";
                txtWastage.Text = "";
                txtRate.Text = "";
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(filePathForXML); dgvPriceDeclaration.DataSource = ""; dgvPriceDeclaration.DataBind();

                intVatItemID = int.Parse(ddlProductName.SelectedValue.ToString());
                intMushokType = int.Parse(ddlType.SelectedValue.ToString());
                dteDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                dt = new DataTable();
                dt = objvat.GetPreviousM1InfoByItem(intVatItemID, intMushokType, dteDate);
                if (dt.Rows.Count > 0)
                {
                    for (int index = 0; index < dt.Rows.Count; index++)
                    {
                        itemid = dt.Rows[index]["intVATMaterialID"].ToString();
                        itemname = dt.Rows[index]["strMaterialName"].ToString();
                        uom = dt.Rows[index]["strUOM"].ToString();
                        qty = dt.Rows[index]["numQty"].ToString();
                        wastage = dt.Rows[index]["numWastage"].ToString();
                        rate = dt.Rows[index]["Rate"].ToString();
                        amount = dt.Rows[index]["monValue"].ToString();

                        //Start Create XML
                        CreateVoucherXml(itemid, itemname, uom, qty, wastage, rate, amount);
                    }

                    dt = new DataTable();
                    dt = objvat.GetDItemVatPrice(intVatItemID);
                    if (dt.Rows.Count > 0)
                    {
                        txtSDChargeable.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSDChargablePrice"].ToString()), 2).ToString();
                        txtSD.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSDPercent"].ToString()), 2).ToString();
                        txtVAT.Text = Math.Round(decimal.Parse(dt.Rows[0]["monVATPercent"].ToString()), 2).ToString();
                        txtSurChargePercentage.Text = dt.Rows[0]["monSurChargePercent"].ToString();
                        txtWholeSale.Text = Math.Round(decimal.Parse(dt.Rows[0]["monWholeSalePrice"].ToString()), 2).ToString();
                        txtMRP.Text = Math.Round(decimal.Parse(dt.Rows[0]["monRetailPrice"].ToString()), 2).ToString();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No price declaration found for this item.');", true);
                    File.Delete(filePathForXML); dgvPriceDeclaration.DataSource = ""; dgvPriceDeclaration.DataBind();
                    return;
                }
            }
            catch { }            
        }
        private void CreateVoucherXml(string itemid, string itemname, string uom, string qty, string wastage, string rate, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, wastage, rate, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, wastage, rate, amount);
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
            if (ds.Tables[0].Rows.Count > 0) { dgvPriceDeclaration.DataSource = ds; }
            else { dgvPriceDeclaration.DataSource = ""; }
            dgvPriceDeclaration.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemname, string uom, string qty, string wastage, string rate, string amount)
        {
            XmlNode node = doc.CreateElement("ItemAdd");
           
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Wastage = doc.CreateAttribute("wastage"); Wastage.Value = wastage;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Amount = doc.CreateAttribute("amount"); Amount.Value = amount;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Wastage);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Amount);
            return node;
        }
        protected void dgvPriceDeclaration_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                dgvPriceDeclaration.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvPriceDeclaration.DataSource;
                dsGrid.Tables[0].Rows[dgvPriceDeclaration.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvPriceDeclaration.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvPriceDeclaration.DataSource = ""; dgvPriceDeclaration.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        #endregion ============================================================================


        #region ===============================================================================
        protected void btnSaveM1_Click(object sender, EventArgs e)
        {

        }
        #endregion ============================================================================












    }
}