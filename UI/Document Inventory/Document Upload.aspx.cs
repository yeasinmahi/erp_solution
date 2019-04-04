 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Document_Inventory;
using System.Data;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using UI.ClassFiles;
using HR_BLL.Global;
using System.Text.RegularExpressions;
using GLOBAL_BLL;


namespace UI.Document_Inventory
{
    
    public partial class Document_Upload : BasePage
    {
        documentupload bll = new documentupload();
        DataTable check = new DataTable();
        DataTable data = new DataTable();  
        DataTable dt = new DataTable();
        DataTable employee = new DataTable();
        DocumentUpload_BLL objDocUp = new DocumentUpload_BLL();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dt = bll.DocumentAtachmentType();
                drdlAttachType.DataSource = dt;
                drdlAttachType.DataTextField = "TypeName";
                drdlAttachType.DataValueField = "intId";

                drdlAttachType.DataBind();

                pnlUpperControl.DataBind();
                hdnField.Value = "0";//lbldoc.Text = "";
                HiddenField9.Value= "0";
                int intenroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int depertmentid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());

                PolicyGrid();           
            
                
                if (depertmentid ==14 || depertmentid == 242)
                {


                    txtEnroll.ReadOnly = false;
                }
                else
                {
                    data = bll.loadpageInfo(intenroll);
                    if (data.Rows.Count > 0)
                    {
                        TxtEmployee.Text = data.Rows[0]["strEmployeeName"].ToString();
                        TxtDesignation.Text = data.Rows[0]["strDesignation"].ToString();
                        TxtUnit.Text = data.Rows[0]["strUnit"].ToString();
                        txtEnroll.Text = data.Rows[0]["intEmployeeID"].ToString();
                        TxtDepartment.Text = data.Rows[0]["strDepatrment"].ToString();
                    }
                    txtEnroll.ReadOnly = true;
                    TxtDepartment.ReadOnly = true;
                }
            }
            else
            {
                if (hdnField.Value != "0")
                {
                    btnSave_Click();
                    //lbldoc.Text = message;


                }
                if(HiddenField9.Value!="0")
                {
                    btnPolicySave_Click();
                }
            }
        }

        private void PolicyGrid()
        {
            try
            {
                ApplicationType atp = new ApplicationType();
                DataTable et = new DataTable();
                et = atp.GetPolicyDocument(1, "", "", "", "", 0);
                {
                    GridViewPolicy.DataSource = et;
                    GridViewPolicy.DataBind();
                }
            }
            catch { }
        }

        private void btnPolicySave_Click()
        {
            try
            {
                int actionby = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                string deptname = TxtPolicyDept.Text.ToString();
                string version = TxtVersion.Text.ToString();
                string policyname = TxtPolicy.Text.ToString();
                string Dfile = Path.GetFileName(FileUpload2.PostedFile.FileName);
                //-------- Save To Database ------------
                ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
                dt = atp.GetPolicyDocument(0, policyname, deptname, version, Dfile, actionby);
                string msg = dt.Rows[0]["strPolicyName"].ToString();
                string[] searchKey = Regex.Split(msg, ";");
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Document Inventory/Document Upload") + searchKey[1].ToString());
                FileUploadFTP(Server.MapPath("~/Document Inventory/Document Upload"), searchKey[1].ToString(), "ftp://ftp.akij.net/Policy/", "erp@akij.net", "erp123");
                File.Delete(Server.MapPath("~/Document Inventory/Document Upload") + searchKey[1].ToString());
                PolicyGrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + searchKey[0].ToString() + "');", true);
            }
            catch { }
        }

        private void btnSave_Click()
        {         

            int intUnitId = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
            int intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int intjobId = int.Parse("3".ToString());
            int enroll = int.Parse(txtEnroll.Text.ToString());
            string documenttype = drdlAttachType.SelectedItem.Text.ToString();
            int docid = int.Parse(drdlAttachType.SelectedValue.ToString());
            int depertmentid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
            int unitid = int.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
           
            string deptname = TxtDepartment.Text.ToString(); 

                string Dfile = enroll + "-" + deptname + "-" + documenttype + "-" + Path.GetFileName(DUpload.PostedFile.FileName);
                decimal length = Dfile.Length;
                string path = "/HR & Admin/" + Dfile;
                check = bll.checkpathdata(path);

                if (check.Rows.Count > 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Allready inserted ');", true);
                }
                else
                {

                Stream strm = DUpload.PostedFile.InputStream;
                string FileExtension = Dfile.Substring(Dfile.LastIndexOf('.') + 1).ToLower();

                if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                {
                    objDocUp.ImageCompress(strm, Server.MapPath("~/Document Inventory/Document Upload") + Dfile);

                }
                else
                {
                    DUpload.PostedFile.SaveAs(Server.MapPath("~/Document Inventory/Document Upload") + Dfile);
                }
                string msg=bll.DocumnetUploadInsertData(enroll, documenttype, deptname, path, intEnroll, intUnitId, depertmentid,docid); 
           
                FileUploadFTP(Server.MapPath("~/Document Inventory/Document Upload"), Dfile, "ftp://ftp.akij.net/HR & Admin/", "erp@akij.net", "erp123");

                File.Delete(Server.MapPath("~/Document Inventory/Document Upload") + Dfile);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + "');", true);

                 
                }
               
            }
            
   

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
             
            
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;
            
            //UploadFile;
            FileInfo fileInfo = new FileInfo(localPath +fileName);
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            

           
        }

       

        protected void txtEnroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEnroll.ReadOnly = false;
                Int32 enroll = Int32.Parse(txtEnroll.Text.ToString());

                employee = bll.Employeeinformation(enroll);
                if (employee.Rows.Count > 0)
                {
                    TxtEmployee.Text = employee.Rows[0]["strEmployeeName"].ToString();
                    TxtDesignation.Text = employee.Rows[0]["strDesignation"].ToString();
                    TxtDepartment.Text = employee.Rows[0]["strDepatrment"].ToString();
                    TxtUnit.Text = employee.Rows[0]["strUnit"].ToString();

                    TxtDepartment.ReadOnly = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data ');", true);
                }
            }
            catch { }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Int32 enroll = Int32.Parse(txtEnroll.Text.ToString());

            //DataTable download = new DataTable();
            //download = bll.DocumentAtachmentTypedownload();
            //GridView1.DataSource = download;
            //GridView1.DataBind();
        }

        protected void BtnPolicyView_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber4 = searchKey[0].ToString();
                    string ext = Path.GetExtension(searchKey[1].ToString());
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PloicyView.aspx');", true);
                    // Response.Write(ordernumber); 
                    //if ((ext != ".pdf") && (ext != ".doc") && (ext != ".docx") && (ext != ".txt") && (ext != ".xls") && (ext != ".xlsx"))
                    //{
                    //    Session["Rowid"] = ordernumber4;
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('PloicyView.aspx');", true);
                    //}
                    //else
                    //{
                    //    string strPathurl = Uri.EscapeUriString(searchKey[1].ToString());
                    //    string imageUrl = "ftp://erp:erp123@ftp.akij.net/Policy/" + strPathurl;
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewOthers('" + imageUrl + "');", true);
                    //}
                }
                catch { }
            }
        }

       
        }




       
    }





     
 
