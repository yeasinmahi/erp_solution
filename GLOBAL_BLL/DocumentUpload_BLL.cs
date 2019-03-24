using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOBAL_BLL
{
    public class DocumentUpload_BLL
    {
        public void ImageCompress(Stream strm, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(strm))
            {
                int height = image.Height;
                int width = image.Width;
                float sngRatio = ((float)width/height);
                float newWidth = 600; // New Width of Image in Pixel  
                float newHeight = newWidth / sngRatio; // New Height of Image in Pixel  
                var thumbImg = new Bitmap((int) newWidth, (int) newHeight);
                var thumbGraph = Graphics.FromImage(thumbImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imgRectangle = new Rectangle(0, 0, (int)newWidth, (int) newHeight);
                thumbGraph.DrawImage(image, imgRectangle);
                thumbImg.Save(targetPath, image.RawFormat);
            }
            
        }













    }
}
