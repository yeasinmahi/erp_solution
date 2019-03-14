using System;
using System.IO;
using System.Net;

namespace Utility
{
    public static class Downloader
    {
        public static byte[] DownloadFromFtp(this string remoteUrl)
        {
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteUrl);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //Enter FTP Server credentials.
            request.Credentials = new NetworkCredential("erp", "erp123");
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = false;
            try
            {
                //Fetch the Response and read it into a MemoryStream object.
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                using (MemoryStream stream = new MemoryStream())
                {
                    response.GetResponseStream()?.CopyTo(stream);

                    byte[] bytes = stream.ToArray();
                    return bytes;
                }
            }
            catch
            {
                return new byte[0];
            }

        }

        public static bool UploadToFtp(this string remoteLink, string localUrl)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("erp", "erp123");
                    client.UploadFile(remoteLink, WebRequestMethods.Ftp.UploadFile, localUrl);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            

        }
    }
}
