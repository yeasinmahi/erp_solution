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
    public partial class RmtTADAAttachDocPathlist : BasePage
    {
        DataTable dt = new DataTable();
        StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        //string strdate; string strTodate; string UNITS; string ENROLS;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string ENROLS; string attchid;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RmtTADAAttachDocPathlist";
        string stop = "stopping SAD\\Order\\RmtTADAAttachDocPathlist";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtTADAAttachDocPathlist TADA Doc Path List Show", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    strDate = Session["Date"].ToString();
                strTodate = Session["DateTodate"].ToString();
                UNITS = Session["UNIT"].ToString();
                int unit = int.Parse(UNITS);
                ENROLS = Session["ENROLL"].ToString();
                int enrol1 = int.Parse(ENROLS);
                attchid = Session["ATTAHCTYPEID"].ToString();
                int attch = int.Parse(attchid);
                DataTable dt = new DataTable();
                StatementC bll = new SAD_BLL.Customer.Report.StatementC();
                dt = bll.getAttachment(unit, strDate, strTodate, enrol1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
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

        protected void btnDocDownload_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\RmtTADAAttachDocPathlist TADA Doc  Dounload Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string filePath = searchKey[0];
            string fileName = filePath;

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
