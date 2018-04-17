using Purchase_BLL.Asset;
using SCM_BLL;
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

namespace UI.SCM
{
    public partial class WHLocationStockTransfer : BasePage
    {
        Location_BLL objOperation = new Location_BLL(); 
        DataTable dt = new DataTable(); int check;
         int enroll, intWH; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Trn__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); dgvWHLocation.DataSource = ""; dgvWHLocation.DataBind(); }
                catch { }
                pnlUpperControl.DataBind();
                DefaltLoad();
            }
           
        }



        #region==================Defalt Load=============================
        private void DefaltLoad()
        {
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objOperation.WhDataView(1, "", intWH, 0, enroll);
                ddlWH.DataSource = dt;
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataBind();

                intWH = int.Parse(ddlWH.SelectedValue); 
                Session["WareID"] = ddlWH.SelectedValue.ToString();
                ddlLocation.Visible = false;

                dt = objOperation.WhLocationView(int.Parse(ddlWH.SelectedValue));
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataValueField = "intStoreLocationID";
                ddlLocation.DataBind();
                ddlLocation2.DataSource = dt;
                ddlLocation2.DataTextField = "strLocationName";
                ddlLocation2.DataValueField = "intStoreLocationID";
                ddlLocation2.DataBind();
            }
            catch { }
            
        }
        #endregion================Close==================================

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSearch(string prefixText, int count)
        {      
             return AutoSearch_BLL.AutoSearchLocationItem(HttpContext.Current.Session["WareID"].ToString(), prefixText);            
        }

       
        #endregion====================Close===============================

        #region===================Action==========================================

        protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intWH = int.Parse(ddlWH.SelectedValue);
                Session["WareID"] = ddlWH.SelectedValue.ToString();
                dt = objOperation.WhLocationView(intWH);
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "strLocationName";
                ddlLocation.DataValueField = "intStoreLocationID";
                ddlLocation.DataBind();

                ddlLocation2.DataSource = dt;
                ddlLocation2.DataTextField = "strLocationName";
                ddlLocation2.DataValueField = "intStoreLocationID";
                ddlLocation2.DataBind(); 
              
                dgvWHLocation.DataSource = "";
                dgvWHLocation.DataBind();
               
            }
            catch { }

        }

        protected void radLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {   
                txtItem.Visible = false;
                ddlLocation.Visible = true;
                dgvWHLocation.DataSource = "";
                dgvWHLocation.DataBind();

            }
            catch { }
           

        }

        protected void radItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtItem.Visible = true;
                ddlLocation.Visible = false;
                dgvWHLocation.DataSource = "";
                dgvWHLocation.DataBind();
                
            }
            catch { }
           
           
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            try
            {
                
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                intWH = int.Parse(ddlWH.SelectedValue);
                if (radItem.Checked==true)
                {
                    arrayKey = txtItem.Text.Split(delimiterChars); 
                    string item = ""; string itemid = "";  
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemid = arrayKey[1].ToString(); }

                    dt = objOperation.WhDataView(8, "", intWH, int.Parse(itemid), 1);
                }
                else  if (radLocation.Checked==true)
                {
                    int LocationId = int.Parse(ddlLocation.SelectedValue);
                    dt = objOperation.WhDataView(8, "", intWH, LocationId, 2);
                }
               
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();

                 
            }
            catch { }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML); } catch { }
                int newLocation = int.Parse(ddlLocation2.SelectedValue.ToString());
                intWH = int.Parse(ddlWH.SelectedValue);
            if (dgvWHLocation.Rows.Count > 0 && int.Parse(hdnConfirm.Value) == 1)
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());


                    for (int index = 0; index < dgvWHLocation.Rows.Count; index++)
                    {
                        if (((CheckBox)dgvWHLocation.Rows[index].FindControl("chkRow")).Checked == true)
                        {

                            string itemid = ((Label)dgvWHLocation.Rows[index].FindControl("lblItemId")).Text.ToString();
                            string locationId = ((Label)dgvWHLocation.Rows[index].FindControl("lblLocId")).Text.ToString();
                            string stockValue = ((Label)dgvWHLocation.Rows[index].FindControl("lblStockValue")).Text.ToString();
                            string stockQty = ((Label)dgvWHLocation.Rows[index].FindControl("lblStockQty")).Text.ToString();
                            string transferQty = ((TextBox)dgvWHLocation.Rows[index].FindControl("txtTransferQty")).Text.ToString();
                            if(decimal.Parse(transferQty)>0)
                            {
                                CreateVoucherXml(itemid, locationId, transferQty, stockQty, stockValue);
                            }
                          
                        }


                    }
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXML); } catch { }

                string mrtg =  objOperation.WHLocationCreate(9, xmlString, intWH, newLocation, enroll);

               ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + mrtg + "');", true);
                dgvWHLocation.DataSource = ""; dgvWHLocation.DataBind();
                
            }


            catch { }

        }

        private void CreateVoucherXml(string itemid, string locationId,string transferQty,string stockQty, string stockValue)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateLocation(doc, itemid, locationId, transferQty, stockQty, stockValue);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateLocation(doc, itemid, locationId, transferQty, stockQty, stockValue);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            intWH = int.Parse(ddlWH.SelectedValue);
            if (radLocation.Checked == true)
            {
                int LocationId = int.Parse(ddlLocation.SelectedValue);
                dt = objOperation.WhDataView(8, "", intWH, LocationId, 2);
                dgvWHLocation.DataSource = dt;
                dgvWHLocation.DataBind();
            }            
           
        }

        private XmlNode CreateLocation(XmlDocument doc, string itemid,string locationId,string transferQty,string stockQty, string stockValue)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute LocationId = doc.CreateAttribute("locationId");
            LocationId.Value = locationId;
            XmlAttribute TransferQty = doc.CreateAttribute("transferQty");
            TransferQty.Value = transferQty;
            XmlAttribute StockQty = doc.CreateAttribute("stockQty");
            StockQty.Value = stockQty;
            XmlAttribute StockValue = doc.CreateAttribute("stockValue");
            StockValue.Value = stockValue;




            node.Attributes.Append(Itemid);
            node.Attributes.Append(LocationId);
            node.Attributes.Append(TransferQty);
            node.Attributes.Append(StockQty);
            node.Attributes.Append(StockValue);


            return node;
        }
        
        #endregion==========Close=============================================

        
    }
}