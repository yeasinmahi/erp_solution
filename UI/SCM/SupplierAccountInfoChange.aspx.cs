using Purchase_BLL.SupplyChain;
using SCM_BLL;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SCM
{
    public partial class SupplierAccountInfoChange : BasePage
    {
        private string filePathForXMLDocUpload, xmlStringDocUpload, fileName, xml, strDocType;
        private InventoryTransfer_BLL objBll = new InventoryTransfer_BLL();
        private CSM bankcheck = new CSM();
        private DataTable dt = new DataTable();
        private char[] delimeters = { '[', ']' };
        private string[] arraykey;
        private int supplierMasterID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int enroll = Convert.ToInt32(Session[SessionParams.USER_ID].ToString());
            Panel1.Visible = false;

            filePathForXMLDocUpload = Server.MapPath("~/Inventory/Data/DocUpload_" + Session[SessionParams.USER_ID].ToString() + ".xml");

            dt = objBll.GetEmpByEmpID(enroll);
            txtRequesterName.Text = dt.Rows[0]["strEmployeeName"].ToString();
            txtRequesterDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
            txtRequestBy.Text = Session[SessionParams.USER_ID].ToString();
            txtSuperviseBy.Text = dt.Rows[0]["intSuperviserId"].ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string RequesterName, RequesterDesignation, SupplierName = "", SupplierAddress, msg;
            int AccountNo, RequestBy, SuperviseBy, RoutingNo;
            DateTime dteRequestBy, dteSuperviseBy;

            RequesterName = txtRequesterName.Text;
            RequesterDesignation = txtRequesterDesignation.Text;
            arraykey = txtSupplier.Text.Split(delimeters);
            if (arraykey.Length > 0)
            {
                SupplierName = arraykey[0].ToString();
                supplierMasterID = Convert.ToInt32(arraykey[1].ToString());
            }

            SupplierAddress = txtSupplierAddress.Text;
            RoutingNo = Convert.ToInt32(txtRoutingNo.Text);
            AccountNo = Convert.ToInt32(txtAccountNo.Text);
            RequestBy = Convert.ToInt32(txtRequestBy.Text);
            SuperviseBy = Convert.ToInt32(txtSuperviseBy.Text);
            dteRequestBy = DateTime.Parse(txtRequestDate.Text);
            dteSuperviseBy = DateTime.Parse(txtApproveDate.Text);
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLDocUpload);
                XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                xmlStringDocUpload = dSftTm.InnerXml;
                xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                xml = xmlStringDocUpload;
            }
            catch { }
            if (dgvDocUp.Rows.Count > 0)
            {
                for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                {
                    fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                    FileUploadFTP(Server.MapPath("~/Inventory/Data/"), fileName, "ftp://ftp.akij.net/SupplierDoc/", "erp@akij.net", "erp123");
                }
            }

            dt = objBll.InsertSupplierAccountsInfoList(RequesterName, RequesterDesignation, SupplierName, supplierMasterID, SupplierAddress, AccountNo, RoutingNo, RequestBy, SuperviseBy, dteRequestBy, dteSuperviseBy, xml);
            if (filePathForXMLDocUpload != null)
            {
                File.Delete(filePathForXMLDocUpload);
            }
            dgvDocUp.DataSource = "";
            dgvDocUp.DataBind();
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            ClearControl();
            //Image1.ImageUrl = dt.Rows[0]["strFilePath"].ToString();
        }

        private void ClearControl()
        {
            txtRequesterName.Text = "";
            txtRequesterDesignation.Text = "";
            txtSupplier.Text = "";
            txtSupplierAddress.Text = "";
            txtRoutingNo.Text = "";
            txtAccountNo.Text = "";
            txtRequestBy.Text = "";
            txtSuperviseBy.Text = "";
            txtRequestDate.Text = "";
            txtApproveDate.Text = "";
            txtBank.Text = "";
            txtBankID.Text = "";
            txtBranch.Text = "";
            txtDistrict.Text = "";
            txtBranchID.Text = "";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strDocUploadPath, fileName, strFileName;

            string FileExtensions = Path.GetExtension(txtDocUpload.PostedFile.FileName).Substring(1);

            if (txtDocUpload.FileName.ToString() != "")
            {
                int intCount = 0;
                strDocType = "Cheque-Statement";
                if (txtDocUpload.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                    {
                        strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                        strDocUploadPath = strDocType + "_" + txtRequestBy.Text + "_" + strDocUploadPath;
                        fileName = strDocUploadPath.Replace(" ", "");
                        strFileName = fileName.Trim();
                        intCount = intCount + 1;
                        fileName = intCount.ToString() + "_" + fileName.Trim();

                        string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                        uploadedFile.SaveAs(Server.MapPath("~/Inventory/Data/") + fileName.Trim());

                        strFileName = fileName;
                        CreateVoucherXmlDocUpload("1", strDocType, strFileName);
                    }
                }
            }
        }

        #region===========xml code=================

        private void CreateVoucherXmlDocUpload(string doctypeid, string strDocName, string strFileName)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, doctypeid, strDocName, strFileName);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, doctypeid, strDocName, strFileName);
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvDocUp.DataSource = ds;
            }
            else
            {
                dgvDocUp.DataSource = "";
            }
            dgvDocUp.DataBind();
        }

        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string doctypeid, string strDocName, string strFileName)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;
            XmlAttribute StrDocName = doc.CreateAttribute("strDocName"); StrDocName.Value = strDocName;
            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;

            node.Attributes.Append(Doctypeid);
            node.Attributes.Append(StrDocName);
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

                File.Delete(Server.MapPath("~/Dairy/Uploads/") + fileName);
                dsGrid.Tables[0].Rows[dgvDocUp.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLDocUpload);
                DataSet dsGridAfterDelete = (DataSet)dgvDocUp.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXMLDocUpload);
                    dgvDocUp.DataSource = "";
                    dgvDocUp.DataBind();
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch { }
        }

        #endregion=========end xml====================

        protected void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            arraykey = txtSupplier.Text.Split(delimeters);
            if (arraykey.Length > 0)
            {
                supplierMasterID = Convert.ToInt32(arraykey[1].ToString());
                dt = objBll.GetSupplierAddress(supplierMasterID);
                txtSupplierAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();
            }
        }

        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
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
                File.Delete(Server.MapPath("~/Inventory/Data/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }

        #region=======Radio Button Check========

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChechRoutingNo();
        }

        private void ChechRoutingNo()
        {
            try
            {
                DataTable dtbankcheck = new DataTable();
                string Routingnumber = txtRoutingNo.Text;
                // dtbankcheck = bankcheck.getbankcheck(Routingnumber);
                dtbankcheck = bankcheck.getbankcheckNo(Routingnumber);
                if (dtbankcheck.Rows.Count > 0)
                {
                    txtBank.Text = dtbankcheck.Rows[0]["strBankName"].ToString();
                    txtBranch.Text = dtbankcheck.Rows[0]["strBankBranchName"].ToString();

                    txtBankID.Text = dtbankcheck.Rows[0]["intBankID"].ToString();
                    txtDistrict.Text = dtbankcheck.Rows[0]["intDistrictID"].ToString();
                    txtBranchID.Text = dtbankcheck.Rows[0]["intBranchID"].ToString();
                    RadioButton1.Checked = false;
                }
                else
                {
                    txtBank.Text = "";
                    txtBranch.Text = "";
                    txtBankID.Text = "";
                    txtDistrict.Text = "";
                    txtBranchID.Text = "";
                    RadioButton1.Checked = false;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Routing No ??');", true); return;
                }
            }
            catch { RadioButton1.Checked = false; ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true); }
        }

        #endregion====== end checking radio button===========

        //protected void FinalUpload()
        //{
        //    string accNo = txtAccountNo.Text;
        //    if(accNo.Length>=13)
        //    {
        //        if (dgvDocUp.Rows.Count > 0)
        //        {
        //            for (int index = 0; index < dgvDocUp.Rows.Count; index++)
        //            {
        //                fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
        //                FileUploadFTP(Server.MapPath("~/Inventory/Data/"), fileName, "ftp://ftp.akij.net/SupplierDoc/", "erp@akij.net", "erp123");

        //            }
        //        }
        //    }

        //}

        #region=======================Supplier Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchMasterSupplier(prefixText, "Local Purchase");
        }

        #endregion====================Close===============================
    }
}