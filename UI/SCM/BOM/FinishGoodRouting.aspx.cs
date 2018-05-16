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
                dgvRoute.Visible = false;
                dgvReport.Visible = false;
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = objBom.GetBomData(1, xmlData, intwh, BomId, DateTime.Now, enroll);
                if (dt.Rows.Count > 0)
                {            
                    ddlWh.DataSource = dt;
                    ddlWh.DataTextField = "strName";
                    ddlWh.DataValueField = "Id";
                    ddlWh.DataBind();
                }
            }
        }
        

       [WebMethod]
        [ScriptMethod]
        public static string[] GetItemSerach(string prefixText, int count)
        {
            Bom_BLL objBoms = new Bom_BLL();

            return objBoms.AutoSearchBomId(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString(), prefixText);

        }


        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetItemSerach(string prefixText, int count)
        {
            AutoSearch_BLL objBoms = new AutoSearch_BLL(); 
            return objBoms.GetAssetItemByUnit(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString(), prefixText); 
        }


        protected void btnAssetAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRoute.Visible = true;
                dgvReport.Visible = false;
                if (hdnPreConfirm.Value=="1")
                {
                    arrayKey = txtAsset.Text.Split(delimiterChars);
                    intWh = int.Parse(ddlWh.SelectedValue);
                    string assetname = ""; string assetId = ""; string strAssetCode = "";
                    if (arrayKey.Length > 0)
                    { assetname = arrayKey[0].ToString(); assetId = arrayKey[3].ToString(); }
                    string strHour = txtHour.Text.ToString();
                    checkXmlItemData(assetId);
                    if (CheckItem == 1)
                    {
                        CreateXml(assetname, assetId, strHour);
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Item already added');", true); }
                } 
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
        private void CreateXml(string assetname, string assetId, string strHour)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, assetname, assetId, strHour);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, assetname, assetId, strHour);
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
                string item = ""; string itemid = ""; string strAssetCode = "";
                if (arrayKey.Length > 0)
                { item = arrayKey[0].ToString(); itemid = arrayKey[3].ToString(); }

                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if(int.Parse(itemid)>0)
                {
                    dt = objBom.getBomRouting(3, xmlString, xmlData, intWh, int.Parse(itemid), DateTime.Now, enroll);
                    dgvRoute.Visible = false;
                    dgvReport.Visible = true;

                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select FG Item');", true); }
             

            }
            catch { }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(hdnConfirm.Value=="1")
                {
                    arrayKey = txtFgItem.Text.Split(delimiterChars);
                    string item = ""; string itemid = ""; string strAssetCode = "";
                    if (arrayKey.Length > 0)
                    { item = arrayKey[0].ToString(); itemid = arrayKey[3].ToString(); }
                    string strHour = txtHoursMan.Text.ToString();
                    string qty = txtQty.Text.ToString();
                    string remarks = txtRemarks.Text.ToString();

                    string xmlData = "<voucher><voucherentry qty=" + '"' + qty + '"' + " remarks=" + '"' + remarks + '"' + " strHour=" + '"' + strHour + '"' + "/></voucher>".ToString();
                    if (decimal.Parse(qty) > 0)
                    {
                        enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        XmlDocument doc = new XmlDocument();
                        intWh = int.Parse(ddlWh.SelectedValue);
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("voucher");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<voucher>" + xmlString + "</voucher>";
                        try { File.Delete(filePathForXML); } catch { }
                        string msg = objBom.GetRoutingData(2, xmlString, xmlData, intWh, int.Parse(itemid), DateTime.Now, enroll);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                        dgvRoute.DataSource = "";
                        dgvRoute.DataBind();
                        txtQty.Text = "0";
                        txtHoursMan.Text = "0";
                        txtRemarks.Text = "0";
                    }
                }
               

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

        private XmlNode CreateItemNode(XmlDocument doc, string assetname, string assetId, string strHour)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Assetname = doc.CreateAttribute("assetname");
            Assetname.Value = assetname;
            XmlAttribute AssetId = doc.CreateAttribute("assetId");
            AssetId.Value = assetId;
            XmlAttribute StrHour = doc.CreateAttribute("strHour");
            StrHour.Value = strHour;
             

            node.Attributes.Append(Assetname);
            node.Attributes.Append(AssetId);
            node.Attributes.Append(StrHour); 
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