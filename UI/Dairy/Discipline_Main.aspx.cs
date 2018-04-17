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
    public partial class Discipline_Main : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL(); Task_BLL objtask = new Task_BLL();
        DataTable dt;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strSubmitDate;

        string Unitid; int intID; string strCreatedOn; int intWork; int intInsertBy; string xml;
        int intEmpID; string strCaseName; string strDescription; int intCreatedBy; DateTime dteCreatedOn;
        DateTime dteDeadline; string strStatus; int intStatusID; int intActionID;
        int intUnitid; int intCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
            filePathForXMLDocUpload = Server.MapPath("~/Dairy/Data/DocUpDecipline_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();

                    dt = objtask.GetActionList();
                    ddlAction.DataTextField = "strAction";
                    ddlAction.DataValueField = "intActionID";
                    ddlAction.DataSource = dt;
                    ddlAction.DataBind();

                    LoadGrid(); 

                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    //pnlUpperControl.DataBind();

                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();
                }
                catch
                { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
        }

        private void LoadGrid()
        {
            try
            {                
                intWork = 1;
                intUnitid = int.Parse(Session[SessionParams.UNIT_ID].ToString());

                dt = new DataTable();
                dt = objtask.GetDisciplineReport(intWork, intUnitid);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblReportName.Text = "DISCIPLINE REPORT :";
                }
            }
            catch { }

        }

        protected void btnDocVew_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();

            intID = int.Parse(senderdata.ToString());
            intCount = 0;

            dt = new DataTable();
            dt = objtask.GetDocCount(intID);
            if (dt.Rows.Count > 0)
            {
                intCount = int.Parse(dt.Rows[0]["intDocCount"].ToString());
            }

            if (intCount > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocListView('" + senderdata + "');", true);
            }
            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There are no document.');", true); return; }
        }




        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                //********************************************************************************************
                String strDate = "1900-01-01";

                intWork = 1;
                
                char[] ch = { '[', ']' };
                string[] temp = txtEmployeeName.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                try { intEmpID = int.Parse(temp[1].ToString()); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Employee Name.');", true); return; }

                 
                strCaseName = txtCaseName.Text;
                strDescription = txtDescription.Text;
                
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtCreatedBy.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                try { intCreatedBy = int.Parse(temp1[1].ToString()); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Created By Name.');", true); return; }
                
                try { dteCreatedOn = DateTime.Parse(txtCreatedOn.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Created On Date.');", true); return; }
                try { dteDeadline = DateTime.Parse(txtDeadline.Text); }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Deadline.');", true); return; }

                strStatus = ddlStatus.SelectedItem.ToString();
                intStatusID = int.Parse(ddlStatus.SelectedValue.ToString());
                intActionID = int.Parse(ddlAction.SelectedValue.ToString());                
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

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
                        FileUploadFTP(Server.MapPath("~/Dairy/Uploads/"), fileName, "ftp://ftp.akij.net/DisciplineDocList/", "erp@akij.net", "erp123");

                    }
                }

                //intWork,intEmpID,strCase,strDescription,intCreatedBy,dteCreatedOn,dteDeadline,intStatusID,strStatus,intActionID,intInsertBy,xml

                //Final Insert
                string message = objtask.InsertTask(intWork, intEmpID, strCaseName, strDescription, intCreatedBy, dteCreatedOn, dteDeadline, intStatusID, strStatus, intActionID, intInsertBy, xml);

                txtEmployeeName.Text = "";
                txtCaseName.Text = "";
                txtDescription.Text = "";
                txtCreatedOn.Text = "";
                txtCreatedBy.Text = "";
                txtDeadline.Text = "";
                
                if (filePathForXMLDocUpload != null)
                { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

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

                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = 1;
                    strDocName = "Descipline Doc";
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        dteCreatedOn = DateTime.Parse(txtCreatedOn.Text);
                        strSubmitDate = txtCreatedOn.Text;
                        
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Created On Date Properly Input.');", true); return; }

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
                            if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            {
                                uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            }
                            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

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

















        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchEmployee(string prefixText, int count) 
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }































    }
}