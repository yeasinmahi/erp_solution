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
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.Dairy
{
    public partial class Daily_Task : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Daily_Task.aspx";
        string stop = "stopping Dairy/Daily_Task.aspx";

        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;
        
        int intWork; string strTaskTitle; string strPriority; int intStatusID; string strStatus; 
        int intCompletePer; int intAssignBy; int intAssignTo; DateTime dteStart; DateTime dteDeadline; 
        DateTime dteComplete; string strRemarks; int intInsertBy; int intReffID; DateTime dteDate;
        string strDescription; string xml; string strTaskReffNo;
        int intEnroll; int intSearchEnroll;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strSubmitDate;
        int intID; DateTime dteSubmitDate;


        string Unitid; DateTime dteDeadlineTime;
        //string filePathForXML; string xmlString = ""; string xml;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        //string assigntoname; string assignenroll;  

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Daily_Task.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            //filePathForXML = Server.MapPath("~/Dairy/Data/AssignTo_" + hdnEnroll.Value + ".xml");

            //hdnEnroll.Value = "1459";

            filePathForXMLDocUpload = Server.MapPath("~/Dairy/Data/DocUpload_" + hdnEnroll.Value + ".xml");
            
            if (!IsPostBack)
            {
                try 
                {
                    dt = objtask.GetTeamMemberList(int.Parse(hdnEnroll.Value));
                    ddlAssignTo.DataTextField = "strEmployeeName";
                    ddlAssignTo.DataValueField = "intEmployeeID";
                    ddlAssignTo.DataSource = dt;
                    ddlAssignTo.DataBind();
                    ddlAssignTo.Visible = false;
                    
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg";
                    //File.Delete(filePathForXML); dgvAssignedTo.DataSource = ""; dgvAssignedTo.DataBind();

                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    //pnlUpperControl.DataBind();

                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();
                }
                catch
                { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }


        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count) 
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString()); 
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText); 
        }

        protected void FinalUpload()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Daily_Task.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "3")
            {
                try
                {
                    string strDate = "1900-01-01";

                    intWork = 1;
                    strTaskReffNo = txtReff.Text;
                    if (txtTaskDetails.Text != "") { strTaskTitle = txtTaskDetails.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Task Title.');", true); return; }
                    strPriority = ddlPriority.SelectedItem.ToString();
                    intStatusID = 1;
                    strStatus = "Not Started";
                    intCompletePer = 0;

                    intAssignBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //intAssignBy = 1459;

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

                    try 
                    { 
                        dteDeadline = DateTime.Parse(txtDeadline.Text);
                        if (dteStart > dteDeadline)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline.');", true); return;
                        }
                    }
                    catch { dteDeadline = DateTime.Parse(strDate.ToString()); }
                          
                    dteComplete = DateTime.Parse(strDate.ToString());
                    strRemarks = txtRemarks.Text;
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intReffID = 0;
                    dteDate = DateTime.Parse(strDate.ToString());
                    strDescription = "";
                    
                    //***************************************************************************************************
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

                    //dteDeadlineTime = "";
                    dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));

                    //Final Insert
                    string message = objtask.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo, dteDeadlineTime);

                    if (filePathForXMLDocUpload != null)
                    { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    //txtTaskDetails.Text = "";
                    //txtRemarks.Text = "";
                    //txtAssignBy.Text = "";
                    txtSearchAssignedTo.Text = "";
                    //txtStartDate.Text = "";
                    //txtDeadline.Text = "";
                    //txtReff.Text = "";

                    LoadGrid(); 

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }
        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0;}
            
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
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Daily_Task.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

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

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
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

                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = 1;
                    strDocName = "Task Doc";
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        dteSubmitDate = DateTime.Parse(txtStartDate.Text);
                        strSubmitDate = txtStartDate.Text;
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTaskDetails.Text = "";
            txtRemarks.Text = "";            
            txtSearchAssignedTo.Text = "";
            txtStartDate.Text = "";
            txtDeadline.Text = "";
            txtReff.Text = "";
        }
        protected void cbMyTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMyTeam.Checked == true)
            {
                ddlAssignTo.Visible = true;
                txtSearchAssignedTo.Visible = false;
            }
            else
            {
                ddlAssignTo.Visible = false;
                txtSearchAssignedTo.Visible = true;
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


        //** Gridview Document Upload End   


































        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (hdnconfirm.Value == "1")
        //    {
        //        try
        //        {
        //            string strDate = "1900-01-01";

        //            intWork = 1;
        //            strTaskReffNo = txtReff.Text;
        //            if (txtTaskDetails.Text != "") { strTaskTitle = txtTaskDetails.Text; }
        //            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Task Title.');", true); return; }
        //            strPriority = ddlPriority.SelectedItem.ToString();
        //            intStatusID = 1;
        //            strStatus = "Not Started";
        //            intCompletePer = 0;

        //            //char[] chr = { '[', ']' };
        //            //string[] temp1 = txtAssignBy.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
        //            //try { intAssignBy = int.Parse(temp1[1].ToString()); }
        //            //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign By.');", true); return; }

        //            intAssignBy = int.Parse(Session[SessionParams.USER_ID].ToString());

        //            char[] ch = { '[', ']' };
        //            string[] temp = txtSearchAssignedTo.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
        //            try { intAssignTo = int.Parse(temp[1].ToString()); }
        //            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign To.');", true); return; }

        //            try { dteStart = DateTime.Parse(txtStartDate.Text); }
        //            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Start Date.');", true); return; }

        //            try { dteDeadline = DateTime.Parse(txtDeadline.Text); }
        //            catch { dteDeadline = DateTime.Parse(strDate.ToString()); }

        //            //if (txtDeadline.Text == "") { dteDeadline = DateTime.Parse(strDate.ToString()); }
        //            //else
        //            //{
        //            //    if (dteDeadline < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
        //            //    {
        //            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Deadline.');", true); return;
        //            //    }
        //            //    else
        //            //    {
        //            //        try { dteDeadline = DateTime.Parse(txtDeadline.Text); }
        //            //        catch { dteDeadline = DateTime.Parse(strDate.ToString()); }
        //            //    }
        //            //}

        //            dteComplete = DateTime.Parse(strDate.ToString());
        //            strRemarks = txtRemarks.Text;
        //            intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
        //            intReffID = 0;
        //            dteDate = DateTime.Parse(strDate.ToString());
        //            strDescription = "";
        //            xml = "";

        //            //Final Insert
        //            string message = objtask.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo);

        //            txtTaskDetails.Text = "";
        //            txtRemarks.Text = "";
        //            //txtAssignBy.Text = "";
        //            txtSearchAssignedTo.Text = "";
        //            txtStartDate.Text = "";
        //            txtDeadline.Text = "";
        //            txtReff.Text = "";

        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
        //            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        //        }
        //        catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
        //    }
        //}
        

        //protected void btnAssignedToAdd_Click(object sender, EventArgs e)
        //{
        //    string senderdata = txtSearchAssignedTo.Text;

        //    string strSearchKey = senderdata;
        //    string[] searchKey = Regex.Split(strSearchKey, ";");

        //    assigntoname = txtSearchAssignedTo.Text;
        //    assignenroll = searchKey[1];
        //    if (assignenroll != "")
        //    {
        //        CreateVoucherXmlDocUpload(assigntoname, assignenroll);
        //    }

        //    txtSearchAssignedTo.Text = "";
        //}
        //private void CreateVoucherXmlDocUpload(string assigntoname, string assignenroll)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    if (System.IO.File.Exists(filePathForXML))
        //    {
        //        doc.Load(filePathForXML);
        //        XmlNode rootNode = doc.SelectSingleNode("DocUpload");
        //        XmlNode addItem = CreateItemNodeDocUpload(doc, assigntoname, assignenroll);
        //        rootNode.AppendChild(addItem);
        //    }
        //    else
        //    {
        //        XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
        //        doc.AppendChild(xmldeclerationNode);
        //        XmlNode rootNode = doc.CreateElement("DocUpload");
        //        XmlNode addItem = CreateItemNodeDocUpload(doc, assigntoname, assignenroll);
        //        rootNode.AppendChild(addItem);
        //        doc.AppendChild(rootNode);
        //    }
        //    doc.Save(filePathForXML);
        //    LoadGridwithXmlDocUpload();
        //    //Clear(); 
        //}
        //private void LoadGridwithXmlDocUpload()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(filePathForXML);
        //    XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
        //    xmlString = dSftTm.InnerXml;
        //    xmlString = "<DocUpload>" + xmlString + "</DocUpload>";
        //    StringReader sr = new StringReader(xmlString);
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(sr);
        //    if (ds.Tables[0].Rows.Count > 0) { dgvAssignedTo.DataSource = ds; }
        //    else { dgvAssignedTo.DataSource = ""; } dgvAssignedTo.DataBind();
        //}
        //private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string assigntoname, string assignenroll)
        //{
        //    XmlNode node = doc.CreateElement("DocUpload");

        //    XmlAttribute Assigntoname = doc.CreateAttribute("assigntoname"); Assigntoname.Value = assigntoname;
        //    XmlAttribute Assignenroll = doc.CreateAttribute("assignenroll"); Assignenroll.Value = assignenroll;

        //    node.Attributes.Append(Assigntoname);
        //    node.Attributes.Append(Assignenroll);            
        //    return node;
        //}
        //protected void dgvAssignedTo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(filePathForXML);
        //        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
        //        xmlString = dSftTm.InnerXml;
        //        xmlString = "<DocUpload>" + xmlString + "</DocUpload>";
        //        StringReader sr = new StringReader(xmlString);
        //        DataSet ds = new DataSet();
        //        ds.ReadXml(sr);
        //        dgvAssignedTo.DataSource = ds;

        //        DataSet dsGrid = (DataSet)dgvAssignedTo.DataSource;
        //        ////fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();

        //        ////File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
        //        dsGrid.Tables[0].Rows[dgvAssignedTo.Rows[e.RowIndex].DataItemIndex].Delete();
        //        dsGrid.WriteXml(filePathForXML);
        //        DataSet dsGridAfterDelete = (DataSet)dgvAssignedTo.DataSource;
        //        if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
        //        {
        //            File.Delete(filePathForXML); dgvAssignedTo.DataSource = ""; dgvAssignedTo.DataBind();
        //        }
        //        else { LoadGridwithXmlDocUpload(); }
        //    }
        //    catch { }
        //}
        

















    }
}