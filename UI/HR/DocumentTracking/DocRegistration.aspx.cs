using HR_BLL.DocumentTracking;
using System;
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

namespace UI.HR.DocumentTracking
{
    public partial class DocRegistration : BasePage
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string fileName, strDocUploadPath, strFileName, xml, strDocumentCode, strDocumentInfo;
        int intID, intPart, intDocumentTypeID, intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, intInsertBy;

       

        DateTime? dteFrom, dteTo;

        protected void chkValidity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValidity.Checked == true)
            {
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                lblToDate.Visible = false;
                txtToDate.Visible = false;
            }
            else if (chkValidity.Checked == false)
            {
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;
                txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXMLDocUpload = Server.MapPath("~/HR/DocumentTracking/Data/DocUpload_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                                
                try
                {
                    dt = new DataTable();
                    dt = obj.GetDocumentTypeData();
                    ddlDocType.DataTextField = "TypeName";
                    ddlDocType.DataValueField = "intId";
                    ddlDocType.DataSource = dt;
                    ddlDocType.DataBind();
                }
                catch { }

                try
                {
                    dt = new DataTable();
                    dt = obj.GetDivisionData();
                    ddlDivision.DataTextField = "strDivision";
                    ddlDivision.DataValueField = "intDivisionID";
                    ddlDivision.DataSource = dt;
                    ddlDivision.DataBind();
                }
                catch { }

                try
                {
                    intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());

                    dt = new DataTable();
                    dt = obj.GetDeptData(intDivisionID);
                    ddlDepartment.DataTextField = "strDepartment";
                    ddlDepartment.DataValueField = "intDeptID";
                    ddlDepartment.DataSource = dt;
                    ddlDepartment.DataBind();
                }
                catch { }

                try
                {
                    intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());

                    dt = new DataTable();
                    dt = obj.GetSectionData(intDeptID);
                    ddlSection.DataTextField = "strSection";
                    ddlSection.DataValueField = "intSectionID";
                    ddlSection.DataSource = dt;
                    ddlSection.DataBind();
                }
                catch { }

                try
                {
                    dt = new DataTable();
                    dt = obj.GetLocationData();
                    ddlLocation.DataTextField = "strLocation";
                    ddlLocation.DataValueField = "intLocationID";
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataBind();
                }
                catch { }

                try
                {
                    intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());

                    dt = new DataTable();
                    dt = obj.GetFolderData(intLocationID);
                    ddlFolder.DataTextField = "strFolder";
                    ddlFolder.DataValueField = "intFolderID";
                    ddlFolder.DataSource = dt;
                    ddlFolder.DataBind();
                }
                catch { }


                chkValidity.Checked = true;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                lblToDate.Visible = false;
                txtToDate.Visible = false;
                
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
        }
        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetFolderData(intLocationID);
                ddlFolder.DataTextField = "strFolder";
                ddlFolder.DataValueField = "intFolderID";
                ddlFolder.DataSource = dt;
                ddlFolder.DataBind();
            }
            catch { }
        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetSectionData(intDeptID);
                ddlSection.DataTextField = "strSection";
                ddlSection.DataValueField = "intSectionID";
                ddlSection.DataSource = dt;
                ddlSection.DataBind();
            }
            catch { }
        }
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetDeptData(intDivisionID);
                ddlDepartment.DataTextField = "strDepartment";
                ddlDepartment.DataValueField = "intDeptID";
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataBind();
            }
            catch { }
        }
        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                ////string strDat = DateTime.Now.ToString("yyyy-MM-dd");

                if (txtDocUpload.FileName.ToString() != "")
                {
                    ////intDocType = 1;
                    ////strDocName = "Task Doc";
                    intID = int.Parse(hdnEnroll.Value);
                    ////try
                    ////{
                    ////    dteSubmitDate = DateTime.Parse(txtStartDate.Text);
                    ////    strSubmitDate = txtStartDate.Text;
                    ////}
                    ////catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return; }

                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = intID.ToString() + "_" + strDocUploadPath;
                           
                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            fileName = strDocUploadPath.Replace(" ", "");
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/HR/DocumentTracking/Uploads/") + fileName.Trim());
                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{
                            //    uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //}
                            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(strFileName);
                        }
                    }
                }

                hdnconfirm.Value = "0";

                #endregion

            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName);
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
            else { dgvDocUp.DataSource = ""; }
            dgvDocUp.DataBind();
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;

            node.Attributes.Append(StrFileName);
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

                File.Delete(Server.MapPath("~/HR/DocumentTracking/Uploads/") + fileName);
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
        
        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    intPart = 1;
                    intDocumentTypeID = int.Parse(ddlDocType.SelectedValue.ToString());
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                    intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());
                    intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());
                    intSectionID = int.Parse(ddlSection.SelectedValue.ToString());
                    intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());
                    intFolderID = int.Parse(ddlFolder.SelectedValue.ToString());
                    intInsertBy = int.Parse(hdnEnroll.Value);
                    strDocumentCode = txtDocCode.Text;
                    strDocumentInfo = txtDocInfo.Text;

                    if(strDocumentCode == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Inser Valid Document Code.');", true);
                        return;
                    }

                    try
                    {
                        dteFrom = DateTime.Parse(txtFromDate.Text);
                        dteTo = DateTime.Parse(txtToDate.Text);
                    }
                    catch { }

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
                            FileUploadFTP(Server.MapPath("~/HR/DocumentTracking/Uploads/"), fileName, "ftp://ftp.akij.net/DocumentTracking/", "erp@akij.net", "erp123");
                        }
                    }
                    else
                    {
                        intPart = 2;
                    }
                    

                    //Final Insert
                    string message = obj.InsertDTSDocReg(intPart, intDocumentTypeID, dteFrom, dteTo, intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, strDocumentCode, strDocumentInfo, intInsertBy, xml);

                    if (filePathForXMLDocUpload != null)
                    { File.Delete(filePathForXMLDocUpload); }
                    dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    hdnconfirm.Value = "0";
                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);                  
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again.');", true); }

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
                File.Delete(Server.MapPath("~/HR/DocumentTracking/Uploads/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }












    }
}