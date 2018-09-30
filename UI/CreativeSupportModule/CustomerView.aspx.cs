using HR_BLL.CreativeSupport;
using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using Dairy_BLL;
using SAD_BLL.Transport;
using System.Text;
using System.Text.RegularExpressions;

namespace UI.CreativeSupportModule
{
    public partial class CustomerView : System.Web.UI.Page
    {
        CreativeS_BLL objcr = new CreativeS_BLL();
        DataTable dt;

        string filePathForXMLDocUpload, xmlStringDocUpload = "", xmlDoc, filePathForXML, xmlString = "", xmlItem;        
        string strDocUploadPath, fileName, strFileName, strRemarks, name, qty, point, itemid, strJobType, strJobT;        
        int intAssignTo, intAssignBy, intJobDescriptionID, intTotalPoint, intPOID, intItemID, intRowCount;
        DateTime dteRequiredDate, dteDatet;
        TimeSpan tmRequiredTime; decimal qtyq;

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtQty. += new EventHandler(textBox1_LostFocus);
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnPoint.Value = "0";
            filePathForXMLDocUpload = Server.MapPath("~/CreativeSupportModule/Data/DocUpload_" + hdnEnroll.Value + ".xml");
            filePathForXML = Server.MapPath("~/CreativeSupportModule/Data/Item_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
               

                try
                {
                    File.Delete(filePathForXMLDocUpload); dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
                    File.Delete(filePathForXML); dgvCrItem.DataSource = ""; dgvCrItem.DataBind();
                    
                    dt = new DataTable();
                    dt = objcr.GetLoginInfo(int.Parse(hdnEnroll.Value));
                    if (dt.Rows.Count > 0)
                    {
                        txtName.Text = dt.Rows[0]["EmpInfo"].ToString();
                    }
                    ddlJobType.Visible = false;
                    jobTypeTd.Visible = false;

                    txtCRItem.Visible = false;
                    itemTd.Visible = false;

                    txtQty.Visible = false;
                    quantityTd.Visible = false;

                    btnItemAdd.Visible = false;
                }
                catch { }
            }
            else if (hdnconfirm.Value == "2") { FTPUpload(); }
            else if (hdnconfirm.Value == "3") { FinalUpload(); }
            else if (hdnconfirm.Value == "4") { CalculatePoint(); }
        }

        #region ===== Job Create (Insert Action) =============================================
        
        protected void FinalUpload()
        {
            if (hdnconfirm.Value == "3")
            {
                try
                {
                    intAssignBy = int.Parse(hdnEnroll.Value);
                    try { dteRequiredDate = DateTime.Parse(txtReqDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Required Date Select.');", true); }
                    try { intPOID = int.Parse(txtPOID.Text); } catch { intPOID = 0; }
                    //tmRequiredTime = TimeSpan.Parse(tmsReqTime.Hour.ToString() + ":" + tmsReqTime.Minute.ToString() + ":" + tmsReqTime.Second.ToString());
                    ////tmRequiredTime = TimeSpan.Parse(string.Format("{0}:{1}:{2} {3}", tmsReqTime.Hour, tmsReqTime.Minute, tmsReqTime.Second, tmsReqTime.AmPm));
                    dteDatet = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", tmsReqTime.Hour, tmsReqTime.Minute, tmsReqTime.Second, tmsReqTime.AmPm));
                    tmRequiredTime = TimeSpan.Parse(dteDatet.ToString("HH:mm"));
                    
                    try
                    {
                        char[] ch1 = { '[', ']' };
                        string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                        intAssignTo = int.Parse(temp1[3].ToString());
                    }
                    catch { intAssignTo = 0; }

                    intJobDescriptionID = int.Parse(ddlJobDescription.SelectedValue.ToString());
                    strJobType = ddlJobType.SelectedItem.ToString();
                    
                    if(intJobDescriptionID != 1)
                    {
                        if(ddlJobType.SelectedValue.ToString() == "0")
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Job Type Select.');", true);
                            return;
                        }
                    }

                    try { intTotalPoint = int.Parse(txtPoint.Text); }
                    catch { intTotalPoint = 0; }
                    strRemarks = txtRemarks.Text;

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                        xmlItem = xmlString;
                    }
                    catch { }

                    if(intJobDescriptionID == 1)
                    {
                        if(xmlItem == null)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Item Add.');", true);
                            return;
                        }
                    }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXMLDocUpload);
                        XmlNode dSftTm = doc.SelectSingleNode("DocUpload");
                        xmlStringDocUpload = dSftTm.InnerXml;
                        xmlStringDocUpload = "<DocUpload>" + xmlStringDocUpload + "</DocUpload>";
                        xmlDoc = xmlStringDocUpload;
                    }
                    catch { }

                    if (intJobDescriptionID != 1)
                    {
                        if (xmlDoc == null || intPOID == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Document Add & PO ID Input.');", true);
                            return;
                        }
                    }

                    if (dgvDocUp.Rows.Count > 0)
                    {
                        for (int index = 0; index < dgvDocUp.Rows.Count; index++)
                        {
                            fileName = ((Label)dgvDocUp.Rows[index].FindControl("lblFileName")).Text.ToString();
                            FileUploadFTP(Server.MapPath("~/CreativeSupportModule/Data/"), fileName, "ftp://ftp.akij.net/CreativeSupportModuleDoc/", "erp@akij.net", "erp123");                            
                        }
                    }

                    //Final In Insert
                    string message = objcr.InsertAllBillApproval(intAssignBy, dteRequiredDate, tmRequiredTime, intAssignTo, intJobDescriptionID, strJobType, intTotalPoint, strRemarks, xmlItem, xmlDoc, intPOID);
                    
                    hdnconfirm.Value = "0";                    
                    if (filePathForXML != null) { File.Delete(filePathForXML); }                   
                    if (filePathForXMLDocUpload != null) { File.Delete(filePathForXMLDocUpload); }
                    txtSearchAssignedTo.Text = "";
                    ddlJobDescription.SelectedValue = "0";
                    txtCRItem.Text = "";
                    txtQty.Text = "";
                    txtPoint.Text = "";
                    txtPOID.Text = "";
                    txtRemarks.Text = "";
                    txtReqDate.Text = "";
                    //rdoLarge.Enabled = false;
                    //rdoModerate.Enabled = false;
                    //rdoMinor.Enabled = false;
                    //txtCRItem.Enabled = false;
                    //txtQty.Enabled = false;

                    dgvCrItem.DataSource = ""; dgvCrItem.DataBind();
                    dgvDocUp.DataSource = ""; dgvDocUp.DataBind();

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);

                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion ===========================================================================

        #region ===== Document Brows & Add In Gridview========================================

        protected void FTPUpload()
        {
            if (hdnconfirm.Value == "2")
            {
                if (txtDocUpload.FileName.ToString() != "")
                {
                    int intCount = 0;
                    if (txtDocUpload.HasFiles)
                    {
                        foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                        {
                            strDocUploadPath = Path.GetFileName(uploadedFile.FileName);
                            
                            #region ------------- Way One For Upload In FTP  ---------(WOW It's A Best way)------------
                           
                            fileName = strDocUploadPath.Replace(" ", "");
                            
                            strFileName = fileName.Trim();
                            intCount = intCount + 1;
                            fileName = intCount.ToString() + "_" + hdnEnroll.Value + "_" + fileName.Trim();
                            
                            string FileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                            uploadedFile.SaveAs(Server.MapPath("~/CreativeSupportModule/Data/") + fileName.Trim());

                            //if (FileExtension == "jpeg" || FileExtension == "jpg" || FileExtension == "png")
                            //{                               
                            //    uploadedFile.SaveAs(Server.MapPath("~/CreativeSupportModule/Data/") + fileName.Trim());                               
                            //}
                            //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This picture format not allow, Allow picture format is jpeg, jpg, png');", true); return; }

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
            else { dgvDocUp.DataSource = ""; }
            dgvDocUp.DataBind();
        }
        
        private XmlNode CreateItemNodeDocUpload(XmlDocument doc, string strFileName)
        {
            XmlNode node = doc.CreateElement("DocUpload");

            XmlAttribute StrFileName = doc.CreateAttribute("strFileName"); StrFileName.Value = strFileName;
            
            node.Attributes.Append(StrFileName);           
            return node;
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CalculatePoint();", true);
        }

        protected void dgvDocUp_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
                File.Delete(Server.MapPath("~/CreativeSupportModule/Data/") + fileName);
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

        protected void txtCRItem_TextChanged1(object sender, EventArgs e)
        {

        }

        #endregion ===========================================================================

        #region ===== Document Upload Procedure ==============================================
        protected void DynamicUpload()
        {
            FileUploadFTP(Server.MapPath("~/CreativeSupportModule/Data/"), fileName, "ftp://ftp.akij.net/InternalTransportDocList/", "erp@akij.net", "erp123");
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
                File.Delete(Server.MapPath("~/CreativeSupportModule/Data/") + fileName);
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion ===========================================================================

        #region ===== Web Method (Search Option) =============================================

        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
        }

        protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strJT = ddlJobType.SelectedItem.ToString();

                dt = new DataTable();
                dt = objcr.GetJobTypeWisePoint(strJT);
                if (dt.Rows.Count > 0)
                {
                    txtPoint.Text = dt.Rows[0]["intPoint"].ToString();
                }
                else { txtPoint.Text = "0"; }
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] AutoCreativeItem(string prefixText)
        {
            CreativeS_BLL objAutoSearch_BLL = new CreativeS_BLL();
            return objAutoSearch_BLL.AutoSearchItemCRList(prefixText);
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetEmpListForCreativeSupportList(string prefixText)
        {
            CreativeS_BLL objAutoSearch_BLL = new CreativeS_BLL();
            return objAutoSearch_BLL.AutoEmpListForCreativeSupport(prefixText);
        }

        #endregion ============================================================================

        #region ===== Selection Change Action ================================================

        protected void ddlJobDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJobDescription.SelectedItem.Value == @"0")
            {
                ddlJobType.Visible = false;
                jobTypeTd.Visible = false;

                txtCRItem.Visible = false;
                itemTd.Visible = false;

                txtQty.Visible = false;
                quantityTd.Visible = false;

                poidTd.Visible = false;
                WorkOrderTd.Visible = false;

                btnItemAdd.Visible = false;
            }
            else if(ddlJobDescription.SelectedItem.Value == @"1")
            {
                //ddlJobType.SelectedValue = "0";
                ddlJobType.Visible = false;
                jobTypeTd.Visible = false;

                txtCRItem.Visible = true;
                itemTd.Visible = true;

                txtQty.Visible = true;
                quantityTd.Visible = true;

                poidTd.Visible = false;
                WorkOrderTd.Visible = false;

                btnItemAdd.Visible = true;
            }
            else
            {
                ddlJobType.Visible = true;
                jobTypeTd.Visible = true;

                txtCRItem.Visible = false;
                itemTd.Visible = false;

                txtQty.Visible = false;
                quantityTd.Visible = false;

                poidTd.Visible = true;
                WorkOrderTd.Visible = true;

                btnItemAdd.Visible = false;
                

            }
            txtPoint.Text = "";
            txtCRItem.Text = "";
            txtQty.Text = "";
        }

        protected void CalculatePoint()
        {
            try
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtCRItem.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intItemID = int.Parse(temp1[1].ToString());
                }
                catch { intItemID = 0; }

                dt = new DataTable();
                dt = objcr.GetItemWisePoint(intItemID);
                if (dt.Rows.Count > 0)
                {
                    if(txtQty.Text == "")
                    {
                        qtyq = 0;
                    }
                    else
                    {
                       qtyq = decimal.Parse(txtQty.Text);
                    }
                    //txtPoint.Text = dt.Rows[0]["intPoint"].ToString();
                    hdnPoint.Value = dt.Rows[0]["intPoint"].ToString();
                    txtPoint.Text = (decimal.Parse(hdnPoint.Value) * qtyq).ToString();
                }
                else { txtPoint.Text = "0"; }

            }
            catch { }
        }

        //protected void txtCRItem_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        char[] ch1 = { '[', ']' };
        //        string[] temp1 = txtCRItem.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
        //        intItemID = int.Parse(temp1[1].ToString());
        //    }
        //    catch { intItemID = 0; }

        //    dt = new DataTable();
        //    dt = objcr.GetItemWisePoint(intItemID);
        //    if (dt.Rows.Count > 0)
        //    {
        //        //txtPoint.Text = dt.Rows[0]["intPoint"].ToString();
        //        hdnPoint.Value = dt.Rows[0]["intPoint"].ToString();
        //    }
        //    else { txtPoint.Text = "0"; }

        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CalculatePoint();", true);
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "getFocusOnTextbox();", true);
        //    return;
        //}
        
        //protected void txtSearchEmp_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        char[] ch1 = { '[', ']' };
        //        string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
        //        intAssignTo = int.Parse(temp1[3].ToString());
        //    }
        //    catch { intAssignTo = 0; }
        //}
        
        #endregion ============================================================================

        #region===== Creative Item Add Option ===============================================

        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtCRItem.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                name = temp1[0].ToString();
                itemid = temp1[1].ToString();
            }
            catch { itemid = "0"; }
            
            qty = txtQty.Text;
            point = txtPoint.Text;

            try { intRowCount = int.Parse(dgvCrItem.Rows.Count.ToString()); }
            catch { intRowCount = 0; }

            if(intRowCount >= 3)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Alredy 3 Item Added.');", true);
                txtPoint.Text = "";
                txtQty.Text = "";
                txtCRItem.Text = "";
                return;
            }
            if (ddlJobDescription.SelectedItem.Value=="1")//if its selected DESIGN & POSM
            {
                if (string.IsNullOrEmpty(name) || itemid == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Item Input');", true);
                    return;
                }

                if (qty == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Qty.');", true);
                    return;
                }
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "CalculatePoint", "FTPUpload2();", true);

            if (point != "0")
            {
                CreateVoucherXml(name, qty, point, itemid);
                txtPoint.Text = "";
                txtQty.Text = "";
                txtCRItem.Text = "";
            }           
        }
        private void CreateVoucherXml(string name, string qty, string point, string itemid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, name, qty, point, itemid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("ItemAdd");
                XmlNode addItem = CreateItemNode(doc, name, qty, point, itemid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }
        private void LoadGridwithXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePathForXML);
            XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
            xmlString = dSftTm.InnerXml;
            xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
            StringReader sr = new StringReader(xmlString);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvCrItem.DataSource = ds;
            }
            else
            {
                dgvCrItem.DataSource = "";
            }
            dgvCrItem.DataBind();
        }
        private XmlNode CreateItemNode(XmlDocument doc, string name, string qty, string point, string itemid)
        {
            XmlNode node = doc.CreateElement("ItemAdd");

            XmlAttribute Name = doc.CreateAttribute("name"); Name.Value = name;
            XmlAttribute Qty = doc.CreateAttribute("qty"); Qty.Value = qty;
            XmlAttribute Point = doc.CreateAttribute("point"); Point.Value = point;
            XmlAttribute Itemid = doc.CreateAttribute("itemid"); Itemid.Value = itemid;

            node.Attributes.Append(Name);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Point);
            node.Attributes.Append(Itemid);
            return node;
        }
        protected void dgvCrItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("ItemAdd");
                xmlString = dSftTm.InnerXml;
                xmlString = "<ItemAdd>" + xmlString + "</ItemAdd>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                dgvCrItem.DataSource = ds;

                DataSet dsGrid = (DataSet)dgvCrItem.DataSource;
                dsGrid.Tables[0].Rows[dgvCrItem.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXML);
                DataSet dsGridAfterDelete = (DataSet)dgvCrItem.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                {
                    File.Delete(filePathForXML); dgvCrItem.DataSource = ""; dgvCrItem.DataBind();
                }
                else { LoadGridwithXml(); }
            }
            catch { }
        }
        protected int totalqty = 0;
        protected int totalpoint = 0;
        protected void dgvCrItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    totalqty += int.Parse(((Label)e.Row.Cells[2].FindControl("lblQty")).Text);
                    totalpoint += int.Parse(((Label)e.Row.Cells[3].FindControl("lblPoint")).Text);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion ==========================================================================

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchAssignedTo.Text = "";
            ddlJobDescription.SelectedValue = "0";
            txtCRItem.Text = "";
            txtQty.Text = "";
            txtPoint.Text = "";
            txtPOID.Text = "";
            txtRemarks.Text = "";
            //txtReqDate.Text = "";
            //rdoLarge.Checked = false;
            //rdoModerate.Checked = false;
            //rdoMinor.Checked = false;
            //rdoLarge.Enabled = false;
            //rdoModerate.Enabled = false;
            //rdoMinor.Enabled = false;
            //txtCRItem.Enabled = false;
            //txtQty.Enabled = false;

            dgvCrItem.DataSource = ""; dgvCrItem.DataBind();
            dgvDocUp.DataSource = ""; dgvDocUp.DataBind();
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
        }

        




















    }
}