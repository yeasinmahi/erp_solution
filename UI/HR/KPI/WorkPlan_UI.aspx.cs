using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using HR_BLL.KPI;

namespace UI.HR.KPI
{
    public partial class WorkPlan_UI : BasePage
    {
        WorkPlan_BLL objPlan = new WorkPlan_BLL();
        DataTable dt = new DataTable();
        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string fileName; 
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value=HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            filePathForXMLDocUpload = Server.MapPath("~/HR/KPI/Data/DocUpload_" + hdnEnroll.Value + ".xml");
           if(!IsPostBack)
           {
               File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
               //File.Delete(Server.MapPath("~/HR/KPI/Uploads/"));

               pnlUpperControl.DataBind();
               Int32 enroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
               dt = new DataTable();
               dt = objPlan.Workplansummery(enroll);
               dgvStatus.DataSource = dt;
               dgvStatus.DataBind();
           }
           else if (hdnconfirm.Value == "2") { FTPUpload(); }
           else if (hdnField.Value == "1")
           {
               btndocSave_Click();
               //lbldoc.Text = message;
           }
        }

        private void btndocSave_Click()
        {
            try 
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                xmlDocUpload = xmlStringDocUpload;
            }
             
            catch { }
            string description = TxtDescription.Text.ToString();
              Int32 enroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            string subject = TxtSubject.Text.ToString();
            int intType =1;
            dt = new DataTable();
             dt = objPlan.InsertWorkPlandoc(intType, xmlDocUpload, description, subject,enroll);
             if (dt.Rows.Count > 0 && dt.Rows[0]["Mesagess"].ToString() == "Already Insert Work Plan")
             {
                 ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesagess"].ToString() + "');", true);

             }

             else
             {

                 if (dgvDocUp.Rows.Count > 0)
                 {
                     for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                     {
                         fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                         FileUploadFTP(Server.MapPath("~/HR/KPI/Uploads/"), fileName, "ftp://ftp.akij.net/WorkPlanDocUpload/", "erp@akij.net", "erp123");
                         //CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);
                         try { File.Delete(Server.MapPath("~/HR/KPI/Uploads/") + fileName); }
                         catch { }
                     }
                 }

              
                 ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + dt.Rows[0]["Mesagess"].ToString() + "');", true);
             }
             hdnconfirm.Value = "0";
            File.Delete(filePathForXMLDocUpload);  dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

           
            dt = new DataTable();
            dt = objPlan.Workplansummery(enroll);
            dgvStatus.DataSource = dt;
            dgvStatus.DataBind();
            TxtDescription.Text = "";
            TxtSubject.Text = "";
            //****Document Upload End
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            //******************************************************************
            try
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
                try { File.Delete(Server.MapPath("~/HR/KPI/Uploads/") + fileName); }
                catch { }
              
            }
            catch (Exception ex) { throw ex; }
        }
        protected void FTPUpload()
        {
           // hdnEnroll.Value = Session[SessionParams.a].ToString();
            if (hdnconfirm.Value == "2")
            {
                DateTime currentdate = DateTime.Now;
                string second = currentdate.ToString("ffff ");
                
                if (UploadWpaln.FileName.ToString() != "")
                {
                   
                    /////strDocUploadPath = txtDocUpload.FileName.ToString();
                    
                    Int32 enroll = Int32.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    dt = objPlan.CheckAutoID();
                    int autoid = int.Parse(dt.Rows[0]["ID"].ToString());
                    if (UploadWpaln.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in UploadWpaln.PostedFiles)
                        {
                            string strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            ////strDocUploadPath = Path.GetFileName(txtDocUpload.PostedFile.FileName);
                            strDocUploadPath ="_" + strDocUploadPath;
                         

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            //string fileName = hdnID.Value + "_" + Path.GetFileName(txtDocUpload.PostedFile.FileName);
                             fileName = strDocUploadPath.Replace(" ", "");

                           string   strFileName = fileName.Trim();
                            //////strFilePath = fileName;\
                           dt = new DataTable();

                           
                            fileName = second.ToString() + '_' + autoid.ToString() + "_" + fileName.Trim();


                            //string fileName = FileUpload1.FileName;
                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                              
                                uploadedFile.SaveAs(Server.MapPath("~/HR/KPI/Uploads/") + fileName.Trim());
                              
                           
                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(strFileName);
                           
                        }

                        


                    }
                }

                hdnconfirm.Value = "0";

                
                            #endregion

            }
        }


        private void CreateVoucherXmlDocUpload(string strFileName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLDocUpload);
            LoadGridwithXmlDocUpload();
            //Clear(); 
        }
        private void LoadGridwithXmlDocUpload()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLDocUpload);
            XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
            xmlStringDocUpload = dSftTm.InnerXml;
            xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
            StringReader sr = new StringReader(xmlStringDocUpload);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvDocUp.DataSource = ds; }
            else { dgvDocUp.DataSource = ""; } dgvDocUp.DataBind();
        }
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid");

            node.Attributes.Append(StrFileName);
          
            return node;
        }
        protected void dgvDocUp_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                StringReader sr = new StringReader(xmlStringDocUpload);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvDocUp.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvDocUp.DataSource;
                fileName = dsGrid.Tables[0].Rows[e.RowIndex][0].ToString();
                File.Delete(Server.MapPath("~/HR/KPI/Uploads/") + fileName);

                //hdndgvDTFCash.Value = grandtotaldtfarecash.ToString();
                dsGrid.Tables[0].Rows[dgvDocUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    //hdnDTFCountCash.Value = dgvDTFareCash.Rows.Count.ToString();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch { }

        }

        protected void BtnDetalisView_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);

                string ordernumber3 = searchKey[0].ToString();

                // Response.Write(ordernumber); 
                Session["intAutoID"] = ordernumber3;


                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('ReportDetalisWorkplan_UI.aspx');", true);

            }
            catch { }
        }
        //** Gridview Document Upload End   
     
    }
}