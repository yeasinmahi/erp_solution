using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;

using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Net;
using Purchase_BLL.Qc_Management;

namespace UI.QC_Management
{
    public partial class QcResultEntry : BasePage
    {
        DataTable dtReport = new DataTable();
        QcBllManagement Report = new QcBllManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                int itemid = int.Parse(Session["itemid"].ToString());

                dtReport = Report.getItemAttributes(itemid);

                GridView1.DataSource = dtReport;
                GridView1.DataBind();

                Button1.Visible = false;
            }
            else
            {
                if (hdnApprove.Value == "1")
                {
                    btndocApproveSave_Click();

                }
            }


        }

        private void btndocApproveSave_Click()
        {


            string empto = (Session[SessionParams.USER_ID].ToString());
            string dfile = empto + "_" + Path.GetFileName(dupload.PostedFile.FileName);

            string path = dfile;




            dupload.PostedFile.SaveAs(Server.MapPath("~/HR/Internal/Uploads/") + dfile);
            FileUploadFTP(Server.MapPath("~/HR/Internal/Uploads/"), dfile, "ftp://ftp.akij.net/AFBLBrandPicture/", "erp@akij.net", "erp123");
                    File.Delete(Server.MapPath("~/HR/Internal/Uploads/") + dfile);

                    int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));

                    if (GridView1.Rows.Count > 0)
                    {

                        for (int index = 0; index < GridView1.Rows.Count; index++)
                        {


                            string itemidss = ((Label)GridView1.Rows[index].FindControl("lblintid")).Text.ToString();
                            string itemid = ((Label)GridView1.Rows[index].FindControl("lblitemid")).Text.ToString();
                            string strItemName = ((Label)GridView1.Rows[index].FindControl("lblstrItemName")).Text.ToString();
                            string strattributename = ((Label)GridView1.Rows[index].FindControl("lblstrattributename")).Text.ToString();
                          
                            string Result = ((TextBox)GridView1.Rows[index].FindControl("lblqty")).Text.ToString();
                            string Resultcurrect = ((DropDownList)GridView1.Rows[index].FindControl("DropDownList117")).SelectedItem.ToString();
                            int intids = int.Parse(itemidss.ToString());
                            int itemids = int.Parse(itemid.ToString());
                            //  int Results = int.Parse(Result.ToString());
                            int ponoinput = int.Parse(Session["inputpono"].ToString());
                            Report.insertattributesresult(itemids, intids, Result, enroll, ponoinput, path, Resultcurrect);



                        }
                        GridView1.DataBind();





                    }





                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Document Upload With Approved');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);


        }
        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(ftpurl + fileName);
            requestFTPUploader.Credentials = new NetworkCredential(user, pass);
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            FileInfo fileInfo = new FileInfo(localPath + fileName);
            FileStream fileStream = fileInfo.OpenRead();

            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];

            Stream uploadStream = requestFTPUploader.GetRequestStream();
            int contentLength = fileStream.Read(buffer, 0, bufferLength);

            while (contentLength != 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = fileStream.Read(buffer, 0, bufferLength);
            }

            uploadStream.Close();
            fileStream.Close();

            requestFTPUploader = null;

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));

            if (GridView1.Rows.Count > 0)
            {

                for (int index = 0; index < GridView1.Rows.Count; index++)
                {
                   

                    string itemidss = ((Label)GridView1.Rows[index].FindControl("lblintid")).Text.ToString();
                    string itemid = ((Label)GridView1.Rows[index].FindControl("lblitemid")).Text.ToString();
                    string strItemName = ((Label)GridView1.Rows[index].FindControl("lblstrItemName")).Text.ToString();
                    string strattributename = ((Label)GridView1.Rows[index].FindControl("lblstrattributename")).Text.ToString();

                    string Result = ((TextBox)GridView1.Rows[index].FindControl("qty")).Text.ToString();

                    int intids = int.Parse(itemidss.ToString());
                    int itemids = int.Parse(itemid.ToString());
                    //  int Results = int.Parse(Result.ToString());
                    int pono = int.Parse(Session["inputpono"].ToString());
                   // Report.insertattributesresult(intids, itemids, Result, enroll,pono);



                }
              //  GridView1.DataBind();
             
            
            
            
            }
        }

        protected void lblqty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_(object sender, EventArgs e)
        {
            int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));

            if (GridView1.Rows.Count > 0)
            {

                for (int index = 0; index < GridView1.Rows.Count; index++)
                {


                    string itemidss = ((Label)GridView1.Rows[index].FindControl("lblintid")).Text.ToString();
                    string itemid = ((Label)GridView1.Rows[index].FindControl("lblitemid")).Text.ToString();
                    string strItemName = ((Label)GridView1.Rows[index].FindControl("lblstrItemName")).Text.ToString();
                    string strattributename = ((Label)GridView1.Rows[index].FindControl("lblstrattributename")).Text.ToString();
                    string Result = ((TextBox)GridView1.Rows[index].FindControl("lblqty")).Text.ToString();
                  //  string Resultcurrect = ((DropDownList)GridView1.Rows[index].FindControl("lblqty")).SelectedItem.ToString();
                    string Resultcurrect = ((DropDownList)GridView1.Rows[index].FindControl("DropDownList117")).SelectedItem.ToString();
                    int intids = int.Parse(itemidss.ToString());
                    int itemids = int.Parse(itemid.ToString());
                    //  int Results = int.Parse(Result.ToString());
                    int ponoinput = int.Parse(Session["inputpono"].ToString());
                   // Report.insertattributesresult(itemids, intids, Result, enroll, ponoinput, Resultcurrect);



                }
                  GridView1.DataBind();





            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}