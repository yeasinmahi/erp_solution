using Flogging.Core;
using GLOBAL_BLL;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class PoDocAttachmentDetalis : BasePage
    {
        private DataTable dt = new DataTable();
        private PoGenerate_BLL objPo = new PoGenerate_BLL();
        private string dfile, xmlData;

        private SeriLog log = new SeriLog();
        private string location = "SCM";
        private string start = "starting SCM\\PoDocAttachmentDetalis";
        private string stop = "stopping SCM\\PoDocAttachmentDetalis";
        private string perform = "Performance on SCM\\PoDocAttachmentDetalis";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string unit = Request.QueryString["unit"].ToString();
                string PoId = Request.QueryString["PoId"].ToString();
                string BillAmount = Request.QueryString["BillAmount"].ToString();
                int BillId = int.Parse(Request.QueryString["BillId"].ToString());
                string BillCode = Request.QueryString["BillCode"].ToString();

                lblUnit.Text = unit;
                lblBillAmount.Text = BillAmount;
                lblPoId.Text = PoId;
                lblBillId.Text = BillId.ToString();
                lblBillReg.Text = BillCode;

                dt = objPo.GetPoData(27, "", 0, 0, DateTime.Now, Enroll);
                ddlFileGroup.DataSource = dt;
                ddlFileGroup.DataTextField = "strName";
                ddlFileGroup.DataValueField = "Id";
                ddlFileGroup.DataBind();

                dt = objPo.GetPoData(28, "", 0, BillId, DateTime.Now, Enroll);
                dgvDocument.DataSource = dt;
                dgvDocument.DataBind();
            }
            else
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnSubmit_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnSubmit_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                try { File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString()); } catch { }
                string BillId = Request.QueryString["BillId"].ToString();
                string entryType = ddlFileGroup.SelectedValue.ToString();
                string remarks = txtNote.Text.ToString();
                string billCode = Request.QueryString["BillCode"].ToString();
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    var FileExtension = Path.GetExtension(userPostedFile.FileName).Substring(1);
                    xmlData = "<voucher><voucherentry BillId=" + '"' + BillId + '"' + " entryType=" + '"' + entryType + '"' + " remarks=" + '"' + remarks + '"' + " billCode=" + '"' + billCode + '"' + " FileExtension=" + '"' + FileExtension + '"' + "/></voucher>".ToString();
                    string msg = objPo.PoApprove(29, xmlData, 0, int.Parse(BillId), DateTime.Now, Enroll);
                    int fileId = int.Parse(msg);
                    if (fileId > 0)
                    {
                        dfile = fileId.ToString() + "." + FileExtension;

                        userPostedFile.SaveAs(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
                        FileUploadFTP(Server.MapPath("~/SCM/Uploads/"), dfile.ToString(), "ftp://ftp.akij.net/ERP_FTP/", "erp@akij.net", "erp123");
                        File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
                        xmlData = "<voucher><voucherentry BillId=" + '"' + BillId + '"' + " entryType=" + '"' + entryType + '"' + " remarks=" + '"' + remarks + '"' + " billCode=" + '"' + billCode + '"' + "/></voucher>".ToString();

                        string msgs = objPo.PoApprove(30, xmlData, 0, fileId, DateTime.Now, Enroll);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msgs + "');", true);
                        dt = objPo.GetPoData(28, "", 0, int.Parse(BillId), DateTime.Now, Enroll);
                        dgvDocument.DataSource = dt;
                        dgvDocument.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnSubmit_Click Uplaod", ex);
                Flogger.WriteError(efd);
                File.Delete(Server.MapPath("~/SCM/Uploads/") + dfile.ToString());
            }

            fd = log.GetFlogDetail(stop, location, "btnSubmit_Click Uplaod", null);
            Flogger.WriteDiagnostic(fd);
            // ends

            tracker.Stop();
        }

        protected void btnDocView_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnDocView_Click", null);
            Flogger.WriteDiagnostic(fd);
            var tracker = new PerfTracker(perform + " " + "btnDocView_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string filePatht = searchKey[0];
                string image = "ftp://erp:erp123@ftp.akij.net/" + filePatht;

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ImageName"),
                new DataColumn("ImageUrl"),
                new DataColumn("ZoomImageUrl")
                });
                dt.Rows.Add(image, image);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnDocView_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnDocView_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends

            tracker.Stop();
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