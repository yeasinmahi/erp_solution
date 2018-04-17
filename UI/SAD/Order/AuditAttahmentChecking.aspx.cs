using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using UI.ClassFiles;
using SAD_BLL.Customer.Report;
namespace UI.SAD.Order
{
    public partial class AuditAttahmentChecking : BasePage
    {
        char[] delimiterChars = { '[',']' }; string strDate; string UNITS; string enrol1;
        string innerTableHtml = ""; 


        protected void Page_Load(object sender, EventArgs e)
        {
           


            DataTable dt = new DataTable();
            SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();

            if (!IsPostBack)
            {
                //pnlUpperControl.DataBind();
                ////---------xml----------
                try
                {


                    strDate = Session["Date"].ToString();
                    DateTime dtfrom = Convert.ToDateTime(strDate);
                    DateTime dtTo = Convert.ToDateTime(strDate);
                    UNITS = Session["UNIT"].ToString();
                    int unit = int.Parse(UNITS);
                    enrol1 = Session["enrol1"].ToString();
                    int enrol = int.Parse(enrol1);
                    int attahtype = int.Parse(Session["atttp"].ToString());
                    dt = bll.getAttachmentWithCategory(unit, dtfrom, dtTo, enrol, attahtype);
                    try
                    {

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string strPathurl =  Uri.EscapeUriString(dt.Rows[i]["strPathurl"].ToString());
                                string url = "ftp://erp:erp123@ftp.akij.net/TADAPictures/"+ strPathurl;
                                string imageUrl = url;//System.Web.HttpUtility.HtmlEncode(url); ;
                                innerTableHtml = innerTableHtml + @" <table border='0'>
                                <tr><td>"; innerTableHtml = innerTableHtml + @"<img src="+imageUrl+@" Height='350px' Width='350px'></td></tr></table>";
                            }
                            #region ------------ Filter Div By InnerHTML ---------------
                            System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                            new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            createDiv.ID = "createDiv";
                            createDiv.InnerHtml = innerTableHtml;
                            createDiv.Attributes.Add("class", "dynamicDivbn");
                            this.Controls.Add(createDiv);
                            #endregion                            
                        }
                    }

                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);

                    }


                }
                catch { }
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