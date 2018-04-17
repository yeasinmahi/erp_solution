using HR_BLL.Global;
using Purchase_BLL.SupplyChain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class ItemManager : BasePage
    {

        #region =========== Global Variable Declareation ==========
        int locationid, unitid, itemid, unit; char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        DataTable dt = new DataTable();
        CSM bll = new CSM();
        bool ysnChecked;
        string xmlpath,  itemnames,  itemids, uom, subcategorys,  procuretypes,unitnames,  vats,  warehousenames;
        decimal totalcom, comrate, selectedtotalcom = 0;

        #endregion

      

        protected void drdlcluster_SelectedIndexChanged(object sender, EventArgs e)
        {
             locationid = Convert.ToInt32(drdlcluster.SelectedValue.ToString());
            Session["locationid"] = locationid;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/REQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "itemmanager.xml");
            //locationid = Convert.ToInt32(drdlcluster.SelectedValue.ToString());
            //Session["locationid"] = locationid;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] Getitemmanageritemlist(string prefixText, int count)
        {
            int locid = Convert.ToInt32(HttpContext.Current.Session["locationid"].ToString());
           
            //int locid = 2;
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            return objAutoSearch_BLL.GetItemBasedoncluster(locid.ToString(), prefixText);

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //itemname,  itemid,  uom,  subcategory,  procuretype,  vat,  unit,  warehouse
                if (hdnconfirm.Value == "1")
                {
                    if (!String.IsNullOrEmpty(txtItem.Text))
                    {
                        string strSearchKey = txtItem.Text;
                        arrayKey = strSearchKey.Split(delimiterChars);
                        string itemcode = arrayKey[1].ToString();
                        string strCustname = strSearchKey;
                        itemid = int.Parse(itemcode.ToString());
                        itemnames = arrayKey[0].ToString();

                    }
                    uom = txtUOM.Text;
                    subcategorys = drdlSubCategory.SelectedItem.Text.ToString();
                    procuretypes = drdlProcureType.SelectedItem.Text.ToString();
                    vats = drdlVatApplicable.SelectedItem.Text.ToString();
                    unitnames = drdlUnitName.SelectedItem.Text.ToString();
                    warehousenames = drdlwhlist.SelectedItem.Text.ToString();

                  

                    //if (stocks > 0)

                }
            }
            catch { }
        }
           
        private void LoadFieldValue(int itemid)
        {
            try
            {

                //EmployeeRegistration objenrol = new EmployeeRegistration();
                //DataTable objDT = new DataTable();
                dt = bll.GetItemDetaills(itemid);
                if (dt.Rows.Count >= 0)
                {

                    txtmasterid.Text = dt.Rows[0]["intItemMasterID"].ToString();
                    txtUOM.Text = dt.Rows[0]["strUoM"].ToString();
                    
                }

            }
            catch (Exception ex) { throw ex; }
        }

        protected void grdvItemManagerDetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvItemManagerDetaills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("Itemmanager");
                var xmlString = xlnd.InnerXml;
                xmlString = "<Itemmanager>" + xmlString + "</Itemmanager>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { grdvItemManagerDetaills.DataSource = ds; } else { grdvItemManagerDetaills.DataSource = ""; }
                grdvItemManagerDetaills.DataBind();
            }
            catch { grdvItemManagerDetaills.DataSource = ""; grdvItemManagerDetaills.DataBind(); }
        }
        private void CreateXml(string itemname, string itemid, string uom, string subcategory, string procuretype, string vat, string unit, string warehouse)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Itemmanager");
                XmlNode addItem = CreateNode(doc, itemname,  itemid,  uom,  subcategory,  procuretype,  vat,  unit,  warehouse);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Itemmanager");
                XmlNode addItem = CreateNode(doc, itemname, itemid, uom, subcategory, procuretype, vat, unit, warehouse);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }

        private XmlNode CreateNode(XmlDocument doc, string itemname, string itemid, string uom, string subcategory, string procuretype,
            string vat, string unit, string warehouse)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value = uom;
            XmlAttribute Subcategory = doc.CreateAttribute("subcategory");
            Subcategory.Value = subcategory;
            XmlAttribute Procuretype = doc.CreateAttribute("procuretype");
            Procuretype.Value = procuretype;
            XmlAttribute Vat = doc.CreateAttribute("vat");
            Vat.Value = vat;
            XmlAttribute Unit = doc.CreateAttribute("unit");
            Unit.Value = unit;
            XmlAttribute Warehouse = doc.CreateAttribute("warehouse");
            Warehouse.Value = warehouse;
           

            node.Attributes.Append(Itemname);
            node.Attributes.Append(Itemid);
            node.Attributes.Append(Uom);
            node.Attributes.Append(Unit);
            node.Attributes.Append(Subcategory);
            node.Attributes.Append(Procuretype);
            node.Attributes.Append(Vat);
            node.Attributes.Append(Unit);
            node.Attributes.Append(Warehouse);
            
            return node;
        }


        private void Clearcontrols()
        {
            txtItem.Text = "0.00"; txtmasterid.Text = ""; txtUOM.Text = "";

        }
        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //unitid = int.Parse(drdlUnitName.SelectedValue.ToString());
            //dt = bll.GetItemSubcategorylist(unitid);
            //drdlSubCategory.DataSource = dt;
            //drdlSubCategory.DataTextField = dt.Rows[0].["strSubCatName"];
            //drdlSubCategory.DataValueField = dt.Rows[0].["intAutoID"];
            //drdlSubCategory.DataBind();
        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtItem.Text))
            {
                string strSearchKey = txtItem.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string itemcode = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                itemid = int.Parse(itemcode.ToString());
                LoadFieldValue(itemid);

            }
        }
    }
}