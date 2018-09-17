using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteAttachDocChecking : BasePage
    {

        char[] delimiterChars = { '[',']' }; string[] arrayKey;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\RemoteAttachDocChecking";
        string stop = "stopping SAD\\Order\\RemoteAttachDocChecking";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); hdnField.Value = "0";//lbldoc.Text = "";

            }
            else
            {
                if (hdnField.Value != "0")
                {
                    //btnSave_Click();
                    //lbldoc.Text = message;
                }
            }
        }

        protected void btnShowAttachment_Click(object sender, EventArgs e)
        {

            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on  SAD\\Order\\ChallanCancel Show Attendance", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
            string strSearchKey = txtFullName.Text;
            arrayKey = strSearchKey.Split(delimiterChars);
            string code = arrayKey[1].ToString();
            string TSOName = strSearchKey;
            string strDate = dteFromDate.ToString();
            Session["Date"] = strDate;
            DateTime dteTodate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
            string strTodate = dteTodate.ToString();
            Session["DateTodate"] = strTodate;
            int unit =int.Parse( drdlunit.SelectedValue.ToString());
            Session["UNIT"] = unit;
            string enrol = (HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int enrol1 = Convert.ToInt32(code);
            Session["ENROLL"] = enrol1;
            string attachmenttype = drdlAttachType.SelectedValue.ToString();
            Session["ATTACHTYPE"] = attachmenttype;


            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList();", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('RemoteTADADocChkPathlist.aspx');", true);
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

        protected void lnkDownload_Click(object sender, EventArgs e)
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
    }
}