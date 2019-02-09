﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Global;
using Purchase_BLL.SupplyChain;
using Utility;

namespace UI.Inventory
{
    public partial class SupplierDocView : Page
    {
        private readonly string ftp = "ftp://ftp.akij.net/SupplierDoc/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadGridView();
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);
                }

            }
        }

        protected void gridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = GridViewUtil.GetCurrentGridViewRow(gridView, e);
            string strPath = (row.FindControl("lblFtpPath") as Label)?.Text;
            string fileName = Path.GetFileName(strPath);
            if (e.CommandName == "View")
            {
                Session["src"] = ftp + strPath;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup",
                        "popup('../Other/DocumentView.aspx','Document View');", true);
            }
            else if (e.CommandName == "Download")
            {
                byte[] bytes = Downloader.DownloadFromFtp(ftp + strPath);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }

        protected void gridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDownload = e.Row.FindControl("btnDownload") as Button;
                Button btnView = e.Row.FindControl("btnView") as Button;
                ScriptManager.GetCurrent(this)?.RegisterPostBackControl(btnDownload);
                ScriptManager.GetCurrent(this)?.RegisterAsyncPostBackControl(btnView);
            }
        }
        private void LoadGridView()
        {
            int intSuppMasterId = Convert.ToInt32(Request.QueryString["intSuppMasterId"]);
            DataTable dt = new CSM().GetDocDetailsData(intSuppMasterId);
            
            gridView.DataSource = dt;
            gridView.DataBind();
        }
    }
}