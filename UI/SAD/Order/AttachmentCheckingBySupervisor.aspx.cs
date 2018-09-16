using Flogging.Core;
using GLOBAL_BLL;
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
    public partial class AttachmentCheckingBySupervisor : BasePage
    {

        char[] delimiterChars = { '[', ']' }; string strDate; string UNITS; string enrol1;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\AttachmentCheckingBySupervisor";
        string stop = "stopping SAD\\Order\\AttachmentCheckingBySupervisor";
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                ////---------xml----------
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on  SAD\\Order\\AttachmentCheckingBySupervisor Attachment Check in Suppervisor", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {


                    strDate = Session["Date"].ToString();
                    DateTime dtfrom = Convert.ToDateTime(strDate);
                    DateTime dtTo = Convert.ToDateTime(strDate);
                    UNITS = Session["UNIT"].ToString();
                    int unit = int.Parse(UNITS);
                    enrol1 = Session["enrol1"].ToString();
                    int enrol = int.Parse(enrol1);
                    int attahtype = 18;
                    dt = bll.getAttachmentWithCategory(unit, dtfrom, dtTo, enrol, attahtype);

                    try
                    {

                        if (dt.Rows.Count > 0)
                        {
                            grdvAttachmentCheckBySupervisor.DataSource = dt;
                            grdvAttachmentCheckBySupervisor.DataBind();
                        }
                        else
                        {
                        }
                   

                }
                catch { }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                }

                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();



                ////-----**----------//
            }
        }
        protected void btnDocDownload_Click(object sender, EventArgs e)
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
    }
}