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
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;

namespace UI.Wastage
{
    public partial class SO : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;

        int intEnroll;
        string filePathForXML, xmlString, xml, itemid, itemname, uom, qty, rate, value, remarks,MRRNO;
         
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/Wastage/Data/SO_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                   
                    File.Delete(filePathForXML);

                    dt = new DataTable();
                  
                    dt = obj.GetUnit();
                    ddlUnitName.DataTextField = "strUnit";
                    ddlUnitName.DataValueField = "intUnitID";
                    ddlUnitName.DataSource = dt;
                    ddlUnitName.DataBind();
                    CustList();
                    WHlist();
                    Itemlist();
                    pnlUpperControl.DataBind();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void Itemlist()
        {
            dt = obj.ItemListRpt(int.Parse(ddlUnitName.SelectedValue.ToString()));
            ddlItem.DataTextField = "strItemName";
            ddlItem.DataValueField = "intItemID";
            ddlItem.DataSource = dt;
            ddlItem.DataBind();
        }

        private void WHlist()
        {
            dt = obj.getWHbyUnitList(int.Parse(ddlUnitName.SelectedValue.ToString()));
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWareHouseID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
        }

        private void CustList()
        {
            dt = obj.CustomerList(int.Parse(ddlUnitName.SelectedValue.ToString()));
            ddlCustomer.DataTextField = "strCustomerName";
            ddlCustomer.DataValueField = "intCustomerID";
            ddlCustomer.DataSource = dt;
            ddlCustomer.DataBind();

        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = obj.getIteminfo(ddlItem.SelectedValue);
            txtRate.Text = dt.Rows[0]["monRate"].ToString(); 
            txtUOM.Text = dt.Rows[0]["strUOM"].ToString(); 
        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvSOItem.DataSource;
                dsGrid.Tables[0].Rows[dgvSOItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvSOItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(filePathForXML); dgvSOItem.DataSource = ""; dgvSOItem.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        #region ===== Item Add & Load Grid Action ===========================================================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtQty.Text != "")&&(txtRate.Text!=""))
            {
                CreateAddXml(ddlItem.SelectedValue.ToString(), ddlItem.SelectedItem.ToString(), txtUOM.Text, txtQty.Text, txtRate.Text, txtValue.Text, txtRemarks.Text);

                txtUOM.Text = "";
                txtQty.Text = "";
                txtRate.Text = "";
                txtValue.Text = "";
                txtRemarks.Text = "";
            }
        }

        protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            WHlist();
            CustList();
            Itemlist();
        }
        private void CreateAddXml(string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("SOItem");
                XmlNode addItem = CreateItemNode(doc, itemid, itemname, uom, qty, rate, value, remarks);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode xlnd = doc.SelectSingleNode("SOItem");
                xmlString = xlnd.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvSOItem.DataSource = ds; } else { dgvSOItem.DataSource = ""; }
                dgvSOItem.DataBind();
            }
            catch { dgvSOItem.DataSource = ""; dgvSOItem.DataBind(); }
        }
        private XmlNode CreateItemNode(XmlDocument doc, string itemid, string itemname, string uom, string qty, string rate, string value, string remarks)
        {
            XmlNode node = doc.CreateElement("SOItem");

            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;
            XmlAttribute Itemname = doc.CreateAttribute("itemname"); Itemname.Value = itemname;
            XmlAttribute Uom = doc.CreateAttribute("uom"); Uom.Value = uom;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Rate = doc.CreateAttribute("rate"); Rate.Value = rate;
            XmlAttribute Value = doc.CreateAttribute("value"); Value.Value = value;
            XmlAttribute Remarks = doc.CreateAttribute("remarks"); Remarks.Value = remarks;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Rate);
            node.Attributes.Append(Value);
            node.Attributes.Append(Remarks);
            return node;
        }
        protected void dgvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                xmlString = dSftTm.InnerXml;
                xmlString = "<SOItem>" + xmlString + "</SOItem>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvSOItem.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvSOItem.DataSource;
                dsGrid.Tables[0].Rows[dgvSOItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvSOItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvSOItem.DataSource = ""; dgvSOItem.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }

        protected decimal totalqty = 0;
        protected decimal totalvalue = 0;
        protected void dgvSOItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                }
            }
            catch { }
        }

        #endregion ==========================================================================================

        #region ===== Submit Action =========================================================================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
                if (dgvSOItem.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("SOItem");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<SOItem>" + xmlString + "</SOItem>";
                        xml = xmlString;
                    }
                    catch { }
                    if (xml == "") { return; }
                }
               if (txtMRNo.Text == "") { MRRNO = "0"; } else { MRRNO = txtMRNo.Text; };
                if ((txtSODate.Text != "")||(int.Parse(ddlUnitName.SelectedValue)!=0) || (int.Parse(ddlWHName.SelectedValue) != 0))
                {
                    string message = obj.insertSales(DateTime.Parse(txtSODate.Text),int.Parse(ddlCustomer.SelectedValue), int.Parse(ddlUnitName.SelectedValue),intEnroll,MRRNO,int.Parse(ddlWHName.SelectedValue),  xml);
                    if (filePathForXML != null) { File.Delete(filePathForXML); }
                    dgvSOItem.DataSource = ""; dgvSOItem.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
           
        }

        #endregion ==========================================================================================




























    }
}