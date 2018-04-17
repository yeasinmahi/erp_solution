using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.KPI;
using System.Data;
using System.Net;
using System.IO;

namespace UI.HR.KPI
{
    public partial class ReportDetalisWorkplan_UI : System.Web.UI.Page
    {
        WorkPlan_BLL objPlan = new WorkPlan_BLL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int autoid = Convert.ToInt32(Session["intAutoID"].ToString());
                dt = objPlan.workplandetalisdata(autoid);
                if (dt.Rows.Count > 0)
                {
                    TxtDescription.Text = dt.Rows[0]["strWorkPlanDetalis"].ToString();
                    TxtSubject.Text = dt.Rows[0]["strSubject"].ToString();
                }


                dt = new DataTable();
                dt = objPlan.Workplandetalisdocumnetdata(autoid);
                dgvDocUp.DataSource = dt;
                dgvDocUp.DataBind();


            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
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
            string ftpFolder = "WorkPlanDocUpload/";

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



        }
    }
}