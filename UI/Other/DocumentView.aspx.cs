using System;
using System.IO;
using Utility;

namespace UI.Other
{
    public partial class DocumentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["src"] != null)
            {
                var src = Session["src"].ToString();


                string ext = Path.GetExtension(src);
                if (ext.ToLower().Contains("pdf"))
                {
                    LoadPdf(src);
                }
                else if (ext.ToLower().Contains("png") || ext.ToLower().Contains("jpg") ||
                         ext.ToLower().Contains("jpeg") || ext.ToLower().Contains("gif") || ext.ToLower().Contains("bmp"))
                {
                    LoadImage(src);
                }
                else
                {
                    Response.Write("<script>alert('Unknown Extention');</script>");
                } 
            }
            else
            {
                Response.Write("<script>alert('If you want to see image you have to put image url toSession[ImageSrc]');</script>");
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('If you want to see image you have to put image url toSession['ImageSrc'] ');", true);
            }

        }
        public void LoadPdf(string src)
        {
            byte[] bytes = src.DownloadFromFtp();
            embad.Src = "data:application/pdf;base64," + Convert.ToBase64String(bytes);
        }
        public void LoadImage(string src)
        {
            byte[] bytes = src.DownloadFromFtp();
            image.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytes);
        }

    }
}