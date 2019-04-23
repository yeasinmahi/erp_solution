using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR_BLL.Document_Inventory;
using System.Data;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using UI.ClassFiles;

namespace UI.Document_Inventory
{
    public partial class DownloadDocument :BasePage
    {
        documentdownload bll = new documentdownload();
        DataTable download = new DataTable();
        DataTable employee = new DataTable();
        DataTable data = new DataTable();
        DataTable docview = new DataTable();
        DataTable corporateView = new DataTable();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Int32 intenroll=Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                int depertmentid = Int32.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
                int unit = Int32.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

                if (depertmentid ==14 || depertmentid == 242)
                {
                   
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                    dt = new DataTable();
                    dt = bll.CheckCorporate(intenroll);
                    if(dt.Rows.Count>0)
                    {
                        corporateView = bll.CorporateViewDataGrid(unit);
                        GridView2.DataSource = corporateView;
                        GridView2.DataBind();
                        txtEnroll.ReadOnly = false;
                    }
                    //if (intjobid == 1 || intjobid == 3 || intjobid == 4 || intjobid == 5 || intjobid == 6 || intjobid == 7 || intjobid == 8 || intjobid == 9 || intjobid == 10 || intjobid == 11 || intjobid == 12 || intjobid == 13 || intjobid == 14 || intjobid == 15 || intjobid == 16 || intjobid == 17 || intjobid == 18 || intjobid == 19 || intjobid == 22 || intjobid == 88 || intjobid == 125 || intjobid == 131 || intjobid == 1254 || intjobid == 1257 || intjobid == 1258 || intjobid == 1259 || intjobid == 1260 || intjobid == 90 || intjobid == 95 || intjobid == 91)
                    //{
                        
                    //}
                    else
                    {
                        Int32 jobstation = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                        docview = bll.docviewpageload(jobstation);
                        GridView2.DataSource = docview;
                        GridView2.DataBind();

                        txtEnroll.ReadOnly = false;
                    }
                }
                else
                {
                    data = bll.loadpageInfo(intenroll);
                    if (data.Rows.Count > 0)
                    {
                        TxtEmployee.Text = data.Rows[0]["strEmployeeName"].ToString();
                        TxtDesignation.Text = data.Rows[0]["strDesignation"].ToString();
                        TxtUnit.Text = data.Rows[0]["strUnit"].ToString();
                        txtEnroll.Text = data.Rows[0]["intEmployeeID"].ToString();
                        //TxtDepartment.Text = employee.Rows[0]["strDepatrment"].ToString();

                        Int32 Enroll = Int32.Parse(txtEnroll.Text.ToString());
                        download = bll.downloadinformation(Enroll);
                        GridView1.DataSource = download;
                        GridView1.DataBind();

                    }
                    txtEnroll.ReadOnly = true;
                }

            }
        }

        protected void btnDocDownload_Click(object sender, EventArgs e)
        {
             char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            string filePath = searchKey[0];
            string fileName = filePath;

            //FTP Server URL.
            string ftp = "ftp://ftp.akij.net/";

            //FTP Folder name. Leave blank if you want to Download file from root folder.
            string ftpFolder = "";

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("erp@akij.net", "erp123");
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
            //catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }
            catch { };

        }

        protected void txtEnroll_TextChanged(object sender, EventArgs e)
        {
           
            
            Int32 enroll = Int32.Parse(txtEnroll.Text.ToString());
           

            employee = bll.EmployerInformation(enroll);
            if (employee.Rows.Count > 0)
            {
                TxtEmployee.Text = employee.Rows[0]["strEmployeeName"].ToString();
                TxtDesignation.Text = employee.Rows[0]["strDesignation"].ToString();
                TxtUnit.Text = employee.Rows[0]["strUnit"].ToString();
                //TxtDepartment.Text = employee.Rows[0]["strDepatrment"].ToString();
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data ');", true);
            }

           

        }

        protected void Btnshow_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridView1.Visible = true;
            Int32 Enroll = Int32.Parse(txtEnroll.Text.ToString());
            download = bll.downloadinformation(Enroll);
            GridView1.DataSource = download;
            GridView1.DataBind();   
        }

       

        protected void BtnReject_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber1 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intDocUploadID"] = ordernumber1;
                    
                    Int32 reject1 = Convert.ToInt32(Session["intDocUploadID"].ToString());
                    bll.documentReject(reject1);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Reject');", true);

                    //GridView1.Visible = false;
                    //GridView2.Visible = true;
                    //Int32 jobstation = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    //docview = bll.docviewpageload(jobstation);
                    //GridView2.DataSource = docview;
                    //GridView2.DataBind();
                    int depertmentid = Int32.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());

                    if (depertmentid == 14)
                    {

                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                        Int32 jobstation = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                        Int32 unit = Int32.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());
                        Int32 intenroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                        dt = new DataTable();
                        dt = bll.CheckCorporate(intenroll);
                        if (dt.Rows.Count > 0)
                        {
                            corporateView = bll.CorporateViewDataGrid(unit);
                            GridView2.DataSource = corporateView;
                            GridView2.DataBind();
                            txtEnroll.ReadOnly = false;
                        }
                        else
                        {
                            docview = bll.docviewpageload(jobstation);
                            GridView2.DataSource = docview;
                            GridView2.DataBind();

                            txtEnroll.ReadOnly = false;
                        }
                    }
                  
                   
                }
                catch { }
            }
           
                  
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber2 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                   

                    Int32 Approve2 = Convert.ToInt32(ordernumber2.ToString());
                    bll.documentApprove(Approve2);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Approve');", true);

                    //GridView1.Visible = false;
                    //GridView2.Visible = true;
                    //Int32 jobstation = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                    //docview = bll.docviewpageload(jobstation);
                    //GridView2.DataSource = docview;
                    //GridView2.DataBind();
                     int depertmentid = Int32.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());

                     if (depertmentid == 14)
                     {

                         GridView1.Visible = false;
                         GridView2.Visible = true;
                         Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                         Int32 jobstation = Int32.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
                         Int32 unit = Int32.Parse(HttpContext.Current.Session[SessionParams.UNIT_ID].ToString());

                         Int32 intenroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                         dt = new DataTable();
                         dt = bll.CheckCorporate(intenroll);
                         if (dt.Rows.Count > 0)
                         {
                             corporateView = bll.CorporateViewDataGrid(unit);
                             GridView2.DataSource = corporateView;
                             GridView2.DataBind();
                             txtEnroll.ReadOnly = false;
                         }
                         else
                         {
                            docview = bll.docviewpageload(jobstation);
                             GridView2.DataSource = docview;
                             GridView2.DataBind();

                             txtEnroll.ReadOnly = false;
                         }
                     }
                  
                }
                catch { }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    char[] delimiterChars = { '^' };
                    string temp1 = ((Button)sender).CommandArgument.ToString();
                    string temp = temp1.Replace("'", " ");
                    string[] searchKey = temp.Split(delimiterChars);

                    string ordernumber3 = searchKey[0].ToString();

                    // Response.Write(ordernumber); 
                    Session["intDocUploadID"] = ordernumber3;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ImageView.aspx');", true);
                }
                catch { }
            }

        }

        protected void BtbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber1 = searchKey[0].ToString();
                Int32 reject1 = Convert.ToInt32(ordernumber1.ToString());
                bll.documentReject(reject1);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully Reject');", true);
                GridView2.Visible = false;
                GridView1.Visible = true;
                Int32 Enroll = Int32.Parse(txtEnroll.Text.ToString());
                download = bll.downloadinformation(Enroll);
                GridView1.DataSource = download;
                GridView1.DataBind();
            }

            catch { }
        }

        



        }
    }
