using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using UI.ClassFiles;
using SAD_BLL.Transport;
using Projects_BLL;
namespace UI.Projects.Local
{
    public partial class ExecutionPlan : BasePage
    {
        Project_Class objproject = new Project_Class();

        string filePathForXML, xmlString = "", xml, activity, activityid, amount, strLocation;
        int intPart, intUnitid, intDeptid, intEventid, intTypeid, intLocationid, intBrandid, intActionBy;
        DateTime dtePlan, dtePlanF, dtePlanT;
        Decimal numAdvAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/Projects/Data/ExecutionActivity_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML); dgvActivity.DataSource = ""; dgvActivity.DataBind();
                    txtDateF.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
                    txtDateT.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    if (ddlType.SelectedValue.ToString() == "2") { ddlBrand.Enabled = true; }
                    else { ddlBrand.Enabled = false; }
                    btnSubmit.Visible = false; txtAdvAmount.Enabled = false;
                }
                catch { }
            }

        }

        #region =============== Start Activity Add Option ==============================
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            activity = ddlActivity.SelectedItem.ToString();
            activityid = ddlActivity.SelectedValue.ToString();
            amount = txtAmount.Text;
            if (amount != "" && amount != "0" && activityid != "")
            { CreateXml(activityid, activity, amount); txtAmount.Text = ""; btnSubmit.Visible = true; }
        }
        private void CreateXml(string activityid, string activity, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Activity");
                XmlNode addItem = CreateItemNode(doc, activityid, activity, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Activity");
                XmlNode addItem = CreateItemNode(doc, activityid, activity, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("Activity");
            xmlString = dSftTm.InnerXml;
            xmlString = "<Activity>" + xmlString + "</Activity>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvActivity.DataSource = ds; }
            else { dgvActivity.DataSource = ""; } dgvActivity.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string activityid, string activity, string amount)
        {
            XmlNode node = doc.CreateElement("Activity");

            XmlAttribute Activityid = doc.CreateAttribute("activityid"); Activityid.Value = activityid;
            XmlAttribute Activity = doc.CreateAttribute("activity"); Activity.Value = activity;
            XmlAttribute Amount = doc.CreateAttribute("amount"); Amount.Value = amount;

            node.Attributes.Append(Activityid);
            node.Attributes.Append(Activity);
            node.Attributes.Append(Amount);
            return node;
        }
        protected void dgvActivity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Activity");
                xmlString = dSftTm.InnerXml;
                xmlString = "<Activity>" + xmlString + "</Activity>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvActivity.DataSource = ds;
                DataSet dsGrid = (DataSet)dgvActivity.DataSource;
                dsGrid.Tables[0].Rows[dgvActivity.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvActivity.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvActivity.DataSource = ""; dgvActivity.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }

        }
        #endregion =============== End Activity Add Option =============================

        #region  =============== Start Activity Gridview Value Total ====================
        protected decimal totalactivity = 0;
        protected void dgvActivity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                { totalactivity += decimal.Parse(((Label)e.Row.Cells[1].FindControl("lblAmount")).Text); }
            }
            catch { }
        }
        #endregion =============== End Activity Gridview Value Total =============================

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue.ToString() == "2") { ddlBrand.Enabled = true; }
            else { ddlBrand.Enabled = false; }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 2;
                intUnitid = int.Parse(hdnUnit.Value);
                intDeptid = int.Parse(ddlDept.SelectedValue.ToString());
                intEventid = int.Parse(ddlEvent.SelectedValue.ToString());
                intTypeid = int.Parse(ddlType.SelectedValue.ToString());
                intLocationid = 0;
                strLocation = txtLocation.Text;
                if (ddlType.SelectedValue.ToString() == "2") { intBrandid = int.Parse(ddlBrand.SelectedValue.ToString()); }
                else { intBrandid = 0; }
                dtePlan = DateTime.Parse(txtDateF.Text); 
                intActionBy = int.Parse(hdnEnroll.Value); 
                dtePlanF = DateTime.Parse(txtDateF.Text);
                dtePlanT = DateTime.Parse(txtDateT.Text);
                if (cbAdvAmount.Checked == true) 
                { 
                    numAdvAmount = decimal.Parse(txtAdvAmount.Text);
                    if (numAdvAmount == 0) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Advance Amount Input.');", true); return; }
                }
                else { numAdvAmount = 0; }                

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("Activity");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<Activity>" + xmlString + "</Activity>";
                    xml = xmlString;
                }
                catch { }
                if (xml == "") { return; }

                string message = objproject.InsertEntry(intPart, intUnitid, intDeptid, intEventid, intTypeid, intLocationid, strLocation, intBrandid, dtePlan, intActionBy, xml, dtePlanF, dtePlanT, numAdvAmount);

                if (filePathForXML != null)
                { File.Delete(filePathForXML); } dgvActivity.DataSource = ""; dgvActivity.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);

            }
        }

        protected void cbAdvAmount_CheckedChanged(object sender, EventArgs e)
        { 
            if(cbAdvAmount.Checked == true) { txtAdvAmount.Enabled = true;} 
            else { txtAdvAmount.Enabled = false;}
        }













    }
}