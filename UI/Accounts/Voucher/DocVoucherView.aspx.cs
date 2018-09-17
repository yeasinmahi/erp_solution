﻿using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Voucher
{
    public partial class DocVoucherView : BasePage
    {
        string strPathurl;
        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Voucher\\DocVoucherView";
        string stop = "stopping Accounts\\Voucher\\DocVoucherView";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strPathurl = "VoucherUpload/" + Session["strPath"].ToString();

                if (strPathurl != "")
                {
                    strPathurl = Uri.EscapeUriString(strPathurl);
                    string imageUrl = "ftp://erp:erp123@ftp.akij.net/" + strPathurl;
                    myPanel.Controls.Add(new LiteralControl("<iframe class='frame' src='" + imageUrl + "'></iframe>"));


                   


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }

            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Voucher\\DocVoucherView   Show ", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                strPathurl = "VoucherUpload/"+Session["strPath"].ToString();
            string fileName = strPathurl;
            //FTP Server URL.
            string ftp = "ftp://ftp.akij.net/";



                try
                {
                    //Create FTP Request.
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + fileName);
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
                        //Download the File.
                        response.GetResponseStream().CopyTo(stream);
                        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(stream.ToArray());
                        Response.End();
                    }
                }
                catch { }
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();
                //**********************************************************************
            }
    }
}