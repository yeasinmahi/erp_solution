using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RmtAttchForNoEmialEmployee :BasePage
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey; string message; string path;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        DataTable objDT = new DataTable();
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RmtAttchForNoEmialEmployee";
        string stop = "stopping SAD\\Order\\RmtAttchForNoEmialEmployee";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnField.Value = "0";
                hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnJobstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            }
            else
            {
                if (hdnField.Value != "0")
                {
                    btnSave_Click();
                }
            }
        }

        private void btnSave_Click()
        {
            var fd = log.GetFlogDetail(start, location, "Save", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtAttchForNoEmialEmployee No Email Employee Save", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                string  strUnit = drdlUnit.SelectedValue.ToString();
            int unit = Convert.ToInt32(strUnit);
            string strSearckey = txtFullName.Text;
            arrayKey = strSearckey.Split(delimiterChars);
            string enrolst = arrayKey[1].ToString();
            int enrol = Convert.ToInt32(enrolst);
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            string dtbilldate = dteFromDate.ToString();
            string attachname = drdlAttachType.SelectedItem.ToString();
            int AttachemtTypeid = int.Parse(drdlAttachType.SelectedValue.ToString());
            hdnJobstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
            int jobstation = Convert.ToInt32(hdnJobstation.Value);
          
            try
            {

                string dte = "Doc_" + enrolst + "_" + DateTime.Now.ToString("yyyydd") + attachname + "." + Path.GetFileName(DUpload.PostedFile.FileName);
                string dfile = dte;
                decimal length = dfile.Length;
                path = dfile;


                DUpload.PostedFile.SaveAs(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                FileUploadFTP(Server.MapPath("~/SAD/Order/Data/OR/"), dfile, "ftp://ftp.akij.net/TADAPictures/", "erp@akij.net", "erp123");
                File.Delete(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                int intPart = 1;
                bll.getTADAAttachinsertion(dfile, length, path, enrol, unit, dteFromDate, AttachemtTypeid, jobstation, intPart);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Uploaded Bill docuement');", true);
               
                        
                
            }
            catch
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message + "');", true);

                //return message;
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Save", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Save", null);
            Flogger.WriteDiagnostic(fd);
            // ends
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

        protected void DownloadFile(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Download", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtAttchForNoEmialEmployee Download ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

            string fileName = (sender as LinkButton).CommandArgument;

            //FTP Server URL.
            string ftp = "ftp://ftp.akij.net/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "TADAPictures/";

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
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
            catch { }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }


        protected void btnShowAttachment_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtAttchForNoEmialEmployee Attachment Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            string strDate = dteFromDate.ToString();
            Session["Date"] = strDate;
            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string strTodate = dteTodate.ToString();
            Session["DateTodate"] = strTodate;
            string Unit = drdlUnit.SelectedValue.ToString();
            int unit = int.Parse(Unit);
            Session["UNIT"] = unit;
            string strSearckey = txtFullName.Text;
            arrayKey = strSearckey.Split(delimiterChars);
            string enrolst = arrayKey[1].ToString();
            int enrol1 = Convert.ToInt32(enrolst);
            Session["ENROLL"] = enrol1;
            string attchtype = drdlAttachType.SelectedValue.ToString();
            int attachid = int.Parse(attchtype);
            Session["ATTAHCTYPEID"] = attachid;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('RmtTADAAttachDocPathlist.aspx');", true);
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);

            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
    }
}