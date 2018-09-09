using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Xml;
using System.IO;

namespace UI.SCM
{
    public partial class FinishedGoodsBridge : BasePage
    {
        string xmlpath, xmlString;
        DataTable dt = new DataTable();
        InventoryTransfer_BLL objinventoryTransfer = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                xmlpath = Server.MapPath("~/SCM/Data/ItemList_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
                pnlUpperControl.DataBind();
                DefaultPageLoad();
                //Panel1.Visible = false;
            }
        }
        private void DefaultPageLoad()
        {
            dt = objinventoryTransfer.GetWearHouse();
            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "strWareHoseName";
            ddlUnit.DataValueField = "intUnitID";
            ddlUnit.DataBind();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

            int unitid = Convert.ToInt32( ddlUnit.SelectedItem.Value) ;
            dt = objinventoryTransfer.GetFGList(unitid);
            ddlFG.DataSource = dt;
            ddlFG.DataTextField = "strProduct";
            ddlFG.DataValueField = "intID";
            ddlFG.DataBind();

            dt = objinventoryTransfer.GetSadUOMList(unitid);
            ddlSadUOM.DataSource=dt;
            ddlSadUOM.DataTextField = "strUOM";
            ddlSadUOM.DataValueField = "intID";
            ddlSadUOM.DataBind();

            dt = objinventoryTransfer.GetSadUOMList(unitid);
            ddlInvUOM.DataSource = dt;
            ddlInvUOM.DataTextField = "strUOM";
            ddlInvUOM.DataValueField = "intID";
            ddlInvUOM.DataBind();

            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = 0.ToString();
            }

        }

        protected void btnAddFg_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strName= ddlFG.SelectedItem.Text;
            string strDescription = "";
            string strPartNo = "";
            string strBrand="";
            int intClusterID = 2;
            int intComGroupID = 37;
            int intCategoryID = 45;
            DateTime dteLastActionTime = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", null);
            string strUoM = ddlInvUOM.SelectedItem.Text;
            int intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intUnit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            int SADItemID = Convert.ToInt32(ddlFG.SelectedItem.Value);
            int numConversion = Convert.ToInt32(txtCount.Text);
            int intSadStandardUOM = Convert.ToInt32(ddlSadUOM.SelectedItem.Value);
            int intInvUoM = Convert.ToInt32(ddlInvUOM.SelectedItem.Value);
            dt = objinventoryTransfer.InsertItemList(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, intEnroll, dteLastActionTime, strUoM);

            objinventoryTransfer.GetItemMasterList(strName,strDescription,strPartNo,strBrand,intClusterID,intComGroupID,intCategoryID,strUoM,intEnroll,intUnit,SADItemID,numConversion,intSadStandardUOM,intInvUoM);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Updated.');", true);
        }

        protected void btnAddMasterItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strName = ddlFG.SelectedItem.Text;
            string strDescription = "";
            string strPartNo = "";
            string strBrand = "";
            int intClusterID = 2;
            int intComGroupID = 37;
            int intCategoryID = 45;
            DateTime dteLastActionTime = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", null);
            string strUoM = ddlInvUOM.SelectedItem.Text;
            int intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intUnit = Convert.ToInt32(ddlUnit.SelectedItem.Value);
            int SADItemID = Convert.ToInt32(ddlFG.SelectedItem.Value);
            int numConversion = Convert.ToInt32(txtCount.Text);
            int intSadStandardUOM = Convert.ToInt32(ddlSadUOM.SelectedItem.Value);
            int intInvUoM = Convert.ToInt32(ddlInvUOM.SelectedItem.Value);
            // objinventoryTransfer.CreateItemMasterList(strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, strUoM, intEnroll);
            CreateXml(strName, strDescription, strPartNo, strBrand, intClusterID.ToString(), intComGroupID.ToString(), intCategoryID.ToString(), strUoM, intEnroll.ToString());
             ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Items Added Successfully.');", true);
        }

       
        protected void ddlFG_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlInvUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = 0.ToString();
            }
        }

        protected void ddlSadUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSadUOM.SelectedItem.Text == ddlInvUOM.SelectedItem.Text)
            {
                txtCount.Text = 1.ToString();
            }
            else
            {
                txtCount.Text = 0.ToString();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            Label lblBaseName = (Label)FindControl("lblitemBaseName");
            lblBaseName.Text = ddlFG.SelectedItem.Text;
            Label lbluom = (Label)FindControl("lblitemDescription");
            lbluom.Text = ddlInvUOM.SelectedItem.Text;
            Label lblcluster = (Label)FindControl("lblcluster");
            lblcluster.Text = "Material";
            Label lblcommodity = (Label)FindControl("lblcommodity");
            lblcommodity.Text = "Finished Goods";
            Label lblclus = (Label)FindControl("lblclus");
            lblclus.Text = 2.ToString();
            Label lblgroup = (Label)FindControl("lblgroup");
            lblgroup.Text = 37.ToString();
            Label lblcat = (Label)FindControl("lblcat");
            lblcat.Text = 45.ToString();
           

           
        }
        private void CreateXml(string strName, string strDescription, string strPartNo, string strBrand, string intClusterID, string intComGroupID, string intCategoryID, string strUoM, string intEnroll)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("CustomerBankGaurantee");
                XmlNode addItem = CreateNode(doc, strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, strUoM, intEnroll);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclarationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclarationNode);
                XmlNode rootNode = doc.CreateElement("CustomerBankGaurantee");
                XmlNode addItem = CreateNode(doc, strName, strDescription, strPartNo, strBrand, intClusterID, intComGroupID, intCategoryID, strUoM, intEnroll);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
            LoadXml();
        }
        private XmlNode CreateNode(XmlDocument doc, string strName, string strDescription, string strPartNo, string strBrand, string intClusterID, string intComGroupID, string intCategoryID, string strUoM, string intEnroll)
        {
            XmlNode node = doc.CreateElement("ItemList");
            XmlAttribute StrName = doc.CreateAttribute("strName");
            StrName.Value = strName;
            XmlAttribute StrDescription = doc.CreateAttribute("strDescription");
            StrDescription.Value = strDescription;
            XmlAttribute StrPartNo = doc.CreateAttribute("strPartNo");
            StrPartNo.Value = strPartNo;
            XmlAttribute StrBrand = doc.CreateAttribute("strBrand");
            StrBrand.Value = strBrand;
            XmlAttribute IntClusterID = doc.CreateAttribute("intClusterID");
            IntClusterID.Value = intClusterID;
            XmlAttribute IntComGroupID = doc.CreateAttribute("intComGroupID");
            IntComGroupID.Value = intComGroupID;
            XmlAttribute StrUoM = doc.CreateAttribute("strUoM");
            StrUoM.Value = strUoM;
            XmlAttribute IntEnroll = doc.CreateAttribute("intEnroll");
            IntEnroll.Value = intEnroll;
           


            node.Attributes.Append(StrName);
            node.Attributes.Append(StrDescription);
            node.Attributes.Append(StrPartNo);
            node.Attributes.Append(StrBrand);
            node.Attributes.Append(IntClusterID);
            node.Attributes.Append(IntComGroupID);
            node.Attributes.Append(StrUoM);
            node.Attributes.Append(IntEnroll);

            return node;
        }

        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("Item");
                xmlString = xlnd.InnerXml;
                xmlString = "<Item>" + xmlString + "</Item>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GVCustList.DataSource = ds;
                }
                else
                {
                   // GVCustList.DataSource = "";
                }
               // GVCustList.DataBind();
            }
            catch
            {
              //  GVCustList.DataSource = "";
                //GVCustList.DataBind();
            }

        }










    }
}