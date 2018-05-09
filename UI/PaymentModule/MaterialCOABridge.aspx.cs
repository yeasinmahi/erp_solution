using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class MaterialCOABridge : BasePage
    {
        Payment_All_Voucher_BLL objVoucher = new Payment_All_Voucher_BLL(); Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;
    
        string filePathForXML; string xmlString = ""; string xml, itemid, coaid, strSupplier;
        int intUnitID, intCategoryID, intPart, intSupplierID, intCOAID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnEmail.Value = Session[SessionParams.EMAIL].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/ItemBridge_" + hdnEnroll.Value + ".xml");

                if (!IsPostBack)
                {
                    File.Delete(filePathForXML); dgvItemList.DataSource = ""; dgvItemList.DataBind();

                    dt = new DataTable();
                    dt = objBillReg.GetUnitListByUserID(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ddlUnit.DataTextField = "strUnit";
                        ddlUnit.DataValueField = "intUnitID";
                        ddlUnit.DataSource = dt;
                        ddlUnit.DataBind();
                    }

                    dt = new DataTable();
                    dt = objVoucher.GetCategory();
                    if (dt.Rows.Count > 0)
                    {
                        ddlCategory.DataTextField = "strReqItemCategory";
                        ddlCategory.DataValueField = "intAutoID";
                        ddlCategory.DataSource = dt;
                        ddlCategory.DataBind();
                    }
                }
            }
            catch { }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }       
        private void LoadGrid()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                try { intCategoryID = int.Parse(ddlCategory.SelectedValue.ToString());}
                catch { intCategoryID = 0; }

                if(intCategoryID == 0)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetItemForCOABridge(intUnitID);
                }
                else
                {
                    dt = new DataTable();
                    dt = objVoucher.GetItemForCOABridgeByUnitAndCategory(intUnitID, intCategoryID);
                }                
                dgvItemList.DataSource = dt;
                dgvItemList.DataBind();
            }
            catch { }
        }     
        protected void dgvItemList_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in dgvItemList.Rows)
            {
                DropDownList ddlAccountName = gvRow.FindControl("ddlAccountName") as DropDownList;
                HiddenField hdnCOAID = gvRow.FindControl("hdnCOAID") as HiddenField;

                if (ddlAccountName != null && hdnCOAID != null)
                {
                    ddlAccountName.SelectedValue = hdnCOAID.Value;
                }
            }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvItemList.DataSource = "";
            dgvItemList.DataBind();
        }
        protected void btnCOABankItem_Click(object sender, EventArgs e)
        {
            LoadGridBankItem();
        }
        protected void btnCOABankItem_Click1(object sender, EventArgs e)
        {
            LoadGridBankItem();
        }
        private void LoadGridBankItem()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                try { intCategoryID = int.Parse(ddlCategory.SelectedValue.ToString()); }
                catch { intCategoryID = 0; }

                if (intCategoryID == 0)
                {
                    dt = new DataTable();
                    dt = objVoucher.GetCOABankItem(intUnitID);
                }
                else
                {
                    dt = new DataTable();
                    dt = objVoucher.GetCOABankItemByUnitAndCategoryID(intUnitID, intCategoryID);
                }
                dgvItemList.DataSource = dt;
                dgvItemList.DataBind();
            }
            catch { }
        }
        protected void btnUpdateBridge_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (dgvItemList.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvItemList.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvItemList.Rows[index].FindControl("chkRow")).Checked == true)
                        {
                            itemid = ((Label)dgvItemList.Rows[index].FindControl("lblItemID")).Text.ToString();
                            coaid = ((DropDownList)dgvItemList.Rows[index].FindControl("ddlAccountName")).SelectedValue.ToString();

                            if (coaid != "0")
                            {
                                CreateVoucherXml(itemid, coaid);
                            }
                        }
                    }
                }

                if (dgvItemList.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("ItemBridge");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<ItemBridge>" + xmlString + "</ItemBridge>";
                        xml = xmlString;
                    }
                    catch { }
                    if (xml == "") { return; }
                }

                string message = objVoucher.InsertAndUpdateSupplierCOA(intPart, intSupplierID, intUnitID, strSupplier, int.Parse(hdnEnroll.Value), intCOAID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
        }
        private void CreateVoucherXml(string itemid, string coaid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemBridge");
                XmlNode addItem = CreateItemNode(doc, itemid, coaid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemBridge");
                XmlNode addItem = CreateItemNode(doc, itemid, coaid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string coaid)
        {
            XmlNode node = doc.CreateElement("ItemBridge");
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Coaid = doc.CreateAttribute("coaid"); Coaid.Value = coaid;
           
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Coaid);
            return node;
        }
        











    }
}