using HR_BLL.DocumentTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.DocumentTracking
{
    public partial class DocumentSearch : BasePage
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;

        int intPart, intID, intDocRegID, intApprovedBy, intRequiredBy; int intIssuedBy;
        string strSearch, strRequiredType, fileName;
        DateTime dteFromDate, dteRequiredDate, dteToDate, dteReturnDate; bool ysnApproved, ysnReturnable, ysnIssued;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {

            }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

            intPart = int.Parse(ddlSearchType.SelectedValue.ToString());
            strSearch = txtSearch.Text;
            dteFromDate = DateTime.Parse("2017-10-01");
            dteToDate = DateTime.Parse(DateTime.Now.ToString());
            

            try
            {
                dt = new DataTable();
                dt = obj.GetDTSReport(intPart, strSearch, dteFromDate, dteToDate);
                dgvDocReq.DataSource = dt;
                dgvDocReq.DataBind();
            }
            catch { }
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            intDocRegID = int.Parse(searchKey[0]);

            try
            {
                
               // fileName = "strFilePath";
            
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.akij.net/");
                ftpRequest.Credentials = new NetworkCredential("erp@akij.net", "erp123");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                List<string> directories = new List<string>();

                dt = new DataTable();
                dt = obj.GetFileName(intDocRegID);

            using (WebClient ftpClient = new WebClient())
            {
                ftpClient.Credentials = new System.Net.NetworkCredential("erp@akij.net", "erp123");

                    if (dt.Rows.Count > 0)
                    {
                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            string path = "ftp://ftp.akij.net/DocumentTracking/" + dt.Rows[index]["strFilePath"].ToString();
                            string trnsfrpth = @"C:/Users/"+ Environment.UserName +"/Documents/" + dt.Rows[index]["strFilePath"].ToString();
                            ftpClient.DownloadFile(path, trnsfrpth);

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Downloaded');", true);
                        }
                    }
                    
            }

            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There was an error.');", true); }

        }




    }
}