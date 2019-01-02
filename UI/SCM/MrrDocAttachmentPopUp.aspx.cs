using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class MrrDocAttachmentPopUp : System.Web.UI.Page
    {
        private MrrReceive_BLL obj = new MrrReceive_BLL();
        private DataTable dt = new DataTable();
        private int enroll, intWh, MrrId; private string dfile, xmlData;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\MrrDocAttachmentPopUp";
        private string stop = "stopping SCM\\MrrDocAttachmentPopUp";
        private string perform = "Performance on SCM\\MrrDocAttachmentPopUp";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                var tracker = new PerfTracker(perform + " " + "PageLoad", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    MrrId = int.Parse(Request.QueryString["MrrId"].ToString());
                    lblMrrNo.Text = MrrId.ToString();
                    dt = obj.DataView(13, "", intWh, MrrId, DateTime.Now, enroll);
                    if (dt.Rows.Count > 0)
                    {
                        lblChallan.Text = dt.Rows[0]["strExtnlReff"].ToString();
                        DateTime dtechallan = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                        lblChallanDate.Text = dtechallan.ToString("dd-MM-yyyy");
                        lblWH.Text = dt.Rows[0]["strWareHoseName"].ToString();
                        lblSupplier.Text = dt.Rows[0]["strSupplierName"].ToString();
                        DateTime dteMrr = DateTime.Parse(dt.Rows[0]["dteChallanDate"].ToString());
                        lblMrrDate.Text = dteMrr.ToString("dd-MM-yyyy");
                        lblUnitName.Text = dt.Rows[0]["strDescription"].ToString();
                        string unit = dt.Rows[0]["intUnitID"].ToString();
                        imgUnit.ImageUrl = "/Content/images/img/" + unit.ToString() + ".png".ToString();
                    }

                    getDocView();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "PageLoad", ex);
                    Flogger.WriteError(efd);
                }

                fd = log.GetFlogDetail(stop, location, "PageLoad", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
            }
            else { }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string filePath = searchKey[0];
            string fileName = filePath;

            //FTP Server URL.
            string ftp = "ftp://ftp.akij.net";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "ERP_FTP/";

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("erp", "erp123");
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;

                //Fetch the Response and read it into a MemoryStream object.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                using (MemoryStream stream = new MemoryStream())
                {
                    //Download the File.
                    response.GetResponseStream().CopyTo(stream);
                    Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(stream.ToArray());
                    Response.End();
                }
            }
            //catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }
            catch { };
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnView_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnView_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string filePath = searchKey[0];
                string image = "ftp://erp:erp123@ftp.akij.net/" + filePath;
                imageView.ImageUrl = image;
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnView_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnView_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        protected void btnMrr_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnMrr_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnMrr_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                MrrId = int.Parse(Request.QueryString["MrrId"].ToString());
                string FileExtension = Path.GetExtension(docUpload.PostedFile.FileName).Substring(1);
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                xmlData = "<voucher><voucherentry strFileName=" + '"' + txtName.Text.ToString() + '"' + " FileExtension=" + '"' + FileExtension + '"' + "/></voucher>".ToString();

                if (FileExtension.Length > 1)
                {
                    string msg = obj.MrrReceive(15, xmlData, intWh, MrrId, DateTime.Now, enroll);

                    string[] searchKey = Regex.Split(msg, ":");
                    string fileId = searchKey[1].ToString();

                    dfile = fileId.ToString() + "." + FileExtension;
                    docUpload.PostedFile.SaveAs(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
                    FileUploadFTP(Server.MapPath("~/SCM/Uploads/"), dfile.ToString(), "ftp://ftp.akij.net/ERP_FTP/", "erp@akij.net", "erp123");
                    File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + searchKey[0].ToString() + "');", true);
                    getDocView();
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnMrr_Click", ex);
                Flogger.WriteError(efd);
                File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
            }

            fd = log.GetFlogDetail(stop, location, "btnMrr_Click", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        private void getDocView()
        {
            var fd = log.GetFlogDetail(start, location, "getDocView", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "getDocView", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                MrrId = int.Parse(Request.QueryString["MrrId"].ToString());
                dt = obj.DataView(16, "", intWh, MrrId, DateTime.Now, enroll);
                dgvDocument.DataSource = dt;
                dgvDocument.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "getDocView", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "getDocView", null);
            Flogger.WriteDiagnostic(fd);
            tracker.Stop();
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
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
        }
    }
}