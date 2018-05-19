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

        int check;
        string pID, pIDName, accountName, LocationData, Location;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/BomR__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
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
                ddlType.DataSource = dt;
                ddlType.DataTextField = "strName";
                ddlType.DataValueField = "Id";
                ddlType.DataBind(); 

                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                try
                {
                    pID = ListBox1.SelectedValue.ToString();
                    pIDName = ListBox1.SelectedItem.ToString();
                    hdnOpID.Value = pID;
                    hdnOpName.Value = pIDName;
                }
                catch { }

                checkParent();

                pnlUpperControl.DataBind();

            }
        }

        private void checkParent()
        {
            if (LinkButton2.Text == string.Empty)
            {
                
            }
            else
            {
               
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
                if(hdnPreConfirm.Value=="1")
                {
                    dgvRptw.Visible = false;
                    dgvRoute.Visible = true;

                    arrayKey = txtFgItem.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWh.SelectedValue);
                    string item = ""; string itemId = "";
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemId = arrayKey[3].ToString(); }
                    string workName = hdnOpName.Value.ToString();
                    string strcode = txtRemarks.Text.ToString();
                    string workId =hdnOpID.Value.ToString();
                    string strTypeID = ddlType.SelectedValue.ToString();
                    string strTypeName = ddlType.SelectedItem.ToString();
                    string itemName = item;
                    checkXmlItemData(workId, strTypeID);
                    if (int.Parse(itemId) > 0 && int.Parse(hdnOpID.Value.ToString())>0)
                    {
                        if (CheckItem == 1)
                        {
                            CreateXml(itemName, itemId, workName, workId, strcode, strTypeID, strTypeName);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Workstation already added');", true); }
                    }

                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input FG Item or select Workstation');", true); }
                }
               



            }
            catch { }

        }
        private void checkXmlItemData(string workId,string strTypeID)
        {
            try
            {

                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (workId == (ds.Tables[0].Rows[i].ItemArray[3].ToString()))
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
        private void CreateXml(string itemName,string itemId,string workName,string workId,string strcode,string strTypeID,string strTypeName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, itemName, itemId, workName, workId, strcode, strTypeID, strTypeName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, itemName, itemId, workName, workId, strcode,strTypeID, strTypeName);
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
               
                txtFgItem.Text = ""; 
                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                pID = ListBox1.SelectedValue.ToString();
                pIDName = ListBox1.SelectedItem.ToString();
                hdnOpID.Value = pID;
                hdnOpName.Value = pIDName;

                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
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

        private XmlNode CreateItemNode(XmlDocument doc,string itemName,string itemId,string workName,string workId,string strcode,string strTypeID, string strTypeName)
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

            XmlAttribute StrTypeID = doc.CreateAttribute("strTypeID");
            StrTypeID.Value = strTypeID;

            XmlAttribute StrTypeName = doc.CreateAttribute("strTypeName");
            StrTypeName.Value = strTypeName;

         
            node.Attributes.Append(ItemName);
            node.Attributes.Append(ItemId);
            node.Attributes.Append(WorkName);
            node.Attributes.Append(WorkId);
            node.Attributes.Append(Strcode);

            node.Attributes.Append(StrTypeID);
            node.Attributes.Append(StrTypeName);

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


        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                accountName = ">" + ListBox1.SelectedItem.ToString();
                pID = ListBox1.SelectedValue.ToString();
                pIDName = ListBox1.SelectedItem.ToString();
                hdnOpID.Value = pID;
                hdnOpName.Value = pIDName;

                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                if (LinkButton2.Text.Length == 0) { LinkButton2.Text = accountName.ToString(); hdn1.Value = pID; }
                else if (LinkButton3.Text.Length == 0) { LinkButton3.Text = accountName.ToString(); hdn2.Value = pID; }
                else if (LinkButton4.Text.Length == 0) { LinkButton4.Text = accountName.ToString(); hdn3.Value = pID; }
                else if (LinkButton5.Text.Length == 0) { LinkButton5.Text = accountName.ToString(); hdn4.Value = pID; }
                else if (LinkButton6.Text.Length == 0) { LinkButton6.Text = accountName.ToString(); hdn5.Value = pID; }
                else if (LinkButton7.Text.Length == 0) { LinkButton7.Text = accountName.ToString(); hdn6.Value = pID; }
                else if (LinkButton8.Text.Length == 0) { LinkButton8.Text = accountName.ToString(); hdn7.Value = pID; }
                else if (LinkButton9.Text.Length == 0) { LinkButton9.Text = accountName.ToString(); hdn8.Value = pID; }
                else if (LinkButton10.Text.Length == 0) { LinkButton10.Text = accountName.ToString(); hdn9.Value = pID; }
               

            }
            catch { }
        }

        #region==================Link Button Chaild View======================
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getWorkstationParent(intwh);
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();


                LinkButton2.Text = string.Empty;
                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                pID = hdn1.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton2.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton3.Text = string.Empty; LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn2.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton3.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton4.Text = string.Empty; LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
               
                pID = hdn3.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton4.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton5.Text = string.Empty; LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn4.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton5.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton6.Text = string.Empty; LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn5.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton6.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton7.Text = string.Empty; LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn6.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton7.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                LinkButton8.Text = string.Empty;
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn7.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton8.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton9.Text = string.Empty; LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            try
            {

                pID = hdn8.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton9.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                LinkButton10.Text = string.Empty;
                checkParent();
            }
            catch { }

        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            try
            {
                pID = hdn9.Value;
                hdnOpID.Value = pID;
                hdnOpName.Value = LinkButton10.Text.ToString();
                intwh = int.Parse(ddlWh.SelectedValue);
                dt = objBom.getChildData(intwh, int.Parse(pID));
                ListBox1.DataSource = dt;
                ListBox1.DataTextField = "strName";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();
                checkParent();
            }
            catch { }

        }

        #endregion=================Close================================================
    }
}