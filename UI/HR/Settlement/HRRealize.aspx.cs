using HR_BLL.Settlement;
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

namespace UI.HR.Settlement
{
    public partial class HRRealize : BasePage
    {
        HRClass objhr = new HRClass(); SelfClass objs = new SelfClass();
        GlobalClass obj = new GlobalClass();
        DataTable dt;

        int intSVID; int intEnroll; decimal monAmount; string strRemarks;
        int intJobStationID; int intPart; int intUnitID;
        int intApproveBy; DateTime dteSeparateDateTime; DateTime dteLastOfficeDate;
        DateTime dteLastOfficeDateByUser; DateTime dteLastOfficeDateByAuthority; string strSeparateReason;
        int intSeparateInsertBy; int intSeparateType; string strEmailAdd; string strCurrentAddress;
        int ysnBenifit; string strDocUploadPath; string strFilePath; int intSeparationID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { pnlUpperControl.DataBind(); hdnconfirm.Value = "0"; }
            else
            {
                if (hdnconfirm.Value == "1") { HRRealizeResign(); }
                else if (hdnconfirm.Value == "2") { FTPUpload(); }
                    
            } 
            LoadGrid(); 
        }
        private void LoadGrid()
        {
            intSVID = int.Parse(Session[SessionParams.USER_ID].ToString());
            intPart = 5;

            dt = new DataTable();
            dt = obj.GetReportForAllUpdate(intPart, intSVID, intUnitID);
            dgvReport.DataSource = dt;
            dgvReport.DataBind();
        }

        public string FilterControlsHRRealizeResign(string empcode, string enroll, string empname, string designation, string salary, string resignDate, string lastdate, string lastdateuser, string lastdateAuthority, string separateName, string reason, string ysnBenifit)
        { return "FilterControlsHRRealizeResign('" + empcode + "','" + enroll + "','" + empname + "','" + designation + "','" + salary + "','" + resignDate + "','" + lastdate + "','" + lastdateuser + "','" + lastdateAuthority + "','" + separateName + "','" + reason + "','" + ysnBenifit + "')"; }

        public string FilterControlsHRRealizeResignDocUp(string enroll, string intID)
        { return "FilterControlsHRRealizeResignDoc('" + enroll + "','" + intID + "')"; }


        private void HRRealizeResign()
        {

            if (hdnconfirm.Value == "1")
            {
                try
                {
                    if (txtDeductSalary.Text == "")
                    {
                        monAmount = 0;
                    }
                    else
                    {
                        monAmount = decimal.Parse(txtDeductSalary.Text);
                    }

                    intPart = 7;
                    if (ddlRemarks.Text == "1") { strRemarks = "Perfectly handover job responsibility"; }
                    else if (ddlRemarks.Text == "2") { strRemarks = "Handover partial job responsibility"; }
                    else if (ddlRemarks.Text == "3") { strRemarks = "Lackings of Departmental head job handover cannot check properly"; }

                    intEnroll = int.Parse(hdnID.Value);

                    //Here : intSeparateType = ysnBenifit
                    if (CheckBox1.Checked == true) { intSeparateType = 1; } else { intSeparateType = 0; }

                    intApproveBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    dteLastOfficeDateByAuthority = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteLastOfficeDateByUser = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    dteSeparateDateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

                    strEmailAdd = txtOthersAmount.Text;
                    strCurrentAddress = txtReasonOfOtherAmount.Text;

                    objs.InsertResign(intPart, intEnroll, dteSeparateDateTime, dteLastOfficeDate, dteLastOfficeDateByUser, dteLastOfficeDateByAuthority, strSeparateReason, intSeparateInsertBy, intSeparateType, intApproveBy, monAmount, strRemarks, strEmailAdd, strCurrentAddress);
                    LoadGrid();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ClearControlsHRRealize();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('HR Realize Successfully.');", true);
                }
                catch { }

            }
        }

        protected void FTPUpload()//object sender, EventArgs e)
        {
            intEnroll = int.Parse(hdnID.Value);
            intSeparationID = int.Parse(hdnSeprationID.Value);
            strDocUploadPath = txtDocUpload.FileName.ToString();
            strDocUploadPath = hdnID.Value + "_" + strDocUploadPath;

            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
            string fileName = hdnID.Value + "_" + Path.GetFileName(txtDocUpload.PostedFile.FileName);
            txtDocUpload.PostedFile.SaveAs(Server.MapPath("~/HR/Settlement/Uploads/") + fileName);
            FileUploadFTP(Server.MapPath("~/HR/Settlement/Uploads/"), fileName, "ftp://ftp.akij.net/HRDocumentForSeparation/", "erp@akij.net", "erp123");
            File.Delete(Server.MapPath("~/HR/Settlement/Uploads/") + fileName);
            //lblMessage.Text += fileName + " Uploaded.<br />";

            strFilePath = strDocUploadPath;

            obj.InsertDocPath(intEnroll, strFilePath, intSeparationID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Document Upload Successfully.');", true);

            Response.Redirect(Request.Url.AbsoluteUri);
            #endregion

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


















    }
}