using SCM_BLL;
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

namespace UI.SCM
{
    public partial class SupplierAccountInfoChange : BasePage
    {
        string filePathForXMLDocUpload, xmlStringDocUpload, fileName;
        InventoryTransfer_BLL objBll = new InventoryTransfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                filePathForXMLDocUpload = Server.MapPath("~/Inventory/Data/DocUpload_" + Session[SessionParams.UNIT_ID].ToString() + ".xml");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string RequesterName, RequesterDesignation, SupplierName, SupplierAddress, RoutingNo, msg;
            int AccountNo, RequestBy, SuperviseBy;
            DateTime dteRequestBy, dteSuperviseBy;

            RequesterName = txtRequesterName.Text;
            RequesterDesignation = txtRequesterDesignation.Text;
            SupplierName = txtSupplierName.Text;
            SupplierAddress = txtSupplierAddress.Text;
            RoutingNo = txtRoutingNo.Text;
            AccountNo = Convert.ToInt32(txtAccountNo.Text);
            RequestBy = Convert.ToInt32(txtRequestBy.Text);
            SuperviseBy = Convert.ToInt32(txtSuperviseBy.Text);
            dteRequestBy = DateTime.Parse(txtRequestDate.Text);
            dteSuperviseBy = DateTime.Parse(txtApproveDate.Text);
            msg = objBll.InsertSupplierAccountsInfoList(RequesterName, RequesterDesignation, SupplierName, SupplierAddress, AccountNo, RoutingNo, RequestBy, SuperviseBy, dteRequestBy, dteSuperviseBy);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            ClearControl();
        }

        private void ClearControl()
        {
            txtRequesterName.Text = "";
            txtRequesterDesignation.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtRoutingNo.Text = "";
            txtAccountNo.Text = "";
            txtRequestBy.Text = "";
            txtSuperviseBy.Text = "";
            txtRequestDate.Text = "";
            txtApproveDate.Text = "";
        }

        #region============stas file upload=============
        protected void FTPUpload()
        {
            

            //hdnconfirm.Value = "0";

            #endregion

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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strDocUploadPath, fileName, strFileName;
            //if (hdnconfirm.Value == "2")
            //{
            ////string strDat = DateTime.Now.ToString("yyyy-MM-dd");

            if (txtDocUpload.FileName.ToString() != "")
            {
                //intDocType = int.Parse(ddlDocType.SelectedValue.ToString());
                //strDocName = ddlDocType.SelectedItem.ToString();
                //intID = int.Parse(hdnEnroll.Value);
                try
                {
                    //dteSubmitDate = DateTime.Parse(txtStartDate.Text);
                    //////strSubmitDate = txtStartDate.Text;
                }
                catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Submit Date Properly Input.');", true); return; }

                int intCount = 0;
                if (txtDocUpload.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in txtDocUpload.PostedFiles)
                    {
                        strDocUploadPath = Path.GetFileName(uploadedFile.FileName);

                        strDocUploadPath = txtRequestBy.Text + "_" + txtRequestDate.Text + "_" + strDocUploadPath;
                        //doctypeid = intDocType.ToString();

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
                        CreateVoucherXmlDocUpload("5", "Bank Information", strFileName);
                    }
                }
            }
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
            catch { }

        }


    }

    #endregion===========end upload code===========


}
