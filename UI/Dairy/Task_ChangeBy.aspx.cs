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
    public partial class Task_ChangeBy : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;


        int intWork; string strTaskTitle; string strPriority; int intStatusID; string strStatus;
        int intCompletePer; int intAssignBy; int intAssignTo; DateTime dteStart; DateTime dteDeadline;
        DateTime dteComplete; string strRemarks; int intInsertBy; int intReffID; DateTime dteDate;
        string strDescription; string xml; string strTaskReffNo; int intID;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strSubmitDate;

        int intEnroll; int intSearchEnroll; string strReportType;
        DateTime dteSubmitDate;

        string Unitid; DateTime dteDeadlineTime; int intPBack;
        //string filePathForXML; string xmlString = ""; string xml;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        //string assigntoname; string assignenroll;  

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            filePathForXMLDocUpload = Server.MapPath("~/Dairy/Data/DocUpload_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp1.DataSource = ""; dgvDocUp1.DataBind();
                    ////ForwardDiv.Visible = false;
                    img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg";

                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();
                    ForwardDiv.Visible = false;
                    //
                    GetTaskInfoForUpdate();

                    try
                    {
                        dt = new DataTable();
                        dt = objtask.GetDeadlineChangeReport(intID);
                        dgvChangeReport.DataSource = dt;
                        dgvChangeReport.DataBind();
                    }
                    catch { }
                    ////LoadGrid();


                }
                catch { }
            }
            else if (hdnconfirm.Value == "4") { FTPUploadF(); }
            else if (hdnconfirm.Value == "5") { FinalUploadF(); }

            //int intPostB = 1;
            //HttpContext.Current.Session["intPBack"] = intPostB.ToString();
            //intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString());

            //Session["intPBack"] = "1";
            //intPBack = int.Parse(Session["intPBack"].ToString());
        }

        private void GetTaskInfoForUpdate()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            dt = new DataTable();
            dt = objtask.GetTaskInfoForUpdateR(intID);
            if (dt.Rows.Count > 0)
            {
                txtTaskDetails.Text = dt.Rows[0]["strTaskTitle"].ToString();                
                txtDeadline.Text = dt.Rows[0]["dteDeadline"].ToString();

                txtTaskDetailsT.Text = dt.Rows[0]["strTaskTitle"].ToString();
                txtStartDate.Text = dt.Rows[0]["dteStart"].ToString();
                txtDeadlineF.Text = dt.Rows[0]["dteDeadline"].ToString();
                txtRemarks.Text = dt.Rows[0]["strRemarks"].ToString();
                ddlPriority.SelectedValue = dt.Rows[0]["strPriority"].ToString();

            }

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    string strDate = "1900-01-01";

                    intWork = 4;
                    strTaskReffNo = "";
                    if (txtTaskDetails.Text != "") { strTaskTitle = txtTaskDetails.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Task Title.');", true); return; }
                    strPriority = "";
                    intStatusID = 1;
                    strStatus = "Not Started";
                    intCompletePer = 0;

                    //char[] chr = { '[', ']' };
                    //string[] temp1 = txtAssignBy.Text.Split(chr, StringSplitOptions.RemoveEmptyEntries);
                    //try { intAssignBy = int.Parse(temp1[1].ToString()); }
                    //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Assign By.');", true); return; }

                    intAssignBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intAssignTo = 0;
                    dteStart = DateTime.Parse(strDate.ToString());
                    try { dteDeadline = DateTime.Parse(txtDeadline.Text); }
                    catch { dteDeadline = DateTime.Parse(strDate.ToString()); }

                    dteComplete = DateTime.Parse(strDate.ToString());
                    strRemarks = "";
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intReffID  = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    dteDate = DateTime.Parse(strDate.ToString());
                    strDescription = "";
                    xml = "";

                    //dteDeadlineTime = "";
                    dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm));

                    //Final Insert
                    string message = objtask.InsertTask(intWork, strTaskTitle, strPriority, intStatusID, strStatus, intCompletePer, intAssignBy, intAssignTo, dteStart, dteDeadline, dteComplete, strRemarks, intInsertBy, intReffID, dteDate, strDescription, xml, strTaskReffNo, dteDeadlineTime);
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            //int intPostB = 1;
            //HttpContext.Current.Session["intPBack"] = intPostB.ToString();
            //intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString()); 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {   
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                   
                    //Final Insert
                    string message = objtask.UpdateTaskCancel(intReffID);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            //int intPostB = 1;
            //HttpContext.Current.Session["intPBack"] = intPostB.ToString();
            //intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString()); 
        }


        protected void FinalUploadF()
        {
            if (hdnconfirm.Value == "5")
            {
                try
                {
                    string strDate = "1900-01-01";

                    intWork = 6;
                    if (txtTaskDetailsT.Text != "") { strTaskTitle = txtTaskDetailsT.Text; }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Task Title.');", true); return; }
                    strPriority = ddlPriority.SelectedItem.ToString();
                    intStatusID = 1;
                    strStatus = "Not Started";
                    intCompletePer = 0;

                    //strTaskReffNo = txtReff.Text;
                    strTaskReffNo = "";
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
                    strDescription = "";
                    dteDeadlineTime = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector2.Hour, TimeSelector2.Minute, TimeSelector2.Second, TimeSelector2.AmPm));

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
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }
            }

            //int intPostB = 1;
            //HttpContext.Current.Session["intPBack"] = intPostB.ToString();
            //intPBack = int.Parse(HttpContext.Current.Session["intPBack"].ToString()); 
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
        //** Gridview Document Upload End   

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
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

        protected void cbTaskReAssing_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTaskReAssing.Checked == true) 
            { 
                ForwardDiv.Visible = true;
                DeadlineChangeDiv.Visible = false;
                dt = objtask.GetTeamMemberList(int.Parse(hdnEnroll.Value));
                ddlAssignTo.DataTextField = "strEmployeeName";
                ddlAssignTo.DataValueField = "intEmployeeID";
                ddlAssignTo.DataSource = dt;
                ddlAssignTo.DataBind();
                ddlAssignTo.Visible = false;
                cbMyTeam.Checked = false;
                txtSearchAssignedTo.Visible = true;
            }
            else
            {
                ForwardDiv.Visible = false;
                DeadlineChangeDiv.Visible = true;
                dgvReport.DataSource = "";
                dgvReport.DataBind();
                img.ImageUrl = "ftp://erp:erp123@ftp.akij.net/AJMLEmployeePhoto/default.jpg";
                txtSearchAssignedTo.Text = "";
            }
        }




















    }
}