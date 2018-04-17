using SAD_BLL.Transport;
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

namespace UI.Transport
{
    public partial class VendorTTripCompleteEntry : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt; DataTable dtn;

        string filePathForXML; string xmlString = ""; string xml;
        string filePathForXMLCustWiseCost; string xmlStringCustWiseCost = ""; string xmlCustWiseCost;

        int intID; int intWork; int intReffID; int intUnitID;
        decimal monCompanyDem; decimal monPartyDem; decimal monAddFare; decimal monSpecialFare;
        string strCompanyDem; string strPartyDem; string strAddFare; string strSpecialFare;
        int intInInsertBy; decimal monTripFareVendorVT; decimal monTotalTripFareVT;

        string filePathForXMLDocUpload; string xmlStringDocUpload = ""; string xmlDocUpload;
        string strDocUploadPath; int intDocType; string strFilePath; string strDocName;
        string fileName; string doctypeid; string strFileName;
        decimal monOthers; string strCauseOfOther; int int3rdPartyCOAid; string strVehicleSupplier;

        string reffid; string custid; string custname; string millage; string tripfare; string tfopentruck;
        string tfcoveredvan; string tfpickup; string tf7ton; string tf5ton; string tf3ton; string tf1andhalfton;
        string bridgetoll; string bnrtoll20ton; string bnrtoll10ton; string bnrtoll7ton; string bnrtoll5ton;
        string bnrtoll3ton; string bnrtoll2ton; string bnrtoll1andhalfton; string ferrytoll; string ft20ton;
        string ft7ton; string ft5ton; string ft3ton; string ft1andhalfton; string tf10ton; int intInsertBy;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            filePathForXMLDocUpload = Server.MapPath("~/Transport/Data/DocUpload_" + hdnEnroll.Value + ".xml");
            filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");

            if (!IsPostBack)
            {
                try
                {
                    intID = int.Parse(Request.QueryString["intID"].ToString());
                    HttpContext.Current.Session["intID"] = intID.ToString();

                    HttpContext.Current.Session["RealoadFromVTComplete"] = "1";

                    dtn = new DataTable();
                    dtn = obj.GetDriverEnrollAndUnitidByTrip(intID);

                    if (dtn.Rows.Count > 0)
                    {
                        intUnitID = int.Parse(dtn.Rows[0]["intUnitID"].ToString()); 
                    }  
                    
                    dt = new DataTable();
                    dt = obj.GetDocTypeListForVendorT();
                    ddlDocType.DataTextField = "strDocType";
                    ddlDocType.DataValueField = "intDocType";
                    ddlDocType.DataSource = dt;
                    ddlDocType.DataBind();

                    dt = obj.GetVehicleSupplierList(intUnitID);
                    ddlVehicleSupplier.DataTextField = "strName";
                    ddlVehicleSupplier.DataValueField = "intCOAid";
                    ddlVehicleSupplier.DataSource = dt;
                    ddlVehicleSupplier.DataBind();

                    GetTripFareAndToll();
                    CustomerWiseRouteCost();
                    //LoadGrid();
                    ////btnUpdate.Visible = false;
                    ////if (intUnitID == 2)
                    ////{
                    ////    if (hdnEnroll.Value == "58073" || hdnEnroll.Value == "87101")
                    ////    {
                    ////        btnUpdate.Visible = true;
                    ////    }
                    ////    else { btnUpdate.Visible = false; }
                    ////}
                }
                catch
                { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
        }

        private void GetTripFareAndToll()
        {
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());

            dt = new DataTable();
            dt = obj.GetTripFareAndToll(intID);
            if (dt.Rows.Count > 0)
            {
                lblTripNo.Text = dt.Rows[0]["TripNo"].ToString();
                lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                lblVehicleType.Text = dt.Rows[0]["VehicleType"].ToString();

                txtTotalTripFare.Text = dt.Rows[0]["TripFare"].ToString();
                hdnTFare.Value = dt.Rows[0]["TripFare"].ToString();

                hdnQty.Value = dt.Rows[0]["Quantity"].ToString();
                txtQuantity.Text = dt.Rows[0]["Quantity"].ToString(); 
            }
            //dt = new DataTable();
            //dt = obj.GetTripFareForInEntry(intID);
            //if (dt.Rows.Count > 0)
            //{
            //    hdnTFare.Value = dt.Rows[0]["monTripFare"].ToString();
            //    txtTotalTripFare.Text = dt.Rows[0]["monTripFare"].ToString();
            //}   

        }

        protected void btnTripComplete_Click(object sender, EventArgs e)
        { 
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    int3rdPartyCOAid = int.Parse(ddlVehicleSupplier.SelectedValue.ToString());
                    strVehicleSupplier = ddlVehicleSupplier.SelectedItem.ToString();

                    try { monCompanyDem = decimal.Parse(txtCompanyDem.Text); }
                    catch { monCompanyDem = 0; }
                    if (monCompanyDem != 0 && txtCauseOfComDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Company Demurrage.');", true); return; }
                    strCompanyDem = txtCauseOfComDem.Text;

                    try { monPartyDem = decimal.Parse(txtPartyDem.Text); }
                    catch { monPartyDem = 0; }
                    if (monPartyDem != 0 && txtCauseOfPartyDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Party Demurrage.');", true); return; }
                    strPartyDem = txtCauseOfPartyDem.Text;

                    try { monAddFare = decimal.Parse(txtAdditionalFare.Text); }
                    catch { monAddFare = 0; }
                    if (monAddFare != 0 && txtCauseOfAdditionalF.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Additional Fare.');", true); return; }
                    strAddFare = txtCauseOfAdditionalF.Text;

                    try { monSpecialFare = decimal.Parse(txtSpecialFare.Text); }
                    catch { monSpecialFare = 0; }
                    if (monSpecialFare != 0 && txtCauseOfSpeDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Special Fare.');", true); return; }
                    strSpecialFare = txtCauseOfSpeDem.Text; ;

                    try { monTripFareVendorVT = decimal.Parse(hdnTFare.Value); }
                    catch { monTripFareVendorVT = 0; }
                    monTotalTripFareVT = ((monTripFareVendorVT + monCompanyDem + monAddFare + monSpecialFare) - monPartyDem);

                    //InsertVendorTTripComplete
                    /////string message = obj.InsertVendorTTripComplete(intID, strCompanyDem, monCompanyDem, strPartyDem, monPartyDem, strAddFare, monAddFare, strSpecialFare, monSpecialFare, monTripFareVendorVT, monTotalTripFareVT, intInInsertBy);

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again');", true); }
            }

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
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    strDocUploadPath = txtDocUpload.FileName.ToString();
                    //strDocUploadPath = txtDocUpload.
                    strDocUploadPath = Path.GetFileName(txtDocUpload.PostedFile.FileName);
                    strDocUploadPath = strDocName + "_" + intID.ToString() + "_" + strDocUploadPath;
                    doctypeid = ddlDocType.SelectedValue.ToString();

                    #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                    //string fileName = hdnID.Value + "_" + Path.GetFileName(txtDocUpload.PostedFile.FileName);
                    fileName = strDocUploadPath.Replace(" ", "");

                    //fileName = "* A Short String. *";
                    //Console.WriteLine(fileName);
                    //Console.WriteLine(fileName.Trim(new Char[] { ' ', '_', '*', '.' }));

                    //string txt = "                   i am a string                                    ";
                    //char[] charsToTrim = { ' ' };
                    //txt = txt.Trim(charsToTrim); // txt = "i am a string"

                    //var myString = "    this    is my String ";
                    //var newstring = myString.Trim(); // results in "this is my String"
                    //var noSpaceString = myString.Replace(" ", ""); // results in "thisismyString";

                    //////////////////////////txtDocUpload.PostedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                    //////FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
                    ////File.Delete(Server.MapPath("~/Transport/Uploads/") + fileName);
                    //lblMessage.Text += fileName + " Uploaded.<br />";
                    strFileName = fileName;
                    strFilePath = fileName;

                    //string fileName = FileUpload1.FileName;
                    string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                    if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                    {
                        //FileUpload1.SaveAs(Server.MapPath(fileName));
                        txtDocUpload.PostedFile.SaveAs(Server.MapPath("~/Transport/Uploads/") + fileName.Trim());
                    }
                    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, bmp, png');", true); return; }

                    CreateVoucherXmlDocUpload(strFileName, doctypeid);
                    ////obj.InsertDocPath(intEnroll, strFilePath, intSeparationID);
                    //txtAgentName.Text = "";
                    //txtDTFCash.Text = "";
                }
                else
                { }
                hdnconfirm.Value = "0";

                ///obj.InsertDocPath(intEnroll, strFilePath, intSeparationID);
                ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Document Upload Successfully.');", true);

                ///Response.Redirect(Request.Url.AbsoluteUri);
                    #endregion

            }
        }
        private void CreateVoucherXmlDocUpload(string strFileName, string doctypeid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLDocUpload))
            {
                doc.Load(filePathForXMLDocUpload);
                XmlNode rootNode = doc.SelectSingleNode("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("DocUpload");
                XmlNode addItem = CreateItemNodeDocUpload(doc, strFileName, doctypeid);
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
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName, string doctypeid)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            XmlAttribute Doctypeid = doc.CreateAttribute("doctypeid"); Doctypeid.Value = doctypeid;

            node.Attributes.Append(StrFileName);
            node.Attributes.Append(Doctypeid);
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
        //** Gridview Document Upload End   



        private void FileUploadFTP(string localPath, string fileName, string ftpurl, string user, string pass)
        {
            //******************************************************************

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
        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    int3rdPartyCOAid = int.Parse(ddlVehicleSupplier.SelectedValue.ToString());
                    strVehicleSupplier = ddlVehicleSupplier.SelectedItem.ToString();

                    try { monCompanyDem = decimal.Parse(txtCompanyDem.Text); }
                    catch { monCompanyDem = 0; }
                    if (monCompanyDem != 0 && txtCauseOfComDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Company Demurrage.');", true); return; }
                    strCompanyDem = txtCauseOfComDem.Text;

                    try { monPartyDem = decimal.Parse(txtPartyDem.Text); }
                    catch { monPartyDem = 0; }
                    if (monPartyDem != 0 && txtCauseOfPartyDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Party Demurrage.');", true); return; }
                    strPartyDem = txtCauseOfPartyDem.Text;

                    try { monAddFare = decimal.Parse(txtAdditionalFare.Text); }
                    catch { monAddFare = 0; }
                    if (monAddFare != 0 && txtCauseOfAdditionalF.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Additional Fare.');", true); return; }
                    strAddFare = txtCauseOfAdditionalF.Text;

                    try { monSpecialFare = decimal.Parse(txtSpecialFare.Text); }
                    catch { monSpecialFare = 0; }
                    if (monSpecialFare != 0 && txtCauseOfSpeDem.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Special Fare.');", true); return; }
                    strSpecialFare = txtCauseOfSpeDem.Text; ;

                    try { monOthers = decimal.Parse(txtOthersTK.Text); }
                    catch { monOthers = 0; }
                    if (monOthers != 0 && txtCauseOfOthers.Text == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Cause Of Others.');", true); return; }
                    strCauseOfOther = txtCauseOfOthers.Text;
                    
                    try { monTripFareVendorVT = decimal.Parse(hdnTFare.Value); }
                    catch { monTripFareVendorVT = 0; }
                    monTotalTripFareVT = ((monTripFareVendorVT + monCompanyDem + monAddFare + monSpecialFare) - monPartyDem);

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
                            FileUploadFTP(Server.MapPath("~/Transport/Uploads/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");

                            //CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

                        }
                    }

                    //InsertVendorTTripComplete
                    string message = obj.InsertVendorTTripComplete(intID, strCompanyDem, monCompanyDem, strPartyDem, monPartyDem, strAddFare, monAddFare, strSpecialFare, monSpecialFare, monTripFareVendorVT, monTotalTripFareVT, intInInsertBy, xmlDocUpload, strCauseOfOther, monOthers, int3rdPartyCOAid, strVehicleSupplier);

                    if (filePathForXMLDocUpload != null)
                    { File.Delete(filePathForXMLDocUpload); } dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    hdnconfirm.Value = "0";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                                        
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Try Again');", true); }
            }
            
        }

        //** Gridview Customer Wise Route Cost Add Start ******************************************************
        private void CustomerWiseRouteCost()
        {
            intWork = 1;
            intID = int.Parse(HttpContext.Current.Session["intID"].ToString());
            dt = new DataTable();
            dt = obj.GetCustomerWiseCostForUpdate(intWork, intID);
            dgvTripWiseCustomer.DataSource = dt;
            dgvTripWiseCustomer.DataBind();
            if (dt.Rows.Count > 0)
            {
                intUnitID = int.Parse(dt.Rows[0]["unitid"].ToString());
            }

            dgvTripWiseCustomer.Columns[5].Visible = false;
            dgvTripWiseCustomer.Columns[6].Visible = false;
            dgvTripWiseCustomer.Columns[7].Visible = false;
            dgvTripWiseCustomer.Columns[8].Visible = false;
            dgvTripWiseCustomer.Columns[9].Visible = false;
            dgvTripWiseCustomer.Columns[10].Visible = false;
            dgvTripWiseCustomer.Columns[11].Visible = false;
            dgvTripWiseCustomer.Columns[12].Visible = false;
            dgvTripWiseCustomer.Columns[13].Visible = false;
            dgvTripWiseCustomer.Columns[14].Visible = false;
            dgvTripWiseCustomer.Columns[15].Visible = false;
            dgvTripWiseCustomer.Columns[16].Visible = false;
            dgvTripWiseCustomer.Columns[17].Visible = false;
            dgvTripWiseCustomer.Columns[18].Visible = false;
            dgvTripWiseCustomer.Columns[19].Visible = false;
            dgvTripWiseCustomer.Columns[20].Visible = false;
            dgvTripWiseCustomer.Columns[21].Visible = false;
            dgvTripWiseCustomer.Columns[22].Visible = false;
            dgvTripWiseCustomer.Columns[23].Visible = false;
            dgvTripWiseCustomer.Columns[24].Visible = false;
            dgvTripWiseCustomer.Columns[25].Visible = false;
            dgvTripWiseCustomer.Columns[26].Visible = false;
            dgvTripWiseCustomer.Columns[27].Visible = false;

            //intUnitID = 16;

            if (intUnitID == 1)
            {
                dgvTripWiseCustomer.Columns[6].Visible = true;
                dgvTripWiseCustomer.Columns[7].Visible = true;
                dgvTripWiseCustomer.Columns[8].Visible = true;
                //dgvTripWiseCustomer.Columns[14].Visible = true;
                //dgvTripWiseCustomer.Columns[22].Visible = true;
            }
            else if (intUnitID == 2)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                //dgvTripWiseCustomer.Columns[17].Visible = true;
                //dgvTripWiseCustomer.Columns[18].Visible = true;
                //dgvTripWiseCustomer.Columns[19].Visible = true;
                //dgvTripWiseCustomer.Columns[21].Visible = true;
                //dgvTripWiseCustomer.Columns[24].Visible = true;
                //dgvTripWiseCustomer.Columns[25].Visible = true;
                //dgvTripWiseCustomer.Columns[26].Visible = true;
                //dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 4)
            {
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                //dgvTripWiseCustomer.Columns[15].Visible = true;
                //dgvTripWiseCustomer.Columns[18].Visible = true;
                //dgvTripWiseCustomer.Columns[19].Visible = true;
                //dgvTripWiseCustomer.Columns[23].Visible = true;
                //dgvTripWiseCustomer.Columns[25].Visible = true;

            }
            else if (intUnitID == 16)
            {
                //dgvTripWiseCustomer.Columns[5].Visible = true;

                dgvTripWiseCustomer.Columns[9].Visible = true;
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[12].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;

                //dgvTripWiseCustomer.Columns[16].Visible = true;
                //dgvTripWiseCustomer.Columns[17].Visible = true;
                //dgvTripWiseCustomer.Columns[18].Visible = true;
                //dgvTripWiseCustomer.Columns[19].Visible = true;
                //dgvTripWiseCustomer.Columns[20].Visible = true;
                //dgvTripWiseCustomer.Columns[21].Visible = true;
                //dgvTripWiseCustomer.Columns[24].Visible = true;
                //dgvTripWiseCustomer.Columns[25].Visible = true;
                //dgvTripWiseCustomer.Columns[26].Visible = true;
                //dgvTripWiseCustomer.Columns[27].Visible = true;
            }
            else if (intUnitID == 10)
            {
                dgvTripWiseCustomer.Columns[10].Visible = true;
                dgvTripWiseCustomer.Columns[11].Visible = true;
                dgvTripWiseCustomer.Columns[13].Visible = true;
                //dgvTripWiseCustomer.Columns[17].Visible = true;
                //dgvTripWiseCustomer.Columns[18].Visible = true;
                //dgvTripWiseCustomer.Columns[21].Visible = true;
                //dgvTripWiseCustomer.Columns[24].Visible = true;
                //dgvTripWiseCustomer.Columns[25].Visible = true;
            }
            else
            {
                dgvTripWiseCustomer.Columns[5].Visible = true;
                //dgvTripWiseCustomer.Columns[14].Visible = true;
                //dgvTripWiseCustomer.Columns[22].Visible = true;
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {

                if (dgvTripWiseCustomer.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvTripWiseCustomer.Rows.Count; index++)
                    {
                        reffid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblReffIDG")).Text.ToString();
                        custid = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustIDG")).Text.ToString();
                        custname = ((Label)dgvTripWiseCustomer.Rows[index].FindControl("lblCustNameG")).Text.ToString();
                        millage = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtMillageG")).Text.ToString();
                        tripfare = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTripFareG")).Text.ToString();
                        tfopentruck = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFOpentruckG")).Text.ToString();
                        tfcoveredvan = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFCoveredVanG")).Text.ToString();
                        tfpickup = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTFPickupG")).Text.ToString();
                        tf10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF10TonG")).Text.ToString();
                        tf7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF7TonG")).Text.ToString();
                        tf5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF5TonG")).Text.ToString();
                        tf3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF3TonG")).Text.ToString();
                        tf1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtTF1AndHalfTonG")).Text.ToString();
                        bridgetoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBridgeTollG")).Text.ToString();
                        bnrtoll20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll20TonG")).Text.ToString();
                        bnrtoll10ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll10TonG")).Text.ToString();
                        bnrtoll7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll7TonG")).Text.ToString();
                        bnrtoll5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll5TonG")).Text.ToString();
                        bnrtoll3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll3TonG")).Text.ToString();
                        bnrtoll2ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll2TonG")).Text.ToString();
                        bnrtoll1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtBnRToll1AndHalfTonG")).Text.ToString();
                        ferrytoll = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFerryTollG")).Text.ToString();
                        ft20ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT20TonG")).Text.ToString();
                        ft7ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT7TonG")).Text.ToString();
                        ft5ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT5TonG")).Text.ToString();
                        ft3ton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT3TonG")).Text.ToString();
                        ft1andhalfton = ((TextBox)dgvTripWiseCustomer.Rows[index].FindControl("txtFT1AndHalfTonG")).Text.ToString();

                        CreateVoucherXmlCustWiseCost(reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);

                    }

                    if (dgvTripWiseCustomer.Rows.Count > 0)
                    {
                        try
                        {
                            //filePathForXMLCustWiseCost = Server.MapPath("~/Transport/Data/CustWiseCost_" + hdnEnroll.Value + ".xml");
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePathForXMLCustWiseCost);
                            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
                            string xmlStringCustWiseCost = dSftTm.InnerXml;
                            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
                            xml = xmlStringCustWiseCost;
                        }
                        catch { }
                        if (xml == "") { return; }
                    }

                    intReffID = int.Parse(HttpContext.Current.Session["intID"].ToString());
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());
                    //Final Update
                    string message = obj.UpdateRouteCostByCustomer(intReffID, intInsertBy, xml);

                    if (filePathForXMLCustWiseCost != null)
                    { File.Delete(filePathForXMLCustWiseCost); } dgvTripWiseCustomer.DataSource = ""; dgvTripWiseCustomer.DataBind();

                    //Show Report By Trip Sl Start
                    GetTripFareAndToll();
                    CustomerWiseRouteCost();
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    //Show Report By Trip Sl End

                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Add();", true);
                }
            }
        }
        private void CreateVoucherXmlCustWiseCost(string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLCustWiseCost))
            {
                doc.Load(filePathForXMLCustWiseCost);
                XmlNode rootNode = doc.SelectSingleNode("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("CustWiseCost");
                XmlNode addItem = CreateItemNodeCustWiseCost(doc, reffid, custid, custname, millage, tripfare, tfopentruck, tfcoveredvan, tfpickup, tf10ton, tf7ton, tf5ton, tf3ton, tf1andhalfton, bridgetoll, bnrtoll20ton, bnrtoll10ton, bnrtoll7ton, bnrtoll5ton, bnrtoll3ton, bnrtoll2ton, bnrtoll1andhalfton, ferrytoll, ft20ton, ft7ton, ft5ton, ft3ton, ft1andhalfton); ;
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLCustWiseCost);
            LoadGridwithXmlCustWiseCost();
            //Clear();
        }
        private void LoadGridwithXmlCustWiseCost()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXMLCustWiseCost);
            XmlNode dSftTm = doc.SelectSingleNode("CustWiseCost");
            xmlStringCustWiseCost = dSftTm.InnerXml;
            xmlStringCustWiseCost = "<CustWiseCost>" + xmlStringCustWiseCost + "</CustWiseCost>";
            StringReader sr = new StringReader(xmlStringCustWiseCost);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0) { dgvTripWiseCustomer.DataSource = ds; }
            else { dgvTripWiseCustomer.DataSource = ""; } //dgvTripWiseCustomer.DataBind();
        }
        private XmlNode CreateItemNodeCustWiseCost(XmlDocument doc, string reffid, string custid, string custname, string millage, string tripfare, string tfopentruck, string tfcoveredvan, string tfpickup, string tf10ton, string tf7ton, string tf5ton, string tf3ton, string tf1andhalfton, string bridgetoll, string bnrtoll20ton, string bnrtoll10ton, string bnrtoll7ton, string bnrtoll5ton, string bnrtoll3ton, string bnrtoll2ton, string bnrtoll1andhalfton, string ferrytoll, string ft20ton, string ft7ton, string ft5ton, string ft3ton, string ft1andhalfton)
        {
            XmlNode node = doc.CreateElement("CustWiseCost");

            XmlAttribute Reffid = doc.CreateAttribute("reffid"); Reffid.Value = reffid;
            XmlAttribute Custid = doc.CreateAttribute("custid"); Custid.Value = custid;
            XmlAttribute Custname = doc.CreateAttribute("custname"); Custname.Value = custname;
            XmlAttribute Millage = doc.CreateAttribute("millage"); Millage.Value = millage;
            XmlAttribute Tripfare = doc.CreateAttribute("tripfare"); Tripfare.Value = tripfare;
            XmlAttribute Tfopentruck = doc.CreateAttribute("tfopentruck"); Tfopentruck.Value = tfopentruck;
            XmlAttribute Tfcoveredvan = doc.CreateAttribute("tfcoveredvan"); Tfcoveredvan.Value = tfcoveredvan;
            XmlAttribute Tfpickup = doc.CreateAttribute("tfpickup"); Tfpickup.Value = tfpickup;
            XmlAttribute Tf10ton = doc.CreateAttribute("tf10ton"); Tf10ton.Value = tf10ton;
            XmlAttribute Tf7ton = doc.CreateAttribute("tf7ton"); Tf7ton.Value = tf7ton;
            XmlAttribute Tf5ton = doc.CreateAttribute("tf5ton"); Tf5ton.Value = tf5ton;
            XmlAttribute Tf3ton = doc.CreateAttribute("tf3ton"); Tf3ton.Value = tf3ton;
            XmlAttribute Tf1andhalfton = doc.CreateAttribute("tf1andhalfton"); Tf1andhalfton.Value = tf1andhalfton;
            XmlAttribute Bridgetoll = doc.CreateAttribute("bridgetoll"); Bridgetoll.Value = bridgetoll;
            XmlAttribute Bnrtoll20ton = doc.CreateAttribute("bnrtoll20ton"); Bnrtoll20ton.Value = bnrtoll20ton;
            XmlAttribute Bnrtoll10ton = doc.CreateAttribute("bnrtoll10ton"); Bnrtoll10ton.Value = bnrtoll10ton;
            XmlAttribute Bnrtoll7ton = doc.CreateAttribute("bnrtoll7ton"); Bnrtoll7ton.Value = bnrtoll7ton;
            XmlAttribute Bnrtoll5ton = doc.CreateAttribute("bnrtoll5ton"); Bnrtoll5ton.Value = bnrtoll5ton;
            XmlAttribute Bnrtoll3ton = doc.CreateAttribute("bnrtoll3ton"); Bnrtoll3ton.Value = bnrtoll3ton;
            XmlAttribute Bnrtoll2ton = doc.CreateAttribute("bnrtoll2ton"); Bnrtoll2ton.Value = bnrtoll2ton;
            XmlAttribute Bnrtoll1andhalfton = doc.CreateAttribute("bnrtoll1andhalfton"); Bnrtoll1andhalfton.Value = bnrtoll1andhalfton;
            XmlAttribute Ferrytoll = doc.CreateAttribute("ferrytoll"); Ferrytoll.Value = ferrytoll;
            XmlAttribute Ft20ton = doc.CreateAttribute("ft20ton"); Ft20ton.Value = ft20ton;
            XmlAttribute Ft7ton = doc.CreateAttribute("ft7ton"); Ft7ton.Value = ft7ton;
            XmlAttribute Ft5ton = doc.CreateAttribute("ft5ton"); Ft5ton.Value = ft5ton;
            XmlAttribute Ft3ton = doc.CreateAttribute("ft3ton"); Ft3ton.Value = ft3ton;
            XmlAttribute Ft1andhalfton = doc.CreateAttribute("ft1andhalfton"); Ft1andhalfton.Value = ft1andhalfton;

            node.Attributes.Append(Reffid);
            node.Attributes.Append(Custid);
            node.Attributes.Append(Custname);
            node.Attributes.Append(Millage);
            node.Attributes.Append(Tripfare);
            node.Attributes.Append(Tfopentruck);
            node.Attributes.Append(Tfcoveredvan);
            node.Attributes.Append(Tfpickup);
            node.Attributes.Append(Tf10ton);
            node.Attributes.Append(Tf7ton);
            node.Attributes.Append(Tf5ton);
            node.Attributes.Append(Tf3ton);
            node.Attributes.Append(Tf1andhalfton);
            node.Attributes.Append(Bridgetoll);
            node.Attributes.Append(Bnrtoll20ton);
            node.Attributes.Append(Bnrtoll10ton);
            node.Attributes.Append(Bnrtoll7ton);
            node.Attributes.Append(Bnrtoll5ton);
            node.Attributes.Append(Bnrtoll3ton);
            node.Attributes.Append(Bnrtoll2ton);
            node.Attributes.Append(Bnrtoll1andhalfton);
            node.Attributes.Append(Ferrytoll);
            node.Attributes.Append(Ft20ton);
            node.Attributes.Append(Ft7ton);
            node.Attributes.Append(Ft5ton);
            node.Attributes.Append(Ft3ton);
            node.Attributes.Append(Ft1andhalfton);
            return node;
        }

        //** Gridview Customer Wise Route Cost End 







    }
}