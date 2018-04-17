using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Purchase_BLL.Asset;
using System.Web.Services;
using System.Web.Script.Services;

namespace UI.Asset
{
    public partial class AssetDebitCreditSetup : BasePage
    {
        AssetMaintenance configure = new AssetMaintenance();
        AssetInOut objasset = new AssetInOut();
        DataTable dt = new DataTable();
        string filePathForXMLAssetAccoA;

        string xmlString = ""; string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string debit, credit, accCOAid=null, accCOAName=null,drcrType; int intunit;
        string assetcoa, assetcoaName;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXMLAssetAccoA = Server.MapPath("~/Asset/Data/CC_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            //

            if (!IsPostBack)
            {
                try { File.Delete(filePathForXMLAssetAccoA); dgvGridView.DataSource = ""; dgvGridView.DataBind(); }
                catch { }
                //Session["WareID"] = hdnwh.Value;
                intunit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
               int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objasset.UnitByUser(enroll);
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
                intunit = int.Parse(ddlUnit.SelectedValue);
                dt.Clear();
                //dt =configure.DepreciationView(12, "", DateTime.Now, DateTime.Now, intunit, 0);
                dt = objasset.AssetTransectionType();
                ddlTransecTionType.DataSource = dt;
                ddlTransecTionType.DataTextField = "Name";
                ddlTransecTionType.DataValueField = "ID";
                ddlTransecTionType.DataBind();
                dt.Clear();
                dt = configure.AssetType();
                ddlAssetType.DataSource = dt;
                ddlAssetType.DataTextField = "strAssetTypeName";
                ddlAssetType.DataValueField = "intAssetTypeID";
                ddlAssetType.DataBind();
                dt.Clear();
            }
            else
            {

            }
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAssetCoaSearch(string prefixText, int count)
        {
          
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int intunit =Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
            return objAutoSearch_BLL.AutoSearchFixedAssetCoa(intunit.ToString(), prefixText);
           
        }
        [WebMethod]
        [ScriptMethod]
        public static string[] GetAccCoaSearch(string prefixText, int count)
        {

            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            int intunit = Convert.ToInt32(HttpContext.Current.Session["UnitID"].ToString());
            return objAutoSearch_BLL.AutoSearchAccountsChartOfACC(intunit.ToString(), prefixText);

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
                int unit = int.Parse(ddlUnit.SelectedValue.ToString());
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                string xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                try { File.Delete(filePathForXMLAssetAccoA); } catch { }

                dt= configure.DepreciationView(14, xmlString, DateTime.Now, DateTime.Now, unit, 0);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);
                dgvGridView.DataSource = ""; dgvGridView.DataBind();

                }
            catch { }
        }

        protected void dgvGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int intID = int.Parse(((Label)dgvGridView.Rows[e.RowIndex].FindControl("lblAutoID")).Text);
                if (intID != 0)
                {
                    dt = configure.DepreciationView(18, "", DateTime.Now, DateTime.Now, intID, 0);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesasge"].ToString() + "');", true);

                    GridViewLoad();

                }
                else
                {
                    LoadGridwithXml();
                    DataSet dsGrid = (DataSet)dgvGridView.DataSource;
                    dsGrid.Tables[0].Rows[dgvGridView.Rows[e.RowIndex].DataItemIndex].Delete();
                    dsGrid.WriteXml(filePathForXMLAssetAccoA);
                    DataSet dsGridAfterDelete = (DataSet)dgvGridView.DataSource;
                    if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                    { File.Delete(filePathForXMLAssetAccoA); dgvGridView.DataSource = ""; dgvGridView.DataBind(); }
                    else { LoadGridwithXml(); }
                }

            }

            catch { }
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                   
                dgvGridView.DataBind();
            }
            catch { }
        }

        protected void ddlAssetCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();
            }
            catch { }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewLoad();
        }

        protected void DdlBillUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["UnitID"] = ddlUnit.SelectedValue.ToString();
            }
            catch { }
        }

        protected void DdlBillUnit_DataBound(object sender, EventArgs e)
        {
            try
            {
                Session["UnitID"] = ddlUnit.SelectedValue.ToString();
            }
            catch { }
          
        }

        private void GridViewLoad()
        {
            try
            {
                string assetTypeid = ddlAssetType.SelectedValue.ToString();

               
                string xml = "<voucher><voucherentry AssetCOA=" + '"' + assetTypeid + '"' + "/></voucher>".ToString();

               dt = configure.DepreciationView(17, xml, DateTime.Now, DateTime.Now, int.Parse(ddlUnit.SelectedValue), int.Parse(ddltype.SelectedValue));
                dgvGridView.Visible = true;
                dgvGridView.DataSource = "";
                dgvGridView.DataBind();

                if (dt.Rows.Count > 0)
                {
                    dgvGridView.DataSource = dt;
                }

                else
                {
                    dgvGridView.DataSource = "";

                }
                dgvGridView.DataBind();

                
            }
            catch { }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (radCredit.Checked == true || radDebit.Checked == true)
                { 
                    string typeid = ddltype.SelectedValue.ToString();
                    string typeName = ddltype.SelectedItem.ToString();
                    string accountstypeID = ddlTransecTionType.SelectedValue.ToString();
                    string accountstypeName = ddlTransecTionType.SelectedItem.ToString();
                    string assetypeID = ddlAssetType.SelectedValue.ToString();
                    string assetypeName = ddlAssetType.SelectedItem.ToString(); 

                    arrayKey = txtAccCoa.Text.Split(delimiterChars);
                    if (arrayKey.Length > 0)
                    { accCOAName = arrayKey[0].ToString(); accCOAid = arrayKey[1].ToString(); }


                    string unit = ddlUnit.SelectedValue.ToString();
                    string unitName = ddlUnit.SelectedItem.ToString();
                    string autoID = "0".ToString();
                    if (radDebit.Checked == true)
                    {
                        debit = accCOAid.ToString();
                       
                        drcrType = "Debit".ToString();
                    }

                    else { debit = "".ToString(); }
                    if (radCredit.Checked == true)
                    {
                        credit = accCOAid.ToString();
                        
                        drcrType = "Credit".ToString();
                    }
                    else
                    { credit = "".ToString(); } 

                    string enroll = Session[SessionParams.USER_ID].ToString();

                    CreateVoucherXml(unit, unitName, assetcoa, assetcoaName, typeid, typeName, accCOAid, accCOAName, debit, credit, drcrType, enroll, autoID.ToString(), accountstypeID, accountstypeName, assetypeID, assetypeName);
                }
            }
            catch { }
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvGridView.DataSource = ds; }

                else { dgvGridView.DataSource = ""; }
                dgvGridView.DataBind();
            }
            catch { }

        }
        private void CreateVoucherXml(string unit, string unitName,string assetcoa,string assetcoaName, string typeid, string typeName , string accCOAid,string accCOAName, string debit, string credit,string drcrType, string enroll,string autoID,string accountstypeID, string accountstypeName,string  assetypeID,string assetypeName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAssetAccoA))
            {
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, unit, unitName, assetcoa, assetcoaName, typeid, typeName, accCOAid, accCOAName, debit, credit, drcrType, enroll, autoID, accountstypeID, accountstypeName, assetypeID, assetypeName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, unit, unitName, assetcoa, assetcoaName, typeid, typeName, accCOAid, accCOAName, debit, credit, drcrType, enroll, autoID, accountstypeID, accountstypeName, assetypeID, assetypeName);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAssetAccoA);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string unit, string unitName, string assetcoa, string assetcoaName, string typeid, string typeName, string accCOAid, string accCOAName, string debit, string credit,string drcrType, string enroll,string autoID,string accountstypeID,string  accountstypeName,string assetypeID,string assetypeName)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Unit = doc.CreateAttribute("unit");
            Unit.Value = unit;
            XmlAttribute UnitName = doc.CreateAttribute("unitName");
            UnitName.Value = unitName;
            XmlAttribute Assetcoa = doc.CreateAttribute("assetcoa");
            Assetcoa.Value = assetcoa;
            XmlAttribute AssetcoaName = doc.CreateAttribute("assetcoaName");
            AssetcoaName.Value = assetcoaName;

            XmlAttribute Typeid = doc.CreateAttribute("typeid");
            Typeid.Value = typeid;
            XmlAttribute TypeName = doc.CreateAttribute("typeName");
            TypeName.Value = typeName;

            XmlAttribute AccCOAid = doc.CreateAttribute("accCOAid");
            AccCOAid.Value = accCOAid;
            XmlAttribute AccCOAName = doc.CreateAttribute("accCOAName");
            AccCOAName.Value = accCOAName;
            
            XmlAttribute Debit = doc.CreateAttribute("debit");
            Debit.Value = debit;
            XmlAttribute Credit = doc.CreateAttribute("credit");
            Credit.Value = credit;

            XmlAttribute DrcrType = doc.CreateAttribute("drcrType");
            DrcrType.Value = drcrType;

            XmlAttribute Enroll = doc.CreateAttribute("enroll");
            Enroll.Value = enroll;
            XmlAttribute AutoID = doc.CreateAttribute("autoID");
            AutoID.Value = autoID;

            XmlAttribute AccountstypeID = doc.CreateAttribute("accountstypeID");
            AccountstypeID.Value = accountstypeID;

            XmlAttribute AccountstypeName = doc.CreateAttribute("accountstypeName");
            AccountstypeName.Value = accountstypeName;
            XmlAttribute AssetypeID = doc.CreateAttribute("assetypeID");
            AssetypeID.Value = assetypeID;

            XmlAttribute AssetypeName = doc.CreateAttribute("assetypeName");
            AssetypeName.Value = assetypeName;
            
            node.Attributes.Append(Unit);
            node.Attributes.Append(UnitName);
            node.Attributes.Append(Assetcoa);
            node.Attributes.Append(AssetcoaName);
            node.Attributes.Append(Typeid);
            node.Attributes.Append(TypeName);            
            node.Attributes.Append(AccCOAid);
            node.Attributes.Append(AccCOAName);
            node.Attributes.Append(Debit);
            node.Attributes.Append(Credit);
            node.Attributes.Append(DrcrType);
            node.Attributes.Append(Enroll);
            node.Attributes.Append(AutoID);

            node.Attributes.Append(AccountstypeID);
            node.Attributes.Append(AccountstypeName);
            node.Attributes.Append(AssetypeID);
            node.Attributes.Append(AssetypeName);
            
            return node;

        }
    }
}