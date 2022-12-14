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
    public partial class InternalApprovalDetalis : BasePage
    {
        internaltranfer objDetalis = new internaltranfer();
        DataTable requestview = new DataTable();
        DataTable mainreq = new DataTable();
        DataTable addnumber = new DataTable();
        int intPart; int empto;int rowid;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                string description = "0".ToString();
                Int32 empto = Int32.Parse("0".ToString());
                string path = "0".ToString();
                //TxtEmpAddress.Attributes.Add("onkeyUp", "SearchText();");

                Int32 subject = Convert.ToInt32(Session["intID"].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                intPart = 3;
                requestview = objDetalis.RequestDetalisView(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                dgvViewRequest.DataSource = requestview;
                dgvViewRequest.DataBind();
                intPart =10;
                mainreq = objDetalis.MainrequestDgv(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
                dgvMainRequest.DataSource = mainreq;
                dgvMainRequest.DataBind();
                if (mainreq.Rows.Count > 0) { lblSubject.Text = mainreq.Rows[0]["strSubJect"].ToString(); lblBill.Text = mainreq.Rows[0]["monTotalBill"].ToString(); }

                
            }

            else
            {
               // if (hdnApprove.Value == "1")
               // {
               //     btndocApproveSave_Click();
               //     //lbldoc.Text = message;
               // }
               //else if (HiddenForward.Value == "2")
               // {
               //     btndocForwardSave_Click();
               //     //lbldoc.Text = message;
                 
               // }
               //else if (HiddenReject.Value == "3")
               // {
               //     btndocRejectSave_Click();
               //     //lbldoc.Text = message;
               // }
               // else if (HiddenClose.Value == "4")
               // {
               //     btndocCloseSave_Click();
               //     //lbldoc.Text = message;
               // }
            }

        }


        //[WebMethod]
        //public static List<string> GetAutoCompleteData(string strSearchKey)
        //{

        //    InternalAutoSearch_BLL objAutoSearch_BLL = new InternalAutoSearch_BLL();

        //    List<string> result = new List<string>();
        //    //Int32 intjobid = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
        //    //Int32 wh = Int32.Parse(DdlWareHouse.SelectedValue.ToString());
        //    result = objAutoSearch_BLL.AutoSearchEmpData(strSearchKey);
        //    return result;





        //}
        //private void btndocCloseSave_Click()
        //{
        //    Int32 subject = Convert.ToInt32(Session["intID"].ToString());

        //    try
        //    {
        //        empto = Int32.Parse(hdfEmpCode.Value.ToString());
        //    }
        //    catch { empto = 0; }



        //    Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
        //    Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
        //    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        //    Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());

        //    string description = TxtDescription.Text.ToString();
           
       

        //    string dfile = empto + "_" + Path.GetFileName(DUpload.PostedFile.FileName);

        //    string path = dfile;
          
        //        intPart = 13;
        //        objDetalis.CloseRequest(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Close');", true);
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
          

        //}

        //private void btndocRejectSave_Click()
        //{
           
        //        Int32 subject = Convert.ToInt32(Session["intID"].ToString());
                
        //        try
        //        {
        //            empto = Int32.Parse(hdfEmpCode.Value.ToString());
        //        }
        //        catch { empto = 0; }



        //        Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
        //        Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
        //        Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        //        Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());

        //        string description = TxtDescription.Text.ToString();
        //        //******** Document Uplaod**********************//
               

        //        string dfile = empto + "_"  + Path.GetFileName(DUpload.PostedFile.FileName);

        //        string path = dfile;
        //        if (DUpload.PostedFile.FileName == "")
        //        {
        //            intPart = 8;
        //            objDetalis.RejectRequest(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Reject');", true);
        //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        //        }

        //        else
        //        {
        //            addnumber = objDetalis.countrowidtable(path);
        //            if (addnumber.Rows.Count > 0)
        //            {
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Change Documnet Name');", true);

        //            }
        //            else
        //            {
        //                DUpload.PostedFile.SaveAs(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                FileUploadFTP(Server.MapPath("~/HR/Internal/Uploads/"), dfile, "ftp://ftp.akij.net/InternalApproval/", "erp@akij.net", "erp123");
        //                File.Delete(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                intPart = 9;
        //                objDetalis.RejectRequestwithDocUpload(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Reject with Document Upload');", true);
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        //            }
        //        }



               

        //}

        //private void btndocForwardSave_Click()
        //{
        //        if (!String.IsNullOrEmpty(TxtEmpAddress.Text))
        //        {
        //            string strSearchKey = TxtEmpAddress.Text;
        //            string[] searchKey = Regex.Split(strSearchKey, ";");
        //            hdfEmpCode.Value = searchKey[1];
        //            Int32 subject = Convert.ToInt32(Session["intID"].ToString());
        //            empto = Int32.Parse(hdfEmpCode.Value.ToString());
                   
                  
                  

        //            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
        //            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
        //            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        //            Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    
        //            string description = TxtDescription.Text.ToString();
        //            //******** Document Uplaod**********************//
                  
        //            string dfile = empto + "_"  + Path.GetFileName(DUpload.PostedFile.FileName);
                   
        //            string path = dfile;
        //            if (DUpload.PostedFile.FileName== "")
        //            {
        //                intPart = 6;
        //                objDetalis.ForwardRequest(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Forward');", true);
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        //            }

        //            else
        //            {
        //                addnumber = objDetalis.countrowidtable(path);
        //                if (addnumber.Rows.Count > 0)
        //                {
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Change Documnet Name');", true);

        //                }
        //                else
        //                {
        //                    DUpload.PostedFile.SaveAs(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                    FileUploadFTP(Server.MapPath("~/HR/Internal/Uploads/"), dfile, "ftp://ftp.akij.net/InternalApproval/", "erp@akij.net", "erp123");
        //                    File.Delete(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                    intPart = 7;
        //                    objDetalis.ForwardRequestwithDocUpload(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Document Upload with Forward');", true);
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        //                }
                       
        //            }
                

                    
                 

        //  }
        //}

        //private void btndocApproveSave_Click()
        //{
        //    try
        //    {
            
        //            try{
        //             empto = Int32.Parse(hdfEmpCode.Value.ToString());
        //               }
        //            catch{empto=0;}
        //            Int32 subject = Convert.ToInt32(Session["intID"].ToString());


        //            Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
        //            Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
        //            Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
        //            Int32 intUnit = int.Parse(Session[SessionParams.UNIT_ID].ToString());
                    
        //            string description = TxtDescription.Text.ToString();
        //            //******** Document Uplaod**********************//
                   
        //            string dfile = empto + "_"  + Path.GetFileName(DUpload.PostedFile.FileName);
                   
        //            string path = dfile;
        //            if (DUpload.PostedFile.FileName== "")
        //            {
        //                intPart = 4;
        //                objDetalis.ApproveRequest(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Approved');", true);
                    
        //            }

        //            else
        //            {
        //                addnumber = objDetalis.countrowidtable(path);
        //                if (addnumber.Rows.Count > 0)
        //                {
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Change Documnet Name');", true);

        //                }
        //                else
        //                {
        //                    DUpload.PostedFile.SaveAs(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                    FileUploadFTP(Server.MapPath("~/HR/Internal/Uploads/"), dfile, "ftp://ftp.akij.net/InternalApproval/", "erp@akij.net", "erp123");
        //                    File.Delete(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
        //                    intPart = 5;
        //                    objDetalis.ApprovedRequestwithDocUpload(intPart, empto, subject, path, description, intenroll, intjobid, intdept, intUnit);
        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Document Upload With Approved');", true);
        //                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true); 
        //                }
                       
        //            }
                

                    
                    
        //        }
          
        //    catch { }
           
        //}

        //private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        //{
        //    FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
        //    requestFTPUploader.Credentials = new NetworkCredential(user, pass);
        //    requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

        //    FileInfo fileInfo = new FileInfo(localPath + fileName);
        //    FileStream fileStream = fileInfo.OpenRead();

        //    int bufferLength = 2048;
        //    byte[] buffer = new byte[bufferLength];

        //    Stream uploadStream = requestFTPUploader.GetRequestStream();
        //    int contentLength = fileStream.Read(buffer, 0, bufferLength);

        //    while (contentLength != 0)
        //    {
        //        uploadStream.Write(buffer, 0, contentLength);
        //        contentLength = fileStream.Read(buffer, 0, bufferLength);
        //    }

        //    uploadStream.Close();
        //    fileStream.Close();

        //    requestFTPUploader = null;

        //}

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
       


        }

        protected void BtnDetalisdownload_Click(object sender, EventArgs e)
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
       
        }
    }
}