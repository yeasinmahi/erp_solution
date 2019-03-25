using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static void ImageCompress(this Stream stream, float newWidth,  string destinationPath)
        {
            using (var image = Image.FromStream(stream))
            {
                int height = image.Height;
                int width = image.Width;
                float sngRatio = ((float)width / height);
                //float newWidth = 600; // New Width of Image in Pixel  
                float newHeight = newWidth / sngRatio; // New Height of Image in Pixel  
                var thumbImg = new Bitmap((int)newWidth, (int)newHeight);
                var thumbGraph = Graphics.FromImage(thumbImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imgRectangle = new Rectangle(0, 0, (int)newWidth, (int)newHeight);
                thumbGraph.DrawImage(image, imgRectangle);
                thumbImg.Save(destinationPath, image.RawFormat);
            }

        }
        public static void ImageCompress(this Stream stream, string destinationPath)
        {
            using (var image = Image.FromStream(stream))
            {
                int height = image.Height;
                int width = image.Width;
                float sngRatio = ((float)width / height);
                float newWidth = 600; // New Width of Image in Pixel  
                float newHeight = newWidth / sngRatio; // New Height of Image in Pixel  
                var thumbImg = new Bitmap((int)newWidth, (int)newHeight);
                var thumbGraph = Graphics.FromImage(thumbImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imgRectangle = new Rectangle(0, 0, (int)newWidth, (int)newHeight);
                thumbGraph.DrawImage(image, imgRectangle);
                thumbImg.Save(destinationPath, image.RawFormat);
            }

        }
    }
}
