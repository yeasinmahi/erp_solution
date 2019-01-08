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
        string filePathForXML; string xmlString = ""; HR_BLL.Penalty.Penalty pnlty = new HR_BLL.Penalty.Penalty();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                filePathForXML = Server.MapPath("~/HR/Penalty/Data/FD_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
                txtEmployeeSearch.Enabled = true;
                if (!IsPostBack)
                {
                    pnlUpperControl.DataBind(); try { File.Delete(filePathForXML); } catch { }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Initialize();", true);
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
                    else
                    {
                        ClearControls();
                    }
                }
            }
            catch { }
        }
        private void ClearControls()
        {

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
                txtEmployeeSearch.Enabled = false;
                txtEmployeeSearch.Text = objDT.Rows[0]["strEmployeeName"].ToString();
                hdnenroll.Value = objDT.Rows[0]["intEmployeeID"].ToString();
                txtDepartment.Text = objDT.Rows[0]["strDepatrment"].ToString();
                txtDesignation.Text = objDT.Rows[0]["strDesignation"].ToString();
                txtUnit.Text = objDT.Rows[0]["strUnit"].ToString();
                hdnsearch.Value = employeeCode;
                txtJobstation.Text = objDT.Rows[0]["strJobStationName"].ToString();
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry !!! Employee not found.');", true); }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string spouse = txtSpouse.Text; string childnm = txtChild.Text; string childgndr = ddlGender.SelectedItem.ToString();
                string childdob = txtDOB.Text; string empcode = hdnsearch.Value;
                if (childnm.Length <= 0) { childgndr = "Female"; childdob = DateTime.Now.ToString("yyyy-MM-dd"); }
                CreateFdayXml(spouse, childnm, childgndr, childdob, empcode);
            }
            catch { }
        }
        private void CreateFdayXml(string spouse, string childnm, string childgndr, string childdob, string empcode)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("FamilyDay");
                XmlNode addItem = CreateItemNode(doc, spouse, childnm, childgndr, childdob, empcode);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("FamilyDay");
                XmlNode addItem = CreateItemNode(doc, spouse, childnm, childgndr, childdob, empcode); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string spouse, string childnm, string childgndr, string childdob, string empcode)
        {
            XmlNode node = doc.CreateElement("items");
            XmlAttribute Spouse = doc.CreateAttribute("spouse");
            Spouse.Value = spouse;
            XmlAttribute Childnm = doc.CreateAttribute("childnm");
            Childnm.Value = childnm;
            XmlAttribute Childgndr = doc.CreateAttribute("childgndr");
            Childgndr.Value = childgndr;
            XmlAttribute Childdob = doc.CreateAttribute("childdob");
            Childdob.Value = childdob;
            XmlAttribute Empcode = doc.CreateAttribute("empcode");
            Empcode.Value = empcode;

            node.Attributes.Append(Spouse);
            node.Attributes.Append(Childnm);
            node.Attributes.Append(Childgndr);
            node.Attributes.Append(Childdob);
            node.Attributes.Append(Empcode);
            return node;
        }
        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("FamilyDay");
                xmlString = dSftTm.InnerXml;
                xmlString = "<FamilyDay>" + xmlString + "</FamilyDay>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0) { dgvfml.DataSource = ds; }
                else { dgvfml.DataSource = ""; }
                dgvfml.DataBind(); txtChild.Text = ""; txtDOB.Text = "";
            }
            catch { }
        }
        protected void dgvfml_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvfml.DataSource;
                dsGrid.Tables[0].Rows[dgvfml.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvfml.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXML); dgvfml.DataSource = ""; dgvfml.DataBind(); }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected void ddlGGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPtype.SelectedValue.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Initialize();", true);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    XmlDocument doc = new XmlDocument(); DataTable dt = new DataTable();
                    try
                    {
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("FamilyDay");
                        xmlString = dSftTm.InnerXml;
                        xmlString = "<FamilyDay>" + xmlString + "</FamilyDay>";
                    }
                    catch { xmlString = ""; }

                    dt = pnlty.Familydayinformation(0, hdnsearch.Value, int.Parse(ddlPnD.SelectedValue), ddlPtype.SelectedItem.ToString(),
                    int.Parse(Session[SessionParams.USER_ID].ToString()), xmlString);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["OutMessage"].ToString() + "');", true);
                    hdnconfirm.Value = "0"; File.Delete(filePathForXML); dgvfml.DataSource = ""; dgvfml.DataBind(); dgvList.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Initialize();", true);
                }
            }
            catch { }
        }
    }
}