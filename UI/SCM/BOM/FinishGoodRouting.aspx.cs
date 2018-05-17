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

namespace UI.SCM.BOM
{
    public partial class FinishGoodRouting: BasePage
    {
        AssetMaintenance objWorkorderParts = new AssetMaintenance(); 
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "", xmlstring2 = ""; 
       

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomMat__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {

                try { File.Delete(filePathForXML); dgvRoute.DataSource = ""; dgvRoute.DataBind(); }
                catch { }
                
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                { 
                    ddlWh.DataSource = dt;
                    ddlWh.DataTextField = "strName";
                    ddlWh.DataValueField = "Id";
                    ddlWh.DataBind();
                } 

                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }

                dt = objBom.getBomRouting(5, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                ddlStation.DataSource = dt;
                ddlStation.DataTextField = "strName";
                ddlStation.DataValueField = "Id";
                ddlStation.DataBind();

            }
        }
        

       [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();

            return objBoms.AutoSearchBomId(HttpContext.Current.Session["unit"].ToString(), prefixText);

        }


        

        protected void btnAssetAdd_Click(object sender, EventArgs e)
        {
            try
            {

                dgvRptw.Visible = false;
                dgvRoute.Visible =true;

                arrayKey = txtFgItem.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWh.SelectedValue);
                    string item = ""; string itemId = "";  
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemId = arrayKey[3].ToString(); }
                    string workName = ddlStation.SelectedValue.ToString();
                    string strcode = "0".ToString();
                    string workId = ddlStation.SelectedValue.ToString();
                    string itemName = item;
                    checkXmlItemData(itemId);
                if (int.Parse(itemId) > 0)
                {
                    if (CheckItem == 1)
                    {
                        CreateXml(itemName, itemId, workName, workId, strcode);
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                }

                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input FG Item');", true); }



            }
            catch { }

        }
        private void checkXmlItemData(string assetId)
        {
            try
            {

                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (assetId == (ds.Tables[0].Rows[i].ItemArray[1].ToString()))
                    {
                        CheckItem = 0;
                        break;
                    }
                    else
                    {
                        CheckItem = 1;
                    } 
                }
            }
            catch { }

        }
        private void CreateXml(string itemName,string itemId,string workName,string workId,string strcode)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemName, itemId, workName, workId, strcode);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemName, itemId, workName, workId, strcode);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                arrayKey = txtFgItem.Text.Split(delimiterChars);
                string item = ""; string itemid = "";  
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[3].ToString(); } 
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if(int.Parse(itemid)>0)
                {
                    dgvRptw.Visible = true;
                    dgvRoute.Visible = false;
                    dt = objBom.getBomRouting(6, xmlString, xmlData, intWh, int.Parse(itemid), DateTime.Now, enroll);
                    dgvRptw.DataSource = dt;
                    dgvRptw.DataBind();

                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select FG Item');", true); }
             

            }
            catch { }
        }

        protected void ddlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 

                intwh = int.Parse(ddlWh.SelectedValue);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.getBomRouting(4, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {
                    hdnUnit.Value = dt.Rows[0]["intunit"].ToString();
                    Session["unit"] = hdnUnit.Value.ToString();
                }
                dt = objBom.getBomRouting(5, xmlString, xmlData, intwh, 0, DateTime.Now, enroll);
                ddlStation.DataSource = dt;
                ddlStation.DataTextField = "strName";
                ddlStation.DataValueField = "Id";
                ddlStation.DataBind();
            }
            catch { }
        }

        protected void btnDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                try { File.Delete(filePathForXML); }
                catch { }
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                GridViewRow row = (GridViewRow)((Button)sender).NamingContainer; 
                Label lblItem = row.FindControl("lblItem") as Label;
                Label lblSectionName = row.FindControl("lblSectionName") as Label;
                Label lblWorkstationId = row.FindControl("lblWorkstationId") as Label;
                intwh = int.Parse(ddlWh.SelectedValue);
                string itemname = lblItem.Text.ToString();
                string stationName = lblSectionName.Text.ToString();
                string stationId = lblWorkstationId.Text.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + itemname + "','" + stationName.ToString() + "','" + stationId + "','" + intwh + "');", true);


               
            }
            catch { }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                        
                        enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        XmlDocument doc = new XmlDocument();
                        intWh = int.Parse(ddlWh.SelectedValue);
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("voucher");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<voucher>" + xmlString + "</voucher>";
                        try { File.Delete(filePathForXML); } catch { }
                        string msg = objBom.GetRoutingData(2, xmlString, xmlData, intWh, 0, DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvRoute.DataSource = "";
                        dgvRoute.DataBind();
                        txtFgItem.Text = "";
                       
                        
                    
                 


            }
            catch { }
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvRoute.DataSource = ds; }

                else { dgvRoute.DataSource = ""; }
                dgvRoute.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNode(XmlDocument doc,string itemName,string itemId,string workName,string workId,string strcode)
        {
            XmlNode node = doc.CreateElement("voucherEntry");
             
                 XmlAttribute ItemName = doc.CreateAttribute("itemName");
            ItemName.Value = itemName;

            XmlAttribute ItemId = doc.CreateAttribute("itemId");
            ItemId.Value = itemId;
            XmlAttribute WorkName = doc.CreateAttribute("workName");
            WorkName.Value = workName;

            XmlAttribute WorkId = doc.CreateAttribute("workId");
            WorkId.Value = workId;

            XmlAttribute Strcode = doc.CreateAttribute("strcode");
            Strcode.Value = strcode;

            node.Attributes.Append(ItemName);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(WorkName);
            node.Attributes.Append(WorkId);
            node.Attributes.Append(Strcode);
 
            return node;
        }
        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvRoute.DataSource;
                dsGrid.Tables[0].Rows[dgvRoute.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvRoute.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvRoute.DataSource = ""; dgvRoute.DataBind(); }
                else { LoadGridwithXml(); }


            }

            catch { }
        }

    }
}