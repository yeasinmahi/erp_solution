<%@ WebHandler Language="C#" Class="ShowImgFTP" %>

using System;
using System.Web;

public class ShowImgFTP : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string path = context.Request.QueryString["path"];
        context.Response.ContentType = "image/png";

        AkijFTPConnector.FTP f = new AkijFTPConnector.FTP();
        f.FtpHost = "ftp.akij.net";
        f.UserName = "ftp@akij.net";
        f.Password = "ftp@123";
        f.Port = "21";
        f.Login();
        System.IO.MemoryStream ms = f.DownloadFileFromServerFoeWeb(path, "c:\\tt.png");

        if (ms != null)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();

            context.Response.ContentType = "image/png";
            context.Response.BinaryWrite(ms.GetBuffer());
        }
        ms.Close();

        f.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}