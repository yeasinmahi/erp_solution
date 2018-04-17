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
    public partial class RemoteTADADocChkPathlist : BasePage
    {
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string ENROLS; string ATTCHMENTTYPE;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                try
                {

                    strDate = Session["Date"].ToString();
                    DateTime dtfrom =Convert.ToDateTime( strDate);

                    strTodate = Session["DateTodate"].ToString();
                    DateTime dtTo = Convert.ToDateTime(strTodate);

                    UNITS = Session["UNIT"].ToString();
                    int unit = int.Parse(UNITS);
                    ENROLS = Session["ENROLL"].ToString();
                    int enrol1 = int.Parse(ENROLS);
                   
                    ATTCHMENTTYPE=  Session["ATTACHTYPE"].ToString();

                    int attachtyp=int.Parse(ATTCHMENTTYPE);

                    DataTable dt = new DataTable();
                    SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();


                    //dt = bll.getAttachment(unit, strDate, strTodate, enrol1);

                    dt = bll.getAttachmentWithCategory(unit, dtfrom, dtTo, enrol1, attachtyp);
                    
                    
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
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