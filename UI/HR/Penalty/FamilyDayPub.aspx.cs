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
    public partial class FamilyDayPub : BasePage
    {
        string filePathForXML; string xmlString = ""; HR_BLL.Penalty.Penalty pnlty = new HR_BLL.Penalty.Penalty(); DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                filePathForXML = Server.MapPath("~/HR/Penalty/Data/FD_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind(); BindPickandDrop();
                    txtEmployeeSearch.Attributes.Add("onkeyUp", "SearchText();");
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtEmployeeSearch.Text))
                    {
                        string strSearchKey = txtEmployeeSearch.Text;
                        string[] searchKey = Regex.Split(strSearchKey, ",");
                        hdnsearch.Value = searchKey[1];
                        FillControls(searchKey[1]);
                    }
                }
            }
            catch { }
        }
        private void BindPickandDrop()
        {
            try
            {
                dt = new DataTable(); try { File.Delete(filePathForXML); } catch { }
                dt = pnlty.GetPickDropList();
                ddlPnD.DataSource = dt; ddlPnD.DataTextField = "Names";
                ddlPnD.DataValueField = "ID"; ddlPnD.DataBind();
                ddlPnD.Items.Insert(0, new ListItem("Select Point", "0"));
                ddlPtype.SelectedValue = "0"; txtSpouse.Text = ""; ddlSGender.SelectedValue = "M"; txtSDOB.Text = "";
                txtSpouse.Enabled = false; ddlSGender.Enabled = false; txtSDOB.Enabled = false;
                ddlChild.SelectedValue = "0"; txtChild.Text = ""; ddlCGender.SelectedValue = "S"; txtCDOB.Text = "";
                txtChild.Enabled = false; ddlCGender.Enabled = false; txtCDOB.Enabled = false; btnAdd.Enabled = false;
                hdnconfirm.Value = "0"; hdnsearch.Value = ""; txtJobstation.Text = ""; txtEmployeeSearch.Text = ""; txtDepartment.Text = ""; hdnsdob.Value = "";
                txtDesignation.Text = ""; txtJobtype.Text = ""; txtUnit.Text = ""; hdncdob.Value = "";
            }
            catch { }
        }
        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {
            AutoSearch_BLL objAutoSearch_BLL = new AutoSearch_BLL();
            List<string> result = new List<string>();
            result = objAutoSearch_BLL.AutoSearchEmployeesData(int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString())
            , int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString()), strSearchKey);
            return result;
        }
        private void FillControls(string employeeCode)
        {
            HR_BLL.Employee.EmployeeRegistration basicinfo = new HR_BLL.Employee.EmployeeRegistration();
            DataTable objDT = basicinfo.GetEmployeeProfileByEmpCode(employeeCode);
            if (objDT.Rows.Count > 0)
            {
                txtEmployeeSearch.Text = objDT.Rows[0]["strEmployeeName"].ToString();
                txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                txtJobtype.Text = objDT.Rows[0]["strJobType"].ToString();
                txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                hdnsearch.Value = employeeCode; hdncode.Value = employeeCode;
                txtJobstation.Text = objDT.Rows[0]["strJobStationName"].ToString();
                dgvList.DataBind();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry !!! Employee not found.');", true); }

        }
        protected void ddlPtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPtype.SelectedValue.ToString() == "0") { txtSpouse.Enabled = false; ddlSGender.Enabled = false; txtSDOB.Enabled = false; }
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
                    string childnm = txtChild.Text; string childgndr = ddlCGender.SelectedItem.ToString(); string childdob = hdncdob.Value;
                    CreateXml(childnm, childgndr, childdob, "CHILD");
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
            catch { dgvfml.DataSource = ""; dgvfml.DataBind();}
        }
        protected void dgvfml_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml(); DataSet dsGrid = (DataSet)dgvfml.DataSource;
                dsGrid.Tables[0].Rows[dgvfml.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvfml.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(filePathForXML); dgvfml.DataSource = ""; dgvfml.DataBind(); }
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
                    string sname = txtSpouse.Text; string sgndr = ddlSGender.SelectedItem.ToString(); string sdob = hdnsdob.Value;
                    try
                    {
                        doc.Load(filePathForXML); XmlNode dSftTm = doc.SelectSingleNode("FamilyDay"); xmlString = dSftTm.InnerXml;
                        xmlString = "<FamilyDay>" + xmlString + "</FamilyDay>";
                    }
                    catch { xmlString = ""; }
                    dt = pnlty.Familydayinformation(0, hdncode.Value, int.Parse(pnd), ptype, sname, sgndr, sdob, actionby, xmlString);
                    try { File.Delete(filePathForXML); } catch { } LoadGridwithXml(); 
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["OutMessage"].ToString() + "');", true);
                    BindPickandDrop();
                }
            }
            catch { }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    char[] delimiterChars = { '^' }; dt = new DataTable();
                    string temp = ((Button)sender).CommandArgument.ToString();
                    string[] searchKey = temp.Split(delimiterChars);
                    int mid = int.Parse(searchKey[0].ToString());
                    int did = int.Parse(searchKey[1].ToString());
                    dt = pnlty.Familydayinformation(3, hdncode.Value, mid, "", "", "", "", did, "");
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["OutMessage"].ToString() + "');", true);
                    dgvList.DataBind();
                }
                catch { }
            }
        }
    }
}