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
    public partial class InternalApproval : BasePage
    {
        internaltranfer objapproval = new internaltranfer();
        DataTable dt = new DataTable();
        DataTable addnumber = new DataTable();

        int intPart; string dataname;  string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnField.Value = "0";
                TxtEmpAddress.Attributes.Add("onkeyUp", "SearchText();");
                //dt = objapproval.internaluserview();
                string subject = "0".ToString();
                string description = "0".ToString();
                Int32 empto = Int32.Parse("0".ToString());
                string path = "0".ToString();
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                //intPart = 12;
                intPart = 16;
                dt = objapproval.UserrRequestview(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                dgvStatus.DataSource = dt;
                dgvStatus.DataBind();
                pnlUpperControl.DataBind();
            }

            else
            {
                if (hdnField.Value != "0")
                {
                    btndocSave_Click();
                    //lbldoc.Text = message;
                }
            }
        }

        private void btndocSave_Click()
        {
            try
            {
                if (!String.IsNullOrEmpty(TxtEmpAddress.Text))
                {
                    string strSearchKey = TxtEmpAddress.Text;
                    string[] searchKey = Regex.Split(strSearchKey, ";");
                    hdfEmpCode.Value = searchKey[1];
                    Int32 empto= Int32.Parse(hdfEmpCode.Value.ToString());
                    decimal totalbill;
                   
                    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    string subject = TxtSubject.Text.ToString();
                    string description = TxtDescription.Text.ToString();
                    try {  totalbill = decimal.Parse(txtTotalAmount.Text.ToString()); }
                    catch {  totalbill = decimal.Parse(0.ToString()); }//**intUnit variable use for Total bill Amount**//
                    //******** Document Uplaod**********************//
                    string dte = DateTime.Now.ToString(".fffffff").ToString();

                    string dfile = empto+dte + Path.GetFileName(DUpload.PostedFile.FileName);

                    decimal length = dfile.Length;
                    
                     path =dfile;
                    
                    if (DUpload.PostedFile.FileName == "")
                    {
                        intPart = 14;
                        objapproval.ApprovalSubmitedInsert(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit,totalbill);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Approval Submited without Document ');", true);
                        TxtEmpAddress.Text = "";
                        TxtSubject.Text = "";
                        TxtDescription.Text = "";
                    }
                
                    else
                    {
                      
                            DUpload.PostedFile.SaveAs(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
                            FileUploadFTP(Server.MapPath("~/HR/Internal/Uploads/"), dfile, "ftp://ftp.akij.net/InternalApproval/", "erp@akij.net", "erp123");
                            File.Delete(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
                            intPart = 1;
                            objapproval.ApprovalSubmitedInsert(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit,totalbill);


                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Approval with Submited Document');", true);
                            TxtEmpAddress.Text = "";
                            TxtSubject.Text = "";
                            TxtDescription.Text = "";
                        
                    }
                    intPart = 16;
                    dt = objapproval.UserrRequestview(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                    dgvStatus.DataSource = dt;
                    dgvStatus.DataBind();
                }
            }
            catch { }
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

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

        [WebMethod]
        public static List<string> GetAutoCompleteData(string strSearchKey)
        {

            InternalAutoSearch_BLL objAutoSearch_BLL = new InternalAutoSearch_BLL();

            List<string> result = new List<string>();
           
            result = objAutoSearch_BLL.AutoSearchEmpData(strSearchKey);
            return result;





        }

        protected void BtnDetalisView_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intID"] = ordernumber1;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('UserDetalisview.aspx');", true);

                }
                catch { }
            }
        }
    }
}