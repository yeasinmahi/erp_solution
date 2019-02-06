using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;

using System.Data;
using UI.ClassFiles;
using System.Web.Services;
using System.Web.Script.Services;
using Utility;
using System.IO;
using System.Xml;

namespace UI.Asset.Operator
{
    public partial class OperatorAssign : BasePage
    {
        AssetInOut objCheck = new AssetInOut();
        DataTable dt = new DataTable();
        int intResEnroll, intWHiD, intType, intActionBy; string assetCode, number, strNaration, stringXml;
        private string filePathForXML;
        private string xmlString;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        private int CheckItem = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                filePathForXML = Server.MapPath("~/Asset/Data/OP" + Enroll + ".xml");

                if ( !IsPostBack)
                {
                   
                    File.Delete(filePathForXML);
                    dgvAsset.DataSource = "";
                    dgvAsset.DataBind();

                }
            }
            catch { }
        }

        protected void btnAddd_Click(object sender, EventArgs e)
        {
            try
            {



                arrayKey = txtAssetItem.Text.Split(delimiterChars);
                string assetId = ""; string assetName = ""; string assetType = ""; string assetLocation = "0";
                if (arrayKey.Length > 0)
                { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); number = (arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }

                CheckXmlItemData(assetId);
                if (CheckItem == 1)
                {
                     
                    CreateXml(assetId, assetName, assetLocation);
                }

            }
            catch { }
        }

        private void CreateXml(string assetId, string assetName, string assetLocation)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, assetId, assetName, assetLocation);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, assetId, assetName, assetLocation);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string assetId, string assetName, string assetLocation)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute AssetId = doc.CreateAttribute("assetId");
            AssetId.Value = assetId;
            XmlAttribute AssetName = doc.CreateAttribute("assetName");
            AssetName.Value = assetName;
            XmlAttribute AssetLocation = doc.CreateAttribute("assetLocation");
            AssetLocation.Value = assetLocation;
             

            node.Attributes.Append(AssetId);
          
            node.Attributes.Append(AssetName);
            node.Attributes.Append(AssetLocation);

           
            return node;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                intWh = int.Parse(ddlWH.SelectedValue);
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";

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
                { dgvAsset.DataSource = ds; }
                else { dgvAsset.DataSource = ""; }
                dgvAsset.DataBind();
            }
            catch (Exception ex) { }
        }
        private void CheckXmlItemData(string itemid)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePathForXML);
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (itemid == (ds.Tables[0].Rows[i].ItemArray[0].ToString()))
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


        protected void GridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvAsset.DataSource;
                dsGrid.Tables[0].Rows[dgvAsset.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvAsset.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML);
                    dgvAsset.DataSource = "";
                    dgvAsset.DataBind();
                }
                else
                {
                    LoadGridwithXml();
                }
            }
            catch (Exception ex) { }
        }
 


        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmployeeAutoSearch(string prefixText, int count)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            
            return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText);

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetAutoSearch(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            
             return objAutoSearch_BLL.GetAssetItem(Active, prefixText);
            
        }

        protected void TxtAsset_TextChanged(object sender, EventArgs e)
        {
            try
            {

        
                   arrayKey = txtAssetItem.Text.Split(delimiterChars);
                    string assetId = ""; string assetName = ""; string assetType = ""; int assetAutoId = 0;
                    if (arrayKey.Length > 0)
                    { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); number = (arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }
 
                dt = objCheck.ShowassetData(number);
                if (dt.Rows.Count > 0)
                {
                    txtAssetItem.Text = dt.Rows[0]["strNameOfAsset"].ToString();
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
            catch { }
        }
    }
}