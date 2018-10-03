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

namespace UI.SAD.Order
{
    public partial class UploadedReceiveChallanDetaills : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        SalesView bll = new SalesView();

        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string ENROLS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                try
                {

                    strDate = Session["Date"].ToString();
                    strTodate = Session["DateTodate"].ToString();
                    DateTime dtf = Convert.ToDateTime(strDate);
                    DateTime dtt = Convert.ToDateTime(strTodate);
                    UNITS = Session["UNIT"].ToString();
                    int unit = int.Parse(UNITS);
                    ENROLS = Session["ENROLL"].ToString();
                    int enrol1 = int.Parse(ENROLS);

                    dt = bll.GetReciveChallanDetInfo("", 0, "", enrol1, unit, dtf, 0, "", 0, 2, dtt, 0);
                    string msg = dt.Rows[0]["Messages"].ToString();



                    grdvReceiveChallanDownload.DataSource = dt;
                    grdvReceiveChallanDownload.DataBind();
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('List Empty.');", true); }

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
            string ftpFolder = "ChallanReceived/";

            try
            {
                //Create FTP Request.
                System.Net.FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
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
            //catch { };
        }
    }
}