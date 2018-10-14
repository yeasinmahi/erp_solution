using HR_BLL.CreativeSupport;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using Utility;

namespace UI.CreativeSupportModule
{
    public partial class CreativeSupportJobDetail : Page
    {
        CreativeS_BLL objcr = new CreativeS_BLL();
        DataTable dt;
        private string serverFolderPath;
        private string serverFilePath;
        private string fileName;
        int intPart, intJobID;
        protected void Page_Load(object sender, EventArgs e)
        {
            serverFolderPath = Server.MapPath("~/CreativeSupportModule/Data");
            if (!IsPostBack)
            {
                try
                {
                    intPart = 1;
                    intJobID = int.Parse(Request.QueryString["Id"]);

                    rdoLarge.Checked = false;
                    rdoMinor.Checked = false;
                    rdoModerate.Checked = false;
                    rdoLarge.Enabled = false;
                    rdoMinor.Enabled = false;
                    rdoModerate.Enabled = false;

                    dt = new DataTable();
                    dt = objcr.GetJobDetailsR(intPart, intJobID);
                    if (dt.Rows.Count > 0)
                    {
                        txtName.Text = dt.Rows[0]["AssignBy"].ToString();
                        txtRequiredDate.Text = dt.Rows[0]["dteRequiredDate"].ToString();
                        txtRequiredTime.Text = dt.Rows[0]["tmRequiredTime"].ToString();
                        txtPOID.Text = dt.Rows[0]["intPOID"].ToString();
                        txtSpecialAssignTo.Text = dt.Rows[0]["AssignTo"].ToString();
                        txtJobDesc.Text = dt.Rows[0]["strJobDescription"].ToString();
                        txtRemarks.Text = dt.Rows[0]["strRemarks"].ToString();

                        string strJobType = dt.Rows[0]["strJobType"].ToString();
                        if (strJobType == "Large")
                        {
                            rdoLarge.Checked = true;
                        }
                        else if (strJobType == "Moderate")
                        {
                            rdoModerate.Checked = true;
                        }
                        else if (strJobType == "Minor")
                        {
                            rdoMinor.Checked = true;
                        }
                    }

                    try
                    {
                        intPart = 2;
                        dt = objcr.GetJobDetailsR(intPart, intJobID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["strCreativeItemName"].ToString() != "")
                            {
                                dgvCrItem.DataSource = dt;
                                dgvCrItem.DataBind();
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        intPart = 3;
                        dt = objcr.GetJobDetailsR(intPart, intJobID);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["strFilePath"].ToString() != "")
                            {
                                dgvDocUp.DataSource = dt;
                                dgvDocUp.DataBind();
                            }
                        }
                    }
                    catch { }
                    try
                    {
                        intPart = 4;
                        dt = objcr.GetJobDetailsR(intPart, intJobID);
                        if (dt.Rows.Count > 0)
                        {

                            gvStatusDetails.DataSource = dt;
                            gvStatusDetails.DataBind();

                        }
                    }
                    catch { }
                }
                catch { }
            }
        }

        protected int totalqty = 0;
        protected int totalpoint = 0;
        protected void dgvCrItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalqty += int.Parse(((Label)e.Row.Cells[2].FindControl("lblQty")).Text);
                    totalpoint += int.Parse(((Label)e.Row.Cells[3].FindControl("lblPoint")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        protected void gvStatusDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Download")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvStatusDetails.Rows[rowIndex];
                    string strPath = (row.FindControl("lblDocFileName") as Label).Text;
                    if (string.IsNullOrWhiteSpace(strPath))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There are no file to download');", true);
                        return;
                    }
                    fileName = strPath;

                    //FTP Server URL.
                    string ftp = "ftp://ftp.akij.net/";

                    //FTP Folder name. Leave blank if you want to Download file from root folder.
                    string ftpFolder = "CreativeSupportModuleDoc/";

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
                            response.GetResponseStream()?.CopyTo(stream);
                            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.BinaryWrite(stream.ToArray());
                            Response.End();
                        }
                    }
                    catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse)?.StatusDescription); }
                }
                else if (e.CommandName == "DownloadAll")
                {

                    foreach (GridViewRow row in gvStatusDetails.Rows)
                    {
                        string strPath = (row.FindControl("lblDocFileName") as Label)?.Text;
                        if (string.IsNullOrWhiteSpace(strPath))
                        {
                            continue;
                        }
                        serverFilePath = $@"{serverFolderPath}\{"Attachment"}";

                        //FTP Server URL.
                        string ftp = "ftp://ftp.akij.net/CreativeSupportModuleDoc/";
                        string ftpPath = ftp + strPath;
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }
                        if (!Directory.Exists(serverFilePath))
                        {
                            //Directory.Delete(serverFilePath, true);
                            Directory.CreateDirectory(serverFilePath);
                        }
                        try
                        {
                            byte[] bytes = Downloader.DownloadFromFtp(ftpPath);
                            string filePath = $@"{serverFilePath}\{strPath}";
                            File.WriteAllBytes(filePath, bytes);
                        }
                        catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse)?.StatusDescription); }
                    }

                    Response.AddHeader("content-disposition", "attachment;filename=" + "Attachment.zip");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    Response.BinaryWrite(ZipHelper.CreateZip(serverFilePath));
                    Response.Flush();
                    FileHelper.DeleteFolder(serverFilePath);
                    Response.End();

                }
            }
            catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse)?.StatusDescription); }
        }

        protected void dgvDocUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvDocUp.Rows[rowIndex];
                string strPath = (row.FindControl("lblFileName") as Label).Text;
                if (e.CommandName == "View")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocument('" + strPath + "');", true);
                }
                else if (e.CommandName == "Download")
                {
                    string fileName = strPath;

                    //FTP Server URL.
                    string ftp = "ftp://ftp.akij.net/";

                    //FTP Folder name. Leave blank if you want to Download file from root folder.
                    string ftpFolder = "CreativeSupportModuleDoc/";

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
            catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }
        }














































    }
}