using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using UI.ClassFiles;
using QRCoder;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;

namespace UI.Accounts.PartyPayment
{
    public partial class QRCodePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string plBarCode = "APBML-B-Apr25-720";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(plBarCode, QRCodeGenerator.ECCLevel.Q);

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();

            imgBarCode.Height = 50;

            imgBarCode.Width = 50;

            using (Bitmap bitMap = qrCode.GetGraphic(20))

            {
                using (MemoryStream ms = new MemoryStream())

                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] byteImage = ms.ToArray();

                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                }
                //plBarCode.Controls.Add(imgBarCode);
            }
            plhQRCode.Controls.Add(imgBarCode);


        }













    }
}