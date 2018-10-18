using System.IO;
using System.Net;

namespace Utility
{
    public class Downloader
    {
        public static byte[] DownloadFromFtp(string remoteLink)
        {
            //Create FTP Request.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteLink);
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

                byte[] bytes = stream.ToArray();
                return bytes;
            }

        }
    }
}
