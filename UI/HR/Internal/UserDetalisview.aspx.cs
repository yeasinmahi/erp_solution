using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Internal;
using System.Web.Services;
using UI.ClassFiles;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;


namespace UI.HR.Internal
{
    public partial class UserDetalisview : System.Web.UI.Page
    {
        internaltranfer objDetalis = new internaltranfer();
        DataTable requestview = new DataTable();
        DataTable mainreq = new DataTable();
        int intPart; int empto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string description = "0".ToString();
                Int32 empto = Int32.Parse("0".ToString());
                string path = "0".ToString();
                hdnstatus.Value = "Approved";

                Int32 subject = Convert.ToInt32(Session["intID"].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                intPart = 3;
                requestview = objDetalis.RequestDetalisView(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                dgvViewRequest.DataSource = requestview;
                dgvViewRequest.DataBind();
                intPart = 10;
                mainreq = objDetalis.MainrequestDgv(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                dgvMainRequest.DataSource = mainreq;
                dgvMainRequest.DataBind();
                if (mainreq.Rows.Count > 0) { lblSubject.Text = mainreq.Rows[0]["strSubJect"].ToString(); lblBill.Text = mainreq.Rows[0]["monTotalBill"].ToString(); }

            }


        }

        protected void BtnDownload_Click(object sender, EventArgs e)
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
            string ftpFolder = "InternalApproval/";

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
            catch { };
            //**********************************************************************


        }

        protected void BtnDownload_Click1(object sender, EventArgs e)
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
            string ftpFolder = "InternalApproval/";

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
            catch { };
            //*****************************
        }
    }
}