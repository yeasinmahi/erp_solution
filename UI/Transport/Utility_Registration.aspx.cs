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
    public partial class Utility_Registration : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL(); Utility_BLL objut = new Utility_BLL();
        DataTable dt;

        int intID; int intWork; int intUnitID; DateTime dteFromDate; DateTime dteToDate; int intUtilityID;
        string strLicenseAppNo; DateTime dteValidFrom; DateTime dteValidTo; DateTime dteExpireDate;
        DateTime dteNextSubmiteDate; decimal monGovFee; decimal monIncidentalCost; decimal monTotalCost;
        string strRemarks; int intInsertBy; DateTime dteSubmitDate; int intJobStationID;
        string strServiceName; string strLicenseAuthAdd; string strCategory;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName; string strSubmitDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            filePathForXMLDocUpload = Server.MapPath("~/Transport/Data/DocUpload_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    try
                    {
                        dt = objut.GetJobStationList(intUnitID);
                        ddlJobStation.DataTextField = "strJobStationName";
                        ddlJobStation.DataValueField = "intEmployeeJobStationId";
                        ddlJobStation.DataSource = dt;
                        ddlJobStation.DataBind();

                        intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());


                        dt = new DataTable();
                        dt = objut.GetJobStationAddress(intJobStationID);
                        if (dt.Rows.Count > 0)
                        {
                            txtJobSAddress.Text = dt.Rows[0]["strStationAddress"].ToString();
                        }
                    }
                    catch { }

                    dt = new DataTable();
                    dt = objut.GetDocList();
                    ddlDocType.DataTextField = "strDocType";
                    ddlDocType.DataValueField = "intDocType";
                    ddlDocType.DataSource = dt;
                    ddlDocType.DataBind();
                }
                catch
                { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

            dt = objut.GetJobStationList(intUnitID);
            ddlJobStation.DataTextField = "strJobStationName";
            ddlJobStation.DataValueField = "intEmployeeJobStationId";
            ddlJobStation.DataSource = dt;
            ddlJobStation.DataBind();

            intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            dt = new DataTable();
            dt = objut.GetJobStationAddress(intJobStationID);
            if (dt.Rows.Count > 0)
            {
                txtJobSAddress.Text = dt.Rows[0]["strStationAddress"].ToString();
            }
        }
        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                //intUtilityID = int.Parse(HttpContext.Current.Session["intID"].ToString());

                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());                
                strServiceName = txtServiceName.Text;
                strLicenseAuthAdd = txtLicenseAuthAdd.Text;
                strCategory = txtCategory.Text;
                strLicenseAppNo = txtLicenseNo.Text;
                
                try { dteSubmitDate = DateTime.Parse(txtSubmitedDate.Text);}
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return; }

                try { dteValidFrom = DateTime.Parse(txtValidFromDate.Text);} catch { }
                try { dteValidTo = DateTime.Parse(txtValidToDate.Text);} catch { }
                try { dteExpireDate = DateTime.Parse(txtExpireDate.Text);} catch { }
                
                try { dteNextSubmiteDate = DateTime.Parse(txtNextSubmitedDate.Text);}
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Next Submite Date Properly Input.');", true); return; }
                
                try { monGovFee = decimal.Parse(txtGovFee.Text); } catch { monGovFee = 0; }
                try { monIncidentalCost = decimal.Parse(txtIncidentalCost.Text); } catch { monIncidentalCost = 0; }
                monTotalCost = (monGovFee + monIncidentalCost);
                strRemarks = txtRemarks.Text;
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

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

                if (dgvDocUp.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                    {
                        fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                        FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/UtilityDocList/", "erp@akij.net", "erp123");

                    }
                }

                //Final Insert
                string message = objut.InsertRegistration(intUnitID, intJobStationID, strServiceName, strCategory, strLicenseAuthAdd, strLicenseAppNo, dteValidFrom, dteValidTo, dteExpireDate, dteNextSubmiteDate, monGovFee, monIncidentalCost, monTotalCost, strRemarks, intInsertBy, dteSubmitDate, xmlDocUpload);

                txtServiceName.Text = "";
                txtLicenseAuthAdd.Text = "";
                txtCategory.Text = "";
                txtLicenseNo.Text = "";
                txtSubmitedDate.Text = "";
                txtValidFromDate.Text = "";
                txtValidToDate.Text = "";
                txtExpireDate.Text = "";
                txtNextSubmitedDate.Text = "";
                txtGovFee.Text = "";
                txtIncidentalCost.Text = "";
                txtRemarks.Text = "";

                if (filePathForXMLDocUpload != null)
                { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

            }
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
                File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }

        //** Gridview Document Upload Start ******************************************************
        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = int.Parse(ddlDocType.SelectedValue.ToString());
                    strDocName = ddlDocType.SelectedItem.ToString();
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        dteSubmitDate = DateTime.Parse(txtSubmitedDate.Text);
                        strSubmitDate = txtSubmitedDate.Text;
                    }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return; }

                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strSubmitDate + "_" + strDocUploadPath;
                            doctypeid = ddlDocType.SelectedValue.ToString();

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                            fileName = strDocUploadPath.Replace(" ", "");
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            {
                                uploadedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                            }
                            else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(strFileName, doctypeid, strSubmitDate);
                        }
                    }
                }

                hdnconfirm.Value = "0";

                            #endregion

            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid, strSubmitDate);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid, strSubmitDate);
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
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName, string doctypeid, string strSubmitDate)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;
            XmlAttribute StrSubmitDate = doc.CreateAttribute("strSubmitDate"); StrSubmitDate.Value = strSubmitDate;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Doctypeid);
            node.Attributes.Append(StrSubmitDate);
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

                File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
                dsGrid.Tables[0].Rows[dgvDocUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch { }

        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            dt = new DataTable();
            dt = objut.GetJobStationAddress(intJobStationID);
            if (dt.Rows.Count > 0)
            {
                txtJobSAddress.Text = dt.Rows[0]["strStationAddress"].ToString();
            }
        }
        //** Gridview Document Upload End   
      










    }
}