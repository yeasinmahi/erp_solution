using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;

namespace UI.Transport
{
    public partial class InternalTDocPathList : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int intSeparationID; string Id; string strDate; string strTodate; string UNITS; string enrol1; string ReportType;
        string innerTableHtml = ""; 

        int intReffID; int intDoct;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    intReffID = int.Parse(Request.QueryString["Id"]);
                    HttpContext.Current.Session["intReffID"] = intReffID.ToString();

                    intDoct = int.Parse(HttpContext.Current.Session["intDoct"].ToString());

                    GetTripFareAndToll();

                    if (intDoct == 0)
                    {
                        dt = new DataTable();
                        dt = obj.GetDocPathList(intReffID);
                        //dgvDocPath.DataSource = dt;
                        //dgvDocPath.DataBind();
                    }
                    else
                    {
                        dt = new DataTable();
                        dt = obj.GetDocTypeWiseDPathList(intReffID, intDoct);
                        //dgvDocPath.DataSource = dt;
                        //dgvDocPath.DataBind();
                    }                    
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('List Empty.');", true); }
                                
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string strPathurl = dt.Rows[i]["strFilePath"].ToString();// + strPathurlDocument_57826_St -3, 1, 16-A.jpg
                            string url = "ftp://erp:erp123@ftp.akij.net/InternalTransportDocList/" + strPathurl;
                            string imageUrl = url;//System.Web.HttpUtility.HtmlEncode(url); ;
                            innerTableHtml = innerTableHtml + @" <table border='0'>
                                <tr><td>"; innerTableHtml = innerTableHtml + @"<img src=" + imageUrl + @" Height='700px' Width='800px'></td></tr></table>";
                        }
                        #region ------------ Filter Div By InnerHTML ---------------
                        System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                        new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        createDiv.ID = "createDiv";
                        createDiv.InnerHtml = innerTableHtml;
                        createDiv.Attributes.Add("class", "dynamicDivbn");
                        this.Controls.Add(createDiv);
                        #endregion
                    }
                }

                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no attachement against your query.');", true);

                }


                //try
                //{
                //    intReffID = int.Parse(Request.QueryString["Id"]);
                //    HttpContext.Current.Session["intReffID"] = intReffID.ToString();

                //    intDoct = int.Parse(HttpContext.Current.Session["intDoct"].ToString());

                //    if (intDoct == 0)
                //    {
                //        dt = new DataTable();
                //        dt = obj.GetDocPathList(intReffID);
                //        dgvDocPath.DataSource = dt;
                //        dgvDocPath.DataBind();
                //    }
                //    else
                //    {
                //        dt = new DataTable();
                //        dt = obj.GetDocTypeWiseDPathList(intReffID, intDoct);
                //        dgvDocPath.DataSource = dt;
                //        dgvDocPath.DataBind();
                //    }

                //    GetTripFareAndToll();
                //}
                //catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('List Empty.');", true); }
            }
        }

        private void GetTripFareAndToll()
        {
            intReffID = int.Parse(HttpContext.Current.Session["intReffID"].ToString());

            dt = new DataTable();
            dt = obj.GetTripFareAndToll(intReffID);
            if (dt.Rows.Count > 0)
            {
                lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();
                lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();
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
            string ftpFolder = "InternalTransportDocList/";

            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
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
            catch (WebException ex) { throw new Exception((ex.Response as FtpWebResponse).StatusDescription); }

        }





    }
}