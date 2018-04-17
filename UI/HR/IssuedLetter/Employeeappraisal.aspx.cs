using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.IssuedLetter
{
    public partial class Employeeappraisal : BasePage
    {
        public string strinformation = ""; DataTable dt; string xmlpath; string xmlString = ""; int actionby; int loginuser; protected int grdTotal;
        HR_BLL.IssuedLetter.EmployeeIssuedLetter objbll = new HR_BLL.IssuedLetter.EmployeeIssuedLetter();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnloginenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            xmlpath = Server.MapPath("~/HR/IssuedLetter/Data/APP_" + hdnloginenroll.Value + "_" +
            HttpContext.Current.Session[SessionParams.UNIT_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); grdTotal = 0; try { File.Delete(xmlpath);} catch { }
            }
            for (int index = 0; index < 11; index++)
            {                
                string point = ((RadioButtonList)dgvgrading.Rows[index].FindControl("rdograding")).SelectedValue.ToString();
                try { grdTotal += int.Parse(point); } catch { }
            }
            lblgrdTotal.Text = "Achivement point :" + " " + grdTotal.ToString();
        }
        protected void txtFullName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtFullName.Text))
                {
                    string strSearchKey = txtFullName.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ",");
                    hdnenroll.Value = searchKey[1];
                    Loadcontrols();
                }
                else { Clearcontrols(); }
            }
            catch { }
        }
        public void Loadcontrols()
        {
            dt = new DataTable(); dt = objbll.GetIndividualInformation(hdnenroll.Value);
            hdnsearch.Value = dt.Rows[0]["intEmployeeID"].ToString();
            strinformation = @"<table style='width:100%;'>
                <tr><td colspan='4' style='text-align:center; background-color:#d1fbf7; font:14px bold verdana;'> <u>Individual Progress Report, " + DateTime.Now.ToString("yyyy") + @"</u><br />(Confidential) </td></tr>
                <tr class='tblheader'><td colspan='4'> Personal Information </td></tr>
                <tr class='tblrowodd'><td class='lblp'>Employee Name :</td><td colspan='3'>" + dt.Rows[0]["strEmployeeName"].ToString() + @"</td></tr>
                <tr class='tblroweven'><td class='lblp'>ID No. :</td><td>" + dt.Rows[0]["strEmployeeCode"].ToString() + @"</td>
                <td class='lblp'>JoinDate :</td><td>" + DateTime.Parse(dt.Rows[0]["dteJoiningDate"].ToString()).ToString("yyyy-MM-dd") + @"</td></tr>
                <tr class='tblrowodd'><td class='lblp'>Sex :</td><td>" + dt.Rows[0]["strGender"].ToString() + @"</td>
                <td class='lblp'>Unit Name :</td><td>" + dt.Rows[0]["strUnit"].ToString() + @"</td></tr>
                <tr class='tblroweven'><td class='lblp'>Department :</td><td>" + dt.Rows[0]["strDepatrment"].ToString() + @"</td>
                <td class='lblp'>Designation :</td><td>" + dt.Rows[0]["strDesignation"].ToString() + @"</td></tr>
                <tr class='tblrowodd'><td class='lblp'>Job Nature :</td><td>" + dt.Rows[0]["strJobTypeShort"].ToString() + @"</td>
                <td class='lblp'>ContactNo. :</td><td>" + Session[SessionParams.PHONE].ToString() + @"</td></tr>
                </table>"; pnlpersonalinformation.DataBind();
            dt = new DataTable(); dt = objbll.GetPreviousRecord(int.Parse(hdnsearch.Value), 0);

            lblprerecord.Text = "Last year Increment(%): " + dt.Rows[0]["LYPercentage"].ToString() + " _ " +
                                "Last year Increment(tk): " + dt.Rows[0]["LYTaka"].ToString() + " _ " +
                                "Last year Increment(Gross): " + dt.Rows[0]["LYGross"].ToString();
             lblrcd.Text = "Current Gross: " + dt.Rows[0]["CYGross"].ToString() + " _ " +
                           "Current Basic: " + dt.Rows[0]["CYBasic"].ToString();
        }
        public void Clearcontrols()
        {
            strinformation = ""; dgvgrading.DataBind(); grdTotal = 0; lblgrdTotal.Text = "Achivement point :" + " " + grdTotal.ToString();
            txtIncPer.Text = ""; txtIncTk.Text = ""; txtProGross.Text = ""; txtProProm.Text = ""; txtComments.Text = ""; txtFullName.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                actionby = int.Parse(hdnsearch.Value);
                for (int index = 0; index < 11; index++)
                {
                    string grdid = ((HiddenField)dgvgrading.Rows[index].FindControl("hdngrade")).Value.ToString();
                    string point = ((RadioButtonList)dgvgrading.Rows[index].FindControl("rdograding")).SelectedValue.ToString();
                    CreateXml(hdnsearch.Value, grdid, point);
                }
                XmlDocument doc = new XmlDocument(); XmlNode xmls; string msg = ""; double inctk = 0.00; int incp = 0; double gross = 0.00; 
                loginuser = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                if (File.Exists(xmlpath))
                {           
                    doc.Load(xmlpath);
                    xmls = doc.SelectSingleNode("Grading");
                    xmlString = xmls.InnerXml;
                    xmlString = "<Grading>" + xmlString + "</Grading>";
                    string ovrallgrd = rdolbl.SelectedValue.ToString();
                    if (txtIncPer.Text.Length > 0) { incp = int.Parse(txtIncPer.Text); }
                    if (txtIncTk.Text.Length > 0) { inctk = double.Parse(txtIncTk.Text); }
                    if (txtProGross.Text.Length > 0) { gross = double.Parse(txtProGross.Text); } 
                    string promotion = txtProProm.Text; string remarks = txtComments.Text;
                    msg = objbll.UpdateEmployeeProgress(actionby, loginuser, xmlString, ovrallgrd, incp, inctk, gross, promotion, remarks);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                    File.Delete(xmlpath); Clearcontrols();
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        private void CreateXml(string enroll, string gradeid, string point)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Grading");
                XmlNode addItem = CreateNode(doc, enroll, gradeid, point);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Education");
                XmlNode addItem = CreateNode(doc, enroll, gradeid, point);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }
        private XmlNode CreateNode(XmlDocument doc, string enroll, string gradeid, string point)
        {
            XmlNode node = doc.CreateElement("grade");
            XmlAttribute Enroll = doc.CreateAttribute("enroll");
            Enroll.Value = enroll;
            XmlAttribute Gradeid = doc.CreateAttribute("gradeid");
            Gradeid.Value = gradeid;
            XmlAttribute Point = doc.CreateAttribute("point");
            Point.Value = point;

            node.Attributes.Append(Enroll);
            node.Attributes.Append(Gradeid);
            node.Attributes.Append(Point);
            return node;
        }

        
    }
}