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

namespace UI.HR.IssuedLetter
{
    public partial class Experienceupdate : BasePage
    {
        public string strinformation = ""; DataTable dt; string eduxmlpath; string traxmlpath; string expxmlpath; string eduxmlString = ""; 
        string traxmlString = ""; string expxmlString = ""; HR_BLL.IssuedLetter.EmployeeIssuedLetter objbll = new HR_BLL.IssuedLetter.EmployeeIssuedLetter();
        protected void Page_Load(object sender, EventArgs e)
        {
            eduxmlpath = Server.MapPath("~/HR/IssuedLetter/Data/EDU_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" +
            HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + ".xml");
            traxmlpath = Server.MapPath("~/HR/IssuedLetter/Data/TRA_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" +
            HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + ".xml");
            expxmlpath = Server.MapPath("~/HR/IssuedLetter/Data/EXP_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + "_" +
            HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + ".xml");
            if(!IsPostBack)
            {
                dt = new DataTable(); dt = objbll.GetIndividualInformation(int.Parse(Session[SessionParams.USER_ID].ToString()));               
                pnlUpperControl.DataBind(); 
                strinformation = @"<table style='width:100%;'>
                <tr><td colspan='4' style='text-align:center;background-color:#d1fbf7; font:14px bold verdana;'> <u>Individual Progress Report, " + DateTime.Now.ToString("yyyy") + @"</u><br />(Confidential) </td></tr>
                <tr class='tblheader'><td colspan='4'> Personal Information </td></tr>
                <tr class='tblrowodd'><td class='lblp'>Employee Name :</td><td colspan='3'>" + dt.Rows[0]["strEmployeeName"].ToString() + @"</td></tr>
                <tr class='tblroweven'><td class='lblp'>ID No. :</td><td>" + dt.Rows[0]["strEmployeeCode"].ToString() + @"</td>
                <td class='lblp'>JoinDate :</td><td>" + DateTime.Parse(dt.Rows[0]["dteJoiningDate"].ToString()).ToString("yyyy-MM-dd") +@"</td></tr>
                <tr class='tblrowodd'><td class='lblp'>Sex :</td><td>" + dt.Rows[0]["strGender"].ToString() + @"</td>
                <td class='lblp'>Unit Name :</td><td>" + dt.Rows[0]["strUnit"].ToString() + @"</td></tr>
                <tr class='tblroweven'><td class='lblp'>Department :</td><td>" + dt.Rows[0]["strDepatrment"].ToString() + @"</td>
                <td class='lblp'>Designation :</td><td>" + dt.Rows[0]["strDesignation"].ToString() + @"</td></tr>
                <tr class='tblrowodd'><td class='lblp'>Job Nature :</td><td>" + dt.Rows[0]["strJobTypeShort"].ToString() + @"</td>
                <td class='lblp'>ContactNo. :</td><td>" + Session[SessionParams.PHONE].ToString() + @"</td></tr>
                </table>"; pnlpersonalinformation.DataBind(); txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
                txtTdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                try { File.Delete(eduxmlpath); File.Delete(traxmlpath); File.Delete(expxmlpath); }  catch { }
                Clearcontrols();
            }
        }

        #region =================== Education Add ==================
        protected void btnEAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string inst =txtInstitute.Text;
                string degree =txtDegree.Text;
                string major =txtMajor.Text;
                string passingyear =txtPassingYear.Text;
                CreateEduXml(inst, degree, major, passingyear);
                Clearcontrols();
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void CreateEduXml(string inst, string degree, string major, string passingyear)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(eduxmlpath))
            {
                doc.Load(eduxmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Education");
                XmlNode addItem = CreateEduNode(doc, inst, degree, major, passingyear);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Education");
                XmlNode addItem = CreateEduNode(doc, inst, degree, major, passingyear);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(eduxmlpath); EduXml(); 
        }
        private XmlNode CreateEduNode(XmlDocument doc, string inst, string degree, string major, string passingyear)
        {
            XmlNode node = doc.CreateElement("edu");
            XmlAttribute Inst = doc.CreateAttribute("inst");
            Inst.Value = inst;
            XmlAttribute Degree = doc.CreateAttribute("degree");
            Degree.Value = degree;
            XmlAttribute Major = doc.CreateAttribute("major");
            Major.Value = major;
            XmlAttribute Passingyear = doc.CreateAttribute("passingyear");
            Passingyear.Value = passingyear;

            node.Attributes.Append(Inst);
            node.Attributes.Append(Degree);
            node.Attributes.Append(Major);
            node.Attributes.Append(Passingyear);
            return node;
        }
        private void EduXml()
        {
            XmlDocument doc = new XmlDocument(); doc.Load(eduxmlpath);
            XmlNode dsedu = doc.SelectSingleNode("Education");
            eduxmlString = dsedu.InnerXml;
            eduxmlString = "<Education>" + eduxmlString + "</Education>";
            StringReader sr = new StringReader(eduxmlString);
            DataSet ds = new DataSet(); ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvedu.DataSource = ds; } else { dgvedu.DataSource = ""; } dgvedu.DataBind();
        }
        protected void dgvedu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EduXml();
                DataSet dsGrid = (DataSet)dgvedu.DataSource;
                dsGrid.Tables[0].Rows[dgvedu.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(eduxmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvedu.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(eduxmlpath); dgvedu.DataSource = ""; dgvedu.DataBind(); }
                else { EduXml(); }
            }
            catch { }
        }

        #endregion =================== Education Add ==================

        #region =================== Traning Add ==================
        protected void btnTAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string tinst = txtTrining.Text;
                string course = txtCourse.Text;
                string duration = txtDuration.Text;
                CreateTraXml(tinst, course, duration);
                Clearcontrols();
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void CreateTraXml(string tinst, string course, string duration)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(traxmlpath))
            {
                doc.Load(traxmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Traning");
                XmlNode addItem = CreateTraNode(doc, tinst, course, duration);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Traning");
                XmlNode addItem = CreateTraNode(doc, tinst, course, duration);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(traxmlpath); TraXml();
        }
        private XmlNode CreateTraNode(XmlDocument doc, string tinst, string course, string duration)
        {
            XmlNode node = doc.CreateElement("tra");
            XmlAttribute Tinst = doc.CreateAttribute("tinst");
            Tinst.Value = tinst;
            XmlAttribute Course = doc.CreateAttribute("course");
            Course.Value = course;
            XmlAttribute Duration = doc.CreateAttribute("duration");
            Duration.Value = duration;

            node.Attributes.Append(Tinst);
            node.Attributes.Append(Course);
            node.Attributes.Append(Duration);
            return node;
        }
        private void TraXml()
        {
            XmlDocument doc = new XmlDocument(); doc.Load(traxmlpath);
            XmlNode dstra = doc.SelectSingleNode("Traning");
            traxmlString = dstra.InnerXml;
            traxmlString = "<Traning>" + traxmlString + "</Traning>";
            StringReader sr = new StringReader(traxmlString);
            DataSet ds = new DataSet(); ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvtra.DataSource = ds; } else { dgvtra.DataSource = ""; } dgvtra.DataBind();
        }
        protected void dgvtra_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                TraXml();
                DataSet dsGrid = (DataSet)dgvtra.DataSource;
                dsGrid.Tables[0].Rows[dgvtra.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(traxmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvtra.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(traxmlpath); dgvtra.DataSource = ""; dgvtra.DataBind(); }
                else { TraXml(); }
            }
            catch { }
        }
        #endregion =================== Traning Add ==================

        #region =================== Experience Add ==================
        protected void btnExAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string exinst = txtCompany.Text;
                string dpt = txtDept.Text;
                string dsg = txtDesg.Text;
                string frm = txtFdate.Text;
                string to = txtTdate.Text;
                string ttl = txtTotal.Text;
                CreateExXml(exinst, dpt, dsg, frm, to, ttl);
                Clearcontrols();
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        
        }
        private void CreateExXml(string exinst, string dpt, string dsg, string frm, string to, string ttl)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(expxmlpath))
            {
                doc.Load(expxmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Experience");
                XmlNode addItem = CreateExpNode(doc, exinst, dpt, dsg, frm, to, ttl);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Experience");
                XmlNode addItem = CreateExpNode(doc, exinst, dpt, dsg, frm, to, ttl);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(expxmlpath); ExpXml();
        }
        private XmlNode CreateExpNode(XmlDocument doc, string exinst, string dpt, string dsg, string frm, string to, string ttl)
        {
            XmlNode node = doc.CreateElement("exp");
            XmlAttribute ExInst = doc.CreateAttribute("exinst");
            ExInst.Value = exinst;
            XmlAttribute Dpt = doc.CreateAttribute("dpt");
            Dpt.Value = dpt;
            XmlAttribute Dsg = doc.CreateAttribute("dsg");
            Dsg.Value = dsg;
            XmlAttribute Frm = doc.CreateAttribute("frm");
            Frm.Value = frm;
            XmlAttribute To = doc.CreateAttribute("to");
            To.Value = to;
            XmlAttribute Ttl = doc.CreateAttribute("ttl");
            Ttl.Value = ttl;

            node.Attributes.Append(ExInst);
            node.Attributes.Append(Dpt);
            node.Attributes.Append(Dsg);
            node.Attributes.Append(Frm);
            node.Attributes.Append(To);
            node.Attributes.Append(Ttl);
            return node;
        }
        private void ExpXml()
        {
            XmlDocument doc = new XmlDocument(); doc.Load(expxmlpath);
            XmlNode dsexp = doc.SelectSingleNode("Experience");
            expxmlString = dsexp.InnerXml;
            expxmlString = "<Experience>" + expxmlString + "</Experience>";
            StringReader sr = new StringReader(expxmlString);
            DataSet ds = new DataSet(); ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvexp.DataSource = ds; } else { dgvexp.DataSource = ""; } dgvexp.DataBind();
        }
        protected void dgvexp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ExpXml();
                DataSet dsGrid = (DataSet)dgvexp.DataSource;
                dsGrid.Tables[0].Rows[dgvexp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(expxmlpath);
                DataSet dsGridAfterDelete = (DataSet)dgvexp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0) { File.Delete(expxmlpath); dgvexp.DataSource = ""; dgvexp.DataBind(); }
                else { ExpXml(); }
            }
            catch { }
        }

        #endregion =================== Experience Add ==================
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument(); XmlNode xmls; string msg = ""; int actionby; int loginuser;
            actionby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            loginuser = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            try
            {
                if ((File.Exists(eduxmlpath)) || (File.Exists(traxmlpath)) || (File.Exists(expxmlpath)))
                {
                    //----------- get Education xmlstring ----------------                
                    doc.Load(eduxmlpath);
                    xmls = doc.SelectSingleNode("Education");
                    eduxmlString = xmls.InnerXml;
                    eduxmlString = "<Education>" + eduxmlString + "</Education>";
                    //----------- get Training xmlstring ----------------                
                    doc.Load(traxmlpath);
                    xmls = doc.SelectSingleNode("Traning");
                    traxmlString = xmls.InnerXml;
                    traxmlString = "<Traning>" + traxmlString + "</Traning>";
                    //----------- get Experience xmlstring ----------------                
                    doc.Load(expxmlpath);
                    xmls = doc.SelectSingleNode("Experience");
                    expxmlString = xmls.InnerXml;
                    expxmlString = "<Experience>" + expxmlString + "</Experience>";
                    msg = objbll.InsertEmployeeProgress(actionby, loginuser, eduxmlString, traxmlString, expxmlString);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    File.Delete(eduxmlpath); File.Delete(traxmlpath); File.Delete(expxmlpath);
                    dgvedu.DataSource = ""; dgvedu.DataBind(); dgvtra.DataSource = ""; dgvtra.DataBind();
                    dgvexp.DataSource = ""; dgvexp.DataBind(); Clearcontrols();
                }
                else
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please add somthing.');", true); }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + ";  " + msg + "');", true); }
        }
        public void Clearcontrols()
        {
            txtInstitute.Text = ""; txtDegree.Text = ""; txtMajor.Text = ""; txtPassingYear.Text = ""; txtTrining.Text = ""; 
            txtCourse.Text = ""; txtDuration.Text = ""; txtCompany.Text = ""; txtDept.Text = ""; txtDesg.Text = ""; 
            txtFdate.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtTdate.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
            txtTotal.Text = "";
        }


    }
}