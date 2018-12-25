using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using UI.ClassFiles;
using HR_BLL.Dispatch;
using SAD_BLL.Transport;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Dispatch
{
    public partial class Dispatch : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Dispatch/Dispatch.aspx";
        string stop = "stopping HR/Dispatch/Dispatch.aspx";

        DispatchBLL objdp = new DispatchBLL(); InternalTransportBLL obj = new InternalTransportBLL();
        
        DateTime dteDate; int intUnit; int intJobStation; string strNameAndAddress; string strSubject; string strRemarks;
        int intInsertBy; string fileName; string strDocUploadPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/Dispatch.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            if (!IsPostBack)
            {
                try { pnlUpperControl.DataBind(); txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");}
                catch { }
            }
            else if (hdnconfirm.Value == "3") { DispatchSubmit(); }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region ================== Dispatch Insert & Doc Upload =============================================
        protected void DispatchSubmit()
        {
            var fd = log.GetFlogDetail(start, location, "DispatchSubmit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/Dispatch.aspx DispatchSubmit", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "3")
            {
                try
                {
                    if (txtDocUpload.FileName.ToString() != "")
                    {
                        if (txtDocUpload.HasFiles)
                        {
                            foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                            {
                                strDocUploadPath = Path.GetFileName(uploadedFile.FileName);
                                fileName = strDocUploadPath.Replace(" ", "");
                                fileName = fileName.Trim();
                                fileName = fileName.Trim();
                                string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                                uploadedFile.SaveAs(Server.MapPath("~/HR/Dispatch/Data/") + fileName.Trim());
                            }
                        }
                    }
                    if (fileName != "" && fileName != null)
                    {
                        FileUploadFTP(Server.MapPath("~/HR/Dispatch/Data/"), fileName, "ftp://ftp.akij.net/ERP_HRDispatch/", "erp@akij.net", "erp123");
                    }

                    dteDate = DateTime.Parse(txtDate.Text);
                    intUnit = int.Parse(ddlUnit.SelectedValue.ToString());
                    intJobStation = int.Parse(ddlJobStation.SelectedValue.ToString());
                    strNameAndAddress = txtNameAndAddress.Text;
                    strSubject = txtSubject.Text;
                    strRemarks = txtRemarks.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);

                    //Final In Insert                        
                    string message = objdp.InsertDispatch(dteDate, intUnit, intJobStation, strNameAndAddress, strSubject, strRemarks, fileName, intInsertBy);
                    txtNameAndAddress.Text = "";
                    txtSubject.Text = "";
                    txtRemarks.Text = "";
                    hdnconfirm.Value = "0";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "DispatchSubmit", ex);
                    Flogger.WriteError(efd);
                }
            }

            fd = log.GetFlogDetail(stop, location, "DispatchSubmit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #endregion ==========================================================================================

        #region ================== File Upload To FTP =======================================================
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
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
                File.Delete(Server.MapPath("~/HR/Dispatch/Data/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion ==========================================================================================

        
    }
}







