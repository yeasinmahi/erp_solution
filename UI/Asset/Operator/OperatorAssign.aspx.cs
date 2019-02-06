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
        int intResEnroll; string number;
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

                dgvAsset.Visible = true;
                dgvAsetiew.Visible = false;
                dgvAsetiew.DataSource = "";
                dgvAsetiew.DataBind();


                arrayKey = txtAssetItem.Text.Split(delimiterChars);
                string assetId = ""; string assetName = ""; string assetType = ""; string assetLocation = "0";
                try
                {
                    if (arrayKey.Length > 0)
                    { assetName = arrayKey[0].ToString(); assetId = arrayKey[1].ToString(); number = (arrayKey[3].ToString()); assetType = arrayKey[5].ToString(); }
                }
                catch { number = "0"; }
                

                assetLocation = txtLocation.Text.ToString();
                if (int.Parse(number) >0)
                {

                    CheckXmlItemData(assetId);
                    if (CheckItem == 1)
                    {

                        CreateXml(assetId, assetName, assetLocation, number);
                        txtAssetItem.Text = "";
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Asset Id Already added');", true);
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Asset Number');", true); }
            }
            catch { }
        }

        private void CreateXml(string assetId, string assetName, string assetLocation,string number)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, assetId, assetName, assetLocation, number);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, assetId, assetName, assetLocation, number);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string assetId, string assetName, string assetLocation,string number)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute AssetId = doc.CreateAttribute("assetId");
            AssetId.Value = assetId;
            XmlAttribute AssetName = doc.CreateAttribute("assetName");
            AssetName.Value = assetName;
            XmlAttribute AssetLocation = doc.CreateAttribute("assetLocation");
            AssetLocation.Value = assetLocation;

            XmlAttribute Number = doc.CreateAttribute("number");
            Number.Value = number;
            

            node.Attributes.Append(AssetId);
          
            node.Attributes.Append(AssetName);
            node.Attributes.Append(AssetLocation);
            node.Attributes.Append(Number);


            return node;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                try
                {
                arrayKey = txtEmp.Text.Split(delimiterChars);

                try
                {
                    if (arrayKey.Length > 0)
                    { intResEnroll = int.Parse(arrayKey[7].ToString()); }
                }
                catch { intResEnroll = 0; }

                if(intResEnroll>0)
                {
                    string remarks = txtRemarks.Text.ToString();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    File.Delete(filePathForXML);
                    string msg = objCheck.OperatorSetup(1, xmlString, intResEnroll, 0, remarks, Enroll);
                    txtAssetItem.Text = "";txtEmp.Text = "";txtRemarks.Text = "";txtLocation.Text = "";
                    dgvAsset.DataSource = "";
                    dgvAsset.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Set Employee');", true);
                }
                   

                }
                catch { File.Delete(filePathForXML); }
             
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


        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
        public static string[] GetEmployeeSerach(string prefixText, int count)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            
            return objAutoSearch_BLL.GetEmployeeByJobstationOperator(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), prefixText.ToLower());

        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetSerach(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int Active = int.Parse(1.ToString());
            
             return objAutoSearch_BLL.GetAssetItem(Active, prefixText.ToLower());
            
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
                    txtLocation.Text = dt.Rows[0]["strNameOfAsset"].ToString() + " Unit:" + dt.Rows[0]["strUnit"].ToString() + " JobStation:" + dt.Rows[0]["strJobStationName"].ToString();

               }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);

                }
            }
            catch { }
        }

        protected void dgvAsetiew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                arrayKey = txtEmp.Text.Split(delimiterChars);
                try
                {
                    if (arrayKey.Length > 0)
                    { intResEnroll = int.Parse(arrayKey[7].ToString()); }
                }
                catch { intResEnroll = 0; }
                string Id = ((Label)dgvAsetiew.Rows[e.RowIndex].FindControl("lblId")).Text;
                if (intResEnroll > 0)
                {
                    string msg = objCheck.OperatorSetup(3, xmlString, intResEnroll, int.Parse(Id), "", Enroll);
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    showData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Employee');", true);
                }
              

            }
            catch { }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
             showData();
        }

        private void showData()
        {
            try
            {
                arrayKey = txtEmp.Text.Split(delimiterChars);
                try
                {
                    if (arrayKey.Length > 0)
                    { intResEnroll = int.Parse(arrayKey[7].ToString()); }
                }
                catch { intResEnroll = 0; }

                if (intResEnroll > 0)
                {
                    dgvAsset.DataSource = "";
                    dgvAsset.DataBind();
                    File.Delete(filePathForXML);
                    dgvAsset.Visible = false;
                    dgvAsetiew.Visible = true;
                    dt = objCheck.OperatorSetupData(2, xmlString, intResEnroll, 0, "", Enroll);
                    dgvAsetiew.DataSource = dt;
                    dgvAsetiew.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select Employee for Report');", true);
                }
            }
            catch { }
        }
    }
}