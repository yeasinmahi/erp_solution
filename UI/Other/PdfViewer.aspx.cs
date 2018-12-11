using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace UI.Other
{
    public partial class PdfViewer : System.Web.UI.Page
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
                Response.Write("<script>alert('If you want to see image you have to put image url toSession[ImageSrc]');</script>");
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('If you want to see image you have to put image url toSession['ImageSrc'] ');", true);
            }
        }
        public void LoadImage(string src)
        {
            byte[] bytes = Downloader.DownloadFromFtp(src);
            embad.Src = "data:application/pdf;base64," + Convert.ToBase64String(bytes);
            //embad.Src = src;
        }
    }
}