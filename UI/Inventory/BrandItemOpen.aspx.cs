using HR_BLL.TourPlan;
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

namespace UI.Inventory
{
    public partial class BrandItemOpen : System.Web.UI.Page
    {
        string xmlpath; string xmlString = "", itemname, uomname;
        int unitid, uomid, rpttypeid;
        TourPlanning bll = new TourPlanning();
        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string secid = "0"; DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                hdnunit.Value = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                hdnAction.Value = "0";
                ////---------xml----------
                try { File.Delete(xmlpath); }
                catch { }
                ////-----**----------//
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }
        private void Clearcontrols()
        {
            txtItemName.Text = ""; 
            
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                bool proceed = false;
                itemname = txtItemName.Text.ToString();
                uomid = int.Parse(ddlUOM.SelectedValue.ToString());
                unitid= int.Parse(ddlUnit.SelectedValue.ToString());
                rpttypeid= int.Parse(ddlUnit.SelectedValue.ToString());
                int cnt = dgv.Rows.Count;

                if (cnt == 0)
                {
                    CreateXml(itemname, uomname);
                    Clearcontrols();
                }

                else
                {
                    for (int r = 0; r < cnt; r++)
                    {
                        string itmname = ((HiddenField)dgv.Rows[r].FindControl("hdnitemname")).Value.ToString();
                        if (itemname != itmname) { proceed = true; }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please select another item.');", true);
                            break;
                        }
                    }

                    if (proceed == true)
                    {
                        CreateXml(itemname, uomname);
                        Clearcontrols();
                    }
                }

            }
        }

        private void CreateXml(string itemname,string uomname)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("BrnadItmOpen");
                XmlNode addItem = CreateNode(doc, itemname, uomname);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BrnadItmOpen");
                XmlNode addItem = CreateNode(doc, itemname, uomname);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath); LoadXml();
        }

        private XmlNode CreateNode(XmlDocument doc, string itemname, string uomname)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemname = doc.CreateAttribute("itemname");
            Itemname.Value = itemname;
            XmlAttribute Uomname = doc.CreateAttribute("uomname");
            Uomname.Value = uomname;
            

            node.Attributes.Append(Itemname);
            node.Attributes.Append(Uomname);
            
            return node;
        }



        private void LoadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(xmlpath);
                XmlNode xlnd = doc.SelectSingleNode("BrnadItmOpen");
                xmlString = xlnd.InnerXml;
                xmlString = "<BrnadItmOpen>" + xmlString + "</BrnadItmOpen>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgv.DataSource = ds; } else { dgv.DataSource = ""; }
                dgv.DataBind();
            }
            catch { dgv.DataSource = ""; dgv.DataBind(); }
        }
        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadXml();
                DataSet dsGrid = (DataSet)dgv.DataSource;
                dsGrid.Tables[0].Rows[dgv.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(xmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgv.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(xmlpath); dgv.DataSource = ""; dgv.DataBind(); }
                else { LoadXml(); }
            }
            catch { }
        }
    }
}