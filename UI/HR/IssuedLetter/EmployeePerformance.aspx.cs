using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.IssuedLetter
{
    public partial class EmployeePerformance : BasePage
    {
        HR_BLL.IssuedLetter.EmployeeIssuedLetter objbll = new HR_BLL.IssuedLetter.EmployeeIssuedLetter();string filePathForXML;
        DataTable dt = new DataTable(); DirectoryInfo dirInfo; string xmleducation; string xmltraining; string xmlachievement;
        string xmlgrading; string signfile; string filePath; 
        protected void Page_Load(object sender, EventArgs e)
        {
            dirInfo = new DirectoryInfo(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/"));
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnconfirm.Value = "0"; ClearControls();
                dt = objbll.GetIndividualInformation(int.Parse(Session[SessionParams.USER_ID].ToString()));
                txtCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                txtEnroll.Text = dt.Rows[0]["intEmployeeId"].ToString();
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtEmployee.Text = dt.Rows[0]["strEmployeeName"].ToString();
                txtJoindate.Text = DateTime.Parse(dt.Rows[0]["dteJoiningDate"].ToString()).ToString("yyyy-MM-dd");
                txtDepartment.Text = dt.Rows[0]["strDepatrment"].ToString();
                txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                txtJobtype.Text = dt.Rows[0]["strJobTypeShort"].ToString();
                txtSex.Text = dt.Rows[0]["strGender"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            }
        }

        private void ClearControls()
        {

            txtInstitute.Text = ""; txtDegree.Text = "";
            txtMajor.Text = ""; txtPassingYear.Text = "";
            txtTrining.Text = ""; txtCourse.Text = "";
            txtDuration.Text = "";

            txtBengali.Text = ""; txtEnglish.Text = "";
            txtOthers.Text = ""; txtRemarks.Text = "";
            txtTotalExpOthersCompany.Text = "";

            dtePeriodFrom.Text = ""; dtePeriodTo.Text = "";
            txtTask.Text = ""; txtAchivement.Text = "";
            txtAchive.Text = ""; dteLastupdate.Text = "";

            txtAchive.Text = ""; dteLastupdate.Text = "";
            dgvgrading.DataBind(); txtShortterm.Text = "";
            txtLongterm.Text = ""; txtComments.Text = "";
            txtPotential.Text = ""; txtSelfdevelopment.Text = "";
            txtChaTaskTarget.Text = "";
            File.Delete(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Grading.xml"));
            File.Delete(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml"));
            File.Delete(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml"));
            File.Delete(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml"));
            dgvedu.DataBind(); dgvtraining.DataBind(); dgvachive.DataBind(); dgvgrading.DataBind();
        }              

        #region --------------------- Gridview Loading -------------------
        private void LoadEducationXml()
        {
            string validExtensions = Session[SessionParams.USER_ID].ToString() + "Education.xml";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();
            foreach (string extension in extFilter)
            { files.AddRange(dirInfo.GetFiles(extension)); }
            if (files.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Education");
                xmleducation = dSftTm.InnerXml;
                xmleducation = "<Education>" + xmleducation + "</Education>";
                StringReader sr = new StringReader(xmleducation);
                DataSet ds = new DataSet();
                ds.ReadXml(sr); dgvedu.DataSource = ds; dgvedu.DataBind();
            }
            else { dgvedu.DataSource = ""; dgvedu.DataBind(); }
        }
        private void LoadTrainingXml()
        {
            string validExtensions = Session[SessionParams.USER_ID].ToString() + "Training.xml";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();
            foreach (string extension in extFilter)
            { files.AddRange(dirInfo.GetFiles(extension)); }
            if (files.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Training");
                xmltraining = dSftTm.InnerXml;
                xmltraining = "<Training>" + xmltraining + "</Training>";
                StringReader sr = new StringReader(xmltraining);
                DataSet ds = new DataSet();
                ds.ReadXml(sr); dgvtraining.DataSource = ds; dgvtraining.DataBind();
            }
            else { dgvtraining.DataSource = ""; dgvtraining.DataBind(); }
        }
        private void LoadAchieveXml()
        {
            string validExtensions = Session[SessionParams.USER_ID].ToString() + "Achieve.xml";
            string[] extFilter = validExtensions.Split(new char[] { ',' });
            ArrayList files = new ArrayList();
            foreach (string extension in extFilter)
            { files.AddRange(dirInfo.GetFiles(extension)); }
            if (files.Count > 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("Achieve");
                xmlachievement = dSftTm.InnerXml;
                xmlachievement = "<Achieve>" + xmlachievement + "</Achieve>";
                StringReader sr = new StringReader(xmlachievement);
                DataSet ds = new DataSet();
                ds.ReadXml(sr); dgvachive.DataSource = ds; dgvachive.DataBind();
            }
            else { dgvachive.DataSource = ""; dgvachive.DataBind(); }
        }
        #endregion

        #region --------------------- Gridview Row Delete -------------------
        protected void dgvedu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml");
            LoadEducationXml();
            DataSet dsGrid = (DataSet)dgvedu.DataSource;
            dsGrid.Tables[0].Rows[dgvedu.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(filePathForXML);
            DataSet dsGridAfterDelete = (DataSet)dgvedu.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            { File.Delete(filePathForXML); }
            LoadEducationXml();
        }
        protected void dgvtraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml");
            LoadTrainingXml();
            DataSet dsGrid = (DataSet)dgvtraining.DataSource;
            dsGrid.Tables[0].Rows[dgvtraining.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(filePathForXML);
            DataSet dsGridAfterDelete = (DataSet)dgvtraining.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            { File.Delete(filePathForXML); }
            LoadTrainingXml();
        }
        protected void dgvachive_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml");
            LoadAchieveXml();
            DataSet dsGrid = (DataSet)dgvachive.DataSource;
            dsGrid.Tables[0].Rows[dgvachive.Rows[e.RowIndex].DataItemIndex].Delete();
            dsGrid.WriteXml(filePathForXML);
            DataSet dsGridAfterDelete = (DataSet)dgvachive.DataSource;
            if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
            { File.Delete(filePathForXML); }
            LoadAchieveXml();
        }

        #endregion

        #region --------------------- Gridview Row Update -------------------
        protected void dgvedu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml");
            dgvedu.EditIndex = e.NewEditIndex;
            LoadEducationXml();
        }
        protected void dgvedu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml");
            int index = dgvedu.Rows[e.RowIndex].DataItemIndex;
            string institute = ((TextBox)dgvedu.Rows[index].FindControl("txtinstitute")).Text.ToString();
            string degree = ((TextBox)dgvedu.Rows[index].FindControl("txtdegree")).Text.ToString();
            string major = ((TextBox)dgvedu.Rows[index].FindControl("txtmajor")).Text.ToString();
            string passingyear = ((TextBox)dgvedu.Rows[index].FindControl("txtpassingyear")).Text.ToString();
            dgvedu.EditIndex = -1;
            LoadEducationXml();
            DataSet dsUpdate = (DataSet)dgvedu.DataSource;
            dsUpdate.Tables[0].Rows[index]["institute"] = institute;
            dsUpdate.Tables[0].Rows[index]["degree"] = degree;
            dsUpdate.Tables[0].Rows[index]["major"] = major;
            dsUpdate.Tables[0].Rows[index]["passingyear"] = passingyear;
            dsUpdate.WriteXml(filePathForXML);
            LoadEducationXml();
        }
        protected void dgvedu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvedu.EditIndex = -1;
            LoadEducationXml();
        }
        protected void dgvtraining_RowEditing(object sender, GridViewEditEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml");
            dgvtraining.EditIndex = e.NewEditIndex;
            LoadTrainingXml();
        }
        protected void dgvtraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml");
            int index = dgvtraining.Rows[e.RowIndex].DataItemIndex;
            string trinstitute = ((TextBox)dgvtraining.Rows[index].FindControl("txttrinstitute")).Text.ToString();
            string course = ((TextBox)dgvtraining.Rows[index].FindControl("txtcourse")).Text.ToString();
            string duration = ((TextBox)dgvtraining.Rows[index].FindControl("txtduration")).Text.ToString();
            dgvtraining.EditIndex = -1;
            LoadTrainingXml();
            DataSet dsUpdate = (DataSet)dgvtraining.DataSource;
            dsUpdate.Tables[0].Rows[index]["trinstitute"] = trinstitute;
            dsUpdate.Tables[0].Rows[index]["course"] = course;
            dsUpdate.Tables[0].Rows[index]["duration"] = duration;
            dsUpdate.WriteXml(filePathForXML);
            LoadTrainingXml();
        }
        protected void dgvtraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvtraining.EditIndex = -1;
            LoadTrainingXml();
        }
        protected void dgvachive_RowEditing(object sender, GridViewEditEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml");
            dgvachive.EditIndex = e.NewEditIndex;
            LoadAchieveXml();
        }
        protected void dgvachive_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml");
            int index = dgvachive.Rows[e.RowIndex].DataItemIndex;
            string ctask = ((TextBox)dgvachive.Rows[index].FindControl("txtctask")).Text.ToString();
            string cachivement = ((TextBox)dgvachive.Rows[index].FindControl("txtcachivement")).Text.ToString();
            string cachive = ((TextBox)dgvachive.Rows[index].FindControl("txtcachive")).Text.ToString();
            dgvachive.EditIndex = -1;
            LoadAchieveXml();
            DataSet dsUpdate = (DataSet)dgvachive.DataSource;
            dsUpdate.Tables[0].Rows[index]["ctask"] = ctask;
            dsUpdate.Tables[0].Rows[index]["cachivement"] = cachivement;
            dsUpdate.Tables[0].Rows[index]["cachive"] = cachive;
            dsUpdate.WriteXml(filePathForXML);
            LoadAchieveXml();
        }
        protected void dgvachive_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvachive.EditIndex = -1;
            LoadAchieveXml();
        }

        #endregion

        #region --------------------- Button Click Event -------------------
        protected void btnEduAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string institute = txtInstitute.Text;
                string degree = txtDegree.Text;
                string major = txtMajor.Text;
                string yearofpassing = txtPassingYear.Text;
                CreateEDUXml(institute, degree, major, yearofpassing);
            }
        }
        protected void btnTrainAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string training = txtTrining.Text;
                string course = txtCourse.Text;
                string duration = txtDuration.Text;
                CreateTRAXml(training, course, duration);
            }
        }
        protected void btnAchiveAdd_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string dteprdfrom = DateTime.Parse(dtePeriodFrom.Text).ToString("yyyy-MM-dd");
                string dteprdto = DateTime.Parse(dtePeriodTo.Text).ToString("yyyy-MM-dd");
                string task = txtTask.Text;
                string achievement = txtAchivement.Text;
                string achieve = txtAchive.Text;
                CreateACHVXml(dteprdfrom, dteprdto, task, achievement, achieve);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                    dirInfo = new DirectoryInfo(Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/"));
                    //--------------- Part XML Document ------------
                    string edufile = Session[SessionParams.USER_ID].ToString() + "Education.xml";
                    string[] edufilter = edufile.Split(new char[] { ',' });
                    ArrayList eduarr = new ArrayList();
                    foreach (string eduext in edufilter)
                    { eduarr.AddRange(dirInfo.GetFiles(eduext)); }
                    if (eduarr.Count > 0)
                    {
                        filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml");
                        XmlDocument edudoc = new XmlDocument();
                        edudoc.Load(filePathForXML);
                        XmlNode edunode = edudoc.SelectSingleNode("Education");
                        xmleducation = edunode.InnerXml;
                        xmleducation = "<Education>" + xmleducation + "</Education>";
                    }
                    //----------------------------------------------------
                    string trafile = Session[SessionParams.USER_ID].ToString() + "Training.xml";
                    string[] trafilter = trafile.Split(new char[] { ',' });
                    ArrayList traarr = new ArrayList();
                    foreach (string traext in trafilter)
                    { traarr.AddRange(dirInfo.GetFiles(traext)); }
                    if (traarr.Count > 0)
                    {
                        filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml");
                        XmlDocument tradoc = new XmlDocument();
                        tradoc.Load(filePathForXML);
                        XmlNode tranode = tradoc.SelectSingleNode("Training");
                        xmltraining = tranode.InnerXml;
                        xmltraining = "<Training>" + xmltraining + "</Training>";
                    }

                    //----------------------------------------------------
                    string achfile = Session[SessionParams.USER_ID].ToString() + "Achieve.xml";
                    string[] achfilter = achfile.Split(new char[] { ',' });
                    ArrayList acharr = new ArrayList();
                    foreach (string achext in achfilter)
                    { acharr.AddRange(dirInfo.GetFiles(achext)); }
                    if (acharr.Count > 0)
                    {
                        filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml");
                        XmlDocument achdoc = new XmlDocument();
                        achdoc.Load(filePathForXML);
                        XmlNode achnode = achdoc.SelectSingleNode("Achieve");
                        xmlachievement = achnode.InnerXml;
                        xmlachievement = "<Achieve>" + xmlachievement + "</Achieve>";
                    }

                    for (int index = 0; index < 11; index++)
                    {
                        string grdid = ((HiddenField)dgvgrading.Rows[index].FindControl("hdngrade")).Value.ToString();
                        string point = ((RadioButtonList)dgvgrading.Rows[index].FindControl("rdograding")).SelectedValue.ToString();
                        CreateGradingXml(grdid, point);
                    }
                    //----------------------------------------------------
                    string grdfile = Session[SessionParams.USER_ID].ToString() + "Grading.xml";
                    string[] grdfilter = grdfile.Split(new char[] { ',' });
                    ArrayList grdarr = new ArrayList();
                    foreach (string grdext in grdfilter)
                    { grdarr.AddRange(dirInfo.GetFiles(grdext)); }
                    if (grdarr.Count > 0)
                    {
                        filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Grading.xml");
                        XmlDocument grddoc = new XmlDocument();
                        grddoc.Load(filePathForXML);
                        XmlNode grdnode = grddoc.SelectSingleNode("Grading");
                        xmlgrading = grdnode.InnerXml;
                        xmlgrading = "<Grading>" + xmlgrading + "</Grading>";
                    }

                    string bengli = txtBengali.Text; 
                    string english = txtEnglish.Text;
                    string others = txtOthers.Text; 
                    string remarks = txtRemarks.Text;
                    string expotherscompany = txtTotalExpOthersCompany.Text;
                    string rdoperformance = rdoper.SelectedValue.ToString();
                    DateTime dtelstupdt = DateTime.Parse(dteLastupdate.Text);
                    string shorttearm = txtShortterm.Text;
                    string longtearm = txtLongterm.Text;
                    string rdorelocat = rdorelocate.SelectedValue.ToString();
                    string preference = txtpretowork.Text;
                    string comments = txtComments.Text;
                    string potential = txtPotential.Text;
                    string slfdevelopment = txtSelfdevelopment.Text;
                    string tasktarget = txtChaTaskTarget.Text;
                //------------- Now get Greading Points -------------
                    
                    UploadSignatureToFTP();
                    try
                    {
                        int enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                        string msg = objbll.InsertProgressData(enroll, xmleducation, xmltraining, bengli, english, others, remarks, expotherscompany,
                        xmlachievement, rdoperformance, dtelstupdt, xmlgrading, shorttearm, longtearm, rdorelocat, preference, comments,
                        potential, slfdevelopment, tasktarget, "/EmployeeInformation/" + signfile); 
                            if (msg != "0")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                            ClearControls();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + ",!!!');", true);
                        }
                    }
                    catch (Exception ex) { throw ex; }

            }
        }
        private void UploadSignatureToFTP()
        {
            try
            {
                if (signature.HasFile)
                {
                    filePath = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/");
                    string flnm = Path.GetExtension(signature.FileName);
                    signfile = "EmployeeSignature_" + Session[SessionParams.USER_ID].ToString() + "_" + Path.GetFileName(signature.FileName);
                    HttpPostedFile http = signature.PostedFile;
                    int length = http.ContentLength;
                    byte[] photoData = new byte[length];
                    http.InputStream.Read(photoData, 0, length);
                    FileStream photoFile = new FileStream(filePath + signfile, FileMode.Create);
                    photoFile.Write(photoData, 0, photoData.Length);
                    photoFile.Close();
                    WebClient wcp = new WebClient();
                    Uri uriphotoadd = new Uri("ftp://ftp.akij.net/EmployeeInformation/" + signfile);
                    wcp.Credentials = new NetworkCredential("erp@akij.net", "erp123");
                    wcp.UploadFile(uriphotoadd, filePath + signfile);
                    //File.Delete(filePath + signfile);
                }
            }
            catch { }
        }
        #endregion

        #region --------------------- XML Creating -------------------
        private void CreateEDUXml(string institute, string degree, string major, string passingyear)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Education.xml");
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Education");
                XmlNode addItem = CreateEducationNode(doc, institute, degree, major, passingyear);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Education");
                XmlNode addItem = CreateEducationNode(doc, institute, degree, major, passingyear);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML); LoadEducationXml(); txtInstitute.Text = ""; txtDegree.Text = "";
            txtMajor.Text = ""; txtPassingYear.Text = "";
        }       
        private XmlNode CreateEducationNode(XmlDocument doc, string institute, string degree, string major, string passingyear)
        {
            XmlNode node = doc.CreateElement("edu");
            XmlAttribute Institute = doc.CreateAttribute("institute");
            Institute.Value = institute;
            XmlAttribute Degree = doc.CreateAttribute("degree");
            Degree.Value = degree;
            XmlAttribute Major = doc.CreateAttribute("major");
            Major.Value = major;
            XmlAttribute PassingYear = doc.CreateAttribute("passingyear");
            PassingYear.Value = passingyear;
            node.Attributes.Append(Institute);
            node.Attributes.Append(Degree);
            node.Attributes.Append(Major);
            node.Attributes.Append(PassingYear);
            return node;
        }
        private void CreateTRAXml(string trinstitute, string course, string duration)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Training.xml");
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Training");
                XmlNode addItem = CreateTrainingNode(doc, trinstitute, course, duration);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Training");
                XmlNode addItem = CreateTrainingNode(doc, trinstitute, course, duration);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML); LoadTrainingXml(); txtTrining.Text = ""; txtCourse.Text = "";
            txtDuration.Text = ""; 
        }
        private XmlNode CreateTrainingNode(XmlDocument doc, string trinstitute, string course, string duration)
        {
            XmlNode node = doc.CreateElement("train");
            XmlAttribute TRInstitute = doc.CreateAttribute("trinstitute");
            TRInstitute.Value = trinstitute;
            XmlAttribute Course = doc.CreateAttribute("course");
            Course.Value = course;
            XmlAttribute Duration = doc.CreateAttribute("duration");
            Duration.Value = duration;

            node.Attributes.Append(TRInstitute);
            node.Attributes.Append(Course);
            node.Attributes.Append(Duration);
            return node;
        }
        private void CreateACHVXml(string dteprdfrom, string dteprdto, string ctask, string cachivement, string cachive)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Achieve.xml");
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Achieve");
                XmlNode addItem = CreateAchieveNode(doc, dteprdfrom, dteprdto, ctask, cachivement, cachive);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Achieve");
                XmlNode addItem = CreateAchieveNode(doc, dteprdfrom, dteprdto, ctask, cachivement, cachive);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML); LoadAchieveXml(); txtTask.Text = ""; txtAchivement.Text = "";
            txtAchive.Text = "";
        }
        private XmlNode CreateAchieveNode(XmlDocument doc, string dteprdfrom, string dteprdto, string ctask, string cachivement, string cachive)
        {
            XmlNode node = doc.CreateElement("achv");
            XmlAttribute Dteprdfrom = doc.CreateAttribute("dteprdfrom");
            Dteprdfrom.Value = dteprdfrom;
            XmlAttribute Dteprdto = doc.CreateAttribute("dteprdto");
            Dteprdto.Value = dteprdto;
            XmlAttribute CTask = doc.CreateAttribute("ctask");
            CTask.Value = ctask;
            XmlAttribute CAchivement = doc.CreateAttribute("cachivement");
            CAchivement.Value = cachivement;
            XmlAttribute CAchive = doc.CreateAttribute("cachive");
            CAchive.Value = cachive;

            node.Attributes.Append(Dteprdfrom);
            node.Attributes.Append(Dteprdto);
            node.Attributes.Append(CTask);
            node.Attributes.Append(CAchivement);
            node.Attributes.Append(CAchive);
            return node;
        }
        private void CreateGradingXml(string grdid, string point)
        {
            filePathForXML = Server.MapPath("~/HR/IssuedLetter/LetterTypeTemplate/" + Session[SessionParams.USER_ID].ToString() + "Grading.xml");
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("Grading");
                XmlNode addItem = CreateGradingNode(doc, grdid, point);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Grading");
                XmlNode addItem = CreateGradingNode(doc, grdid, point);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateGradingNode(XmlDocument doc, string grdid, string point)
        {
            XmlNode node = doc.CreateElement("grade");
            XmlAttribute Grdid = doc.CreateAttribute("grdid");
            Grdid.Value = grdid;
            XmlAttribute Point = doc.CreateAttribute("point");
            Point.Value = point;

            node.Attributes.Append(Grdid);
            node.Attributes.Append(Point);
            return node;
        }
        #endregion  

        

        

        

    }
}