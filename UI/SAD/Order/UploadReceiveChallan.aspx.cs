using GLOBAL_BLL;
using SAD_BLL.Customer.Report;
using SAD_BLL.Sales;
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
    public partial class UploadReceiveChallan : System.Web.UI.Page
    {
        #region =========== Global Variable Declareation ==========
        int unit, enrol, AttachemtTypeid, jobstation, intPart, custid, rpttypes, intsertby;
        string strchallan, path, attachname, curentdate, dte, dfile, dtbilldate, msg;
        DateTime dteFromDate, todate;
        SalesView bll = new SalesView();
        StatementC bllst = new StatementC();
        DataTable dt = new DataTable();
        string xmlpath, email, strSearchKey, code, strCustname;
        decimal length;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                pnlMarque.DataBind();
                hdnField.Value = "0";//lbldoc.Text = "";
                txtFromDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(1));
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

                unit = Convert.ToInt32(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                enrol = Convert.ToInt32(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                DateTime dttodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                dtbilldate = dteFromDate.ToString();
                AttachemtTypeid = 99999;
                jobstation = Convert.ToInt32(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                curentdate = DateTime.Now.ToString(".fffffff").ToString();
                dte = DateTime.Now.ToString(".fffffff").ToString();
                attachname = Session["strCustname"].ToString();
                string subattach = attachname.Substring(0, 6);
                strchallan = txtReceiveChallan.Text.ToString();
                if (strchallan == "")
                {
                    strchallan = "990918101";
                }
                else
                {
                    strchallan = txtReceiveChallan.Text.ToString();
                }
                dfile = strchallan + subattach + "_" + Path.GetFileName(DUpload.PostedFile.FileName);
                length = dfile.Length;
                path = dfile;

                string Dfiles = DUpload.PostedFile.FileName;
                string FileExtension = Dfiles.Substring(Dfiles.LastIndexOf('.') + 1).ToLower();
                if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                {
                    DocumentUpload_BLL objDocUp = new DocumentUpload_BLL();
                    Stream strm = DUpload.PostedFile.InputStream;
                    objDocUp.ImageCompress(strm, Server.MapPath("~/SAD/Order/Data/OR/") + dfile);



                    DUpload.PostedFile.SaveAs(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                    FileUploadFTP(Server.MapPath("~/SAD/Order/Data/OR/"), dfile, "ftp://ftp.akij.net/ChallanReceived/", "erp@akij.net", "erp123");
                    File.Delete(Server.MapPath("~/SAD/Order/Data/OR/") + dfile);
                    intPart = 1;
                    custid = 0;
                    dt = bll.GetReciveChallanDetInfo(dfile, length, path, enrol, unit, dteFromDate, AttachemtTypeid, strchallan, jobstation, intPart, dttodate, custid);
                    msg = dt.Rows[0]["Messages"].ToString();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Messages"].ToString() + "');", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please  save as jpeg OR jpg or png format image ');", true);

                }
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
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void lnkDownload_Click(object sender, EventArgs e)
        {

        }
        protected void btnshowchallan_Click(object sender, EventArgs e)
        {
            string ch = txtReceiveChallan.Text.ToString();
            dt = bll.GetChallanDetInfo(ch, 4);
            if (dt.Rows.Count > 0)
            {
                lblCustname.Text = dt.Rows[0][0].ToString();
                lblChqntval.Text = dt.Rows[0][1].ToString();
                lblchdateval.Text = dt.Rows[0][2].ToString();
                lbldoval.Text = dt.Rows[0][3].ToString();
                strCustname = lblCustname.Text;
                Session["strCustname"] = strCustname;
            }

        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;

            string strDate = dteFromDate.ToString();

            Session["Date"] = strDate;

            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string strTodate = dteTodate.ToString();

            Session["DateTodate"] = strTodate;

            string hdUnit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
            int unit = int.Parse(hdUnit);
            Session["UNIT"] = unit;

            string enrol = (HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int enrol1 = Convert.ToInt32(enrol);
            Session["ENROLL"] = enrol1;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ReceiveChallanUploadDetaills.aspx');", true);

        }


    }
}