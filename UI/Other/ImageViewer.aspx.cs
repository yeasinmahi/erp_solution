using System;
using System.Web.UI;
using Utility;

namespace UI.Other
{
    public partial class ImageViewer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["src"] != null)
            {
                var src = Session["src"].ToString();
                LoadImage(src);
            }
            else
            {
                Response.Write("<script>alert('If you want to see image you have to put image url toSession[src]');</script>");
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('If you want to see image you have to put image url toSession['ImageSrc'] ');", true);
            }
            
        }

        public void LoadImage(string src)
        {
            byte[] bytes = Downloader.DownloadFromFtp(src);
            image.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytes);
        }
    }
}