using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UI.ClassFiles;
using Purchase_BLL;
using Purchase_BLL.SupplyChain;
using System.IO;
using System.Net;
using System.Xml;
using Utility;

namespace UI.Inventory
{
    public partial class SupplierEnlistment : BasePage
    {
        private DataTable dt = new DataTable();
        private CSM InsertSupplier = new CSM();
        private CSM Enlist = new CSM();
        private CSM bankcheck = new CSM();
        private CSM report = new CSM();

        private string filePathForXMLDocUpload; private string xmlStringDocUpload = ""; private string xmlDocUpload; private string xml;
        private string strDocUploadPath; private int intDocType; private string strFilePath; private string strDocName;
        private string fileName, docType; private string doctypeid; private string strFileName; private string strSubmitDate;
        private int intID, intInsertBy; private DateTime dteSubmitDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //btnApprove.Visible = false;
                //btnEdit0.Visible = false;
                //btnSubmitForeign.Visible = false;
                //Button3.Visible = false;

                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXMLDocUpload = Server.MapPath("~/Inventory/Data/DocUpload_" + hdnEnroll.Value + ".xml");

                // Response.Write(enroll);
                if (!IsPostBack)
                {
                    btnApprove.Visible = false;
                    btnEdit0.Visible = false;
                    btnSubmitForeign.Visible = false;
                    Button3.Visible = false;
                    btnTempory.Visible = false;
                    Int32 enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    txtEnlishmentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    //Response.Write(enroll);
                    //DataTable dtcount = new DataTable();
                    //dtcount = bankcheck.getcount(enroll);
                    //Int32 permissioncoun = Convert.ToInt32(dtcount.Rows[0]["count"].ToString());
                    //if (permissioncoun > 0)
                    //{
                    //    Button1.Visible = true;

                    if ((int.Parse(Session[SessionParams.USER_ID].ToString()) == 1039) || (int.Parse(Session[SessionParams.USER_ID].ToString()) == 1272))
                    {
                        string strRequestSupID = Request.QueryString["intSuppMasterID"];
                        //Purchase_BLL.
                        if (Request.QueryString["intSuppMasterID"] != "" && Request.QueryString["intSuppMasterID"] != null)
                        {
                            /// int masid = int.Parse(Session["msid"].ToString());
                            int intRequestSupID = int.Parse(strRequestSupID.ToString());
                            dt = bankcheck.GetRequestedSuppInfo(intRequestSupID);
                            txtSuppliername.Text = dt.Rows[0]["strSuppMasterName"].ToString();
                            txtContactNo.Text = dt.Rows[0]["strOrgContactNo"].ToString();
                            txtAddress.Text = dt.Rows[0]["strOrgAddress"].ToString();
                            txtFax.Text = dt.Rows[0]["strOrgFAXNo"].ToString();
                            txtemail.Text = dt.Rows[0]["strOrgMail"].ToString();
                            txtBin.Text = dt.Rows[0]["strBIN"].ToString();
                            txtVatReg.Text = dt.Rows[0]["strVATRegNo"].ToString();
                            txtTin.Text = dt.Rows[0]["strTIN"].ToString();
                            txtTradeLicn.Text = dt.Rows[0]["strTradeLisenceNo"].ToString();
                            ddlBussType.Text = dt.Rows[0]["strBusinessType"].ToString();
                            txtContactP.Text = dt.Rows[0]["strReprName"].ToString();
                            ddlservice.Text = dt.Rows[0]["strServiceType"].ToString();
                            txtPhone.Text = dt.Rows[0]["strReprContactNo"].ToString();
                            ddlSupplierType.Text = dt.Rows[0]["strSupplierType"].ToString();
                            txtPayTo.Text = dt.Rows[0]["strPayToName"].ToString();
                            txtACNo.Text = dt.Rows[0]["strACNO"].ToString();
                            txtEnlishmentDate.Text = dt.Rows[0]["dteEnlistmentDate"].ToString();
                            txtRouting.Text = dt.Rows[0]["strRoutingNo"].ToString();
                            txtShortName.Text = dt.Rows[0]["strShortName"].ToString();
                            //RadioButton1.Checked = true;
                            txtBank.Text = dt.Rows[0]["strBank"].ToString();
                            txtBankId.Text = dt.Rows[0]["intBankID"].ToString();
                            txtBranch.Text = dt.Rows[0]["strBranch"].ToString();
                            txtDistrictId.Text = dt.Rows[0]["intDistrictID"].ToString();
                            txtBranchId.Text = dt.Rows[0]["intBranchID"].ToString();
                            btnEdit.Visible = false;
                            //btnEdit.Visible = false;
                            //Button1.Visible = true;
                            //btnEdit0.Visible = false;
                            //btnTempory.Visible = false;
                        }
                    }
                    else
                    {
                        //btnApprove.Visible = true;
                        //btnEdit0.Visible = true;
                        //btnSubmitForeign.Visible = true;
                        //Button3.Visible = true;
                        //btnTempory.Visible = true;
                        //btnEdit.Visible = true;
                        Button1.Visible = true;
                    }
                    //}
                    //else
                    //{
                    //    Button1.Visible = false;
                    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('You have no permission!');", true);
                    //}
                }
                else if (hdnconfirm.Value == "2") { FTPUpload(); }
                else if (hdnconfirm.Value == "3") { FinalUpload(); }
                else
                {
                }
                //if ((int.Parse(Session[SessionParams.USER_ID].ToString()) == 1039) || (int.Parse(Session[SessionParams.USER_ID].ToString()) == 1392))
                //{ btnEdit.Enabled = true; btnEdit0.Visible = true; btnTempory.Visible = true; }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('" + ex.Message + "');", true);
            }
        }

        #region ===== Md. Al-Amin (Start Code) ==============================================================

        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                ////string strDat = DateTime.Now.ToString("yyyy-MM-dd");

                if (txtDocUpload.FileName.ToString() != "")
                {
                    intDocType = int.Parse(ddlDocType.SelectedValue.ToString());
                    strDocName = ddlDocType.SelectedItem.ToString();
                    intID = int.Parse(hdnEnroll.Value);
                    try
                    {
                        //dteSubmitDate = DateTime.Parse(txtStartDate.Text);
                        //////strSubmitDate = txtStartDate.Text;
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return;
                    }

                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                            strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strSubmitDate + "_" + strDocUploadPath;
                            doctypeid = intDocType.ToString();

                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------

                            fileName = strDocUploadPath.Replace(" ", "");
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + fileName.Trim();

                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/Inventory/Data/") + fileName.Trim());
                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{
                            //    uploadedFile.SaveAs(Server.MapPath("~/Dairy/Uploads/") + fileName.Trim());
                            //}
                            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

                            strFileName = fileName;
                            CreateVoucherXmlDocUpload(doctypeid, strDocName, strFileName);
                        }
                    }
                }

                hdnconfirm.Value = "0";

                #endregion ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
            }
        }

        private void CreateVoucherXmlDocUpload(string doctypeid, string strDocName, string strFileName)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
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
            if (ds.Tables[0].Rows.Count > 0) { dgvDocUp.DataSource = ds; }
            else { dgvDocUp.DataSource = ""; }
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
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                }
                else { LoadGridwithXmlDocUpload(); }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('" + ex.Message + "');", true);
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
                File.Delete(Server.MapPath("~/Inventory/Data/") + fileName);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('" + ex.Message + "');", true);
            }
        }

        #endregion ===== Md. Al-Amin (Start Code) ==============================================================

        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    string strSuppMasterName;
                    string strOrgAddress;
                    string strOrgMail;
                    string strOrgContactNo;
                    string strOrgFAXNo;
                    string strBusinessType;
                    string strServiceType;
                    string strBIN;
                    string strTIN;
                    string strVATRegNo;
                    string strTradeLisenceNo;
                    string strReprName;
                    string strReprContactNo;
                    string strPayToName;
                    string strSupplierType;
                    DateTime dteEnlistmentDate;
                    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                    int intRequestBy;
                    string strShortName;
                    string strACNO;
                    string strRoutingNo;
                    string strBank;
                    string strBranch;
                    int intBankID;
                    int intDistrictID;
                    int intBranchID;

                    strPayToName = txtPayTo.Text;
                    strRoutingNo = txtRouting.Text;
                    strACNO = txtACNo.Text;
                    int acclenth = strACNO.Length;
                    strReprContactNo = txtPhone.Text.ToString();

                    if (strReprContactNo.Length != 11)
                    {
                        Toaster("Contact No Must be 11 digit ??", Common.TosterType.Warning);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                        return;
                    }
                    else if (strPayToName.Length < 2)
                    {
                        Toaster("Please mention Pay to Name", Common.TosterType.Warning);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                        return;
                    }
                    else if (strRoutingNo.Length != 9)
                    {
                        Toaster("Routing no Must be 9 digit ??", Common.TosterType.Warning);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                        return;
                    }
                    else if (strACNO.Length != 13)
                    {
                        Toaster("Account number length must be 13 digit", Common.TosterType.Warning);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                        return;
                    }
                    else if (strPayToName != "" && strRoutingNo.Length == 9 && strACNO.Length == 13 &&
                             strReprContactNo.Length == 11)
                    {
                        strPayToName = txtPayTo.Text;
                        strRoutingNo = txtRouting.Text;
                        strACNO = txtACNo.Text;

                        strSuppMasterName = txtSuppliername.Text;
                        strOrgAddress = txtAddress.Text;
                        strOrgMail = txtemail.Text;
                        strOrgContactNo = txtContactNo.Text;
                        strOrgFAXNo = txtFax.Text;
                        strBusinessType = ddlBussType.SelectedItem.ToString();
                        strServiceType = ddlservice.SelectedItem.ToString();
                        strBIN = txtBin.Text;
                        strTIN = txtTin.Text;
                        strVATRegNo = txtVatReg.Text;
                        strTradeLisenceNo = txtTradeLicn.Text;
                        strReprName = txtContactP.Text;
                        strReprContactNo = txtPhone.Text;

                        strSupplierType = ddlSupplierType.SelectedItem.ToString();

                        strBank = txtBank.Text;
                        strBranch = txtBranch.Text;
                        intBankID = int.Parse(txtBankId.Text);
                        intDistrictID = int.Parse(txtDistrictId.Text);
                        intBranchID = int.Parse(txtBranchId.Text);
                        dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

                        intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                        //if (txtBranch.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true); return; }

                        //else { RadioButton1.Checked = false; }

                        #region ===== Md. Al-Amin (Start Code) ===============================================

                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLDocUpload);
                            XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                            xmlStringDocUpload = dSftTm.InnerXml;
                            xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                            xml = xmlStringDocUpload;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('" + ex.Message + "');", true);
                        }

                        if (dgvDocUp.Rows.Count > 0)
                        {
                            for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                            {
                                docType = ((Label) dgvDocUp.Rows[index].FindControl("lbldoctypeid")).Text.ToString();

                                if (docType == "1")
                                {
                                    break;
                                }
                            }
                        }

                        if (docType == "1") // Cheque Statement
                        {
                            if (dgvDocUp.Rows.Count > 0)
                            {
                                for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                                {
                                    fileName = ((Label) dgvDocUp.Rows[index].FindControl("lblFileName")).Text
                                        .ToString();

                                    FileUploadFTP(Server.MapPath("~/Inventory/Data/"), fileName,
                                        "ftp://ftp.akij.net/SupplierDoc/", "erp@akij.net", "erp123");
                                }
                            }

                            #endregion ===== Md. Al-Amin (Start Code) ===============================================

                            strShortName = txtShortName.Text;

                            string message = Enlist.InsertSuppEnlistment(strSuppMasterName, strOrgAddress, strOrgMail,
                                strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN,
                                strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName,
                                strSupplierType, dteEnlistmentDate, intRequestBy, strShortName, strACNO, strRoutingNo,
                                strBank, strBranch, intBankID, intDistrictID, intBranchID, xml);

                            if (filePathForXMLDocUpload != null)
                            {
                                File.Delete(filePathForXMLDocUpload);
                            }
                            dgvDocUp.DataSource = "";
                            dgvDocUp.DataBind();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('" + message + "');", true);

                            txtSuppliername.Text = "";
                            txtemail.Text = "";
                            txtContactNo.Text = "";
                            txtFax.Text = "";
                            ddlBussType.DataBind();
                            ddlservice.DataBind();
                            txtBin.Text = "";
                            txtTin.Text = "";
                            txtVatReg.Text = "";
                            txtTradeLicn.Text = "";
                            txtContactP.Text = "";
                            txtAddress.Text = "";
                            ddlSupplierType.DataBind();
                            txtACNo.Text = "";
                            txtRouting.Text = "";
                            txtBank.Text = "";
                            txtBranch.Text = "";
                            txtBankId.Text = "";
                            txtDistrictId.Text = "";
                            txtBranchId.Text = "";
                            txtPhone.Text = "";
                            ddlservice.DataBind();
                            //txtEnlishmentDate.Text = "";
                            txtPayTo.Text = "";
                            txtShortName.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                                "alert('Please Upload Cheque Leave Or Bank Statement ??');", true);
                        }
                    }
                    else
                    {
                        Toaster("some information do not provide properly",Common.TosterType.Warning);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "alert('" + ex.Message + "');", true);
                }
            }
        }

        protected void txtSuppliername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtShortName.Text = txtSuppliername.Text;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('" + ex.Message + "');", true);
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChechRoutingNo();
        }

        private void ChechRoutingNo()
        {
            try
            {
                DataTable dtbankcheck = new DataTable();
                string Routingnumber = txtRouting.Text;
                // dtbankcheck = bankcheck.getbankcheck(Routingnumber);
                dtbankcheck = bankcheck.getbankcheckNo(Routingnumber);
                if (dtbankcheck.Rows.Count > 0)
                {
                    txtBank.Text = dtbankcheck.Rows[0]["strBankName"].ToString();
                    txtBranch.Text = dtbankcheck.Rows[0]["strBankBranchName"].ToString();

                    txtBankId.Text = dtbankcheck.Rows[0]["intBankID"].ToString();
                    txtDistrictId.Text = dtbankcheck.Rows[0]["intDistrictID"].ToString();
                    txtBranchId.Text = dtbankcheck.Rows[0]["intBranchID"].ToString();
                    RadioButton1.Checked = false;
                }
                else
                {
                    txtBank.Text = "";
                    txtBranch.Text = "";
                    txtBankId.Text = "";
                    txtDistrictId.Text = "";
                    txtBranchId.Text = "";
                    RadioButton1.Checked = false;
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Wrong Routing No ??');", true); return;
                }
            }
            catch
            {
                RadioButton1.Checked = false;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please click the check box');", true);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                    string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
                    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                    int RequestBy; string strShortName; string strACNO; string strRoutingNo; string strBank; string strBranch; int BankID; int DistrictID; int BranchID;

                    strPayToName = txtPayTo.Text;
                    strRoutingNo = txtRouting.Text;
                    strACNO = txtACNo.Text;
                    strReprContactNo = txtPhone.Text.ToString();
                    if (strReprContactNo.Length != 11)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Contact Number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }

                    if (strPayToName == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Pay to Name');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }
                    else if (strRoutingNo.Length != 9)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Routing number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }
                    else if (strACNO.Length != 13)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please mention Account number');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "OpenHdnDiv();", true);
                    }
                    else if (strPayToName != "" && strRoutingNo.Length == 9 && strACNO.Length == 13 && strReprContactNo.Length == 11)
                    {
                        strSuppMasterName = txtSuppliername.Text;
                        strOrgAddress = txtAddress.Text;
                        strOrgMail = txtemail.Text;
                        strOrgContactNo = txtContactNo.Text;
                        strOrgFAXNo = txtFax.Text;
                        strBusinessType = ddlBussType.SelectedItem.ToString();
                        strServiceType = ddlservice.SelectedItem.ToString();
                        strBIN = txtBin.Text;
                        strTIN = txtTin.Text;
                        strVATRegNo = txtVatReg.Text;
                        strTradeLisenceNo = txtTradeLicn.Text;
                        strReprName = txtContactP.Text;
                        strReprContactNo = txtPhone.Text;

                        strSupplierType = ddlSupplierType.SelectedItem.ToString();
                        strShortName = txtShortName.Text;

                        strBank = txtBank.Text;
                        strBranch = txtBranch.Text;
                        BankID = int.Parse(txtBankId.Text);
                        DistrictID = int.Parse(txtDistrictId.Text);
                        BranchID = int.Parse(txtBranchId.Text);
                        dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
                        Int32 MasterId = int.Parse(Session["msid"].ToString());

                        RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                        dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());

                        string msg = "";
                        //Enlist.INSERTMASTERSUPPLIERFINAL(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);
                        msg = Enlist.InsertNewSupplierEdit(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName, BankID, DistrictID, BranchID, strACNO, strRoutingNo, MasterId);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                        Response.Redirect("~/Inventory/SupplierFinal.aspx");
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

                        Response.Redirect("~/Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                    "alert('" + ex.Message + "');", true);
            }
        }

        protected void ddlSupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSupplierType;
            strSupplierType = ddlSupplierType.SelectedItem.ToString();
            Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
            if (suppliertypeid == 3)
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = false;
                btnApprove.Visible = false;
                btnEdit0.Visible = false;
                btnEdit.Visible = false;
                txtPayTo.Visible = false;

                chkBox1.Visible = false;

                lblbank.Visible = false;
                lblpayto.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblAcNo.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;
                btnSubmitForeign.Visible = true;
                Button3.Visible = false;

                //txtSuppliername.Text = txtPayTo.Text;
                hid.Value = txtSuppliername.Text;

                //Divinfo.Visible = false;
            }
            else
            {
                //Divinfo.Visible = true;
                txtACNo.Visible = true;
                txtPayTo.Visible = true;
                txtRouting.Visible = true;
                txtBank.Visible = true;
                txtBranch.Visible = true;
                txtBankId.Visible = true;
                txtDistrictId.Visible = true;
                txtBranchId.Visible = true;
                Button1.Visible = true;
                //  chkBox1.Visible = true;

                lblbank.Visible = true;
                lblpayto.Visible = true;
                lblrouting.Visible = true;
                RadioButton1.Visible = true;
                lblAcNo.Visible = true;
                RadioButton1.Visible = true;
                lblbankid.Visible = true;
                lblbranch.Visible = true;
                lblbranchid.Visible = true;
                lbldistrictid.Visible = true;
                btnSubmitForeign.Visible = false;
            }

            //if ((int.Parse(Session[SessionParams.USER_ID].ToString()) == 1039) || (int.Parse(Session[SessionParams.USER_ID].ToString()) == 1392))
            //{ btnEdit.Enabled = true; btnEdit0.Visible = true; btnTempory.Visible = false; }
        }

        protected void submit_ClickForeign(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistment;
                //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                int RequestBy; string strShortName;

                strSuppMasterName = txtSuppliername.Text;
                strOrgAddress = txtAddress.Text;
                strOrgMail = txtemail.Text;
                strOrgContactNo = txtContactNo.Text;
                strOrgFAXNo = txtFax.Text;
                strBusinessType = ddlBussType.SelectedItem.ToString();
                strServiceType = ddlservice.SelectedItem.ToString();
                strBIN = txtBin.Text;
                strTIN = txtTin.Text;
                strVATRegNo = txtVatReg.Text;
                strTradeLisenceNo = txtTradeLicn.Text;
                strReprName = txtContactP.Text;
                strReprContactNo = txtPhone.Text;
                strPayToName = strSuppMasterName;
                strSupplierType = ddlSupplierType.SelectedItem.ToString();
                strShortName = txtShortName.Text;
                //strACNO = txtACNo.Text;
                //strRoutingNo = txtRouting.Text;
                //strBank = txtBank.Text;
                //strBranch = txtBranch.Text;
                //BankID = int.Parse(txtBankId.Text);
                //DistrictID = int.Parse(txtDistrictId.Text);
                //BranchID = int.Parse(txtDistrictId.Text);
                dteEnlistment = DateTime.Parse(txtEnlishmentDate.Text);
                //Int32 MasterId = int.Parse(Session["msid"].ToString());

                RequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                dteEnlistment = DateTime.Parse(dteEnlistment.ToShortDateString());
                // strSuppMasterName = hid.Value;

                try
                {
                    strSupplierType = ddlSupplierType.SelectedItem.ToString();
                    Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
                    if (suppliertypeid == 3)
                    {
                        txtACNo.Enabled = false;
                        txtRouting.Enabled = false;
                        txtBank.Enabled = false;
                        txtBranch.Enabled = false;
                        txtBankId.Enabled = false;
                        txtDistrictId.Enabled = false;
                        txtBranchId.Enabled = false;
                    }

                    //Enlist.InsertSupplierMaster(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);

                    Enlist.InsertSupplierDumpFTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistment, RequestBy, strShortName);

                    txtSuppliername.Text = "";
                    txtemail.Text = "";
                    txtContactNo.Text = "";
                    txtFax.Text = "";
                    ddlBussType.DataBind();
                    ddlservice.DataBind();
                    txtBin.Text = "";
                    txtTin.Text = "";
                    txtVatReg.Text = "";
                    txtTradeLicn.Text = "";
                    txtContactP.Text = "";
                    txtAddress.Text = "";
                    ddlSupplierType.DataBind();
                    txtPhone.Text = "";
                    ddlservice.DataBind();
                    //txtEnlishmentDate.Text = "";
                    txtPayTo.Text = "";
                    txtShortName.Text = "";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript",
                        "alert('" + ex.Message + "');", true);
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
            }
        }

        protected void submit_ClickforignDump(object sender, EventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{
            string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
            string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
            //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
            int intRequestBy; string strShortName;

            strSuppMasterName = txtSuppliername.Text;
            strOrgAddress = txtAddress.Text;
            strOrgMail = txtemail.Text;
            strOrgContactNo = txtContactNo.Text;
            strOrgFAXNo = txtFax.Text;
            strBusinessType = ddlBussType.SelectedItem.ToString();
            strServiceType = ddlservice.SelectedItem.ToString();
            strBIN = txtBin.Text;
            strTIN = txtTin.Text;
            strVATRegNo = txtVatReg.Text;
            strTradeLisenceNo = txtTradeLicn.Text;
            strReprName = txtContactP.Text;
            strReprContactNo = txtPhone.Text;

            strPayToName = txtPayTo.Text;
            strSupplierType = ddlSupplierType.SelectedItem.ToString();

            strShortName = txtShortName.Text;

            dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

            intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            strShortName = txtShortName.Text;

            Enlist.InsertSupplierDumpForeign(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);

            txtSuppliername.Text = "";
            txtemail.Text = "";
            txtContactNo.Text = "";
            txtFax.Text = "";
            ddlBussType.DataBind();
            ddlservice.DataBind();
            txtBin.Text = "";
            txtTin.Text = "";
            txtVatReg.Text = "";
            txtTradeLicn.Text = "";
            txtContactP.Text = "";
            txtAddress.Text = "";
            ddlSupplierType.DataBind();
            txtPhone.Text = "";
            ddlservice.DataBind();
            //txtEnlishmentDate.Text = "";

            //}
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        }

        protected void chkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //string strSupplierType;
            //strSupplierType = ddlSupplierType.SelectedItem.ToString();
            //Int32 suppliertypeid = int.Parse(ddlSupplierType.SelectedValue.ToString());
            if (((chkBox1)).Checked == true)
            {
                txtACNo.Visible = false;
                txtRouting.Visible = false;
                txtBank.Visible = false;
                txtBranch.Visible = false;
                txtBankId.Visible = false;
                txtDistrictId.Visible = false;
                txtBranchId.Visible = false;
                Button1.Visible = false;
                btnApprove.Visible = false;
                btnEdit0.Visible = false;
                btnEdit.Visible = false;
                RadioButton1.Visible = false;
                lblbank.Visible = false;
                lblrouting.Visible = false;
                RadioButton1.Visible = false;
                lblbankid.Visible = false;
                lblbranch.Visible = false;
                lblbranchid.Visible = false;
                lbldistrictid.Visible = false;
                btnSubmitForeign.Visible = true;
                btnApprove.Visible = false;
                btnSubmitForeign.Visible = false;
                lblAcNo.Visible = false;
                Button3.Visible = true;
                Button1.Visible = false;
                btnApprove.Visible = false;

                //txtSuppliername.Text = txtPayTo.Text;
                hid.Value = txtSuppliername.Text;

                //Divinfo.Visible = false;
            }
            else if (((chkBox1)).Checked == false)
            {
                txtACNo.Visible = true;
                txtRouting.Visible = true;
                txtBank.Visible = true;
                txtBranch.Visible = true;
                txtBankId.Visible = true;
                txtDistrictId.Visible = true;
                txtBranchId.Visible = true;

                btnApprove.Visible = false;
                //btnEdit0.Visible = true;
                //btnEdit.Visible = true;
                RadioButton1.Visible = true;
                lblbank.Visible = true;
                lblrouting.Visible = true;
                RadioButton1.Visible = true;
                lblbankid.Visible = true;
                lblbranch.Visible = true;
                lblbranchid.Visible = true;
                lbldistrictid.Visible = true;
                lblAcNo.Visible = true;
                Button3.Visible = false;
                Button1.Visible = true;
                btnApprove.Visible = false;
            }
        }

        protected void submitTempory_Click(object sender, EventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{
            //    string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
            //    string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
            //    //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
            //    int intRequestBy; string strShortName;

            //    strSuppMasterName = txtSuppliername.Text;
            //    strOrgAddress = txtAddress.Text;
            //    strOrgMail = txtemail.Text;
            //    strOrgContactNo = txtContactNo.Text;
            //    strOrgFAXNo = txtFax.Text;
            //    strBusinessType = ddlBussType.SelectedItem.ToString();
            //    strServiceType = ddlservice.SelectedItem.ToString();
            //    strBIN = txtBin.Text;
            //    strTIN = txtTin.Text;
            //    strVATRegNo = txtVatReg.Text;
            //    strTradeLisenceNo = txtTradeLicn.Text;
            //    strReprName = txtContactP.Text;
            //    strReprContactNo = txtPhone.Text;

            //    strPayToName = txtPayTo.Text;
            //    strSupplierType = ddlSupplierType.SelectedItem.ToString();

            //    strShortName = txtShortName.Text;

            //    dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

            //    intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
            //    strShortName = txtShortName.Text;

            //    Enlist.InsertSupplierDumpFTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);

            //    txtSuppliername.Text = "";
            //    txtemail.Text = "";
            //    txtContactNo.Text = "";
            //    txtFax.Text = "";
            //    ddlBussType.DataBind();
            //    ddlservice.DataBind();
            //    txtBin.Text = "";
            //    txtTin.Text = "";
            //    txtVatReg.Text = "";
            //    txtTradeLicn.Text = "";
            //    txtContactP.Text = "";
            //    txtAddress.Text = "";
            //    ddlSupplierType.DataBind();
            //    txtPhone.Text = "";
            //    ddlservice.DataBind();
            //    //txtEnlishmentDate.Text = "";
            //    txtPayTo.Text = "";
            //    txtShortName.Text = "";

            //}
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Not Allowed Please send via mail');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void btnTempory_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string strSuppMasterName; string strOrgAddress; string strOrgMail; string strOrgContactNo; string strOrgFAXNo; string strBusinessType; string strServiceType; string strBIN;
                string strTIN; string strVATRegNo; string strTradeLisenceNo; string strReprName; string strReprContactNo; string strPayToName; string strSupplierType; DateTime dteEnlistmentDate;
                //DateTime dteLastActionTime; bool ysnActive; int intMasterSupplierType; int intPreferedInstrument;
                int intRequestBy; string strShortName;

                strSuppMasterName = txtSuppliername.Text;
                strOrgAddress = txtAddress.Text;
                strOrgMail = txtemail.Text;
                strOrgContactNo = txtContactNo.Text;
                strOrgFAXNo = txtFax.Text;
                strBusinessType = ddlBussType.SelectedItem.ToString();
                strServiceType = ddlservice.SelectedItem.ToString();
                strBIN = txtBin.Text;
                strTIN = txtTin.Text;
                strVATRegNo = txtVatReg.Text;
                strTradeLisenceNo = txtTradeLicn.Text;
                strReprName = txtContactP.Text;
                strReprContactNo = txtPhone.Text;

                strPayToName = txtPayTo.Text;
                strSupplierType = ddlSupplierType.SelectedItem.ToString();

                strShortName = txtShortName.Text;

                dteEnlistmentDate = DateTime.Parse(txtEnlishmentDate.Text);

                intRequestBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                strShortName = txtShortName.Text;

                Enlist.InsertMasterSupplierTempory(strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, strReprContactNo, strPayToName, strSupplierType, dteEnlistmentDate, intRequestBy, strShortName);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sucessfuly Submitted');", true);

                txtSuppliername.Text = "";
                txtemail.Text = "";
                txtContactNo.Text = "";
                txtFax.Text = "";
                ddlBussType.DataBind();
                ddlservice.DataBind();
                txtBin.Text = "";
                txtTin.Text = "";
                txtVatReg.Text = "";
                txtTradeLicn.Text = "";
                txtContactP.Text = "";
                txtAddress.Text = "";
                ddlSupplierType.DataBind();
                txtPhone.Text = "";
                ddlservice.DataBind();
                //txtEnlishmentDate.Text = "";
                txtPayTo.Text = "";
                txtShortName.Text = "";
            }
        }
    }
}