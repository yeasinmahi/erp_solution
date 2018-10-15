using HR_BLL.CreativeSupport;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Dairy_BLL;
using SAD_BLL.Transport;
using System.Text;
using System.Text.RegularExpressions;

namespace UI.CreativeSupportModule
{
    public partial class HoldFeedback : System.Web.UI.Page
    {
        CreativeSBll objcr = new CreativeSBll();
        DataTable dt;

        int intPart, intJobID, intJobStatusID;
        string filePathForXMLDocUpload, xmlStringDocUpload = "", xmlDoc;
        string strDocUploadPath, fileName, strFileName, strStatusRemarks, strStatus;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXMLDocUpload = Server.MapPath("~/CreativeSupportModule/Data/StausDocUpload_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    intPart = 1;
                    intJobID = int.Parse(Request.QueryString["Id"]);
                    hdnJobID.Value = intJobID.ToString();
                    hdnJobStatusID.Value = Request.QueryString["JobStatusID"];

                    dt = new DataTable();
                    dt = objcr.GetJobDetailsR(intPart, intJobID);
                    if (dt.Rows.Count > 0)
                    {
                        txtSender.Text = dt.Rows[0]["AssignBy"].ToString();
                        txtReceiver.Text = Session[SessionParams.USER_NAME].ToString();
                        txtJobDescription.Text = dt.Rows[0]["strJobDescription"].ToString();
                        txtStatus.Text = Request.QueryString["JobStatus"];
                        txtJobCode.Text = Request.QueryString["JobCode"];
                    }                   
                }
                catch { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
        }

        #region ===== Document Brows & Add In Gridview========================================

        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                if (txtWorkOrderUpload.FileName.ToString() != "")
                {
                    int intCount = 0;
                    if (txtWorkOrderUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtWorkOrderUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------

                            fileName = strDocUploadPath.Replace(" ", "");

                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + hdnEnroll.Value + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/CreativeSupportModule/Data/") + fileName.Trim());

                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{                               
                            //    uploadedFile.SaveAs(Server.MapPath("~/CreativeSupportModule/Data/") + fileName.Trim());                               
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
        protected void dgvDocUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                File.Delete(Server.MapPath("~/CreativeSupportModule/Data/") + fileName);
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

        #endregion ===========================================================================

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtRemarks.Text = "";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        }

        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    intPart = 1;
                    strStatus = txtStatus.Text;
                    if(txtRemarks.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Remarks canot be blank.');", true);
                        return;
                    }
                    strStatusRemarks = txtRemarks.Text;
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDocUpload);
                        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                        xmlStringDocUpload = dSftTm.InnerXml;
                        xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                        xmlDoc = xmlStringDocUpload;
                    }
                    catch { return; }

                    
                    if (dgvDocUp.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                        {
                            fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                            FileUploadFTP(Server.MapPath("~/CreativeSupportModule/Data/"), fileName, "ftp://ftp.akij.net/CreativeSupportModuleDoc/", "erp@akij.net", "erp123");
                        }
                    }

                    //Final In Insert
                    string message = objcr.UpdateJobStatus(intPart, int.Parse(hdnJobID.Value), int.Parse(hdnJobStatusID.Value), strStatus, strStatusRemarks, int.Parse(hdnEnroll.Value), xmlDoc);

                    hdnconfirm.Value = "0";
                    if (filePathForXMLDocUpload != null) { File.Delete(filePathForXMLDocUpload); }                    
                    dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #region ===== Document Upload Procedure ==============================================
        protected void DynamicUpload()
        {
            FileUploadFTP(Server.MapPath("~/CreativeSupportModule/Data/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
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
                File.Delete(Server.MapPath("~/CreativeSupportModule/Data/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion ===========================================================================









    }
}