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
    public partial class ExecutionApproveBySupervisor : BasePage
    {
        Project_Class rptproject = new Project_Class(); DataTable dt;

        string filePathForXML, xmlString = "", xml, projectid, activityid, amount, strLocation;
        int intPart, intUnitid, intDept;
        int intDeptid, intEventid, intTypeid, intLocationid, intBrandid, intActionBy;
        DateTime dtePlan, dtePlanF, dtePlanT;
        decimal numAdvAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXML = Server.MapPath("~/Projects/Data/ExecutionAppBySup_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                File.Delete(filePathForXML);
            }
            else { if (hdnconfirm.Value == "3") { dgvAnnual.Visible = true; }}
        }
        protected void btnShow_Click(object sender, EventArgs e) { LoadGrid(); }
        private void LoadGrid()
        {
            try
            {
                intPart = 1;
                intUnitid = int.Parse(ddlUnit.SelectedValue.ToString());
                intDept = int.Parse(ddlDept.SelectedValue.ToString());

                dt = new DataTable();
                dt = rptproject.GetReportForApprove(intPart, intUnitid, intDept);
                dgvAnnual.DataSource = dt;
                dgvAnnual.DataBind();
            }
            catch { }
        }
        private void GridviewBlank() { dgvAnnual.DataSource = ""; dgvAnnual.DataBind(); }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e) { GridviewBlank(); }
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e) { GridviewBlank(); }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            hdnProjectID.Value = senderdata;

            try
            {
                intPart = 3;
                intUnitid = int.Parse(senderdata.ToString());
                intDept = 0;

                dt = new DataTable();
                dt = rptproject.GetReportForApprove(intPart, intUnitid, intDept);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);
                    dgvExecutionEdit.DataSource = dt;
                    dgvExecutionEdit.DataBind();

                    dt = new DataTable();
                    dt = rptproject.GetAdvAmount(int.Parse(hdnProjectID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtAdvance.Text = dt.Rows[0]["numAppAdvAmount"].ToString();
                        txtDateF.Text = dt.Rows[0]["dteStart"].ToString();
                        txtDateT.Text = dt.Rows[0]["dteEnd"].ToString(); 
                    }
                    dgvAnnual.Visible = false;
                }
            }
            catch { }
        }
        protected decimal totalamo = 0;
        protected void dgvExecutionEdit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalamo += decimal.Parse(((TextBox)e.Row.Cells[1].FindControl("txtRAmount")).Text);
                }
            }
            catch { }
        }

        #region =============== Execution Plan Approve ==============================
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (dgvExecutionEdit.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvExecutionEdit.Rows.Count; index++)
                    {
                        projectid = ((Label)dgvExecutionEdit.Rows[index].FindControl("lblProjectID")).Text.ToString();
                        activityid = ((Label)dgvExecutionEdit.Rows[index].FindControl("lblActivitryid")).Text.ToString();
                        amount = ((TextBox)dgvExecutionEdit.Rows[index].FindControl("txtRAmount")).Text.ToString();

                        CreateXml(projectid, activityid, amount);
                    }
                }
                else { return; }
                intPart = 3;
                intUnitid = 0;
                intDeptid = 0;
                intEventid = 0;
                intTypeid = 0;
                intLocationid = 0;
                strLocation = "";
                intBrandid = 0;
                dtePlan = DateTime.Parse(txtDateF.Text);
                intActionBy = int.Parse(hdnEnroll.Value);
                dtePlanF = DateTime.Parse(txtDateF.Text);
                dtePlanT = DateTime.Parse(txtDateT.Text);
                numAdvAmount = decimal.Parse(txtAdvance.Text);

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

                string message = rptproject.InsertEntry(intPart, intUnitid, intDeptid, intEventid, intTypeid, intLocationid, strLocation, intBrandid, dtePlan, intActionBy, xml, dtePlanF, dtePlanT, numAdvAmount);
                LoadGrid();
                if (filePathForXML != null)
                { File.Delete(filePathForXML); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ClosehdnDivision('" + 0 + "');", true);
            }
            dgvAnnual.Visible = true;
        }
        private void CreateXml(string projectid, string activityid, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Activity");
                XmlNode addItem = CreateItemNode(doc, projectid, activityid, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Activity");
                XmlNode addItem = CreateItemNode(doc, projectid, activityid, amount);
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
            //if (ds.Tables[0].Rows.Count > 0) { dgvActivity.DataSource = ds; }
            //else { dgvActivity.DataSource = ""; } dgvActivity.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string projectid, string activityid, string amount)
        {
            XmlNode node = doc.CreateElement("Activity");

            XmlAttribute Projectid = doc.CreateAttribute("projectid"); Projectid.Value = projectid;
            XmlAttribute Activityid = doc.CreateAttribute("activityid"); Activityid.Value = activityid;
            XmlAttribute Amount = doc.CreateAttribute("amount"); Amount.Value = amount;

            node.Attributes.Append(Projectid);
            node.Attributes.Append(Activityid);
            node.Attributes.Append(Amount);
            return node;
        }
        #endregion ===================================================================













    }
}