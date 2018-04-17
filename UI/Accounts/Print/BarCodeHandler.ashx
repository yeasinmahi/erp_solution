<%@ WebHandler Language="C#" Class="BarCodeHandler" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

public class BarCodeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        Bitmap bmpImage = new Bitmap(800, 228);
        
        Graphics g = Graphics.FromImage(bmpImage);
        g.FillRegion(new SolidBrush(Color.White), new Region());
        SolidBrush fgBrush = new SolidBrush(Color.Black);

        string handelerString = context.Request.QueryString["info"];
            //IDAutomationHC39M
        g.DrawString("*"+handelerString+"*", new Font("IDAutomationHC39M", 30, FontStyle.Regular), fgBrush, 0, 10);
        //g.DrawString("*cpjul1014t0740111*", new Font("IDAutomationHC39M", 16, FontStyle.Regular), fgBrush, 0, 10);
        // g.DrawString("*01670452866*", new Font("Code128bWin", 20), fgBrush, 0, 10);
        //g.SmoothingMode = SmoothingMode.AntiAlias;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        MemoryStream st = new MemoryStream();
      
        bmpImage.Save(st,System.Drawing.Imaging.ImageFormat.Png);

        context.Response.Clear();

        context.Response.ClearHeaders();

        context.Response.ClearContent();

        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(st.GetBuffer());
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }

}