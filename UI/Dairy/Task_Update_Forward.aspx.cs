using Dairy_BLL;
using SAD_BLL.Transport;
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
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace UI.Dairy
{
    public partial class Task_Update_Forward : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        int intEnroll; string Unitid; int intSearchEnroll; string strReportType;
        int intID; DateTime dteSubmitDate;

        int intWork; string strTaskTitle; string strPriority; int intStatusID; string strStatus;
        int intCompletePer; int intAssignBy; int intAssignTo; DateTime dteStart; DateTime dteDeadline;
        DateTime dteComplete; string strRemarks; int intInsertBy; int intReffID; DateTime dteDate;
        string strDescription; string strTaskReffNo;

        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strSubmitDate;
        DateTime dteDeadlineTime; int intCount; string strNotes;

        string objective; string activities; string who; string when; string outcomes; string evaluation; string notes;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            filePathForXML = Server.MapPath("~/Dairy/Data/WorkPlan_" + hdnEnroll.Value + ".xml");
            filePathForXMLDocUpload = Server.MapPath("~/Dairy/Data/DocUpload_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXML); dgvWorkPlan.DataSource = ""; dgvWorkPlan.DataBind();
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg";

                    ForwardDiv.Visible = false;

                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                    intCount = 0;
                    dt = new DataTable();
                    dt = objtask.GetCountWorkPlan(intID);
                    if (dt.Rows.Count > 0)
                    { intCount = int.Parse(dt.Rows[0]["intWPCount"].ToString()); }
                    if (intCount > 0)
                    {
                        CheckBoxTaskFDiv.Visible = true;
                        UpdateDiv.Visible = true;
                        WorkPlanDiv.Visible = false;
                        GetTaskInfoForUpdate();
                    }
                    else
                    {
                        CheckBoxTaskFDiv.Visible = false;
                        UpdateDiv.Visible = false;
                        WorkPlanDiv.Visible = true;
                    }

                    ////LoadGrid();
                }
                catch { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
            else if (hdnconfirm.Value == "4") { FTPUploadF(); }
            else if (hdnconfirm.Value == "5") { FinalUploadF(); }
        }

        private void GetTaskInfoForUpdate()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            dt = new DataTable();
            dt = objtask.GetTaskInfoForUpdateR(intID);
            if (dt.Rows.Count > 0)
            {
                txtTaskDetailsOld.Text = dt.Rows[0]["strTaskTitle"].ToString();
                txtReff.Text = dt.Rows[0]["strTaskReffNo"].ToString();

                //DateTime strDateFormat = DateTime.Parse(dt.Rows[0]["dteDeadline"].ToString("yyyy-MM-dd"));
                //txtDeadline.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txtDeadline.Text = DateTime.Parse(dt.Rows[0]["dteDeadline"].ToString("yyyy-MM-dd"));

                txtDeadline.Text = dt.Rows[0]["dteDeadline"].ToString();
                hdnStartDate.Value = dt.Rows[0]["dteStart"].ToString();

                txtExitDeadline.Visible = false;
                TimeSelector1.Visible = false;
                if (txtDeadline.Text == "")
                { 
                    txtExitDeadline.Visible = false; txtExitDeadline.Text = ""; TimeSelector1.Visible = true;
                    DeadlineChageReqDiv.Visible = false;
                }
                else 
                { 
                    txtExitDeadline.Visible = true; TimeSelector1.Visible = false;
                    txtExitDeadline.Text = dt.Rows[0]["dteDeadlineTime"].ToString();
                    DeadlineChageReqDiv.Visible = true;
                }

                ddlStatus.SelectedValue = dt.Rows[0]["intStatusID"].ToString();
                txtComPer.Text = dt.Rows[0]["intCompletePer"].ToString();

                if (hdnComPer.Value == "")
                {
                    hdnComPer.Value = "0";
                }
                else { hdnComPer.Value = dt.Rows[0]["intCompletePer"].ToString(); }
            }

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlStatus.SelectedItem.ToString() == "Forward") 
            //{ 
            //    ForwardDiv.Visible = true; btnSave.Visible = false;
            //    txtTaskDetails.Text = txtTaskDetailsOld.Text;

            //    dt = objtask.GetTeamMemberList(int.Parse(hdnEnroll.Value));
            //    ddlAssignTo.DataTextField = "strEmployeeName";
            //    ddlAssignTo.DataValueField = "intEmployeeID";
            //    ddlAssignTo.DataSource = dt;
            //    ddlAssignTo.DataBind();
            //    ddlAssignTo.Visible = false;
            //    cbMyTeam.Checked = false;
            //}
            //else { ForwardDiv.Visible = false; btnSave.Visible = true; }

            if (ddlStatus.SelectedItem.ToString() == "Completed") { txtComPer.Text = "100"; }
            else { txtComPer.Text = hdnComPer.Value; }
        }

        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                //********************************************************************************************
                String strDate = "1900-01-01";

                //DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));

                intWork = 2;
                intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                intStatusID = int.Parse(ddlStatus.SelectedValue.ToString());
                strStatus = ddlStatus.SelectedItem.ToString();
                try { intCompletePer = int.Parse(txtComPer.Text); }
                catch { intCompletePer = 0; }

                if (intCompletePer < int.Parse(hdnComPer.Value))
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Completed percent is less than previous percent. Please input Complete percent equal or more than previous percent.');", true); return; }

                if (intCompletePer > 100)
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Percentage');", true); return; }

                strDescription = txtDescription.Text;

                //////////try { dteDate = DateTime.Parse(txtUpdateDate.Text); }
                //////////catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Update Date.');", true); return; }
                hdnUpdateDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                dteDate = DateTime.Parse(hdnUpdateDate.Value);
                dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));

                //if (intCompletePer == 100)
                //{
                //    dteComplete = DateTime.Parse(txtUpdateDate.Text);
                //    if (dteComplete < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                //    {
                //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Complete Date.');", true); return;
                //    }
                //}
                //else { dteComplete = DateTime.Parse(txtUpdateDate.Text); }

                ////////////dteComplete = DateTime.Parse(txtUpdateDate.Text);                
                dteComplete = DateTime.Parse(hdnUpdateDate.Value);
                //try { dteDeadline = DateTime.Parse(txtDeadline.Text); }
                //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Deadline.');", true); return; }

                try
                {
                    string datecheck = hdnStartDate.Value;

                    dteDeadline = DateTime.Parse(txtDeadline.Text);
                    if (DateTime.Parse(datecheck.ToString()) > dteDeadline)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline.');", true); return;
                    }
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline.');", true); return; }

                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                strTaskReffNo = "";
                strTaskTitle = "";
                strPriority = "";
                try { intAssignBy = int.Parse(txtMarks.Text);} catch { intAssignBy = 0; }

                if (intAssignBy > 100)
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Proposed Marks.');", true); return; }

                intAssignTo = 0;
                dteStart = DateTime.Parse(strDate.ToString());
                strRemarks = "";

                //********************************************************************************************
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXMLDocUpload);
                    XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                    xmlStringDocUpload = dSftTm.InnerXml;
                    xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                    xml = xmlStringDocUpload;
                }
                catch { }

                if (dgvDocUp.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                    {
                        fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                        FileUploadFTP(Server.MapPath("~/Dairy/Uploads/"), fileName, "ftp://ftp.akij.net/TaskDocument/", "erp@akij.net", "erp123");

                    }
                }

                //Final Insert
                string message = objtask.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo, dteDeadlineTime);

                ////////////txtUpdateDate.Text = "";
                txtComPer.Text = "";
                txtDescription.Text = "";

                if (filePathForXMLDocUpload != null)
                { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

            }
        }

        //** Gridview Document Upload Start ******************************************************
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            //******************************************************************
            try
            {
                FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
                requestFTPUploader.Credentials = new NetworkCredential(user, pass);
                requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(localPath + fileName);
                FileStream fileStream = fileInfo.OpenRead();

                int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];

                Stream uploadStream = requestFTPUploader.GetRequestStream();
                int contentLength = fileStream.Read(buffer, 0, bufferLength);

                while (contentLength != 0)
                {
                    uploadStream.Write(buffer, 0, contentLength);
                    contentLength = fileStream.Read(buffer, 0, bufferLength);
                }

                uploadStream.Close();
                fileStream.Close();

                requestFTPUploader = null;
                File.Delete(Server.MapPath("~/Dairy/Uploads/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }
        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                ////string strDat = DateTime.Now.ToString("yyyy-MM-dd");
                hdnUpdateDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = 1;
                    strDocName = "Task Doc";
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        //txtNowDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        //dteComplete = DateTime.Parse(txtNowDate.Text);
                        dteSubmitDate = DateTime.Parse(hdnUpdateDate.Value);
                        strSubmitDate = DateTime.Now.ToString("yyyy-MM-dd");

                        ////////dteSubmitDate = DateTime.Parse(txtUpdateDate.Text);
                        ////////strSubmitDate = txtUpdateDate.Text;
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return; }

                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strSubmitDate + "_" + strDocUploadPath;
                            doctypeid = "1";

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            fileName = strDocUploadPath.Replace(" ", "");
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{
                            //    uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //}
                            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(strFileName, doctypeid, strSubmitDate);
                        }
                    }
                }

                hdnconfirm.Value = "0";

                            #endregion

            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid, strSubmitDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid, strSubmitDate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);
            LoadGridwithXmlDocUpload();
            //Clear(); 
        }
        private void LoadGridwithXmlDocUpload()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDocUpload);
            XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
            xmlStringDocUpload = dSftTm.InnerXml;
            xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
            StringReader sr = new StringReader(xmlStringDocUpload);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDocUp.DataSource = ds; }
            else { dgvDocUp.DataSource = ""; } dgvDocUp.DataBind();
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;
            XmlAttribute StrSubmitDate = doc.CreateAttribute("strSubmitDate"); StrSubmitDate.Value = strSubmitDate;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Doctypeid);
            node.Attributes.Append(StrSubmitDate);
            return node;
        }
        protected void dgvDocUp_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                StringReader sr = new StringReader(xmlStringDocUpload);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDocUp.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDocUp.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();

                File.Delete(Server.MapPath("~/Dairy/Uploads/") + fileName);
                dsGrid.Tables[0].Rows[dgvDocUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch { }

        }

        //** Gridview Document Upload End   

        protected void FinalUploadF()
        {
            if (hdnconfirm.Value == "5")
            {
                try
                {
                    string strDate = "1900-01-01";

                    intWork = 3;
                    if (txtTaskDetails.Text != "") { strTaskTitle = txtTaskDetails.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Task Title.');", true); return; }
                    strPriority = ddlPriority.SelectedItem.ToString();
                    intStatusID = 1;
                    strStatus = "Not Started";
                    intCompletePer = 0;

                    strTaskReffNo = txtReff.Text;
                    intAssignBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                    //char[] ch = { '[', ']' };
                    //string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    //try { intAssignTo = int.Parse(temp[1].ToString()); }
                    //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign To.');", true); return; }

                    if (cbMyTeam.Checked == false)
                    {
                        char[] ch = { '[', ']' };
                        string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                        try { intAssignTo = int.Parse(temp[1].ToString()); }
                        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign To.');", true); return; }
                    }
                    else
                    {
                        intAssignTo = int.Parse(ddlAssignTo.SelectedValue.ToString());
                    }

                    try { dteStart = DateTime.Parse(txtStartDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Start Date.');", true); return; }

                    //try { dteDeadline = DateTime.Parse(txtDeadlineF.Text); }
                    //catch { dteDeadline = DateTime.Parse(strDate.ToString()); }

                    try
                    {
                        dteDeadline = DateTime.Parse(txtDeadlineF.Text);
                        if (dteStart > dteDeadline)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline.');", true); return;
                        }
                    }
                    catch { dteDeadline = DateTime.Parse(strDate.ToString()); }

                    dteComplete = DateTime.Parse(strDate.ToString());
                    strRemarks = txtRemarks.Text;
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    dteDate = DateTime.Parse(strDate.ToString());
                    dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector2.Hour, TimeSelector2.Minute, TimeSelector2.Second, TimeSelector2.AmPm));
                    strDescription = "";

                    //********************************************************************************************
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDocUpload);
                        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                        xmlStringDocUpload = dSftTm.InnerXml;
                        xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                        xml = xmlStringDocUpload;
                    }
                    catch { }

                    if (dgvDocUp1.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvDocUp1.Rows.Count; index++)
                        {
                            fileName = ((Label)dgvDocUp1.Rows[index].FindControl("lblFileName")).Text.ToString();
                            FileUploadFTP(Server.MapPath("~/Dairy/Uploads/"), fileName, "ftp://ftp.akij.net/TaskDocument/", "erp@akij.net", "erp123");

                        }
                    }

                    //Final Insert
                    string message = objtask.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo, dteDeadlineTime);

                    //txtTaskDetails.Text = "";
                    //txtRemarks.Text = "";
                    txtSearchAssignedTo.Text = "";
                    //txtStartDate.Text = "";
                    //txtDeadlineF.Text = "";

                    if (filePathForXMLDocUpload != null)
                    { File.Delete(filePathForXMLDocUpload); } dgvDocUp1.DataSource = ""; dgvDocUp1.DataBind();

                    LoadGrid();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }
        }


        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }


        //** Gridview Document Upload Start ******************************************************
        protected void FTPUploadF()
        {
            if (hdnconfirm.Value == "4")
            {
                ////string strDat = DateTime.Now.ToString("yyyy-MM-dd");

                if (txtDocUpload1.FileName.ToString() != "")
                {
                    intDocType = 1;
                    strDocName = "Task Doc";
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        dteSubmitDate = DateTime.Parse(txtStartDate.Text);
                        strSubmitDate = txtStartDate.Text;
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Start Date Properly Input.');", true); return; }

                    int intCount = 0;
                    if (txtDocUpload1.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload1.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strSubmitDate + "_" + strDocUploadPath;
                            doctypeid = "1";

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            fileName = strDocUploadPath.Replace(" ", "");
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{
                            //    uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //}
                            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload1(strFileName, doctypeid, strSubmitDate);
                        }
                    }
                }

                hdnconfirm.Value = "0";

                            #endregion

            }
        }
        private void CreateVoucherXmlDocUpload1(string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload1(doc, strFileName, doctypeid, strSubmitDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload1(doc, strFileName, doctypeid, strSubmitDate);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);
            LoadGridwithXmlDocUpload1();
            //Clear(); 
        }
        private void LoadGridwithXmlDocUpload1()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDocUpload);
            XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
            xmlStringDocUpload = dSftTm.InnerXml;
            xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
            StringReader sr = new StringReader(xmlStringDocUpload);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDocUp1.DataSource = ds; }
            else { dgvDocUp1.DataSource = ""; } dgvDocUp1.DataBind();
        }
        private XmlNode CreateItemNodeDocUpload1(XmlDocument doc, string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;
            XmlAttribute StrSubmitDate = doc.CreateAttribute("strSubmitDate"); StrSubmitDate.Value = strSubmitDate;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Doctypeid);
            node.Attributes.Append(StrSubmitDate);
            return node;
        }
        protected void dgvDocUp1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                StringReader sr = new StringReader(xmlStringDocUpload);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDocUp1.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDocUp1.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();

                File.Delete(Server.MapPath("~/Dairy/Uploads/") + fileName);
                dsGrid.Tables[0].Rows[dgvDocUp1.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp1.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp1.DataSource = ""; dgvDocUp1.DataBind();
                }
                else { LoadGridwithXmlDocUpload1(); }
            }
            catch { }

        }

        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            try
            {
                dt = new DataTable();
                dt = objtask.GetPicturePath(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    img.ImageUrl = "ftp://erp:erp123@ftp.akij.net" + dt.Rows[0]["strFtpFilePath"].ToString();
                }
                else { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }
            }
            catch { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }

            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                if (cbMyTeam.Checked == false)
                {
                    char[] chr = { '[', ']' };
                    string[] temp1 = txtSearchAssignedTo.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
                    try { intEnroll = int.Parse(temp1[1].ToString()); }
                    catch { intEnroll = 0; }

                    intSearchEnroll = 0;
                    intWork = 13;

                    dt = new DataTable();
                    dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
                else
                {
                    intEnroll = int.Parse(ddlAssignTo.SelectedValue.ToString());
                    intSearchEnroll = 0;
                    intWork = 13;

                    dt = new DataTable();
                    dt = objtask.GetTaskReport2(intWork, intEnroll, intSearchEnroll);
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
            }
            catch { }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTaskDetails.Text = "";
            txtSearchAssignedTo.Text = "";
            txtStartDate.Text = "";
            txtDeadlineF.Text = "";
            txtRemarks.Text = "";
        }

        protected void cbMyTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMyTeam.Checked == true)
            {
                ddlAssignTo.Visible = true;
                txtSearchAssignedTo.Visible = false;
                dgvReport.DataSource = "";
                dgvReport.DataBind();
                txtSearchAssignedTo.Text = "";
            }
            else
            {
                ddlAssignTo.Visible = false;
                txtSearchAssignedTo.Visible = true;
                dgvReport.DataSource = "";
                dgvReport.DataBind();
                txtSearchAssignedTo.Text = "";
            }
        }

        protected void ddlAssignTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            intEnroll = int.Parse(ddlAssignTo.SelectedValue.ToString());

            try
            {
                dt = new DataTable();
                dt = objtask.GetPicturePath(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    img.ImageUrl = "ftp://erp:erp123@ftp.akij.net" + dt.Rows[0]["strFtpFilePath"].ToString();
                }
                else { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }
            }
            catch { img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg"; }

            LoadGrid();
        }

        protected void cbTaskForward_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTaskForward.Checked == true)
            {
                ForwardDiv.Visible = true; //btnSave.Visible = false;
                UpdateDiv.Visible = false;
                txtTaskDetails.Text = txtTaskDetailsOld.Text;
                txtSearchAssignedTo.Visible = true;

                dt = objtask.GetTeamMemberList(int.Parse(hdnEnroll.Value));
                ddlAssignTo.DataTextField = "strEmployeeName";
                ddlAssignTo.DataValueField = "intEmployeeID";
                ddlAssignTo.DataSource = dt;
                ddlAssignTo.DataBind();
                ddlAssignTo.Visible = false;
                cbMyTeam.Checked = false;
                img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg";
            }
            else
            {
                //ForwardDiv.Visible = false; btnSave.Visible = true;
                ForwardDiv.Visible = false; //btnSave.Visible = false;
                UpdateDiv.Visible = true;
                dgvReport.DataSource = "";
                dgvReport.DataBind();
                txtSearchAssignedTo.Text = "";
            }

        }

        //** Gridview Document Upload End   


        //*** Work Plan Start ***************************************************************************************

        protected void btnWorkPlan_Click(object sender, EventArgs e)
        {
            objective = txtObjectives.Text;
            activities = txtActivities.Text;
            who = txtWho.Text;
            when = txtWhen.Text;
            outcomes = txtOutcomes.Text;
            evaluation = txtEvaluation.Text;
            notes = txtNotes.Text;

            CreateVoucherXml(objective, activities, who, when, outcomes, evaluation, notes);

            txtObjectives.Text = "";
            txtActivities.Text = "";
            txtWho.Text = "";
            txtWhen.Text = "";
            txtOutcomes.Text = "";
            txtEvaluation.Text = "";
            txtNotes.Text = "";
        }
        private void CreateVoucherXml(string objective, string activities, string who, string when, string outcomes, string evaluation, string notes)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("WorkPlan");
                XmlNode addItem = CreateItemNodeWorkPlan(doc, objective, activities, who, when, outcomes, evaluation, notes);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("WorkPlan");
                XmlNode addItem = CreateItemNodeWorkPlan(doc, objective, activities, who, when, outcomes, evaluation, notes);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXmlWorkPlan();
            //Clear(); 
        }
        private void LoadGridwithXmlWorkPlan()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("WorkPlan");
            xmlString = dSftTm.InnerXml;
            xmlString = "<WorkPlan>" + xmlString + "</WorkPlan>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvWorkPlan.DataSource = ds; }
            else { dgvWorkPlan.DataSource = ""; } dgvWorkPlan.DataBind();
        }
        private XmlNode CreateItemNodeWorkPlan(XmlDocument doc, string objective, string activities, string who, string when, string outcomes, string evaluation, string notes)
        {
            XmlNode node = doc.CreateElement("WorkPlan");

            XmlAttribute Objective = doc.CreateAttribute("objective"); Objective.Value = objective;
            XmlAttribute Activities = doc.CreateAttribute("activities"); Activities.Value = activities;
            XmlAttribute Who = doc.CreateAttribute("who"); Who.Value = who;
            XmlAttribute When = doc.CreateAttribute("when"); When.Value = when;
            XmlAttribute Outcomes = doc.CreateAttribute("outcomes"); Outcomes.Value = outcomes;
            XmlAttribute Evaluation = doc.CreateAttribute("evaluation"); Evaluation.Value = evaluation;
            XmlAttribute Notes = doc.CreateAttribute("notes"); Notes.Value = notes;

            node.Attributes.Append(Objective);
            node.Attributes.Append(Activities);
            node.Attributes.Append(Who);
            node.Attributes.Append(When);
            node.Attributes.Append(Outcomes);
            node.Attributes.Append(Evaluation);
            node.Attributes.Append(Notes);
            return node;
        }
        
        
        
        protected void dgvWorkPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("WorkPlan");
                xmlString = dSftTm.InnerXml;
                xmlString = "<WorkPlan>" + xmlString + "</WorkPlan>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvWorkPlan.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvWorkPlan.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();

                File.Delete(Server.MapPath("~/Dairy/Uploads/") + fileName);
                dsGrid.Tables[0].Rows[dgvWorkPlan.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvWorkPlan.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvWorkPlan.DataSource = ""; dgvWorkPlan.DataBind();
                }
                else { LoadGridwithXmlWorkPlan(); }
            }
            catch { }

        }

        protected void btnWorkPlanSave_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("WorkPlan");
                    xmlString = dSftTm.InnerXml;
                    xmlString = "<WorkPlan>" + xmlString + "</WorkPlan>";
                    xml = xmlString;
                }
                catch { }

                //Final Insert
                string message = objtask.InsertWorkPlan(intReffID, intInsertBy, xml);


                if (filePathForXML != null)
                { File.Delete(filePathForXML); } dgvWorkPlan.DataSource = ""; dgvWorkPlan.DataBind();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);                
            }
        }

        //*** Work Plan End ****************************************************************************************** 

        protected void btnDChangeReq_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    try { dteDeadline = DateTime.Parse(txtDChageReq.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline Date.');", true); return; }
                    dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector3.Hour, TimeSelector3.Minute, TimeSelector3.Second, TimeSelector3.AmPm));
                    strNotes = txtReqNotes.Text;

                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                    //Final Insert
                    string message = objtask.InsertDchangeReq(intReffID, dteDeadline, dteDeadlineTime, intInsertBy, strNotes);
                    txtReqNotes.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch { }
            }

        }
















    }
}