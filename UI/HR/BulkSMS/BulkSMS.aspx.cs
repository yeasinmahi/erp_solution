using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL;
using HR_BLL.BulkSMS;
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.HR.BulkSMS
{
    public partial class BulkSMS : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/BulkSMS/BulkSMS.aspx";
        string stop = "stopping HR/BulkSMS/BulkSMS.aspx";

        DataTable dtReport = new DataTable();
        BulkSMSBLL insertSMS = new BulkSMSBLL();
        string filePathForXML;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePathForXML = Server.MapPath("BulkSMSsend.CSV");
            if (!IsPostBack)
            {
               
                pnlUpperControl.DataBind();

                TextBox2.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                Button1.Visible = false;
                txtSMS.Visible = false;
                Button3.Visible = false;
                fu_ImportCSV.Visible = false;
                btn_ImportCSV.Visible = false;
                Button2.Visible = false;
                dtReport = insertSMS.getBulkSMSfilenname();
                GridView2.DataSource = dtReport;
                GridView2.DataBind();
                GridView2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Button1_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/BulkSMS/BulkSMS.aspx Button1_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            string smstxt = txtSMS.Text.ToString();
            string strUserName = Convert.ToString("Akijadmin".ToString());
            string strPassword = Convert.ToString("AkijFood@123".ToString());
            string strMaskingCli = Convert.ToString("AKIJ GROUP".ToString());
            string sms = Convert.ToString(txtSMS.Text.ToString());
            if (smstxt == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type SMS !')", true);
            }
            else
            {
                string strOfficePhoneNo = TextBox2.Text;
                insertSMS.getInsertBulkSMS(strUserName, strPassword, strMaskingCli, strOfficePhoneNo, sms);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully !')", true);
            }

            fd = log.GetFlogDetail(stop, location, "Button1_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btn_ImportCSV_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btn_ImportCSV_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/BulkSMS/BulkSMS.aspx btn_ImportCSV_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);
            
            string fileName;
            string filePath = string.Empty;
            fileName = Path.GetFileName(fu_ImportCSV.PostedFile.FileName);
            Session["fileName"] = fileName;
           // Save(filePathForXML);
            //Load(filePathForXML);
            fu_ImportCSV.PostedFile.SaveAs(Server.MapPath("~/HR/BulkSMS/") + fileName.Trim());     
          
            if (fu_ImportCSV.HasFile && fu_ImportCSV.PostedFile.ContentType.Equals("application/vnd.ms-excel"))
            {
                string path = Server.MapPath("~/HR/BulkSMS/") + fileName;
                //fu_ImportCSV.PostedFile.FileName
                gv_GridView.DataSource = (DataTable)ReadToEnd(path);
                gv_GridView.DataBind();
                lbl_ErrorMsg.Visible = false;
            }
            else
            {
                lbl_ErrorMsg.Text = "Please check the selected file type";
                lbl_ErrorMsg.Visible = true;
            }

            fd = log.GetFlogDetail(stop, location, "btn_ImportCSV_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

       
        private object ReadToEnd(string filePath)
        {
            

            DataTable dtDataSource = new DataTable();

            //Read all lines from selected file and assign to string array variable.
            string[] fileContent = File.ReadAllLines(filePath);

            //Checks fileContent count > 0 then we have some lines in the file. If = 0 then file is empty
            if (fileContent.Count() > 0)
            {
                //In CSV file, 1st line contains column names. When you read CSV file, each delimited by ','.
                //fileContent[0] contains 1st line and splitted by ','. columns string array contains list of columns.
                string[] columns = fileContent[0].Split(',');
                for (int i = 0; i < columns.Count(); i++)
                {
                    dtDataSource.Columns.Add(columns[i]);
                }

                //Same logic for row data.
                for (int i = 1; i < fileContent.Count(); i++)
                {
                    string[] rowData = fileContent[i].Split(',');
                    dtDataSource.Rows.Add(rowData);
                }
            }
            return dtDataSource;

        }

        protected void btn1_ImportCSV_Click(object sender, EventArgs e)
        {
            gv_GridView.DataBind();
            string filename = Session["fileName"].ToString();
            File.Delete(Server.MapPath("~/HR/BulkSMS/") + filename);
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Button1.Visible = true;
            txtSMS.Visible = true;
            Button3.Visible = false;
            fu_ImportCSV.Visible = false;
            btn_ImportCSV.Visible = false;
            Button2.Visible = false;
            lbl_ErrorMsg.Visible = false;
            gv_GridView.DataBind();
            GridView2.Visible = false;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Button1.Visible = false;
            txtSMS.Visible = false;

            fu_ImportCSV.Visible = true;
            btn_ImportCSV.Visible = true;
            Button2.Visible = true;
            Button3.Visible = true;
            lbl_ErrorMsg.Visible = true;
            GridView2.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string smstxt = txtSMS.Text.ToString();
            string strUserName = Convert.ToString("Akijadmin".ToString());
            string strPassword = Convert.ToString("AkijFood@786".ToString());
            string strMaskingCli = Convert.ToString("AKIJ GROUP".ToString());
          
            //Attached file SMS Send\\
            if (gv_GridView.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Attached SMS File !')", true);
            }
            else
            {
           
                
               if (gv_GridView.Rows.Count > 0)
                {

                    for (int index = 0; index < gv_GridView.Rows.Count; index++)
                    {


                        string strOfficePhoneNo = ((Label)gv_GridView.Rows[index].FindControl("lblMobile_No1")).Text.ToString();

                        string sms = ((Label)gv_GridView.Rows[index].FindControl("lblMessage")).Text.ToString();

                            strOfficePhoneNo = "0" + strOfficePhoneNo;

                            insertSMS.getInsertBulkSMS(strUserName, strPassword, strMaskingCli, strOfficePhoneNo, sms);

                       
                     }



                 }
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('SMS Successfully Send !')", true);
              }



            gv_GridView.DataBind();
            string filename = Session["fileName"].ToString();
            File.Delete(Server.MapPath("~/HR/BulkSMS/") + filename);
        }

        protected void Complete_Click(object sender, EventArgs e)
        {

            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string filePath = searchKey[0];
            // string doctype = searchKey[1];
            string fileName = filePath;

            //if (doctype == "Picture")
            //{


            string ftp = "ftp://ftp.akij.net/";


            string ftpFolder = "BulkSMS/";

            try
            {

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;


                request.Credentials = new NetworkCredential("erp", "erp123");
                request.UsePassive = true;
                request.UseBinary = true;
                request.EnableSsl = false;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                using (MemoryStream stream = new MemoryStream())
                {

                    response.GetResponseStream().CopyTo(stream);
                    Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(stream.ToArray());
                    Response.End();
                }

            }
            catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }

            //}


        }
    }
}