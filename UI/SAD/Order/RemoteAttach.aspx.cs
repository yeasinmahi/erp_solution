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

    public partial class RemoteAttach : BasePage
    {
        string message; string path;
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnField.Value = "0";//lbldoc.Text = "";

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
           



            try
            {
               
                Int32 unit = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
               
                Int32 enrol = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                string dtbilldate = dteFromDate.ToString();

                int AttachemtTypeid = int.Parse(drdlAttachType.SelectedValue.ToString());
                string attachname = drdlAttachType.SelectedItem.ToString();
              
                Int32 jobstation = Convert.ToInt32( HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                string curentdate = DateTime.Now.ToString(".fffffff").ToString();
                string dte = DateTime.Now.ToString(".fffffff").ToString();

                string dfile = enrol + attachname + dte + Path.GetFileName(DUpload.PostedFile.FileName);
                decimal length = dfile.Length;
                path = dfile;

              
                DUpload.PostedFile.SaveAs(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                FileUploadFTP(Server.MapPath("~/SAD/Order/Data/OR/"), dfile, "ftp://ftp.akij.net/TADAPictures/", "erp@akij.net", "erp123");
                File.Delete(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                Int32 intPart = 1;
                bll.getTADAAttachinsertion(dfile, length, path, enrol, unit, dteFromDate, AttachemtTypeid, jobstation, intPart);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Uploaded Bill docuement');", true);
               
                        


            }
            catch
            {
               
            }
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
            catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }

        }
        private void saveFileDialog1() { }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }


        protected void lnkDownload_Click(object sender, EventArgs e)
        {

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowAttachment_Click(object sender, EventArgs e)
        {




        }

    





        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;

            string strDate = dteFromDate.ToString();

            Session["Date"] = strDate;

            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            string strTodate = dteTodate.ToString();

            Session["DateTodate"] = strTodate;

            string hdUnit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
            int unit = int.Parse(hdUnit);
            Session["UNIT"] = unit;

            string enrol = (HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int enrol1 = Convert.ToInt32(enrol);
            Session["ENROLL"] = enrol1;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('TAandDADocPathList.aspx');", true);

        }










    }



}


    
