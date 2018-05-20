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
    public partial class FinishedGoodRoutingDetalis : BasePage
    {
        AssetMaintenance objWorkorderParts = new AssetMaintenance();
        Bom_BLL objBom = new Bom_BLL();
        DataTable dt = new DataTable();
        int intwh, enroll, BomId; string xmlData;
        int CheckItem = 1, intWh; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML; string xmlString = "", xmlstring2 = "";

       

        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("~/SCM/Data/Bgd__" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); }
                catch { }
                string itemName = Request.QueryString["itemname"].ToString();
                string stationName = Request.QueryString["stationName"].ToString();
                int workstationId =int.Parse(Request.QueryString["stationId"].ToString());
                intwh =int.Parse( Request.QueryString["intwh"].ToString());
                lblstationName.Text = stationName;
                lblItems.Text = itemName;

                dt = objBom.getBomRouting(8, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);
                dgvMan.DataSource = dt;
                dgvMan.DataBind();
                dt = objBom.getBomRouting(10, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);
                dgvMachineRpt.DataSource = dt;
                dgvMachineRpt.DataBind();
            }
        }
        protected void bnManpower_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnConfirm.Value == "1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    intwh = int.Parse(Request.QueryString["intwh"].ToString());
                    int workstationId = int.Parse(Request.QueryString["stationId"].ToString());
                    decimal qty = decimal.Parse(txtManpower.Text.ToString());
                    decimal hours = decimal.Parse(txtMahour.Text.ToString());
                    decimal rate = decimal.Parse(txtRate.Text.ToString());
                    xmlData = "<voucher><voucherentry qty=" + '"' + qty + '"' + " hours=" + '"' + hours + '"' + " rate=" + '"' + rate + '"' + "/></voucher>".ToString();
                    if (qty > 0 && hours > 0)
                    {
                        string msg = objBom.GetRoutingData(7, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);

                        dt = objBom.getBomRouting(8, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);
                        dgvMan.DataSource = dt;
                        dgvMan.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input quantity and hour');", true); }

                }
            }
            catch { }
        }
        protected void btnMAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(hdnPreConfirm.Value=="1")
                {
                    arrayKey = txtAsset.Text.Split(delimiterChars);
                    intwh = int.Parse(Request.QueryString["intwh"].ToString());
                    int workstationId = int.Parse(Request.QueryString["stationId"].ToString());
                    string asset = ""; string assetId = "";
                    if (arrayKey.Length > 0)
                    { asset = arrayKey[0].ToString(); assetId = arrayKey[3].ToString(); }
                    int intAssetId = int.Parse(assetId.ToString());
                    decimal hours = decimal.Parse(txtMacHour.Text.ToString());
                    if (intAssetId > 0 && hours > 0)
                    {
                        dgvMachine.Visible = true;
                        dgvMachineRpt.Visible = false;
                        CreateXml(asset, intAssetId.ToString(), hours.ToString());
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please input Asset and hour');", true); }
                }
                else { }
              
              
            }
            catch { }
        }

        private void CreateXml(string asset, string intAssetId, string hours)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, asset, intAssetId, hours);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, asset, intAssetId, hours);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string asset, string intAssetId, string hours)
        {
            XmlNode node = doc.CreateElement("voucherEntry");

            XmlAttribute Asset = doc.CreateAttribute("asset");
            Asset.Value = asset;

            XmlAttribute IntAssetId = doc.CreateAttribute("intAssetId");
            IntAssetId.Value = intAssetId;
            XmlAttribute Hours = doc.CreateAttribute("hours");
            Hours.Value = hours;

            

            node.Attributes.Append(Asset);
            node.Attributes.Append(IntAssetId);
            node.Attributes.Append(Hours);
        

            return node;
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
                { dgvMachine.DataSource = ds; }

                else { dgvMachine.DataSource = ""; }
                dgvMachine.DataBind();
            }
            catch { }
        }
        protected void btnSubmitM_Click(object sender, EventArgs e)
        {
            try
            {
                if(hdnConfirm.Value=="1")
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    XmlDocument doc = new XmlDocument();
                    intwh = int.Parse(Request.QueryString["intwh"].ToString());
                    int workstationId = int.Parse(Request.QueryString["stationId"].ToString());
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("voucher");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<voucher>" + xmlString + "</voucher>";
                    try { File.Delete(filePathForXML); } catch { }

                    string msg = objBom.GetRoutingData(9, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);

                    dt = objBom.getBomRouting(10, xmlString, xmlData, intWh, workstationId, DateTime.Now, enroll);
                    dgvMachineRpt.DataSource = dt;
                    dgvMachineRpt.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    dgvMachine.Visible = false;
                    dgvMachineRpt.Visible = true;

                    dgvMachine.DataSource = "";
                    dgvMachine.DataBind();
                    txtAsset.Text = "";
                    txtMacHour.Text = "0";
                }
               

            }
            catch { }
        }

         
        
        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvMachine.DataSource;
                dsGrid.Tables[0].Rows[dgvMachine.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvMachine.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvMachine.DataSource = ""; dgvMachine.DataBind(); }
                else { LoadGridwithXml(); }


            }

            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetItemSerach(string prefixText, int count)
        {
            AutoSearch_BLL objBoms = new AutoSearch_BLL();
            return objBoms.GetAssetItemByUnit(HttpContext.Current.Session["unit"].ToString(), prefixText);
        }

    }
}