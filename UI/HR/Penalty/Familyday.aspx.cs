using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.Penalty
{
    public partial class Familyday : BasePage
    {
        string filePathForXML; string xmlString = ""; HR_BLL.Penalty.Penalty pnlty = new HR_BLL.Penalty.Penalty();DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                filePathForXML = Server.MapPath("~/HR/Penalty/Data/FD_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind(); BindPickandDrop();                    
                    txtEmployeeSearch.Text = HttpContext.Current.Session[SessionParams.USER_NAME].ToString();
                    txtDepartment.Text = HttpContext.Current.Session[SessionParams.DEPT_NAME].ToString();
                    txtDesignation.Text = HttpContext.Current.Session[SessionParams.DESIG_NAME].ToString();
                    txtUnit.Text = HttpContext.Current.Session[SessionParams.UNIT_NAME].ToString();
                    hdncode.Value = HttpContext.Current.Session[SessionParams.USER_CODE].ToString();
                    txtJobtype.Text = HttpContext.Current.Session[SessionParams.JOBTYPE_NAME].ToString();
                    txtJobstation.Text = HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString();
                }
            }
            catch { }
        }
        private void BindPickandDrop()
        {
            try {
                dt = new DataTable(); try { File.Delete(filePathForXML); } catch { }
                dt = pnlty.GetPickDropList();
                ddlPnD.DataSource = dt; ddlPnD.DataTextField = "Names";
                ddlPnD.DataValueField = "ID"; ddlPnD.DataBind();
                ddlPnD.Items.Insert(0, new ListItem("Select Point", "0"));
                ddlPtype.SelectedValue = "0"; txtSpouse.Text = ""; ddlSGender.SelectedValue = "M"; txtSDOB.Text = "";
                txtSpouse.Enabled = false; ddlSGender.Enabled = false; txtSDOB.Enabled = false;
                ddlChild.SelectedValue="0"; txtChild.Text = ""; ddlCGender.SelectedValue = "M"; txtCDOB.Text = "";
                txtChild.Enabled = false; ddlCGender.Enabled = false; txtCDOB.Enabled = false; btnAdd.Enabled = false;
                hdnconfirm.Value = "0"; dgvfml.DataSource = ""; dgvfml.DataBind(); dgvList.DataBind();
            }
            catch { }
        }
        protected void ddlPtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlPtype.SelectedValue.ToString()=="0"){ txtSpouse.Enabled = false; ddlSGender.Enabled = false; txtSDOB.Enabled = false; }
            else { txtSpouse.Enabled = true; ddlSGender.Enabled = true; txtSDOB.Enabled = true; }
        }
        protected void ddlChild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChild.SelectedValue.ToString() == "0") { txtChild.Enabled = false; ddlCGender.Enabled = false; txtCDOB.Enabled = false; btnAdd.Enabled = false; }
            else { txtChild.Enabled = true; ddlCGender.Enabled = true; txtCDOB.Enabled = true; btnAdd.Enabled = true; }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    string childnm = txtChild.Text; string childgndr = ddlCGender.SelectedItem.ToString(); string childdob = txtCDOB.Text;
                    CreateXml(childnm, childgndr, childdob, "CHILD");
                    //if (childnm.Length <= 0 || childdob.Length <= 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please fillup child information properly.');", true); }
                    //else { CreateXml(childnm, childgndr, childdob, "CHILD"); }
                }
            }
            catch { }
        }
        private void CreateXml(string childnm, string childgndr, string childdob, string who)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("FamilyDay");
                XmlNode addItem = CreateItemNode(doc, childnm, childgndr, childdob, who);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FamilyDay");
                XmlNode addItem = CreateItemNode(doc, childnm, childgndr, childdob, who); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string childnm, string childgndr, string childdob, string who)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Childnm = doc.CreateAttribute("childnm");
            Childnm.Value = childnm;
            XmlAttribute Childgndr = doc.CreateAttribute("childgndr");
            Childgndr.Value = childgndr;
            XmlAttribute Childdob = doc.CreateAttribute("childdob");
            Childdob.Value = childdob;
            XmlAttribute Who = doc.CreateAttribute("who");
            Who.Value = who;

            node.Attributes.Append(Childnm);
            node.Attributes.Append(Childgndr);
            node.Attributes.Append(Childdob);
            node.Attributes.Append(Who);
            return node;
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument(); doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("FamilyDay");
                xmlString = dSftTm.InnerXml;
                xmlString = "<FamilyDay>" + xmlString + "</FamilyDay>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet(); ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvfml.DataSource = ds; }
                else { dgvfml.DataSource = ""; }
                dgvfml.DataBind(); txtChild.Text = ""; txtCDOB.Text = "";
            }
            catch { }
        }
        protected void dgvfml_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();DataSet dsGrid = (DataSet)dgvfml.DataSource;
                dsGrid.Tables[0].Rows[dgvfml.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvfml.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0){ File.Delete(filePathForXML); dgvfml.DataSource = ""; dgvfml.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    XmlDocument doc = new XmlDocument(); dt = new DataTable(); int actionby = int.Parse(Session[SessionParams.USER_ID].ToString());
                    string pnd = ddlPnD.SelectedValue.ToString(); string ptype = ddlPtype.SelectedItem.ToString();
                    string sname = txtSpouse.Text; string sgndr = ddlSGender.SelectedItem.ToString(); string sdob = txtSDOB.Text;
                    try
                    { doc.Load(filePathForXML); XmlNode dSftTm = doc.SelectSingleNode("FamilyDay"); xmlString = dSftTm.InnerXml;
                      xmlString = "<FamilyDay>" + xmlString + "</FamilyDay>";}
                    catch { xmlString = ""; }
                    dt = pnlty.Familydayinformation(0, hdncode.Value, int.Parse(pnd), ptype, sname, sgndr, sdob, actionby, xmlString);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["OutMessage"].ToString() + "');", true);
                    BindPickandDrop();
                }
            }
            catch { }
        }


    }
}