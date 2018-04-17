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
namespace UI.Document_Inventory
{
    public partial class PolicyUploadForAFBL :BasePage
    {
        documentupload bll = new documentupload();
        DataTable check = new DataTable();
        DataTable data = new DataTable();
        DataTable dt = new DataTable();
        DataTable employee = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
                

                dt = new DataTable();
                dt = bll.UnitName();
                DdlUnit.DataSource = dt;
                DdlUnit.DataTextField = "strUnit";
                DdlUnit.DataValueField = "intUNitID";
                DdlUnit.DataBind();
                int intunit=int.Parse(DdlUnit.SelectedValue.ToString());
                 dt = new DataTable();
                 dt = bll.PolicyTypeName(intunit);
                 DdlType.DataSource = dt;
                 DdlType.DataTextField = "TypeName";
                 DdlType.DataValueField = "intId";
                 DdlType.DataBind();

                pnlUpperControl.DataBind();
              //lbldoc.Text = "";
                HiddenField9.Value = "0";
                Int32 intenroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int depertmentid = Int32.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());

                PolicyGrid();


                
            }
            else
            {
                
                if (HiddenField9.Value != "0")
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
                int intunit = Int32.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                DataTable et = new DataTable();
                et = atp.GetPolicyDocumentView(3, "", "", "", "", 0, 0, intunit);
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
                int unitid = Int32.Parse(DdlUnit.SelectedValue.ToString());
                int typeid = int.Parse(DdlType.SelectedValue.ToString());
                string Dfile = Path.GetFileName(FileUpload2.PostedFile.FileName);
                //-------- Save To Database ------------
                ApplicationType atp = new ApplicationType(); DataTable dt = new DataTable();
                dt = atp.GetPolicyDocumentinsert(2, policyname, deptname, version, Dfile, actionby, typeid, unitid);
                string msg = dt.Rows[0]["strPolicyName"].ToString();
                string[] searchKeydata = Regex.Split(msg, ".;");
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Document Inventory/Document Upload") + searchKeydata[1].ToString());
                FileUploadFTP(Server.MapPath("~/Document Inventory/Document Upload"), searchKeydata[1].ToString(), "ftp://ftp.akij.net/Policy/", "said.dti@akij.net", "said09");
                File.Delete(Server.MapPath("~/Document Inventory/Document Upload") + searchKeydata[1].ToString());
                PolicyGrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + searchKeydata[0].ToString() + "');", true);
            }
            catch { }
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
                    Session["Rowid"] = ordernumber4.ToString();
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

        protected void DdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intunit = int.Parse(DdlUnit.SelectedValue.ToString());
            dt = new DataTable();
            dt = bll.PolicyTypeName(intunit);
            DdlType.DataSource = dt;
            DdlType.DataTextField = "TypeName";
            DdlType.DataValueField = "intId";
            DdlType.DataBind();

        }

    }
}