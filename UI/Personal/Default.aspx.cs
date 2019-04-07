using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HR_BLL.User;
using HR_DAL.User;
using UI.ClassFiles;
using System.Globalization;
using HR_BLL.Global;
using HR_BLL.Document_Inventory;
using System.IO;
using System.Net;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace UI.Personal
{
    public partial class Default : BasePage
    {
        public UserInfoTDS.QryUserInfoShortDataTable table;
        DataTable dt; documentupload bll = new documentupload();
        protected string strinformation;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
            if (!IsPostBack)
            {
                hdnField.Value = "0";
                string jdate = DateTime.Parse(Session[SessionParams.APPOINTMENT_DATE].ToString()).ToString("dd/MM/yyyy");
                strinformation = @" <table class = 'tbldecoration' align='left' style='width:100%;'>
                    <tr class='captionGrid1'><td colspan='2' style='text-align: center;'> Personal Information </td></tr>

                    <tr style='font-size: 11px; font-weight: bold; background-color: #F0F0F0;'>
                    <td style='text-align: right;width:30%;'>Name : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.USER_NAME].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F8F8F8;'>
                    <td style='text-align: right;'>Unit : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.UNIT_NAME].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F0F0F0;'>
                    <td style='text-align: right;'>Department : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.DEPT_NAME].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F8F8F8;'>
                    <td style='text-align: right;'>Designation : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.DESIG_NAME].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F0F0F0;'>
                    <td style='text-align: right;'>Joining Date : </td>
                    <td style='text-align: left;'> " + jdate + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F8F8F8;'>
                    <td style='text-align: right;'>Email : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.EMAIL].ToString() + @"</td></tr>

                    <tr style='font-size: 11px; font-weight: bold; background-color: #F0F0F0;'>
                    <td style='text-align: right;'>Contactno : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.PHONE].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F8F8F8;'>
                    <td style='text-align: right;'>JobType : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.JOBTYPE_NAME].ToString() + @"</td></tr>
                    <tr style='font-size: 11px; font-weight: bold; background-color: #F0F0F0;'>
                    <td style='text-align: right;'>Supervisor : </td>
                    <td style='text-align: left;'> " + Session[SessionParams.Supervisor].ToString() + @"</td></tr>

                    <tr style='font-size: 11px; font-weight: bold; background-color: #F8F8F8;'>
                    <td style='text-align: right;'>Card Information : </td>
                    <td style='text-align: left;'> Code-" + Session[SessionParams.USER_CODE].ToString() + "<br/>Enroll-" +
                    Session[SessionParams.USER_ID].ToString() +@"</td></tr>
                    </table>";
                pnlpersonalinformation.DataBind();
                pnlUpperControl.DataBind();
                LoadGrid();
            }
            else
            {
                if (hdnField.Value == "1") { SaveDocument(); }
            }
        }

        private void LoadGrid()
        {
            ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
            dt = atp.GetDocumentList(int.Parse(Session[SessionParams.USER_ID].ToString()));
            if (dt.Rows.Count > 0) { dgvdoc.DataSource = dt; }
            else { dgvdoc.DataSource = ""; }
            dgvdoc.DataBind();

            dt = atp.GetPolicyDocument(1, "", "", "", "", int.Parse(Session[SessionParams.USER_ID].ToString()));
            if (dt.Rows.Count > 0) { dgvpolicy.DataSource = dt; }
            else { dgvpolicy.DataSource = ""; }
            dgvpolicy.DataBind();

        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;
            //UploadFile;
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
        private void SaveDocument()
        {
            try
            {
                int unitid = Int32.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                int enroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string documenttype = ddlist.SelectedItem.Text.ToString();
                int deptid = Int32.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                string deptname = HttpContext.Current.Session[SessionParams.DEPT_NAME].ToString();
                string Dfile = enroll + "-" + deptname + "-" + documenttype + "-" + Path.GetFileName(docUpload.PostedFile.FileName);
                decimal length = Dfile.Length;
                string path = "/HR & Admin/" + Dfile;
                dt = new DataTable();
                dt = bll.checkpathdata(path);
                if (dt.Rows.Count > 0) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision('Allready inserted');", true); }
                else
                {
                    string msg = bll.DocumnetUploadInsertData(enroll, documenttype, deptname, path, enroll, unitid, deptid, int.Parse(ddlist.SelectedValue.ToString()));
                    docUpload.PostedFile.SaveAs(Server.MapPath("~/Personal/Uploads/") + Dfile);
                    FileUploadFTP(Server.MapPath("~/Personal/Uploads/"), Dfile, "ftp://ftp.akij.net/HR & Admin/", "erp@akij.net", "erp123");
                    File.Delete(Server.MapPath("~/Personal/Uploads/") + Dfile); LoadGrid();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision('" + msg + "');", true);
                }
                
            }
            catch { }
        }
        public string ViewDocument(object Enroll, object DocumentType)
        {
            //string ext = Path.GetExtension(filepath.ToString());
            //if ((ext != ".pdf") && (ext != ".doc") && (ext != ".docx") && (ext != ".txt") && (ext != ".xls") && (ext != ".xlsx"))
            //{ return "ViewPolicy('" + id.ToString() + "','" + filepath.ToString() + "')"; }
            //else
            //{
            //    string strPathurl = Uri.EscapeUriString(filepath.ToString());
            //    string imageUrl = "ftp://erp:erp123@ftp.akij.net/Policy/" + strPathurl;
            //    return "ViewOthers('" + imageUrl + "')";
            //}
            
            return "ViewDocument('" + Enroll.ToString() + "','" + DocumentType.ToString() + "')"; 
        }
        public string ViewPolicy(object id, object filepath)
        {
            return "ViewPolicy('" + id.ToString() + "','" + filepath.ToString() + "')";
            //string ext = Path.GetExtension(filepath.ToString());
            //if ((ext != ".pdf") && (ext != ".doc") && (ext != ".docx") && (ext != ".txt") && (ext != ".xls") && (ext != ".xlsx"))
            //{ return "ViewPolicy('" + id.ToString() + "','" + filepath.ToString() + "')";  }
            //else
            //{
            //    string strPathurl = Uri.EscapeUriString(filepath.ToString());
            //    string imageUrl = "ftp://erp:erp123@ftp.akij.net/Policy/" + strPathurl;
            //    return "ViewOthers('" + imageUrl + "')";
            //}
            
        }

    }
}
